using System;
using System.Collections.Generic;
using System.Linq;
using COM_DoorsLibrary;
using static DM;

internal class Zamok
{
    private ZamokDatas zamokDatas;
    
    private readonly Constants cons;
    private readonly IniFile ini;
    private readonly DMParam param;

    private readonly string[] sufName = { "_AS", "_OPS", "_OK1", "_OK3", "_PS" };

    public Zamok(short num, ref DMParam param, ref Constants cons)
    {
        this.param = param;
        this.cons = cons;

        ini = new IniFile(IniPath(param.Zamok[num].Kod));

        zamokDatas.Kod = param.Zamok[num].Kod;
        zamokDatas.Name = ini.ReadKey("Names", "NAME");
        zamokDatas.VirezNames = new List<string>();
        zamokDatas.SketchNames = new List<string>();
        zamokDatas.SketchSufName = " " + ini.ReadKey("Names", "NAME_SUF_UP");
        for (var i=0; i<Enum.GetNames(typeof(ZamokSketchTypes)).Length; i++)
        {
            zamokDatas.VirezNames.Add(ini.ReadKey("Names", "NAME_VIREZ" + sufName[i]));
            zamokDatas.SketchNames.Add(ini.ReadKey("Names", "NAME_SKETCH" + sufName[i]));
        }
        zamokDatas.Suvald = bool.Parse(ini.ReadKey("1", "SUVALD"));
        zamokDatas.CM = param.Zamok[num].Cilinder;
        zamokDatas.Mezhosevoe = short.Parse(ini.ReadKey("1", "MEZHOSEVOE"));
        zamokDatas.Ruchka = bool.Parse(ini.ReadKey("1", "RUCHKA"));
        
        if (zamokDatas.Suvald) zamokDatas.CM = false;
        //if (zamokDatas.Ruchka) zamokDatas.Ruchka = param.Zamok[num].Ruchka;
        
        if (num == 0)
        {
            if (param.Height <= 1250)
            {
                zamokDatas.OtPola = (short)(param.Height / 2 + 50);
            }
            else
            {
                if (param.Zamok[num].OtPola > 0 & param.Zamok[num].OtPola != cons.RUCHKA_OT_POLA)
                    zamokDatas.OtPola = param.Zamok[num].OtPola;
                else
                {
                    short k = 0;
                    if (zamokDatas.Kod == (int) DM_Zamok1Names.Меттем_842 |
                        zamokDatas.Kod == (int) DM_Zamok1Names.Гардиан_32_01)
                        k = 6;
                    else if (zamokDatas.Kod == (int) DM_Zamok1Names.Бордер_ЗВ8_6 |
                             zamokDatas.Kod == (int) DM_Zamok1Names.Гардиан_30_01)
                        k = 10;
                    zamokDatas.OtPola = (short) (cons.RUCHKA_OT_POLA - k);
                }
            }
        }
        else
        {
            if (param.Zamok[num].OtPola > 0 & param.Zamok[num].OtPola != cons.ZAMOK2_OT_POLA)
                zamokDatas.OtPola = param.Zamok[num].OtPola;
            else
                zamokDatas.OtPola = (short)cons.ZAMOK2_OT_POLA;
        }

        zamokDatas.OtvOtPola = zamokDatas.OtPola + double.Parse(ini.ReadKey("1", "K_OTV_OT_POLA"));
        zamokDatas.OtKrayaLA = double.Parse(ini.ReadKey(IniSection(true), "OT_KRAYA_LA"));
        zamokDatas.OtKrayaVA = double.Parse(ini.ReadKey(IniSection(false), "OT_KRAYA_VA"));
        zamokDatas.OtTelaVA = double.Parse(ini.ReadKey(IniSection(false), "OT_TELA_VA"));
        zamokDatas.OtKrayaLP = double.Parse(ini.ReadKey(IniSection(true), "OT_KRAYA_LP"));

        if(param.RuchkaAS[0].Kod == (short)RuchkaNames.PB_1300 & param.RuchkaPS[0].Kod < 11)
        {
            zamokDatas.OtKrayaVA += 2;
            zamokDatas.OtTelaVA += 2;
        }
        if(param.RuchkaPS[0].Kod == (short)RuchkaNames.PB_1300 | 
           param.RuchkaPS[0].Kod == (short)RuchkaNames.PB_1700A | 
           param.RuchkaPS[0].Kod == (short)RuchkaNames.АП_DoorLock)
        {
            if (cons.CompareKod(param.Kod, "(62)") & cons.ST62)
            {
                if (param.Thick_LL == 2)
                    zamokDatas.OtKrayaLP = double.Parse(ini.ReadKey("OTV_Z", "OT_KRAYA_LP_62_T2"));
                else
                    zamokDatas.OtKrayaLP = double.Parse(ini.ReadKey("OTV_Z", "OT_KRAYA_LP_62"));
            }
            else
            {
                if (param.Thick_LL == 2)
                    zamokDatas.OtKrayaLP = double.Parse(ini.ReadKey("OTV_Z", "OT_KRAYA_LP_53_T2"));
                else
                    zamokDatas.OtKrayaLP = double.Parse(ini.ReadKey("OTV_Z", "OT_KRAYA_LP_53"));
            }   
        }

        var sovmest = ini.ReadKey("1", "SOVMEST_RUCHKI");
        if (string.IsNullOrWhiteSpace(sovmest) || sovmest.Equals("_"))
        {
            zamokDatas.SovmestRuchki = Array.Empty<int>();
            return;
        }
        var arr = sovmest.Split('_');
        var list = new List<int>();
        foreach(var str in arr)
            if(int.TryParse(str, out var kod))
                list.Add(kod);

        zamokDatas.SovmestRuchki = list.ToArray();
    }

