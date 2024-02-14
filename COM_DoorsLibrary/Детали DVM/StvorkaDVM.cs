using System;

internal class StvorkaDVM
{
    private readonly short _height, _width, lListOtPola, vListOtPola, KLL, KVL;
    private readonly short _vertProf, _vertProfDobor, _gorProf, _gorProfDobor;

    private readonly ListPolotnaDVM LList;
    private readonly ListPolotnaDVM VList;

    public StvorkaDVM(ref DVMParam param, Stvorka type, ref Constants cons, ref IniFile iniDVM)
    {
        if (param.WAktiv.Value == 1d)
        {
            _width = (short)((param.Width - short.Parse(iniDVM.ReadKey("Stvorka", "DVM2_K_WSTV"))) / 2);
        }
        else if (param.WAktiv.Value > 1d)
        {
            if (type == Stvorka.Активная)
            {
                _width = (short)param.WAktiv.Value;
            }
            else
            {
                _width = (short)((param.Width - short.Parse(iniDVM.ReadKey("Stvorka", "DVM2_K_WSTV"))) - param.WAktiv.Value);
            }
        }
        else
        {
            if (type == Stvorka.Активная)
            {
                _width = (short)(param.Width - short.Parse(iniDVM.ReadKey("Stvorka", "DVM1_K_WSTV")));
            }
            else
            {
                _width = 0;
            }
        }
        switch (param.Porog.Kod)
        {
            case 0:
                lListOtPola = short.Parse(iniDVM.ReadKey("DVM", "LL_OT_POLA_0"));
                vListOtPola = short.Parse(iniDVM.ReadKey("DVM", "VL_OT_POLA_0"));
                break;
            case 14:
                lListOtPola = short.Parse(iniDVM.ReadKey("DVM", "LL_OT_POLA_14"));
                vListOtPola = short.Parse(iniDVM.ReadKey("DVM", "VL_OT_POLA_14"));
                break;
            case 25:
                lListOtPola = short.Parse(iniDVM.ReadKey("DVM", "LL_OT_POLA_25"));
                vListOtPola = short.Parse(iniDVM.ReadKey("DVM", "VL_OT_POLA_25"));
                break;
            case 40:
                lListOtPola = short.Parse(iniDVM.ReadKey("DVM", "LL_OT_POLA_40"));
                vListOtPola = short.Parse(iniDVM.ReadKey("DVM", "VL_OT_POLA_40"));
                break;
        }
        KLL = (short)(lListOtPola + short.Parse(iniDVM.ReadKey("DVM", "DVM_KML")));
        KVL = (short)(vListOtPola + short.Parse(iniDVM.ReadKey("DVM", "DVM_KMV")));
        _height = (short)(param.Height - KVL);
        short fullWLL, fullWVL;
        if (type == Stvorka.Активная)
        {
            fullWLL = (short)(_width + short.Parse(iniDVM.ReadKey("Stvorka", "DVM_AS_K_WLL")));
            if (param.WAktiv.Value == 0d)
            {
                fullWVL = _width;
            }
            else
            {
                fullWVL = (short)(_width - short.Parse(iniDVM.ReadKey("Stvorka", "DVM_AS_K_WVL")));
            }
        }
        else
        {
            if (param.WAktiv.Value == 0d)
            {
                fullWLL = 0;
                fullWVL = 0;
            }
            else
            {
                fullWLL = (short)(_width + short.Parse(iniDVM.ReadKey("Stvorka", "DVM_PS_K_WLL")));
                fullWVL = (short)(_width + short.Parse(iniDVM.ReadKey("Stvorka", "DVM_AS_K_WVL")));
            }
        }
        LList = new ListPolotnaDVM((short)(param.Height - KLL), fullWLL, ref cons);
        VList = new ListPolotnaDVM((short)(param.Height - KVL), fullWVL, ref cons);
        short k = short.Parse(iniDVM.ReadKey("Stvorka", "DVM_K_VP"));
        if ((param.Height - KVL - k) > cons.LIST_HIGHT)
        {
            _vertProf = (short)(Math.Round((double)((param.Height - KVL - k) / 2)));
            _vertProfDobor = (short)((param.Height - KVL - k) - _vertProf);
        }
        else
        {
            _vertProf = (short)(param.Height - KVL - k);
            _vertProfDobor = 0;
        }
        if (_width > cons.LIST_HIGHT)
        {
            _gorProf = (short)Math.Round((double)(_width / 2));
            _gorProfDobor = (short)(_width - _gorProf);
        }
        else
        {
            _gorProf = _width;
            _gorProfDobor = 0;
        }
    }

    public void AddVertDoborLicLista(int width)
    {
        LList.AddVertDobor(width);
    }
    public void AddVertDoborVnutLista(int width)
    {
        VList.AddVertDobor(width);
    }
    public short Height
    {
        get { return _height; }
    }
    public short Width
    {
        get { return _width; }
    }
    public short LicList_Height
    {
        get { return LList.Height; }
    }
    public short LicList_Width
    {
        get { return LList.Width; }
    }
    public short VnutList_Height
    {
        get { return VList.Height; }
    }
    public short VnutList_Width
    {
        get { return VList.Width; }
    }
    public short LicListOtPola
    {
        get { return lListOtPola; }
    }
    public short VnutListOtPola
    {
        get { return vListOtPola; }
    }
    public bool IsVertDoborLicLista
    {
        get { return LList.IsVertDobor; }
    }
    public short VertDoborLicLista_Height
    {
        get { return LList.VertDobor_Height; }
    }
    public short VertDoborLicLista_Width
    {
        get { return LList.VertDobor_Width; }
    }
    public bool IsGorDoborLicLista
    {
        get { return LList.IsGorDobor; }
    }
    public short GorDoborLicLista_Height
    {
        get { return LList.GorDobor_Height; }
    }
    public short GorDoborLicLista_Width
    {
        get { return LList.GorDobor_Width; }
    }
    public bool IsDopDoborLicLista
    {
        get { return LList.IsDopDobor; }
    }
    public short DopDoborLicLista_Height
    {
        get { return LList.DopDobor_Height; }
    }
    public short DopDoborLicLista_Width
    {
        get { return LList.DopDobor_Width; }
    }
    public bool IsVertDoborVnutLista
    {
        get { return VList.IsVertDobor; }
    }
    public short VertDoborVnutLista_Height
    {
        get { return VList.VertDobor_Height; }
    }
    public short VertDoborVnutLista_Width
    {
        get { return VList.VertDobor_Width; }
    }
    public bool IsGorDoborVnutLista
    {
        get { return VList.IsGorDobor; }
    }
    public short GorDoborVnutLista_Height
    {
        get { return VList.GorDobor_Height; }
    }
    public short GorDoborVnutLista_Width
    {
        get { return VList.GorDobor_Width; }
    }
    public bool IsDopDoborVnutLista
    {
        get { return VList.IsDopDobor; }
    }
    public short DopDoborVnutLista_Height
    {
        get { return VList.DopDobor_Height; }
    }
    public short DopDoborVnutLista_Width
    {
        get { return VList.DopDobor_Width; }
    }
    public short VertProf
    {
        get { return _vertProf; }
    }
    public short VertProfDobor
    {
        get { return _vertProfDobor; }
    }
    public short GorProf
    {
        get { return _gorProf; }
    }
    public short GorProfDobor
    {
        get { return _gorProfDobor; }
    }
}
