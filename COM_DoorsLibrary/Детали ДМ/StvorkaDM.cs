using static DM;

class StvorkaDM
{
    //private readonly string _name;
    private readonly double _width, _height;
    private readonly short LLOtPola, VLOtPola, kPas2mm;

    private readonly LicevoyListDM LicevoyList;
    private readonly VnutrenniyListDM VnutrenniyList;
    internal Stvorka Position { get; private set; }

    public StvorkaDM(ref DMParam param, Stvorka pos, ref Constants cons, ref IniFile iniDM, ref KorobkaDM Korobka)
    {
        Position = pos;
        if (pos == Stvorka.Пассивная & param.Thick_LL == 2 & param.Thick_VL == 2) {
            kPas2mm = short.Parse(iniDM.ReadKey("Koef", "K_PAS_T2"));
        } else {
            kPas2mm = 0;
        }

        //-------------------------------------------------------------------------------------------
        //====================================|РАСЧЕТ ПОЛОТЕН|=======================================
        //-------------------------------------------------------------------------------------------
        //Расчет ширины створки
        if (param.WAktiv.Value == 1)              //равнополая
        {
            if ((Korobka.TypeStoyki(Raspolozhenie.Прав) == 2 | Korobka.TypeStoyki(Raspolozhenie.Прав) == 3) & 
                (Korobka.TypeStoyki(Raspolozhenie.Лев) == 2 | Korobka.TypeStoyki(Raspolozhenie.Лев) == 3))          //K2(K3) + K2(K3)
            {
                _width = (param.Width - short.Parse(iniDM.ReadKey("Stvorki", "DM2_K_WSTV")) - 
                                        short.Parse(iniDM.ReadKey("Korobka", "DM_K_K2")) * 2) / 2 - kPas2mm;
            }
            else if (Korobka.TypeStoyki(Raspolozhenie.Прав) == 1 & Korobka.TypeStoyki(Raspolozhenie.Лев) == 1)      //K1 + K1
            {
                _width = (param.Width - short.Parse(iniDM.ReadKey("Stvorki", "DM2_K_WSTV"))) / 2 - kPas2mm;
            }
            else                                                                                                   //K1 + K2 (K2 + K1)
            {
                _width = (param.Width - short.Parse(iniDM.ReadKey("Stvorki", "DM2_K_WSTV")) - 
                                        short.Parse(iniDM.ReadKey("Korobka", "DM_K_K2"))) / 2 - kPas2mm;
            }
        }
        else if (param.WAktiv.Value > 1)    //неравнополая
        {
            if (pos == Stvorka.Активная)    //активка
            {
                _width = param.WAktiv.Value;
            }
            else                            //пассивка
            {
                if ((Korobka.TypeStoyki(Raspolozhenie.Прав) == 2 | Korobka.TypeStoyki(Raspolozhenie.Прав) == 3) & 
                    (Korobka.TypeStoyki(Raspolozhenie.Лев) == 2 | Korobka.TypeStoyki(Raspolozhenie.Лев) == 3))          //K2 + K2
                {
                    _width = param.Width - param.WAktiv.Value - short.Parse(iniDM.ReadKey("Stvorki", "DM2_K_WSTV")) - 
                                                         (short.Parse(iniDM.ReadKey("Korobka", "DM_K_K2")) * 2) - kPas2mm;
                }
                else if (Korobka.TypeStoyki(Raspolozhenie.Прав) == 1 & Korobka.TypeStoyki(Raspolozhenie.Лев) == 1)      //K1 + K1
                {
                    _width = param.Width - param.WAktiv.Value - short.Parse(iniDM.ReadKey("Stvorki", "DM2_K_WSTV")) - kPas2mm;
                }
                else                                                                                                    //K1 + K2
                {
                    _width = param.Width - param.WAktiv.Value - short.Parse(iniDM.ReadKey("Stvorki", "DM2_K_WSTV")) - 
                                                          short.Parse(iniDM.ReadKey("Korobka", "DM_K_K2")) - kPas2mm;
                }
            }
        }
        else                                //одностворчатая
        {
            if ((Korobka.TypeStoyki(Raspolozhenie.Прав) == 2 | Korobka.TypeStoyki(Raspolozhenie.Прав) == 3) & 
                (Korobka.TypeStoyki(Raspolozhenie.Лев) == 2 | Korobka.TypeStoyki(Raspolozhenie.Лев) == 3))              //K2 + K2
            {
                _width = param.Width - short.Parse(iniDM.ReadKey("Stvorki", "DM1_K_WSTV")) - 
                                      (short.Parse(iniDM.ReadKey("Korobka", "DM_K_K2")) * 2);
            }
            else if (Korobka.TypeStoyki(Raspolozhenie.Прав) == 1 & Korobka.TypeStoyki(Raspolozhenie.Лев) == 1)          //K1 + K1
            {
                _width = param.Width - short.Parse(iniDM.ReadKey("Stvorki", "DM1_K_WSTV"));
            }
            else                                                                                                        //K1 + K2
            {
                _width = param.Width - short.Parse(iniDM.ReadKey("Stvorki", "DM1_K_WSTV")) - 
                                       short.Parse(iniDM.ReadKey("Korobka", "DM_K_K2"));
            }
        }
        if (pos == Stvorka.Активная & param.WAktiv.Value == 1)
        {
            param.WAktiv.Value = _width;
        }

        //Расчет высоты створки
        short kPor = 0, kK2 = 0;
        switch (param.Porog.Kod)
        {
            case 40:
            case 41:
                kPor = short.Parse(iniDM.ReadKey("Stvorki", "DM_K_HSTV_40"));
                break;
            case 0:
            case 2:
                kPor = short.Parse(iniDM.ReadKey("Stvorki", "DM_K_HSTV_0"));
                break;
            case 1:
                kPor = short.Parse(iniDM.ReadKey("Stvorki", "DM_K_HSTV_PR"));
                break;
            case 14:
            case 15:
                kPor = short.Parse(iniDM.ReadKey("Stvorki", "DM_K_HSTV_14"));
                break;
            case 25:
            case 26:
                kPor = short.Parse(iniDM.ReadKey("Stvorki", "DM_K_HSTV_25"));
                break;
            case 100:
                kPor = short.Parse(iniDM.ReadKey("Stvorki", "DM_K_HSTV_100"));
                break;
            case 30:
                kPor = short.Parse(iniDM.ReadKey("Stvorki", "DM_K_HSTV_30"));
                break;
        }
        if (Korobka.TypeStoyki(0) == 2 | Korobka.TypeStoyki(0) == 3 | Korobka.TypeStoyki(0) == 4)   //макушка К2, K3 или Интек
        {
            kK2 = short.Parse(iniDM.ReadKey("Korobka", "DM_K_K2"));
        }
        _height = param.Height - kPor - kK2;

        //Лист от пола
        if (param.Nalichniki[1] == 0)
        {
            switch (param.Porog.Kod)
            {
                case 0:
                case 2:
                    LLOtPola = short.Parse(iniDM.ReadKey("DM", "LL_OT_POLA_0"));
                    VLOtPola = short.Parse(iniDM.ReadKey("DM", "VL_OT_POLA_0"));
                    break;
                case 40:
                case 41:
                    LLOtPola = short.Parse(iniDM.ReadKey("DM", "LL_OT_POLA_40"));
                    VLOtPola = short.Parse(iniDM.ReadKey("DM", "VL_OT_POLA_40"));
                    break;
                case 25:
                case 26:
                    LLOtPola = short.Parse(iniDM.ReadKey("DM", "LL_OT_POLA_25"));
                    VLOtPola = short.Parse(iniDM.ReadKey("DM", "VL_OT_POLA_25"));
                    break;
                case 14:
                case 15:
                    LLOtPola = short.Parse(iniDM.ReadKey("DM", "LL_OT_POLA_14"));
                    VLOtPola = short.Parse(iniDM.ReadKey("DM", "VL_OT_POLA_14"));
                    break;
                case 100:
                    LLOtPola = short.Parse(iniDM.ReadKey("DM", "LL_OT_POLA_100"));
                    VLOtPola = short.Parse(iniDM.ReadKey("DM", "VL_OT_POLA_100"));
                    break;
                case 30:
                    LLOtPola = (short)(short.Parse(iniDM.ReadKey("DM", "LL_OT_POLA_30")) + 6);
                    VLOtPola = short.Parse(iniDM.ReadKey("DM", "VL_OT_POLA_30"));
                    break;
            }
        }
        else
        {
            LLOtPola = short.Parse(iniDM.ReadKey("DM", "LL_OT_POLA_PR"));
            VLOtPola = short.Parse(iniDM.ReadKey("DM", "VL_OT_POLA_PR"));
        }
        LicevoyList = new LicevoyListDM(ref param, _height, _width, pos, ref cons, ref iniDM);
        VnutrenniyList = new VnutrenniyListDM(ref param, _height, _width, pos, ref cons, ref iniDM);
    }