    private string IniPath(int kod)
    {
        switch (kod)
        {
            case (int)ZamokNames.ПП:
                return cons.DIR_CONS_ZAMOK + "\\DL.ini";
            case (int)ZamokNames.Просам_ЗВ_4:
                return cons.DIR_CONS_ZAMOK + "\\Prosam_ZV4.ini";
            case (int)ZamokNames.Фуаро_900:
                return cons.DIR_CONS_ZAMOK + "\\Fuaro_900.ini";
            case (int)ZamokNames.Просам_ЗВ_8:
                return cons.DIR_CONS_ZAMOK + "\\Prosam_ZV8.ini";
            case (int)ZamokNames.Меттем_842:
                return cons.DIR_CONS_ZAMOK + "\\Mettem_842.ini";
            case (int)ZamokNames.Гардиан_12_11:
                return cons.DIR_CONS_ZAMOK + "\\Gardian_12_11.ini";
            case (int)ZamokNames.Гардиан_30_01:
                return cons.DIR_CONS_ZAMOK + "\\Gardian_30_01.ini";
            case (int)ZamokNames.Apecs_R_0002_CR:
                return cons.DIR_CONS_ZAMOK + "\\Apecs_R0002_CR.ini";
            case (int)ZamokNames.Apecs_T_52:
                return cons.DIR_CONS_ZAMOK + "\\Apecs_T52.ini";
            case (int)ZamokNames.Бордер_ЗВ8_6:
                return cons.DIR_CONS_ZAMOK + "\\Border_ZV8_6.ini";
            case (int)ZamokNames.Гардиан_32_11:
                return cons.DIR_CONS_ZAMOK + "\\Gardian_32_11.ini";
            case (int)ZamokNames.Гардиан_10_01:
                return cons.DIR_CONS_ZAMOK + "\\Gardian_10_01.ini";
            case (int)ZamokNames.Гардиан_12_01:
                return cons.DIR_CONS_ZAMOK + "\\Gardian_12_01.ini";
            case (int)ZamokNames.Гардиан_35_11:
                return cons.DIR_CONS_ZAMOK + "\\Gardian_35_11.ini";
            case (int)ZamokNames.Гардиан_30_11:
                return cons.DIR_CONS_ZAMOK + "\\Gardian_30_11.ini";
            case (int)ZamokNames.Гардиан_32_01:
                return cons.DIR_CONS_ZAMOK + "\\Gardian_32_01.ini";
            case (int)ZamokNames.Apecs_30_R:
                return cons.DIR_CONS_ZAMOK + "\\Apecs_30_R.ini";
            case (int)ZamokNames.Crit_7_RPM:
                return cons.DIR_CONS_ZAMOK + "\\Crit_7_RPM.ini";
            case (int)ZamokNames.ECO_GBS_81:
                return cons.DIR_CONS_ZAMOK + "\\ECO_GBS_81.ini";
            default:
                return "";
        }
    }
    private string IniSection(bool ll)
    {
        if (cons.CompareKod(param.Kod, "ДМ-1") | cons.CompareKod(param.Kod, "ЛМ-1"))
        {
            if (cons.CompareKod(param.Kod, "(70)"))
            {
                if (ll)
                    return param.Thick_LL.EqualsDouble(2) 
                        ? "DM1_90_T2" 
                        : "DM1_90";
                return param.Thick_VL.EqualsDouble(2) 
                    ? "DM1_90_T2" 
                    : "DM1_90";
            }
            if (cons.CompareKod(param.Kod, "(53)") | (cons.CompareKod(param.Kod, "(62)") & !cons.ST62))
            {
                if (ll)
                    return param.Thick_LL.EqualsDouble(2) 
                        ? "DM1_53_T2" 
                        : "DM1_53";
                return param.Thick_VL.EqualsDouble(2) 
                        ? "DM1_53_T2" 
                        : "DM1_53";
            }
            if (cons.CompareKod(param.Kod, "(62)") & cons.ST62)
            {
                if (ll)
                    return param.Thick_LL.EqualsDouble(2) 
                        ? "DM1_62_T2" 
                        : "DM1_62";
                return param.Thick_VL.EqualsDouble(2) 
                        ? "DM1_62_T2" 
                        : "DM1_62";
            }
            return "";
        }
        if (cons.CompareKod(param.Kod, "ДМ-2") | cons.CompareKod(param.Kod, "ЛМ-2") | cons.CompareKod(param.Kod, "MAX"))
        {
            if (cons.CompareKod(param.Kod, "(70)"))
            {
                if (ll)
                    return param.Thick_LL.EqualsDouble(2) 
                        ? "DM2_90_T2" 
                        : "DM2_90";
                return param.Thick_VL.EqualsDouble(2) 
                    ? "DM2_90_T2" 
                    : "DM2_90";
            }
            if (cons.CompareKod(param.Kod, "(53)") | (cons.CompareKod(param.Kod, "(62)") & !cons.ST62))
            {
                if (ll)
                    return param.Thick_LL.EqualsDouble(2)
                        ? "DM2_53_T2" 
                        : "DM2_53";
                return param.Thick_VL.EqualsDouble(2) 
                    ? "DM2_53_T2" 
                    : "DM2_53";
            }
            if (cons.CompareKod(param.Kod, "(62)") & cons.ST62)
            {
                if (ll)
                    return param.Thick_LL.EqualsDouble(2)
                        ? "DM2_62_T2" 
                        : "DM2_62";
                return param.Thick_VL.EqualsDouble(2)
                    ? "DM2_62_T2" 
                    : "DM2_62";
            }
            return "";
        }
        return "";
    }

