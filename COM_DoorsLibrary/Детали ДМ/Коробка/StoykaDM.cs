using static DM;

internal class StoykaDM : DetalKorobkiDM
{
    public StoykaDM(Raspolozhenie pos, short[] nalichniki, ref DMParam param, ref IniFile iniDM)
        : base(pos, nalichniki, ref param, ref iniDM){
        Constants cons = new Constants();

        //======================================================================================
        //------------------------------------|ГЕОМЕТРИЯ СТОЙКИ|--------------------------------
        //======================================================================================

        //Высота стойки
        if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое) 
        {
            Height = param.Height;
            Udlin = false;
            if (nalichniki[(short)Raspolozhenie.Ниж] > 0) 
            {
                Height -= 100;
                Udlin = true;
            }
        } 
        else 
        {
            Height = (short)(param.Height - short.Parse(iniDM.ReadKey("Korobka", "DM_K_VST_K3")));
            Udlin = false;
            if (nalichniki[(short)Raspolozhenie.Ниж] > 0) 
            {
                Height -= 100;
                Udlin = true;
            }
        }

        //Габарит стойки
        if (Type == 2 || Type == 4)
            Gabarit = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_GAB")) + double.Parse(iniDM.ReadKey("Korobka", "DM_K_K2"));
        else if (Type == 1 || Type == 3) 
            Gabarit = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_GAB"));
        else
            Gabarit = 0;

        //Стыковка стойки
        if(!(Type == 2) & (nalichniki[(short)Raspolozhenie.Верх] == 0 || param.Intek))
            Stik = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_STIK_K2"));
        else
            Stik = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_STIK"));

