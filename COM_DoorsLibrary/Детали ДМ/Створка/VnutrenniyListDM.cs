using static DM;

internal class VnutrenniyListDM
{
    private readonly double _height, _width;
    private readonly bool sekPl, kabelKanal;
    private readonly short vstavka, sPor, koef90, koef62;

    public VnutrenniyListDM(ref DMParam param, double hStv, double wStv, Stvorka pos, ref Constants cons, ref IniFile iniDM)
    {
        koef90 = cons.CompareKod(param.Kod, "ДМ", "(70)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_90")) : (short)0;
        koef62 = cons.ST62 & cons.CompareKod(param.Kod, "ДМ", "(62)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_62")) : (short)0;

        _width = pos == Stvorka.Активная ? wStv + double.Parse(iniDM.ReadKey("List", "DM_K_WVL_AS")) + koef90 + (koef62 * 2) :
                                           wStv + double.Parse(iniDM.ReadKey("List", "DM_K_WVL_PS")) + (koef90 / 2) + koef62;
        _height = hStv;

        if (param.Thick_VL == 2){
            if (pos == Stvorka.Активная){
                if (param.WAktiv.Value == 0d)
                    _width += double.Parse(iniDM.ReadKey("Koef", "DM1_K_WVL_T2"));
                else
                {
                    if (koef90 == 0)
                        _width += double.Parse(iniDM.ReadKey("Koef", "DM2_K_WVA_T2"));
                    else
                        _width += double.Parse(iniDM.ReadKey("Koef", "DM2_K_WVA_T2_90"));
                }
                                                            
            } else {
                _width -= double.Parse(iniDM.ReadKey("Koef", "K_WVP_T2"));
            }
        }
        sekPl = pos == Stvorka.Активная && param.Thick_VL == 2 & param.WAktiv.Value != 0d;
        if (sekPl)
            vstavka = (short)(short.Parse(iniDM.ReadKey("List", "DM_VSTAVKA_AS")) + (koef62 > 0 ? koef62+1 : 0));
        else
            vstavka = 0;
        kabelKanal = pos == Stvorka.Активная ? param.Kabel == KabelRaspolozhenie.в_активке :
                                               param.Kabel == KabelRaspolozhenie.в_пассивке;
        sPor = (short)(short.Parse(iniDM.ReadKey("Porog", "DM_POR_VIPAD")) + koef62/2);
    }

    public double Height
    {
        get { return _height; }
    }
    public double Width
    {
        get { return _width; }
    }
    public bool IsSekPloskost
    {
        get { return sekPl; }
    }
    public bool IsKabelKanal
    {
        get { return kabelKanal; }
    }
    public short SPorog_OtKraya
    {
        get => sPor;
    }
    public short Vstavka_Width
    {
        get => vstavka;
    }
}
