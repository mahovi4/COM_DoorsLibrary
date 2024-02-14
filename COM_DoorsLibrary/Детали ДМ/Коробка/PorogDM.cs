using static DM;

internal class PorogDM : DetalKorobkiDM
{
    public PorogDM(Raspolozhenie pos, short[] nalichniki, ref DMParam param, ref IniFile iniDM)
        : base(pos, nalichniki, ref param, ref iniDM) {

        Constants cons = new Constants();
        

        //======================================================================================
        //------------------------------------|ГЕОМЕТРИЯ СТОЙКИ|--------------------------------
        //======================================================================================
        if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое) {
            if (nalichniki[0] == 0) {
                if (nalichniki[2] > 0 && nalichniki[3] > 0) {
                    Height = (short)(param.Width - koefK2 + 2);
                } else if ((nalichniki[2] == 0 && nalichniki[3] > 0) || (nalichniki[2] > 0 && nalichniki[3] == 0)) {
                    Height = (short)(param.Width - koefK2 - koefKK2 + 2);
                } else if (nalichniki[2] == 0 && nalichniki[3] == 0) {
                    Height = (short)(param.Width - koefK2 - (koefKK2 * 2) + 2);
                }
            } else {
                if (nalichniki[2] > 0 && nalichniki[3] > 0) {
                    Height = (short)(param.Width - koefK1);
                } else if ((nalichniki[2] == 0 && nalichniki[3] > 0) || (nalichniki[2] > 0 && nalichniki[3] == 0)) {
                    Height = (short)(param.Width - koefK1 - koefKK2);
                } else if (nalichniki[2] == 0 && nalichniki[3] == 0) {
                    Height = (short)(param.Width - koefK1 - (koefKK2 * 2));
                }
            }
        } else {
            Height = (short)(param.Width - koefK3);
        }

        //Глубина и габарит порога
        switch (param.Porog.Kod) {
            case 40: 
            case 41:
                Glubina = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GLUB_40")) + k62por + (koef90 / 2);
                Gabarit = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GAB_40"));
                break;
            case 25:
                Glubina = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GLUB_25")) + k62por + (koef90 / 2);
                Gabarit = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GAB_25"));
                break;
            case 26:
                Glubina = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GLUB_26")) + k62por + (koef90 / 2);
                Gabarit = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GAB_26"));
                break;
            case 14:
                Glubina = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GLUB_14")) + k62por + (koef90 / 2);
                Gabarit = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GAB_14"));
                break;
            case 15:
                Glubina = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GLUB_15")) + k62por + (koef90 / 2);
                Gabarit = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GAB_15"));
                break;
            case 100:
                Glubina = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GLUB_100")) + k62por + (koef90 / 2);
                Gabarit = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GAB_100"));
                break;
            case 30:
                Glubina = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GLUB_30")) + k62por + (koef90 / 2);
                Gabarit = double.Parse(iniDM.ReadKey("Porog", "DM_POR_GAB_30"));
                break;
            default:
                Glubina = 0.1;
                Gabarit = 0.1;
                break;
        }

        //======================================================================================
        //-------------------------------------|ПРИСВОЕНИЕ ИМЕНИ|-------------------------------
        //======================================================================================
        string tmpTip, tmpTeh, tmpOtkr;
        if (param.Porog.Kod > 2) {
            if (param.Porog.Kod >= 100) {
                tmpTip = param.Porog.Kod.ToString();
            } else {
                tmpTip = "0" + param.Porog.Kod.ToString();
            }

            if (cons.CompareKod(param.Kod, "ДМ", "(70)")) {
                tmpTeh = "(70)";
            } else if (cons.ST62 & cons.CompareKod(param.Kod, "ДМ", "(62)")) {
                tmpTeh = "(62)";
            } else if (!cons.ST62 & cons.CompareKod(param.Kod, "ДМ", "(62)")) {
                tmpTeh = "(53)";
            } else {
                tmpTeh = "(53)";
            }

            if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.ЛевоеВО) {
                tmpOtkr = "_L_";
            } else {
                tmpOtkr = "_R_";
            }

            Name = tmpTeh + "POR" + tmpTip + tmpOtkr + param.Num;
        } else {
            Name = "-";
        }

    }
}
