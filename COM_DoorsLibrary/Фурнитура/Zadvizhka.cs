using System;
using COM_DoorsLibrary;
using static DM;

internal class Zadvizhka
{
    private readonly ZadvizhkaDatas zadvizhkaDatas;

    private readonly IniFile ini;
    private readonly string OtstupSuf;

    public Zadvizhka(ref DMParam param, ref Constants cons, ref IniFile iniDM)
    {
        ini = new IniFile(cons.DIR_CONS_FURNIT + "\\Zadvizhki.ini");

        var koef90 = cons.CompareKod(param.Kod, "ДМ", "(70)") || cons.CompareKod(param.Kod, "ЛМ", "(70)") 
            ? (short.Parse(iniDM.ReadKey("Koef", "KOEF_90"))) 
            : (short)0;

        var koef62 = cons.ST62 & cons.CompareKod(param.Kod, "ДМ", "(62)") || cons.CompareKod(param.Kod, "ЛМ", "(62)")
            ? short.Parse(iniDM.ReadKey("Koef", "KOEF_62")) 
            : (short)0;

        zadvizhkaDatas.Kod = param.Zadvizhka.Kod;
        zadvizhkaDatas.OtPola = param.Zadvizhka.OtPola > 0 ? param.Zadvizhka.OtPola : (short)cons.ZADVIZHKA_OT_POLA;
        
        zadvizhkaDatas.OtKrayaVA = double.Parse(ini.ReadKey(IniSection(zadvizhkaDatas.Kod), IniKey(param, false))) + 
                                   koef62 + 
                                   (koef90 > 0 ? (koef90 / 2) - 6 : 0);

        zadvizhkaDatas.VertOtKraya = double.Parse(ini.ReadKey(IniSection(zadvizhkaDatas.Kod), IniKey(param, true))) + 
                                     koef62 + 
                                     koef90 / 2;

        if (cons.CompareKod(param.Kod, "ДМ", "(70)") || cons.CompareKod(param.Kod, "ЛМ", "(70)"))
            OtstupSuf = "_70";
        else if(cons.CompareKod(param.Kod, "ДМ", "(62)") || cons.CompareKod(param.Kod, "ЛМ", "(62)"))
            OtstupSuf = "_62";
        else
            OtstupSuf = "_53";
    }

    private string IniSection(short kod)
    {
        return kod >= Enum.GetNames(typeof(ZadvizhkaNames)).Length 
            ? "0" 
            : kod.ToString();
    }
    private string IniKey(DMParam param, bool vert)
    {
        if (vert)
        {
            if (param.Otkrivanie.Value == Otkrivanie.ЛевоеВО | param.Otkrivanie.Value == Otkrivanie.ПравоеВО)
                return "VERT_OT_KRAYA_VO";

            if (param.Thick_VL.EqualsDouble(2))
                return param.WAktiv.Value.EqualsDouble(0) 
                    ? "DM1_VERT_OT_KRAYA_T2" 
                    : "DM2_VERT_OT_KRAYA_T2";
            
            return "VERT_OT_KRAYA";
        }

        if (param.Thick_VL.EqualsDouble(2))
                return param.WAktiv.Value.EqualsDouble(0) 
                    ? "DM1_OT_KRAYA_VA_T2" 
                    : "DM2_OT_KRAYA_VA_T2";

        return "OT_KRAYA_VA";
    }

    public ZadvizhkaDatas Datas => zadvizhkaDatas;
    public double OtKrayaVA => zadvizhkaDatas.OtKrayaVA;
    public double VertushokOtKraya => zadvizhkaDatas.VertOtKraya;
    public short OtPola => zadvizhkaDatas.OtPola;
    public short Kod => zadvizhkaDatas.Kod;
    public double Otvetka_Otstup(short stoykaType)
    {
        if (zadvizhkaDatas.Kod != (int) ZadvizhkaNames.Ночной_сторож) return 0;

        string sufNk;
        switch (stoykaType)
        {
            case 1:
                sufNk = "_K1";
                break;
            case 2:
                sufNk = "_K2";
                break;
            default:
                sufNk = "_K3";
                break;
        }

        return double.Parse(ini.ReadKey(zadvizhkaDatas.Kod.ToString(), "OTV_OTSTUP" + sufNk + OtstupSuf));
    }
}

public struct ZadvizhkaDatas
{
    public short Kod;
    public string Name;
    public short OtPola;
    public double OtKrayaVA; 
    public double VertOtKraya;
}
