using static DM;

internal class TorcShpingalet
{
    private readonly ShpingaletDatas shpingaletParam;

    private readonly IniFile ini;

    public TorcShpingalet(int pos, ref DMParam param, ref Constants cons, ref IniFile iniDM)
    {
        ini = new IniFile(cons.DIR_CONS_FURNIT + "\\TorcSpingalet.ini");
        shpingaletParam = new ShpingaletDatas { };

        var koef90 = cons.CompareKod(param.Kod, "ДМ", "(70)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_90")) : (short)0;
        var koef62 = cons.ST62 & cons.CompareKod(param.Kod, "ДМ", "(62)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_62")) : (short)0;

        shpingaletParam.OtKraya = double.Parse(ini.ReadKey("TorcShpingalet", "OT_KRAYA")) + (koef62 / 2) + (koef90 / 4);

        if (param.Otkrivanie.Value == Otkrivanie.Левое) 
        {
            if (pos == 0)
            {
                shpingaletParam.OtvOtstup = param.EIS ? double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_OTP_GST_K1_EIS"))
                                                      : double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_OTP_GST_K1"));
            }
            shpingaletParam.OtvOtKraya = param.Nalichniki[(short)Raspolozhenie.Лев] == 0 
                ? param.WAktiv.Value + double.Parse(ini.ReadKey("TorcShpingalet", "K_OTVTS_GST_K2")) 
                : param.WAktiv.Value + double.Parse(ini.ReadKey("TorcShpingalet", "K_OTVTS_GST_K1"));
        } 
        else if (param.Otkrivanie.Value == Otkrivanie.Правое)  
        {
            if (pos == 0)
            {
                shpingaletParam.OtvOtstup = param.EIS ? double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_OTP_GST_K1_EIS"))
                                                      : double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_OTP_GST_K1"));
            }
            shpingaletParam.OtvOtKraya = param.Nalichniki[(short)Raspolozhenie.Прав] == 0
                ? param.WAktiv.Value + double.Parse(ini.ReadKey("TorcShpingalet", "K_OTVTS_GST_K2")) 
                : param.WAktiv.Value + double.Parse(ini.ReadKey("TorcShpingalet", "K_OTVTS_GST_K1"));
        } 
        else 
        {
            if (pos == 0)
            {
                shpingaletParam.OtvOtstup = param.EIS 
                    ? double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_OTP_GST_K3_EIS")) + (koef62 / 2) + (koef90 / 4)
                    : double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_OTP_GST_K3")) + (koef62 / 2) + (koef90 / 4);
            }
            shpingaletParam.OtvOtKraya = param.WAktiv.Value + double.Parse(ini.ReadKey("TorcShpingalet", "K_OTVTS_GST_K3"));
        }

        switch (param.Porog.Kod) {
            case 40:
            case 41:
                if (pos == 1)
                {
                    shpingaletParam.OtvOtstup = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_POR_40")) + (koef62 / 2) + (koef90 / 4);
                }
                shpingaletParam.Diam = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_D_POR"));
                break;
            case 100:
                if (pos == 1)
                {
                    shpingaletParam.OtvOtstup = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_POR_100")) + (koef62 / 2) + (koef90 / 4);
                }
                shpingaletParam.Diam = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_D_POR"));
                break;
            case 14:
                if (pos == 1)
                {
                    shpingaletParam.OtvOtstup = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_POR_14")) + (koef62 / 2) + (koef90 / 4);
                }
                shpingaletParam.Diam = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_D_POR_14"));
                break;
            case 15:
                if (pos == 1)
                {
                    shpingaletParam.OtvOtstup = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_POR_15")) + (koef62 / 2) + (koef90 / 4);
                }
                shpingaletParam.Diam = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_D_POR"));
                break;
            case 25:
                if (pos == 1)
                {
                    shpingaletParam.OtvOtstup = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_POR_25")) + (koef62 / 2) + (koef90 / 4);
                }
                shpingaletParam.Diam = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_D_POR"));
                break;
            case 26:
                if (pos == 1)
                {
                    shpingaletParam.OtvOtstup = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_POR_26")) + (koef62 / 2) + (koef90 / 4);
                }
                shpingaletParam.Diam = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_D_POR"));
                break;
            case 30:
                if (pos == 1)
                {
                    shpingaletParam.OtvOtstup = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_POR_30")) + (koef62 / 2) + (koef90 / 4);
                }
                shpingaletParam.Diam = double.Parse(ini.ReadKey("TorcShpingalet", "OTVTS_D_POR"));
                break;
        }
    }

    public ShpingaletDatas Datas
    {
        get { return shpingaletParam; }
    }
    public double OtKraya
    {
        get { return shpingaletParam.OtKraya; }
    }
    public double Otvetka_Diam
    {
        get
        {
            return shpingaletParam.Diam;
        }
    }
    public double Otvetka_OtKraya
    {
        get { return shpingaletParam.OtvOtKraya; }
    }
    public double Otvetka_Otstup
    {
        get { return shpingaletParam.OtvOtstup; }
    }
}

public struct ShpingaletDatas
{
    public short Kod;
    public double OtKraya;
    public double OtvOtstup;
    public double OtvOtKraya;
    public double Diam;
}
