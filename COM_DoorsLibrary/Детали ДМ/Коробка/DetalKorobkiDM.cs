internal class DetalKorobkiDM
{
    private short KType, KZamok1, KZamok2, KZamokKodoviy, KZadvizhka, KHeight, KRast1Anker, KRast2Anker, KRast3Anker, KZagNSUp, KZagNSDown;
    private double KGabarit, KStik, KGlubina, KZanizhUp, KZanizhDown, KNalichnik, KAnkerOtKraya, KDAnker1, KDAnker2, KDAnker3, KOTSotKraya, KOTSotstup;
    private bool KUdlin, KGND, KOTS, KObrezka, KKabelKanal, KzSt;
    private string KName, KError;
    private readonly short Kkoef90, Kkoef62, Kk62por, KkoefK1, KkoefK2, KkoefK3, KkoefKK2;

    public DetalKorobkiDM(Raspolozhenie pos, short[] nalichniki, ref DMParam param, ref IniFile iniDM)
    {
        Constants cons = new Constants();
        Kkoef90 = cons.CompareKod(param.Kod, "ДМ", "(70)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_90")) : (short)0;
        Kkoef62 = cons.ST62 && cons.CompareKod(param.Kod, "ДМ", "(62)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_62")) : (short)0;
        if (koef62 > 0)
        {
            if (param.Porog.Kod == 14)
                Kk62por = (short)(koef62 + 3);
            else if (param.Porog.Kod == 30)
                Kk62por = (short)(koef62 + 1);
            else
                Kk62por = koef62;
        }
        else
            Kk62por = 0;

        KkoefK1 = short.Parse(iniDM.ReadKey("Korobka", "DM_K_GST_K1"));
        KkoefK2 = short.Parse(iniDM.ReadKey("Korobka", "DM_K_GST_K2"));
        KkoefK3 = short.Parse(iniDM.ReadKey("Korobka", "DM_K_GST_K3"));
        KkoefKK2 = short.Parse(iniDM.ReadKey("Korobka", "DM_K_K2"));

        //Определение типа стойки и размера наличника
        if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое) 
        {
            if (pos == Raspolozhenie.Верх) 
            {
                if (param.Intek) 
                {
                    KType = 4;
                    KNalichnik = nalichniki[((short)pos)] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K1"));
                } 
                else if (nalichniki[((short)pos)] == 0) 
                {
                    KType = 2;
                    KNalichnik = double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K2"));
                } 
                else 
                {
                    KType = 1;
                    KNalichnik = nalichniki[((short)pos)] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K1"));
                }
            } 
            else if (pos == Raspolozhenie.Ниж) 
            {
                if (!param.IsFramuga((short)pos)) 
                {
                    if (param.Porog.Kod > 4) 
                    {
                        KType = param.Porog.Kod;
                        KNalichnik = 0;
                    } 
                    else if ((param.Porog.Kod == 0 || param.Porog.Kod == 2) && nalichniki[((short)pos)] == 0) 
                    {
                        KType = 0;
                        KNalichnik = 0;
                    } 
                    else if (param.Porog.Kod > 0 && nalichniki[(short)pos] > 0) 
                    {
                        KError += "И порог и наличник снизу, быть не может (должно быть что-то одно)! ";
                    } 
                    else 
                    {
                        if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое) 
                        {
                            KType = 1;
                            KNalichnik = nalichniki[(short)pos] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K1"));
                        } 
                        else 
                        {
                            KType = 3;
                            KNalichnik = nalichniki[(short)pos] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K3"));
                        }
                    }
                } else if (param.Framuga[(short)pos].Type == FramugaType.полного_остекления) 
                {
                    if (param.Porog.Kod > 1) 
                    {
                        if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое) 
                        {
                            KType = 1;
                            KNalichnik = nalichniki[(short)pos] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K1"));
                        } 
                        else 
                        {
                            KType = 3;
                            KNalichnik = nalichniki[(short)pos] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K3"));
                        }
                        KError += "Нижняя фрамуга и порог не стыкуются (должна быть притолока вместо порога)! ";
                    }
                    if (nalichniki[(short)pos] == 0) 
                    {
                        KType = 2;
                        KNalichnik = double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K2"));
                    } 
                    else 
                    {
                        if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое) 
                        {
                            KType = 1;
                            KNalichnik = nalichniki[(short)pos] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K1"));
                        } 
                        else 
                        {
                            KType = 3;
                            KNalichnik = nalichniki[(short)pos] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K3"));
                        }
                    }
                } 
                else 
                {
                    if (param.Porog.Kod > 1) 
                    {
                        KError += "Нижняя фрамуга и порог не стыкуются (должна быть притолока вместо порога)! ";
                    } 
                    else 
                    {
                        if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое) 
                        {
                            KType = 1;
                            KNalichnik = nalichniki[(short)pos] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K1"));
                        } 
                        else 
                        {
                            KType = 3;
                            KNalichnik = nalichniki[(short)pos] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K3"));
                        }
                    }
                }
            } 
            else 
            {
                if (nalichniki[(short)pos] == 0) 
                {
                    KType = 2;
                    KNalichnik = double.Parse(iniDM.ReadKey("Korobka", "DM_K_ST_NAL_K2"));
                } 
                else 
                {
                    KType = 1;
                    KNalichnik = nalichniki[(short)pos] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_ST_NAL_K1"));
                }
            }
        } 
        else 
        {
            if (pos == Raspolozhenie.Верх) 
            {
                if (nalichniki[(short)pos] == 0)
                    KType = 2;
                else 
                    KType = 3;
                KNalichnik = nalichniki[((short)pos)] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K3"));
            } 
            else if (pos == Raspolozhenie.Ниж) 
            {
                if (!param.IsFramuga((short)pos)) 
                {
                    if (param.Porog.Kod > 2) 
                    {
                        KType = param.Porog.Kod;
                        KNalichnik = 0;
                    } 
                    else if ((param.Porog.Kod == 0 || param.Porog.Kod == 2) && nalichniki[(short)pos] == 0) 
                    {
                        KType = 0;
                        KNalichnik = 0;
                    } 
                    else if (param.Porog.Kod > 0 && nalichniki[(short)pos] > 0)
                        KError += "И порог и наличник снизу, быть не может (должно быть что-то одно)! ";
                    else 
                    {
                        KType = 3;
                        KNalichnik = nalichniki[(short)pos] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K3"));
                    }
                } else if (param.Framuga[(short)pos].Type == FramugaType.полного_остекления) 
                {
                    if (param.Porog.Kod > 1) 
                    {
                        param.Porog.Kod = 1;
                        KError += "Нижняя фрамуга и порог не стыкуются (должна быть притолока вместо порога)! ";
                    }
                    if (nalichniki[(short)pos] == 0) 
                    {
                        KType = 2;
                        KNalichnik = double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K2"));
                    } 
                    else 
                    {
                        KType = 3;
                        KNalichnik = nalichniki[(short)pos] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K3"));
                    }
                } 
                else 
                {
                    if (param.Porog.Kod > 1) 
                    {
                        param.Porog.Kod = 1;
                        KError += "Нижняя фрамуга и порог не стыкуются (должна быть притолока вместо порога)! ";
                    }
                    KType = 3;
                    KNalichnik = nalichniki[((short)pos)] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_PRIT_NAL_K3"));
                }
            } 
            else 
            {
                if (nalichniki[(short)pos] == 0)
                    KType = 2;
                else
                    KType = 3;
                KNalichnik = nalichniki[(short)pos] + double.Parse(iniDM.ReadKey("Korobka", "DM_K_ST_NAL_K3"));
            }
        }

        //======================================================================================
        //------------------------------------|ГЕОМЕТРИЯ СТОЙКИ|--------------------------------
        //======================================================================================
        //Обрезка наличника по фрамуге
        if (param.Framuga[(short)pos].Type == FramugaType.полного_остекления) 
        {
            //if (nalichniki[(short)pos] == 0)
            //    KObrezka = false;
            //else
                KObrezka = true;
        } 
        else
            KObrezka = false;

        //======================================================================================
        //-------------------------------------|ПРИСВОЕНИЕ ИМЕНИ|-------------------------------
        //======================================================================================
        string tmpTip, tmpTeh, tmp, tmpPosSt;

        if (KType == 1) 
        {
            if (param.Framuga[(short)pos].Type == FramugaType.полного_остекления)
                tmpTip = "K4_";
            else if (nalichniki[((short)pos)] == short.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_NAL_K1")))
                tmpTip = "K1_";
            else
                tmpTip = "NS_";
        } 
        else if (KType == 2) 
        {
            tmpTip = "K2_";
        } 
        else if (KType == 4) 
        {
            tmpTip = "IN_";
        } 
        else if (KType == 3) 
        {
            if (param.Framuga[(short)pos].Type == FramugaType.полного_остекления)
                tmpTip = "K5_";
            else if (nalichniki[((short)pos)] == short.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_NAL_K3")))
                tmpTip = "K3_";
            else
                tmpTip = "NS_";
        } 
        else 
        {
            tmpTip = "POR";
            if (KType < 100)
                tmpTip += "0" + KType;
            else
                tmpTip += KType;
        }

        if (cons.CompareKod(param.Kod, "ДМ", "(70)"))
            tmpTeh = "(70)";
        else if (cons.ST62 && cons.CompareKod(param.Kod, "ДМ", "(62)"))
            tmpTeh = "(62)";
        else if ((!cons.ST62) && cons.CompareKod(param.Kod, "ДМ", "(62)"))
            tmpTeh = "(53)";
        else
            tmpTeh = "(53)";

        if (pos == Raspolozhenie.Верх)
            tmp = "UPS";
        else if (pos == Raspolozhenie.Ниж)
            tmp = KType > 4 ? "" : "DWN";
        else 
        {
            if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.ЛевоеВО) 
            {
                if (cons.CompareKod(param.Kod, "ДМ-1"))
                    tmp = pos == Raspolozhenie.Лев ? "PS1" : "ZS1";
                else
                    tmp = pos == Raspolozhenie.Лев ? "PS2" : "PS3";
            } 
            else 
            {
                if (cons.CompareKod(param.Kod, "ДМ-1"))
                    tmp = pos == Raspolozhenie.Лев ? "ZS1" : "PS1";
                else
                    tmp = pos == Raspolozhenie.Лев ? "PS3" : "PS2";
            }
        }

        if (pos == Raspolozhenie.Верх || pos == Raspolozhenie.Ниж) {
            if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.ЛевоеВО) {
                tmpPosSt = "_L_";
            } else {
                tmpPosSt = "_R_";
            }
        } else if (pos == Raspolozhenie.Прав) {
            tmpPosSt = "_R_";
        } else {
            tmpPosSt = "_L_";
        }

        KName = tmpTip + tmpTeh + tmp + tmpPosSt + param.Num;
    }

    public short koef90
    {
        get => Kkoef90;
    }
    public short koef62
    {
        get => Kkoef62;
    }
    public short k62por
    {
        get => Kk62por;
    }
    public short koefK1
    {
        get => KkoefK1;
    }
    public short koefK2
    {
        get => KkoefK2;
    }
    public short koefK3
    {
        get => KkoefK3;
    }
    public short koefKK2
    {
        get => KkoefKK2;
    }
    public short GetZamok_Kod(short num) {
        if (num == 0) {
            return KZamok1;
        } else {
            return KZamok2;
        }
    }
    public void SetZamok_Kod(short num, short value) {
        if (num == 0) {
            KZamok1 = value;
        } else {
            KZamok2 = value;
        }
    }
    public short ZamokKodoviy {
        get => KZamokKodoviy;
        set => KZamokKodoviy = value;
    }
    public short Zadvizhka {
        get => KZadvizhka;
        set => KZadvizhka = value;
    }
    public short Height {
        get => KHeight;
        set => KHeight = value;
    }
    public double Gabarit {
        get => KGabarit;
        set => KGabarit = value;
    }
    public double Stik {
        get => KStik;
        set => KStik = value;
    }
    public double Glubina {
        get => KGlubina;
        set => KGlubina = value;
    }
    public double ZanizhUp {
        get => KZanizhUp;
        set => KZanizhUp = value;
    }
    public double ZanizhDown {
        get => KZanizhDown;
        set => KZanizhDown = value;
    }
    public short ZagNSUp {
        get => KZagNSUp;
        set => KZagNSUp = value;
    }
    public short ZagNSDown {
        get => KZagNSDown;
        set => KZagNSDown = value;
    }
    public double Nalichnik {
        get => KNalichnik;
        set => KNalichnik = value;
    }
    public double AnkerOtKraya {
        get => KAnkerOtKraya;
        set => KAnkerOtKraya = value;
    }
    public short Rast1Anker {
        get => KRast1Anker;
        set => KRast1Anker = value;
    }
    public short Rast2Anker {
        get => KRast2Anker;
        set => KRast2Anker = value;
    }
    public short Rast3Anker {
        get => KRast3Anker;
        set => KRast3Anker = value;
    }
    public double DAnker1 {
        get => KDAnker1;
        set => KDAnker1 = value;
    }
    public double DAnker2 {
        get => KDAnker2;
        set => KDAnker2 = value;
    }
    public double DAnker3 {
        get => KDAnker3;
        set => KDAnker3 = value;
    }
    public string Name {
        get => KName;
        set => KName = value;
    }
    public bool Udlin {
        get => KUdlin;
        set => KUdlin = value;
    }
    public bool GND {
        get => KGND;
        set => KGND = value;
    }
    public short Type {
        get => KType;
        set => KType = value;
    }
    public bool OTS {
        get => KOTS;
        set => KOTS = value;
    }
    public double OTSotKraya {
        get => KOTSotKraya;
        set => KOTSotKraya = value;
    }
    public double OTSotstup {
        get => KOTSotstup;
        set => KOTSotstup = value;
    }
    public bool Obrezka {
        get => KObrezka;
        set => KObrezka = value;
    }
    public bool KabelKanal {
        get => KKabelKanal;
        set => KKabelKanal = value;
    }
    public bool zSt {
        get => KzSt;
        set => KzSt = value;
    }
    public string Errors {
        get => KError;
        set => KError += value;
    }
}
