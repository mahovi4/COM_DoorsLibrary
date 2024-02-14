using static DM;

internal class Ruchka
{
    private readonly short koef90, koef62;
    private readonly RuchkaParam ruchkaParam;
    private readonly DMParam dataDM;
    private readonly Stvorka stvorka;

    private readonly IniFile ini;

    public Ruchka(short stv, short num, short k62, short k90, ref DMParam param, ref Constants cons)
    {
        dataDM = param;
        stvorka = (Stvorka)stv;
        ini = new IniFile(cons.DIR_CONS_FURNIT + "\\Ruchki.ini");

        koef90 = k90;
        koef62 = k62;

        ruchkaParam = stvorka == (short)Stvorka.Активная 
            ? dataDM.RuchkaAS[num] 
            : dataDM.RuchkaPS[num];

        if(ruchkaParam.Kod == (short)RuchkaNames.Ручка_скоба)
        {
            if(ruchkaParam.Mezhosevoe == 0)
                ruchkaParam.Mezhosevoe = 300;
            if (ruchkaParam.OtPola == 0)
            {
                if (ruchkaParam.Mezhosevoe <= 400)
                    ruchkaParam.OtPola = 1100;
                else
                    ruchkaParam.OtPola = (short)(1100 - ruchkaParam.Mezhosevoe / 2);
            }
        }
        else if(ruchkaParam.OtPola == 0) 
            ruchkaParam.OtPola = (short)cons.RUCHKA_OT_POLA;
    }

    public double OtKraya(short pos)
    {
        if (pos == 0)
        {
            if(dataDM.Thick_LL == 2)
                return double.Parse(ini.ReadKey(ruchkaParam.Kod.ToString(), "OT_KRAYA_LA"));
            else
                return double.Parse(ini.ReadKey(ruchkaParam.Kod.ToString(), "OT_KRAYA_LA_T2"));
        }
        else if(pos == 1)
        {
            if(dataDM.Thick_VL == 2)
            {
                if (dataDM.WAktiv.Value > 0)
                    return double.Parse(ini.ReadKey(ruchkaParam.Kod.ToString(), "DM2_OT_KRAYA_VA_T2")) + (koef90 / 2) + koef62;
                else
                    return double.Parse(ini.ReadKey(ruchkaParam.Kod.ToString(), "DM1_OT_KRAYA_VA_T2")) + (koef90 / 2) + koef62;
            }
            else
                return double.Parse(ini.ReadKey(ruchkaParam.Kod.ToString(), "OT_KRAYA_VA")) + (koef90 / 2) + koef62;
        }
        else
        {
            if (ruchkaParam.Kod > 10)
                return double.Parse(ini.ReadKey(ruchkaParam.Kod.ToString(), "OT_P_KRAYA_VP")) + koef62 + koef90 / 2;
            else return 0;
        }
    }
    public double OtLeftKraya(short pos)
    {
        if (ruchkaParam.Kod > 10)
        {
            if (pos == 0)
                return double.Parse(ini.ReadKey(ruchkaParam.Kod.ToString(), "OT_L_KRAYA_VA")) + (koef90 / 2) + koef62;
            else
            {
                int k = dataDM.Thick_VL == 2 ? 1 : 0;
                return double.Parse(ini.ReadKey(ruchkaParam.Kod.ToString(), "OT_L_KRAYA_VP")) + k;
            }
        }
        else return 0;
    }
    public short OtPola
    {
        get { return ruchkaParam.OtPola; }
    }
    public short Mezhosevoe
    {
        get { return ruchkaParam.Mezhosevoe; }
    }
    public short Kod
    {
        get { return ruchkaParam.Kod; }
    }
    public string VirezName
    {
        get
        {
            if (stvorka == Stvorka.Активная)
                return ini.ReadKey(ruchkaParam.Kod.ToString(), "NAME_VIREZ");
            else
                return ini.ReadKey(ruchkaParam.Kod.ToString(), "NAME_VIREZ_PS");
        }
    }
    public string SketchName
    {
        get
        {
            if(stvorka == Stvorka.Активная)
                return ini.ReadKey(ruchkaParam.Kod.ToString(), "NAME_SKETCH");
            else
                return ini.ReadKey(ruchkaParam.Kod.ToString(), "NAME_SKETCH_PS");
        }
    }
    public float OtNiza
    {
        get
        {
            if (ruchkaParam.Kod == (int)RuchkaNames.PB_1700C)
            {
                if (dataDM.Porog.Kod == (short)PorogNames.Порог_14)
                    return float.Parse(ini.ReadKey(ruchkaParam.Kod.ToString(), "OT_NIZA_P14"));
                else if(dataDM.Porog.Kod == (short)PorogNames.Выподающий || dataDM.Porog.Kod == (short)PorogNames.Нет)
                    return float.Parse(ini.ReadKey(ruchkaParam.Kod.ToString(), "OT_NIZA_P0"));
                else
                    return float.Parse(ini.ReadKey(ruchkaParam.Kod.ToString(), "OT_NIZA"));
            }
            else
                return 0;
        }
    }
    public bool IsZamkovaya => 
        bool.Parse(ini.ReadKey(ruchkaParam.Kod.ToString(), "ZAMKOVAYA"));
    public string Name => 
        ini.ReadKey(ruchkaParam.Kod.ToString(), "NAME");
}
