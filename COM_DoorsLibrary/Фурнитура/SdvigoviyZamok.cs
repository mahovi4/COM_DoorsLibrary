using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class SdvigoviyZamok
{
    internal double OtKraya { get; } 
    internal double Otstup { get; }

    internal string Name { get; }
    internal string NameVirez { get; }
    internal string NameSkatch { get; }

    private readonly IniFile ini;
    private readonly StvorkaDM stvorka;

    private readonly short koef62, koef90;

    internal SdvigoviyZamok(string name, ref DMParam param, ref Constants cons, ref IniFile iniDM, in StvorkaDM stvorka)
    {
        ini = new IniFile(cons.DIR_CONS_FURNIT + "\\SdvigoviyZamok.ini");

        this.stvorka = stvorka;

        koef90 = cons.CompareKod(param.Kod, "ДМ", "(70)")
            ? short.Parse(iniDM.ReadKey("Koef", "KOEF_90"))
            : (short)0;
        koef62 = cons.ST62 & cons.CompareKod(param.Kod, "ДМ", "(62)")
            ? short.Parse(iniDM.ReadKey("Koef", "KOEF_62"))
            : (short)0;

        Name = ini.ReadKey(name, "Name");
        NameVirez = ini.ReadKey(name, 
            param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое ? "NameNO" : "NameVO");
        NameSkatch = ini.ReadKey(name,
            param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое ? "NameSNO" : "NameSVO");

        OtKraya = GetOtKraya(name, param);
        Otstup = GetOtstup(name, param);
    }

    private double GetOtstup(string name, DMParam param)
    {
        if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое)
            return param.EIS
                ? double.Parse(ini.ReadKey(name, "OTSTUP_K1_EIS"))
                : double.Parse(ini.ReadKey(name, "OTSTUP_K1"));
        return param.EIS
            ? double.Parse(ini.ReadKey(name, "OTSTUP_K3_EIS")) + (double)koef62/2 + (double)koef90/4
            : double.Parse(ini.ReadKey(name, "OTSTUP_K3")) + (double)koef62/2 + (double)koef90/4;
    }

    private double GetOtKraya(string name, DMParam param)
    {
        switch (param.Otkrivanie.Value)
        {
            case Otkrivanie.Левое:
                return param.Nalichniki[(short)Raspolozhenie.Лев] == 0
                    ? stvorka.Width - double.Parse(ini.ReadKey(name, "OT_KRAYA_K2"))
                    : stvorka.Width - double.Parse(ini.ReadKey(name, "OT_KRAYA_K1"));

            case Otkrivanie.Правое:
                return param.Nalichniki[(short)Raspolozhenie.Прав] == 0
                    ? stvorka.Width - double.Parse(ini.ReadKey(name, "OT_KRAYA_K2"))
                    : stvorka.Width - double.Parse(ini.ReadKey(name, "OT_KRAYA_K1"));

            case Otkrivanie.ЛевоеВО:
            case Otkrivanie.ПравоеВО:
            default:
                return stvorka.Width - double.Parse(ini.ReadKey(name, "OT_KRAYA_K3"));
        }
    }

    public SdvigoviyData Data => new SdvigoviyData
    {
        OtKraya = OtKraya,
        Otstup = Otstup,
        Name = Name,
        NameVirez = NameVirez,
        NameSkatch = NameSkatch
    };
}

public struct SdvigoviyData
{
    public double OtKraya;
    public double Otstup;
    public string Name;
    public string NameVirez;
    public string NameSkatch;
}
