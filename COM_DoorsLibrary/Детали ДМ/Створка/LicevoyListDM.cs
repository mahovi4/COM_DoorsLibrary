using static DM;

internal class LicevoyListDM
{
    private readonly double _height, _width, virezPritvorHeight, virezPritvorWidth, TSotKraya;
    private readonly short vstavka, _rightGib, _leftGib, _upGib, kompVir, koef90, koef62;
    private readonly bool downGib, UpTShpin, DownTShpin, SekPl, GND;
    
public LicevoyListDM(ref DMParam param, double hStv, double wStv, Stvorka pos, ref Constants cons, ref IniFile iniDM)
    {
        koef90 = cons.CompareKod(param.Kod, "ДМ", "(70)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_90")) : (short)0;
        koef62 = cons.ST62 & cons.CompareKod(param.Kod, "ДМ", "(62)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_62")) : (short)0;

        _width = pos == Stvorka.Активная ? !(param.WAktiv.Value == 0d) ? wStv + double.Parse(iniDM.ReadKey("List", "DM2_K_WLL_AS")) :
                                                                  wStv + double.Parse(iniDM.ReadKey("List", "DM1_K_WLL")) : 
                                           wStv + double.Parse(iniDM.ReadKey("List", "DM2_K_WLL_PS")) + (koef90 / 2) + koef62;
        switch (param.Porog.Kod) {
            case 40:
            case 41:
            case 1:
                _height = hStv + double.Parse(iniDM.ReadKey("List", "DM_K_HLL_40"));
                break;
            case 0:
            case 2:
                _height = param.Nalichniki[1] == 0 ? hStv + double.Parse(iniDM.ReadKey("List", "DM_K_HLL_0")) : 
                                                       hStv + double.Parse(iniDM.ReadKey("List", "DM_K_HLL_PR"));
                break;
            case 14:
            case 15:
                _height = hStv + double.Parse(iniDM.ReadKey("List", "DM_K_HLL_14"));
                break;
            case 25:
            case 26:
                _height = hStv + double.Parse(iniDM.ReadKey("List", "DM_K_HLL_25"));
                break;
            case 100:
                _height = hStv + double.Parse(iniDM.ReadKey("List", "DM_K_HLL_100"));
                break;
            case 30:
                _height = hStv + double.Parse(iniDM.ReadKey("List", "DM_K_HLL_30"));
                break;
        }
        _height += param.Thick_LL == 2 ? double.Parse(iniDM.ReadKey("Koef", "K_HLL_T2")) : 0;
        _width += param.Thick_LL == 2 ? pos == Stvorka.Активная ? param.WAktiv.Value == 0d ? double.Parse(iniDM.ReadKey("Koef", "DM1_K_WLL_T2")) :
                                                                                      double.Parse(iniDM.ReadKey("Koef", "DM2_K_WLA_T2")) :
                                                                  koef90 == 0 ? double.Parse(iniDM.ReadKey("Koef", "DM2_K_WLP_T2")) :
                                                                                double.Parse(iniDM.ReadKey("Koef", "DM2_K_WLP_T2_90")) : 0;
        kompVir = short.Parse(iniDM.ReadKey("Virez", "DM_KOMPENS_VIREZ"));
        _leftGib = param.Thick_LL == 2 ? pos == Stvorka.Активная ? short.Parse(iniDM.ReadKey("Gib", "DM_BOK_GIB_LA_T2")) :
                                                                  (short)(double.Parse(iniDM.ReadKey("Gib", "DM_BOK_GIB_LP_T2")) + koef62 + (koef90 / 2)) : 
                                         pos == Stvorka.Активная ? short.Parse(iniDM.ReadKey("Gib", "DM_BOK_GIB_LA")) :
                                                                  (short)(short.Parse(iniDM.ReadKey("Gib", "DM_BOK_GIB_LP")) + koef62 + (koef90 / 2));

        _rightGib = pos == Stvorka.Активная ? _leftGib :
                                              param.Thick_LL == 2 ? short.Parse(iniDM.ReadKey("Gib", "DM_BOK_GIB_LA_T2")) :
                                                                    short.Parse(iniDM.ReadKey("Gib", "DM_BOK_GIB_LA"));
        _upGib = param.Thick_LL == 2 ? short.Parse(iniDM.ReadKey("Gib", "DM_UP_GIB_LA_T2")) : 
                                       short.Parse(iniDM.ReadKey("Gib", "DM_UP_GIB_LA"));
        downGib = param.Porog.Kod != 0 && param.Porog.Kod != 2 || param.Nalichniki[1] > 0;
        SekPl = pos != Stvorka.Активная && param.Thick_LL == 2;
        if (SekPl)
            vstavka = (short)(short.Parse(iniDM.ReadKey("List", "DM_VSTAVKA_PS")) + (koef62 > 0 ? koef62 + 1 : 0));
        else
            vstavka = 0;
        if (param.Porog.Kod == 0 | param.Porog.Kod == 2)
        {
            virezPritvorHeight = 0.001;
        }
        else if (param.Porog.Kod == 14 | param.Porog.Kod == 15)
        {
            if (cons.CompareKod(param.Kod, "ДМ", "(70)"))
            {
                virezPritvorHeight = double.Parse(iniDM.ReadKey("Virez", "DM_PRITVOR_POROG_14_90"));
            }
            else
            {
                virezPritvorHeight = double.Parse(iniDM.ReadKey("Virez", "DM_PRITVOR_POROG_14"));
            }
        }
        else if(param.Porog.Kod == 30)
            virezPritvorHeight = double.Parse(iniDM.ReadKey("Virez", "DM_PRITVOR_POROG_30"));
        else
        {
            if (cons.CompareKod(param.Kod, "ДМ", "(70)"))
            {
                virezPritvorHeight = double.Parse(iniDM.ReadKey("Virez", "DM_PRITVOR_POROG_90"));
            }
            else
            {
                virezPritvorHeight = double.Parse(iniDM.ReadKey("Virez", "DM_PRITVOR_POROG"));
            }
        }
        virezPritvorWidth = double.Parse(iniDM.ReadKey("Virez", "DM_VIREZ_PRITVOR")) + koef62 + (koef90 / 2);
        GND = param.GND == GNDRaspolozhenie.стойка_и_полотно;
    }

    public double Height
    {
        get { return _height; }
    }
    public double Width
    {
        get { return _width; }
    }
    public short RightGib
    {
        get { return _rightGib; }
    }
    public short LeftGib
    {
        get { return _leftGib; }
    }
    public short UpGib
    {
        get { return _upGib; }
    }
    public double VirezPoPorogu_Height
    {
        get { return virezPritvorHeight; }
    }
    public double VirezPoPorogu_Width
    {
        get { return virezPritvorWidth; }
    }
    public double TShpingaletOtKraya
    {
        get { return TSotKraya; }
    }
    public short KompensVirez
    {
        get { return kompVir; }
    }
    public bool IsDownGib
    {
        get { return downGib; }
    }
    public bool IsUpTShpingalet
    {
        get { return UpTShpin; }
    }
    public bool IsDownTShpingalet
    {
        get { return DownTShpin; }
    }
    public bool IsSekPloskost
    {
        get { return SekPl; }
    }
    public bool IsGND
    {
        get { return GND; }
    }
    public short Vstavka_Width
    {
        get => vstavka;
    }
}
