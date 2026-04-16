
using COM_DoorsLibrary;

internal class Okno
{
    private readonly short OHVirLL, OWVirLL, OHVirVL, OWVirVL, KoefLL, KoefVL, koef62;
    private readonly double RastOtCrayaLL, RastOtCrayaVL, RastOtPolaLL, RastOtPolaVL, koef90;
    private readonly OknoParam oknoParam;
    private readonly bool otsechkiSw;
    private readonly OtsechkaOkna[] otsechki = {null, null};
    private readonly bool[] ramki = {false, false};

    private readonly IniFile ini;

    public Okno(ref DMParam param, short num, StvorkaDM stvorka, ref Constants cons, ref IniFile iniDM)
    {
        ini = new IniFile(cons.DIR_CONS_FURNIT + "\\Okno.ini");
        koef62 = cons.ST62 & cons.CompareKod(param.Kod, "ДМ", "(62)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_62")) : (short)0;
        koef90 = cons.CompareKod(param.Kod, "ДМ", "(70)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_90")) / 2 : 0;

        oknoParam = param.Okno[num];

        //Размеры вырезов под Окно на листах полотна
        if (param.ZResh == ZashResh.решетка_на_2стороны)
        {
            KoefLL = short.Parse(ini.ReadKey("Okno", "OK_K_VIR_ZR"));
            KoefVL = short.Parse(ini.ReadKey("Okno", "OK_K_VIR_ZR"));
        }
        else
        {
            if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
            {
                KoefLL = 0;
                KoefVL = short.Parse(ini.ReadKey("Okno", "OK_K_VIR_PR"));
            }
            else
            {
                KoefLL = short.Parse(ini.ReadKey("Okno", "OK_K_VIR_PR"));
                KoefVL = 0;
            }
        }

        OHVirLL = (short)(oknoParam.Steklo.Height + KoefLL);
        OWVirLL = (short)(oknoParam.Steklo.Width + KoefLL);
        OHVirVL = (short)(oknoParam.Steklo.Height + KoefVL);
        OWVirVL = (short)(oknoParam.Steklo.Width + KoefVL);

        var koef = param.Nalichniki[(int)Raspolozhenie.Верх] != 0 ? 15 : 0;

        otsechkiSw = int.Parse(ini.ReadKey("Otsechki", "OK_Ots_Sw")) == 1;

        var key = koef62 > 0 ? "OK_Ots_W_62" : koef90 > 0 ? "OK_Ots_W_70" : "OK_Ots_W_53";
        var otsechkaTmp = double.Parse(ini.ReadKey("Otsechki", key));
        var prosechkaWidth = double.Parse(ini.ReadKey("Otsechki", "OK_Ots_Pros_W"));

        if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
        {
            otsechki[1] = new OtsechkaOkna(OWVirVL, OHVirVL, otsechkaTmp - param.Thick_VL, prosechkaWidth);

            if (int.Parse(ini.ReadKey("Ramka", "OK_Rmk_Sw")) == 1)
                ramki[1] = true;
        }
        else
        {
            otsechki[0] = new OtsechkaOkna(OWVirLL, OHVirLL, otsechkaTmp - param.Thick_LL, prosechkaWidth);

            if (int.Parse(ini.ReadKey("Ramka", "OK_Rmk_Sw")) == 1)
                ramki[0] = true;
        }

        var RastOtPola = 0.0;

        //Активная сворка
        if (stvorka.Position == Stvorka.Активная)
        {
            //Вертикальное расположение
            if (oknoParam.VertRaspol == VertRaspolozhenie.от_пола)
                RastOtPola = (short)(oknoParam.PoVertikali);
            else
                RastOtPola = param.Height - OHVirLL - oknoParam.PoVertikali - double.Parse(ini.ReadKey("Okno", "OK_K_VERT")) + koef;

            //Горизонтальное расположение на лицевом
            if (oknoParam.GorRaspol == GorRaspolozhenie.по_центру)
                RastOtCrayaLL = (stvorka.LList_Width - OWVirLL) / 2;
            else if (oknoParam.GorRaspol == GorRaspolozhenie.от_петлевого)
                RastOtCrayaLL = stvorka.LeftGib + oknoParam.PoGorizontali - (KoefLL / 2);
            else
                RastOtCrayaLL = stvorka.LList_Width - stvorka.RightGib - oknoParam.PoGorizontali - OWVirLL + (KoefLL / 2);

                //Горизонтальное расположение на внутреннем
            if (oknoParam.GorRaspol == GorRaspolozhenie.по_центру)
            {
                RastOtCrayaVL = ((stvorka.VList_Width - OWVirVL) / 2) + double.Parse(ini.ReadKey("Okno", "OK_K_GOR_VAS_C"));
                if (param.Thick_VL == 2 & param.WAktiv.Value > 0)
                    RastOtCrayaVL -= double.Parse(ini.ReadKey("Okno", "OK_K_GOR_VAS_C_T2"));
            }
            else if (oknoParam.GorRaspol == GorRaspolozhenie.от_петлевого)
                RastOtCrayaVL = oknoParam.PoGorizontali + double.Parse(ini.ReadKey("Okno", "OK_K_GOR_VAS_P")) + koef62 + koef90 - (KoefVL / 2);
            else
                RastOtCrayaVL = stvorka.VList_Width - OWVirVL - oknoParam.PoGorizontali - 
                    (param.Thick_VL.EqualsDouble(2) & param.WAktiv.Value > 0
                    ? double.Parse(ini.ReadKey("Okno", "OK_K_GOR_VAS_Z_T2")) 
                    : double.Parse(ini.ReadKey("Okno", "OK_K_GOR_VAS_Z"))) - koef62 - koef90 + (KoefVL / 2);
        }
        //Пассивная створка
        else
        {
            //Вертикальное расположение
            if (oknoParam.VertRaspol == VertRaspolozhenie.от_пола)
                RastOtPola = oknoParam.PoVertikali;
            else 
                RastOtPola = param.Height - OHVirLL - oknoParam.PoVertikali - double.Parse(ini.ReadKey("Okno", "OK_K_VERT")) + koef;

            //Горизонтальное расположение на лицевом
            if (oknoParam.GorRaspol == GorRaspolozhenie.по_центру)
            {
                RastOtCrayaLL = (stvorka.LList_Width - OWVirLL - stvorka.RightGib + stvorka.LeftGib) / 2;
                if (param.Thick_LL == 2)
                    RastOtCrayaLL += double.Parse(ini.ReadKey("Okno", "OK_K_GOR_LPS_C_T2"));
            }
            else if (oknoParam.GorRaspol == GorRaspolozhenie.от_петлевого)
                RastOtCrayaLL = stvorka.LList_Width - stvorka.RightGib - OWVirLL - oknoParam.PoGorizontali + KoefLL / 2;
            else
                RastOtCrayaLL = stvorka.LeftGib + oknoParam.PoGorizontali - (KoefLL / 2);

            //Горизонтальное расположение на внутреннем
            if (oknoParam.GorRaspol == GorRaspolozhenie.по_центру)
            {
                RastOtCrayaVL = (stvorka.VList_Width - double.Parse(ini.ReadKey("Okno", "OK_K_GOR_VPS_P")) - koef62 - koef90 - OWVirVL + 
                                double.Parse(ini.ReadKey("Okno", "OK_K_GOR_VPS_Z"))) / 2;
                if (param.Thick_VL == 2)
                    RastOtCrayaVL -= double.Parse(ini.ReadKey("Okno", "OK_K_GOR_VPS_C_T2"));
            }
            else if (oknoParam.GorRaspol == GorRaspolozhenie.от_петлевого)
                RastOtCrayaVL = stvorka.VList_Width - OWVirVL - oknoParam.PoGorizontali - 
                                double.Parse(ini.ReadKey("Okno", "OK_K_GOR_VPS_P")) - koef62 - koef90 + KoefVL / 2;
            else
                RastOtCrayaVL = oknoParam.PoGorizontali + double.Parse(ini.ReadKey("Okno", "OK_K_GOR_VPS_Z")) - (KoefVL / 2);
        }
        
        RastOtPolaLL = RastOtPola - KoefLL/2;
        RastOtPolaVL = RastOtPola - KoefVL/2;
    }
    public short HVirLL
    {
        get { return OHVirLL; }
    }
    public short WVirLL
    {
        get { return OWVirLL; }
    }
    public short HVirVL
    {
        get { return OHVirVL; }
    }
    public short WVirVL
    {
        get { return OWVirVL; }
    }
    public double OtPola(int pos) => 
        pos==1 ? RastOtPolaVL : RastOtPolaLL;

    public double OtCraya(int pos) => 
        pos == 1 ? RastOtCrayaVL : RastOtCrayaLL;

    public bool IsOtsechka(int pos) => 
        otsechkiSw && otsechki[pos] != null && otsechki[pos].IsValid;

    public OtsechkaOkna Otsechka =>
        otsechki[0] == null ? otsechki[1] : otsechki[0];

    public bool IsRamka(int pos) => ramki[pos];
}
