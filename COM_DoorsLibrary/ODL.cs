using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

[Guid("182526ac-9e3e-4d1e-ad0d-3c4ab6a53725")]
public interface IODL
{
    [DispId(1)]
    [Description("Производит расчет изделия.")]
    void Init(ODLParam data);

    [DispId(2)]
    [Description("Возвращает список ошибок, возникших в процессе расчета (в противном случае - пустая строка).")]
    string Errors{get;set;}

    [DispId(3)]
    [Description("Возвращает список конструкционных проблем, возникших в процессе расчета (в противном случае - пустая строка).")]
    string Problems{get;set;}

    [DispId(4)]
    [Description("Возвращает номер соответствующей строки в таблице конструирования.")]
    int Row{get;}

    [DispId(5)]
    [Description("Возвращает номер изделия, присваеваемый изделию системой 1С.")]
    string Num{get;}

    [DispId(6)]
    [Description("Возвращает имя DXF-файла детали по ее индексу.")]
    string Name(short index);

    [DispId(7)]
    [Description("Возвращает сторону открывания изделия.")]
    Otkrivanie Otkrivanie{get; }

    [DispId(8)]
    [Description("Возвращает наличие пассивной створки в изделии.")]
    bool IsPassivka{get;}

    [DispId(9)]
    [Description("Возвращает ширину створки изделия по ее расположению.")]
    double Stvorka_Width(Stvorka stvorka);

    [DispId(10)]
    [Description("Возвращает высоту лицевого листа изделия.")]
    short LicevoyList_Height{get;}

    [DispId(11)]
    [Description("Возвращает ширину лицевого листа изделия по его расположению.")]
    short LicevoyList_Width(Stvorka stvorka);


    [DispId(12)]
    [Description("Возвращает величину отступа лицевого листа изделия от пола.")]
    short LicevoyList_OtPola { get; }

    [DispId(13)]
    [Description("Возвращает величину отступа замкового профиля изделия от пола.")]
    short ZamkovoyProfil_OtPola {get;}

    [DispId(14)]
    [Description("Возвращает высоту замкового профиля изделия.")]
    short ZamkovoyProfil_Height(Stvorka stvorka);

    [DispId(15)]
    [Description("Возвращает развертку замкового профиля изделия.")]
    short ZamkovoyProfil_Razvertka(Stvorka stvorka);

    [DispId(16)]
    [Description("Возвращает высоту вертикальной стойки изделия.")]
    short VertStoyka_Height { get;}

    [DispId(17)]
    [Description("Возвращает высоту горизонтальной стойки изделия.")]
    double GorStoyka_Height{get;}

    [DispId(18)]
    [Description("Возвращает код замка в детали изделия по ее индексу.")]
    short Zamok(short index);

    [DispId(19)]
    [Description("Возвращает величину отступа замка от пола.")]
    short Zamok_OtPola{get;}

    [DispId(20)]
    [Description("Возвращает код ручки в изделии.")]
    short Ruchka{get;}

    [DispId(21)]
    [Description("Возвращает величину отступа ручки от пола.")]
    short Ruchka_OtPola{get; }

    [DispId(22)]
    [Description("Возвращает расстояние от пола до третьего анкера.")]
    short RastDo3Ankera{get;}

    [DispId(23)]
    [Description("Возвращает ширину наличника по его расположению.")]
    short Nalichnik(Raspolozhenie pos);

    [DispId(24)]
    [Description("Возвращает развертку наличника по его расположению.")]
    double Nalichnik_Raz(short conf);

    [DispId(25)]
    [Description("Возвращает диаметр второго анкера в стойке по ее расположению.")]
    double Anker2_Diametr(Raspolozhenie pos);

    [DispId(26)]
    [Description("Возвращает стандартный диаметр анкера.")]
    double Anker_Diametr{get;}
}

