using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Termoblockerator
{
    private readonly IniFile ini;

    private double otKraya, otstup;

    private short koef62, koef90;

    private readonly StvorkaDM stvorka;

    internal Termoblockerator(int pos, ref DMParam param, ref Constants cons, ref IniFile iniDM, in StvorkaDM stvorka)
    {
        ini = new IniFile(cons.DIR_CONS_FURNIT + "\\Termoblockerator.ini");

        koef90 = cons.CompareKod(param.Kod, "ДМ", "(70)") 
            ? short.Parse(iniDM.ReadKey("Koef", "KOEF_90")) 
            : (short)0;
        koef62 = cons.ST62 & cons.CompareKod(param.Kod, "ДМ", "(62)") 
            ? short.Parse(iniDM.ReadKey("Koef", "KOEF_62")) 
            : (short)0;

        this.stvorka = stvorka;

        otKraya = GetOtKraya(param);
        otstup = GetOtstup(pos, param);
    }

    private double GetOtKraya(DMParam param)
    {
        switch (param.Otkrivanie.Value)
        {
            case Otkrivanie.Левое:
                return param.Nalichniki[(short)Raspolozhenie.Лев] == 0
                    ? stvorka.Width - double.Parse(ini.ReadKey("Termoblock", "OT_KRAYA_K2"))
                    : stvorka.Width - double.Parse(ini.ReadKey("Termoblock", "OT_KRAYA_K1"));

            case Otkrivanie.Правое:
                return param.Nalichniki[(short)Raspolozhenie.Прав] == 0
                    ? stvorka.Width - double.Parse(ini.ReadKey("Termoblock", "OT_KRAYA_K2"))
                    : stvorka.Width - double.Parse(ini.ReadKey("Termoblock", "OT_KRAYA_K1"));

            case Otkrivanie.ЛевоеВО:
            case Otkrivanie.ПравоеВО:
            default:
                return stvorka.Width - double.Parse(ini.ReadKey("Termoblock", "OT_KRAYA_K3"));
        }
    }

    private double GetOtstup(int pos, DMParam param)
    {
        if (pos == 0)
        {
            if(param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое)
                return param.EIS
                    ? double.Parse(ini.ReadKey("Termoblock", "OTSTUP_K1_EIS"))
                    : double.Parse(ini.ReadKey("Termoblock", "OTSTUP_K1"));
            return param.EIS
                ? double.Parse(ini.ReadKey("Termoblock", "OTSTUP_K3_EIS")) + (double)koef90 /4
                : double.Parse(ini.ReadKey("Termoblock", "OTSTUP_K3")) + (double)koef90 /4;
        }

        switch (param.Porog.Kod)
        {
            case 40:
            case 41:
                return double.Parse(ini.ReadKey("Termoblock", "OTSTUP_POR_40")) + (double)koef62 / 2 + (double)koef90 / 4;
            case 100:
                return double.Parse(ini.ReadKey("Termoblock", "OTSTUP_POR_100")) + (double)koef62 / 2 + (double)koef90 / 4;
            case 14:
                return double.Parse(ini.ReadKey("Termoblock", "OTSTUP_POR_14")) + (double)koef62 / 2 + (double)koef90 / 4;
            case 15:
                return double.Parse(ini.ReadKey("Termoblock", "OTSTUP_POR_15")) + (double)koef62 / 2 + (double)koef90 / 4;
            case 25:
                return double.Parse(ini.ReadKey("Termoblock", "OTSTUP_POR_25")) + (double)koef62 / 2 + (double)koef90 / 4;
            case 26:
                return double.Parse(ini.ReadKey("Termoblock", "OTSTUP_POR_26")) + (double)koef62 / 2 + (double)koef90 / 4;
            case 30:
                return double.Parse(ini.ReadKey("Termoblock", "OTSTUP_POR_30")) + (double)koef62 / 2 + (double)koef90 / 4;
        }

        return 0;
    }

    internal TermoblockDatas Datas => new TermoblockDatas(otKraya, otstup);
    internal double OtKraya => otKraya;
    internal double Otstup => otstup;
}

public struct TermoblockDatas
{
    public double OtKraya;
    public double Otstup;

    public TermoblockDatas(double otKraya, double otstup)
    {
        OtKraya = otKraya;
        Otstup = otstup;
    }
}
