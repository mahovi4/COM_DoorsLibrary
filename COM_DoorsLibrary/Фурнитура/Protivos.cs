using static DM;

internal class Protivos
{
    private readonly short _otPola;
    private readonly double _otKraya;

    private readonly IniFile ini;

    public Protivos(short num, ref DMParam param, ref Constants cons, ref IniFile iniDM)
    {
        ini = new IniFile(cons.DIR_CONS_FURNIT + "\\Protivos.ini");
        short koef62 = cons.ST62 & cons.CompareKod(param.Kod, "ДМ", "(62)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_62")) : (short)0;

        _otKraya = cons.CompareKod(param.Kod, "ДМ", "(70)") ? double.Parse(iniDM.ReadKey("Furnitura", "DM_PROTIVOS_OT_KRAYA_90")) : 
                                                              double.Parse(iniDM.ReadKey("Furnitura", "DM_PROTIVOS_OT_KRAYA")) + (koef62 / 2);
        if (num == 0)
        {
            if (param.Protivos == 1)
            {
                if (param.Height <= 1250)
                    _otPola = (short)(param.Height / 2 + 100);
                else
                    _otPola = short.Parse(ini.ReadKey("Protivos", "OT_POLA_DO_1_1"));
            }
            else
                _otPola = short.Parse(ini.ReadKey("Protivos", "OT_POLA_DO_1_2"));                         
        }
        else
        {
            if (param.Height <= 1250)
                _otPola = (short)(param.Height - 200);
            else
                _otPola = param.Height < 1800 & param.Height >= 1600
                    ? short.Parse(ini.ReadKey("Protivos", "OT_POLA_DO_2_1800"))
                    : param.Height < 1600
                        ? short.Parse(ini.ReadKey("Protivos", "OT_POLA_DO_2_1600"))
                        : short.Parse(ini.ReadKey("Protivos", "OT_POLA_DO_2_1900"));
        }
    }

    public short OtPola
    {
        get { return _otPola; }
    }
    public double OtKraya
    {
        get { return _otKraya; }
    }
}