        //Глубина стойки
        if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое) 
        {
            if (Type == 2 & !param.Intek & nalichniki[(int)Raspolozhenie.Верх] > 0)
                Glubina = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_GLUB_NO_K2_K1")) + (koef90 / 2) + koef62;
            else
                Glubina = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_GLUB_NO")) + (koef90 / 2) + koef62;
        } 
        else 
            Glubina = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_GLUB_VO")) + (koef90 / 2) + koef62;

        //Занижение стойки
        if (param.Intek || nalichniki[(short)Raspolozhenie.Верх] == 0) {
            if (Type == 2) 
                ZanizhUp = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_ZANIZH_K2_K2"));
            else 
                ZanizhUp = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_ZANIZH_K1_K2"));
        } else {
            if (Type == 2) 
                ZanizhUp = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_ZANIZH_K2_K1"));
            else 
                ZanizhUp = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_ZANIZH_K1_K1"));
        }

        //Занижение стойки нижнее (наличник снизу)
        if (param.Framuga[(short)Raspolozhenie.Ниж].Type == FramugaType.нет) {
            if (nalichniki[(short)Raspolozhenie.Ниж] > 0) 
            {
                if (Type == 2) 
                    ZanizhDown = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_DWN_ZANIZH_K2_K1"));
                else 
                    ZanizhDown = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_ZANIZH_K1_K1"));
            } 
            else
                ZanizhDown = 0;
        } 
        else 
        {
            if (nalichniki[(short)Raspolozhenie.Ниж] > 0) {
                if (Type == 2) 
                    ZanizhDown = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_DWN_ZANIZH_K2_K1"));
                else 
                    ZanizhDown = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_ZANIZH_K1_K1"));
            } else {
                if (Type == 2)
                    ZanizhDown = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_ZANIZH_K2_K2"));
                else 
                    ZanizhDown = double.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_ZANIZH_K1_K2"));
            }
        }

        //Заглушки NS
        ZagNSUp = GetZagNS(0, ((short)pos), nalichniki, param.Otkrivanie.Value);     //верхняя
        ZagNSDown = GetZagNS(1, ((short)pos), nalichniki, param.Otkrivanie.Value);   //нижняя
        if((Height + (ZagNSUp/2) + (ZagNSDown / 2)) > cons.LIST_HIGHT)
        {
            ZagNSUp = 0;
            ZagNSDown = 0;
        }

        //Определение замковая ли стойка
        if (cons.CompareKod(param.Kod, "ДМ-1"))
        {
            if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.ЛевоеВО)
            {
                if (pos == Raspolozhenie.Прав)
                    zSt = true;
                else
                    zSt = false;
            }
            else
            {
                if (pos == Raspolozhenie.Лев)
                    zSt = true;
                else
                    zSt = false;
            }
        }
        else
            zSt = false;

        //======================================================================================
        //--------------------------------------|ДОП ВЫРЕЗЫ|------------------------------------
        //======================================================================================

        //Определение наличия и типа ответки замка
        if (zSt & param.Zamok != null & param.Zamok.Length > 0) 
        {
            SetZamok_Kod(0, param.Zamok[0].Kod);
            if (param.Zamok.Length > 1) SetZamok_Kod(2, param.Zamok[1].Kod);
            else SetZamok_Kod(1, 0);
            ZamokKodoviy = ((short)param.Kodoviy.Type);
            Zadvizhka = param.Zadvizhka.Kod;
        } 
        else 
        {
            SetZamok_Kod(1, 0);
            SetZamok_Kod(2, 0);
            ZamokKodoviy = 0;
            Zadvizhka = 0;
        }

        //Определение наличия отверстия под заземление
        if (param.GND == GNDRaspolozhenie.нет)
            GND = false;
        else 
        {
            if (zSt) 
                GND = false;
            else 
                GND = true;
        }

        //Определение наличия кабельканала в стойке
        if (param.Kabel == KabelRaspolozhenie.в_активке)
        {
            if (param.WAktiv.Value > 0d)
            {
                if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.ЛевоеВО)
                {
                    if (pos == Raspolozhenie.Лев) 
                        KabelKanal = true; 
                    else 
                        KabelKanal = false;
                }
                else
                {
                    if (pos == Raspolozhenie.Прав) 
                        KabelKanal = true; 
                    else 
                        KabelKanal = false;
                }
            }
            else
            {
                if (!zSt) 
                    KabelKanal = true; 
                else 
                    KabelKanal = false;
            }
        }
        else if (param.Kabel == KabelRaspolozhenie.в_пассивке)
        {
            if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.ЛевоеВО)
            {
                if (pos == Raspolozhenie.Прав) 
                    KabelKanal = true; 
                else 
                    KabelKanal = false;
            }
            else
            {
                if (pos == Raspolozhenie.Лев) 
                    KabelKanal = true;
                else 
                    KabelKanal = false;
            }
        }
        else
            KabelKanal = false;

        //======================================================================================
        //-----------------------------------|АНКЕРНЫЕ ОТВЕРСТИЯ|-------------------------------
        //======================================================================================

        //Расположение анкерных отверстий от края стойки
        if (param.Otkrivanie.Value == Otkrivanie.ЛевоеВО | param.Otkrivanie.Value == Otkrivanie.ПравоеВО)
            AnkerOtKraya = double.Parse(iniDM.ReadKey("Furnitura", "DM_ANKER_OT_KRAYA_K3")) + (koef62 / 2) - 1;
        else
        {
            if (nalichniki[(short)pos] == 0)
                AnkerOtKraya = double.Parse(iniDM.ReadKey("Furnitura", "DM_ANKER_OT_KRAYA_K2")) + (koef62 / 2);
            else
                AnkerOtKraya = double.Parse(iniDM.ReadKey("Furnitura", "DM_ANKER_OT_KRAYA_K1")) + (koef62 / 2);
        }
        if (cons.CompareKod(param.Kod, "ДМ", "(70)")) AnkerOtKraya += short.Parse(iniDM.ReadKey("Furnitura", "DM_K_ANKER_90"));

        //Расположение анкерных отверстий по высоте
        Rast1Anker = 200;
        if (param.Height <= 1250)
        {
            Rast2Anker = (short) (param.Height / 2 + 100);
            Rast3Anker = (short) (param.Height - 200);
        }
        else
        {
            Rast2Anker = 1070;
            if (param.Height >= 1800)
            {
                Rast3Anker = 1650;
            }
            else if (param.Height < 1800 && param.Height > 1650)
            {
                Rast3Anker = 1450;
            }
            else if (param.Height <= 1650 && param.Height > 1400)
            {
                Rast3Anker = 1250;
            }
            else if (param.Height <= 1400 && param.Height >= 1300)
            {
                Rast3Anker = 1200;
            }
            else
            {
                Rast3Anker = 2000;
            }
        }

        //Диаметры анкерных отверстий
        if (zSt) {
            DAnker1 = double.Parse(iniDM.ReadKey("Furnitura", "DM_ANKER_D"));
            DAnker2 = double.Parse(iniDM.ReadKey("Furnitura", "DM_ANKER_D"));
            DAnker3 = DAnker1;
        } else {
            if (param.Protivos == 2) {
                DAnker1 = double.Parse(iniDM.ReadKey("Furnitura", "DM_PROTIVOS_D"));
                DAnker2 = double.Parse(iniDM.ReadKey("Furnitura", "DM_ANKER_D"));
                DAnker3 = DAnker1;
            } else {
                DAnker1 = double.Parse(iniDM.ReadKey("Furnitura", "DM_ANKER_D"));
                DAnker2 = double.Parse(iniDM.ReadKey("Furnitura", "DM_PROTIVOS_D"));
                DAnker3 = DAnker1;
            }
        }

        //======================================================================================
        //-------------------------------------|ПРИСВОЕНИЕ ИМЕНИ|-------------------------------
        //======================================================================================
        //string tmp, tmpPosSt;

        //if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.ЛевоеВО) {
        //    if (cons.CompareKod(param.Kod, "ДМ-1")) {
        //        if (pos == Raspolozhenie.Верх) { tmp = "PS1"; } else { tmp = "ZS1"; }
        //    } else {
        //        if (pos == Raspolozhenie.Верх) { tmp = "PS2"; } else { tmp = "PS3"; }
        //    }
        //} else {
        //    if (cons.CompareKod(param.Kod, "ДМ-1")) {
        //        if (pos == Raspolozhenie.Верх) { tmp = "ZS1"; } else { tmp = "PS1"; }
        //    } else {
        //        if (pos == Raspolozhenie.Верх) { tmp = "PS3"; } else { tmp = "PS2"; }
        //    }
        //}

        //if (pos == Raspolozhenie.Лев) {
        //    tmpPosSt = "_L_";
        //} else {
        //    tmpPosSt = "_R_";
        //}

        //Name += tmp + tmpPosSt + param.Num;
    }

    private short GetZagNS(short num, short pos, short[] nalichniki, Otkrivanie otkrivanie) {
        if (nalichniki[num] > nalichniki[pos]) {
            if (nalichniki[pos] == 0) {
                if (otkrivanie == Otkrivanie.Левое || otkrivanie == Otkrivanie.Правое) {
                    return (short)((nalichniki[num] - 20) * 2);
                } else {
                    return (short)(nalichniki[num] * 2);
                }
            } else {
                return (short)((nalichniki[num] - nalichniki[pos]) * 2);
            }
        } else {
            return 0;
        }
    }
}
