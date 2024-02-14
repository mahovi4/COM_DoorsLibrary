
internal class PritolokaDM : DetalKorobkiDM
{

    public PritolokaDM(Raspolozhenie pos, short[] nalichniki, ref DMParam param, ref IniFile iniDM) 
        : base(pos, nalichniki, ref param, ref iniDM) 
    {
        //======================================================================================
        //------------------------------------|ГЕОМЕТРИЯ СТОЙКИ|--------------------------------
        //======================================================================================

        //Ширина
        if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое) 
        {
            if (pos == Raspolozhenie.Верх) 
            {
                if (nalichniki[(short)pos] == 0) 
                {
                    if (nalichniki[(short)Raspolozhenie.Прав] > 0 && 
                        nalichniki[(short)Raspolozhenie.Лев] > 0)
                        Height = (short)(param.Width - koefK2 + 2);
                    else if ((nalichniki[(short)Raspolozhenie.Прав] == 0 && 
                              nalichniki[(short)Raspolozhenie.Лев] > 0) || 
                              (nalichniki[(short)Raspolozhenie.Прав] > 0 && 
                               nalichniki[(short)Raspolozhenie.Лев] == 0))
                        Height = (short)(param.Width - koefK2 - koefKK2 + 2);
                    else if (nalichniki[(short)Raspolozhenie.Прав] == 0 && 
                             nalichniki[(short)Raspolozhenie.Лев] == 0)
                        Height = (short)(param.Width - koefK2 - (koefKK2 * 2) + 2);
                } 
                else 
                {
                    if (nalichniki[(short)Raspolozhenie.Прав] > 0 && nalichniki[(short)Raspolozhenie.Лев] > 0)
                        Height = (short)(param.Width - koefK1);
                    else if ((nalichniki[(short)Raspolozhenie.Прав] == 0 &&
                              nalichniki[(short)Raspolozhenie.Лев] > 0) || 
                              (nalichniki[(short)Raspolozhenie.Прав] > 0 && 
                               nalichniki[(short)Raspolozhenie.Лев] == 0))
                        Height = (short)(param.Width - koefK1 - koefKK2);
                    else if (nalichniki[(short)Raspolozhenie.Прав] == 0 && 
                             nalichniki[(short)Raspolozhenie.Лев] == 0)
                        Height = (short)(param.Width - koefK1 - (koefKK2 * 2));
                }
            } 
            else if (pos == Raspolozhenie.Ниж) 
            {
                if (nalichniki[(short)Raspolozhenie.Прав] > 0 && 
                    nalichniki[(short)Raspolozhenie.Лев] > 0)
                    Height = (short)(param.Width - koefK1);
                else if ((nalichniki[(short)Raspolozhenie.Прав] == 0 && 
                          nalichniki[(short)Raspolozhenie.Лев] > 0) || 
                          (nalichniki[(short)Raspolozhenie.Прав] > 0 && 
                           nalichniki[(short)Raspolozhenie.Лев] == 0))
                    Height = (short)(param.Width - koefK1 - koefKK2);
                else if (nalichniki[(short)Raspolozhenie.Прав] == 0 && 
                         nalichniki[(short)Raspolozhenie.Лев] == 0) 
                    Height = (short)(param.Width - koefK1 - (koefKK2 * 2));
            }
        } 
        else
            Height = param.Width;

        //Габарит
        if ((short)pos == 0) 
        {
            if (param.Intek)
                Gabarit = double.Parse(iniDM.ReadKey("Pritoloka", "DM_PRIT_GAB")) + koefKK2;
            else 
            {
                if (nalichniki[((short)pos)] == 0)
                    Gabarit = double.Parse(iniDM.ReadKey("Pritoloka", "DM_PRIT_GAB")) + koefKK2;
                else
                    Gabarit = double.Parse(iniDM.ReadKey("Pritoloka", "DM_PRIT_GAB"));
            }
        } 
        else if ((short)pos == 1)
            Gabarit = double.Parse(iniDM.ReadKey("Pritoloka", "DM_PRIT_GAB"));

        //Глубина
        if (param.Otkrivanie.Value == Otkrivanie.Левое || param.Otkrivanie.Value == Otkrivanie.Правое)
            Glubina = double.Parse(iniDM.ReadKey("Pritoloka", "DM_PRIT_GLUB_NO")) + (koef90 / 2) + koef62;
        else
            Glubina = double.Parse(iniDM.ReadKey("Pritoloka", "DM_PRIT_GLUB_VO")) + (koef90 / 2) + koef62;
    }
}