[Guid("d64a8e8e-d239-4201-9959-db789d4eb718"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
public interface IEODL
{

}

[Guid("600b2d08-c3df-4dda-8827-ac59a64177e1"), ClassInterface(ClassInterfaceType.None), ComSourceInterfaces(typeof(IEODL))]
[Description("Класс расчета однолистовых дверей.")]
public class ODL : IODL
{
    private short _Height, _Width, HLD, WlA, WLP, ListOtPola, ZPOtPola, HZP, HZPP, WZPA, HZPS, WZPP, WPP, ZamokOtPola, RuchkaOtPola, Do3Ankera;
    private double WAktiv, WPassiv, WHS, ZamokOtKraya;
    private string _Errors, _Problems;
    private readonly double[] nalichniki = new double[4];

    private readonly Constants cons = new Constants();
    private IniFile ini;
    private ODLParam param;

    public void Init(TableData tData)
    {
        Init(tData.ForODL);
    }
    public void Init(ODLParam data)
    {
        param = data;
        ini = new IniFile(cons.DIR_CONS_GLOBAL + "\\ODL.ini"); 

        _Height = param.Height;
        _Width = param.Width;
        ZamokOtPola = param.Zamok[0].OtPola == 0 ? (short)cons.RUCHKA_OT_POLA : param.Zamok[0].OtPola;
        RuchkaOtPola = param.Ruchka[0].OtPola == 0 ? (short)(cons.RUCHKA_OT_POLA + 100) : param.Ruchka[0].OtPola;

        if (param.Height % 10 != 0)
            Errors = "Высота не кратна 10! ";
        if (param.Width % 10 != 0)
            Errors = "Ширина не кратна 10! ";

        //Ширина створки
        if (param.WAktiv.Value == 0d)
        {
            WAktiv = 0;
            WPassiv = 0;
        }
        else
        {
            if (param.WAktiv.Value == 1d)
            {
                WAktiv = (_Width - short.Parse(ini.ReadKey("ODL", "ODL_K_WSTV"))) / 2;
                WPassiv = WAktiv;
            }
            else
            {
                WAktiv = param.WAktiv.Value;
                WPassiv = _Width - short.Parse(ini.ReadKey("ODL", "ODL_K_WSTV")) - WAktiv;
            }
        }

        //Высота лицевых листов
        if (param.Nalichniki[(int)Raspolozhenie.Ниж] == 0)
        {
            if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
            {
                if (param.Porog.Kod == 25)
                    HLD = (short)(_Height - short.Parse(ini.ReadKey("ODL", "ODL_K_HL_P25")));
                else if (param.Porog.Kod == 14)
                    HLD = (short)(_Height - short.Parse(ini.ReadKey("ODL", "ODL_K_HL_P14")));
                else if (param.Porog.Kod == 0)
                    HLD = (short)(_Height - short.Parse(ini.ReadKey("ODL", "ODL_K_HL_P0")));
                else
                    HLD = (short)(_Height - short.Parse(ini.ReadKey("ODL", "ODL_K_HL_P20")));
            }
            else
            {
                if (param.Porog.Kod == 25)
                    HLD = (short)(_Height - short.Parse(ini.ReadKey("ODL", "ODL_K_HL_P25_VO")));
                else if (param.Porog.Kod == 14)
                    HLD = (short)(_Height - short.Parse(ini.ReadKey("ODL", "ODL_K_HL_P14_VO")));
                else if (param.Porog.Kod == 0)
                    HLD = (short)(_Height - short.Parse(ini.ReadKey("ODL", "ODL_K_HL_P0_VO")));
                else
                    HLD = (short)(_Height - short.Parse(ini.ReadKey("ODL", "ODL_K_HL_P20_VO")));
            }
        }
        else
        {
            if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
            {
                HLD = (short)(_Height - short.Parse(ini.ReadKey("ODL", "ODL_K_HL_PR")));
            }
            else
            {
                HLD = (short)(_Height - short.Parse(ini.ReadKey("ODL", "ODL_K_HL_PR_VO")));
            }
        }
        //Ширина лицевых листов
        if (param.WAktiv.Value == 0d)
        {
            if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
            {
                WlA = (short)(_Width - short.Parse(ini.ReadKey("ODL", "ODL1_K_WL")));
            }
            else
            {
                WlA = (short)(_Width - short.Parse(ini.ReadKey("ODL", "ODL1_K_WL_VO")));
            }
        }
        else
        {
            WlA = (short)(WAktiv + short.Parse(ini.ReadKey("ODL", "ODL1_K_AS_WL")));
            WLP = (short)(WPassiv - short.Parse(ini.ReadKey("ODL", "ODL1_K_PS_WL")));
        }

        //Определение расстояния от пола до лицевого листа и замкового профиля
        if (param.Porog.Kod == 20)
        {
            ListOtPola = short.Parse(ini.ReadKey("ODL", "ODL_LL_OT_POLA_20"));
            ZPOtPola = (short)(ListOtPola + short.Parse(ini.ReadKey("Profili", "ODL_ZP_OT_LISTA_20")));
        }
        else if (param.Porog.Kod == 14)
        {
            ListOtPola = short.Parse(ini.ReadKey("ODL", "ODL_LL_OT_POLA_14"));
            ZPOtPola = (short)(ListOtPola + short.Parse(ini.ReadKey("Profili", "ODL_ZP_OT_LISTA_14")));
        }
        else if (param.Porog.Kod == 25)
        {
            ListOtPola = param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое 
                ? short.Parse(ini.ReadKey("ODL", "ODL_LL_OT_POLA_25"))
                : short.Parse(ini.ReadKey("ODL", "ODL_LL_OT_POLA_25_VO"));
            ZPOtPola = param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое 
                ? (short)(ListOtPola + short.Parse(ini.ReadKey("Profili", "ODL_ZP_OT_LISTA_25")))
                : (short)(ListOtPola + short.Parse(ini.ReadKey("Profili", "ODL_ZP_Z_PRITVOR_VO")));
        }
        else if (param.Porog.Kod == 0)
        {
            ListOtPola = short.Parse(ini.ReadKey("ODL", "ODL_LL_OT_POLA_0"));
            ZPOtPola = (short)(ListOtPola + short.Parse(ini.ReadKey("Profili", "ODL_ZP_OT_LISTA_0")));
        }
        
        //Высота замкового (петлевого) профиля
        if (param.Nalichniki[1] == 0)
        {
            if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
            {
                if (param.Porog.Kod == 0)
                    HZP = (short)(_Height - short.Parse(ini.ReadKey("Profili", "ODL_K_HVP_0")));
                else if (param.Porog.Kod == 25)
                    HZP = (short)(_Height - short.Parse(ini.ReadKey("Profili", "ODL_K_HVP_25")));
                else if (param.Porog.Kod == 14)
                    HZP = (short)(_Height - short.Parse(ini.ReadKey("Profili", "ODL_K_HVP_14")));
                else
                    HZP = (short)(_Height - short.Parse(ini.ReadKey("Profili", "ODL_K_HVP_20")));
            }
            else
            {
                if (param.Porog.Kod == 0)
                    HZP = (short)(_Height - short.Parse(ini.ReadKey("Profili", "ODL_K_HVP_0_VO")));
                else if (param.Porog.Kod == 25)
                    HZP = (short)(_Height - short.Parse(ini.ReadKey("Profili", "ODL_K_HVP_25_VO")));
                else if (param.Porog.Kod == 14)
                    HZP = (short)(_Height - short.Parse(ini.ReadKey("Profili", "ODL_K_HVP_14_VO")));
                else
                    HZP = (short)(_Height - short.Parse(ini.ReadKey("Profili", "ODL_K_HVP_20_VO")));
            }
        }
        else HZP = (short)(_Height - short.Parse(ini.ReadKey("Profili", "ODL_K_HVP_PR")));
        if (param.WAktiv.Value > 0) HZPP = (short)(HZP - 10);

        //Ширина развертки замкового профиля
        if (param.Otkrivanie.Value == Otkrivanie.ЛевоеВО | param.Otkrivanie.Value == Otkrivanie.ПравоеВО)
        {
            if(param.Ruchka[0].Kod == (int)RuchkaNames.Ручка_Потайная)
                WZPA = short.Parse(ini.ReadKey("Profili", "ODL_ZP_RAZV_RP"));
            else
                WZPA = short.Parse(ini.ReadKey("Profili", "ODL_ZP_RAZV_VO"));
            if (WPassiv > 0)
                WZPP = short.Parse(ini.ReadKey("Profili", "ODL_ZPP_RAZV_VO"));
            else
                WZPP = 0;
        }
        else
        {
            if (param.Ruchka[0].Kod == (int)RuchkaNames.Ручка_Потайная)
                WZPA = short.Parse(ini.ReadKey("Profili", "ODL_ZP_RAZV_RP"));
            else
                WZPA = short.Parse(ini.ReadKey("Profili", "ODL_ZP_RAZV"));
            if (WPassiv > 0)
                WZPP = short.Parse(ini.ReadKey("Profili", "ODL_ZPP_RAZV"));
            else
                WZPP = 0;
        }

        //Ширина развертки петлевоого профиля
        WPP = short.Parse(ini.ReadKey("Profili", "ODL_PP_RAZV"));

        //Высота стойки коробки
        HZPS = _Height;
        //Высота притолоки
        WHS = _Width - double.Parse(ini.ReadKey("Stoyki", "ODL_K_GSK"));

        //Развертка наличников
        if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
        {
            for (short i = 0; i <= 3; i++)
            {
                if (param.Nalichniki[i] == 0)
                    nalichniki[i] = short.Parse(ini.ReadKey("Stoyki", "ODL_MIN_NAL")) + double.Parse(ini.ReadKey("Stoyki", "ODL_K_NAL"));
                else if (param.Nalichniki[i] == 60)
                    nalichniki[i] = short.Parse(ini.ReadKey("Stoyki", "ODL_NAL")) + double.Parse(ini.ReadKey("Stoyki", "ODL_K_NAL"));
                else
                    nalichniki[i] = param.Nalichniki[i] + double.Parse(ini.ReadKey("Stoyki", "ODL_K_NAL"));
            }
        }
        else
        {
            for (short i = 0; i <= 3; i++)
            {
                if (param.Nalichniki[i] == 0)
                    nalichniki[i] = short.Parse(ini.ReadKey("Stoyki", "ODL_MIN_NAL_VO")) + double.Parse(ini.ReadKey("Stoyki", "ODL_K_NAL"));
                else if (param.Nalichniki[i] == 50)
                    nalichniki[i] = short.Parse(ini.ReadKey("Stoyki", "ODL_NAL_VO")) + double.Parse(ini.ReadKey("Stoyki", "ODL_K_NAL"));
                else
                    nalichniki[i] = param.Nalichniki[i] + double.Parse(ini.ReadKey("Stoyki", "ODL_K_NAL"));
            }
        }
        
        //Пробивка под анкера
        if (param.Zamok[1].Kod == 5 & param.Ruchka[1].Kod == 0)
            param.Ruchka[1].Kod = 302;
        if (_Height >= 1800)
        {
            Do3Ankera = 1650;
        }
        else if (_Height < 1800 & _Height > 1650)
        {
            Do3Ankera = 1450;
        }
        else if (_Height <= 1650)
        {
            Do3Ankera = 1250;
        }

        //Пробивка под замок
        switch (param.Zamok[0].Kod)
        {
            case (int)ODL_ZamokNames.ПП:
                ZamokOtKraya = double.Parse(ini.ReadKey("Profili", "ODL_ZAMOK_DL"));
                break;
            case (int)ODL_ZamokNames.Просам_ЗВ_8:
                ZamokOtKraya = double.Parse(ini.ReadKey("Profili", "ODL_ZAMOK_ZV_8"));
                break;
            case (int)ODL_ZamokNames.Г_12_11_ручка_фланец:
                ZamokOtKraya = double.Parse(ini.ReadKey("Profili", "ODL_ZAMOK_12_11"));
                break;
            case (int)ODL_ZamokNames.Почтовый:
                ZamokOtKraya = double.Parse(ini.ReadKey("Profili", "ODL_ZAMOK_P"));
                break;
        }
        if(param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
            ZamokOtKraya += double.Parse(ini.ReadKey("Profili", "ODL_ZP_Z_PRITVOR_NO"));
        else
            ZamokOtKraya += double.Parse(ini.ReadKey("Profili", "ODL_ZP_Z_PRITVOR_VO"));
    }

    public string Errors
    {
        get
        {
            if (param.WAktiv.Value != 0 & (param.Otkrivanie.Value == Otkrivanie.ЛевоеВО | param.Otkrivanie.Value == Otkrivanie.ПравоеВО))
            {
                _Errors += "ОДЛ-2 внутреннего открывания - такой мадели не существует. ";
            }
            return _Errors;
        }
        set => _Errors += value;
    }
    public string Problems
    {
        get { return _Problems; }
        set { _Problems += value; }
    }
    public int Row
    {
        get { return param.Row; }
    }
    public short AppRow
    {
        get { return param.AppRow; }
    }
    public string Num
    {
        get { return param.Num; }
    }
    public string Name(short index)
    {
        //Присвоение имён
        switch (index)
        {
            case 0:
                if (IsPassivka)
                    return "ODLS2_LLA_" + param.Num;
                else
                    return "ODLS1_LL__" + param.Num;
            case 1:
                return "ODLS2_LLP_" + param.Num;
            case 2:
                if (param.Otkrivanie.Value == Otkrivanie.Левое)
                {
                    if (param.Nalichniki[(int)Raspolozhenie.Прав] > 0)
                        return "C1_(50)ZS_" + param.Num;
                    else
                        return "C2_(50)ZS_" + param.Num;
                }
                else if (param.Otkrivanie.Value == Otkrivanie.Правое)
                {
                    if (param.Nalichniki[(int)Raspolozhenie.Лев] > 0)
                        return "C1_(50)ZS_" + param.Num;
                    else
                        return "C2_(50)ZS_" + param.Num;
                }
                else
                    return "C3_(50)ZS_" + param.Num;
            case 3:
                if (param.Otkrivanie.Value == Otkrivanie.Левое)
                {
                    if (param.Nalichniki[(int)Raspolozhenie.Лев] > 0)
                        return "C1_(50)PS_" + param.Num;
                    else
                        return "C2_(50)PS_" + param.Num;
                }
                else if (param.Otkrivanie.Value == Otkrivanie.Правое)
                {
                    if (param.Nalichniki[(int)Raspolozhenie.Прав] > 0)
                        return "C1_(50)PS_" + param.Num;
                    else
                        return "C2_(50)PS_" + param.Num;
                }
                else
                    return "C3_(50)PS_" + param.Num;
            case 4:
                if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
                {
                    if (param.Nalichniki[(int)Raspolozhenie.Верх] > 0)
                        return "C1_(50)UP_" + param.Num;
                    else
                        return "C2_(50)UP_" + param.Num;
                }
                else
                    return "C3_(50)UP_" + param.Num;
            case 5:
                if(IsPassivka)
                    return "ODLS2_ZPA_" + param.Num;
                else
                    return "ODLS1_ZP__" + param.Num;
            case 6:
                if (IsPassivka)
                    return "ODLS2_PP__" + param.Num;
                else
                    return "ODLS1_PP__" + param.Num;
            case 7:
                return "ODLS2_ZPP_" + param.Num;
            case 8:
                if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
                {
                    if (param.Nalichniki[(int)Raspolozhenie.Ниж] > 0)
                        return "C1_(50)DS_" + param.Num;
                    else
                        return "C2_(50)DS_" + param.Num;
                }
                else
                    return "C3_(50)DS_" + param.Num;
            case 9:
                return "(50)POR" + Porog + "_" + param.Num;
            default:
                return "";
        }
    }
    public Otkrivanie Otkrivanie
    {
        get { return param.Otkrivanie.Value; }
    }
    public bool IsPassivka
    {
        get { return WPassiv != 0; }
    }
    public double Stvorka_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return WAktiv;
        }
        else
        {
            return WPassiv;
        }
    }
    public short LicevoyList_Height
    {
        get { return HLD; }
    }
    public short LicevoyList_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return WlA;
        }
        else
        {
            return WLP;
        }
    }
    public short LicevoyList_OtPola
    {
        get { return ListOtPola; }
    }
    public short ZamkovoyProfil_OtPola
    {
        get { return ZPOtPola; }
    }
    public short ZamkovoyProfil_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
            return HZP;
        else
            return HZPP;
    }
    public short ZamkovoyProfil_Razvertka(Stvorka stvorka)
    {
        if(stvorka == Stvorka.Активная)
            return WZPA;
        else
            return WZPP;
    }
    public short PetlevoyProfil_Razvertka
    {
        get
        {
            return WPP;
        }
    }
    public short VertStoyka_Height
    {
        get { return HZPS; }
    }
    public double GorStoyka_Height
    {
        get { return WHS; }
    }
    public short Zamok(short index)
    {
        if (index == 0 | index == 2 | index == 5 | index == 7)
        {
            return param.Zamok[0].Kod;
        }
        else
        {
            return 0;
        }
    }
    public short Zamok_OtPola
    {
        get { return ZamokOtPola; }
    }
    public short Ruchka
    {
        get { return param.Ruchka[0].Kod; }
    }
    public short Ruchka_OtPola
    {
        get { return RuchkaOtPola; }
    }
    public double Zamok_OtKraya
    {
        get
        {
            return ZamokOtKraya;
        }
    }
    public short RastDo3Ankera
    {
        get { return Do3Ankera; }
    }
    public short Nalichnik(Raspolozhenie pos)
    {
        return param.Nalichniki[(short)pos];
    }
    public double Nalichnik_Raz(short conf)
    {
        switch (conf)
        {
            case 2:
                if(param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.ЛевоеВО)
                    return nalichniki[(short)Raspolozhenie.Прав];
                else
                    return nalichniki[(short)Raspolozhenie.Лев];
            case 3:
                if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.ЛевоеВО)
                    return nalichniki[(short)Raspolozhenie.Лев];
                else
                    return nalichniki[(short)Raspolozhenie.Прав];
            case 4:
                return nalichniki[(short)Raspolozhenie.Верх];

        }
        return nalichniki[(short)Raspolozhenie.Ниж];
        
    }
    public double Anker2_Diametr(Raspolozhenie pos)
    {
        if (WPassiv != 0)
        {
            return double.Parse(ini.ReadKey("Stoyki", "ODL_D_PROTIVOS"));
        }
        else
        {
            if (pos == Raspolozhenie.Лев)
            {
                if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.ЛевоеВО) return double.Parse(ini.ReadKey("Stoyki", "ODL_D_PROTIVOS"));
                else return double.Parse(ini.ReadKey("Stoyki", "ODL_D_ANKER"));
            }
            else if (pos == Raspolozhenie.Прав)
            {
                if (param.Otkrivanie.Value == Otkrivanie.Правое | param.Otkrivanie.Value == Otkrivanie.ПравоеВО) return double.Parse(ini.ReadKey("Stoyki", "ODL_D_PROTIVOS"));
                else return double.Parse(ini.ReadKey("Stoyki", "ODL_D_ANKER"));
            }
            else return 0;
        }
    }
    public double Anker_Diametr
    {
        get { return double.Parse(ini.ReadKey("Stoyki", "ODL_D_ANKER")); }
    }
    public short Porog => param.Porog.Kod;
    public double Porog_Length => _Width - 60;
}
