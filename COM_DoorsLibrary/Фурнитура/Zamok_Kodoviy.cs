using COM_DoorsLibrary;
using static DM;

internal class Zamok_Kodoviy
{
    private KodoviyDatas kodoviyDatas;

    private readonly IniFile ini;
    private readonly string iniPath;

    public Zamok_Kodoviy(ref DMParam param, ref Constants cons)
    {
        iniPath = cons.DIR_CONS_ZAMOK + "\\Kodoviy.ini";
        ini = new IniFile(iniPath);

        kodoviyDatas = new KodoviyDatas
        {
            Name = ini.ReadKey(Section(kodoviyDatas.Type), "NAME"),
            Type = param.Kodoviy.Type,
            OtPola = param.Kodoviy.OtPola > 0 ? param.Kodoviy.OtPola : (short)cons.KODOVIY_OT_POLA
        };

        switch (kodoviyDatas.Type) {
            case Kodoviy.Врезной_кнопки_на_лице:
            case Kodoviy.Врезной_кнопки_на_жопе:
                if (cons.CompareKod(param.Kod, "ДМ-1"))
                {
                    kodoviyDatas.OtShir = double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_K_OT_SHIR"));
                    if (cons.CompareKod(param.Kod, "(53)"))
                    {
                        kodoviyDatas.OtKrayaLA = param.Thick_LL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_OT_KRAYA_LA_53_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_OT_KRAYA_LA_53"));

                        kodoviyDatas.OtKrayaVA = param.Thick_VL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_OT_KRAYA_VA_53_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_OT_KRAYA_VA_53"));

                        kodoviyDatas.OtTelaVA = param.Thick_VL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_OT_TELA_VA_53_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_OT_TELA_VA_53"));
                    }
                    else
                    {
                        kodoviyDatas.OtKrayaLA = param.Thick_LL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_OT_KRAYA_LA_62_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_OT_KRAYA_LA_62"));

                        kodoviyDatas.OtKrayaVA = param.Thick_VL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_OT_KRAYA_VA_62_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_OT_KRAYA_VA_62"));

                        kodoviyDatas.OtTelaVA = param.Thick_VL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_OT_TELA_VA_62_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM1_OT_TELA_VA_62"));
                    }
                }
                else {
                    kodoviyDatas.OtShir = double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_K_OT_SHIR"));
                    if (cons.CompareKod(param.Kod, "(53)"))
                    {
                        kodoviyDatas.OtKrayaLA = param.Thick_LL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_LA_53_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_LA_53"));

                        kodoviyDatas.OtKrayaLP = param.Thick_LL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_LP_53_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_LP_53"));

                        kodoviyDatas.OtKrayaVA = param.Thick_VL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_VA_53_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_VA_53"));

                        kodoviyDatas.OtTelaVA = param.Thick_VL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_TELA_VA_53_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_TELA_VA_53"));
                    }
                    else
                    {
                        kodoviyDatas.OtKrayaLA = param.Thick_LL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_LA_62_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_LA_62"));

                        kodoviyDatas.OtKrayaLP = param.Thick_LL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_LP_62_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_LP_62"));

                        kodoviyDatas.OtKrayaVA = param.Thick_VL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_VA_62_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_VA_62"));

                        kodoviyDatas.OtTelaVA = param.Thick_VL.EqualsDouble(2) 
                            ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_TELA_VA_62_T2")) 
                            : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_TELA_VA_62"));
                    }
                }
                break;

            case Kodoviy.Врезной_пассивка_кнопки_на_лице:
            case Kodoviy.Врезной_пассивка_кнопки_на_жопе:
            case Kodoviy.Накладной_пассивка_кнопки_на_лице:
            case Kodoviy.Накладной_пассивка_кнопки_на_жопе:
                kodoviyDatas.OtKrayaLA = param.Thick_LL.EqualsDouble(2) 
                    ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_LA_53_T2")) 
                    : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_LA_53"));

                kodoviyDatas.OtKrayaLP = param.Thick_LL.EqualsDouble(2) 
                    ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_LP_53_T2")) 
                    : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_LP_53"));

                kodoviyDatas.OtKrayaVA = param.Thick_VL.EqualsDouble(2) 
                    ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_VA_53_T2")) 
                    : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_KRAYA_VA_53"));

                kodoviyDatas.OtTelaVA = param.Thick_VL.EqualsDouble(2) 
                    ? double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_TELA_VA_53_T2")) 
                    : double.Parse(ini.ReadKey(Section(kodoviyDatas.Type), "DM2_OT_TELA_VA_53"));
                break;

            case Kodoviy.Нет:
            default:
                kodoviyDatas.Name = "Нет";
                kodoviyDatas.OtKrayaLA = 0;
                kodoviyDatas.OtKrayaLP = 0;
                kodoviyDatas.OtKrayaVA = 0;
                kodoviyDatas.OtTelaVA = 0;
                kodoviyDatas.OtShir = 0;
                break;
        }
    }

    public void Move(short offset)
    {
        kodoviyDatas.OtPola += offset;
    }

    private static string Section(Kodoviy var)
    {
        switch (var)
        {
            case Kodoviy.Врезной_кнопки_на_лице:
                return "Vreznoy_Akt_Lizev";
            case Kodoviy.Врезной_кнопки_на_жопе:
                return "Vreznoy_Akt_Vnutr";
            case Kodoviy.Врезной_пассивка_кнопки_на_лице:
                return "Vreznoy_Pas_Lizev";
            case Kodoviy.Врезной_пассивка_кнопки_на_жопе:
                return "Vreznoy_Pas_Vnutr";
            case Kodoviy.Накладной_пассивка_кнопки_на_лице:
                return "Nakladnoy_Pas_Lizev";
            default:
                return "Nakladnoy_Pas_Vnutr";
        }
    }

    public KodoviyDatas Dates => kodoviyDatas;
    public double OtShir => kodoviyDatas.OtShir;
    public string Name => kodoviyDatas.Name;
    public double OtKrayaLA => kodoviyDatas.OtKrayaLA;
    public double OtKrayaLP => kodoviyDatas.OtKrayaLP;
    public double OtKrayaVA => kodoviyDatas.OtKrayaVA;
    public double OtTelaVA => kodoviyDatas.OtTelaVA;
    public short OtPola => kodoviyDatas.OtPola;
    public Kodoviy Kod => kodoviyDatas.Type;
}

public struct KodoviyDatas
{
    public Kodoviy Type;
    public string Name;
    public short OtPola;
    public double OtKrayaLA;
    public double OtKrayaLP;
    public double OtKrayaVA;
    public double OtTelaVA;
    public double OtShir;
    
    
}