    //public string Name
    //{
    //    get { return _name; }
    //}
    public double Width
    {
        get { return _width; }
    }
    public double Hight
    {
        get { return _height; }
    }
    public double LList_Hight
    {
        get { return LicevoyList.Height; }
    }
    public double VList_Hight
    {
        get { return VnutrenniyList.Height; }
    }
    public double LList_Width
    {
        get { return LicevoyList.Width; }
    }
    public double VList_Width
    {
        get { return VnutrenniyList.Width; }
    }
    public short LListOtPola
    {
        get { return LLOtPola; }
    }
    public short VListOtPola
    {
        get { return VLOtPola; }
    }
    public double VirezPoPorogu_Height
    {
        get { return LicevoyList.VirezPoPorogu_Height; }
    }
    public double VirezPoPorogu_Width
    {
        get { return LicevoyList.VirezPoPorogu_Width; }
    }
    public short LeftGib
    {
        get { return LicevoyList.LeftGib; }
    }
    public short RightGib
    {
        get { return LicevoyList.RightGib; }
    }
    public short UpGib
    {
        get { return LicevoyList.UpGib; }
    }
    public short KompensVirez
    {
        get { return LicevoyList.KompensVirez; }
    }
    public bool IsDownGib
    {
        get { return LicevoyList.IsDownGib; }
    }
    public bool IsUpTShpingalet
    {
        get { return LicevoyList.IsUpTShpingalet; }
    }
    public bool IsDownTShpingalet
    {
        get { return LicevoyList.IsDownTShpingalet; }
    }
    public bool IsSekPl
    {
        get
        {
            if (Position == Stvorka.Активная)
            {
                return VnutrenniyList.IsSekPloskost;
            }
            else
            {
                return LicevoyList.IsSekPloskost;
            }
        }
    }
    public bool IsGND
    {
        get { return LicevoyList.IsGND; }
    }
    public bool IsKabelKanal
    {
        get { return VnutrenniyList.IsKabelKanal; }
    }
    public short SPorog_OtKraya
    {
        get => VnutrenniyList.SPorog_OtKraya;
    }
    public short Vstavka_Width
    {
        get
        {
            if (Position == Stvorka.Активная)
                return VnutrenniyList.Vstavka_Width;
            else
                return LicevoyList.Vstavka_Width;
        }
    }
}