    public ZamokDatas Datas => zamokDatas;

    public void Move(short offset)
    {
        zamokDatas.OtPola += offset;
        zamokDatas.OtvOtPola += offset;
    }

    public double Otstup(int typeStoyki)
    {
        string secName;
        string parName;
        if (typeStoyki == 1)
            parName = "OTSTUP_OTV_K1";
        else if(typeStoyki == 3)
            parName = "OTSTUP_OTV_K3";
        else
        {
            if(param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
                parName = "OTSTUP_OTV_K2";
            else
                parName = "OTSTUP_OTV_K3";
        }
        if (param.Kod == cons.KodFromString("ДМ-1(62)") & cons.ST62)
            secName = "OTV_62";
        else if (param.Kod == cons.KodFromString("ДМ-1(70)"))
            secName = "OTV_70";
        else
            secName = "OTV_53";
        return double.Parse(ini.ReadKey(secName, parName));
    }
    public double OtKrayaLA => zamokDatas.OtKrayaLA;
    public double OtKrayaVA => zamokDatas.OtKrayaVA;
    public double OtKrayaLP => zamokDatas.OtKrayaLP;
    public double OtTelaVA => zamokDatas.OtTelaVA;
    public short OtPola => zamokDatas.OtPola;
    public double OtvOtPola => zamokDatas.OtvOtPola;
    public string Name => zamokDatas.Name;
    public short Index => zamokDatas.Kod;

    public bool IsSovmestima(short ruchkaKod)
    {
        return zamokDatas.SovmestRuchki
            .Any(kod => kod == ruchkaKod);
    }
}

public struct ZamokDatas
{
    public short Kod;
    public string Name;
    public List<string> VirezNames;
    public List<string> SketchNames;
    public string SketchSufName;
    public bool Suvald;
    public bool CM;
    public short Mezhosevoe;
    public bool Ruchka;
    public short OtPola;
    public double OtKrayaLA;
    public double OtKrayaVA;
    public double OtKrayaLP;
    public double OtTelaVA;
    public double OtvOtPola;
    public int[] SovmestRuchki;
}
public struct Antipanika
{
    public double OtLKrayaVA;
    public double OtLKrayaVP;
    public double OtPKrayaVP;
}
public enum ZamokSketchTypes
{
    На_Активке,
    Ответка_Пассивка,
    Ответка_К1,
    Ответка_К3,
    Ответный_замок
}
