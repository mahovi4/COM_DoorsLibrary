using System;
using static DM;

internal class KorobkaDM
{
    private readonly bool PorogNS;
    private readonly short[] _nalichniki = new short[4];
    private readonly DetalKorobkiDM[] Detales = new DetalKorobkiDM[4];

    public KorobkaDM(ref DMParam param, ref IniFile iniDM)
    {
        for (short i = 0; i <= 3; i++) {
            _nalichniki[i] = CheckNalichnik(i, ref param, ref iniDM);
        }
        if (_nalichniki[(short)Raspolozhenie.Ниж] == 0) {
            if (param.Framuga[(short)Raspolozhenie.Ниж].Type == FramugaType.нет) {
                if (param.Porog.Kod == 1000) {
                    param.Porog.Kod = 0;
                    PorogNS = true;
                } else {
                    PorogNS = false;
                }
            }
            else {
                param.Porog.Kod = 1;
            }
        } else {
            param.Porog.Kod = 1;
        }
        for (short i = 0; i < Detales.Length; i++) {
            if (i == 0) {
                Detales[i] = new PritolokaDM((Raspolozhenie)i, _nalichniki, ref param, ref iniDM);
            } else if (i == 1) {
                if (!param.IsFramuga(i)) {
                    if (_nalichniki[i] > 0) {
                        Detales[i] = new PritolokaDM((Raspolozhenie)i, _nalichniki, ref param, ref iniDM);
                    } else {
                        if (param.Porog.Kod > 2) {
                            Detales[i] = new PorogDM((Raspolozhenie)i, _nalichniki, ref param, ref iniDM);
                        } else {
                            Detales[i] = null;
                        }
                    }
                }
                else {
                    Detales[i] = new PritolokaDM((Raspolozhenie)i, _nalichniki, ref param, ref iniDM);
                }
            } else {
                Detales[i] = new StoykaDM((Raspolozhenie)i, _nalichniki, ref param, ref iniDM);
            }
        }
    }

