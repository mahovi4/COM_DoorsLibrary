internal class KalitkaDVM
{
    private readonly KalitkaParam kalitkaParam;

    private readonly short HLL, HVL, WLL, WVL, VP, GP, VPO, GPO;
    private readonly short LLotPola, VLotPola, WVirLL, HVirLL, WVirVL, HVirVL, VirLLOtPola, VirLLOtZam, VirVLOtPola, VirVLOtZam;

    public KalitkaDVM(ref DVMParam param, ref IniFile iniDVM)
    {
        kalitkaParam = param.KalitParam;

        HLL = (short)(kalitkaParam.Height + short.Parse(iniDVM.ReadKey("Kalitka", "DVM_K_HLLK")));
        WLL = (short)(kalitkaParam.Width + short.Parse(iniDVM.ReadKey("Kalitka", "DVM_K_WLLK")));
        HVL = (short)(kalitkaParam.Height + short.Parse(iniDVM.ReadKey("Kalitka", "DVM_K_HVLK")));
        WVL = (short)(kalitkaParam.Width + short.Parse(iniDVM.ReadKey("Kalitka", "DVM_K_WVLK")));
        VP = (short)(kalitkaParam.Height + short.Parse(iniDVM.ReadKey("Kalitka", "DVM_K_VPK")));
        GP = (short)(kalitkaParam.Width + short.Parse(iniDVM.ReadKey("Kalitka", "DVM_K_GPK")));
        VPO = (short)(kalitkaParam.Height + short.Parse(iniDVM.ReadKey("Kalitka", "DVM_K_VPOK")));
        GPO = (short)(kalitkaParam.Width + short.Parse(iniDVM.ReadKey("Kalitka", "DVM_K_GPOK")));
        LLotPola = (short)(kalitkaParam.OtPola - short.Parse(iniDVM.ReadKey("Kalitka", "DVM_K_LLK_OT_POLA")));
        VLotPola = (short)(kalitkaParam.OtPola + short.Parse(iniDVM.ReadKey("Kalitka", "DVM_K_VLK_OT_POLA")));
        HVirLL = (short)(kalitkaParam.Height + short.Parse(iniDVM.ReadKey("VirezKalitki", "DVM_K_HVIR_LL")));
        WVirLL = (short)(kalitkaParam.Width + short.Parse(iniDVM.ReadKey("VirezKalitki", "DVM_K_WVIR_LL")));
        HVirVL = kalitkaParam.Height;
        WVirVL = kalitkaParam.Width;
        VirLLOtPola = (short)(kalitkaParam.OtPola - short.Parse(iniDVM.ReadKey("VirezKalitki", "DVM_K_VIR_LL_OT_POLA")));
        VirLLOtZam = (short)(kalitkaParam.OtZamka + short.Parse(iniDVM.ReadKey("VirezKalitki", "DVM_K_VIR_LL_OT_ZAMKA")));
        VirVLOtPola = (short)(kalitkaParam.OtPola + short.Parse(iniDVM.ReadKey("VirezKalitki", "DVM_K_VIR_VL_OT_POLA")));
        VirVLOtZam = (short)(kalitkaParam.OtZamka + short.Parse(iniDVM.ReadKey("VirezKalitki", "DVM_K_VIR_VL_OT_ZAMKA")));
    }

    public short Height
    {
        get { return kalitkaParam.Height; }
    }
    public short Width
    {
        get { return kalitkaParam.Width; }
    }
    public short OtPola
    {
        get { return kalitkaParam.OtPola; }
    }
    public short OtZamkovogoProf
    {
        get { return kalitkaParam.OtZamka; }
    }
    public short LicList_Hight
    {
        get { return HLL; }
    }
    public short VnutList_Hight
    {
        get { return HVL; }
    }
    public short LicList_Width
    {
        get { return WLL; }
    }
    public short VnutList_Width
    {
        get { return WVL; }
    }
    public short VertProf
    {
        get { return VP; }
    }
    public short GorProf
    {
        get { return GP; }
    }
    public short VertProfObramleniya
    {
        get { return VPO; }
    }
    public short GorProfObramleniya
    {
        get { return GPO; }
    }
    public short LicListOtPola
    {
        get { return LLotPola; }
    }
    public short VnutListOtPola
    {
        get { return VLotPola; }
    }
    public short VirezLicList_Height
    {
        get { return HVirLL; }
    }
    public short VirezLicList_Width
    {
        get { return WVirLL; }
    }
    public short VirezVnutList_Height
    {
        get { return HVirVL; }
    }
    public short VirezVnutList_Width
    {
        get { return WVirVL; }
    }
    public short VIrezLicList_OtPola
    {
        get { return VirLLOtPola; }
    }
    public short VIrezLicList_OtZamkProf
    {
        get { return VirLLOtZam; }
    }
    public short VIrezVnutList_OtPola
    {
        get { return VirVLOtPola; }
    }
    public short VIrezVnutList_OtZamkProf
    {
        get { return VirVLOtZam; }
    }
}