    private short CheckNalichnik(short num, ref DMParam param, ref IniFile iniDM) 
    {
        if (!param.IsFramuga(num))
            return param.Nalichniki[num];
        else 
        {
            //Изменение алгоритма определения наличника по стыковке с фрамугой
            //if (param.Framuga[num].Type == FramugaType.полного_остекления)
            //{
            //    if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
            //    {
            //        if (param.Nalichniki[num] == 0)
            //            return 0;
            //        return short.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_NAL_K1"));
            //    }
            //    else
            //    {
            //        if (param.Nalichniki[num] == 0)
            //            return 0;
            //        return short.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_NAL_K3"));
            //    }
            //}
            //else
            //{
                if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
                    return short.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_NAL_K1"));
                return short.Parse(iniDM.ReadKey("Stoyki", "DM_STOYKI_NAL_K3"));
            //}
        }
    }
    public short[] Nalichniki
    {
        get { return _nalichniki; }
    }
    public short Nalichnik(short pos)
    {
        return _nalichniki[pos];
    }
    public bool IsPorogNestandart
    {
        get { return PorogNS; }
    }
    public bool IsStoyka(Raspolozhenie pos)
    {
        return !(Detales[(short)pos] == null);
    }
    public bool IsObrezkaNalichnika(Raspolozhenie pos)
    {
        if (IsStoyka(pos)) {
            return Detales[(short)pos].Obrezka;
        } else {
            return false;
        }
    }
    public string Name(short index) {
        Raspolozhenie pos = Raspolozhenie.Верх;
        switch (index)
        {
            case 4:
                pos = Raspolozhenie.Лев;
                break;
            case 5:
                pos = Raspolozhenie.Прав;
                break;
            case 6:
                pos = Raspolozhenie.Верх;
                break;
            case 7:
                pos = Raspolozhenie.Ниж;
                break;
        }
        if (IsStoyka(pos)) {
            return Detales[(short)pos].Name;
        }
        else {
            return "Not";
        }
    }
    public short Zamok_Kod(short num, Raspolozhenie pos) {
        if (pos == Raspolozhenie.Прав || pos == Raspolozhenie.Лев) {
            return Detales[(short)pos].GetZamok_Kod(num);
        } else {
            return 0;
        }
    }
    public short ZamokKodoviy(Raspolozhenie pos) {
        if (pos == Raspolozhenie.Прав | pos == Raspolozhenie.Лев) {
            return Detales[(short)pos].ZamokKodoviy;
        } else {
            return 0;
        }
    }
    public short Zadvizhka(Raspolozhenie pos) {
        if (pos == Raspolozhenie.Прав | pos == Raspolozhenie.Лев) {
            return Detales[(short)pos].Zadvizhka;
        } else {
            return 0;
        }
    }
    public double AnkerOtKraya(Raspolozhenie pos) {
        if (IsStoyka(pos)) {
            return Detales[(short)pos].AnkerOtKraya;
        } else {
            return 0;
        }
    }
    public short AnkerOtPola(short num) {
        if (num == 1) {
            return Detales[2].Rast1Anker;
        } else if (num == 2) {
            return Detales[2].Rast2Anker;
        } else {
            return Detales[2].Rast3Anker;
        }
    }
    public double NalichnikStoyki(Raspolozhenie pos) {
        if (IsStoyka(pos)) {
            return Detales[(short)pos].Nalichnik;
        } else {
            return 0;
        }
    }
    public short HightStoyki(Raspolozhenie pos) {
        if (IsStoyka(pos)) {
            return Detales[(short)pos].Height;
        } else {
            return 0;
        }
    }
    public double GabaritStoyki(Raspolozhenie pos) {
        if (IsStoyka(pos)) {
            return Detales[(short)pos].Gabarit;
        } else {
            return 0;
        }
    }
    public double GlubinaStoyki(Raspolozhenie pos) {
        if (IsStoyka(pos)) {
            return Detales[(short)pos].Glubina;
        } else {
            return 0;
        }
    }
    public double StikovkaStoyki(Raspolozhenie pos) {
        if (pos == Raspolozhenie.Прав | pos == Raspolozhenie.Лев) {
            return Detales[(short)pos].Stik;
        } else {
            return 0;
        }
    }
    public double ZanizhenieStoyki(Raspolozhenie pos) {
        if (pos == Raspolozhenie.Прав | pos == Raspolozhenie.Лев) {
            return Detales[(short)pos].ZanizhUp;
        } else {
            return 0;
        }
    }
    public short UpZaglushkaNSStoyki(Raspolozhenie pos) {
        if (pos == Raspolozhenie.Прав | pos == Raspolozhenie.Лев) {
            return Detales[(short)pos].ZagNSUp;
        } else {
            return 0;
        }
    }
    public short DownZaglushkaNSStoyki(Raspolozhenie pos)
    {
        if (pos == Raspolozhenie.Прав | pos == Raspolozhenie.Лев) {
            return Detales[(short)pos].ZagNSDown;
        } else {
            return 0;
        }
    }
    public double DownZanizhenieStoyki(Raspolozhenie pos) {
        if (pos == Raspolozhenie.Прав | pos == Raspolozhenie.Лев) {
            return Detales[(short)pos].ZanizhDown;
        } else {
            return 0;
        }
    }
    public double RazvertkaStoyki(Raspolozhenie pos)
    {
        if (IsStoyka(pos))
        {
            switch (pos)
            {
                case Raspolozhenie.Лев:
                case Raspolozhenie.Прав:
                    if (Detales[(int)pos].Type == 3)
                        return Detales[(int)pos].Glubina + Detales[(int)pos].Nalichnik + 75.73;
                    else
                        return Detales[(int)pos].Gabarit + Detales[(int)pos].Glubina + Detales[(int)pos].Nalichnik + 4.6038215 - 0.000178533;
                case Raspolozhenie.Верх:
                case Raspolozhenie.Ниж:
                    if (Detales[(int)pos].Type == 3)
                        return Detales[(int)pos].Glubina + Detales[(int)pos].Nalichnik + 72.38;
                    else if (Detales[(int)pos].Type < 5)
                        return Detales[(int)pos].Gabarit + Detales[(int)pos].Glubina + Detales[(int)pos].Nalichnik + 27.95;
                    else
                        return Detales[(int)pos].Glubina + Detales[(int)pos].Gabarit + 1.8;
            }
            return 0;
        }
        else
            return 0;
    }
    public double DAnker1Stoyki(Raspolozhenie pos) {
        if (pos == Raspolozhenie.Прав | pos == Raspolozhenie.Лев) {
            return Detales[(short)pos].DAnker1;
        } else {
            return 0;
        }
    }
    public double DAnker2Stoyki(Raspolozhenie pos) {
        if (pos == Raspolozhenie.Прав | pos == Raspolozhenie.Лев) {
            return Detales[(short)pos].DAnker2;
        } else {
            return 0;
        }
    }
    public bool GND(short index) {
        Raspolozhenie pos = Raspolozhenie.Верх;
        if (index == 4) pos = Raspolozhenie.Лев;
        else if (index == 5) pos = Raspolozhenie.Прав;

        if (pos == Raspolozhenie.Прав | pos == Raspolozhenie.Лев) {
            return Detales[(short)pos].GND;
        } else {
            return false;
        }
    }
    public bool KabelKanal(short index)
    {
        Raspolozhenie pos = Raspolozhenie.Верх;
        if (index == 4) pos = Raspolozhenie.Лев;
        else if (index == 5) pos = Raspolozhenie.Прав;

        if (pos == Raspolozhenie.Прав | pos == Raspolozhenie.Лев) {
            return Detales[(short)pos].KabelKanal;
        } else {
            return false;
        }
    }
    public bool OtvetkaTorcShpin(Raspolozhenie pos)
    {
            if (pos == Raspolozhenie.Верх | pos == Raspolozhenie.Ниж)
            {
                if (IsStoyka(pos))
                {
                    return Detales[(short)pos].OTS;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
    }
    public short TypeStoyki(Raspolozhenie pos)
    {
        return IsStoyka(pos) 
            ? Detales[(short)pos].Type 
            : (short) 0;
    }
}