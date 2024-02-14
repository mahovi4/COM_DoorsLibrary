using System.Collections.Generic;
using System.Linq;
using static DM;

internal delegate void MessageHandler(string message);

internal class Furniture
{
    internal event MessageHandler Error;
    internal event MessageHandler Problem;

    private readonly List<Zamok> _zamok = new List<Zamok>();
    private Zamok_Kodoviy _zamokKodoviy;
    private readonly List<Ruchka> _ruchkaAS = new List<Ruchka>();
    private readonly List<Ruchka> _ruchkaPS = new List<Ruchka>();
    private readonly List<Zadvizhka> _zadvizhka = new List<Zadvizhka>();
    private SdvigoviyZamok _sdvigoviy;
    private readonly List<Glazok> _glazok = new List<Glazok>();
    private readonly List<Protivos> _protivos = new List<Protivos>();
    private readonly List<TorcShpingalet> _torcShpingalet = new List<TorcShpingalet>();
    private readonly List<OtvAntipan> _otvetkiAntipan = new List<OtvAntipan>();
    private readonly List<Termoblockerator> _termoblockerator = new List<Termoblockerator>();

    private DMParam _param;
    private IniFile _iniDM;

    public Furniture()
    {
    }

    public void Calculate(ref DMParam param, ref Constants cons, ref IniFile iniDM, in StvorkaDM stvorka)
    {
        _param = param;
        _iniDM = iniDM;

        var koef90 = cons.CompareKod(param.Kod, "ДМ", "(70)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_90")) : (short)0;
        var koef62 = cons.ST62 & cons.CompareKod(param.Kod, "ДМ", "(62)") ? short.Parse(iniDM.ReadKey("Koef", "KOEF_62")) : (short)0;

        //Замки
        for (short i = 0; i <= 1; i++) {
            if (param.Zamok[i].Kod > 0) {
                var z = new Zamok(i, ref param, ref cons);
                _zamok.Add(z);
            }
        }

        //Замок кодовый
        if (param.Kodoviy.Type != Kodoviy.Нет)
        {
            _zamokKodoviy = new Zamok_Kodoviy(ref param, ref cons);
        }

        if (_zamokKodoviy != null && _zamok.Count > 0)
        {
            if (_zamok.Count > 1 || _zamok[0].OtPola > 1000)
                _zamokKodoviy.Move(-100);
        }

        if (Zamki.Length > 0)
        {
            if (Zamki[0].Kod == (int)ZamokNames.Просам_ЗВ_4 & param.RuchkaAS[0].Kod == (int)RuchkaNames.Ручка_черная_планка)
                param.RuchkaAS[0].Kod = (int)RuchkaNames.Ручка_Вега;
        }

        //Ручки
        for (short i = 0; i < 2; i++)
        {
            for (short y = 0; y < 2; y++)
            {
                if (param.IsRuchka(i, y))
                {
                    var r = new Ruchka(i, y, koef62, koef90, ref param, ref cons);
                    if (i == (short)Stvorka.Активная)
                        _ruchkaAS.Add(r);
                    else
                        _ruchkaPS.Add(r);
                }
            }
        }

        //Задвижки
        if (param.Zadvizhka.Kod > 0)
        {
            var z = new Zadvizhka(ref param, ref cons, ref iniDM);
            _zadvizhka.Add(z);
        }

        //Сдвиговый замок
        if(param.Sdvigoviy.Kod > 0)
        {
            _sdvigoviy = new SdvigoviyZamok(param.Sdvigoviy.Name, ref param, ref cons, ref iniDM, in stvorka);
        }

        //Глазки
        if (param.Glazok != null & param.Glazok.Length > 0)
        {
            for (short i = 0; i < param.Glazok.Length; i++)
            {
                Glazok g = new Glazok(i, ref param, ref cons);
                _glazok.Add(g);
            }
        }

        //Противосъемники
        if (param.Protivos > 0)
        {
            for (short i = 0; i < param.Protivos; i++)
            {
                Protivos p = new Protivos(i, ref param, ref cons, ref iniDM);
                _protivos.Add(p);
            }
        }

        //Торцевые шпингалеты
        if (param.TSpingalet & param.WAktiv.Value > 0d) {
            short count = 0;
            if (!(param.RuchkaPS[0].Kod == (short)RuchkaNames.PB_1300 |
                  param.RuchkaPS[0].Kod == (short)RuchkaNames.PB_1700A |
                  param.RuchkaPS[0].Kod == (short)RuchkaNames.PB_1700C |
                  param.RuchkaPS[0].Kod == (short)RuchkaNames.АП_DoorLock))
            {
                if (param.Porog.Kod == 2)
                    count = 1;
                else
                    count = 2;
            }
            for (short i=0; i < count; i++)
            {
                TorcShpingalet ts = new TorcShpingalet(i, ref param, ref cons, ref iniDM);
                _torcShpingalet.Add(ts);
            }
        }

        //Ответки под врезную антипанику в пассивной створке
        if (param.RuchkaPS[0].Kod == (short)RuchkaNames.PB_1300 | 
            param.RuchkaPS[0].Kod == (short)RuchkaNames.PB_1700A | 
            param.RuchkaPS[0].Kod == (short)RuchkaNames.АП_DoorLock)
        {
            short count;
            if (param.Porog.Kod == 2 | param.Porog.Kod == 0)
                count = 1;
            else
                count = 2;
            for (int i = 0; i < count; i++)
            {
                TorcShpingalet tsp = new TorcShpingalet(i, ref param, ref cons, ref iniDM);
                _otvetkiAntipan.Add(new OtvAntipan(tsp.Otvetka_OtKraya, tsp.Otvetka_Otstup, tsp.Otvetka_Diam));
            }
        }

        //Ответки термоблокераторов
        if (param.Termoblock)
        {
            _termoblockerator.Add(new Termoblockerator(0, ref param, ref cons, ref iniDM, in stvorka));
            if (param.Nalichniki[(int)Raspolozhenie.Ниж] > 0)
                _termoblockerator.Add(new Termoblockerator(0, ref param, ref cons, ref iniDM, in stvorka));
            else if(param.Porog.Kod > 5)
                _termoblockerator.Add(new Termoblockerator(1, ref param, ref cons, ref iniDM, in stvorka));
        }

        if (_ruchkaAS.Count > 0 && _zamok.Count > 0)
        {
            var rzCount = _ruchkaAS
                .Count(ruchka => ruchka.IsZamkovaya);
            if(rzCount > 1)
                OnProblem("Изделие укомплектовано несколькими замковыми ручками!");

            if (_ruchkaAS[0].IsZamkovaya)
            {
                if (!_zamok[0].Datas.Ruchka)
                    OnError($"Замок {_zamok[0].Name} не имеет защелки, но укомплектован замковой ручкой {_ruchkaAS[0].Name}!");
                else if (!_zamok[0].IsSovmestima(_ruchkaAS[0].Kod))
                    OnError($"Замок {_zamok[0].Name} не совместим с ручкой {_ruchkaAS[0].Name}!");
            }

            if (_ruchkaAS.Count > 1 && _zamok.Count > 1)
            {
                for (var i = 1; i < _ruchkaAS.Count; i++)
                {
                    if (!_ruchkaAS[i].IsZamkovaya) continue;

                    if (!_zamok[1].Datas.Ruchka)
                        OnError($"Замок {_zamok[1].Name} не имеет защелки, но укомплектован замковой ручкой {_ruchkaAS[i].Name}!");
                    else if (!_zamok[1].IsSovmestima(_ruchkaAS[i].Kod))
                        OnError($"Замок {_zamok[1].Name} не совместим с ручкой {_ruchkaAS[i].Name}!");
                }
            }
        }

    }

    private void OnError(string message)
    {
        Error?.Invoke(message);
    }

    private void OnProblem(string message)
    {
        Problem?.Invoke(message);
    }

    //-----Замки
    public ZamokDatas[] Zamki
    {
        get
        {
            List<ZamokDatas> zd = new List<ZamokDatas>();
            foreach (Zamok z in _zamok)
                if(z != null & z.Datas.Kod > 0)
                    zd.Add(z.Datas);
            return zd.ToArray();
        }
    }
    public ZamokDatas Zamok(short num)
    {
        if (IsZamok(num))
            return _zamok[num].Datas;
        else
            return new ZamokDatas();
    }
    public bool IsZamok(short num)
    {
        if (_zamok == null) return false;
        if(_zamok.Count > num)
            return _zamok[num] != null;
        return false;
    }
    public short Zamok_Index(short num)
    {
        if (IsZamok(num))
        {
            return _zamok[num].Index;
        }
        else
        {
            return 0;
        }
    }
    public string[] Zamok_VirezNames(short num)
    {
        string suf = "";
        if (num > 0)
            suf = " (верх)";
        string[] tmp = new string[_zamok[num].Datas.VirezNames.Count];
        for (int i = 0; i < _zamok[num].Datas.VirezNames.Count; i++)
            tmp[i] = _zamok[num].Datas.VirezNames[i] + suf;
        return tmp;
    }
    public string[] Zamok_SketchNames(short num)
    {
        string suf = "";
        if (num > 0)
            suf = " (верх)";
        string[] tmp = new string[_zamok[num].Datas.SketchNames.Count];
        for (int i = 0; i < _zamok[num].Datas.SketchNames.Count; i++)
            tmp[i] = _zamok[num].Datas.SketchNames[i] + suf;
        return tmp;
    }
    public string Zamok_Name(short num)
    {
            if (IsZamok(num))
            {
                return _zamok[num].Name;
            }
            else
            {
                return "";
            }
    }
    public double Zamok_OtKraya(short num, short pos)
    {
            if (pos == 0)
            {
                if (IsZamok(num))
                {
                    return _zamok[num].OtKrayaLA;
                }
                else
                {
                    return 0;
                }
            }
            else if (pos == 1)
            {
                if (IsZamok(num))
                {
                    return _zamok[num].OtKrayaVA;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (IsZamok(num))
                {
                    return _zamok[num].OtKrayaLP;
                }
                else
                {
                    return 0;
                }
            }
    }
    public double Zamok_OtTela(short num)
    {
        if (IsZamok(num))
        {
            if (_param.EIS) 
            {
                if (_param.WAktiv.Value > 0)
                    return _zamok[num].OtTelaVA - double.Parse(_iniDM.ReadKey("Furnitura", "DM_ZAMOK_K_EIS2"));
                else
                    return _zamok[num].OtTelaVA - double.Parse(_iniDM.ReadKey("Furnitura", "DM_ZAMOK_K_EIS1"));
            }
            else
                return _zamok[num].OtTelaVA;
        }
        else
        {
            return 0;
        }
    }
    public double Zamok_Otstup(short num, short typeStoyki)
    {
        if (IsZamok(num))
        {
            return _zamok[num].Otstup(typeStoyki);
        }
        else
        {
            return 0;
        }
    }
    public short Zamok_OtPola(short num)
    {
        if (IsZamok(num))
        {
            return _zamok[num].OtPola;
        }
        else
        {
            return 0;
        }
    }
    public double Zamok_Otvetka_OtPola(short num)
    {
        if (IsZamok(num))
        {
            return _zamok[num].OtvOtPola;
        }
        else
        {
            return 0;
        }
    }

    //-----Антипаника
    //public double Antipanika_OtLeftKrayaVA
    //{
    //    get
    //    {
    //        if (_zamok[0] == null)
    //        {
    //            return 0;
    //        }
    //        else
    //        {
    //            return _zamok[0].OtLeftKrayaVA;
    //        }
    //    }
    //}
    //public double Antipanika_OtLeftKrayaVP
    //{
    //    get
    //    {
    //        if (_zamok[0] == null)
    //        {
    //            return 0;
    //        }
    //        else
    //        {
    //            return _zamok[0].OtLeftKrayaVP;
    //        }
    //    }
    //}
    //public double Antipanika_OtRightKrayaVP
    //{
    //    get
    //    {
    //        if (_zamok[0] == null)
    //        {
    //            return 0;
    //        }
    //        else
    //        {
    //            return _zamok[0].OtRightKrayaVP;
    //        }
    //    }
    //}

    //-----Кодовый замок
    public bool IsKodoviy
    {
        get { return _zamokKodoviy != null; }
    }
    public double Kodoviy_OtShir
    {
        get
        {
            if (IsKodoviy)
            {
                return _zamokKodoviy.OtShir;
            }
            else
            {
                return 0;
            }
        }
    }
    public string Kodoviy_Name
    {
        get
        {
            if (IsKodoviy)
            {
                return _zamokKodoviy.Name;
            }
            else
            {
                return "";
            }
        }
    }
    public double Kodoviy_OtKraya(short pos)
    {
            if (IsKodoviy)
            {
                if (pos == 0)
                {
                    return _zamokKodoviy.OtKrayaLA;
                }
                else if (pos == 1)
                {
                    return _zamokKodoviy.OtKrayaVA;
                }
                else
                {
                    return _zamokKodoviy.OtKrayaLP;
                }
            }
            else
            {
                return 0;
            }
    }
    public double Kodoviy_OtTela
    {
        get
        {
            if (IsKodoviy)
            {
                return _zamokKodoviy.OtTelaVA;
            }
            else
            {
                return 0;
            }
        }
    }
    public short Kodoviy_OtPola
    {
        get
        {
            if (IsKodoviy)
            {
                return _zamokKodoviy.OtPola;
            }
            else
            {
                return 0;
            }
        }
    }
    public Kodoviy Kodoviy_Type
    {
        get
        {
            if (IsKodoviy)
            {
                return _zamokKodoviy.Kod;
            }
            else
            {
                return 0;
            }
        }
    }

    //-----Ручки
    public bool IsRuchka(short stvorka, short num)
    {
        List<Ruchka> ruchki;
        if (stvorka == (short)Stvorka.Активная)
            ruchki = _ruchkaAS;
        else
            ruchki = _ruchkaPS;
        if (ruchki != null)
        {
            if(ruchki.Count > num)
                return ruchki[num] != null;
            else
                return false;
        }
        else
            return false;
    }
    public bool ContainsRuchka(short kod)
    {
        return _ruchkaAS
            .Any(ruchka => ruchka.Kod == kod);
    }
    public Ruchka Ruchka(short stvorka, short num)
    {
        if (IsRuchka(stvorka, num))
        {
            if (stvorka == (int)Stvorka.Активная)
                return _ruchkaAS[num];
            else
                return _ruchkaPS[num];
        }
        else return null;
    }
    public short Ruchka_Kod(short stvorka, short num)
    {
        if (IsRuchka(stvorka, num))
        {
            if(stvorka == (short)Stvorka.Активная)
                return _ruchkaAS[num].Kod;
            else
                return _ruchkaPS[num].Kod;
        }
        else
            return 0;
    }
    public double Ruchka_OtKraya(short stvorka, short num, short pos)
    {
        if (IsRuchka(stvorka, num))
        {
            if(stvorka == (short)Stvorka.Активная)
                return _ruchkaAS[num].OtKraya(pos);
            else
                return _ruchkaPS[num].OtKraya(pos);
        }
        else
            return 0;
    }
    public double Ruchka_OtLeftKraya(short stvorka, short num, short pos)
    {
        return Ruchka(stvorka, num).OtLeftKraya(pos);
    }
    public short Ruchka_OtPola(short stvorka, short num)
    {
        if (IsRuchka(stvorka, num))
        {
            if(stvorka == (short)Stvorka.Активная)
                return _ruchkaAS[num].OtPola;
            else
                return _ruchkaPS[num].OtPola;
        }
        else
            return 0;
    }
    public short Ruchka_Mezhosevoe(short stvorka, short num)
    {
        if (IsRuchka(stvorka, num))
        { 
            if(stvorka == (short)Stvorka.Активная)
                return _ruchkaAS[num].Mezhosevoe;
            else
                return _ruchkaPS[num].Mezhosevoe;
        }
        else
            return 0;
    }
    public string Ruchka_VirezName(short stvorka, short num)
    {
        Ruchka r = Ruchka(stvorka, num);
        if (r != null)
            if (Zamok(0).Kod == (int)ZamokNames.ПП && r.Kod == (int)RuchkaNames.Ручка_фланец)
                return "DM_Ручка на фланце для ПП";
            else
                return r.VirezName;
        else
            return "_";
    }
    public string Ruchka_SketchName(short stvorka, short num)
    {
        Ruchka r = Ruchka(stvorka, num);
        if (r != null)
            if (Zamok(0).Kod == (int)ZamokNames.ПП && r.Kod == (int)RuchkaNames.Ручка_фланец)
                return "DM_Ручка_фланец_ПП";
            else
                return r.SketchName;
        else
            return "_";
    }
    public float APanOtNiza
    {
        get
        {
            if (IsRuchka((short)Stvorka.Пассивная, 0))
            {
                return _ruchkaPS[0].OtNiza;
            }
            else
                return 0;
        }
    }

    //-----Задвижки
    public bool IsZadvizhka(short num)
    {
        if (_zadvizhka != null)
        {
            if(_zadvizhka.Count > num)
                return _zadvizhka[num] != null;
            else
                return false;
        }
        else
            return false;
    }
    public short Zadvizhka_Kod(short num)
    {
        if (IsZadvizhka(num))
        {
            return _zadvizhka[num].Kod;
        }
        else
        {
            return 0;
        }
    }
    public double Zadvizhka_OtKpayaVA(short num)
    {
        if (IsZadvizhka(num))
        {
            return _zadvizhka[num].OtKrayaVA;
        }
        else
        {
            return 0;
        }
    }
    public double Zadvizhka_Vertushok_OtKraya(short num)
    {
        if (IsZadvizhka(num))
        {
            return _zadvizhka[num].VertushokOtKraya;
        }
        else
        {
            return 0;
        }
    }
    public double Zadvizhka_Otstup(short num, short stoykaType)
    {
        if (IsZadvizhka(num))
            return _zadvizhka[num].Otvetka_Otstup(stoykaType);
        else
            return 0;
    }
    public short Zadvizhka_OtPola(short num)
    {
        if (IsZadvizhka(num))
        {
            return _zadvizhka[0].OtPola;
        }
        else
        {
            return 0;
        }
    }

    //-----Сдвиговый замок
    public bool IsSdvigoviy()
    {
        return _sdvigoviy != null;
    }
    public SdvigoviyData Sdvigoviy => _sdvigoviy.Data;

    //-----Глазки
    public bool IsGlazok(short num)
    {
        if (_glazok != null)
        {
            if(_glazok.Count > num)
                return _glazok[num] != null;
            else
                return false;
        }
        else
            return false;
    }
    public GlazokRaspolozhenie Glazok_Raspolozhenie(short num)
    {
        if (IsGlazok(num))
        {
            return _glazok[num].Raspolozhenie;
        }
        else
        {
            return GlazokRaspolozhenie.По_центру;
        }
    }
    public short Glazok_OtPola(short num)
    {
        if (IsGlazok(num))
        {
            return _glazok[num].OtPola;
        }
        else
        {
            return 0;
        }
    }

    //-----Противосъемники
    public bool IsProtivos(short num)
{
        if (_protivos != null)
        {
            if (_protivos.Count > num)
                return _protivos[num] != null;
            else
                return false;
        }
        else
            return false;
    }
    public short Protivos_Count
    {
        get { return (short)_protivos.Count; }
    }
    public double Protivos_OtKraya
    {
        get
        {
            if (IsProtivos(0))
            {
                return _protivos[0].OtKraya;
            }
            else
            {
                return 0;
            }
        }
    }
    public short Protivos_OtPola(short num)
    {
        if (IsProtivos(num))
        {
            return _protivos[num].OtPola;
        }
        else
        {
            return 0;
        }
    }

    //-----Торцевые шпингалеты
    public bool IsTorcShpingalet(short num)
    {
        if (_torcShpingalet != null)
        {
            if (_torcShpingalet.Count > num)
                return _torcShpingalet[num] != null;
            else
                return false;
        }
        else
            return false;
    }
    public short TorcShpingalet_Count
    {
        get
        {
            return (short)_torcShpingalet.Count;
        }
    }
    public double TorcShpingalet_OtKraya
    {
        get
        {
            if (IsTorcShpingalet(0))
            {
                return _torcShpingalet[0].OtKraya;
            }
            else
            {
                return 0;
            }
        }
    }
    public double TorcShpingalet_Otvetka_Diam
    {
        get
        {
            if (IsTorcShpingalet(1))
                return _torcShpingalet[1].Otvetka_Diam;
            else
                return 0;
        }
    }
    public double TorcShpingalet_Otvetka_OtKraya
    {
        get
        {
            if (IsTorcShpingalet(0))
            {
                return _torcShpingalet[0].Otvetka_OtKraya;
            }
            else
            {
                return 0;
            }
        }
    }
    public double TorcShpingalet_Otvetka_Otstup(short i)
    {
        if (IsTorcShpingalet(i))
        {
            return _torcShpingalet[i].Otvetka_Otstup;
        }
        else
        {
            return 0;
        }
    }

    //-----Ответки под врезную антипанику в пассивной створке
    public bool IsOtvAntipan(short pos)
    {
        if (pos < _otvetkiAntipan.Count)
            return _otvetkiAntipan[pos] != null;
        else
            return false;
    }
    public double OtvAntipan_Diam(short pos)
    {
        if (IsOtvAntipan(pos))
            return _otvetkiAntipan[pos].Diam;
        else
            return 0;
    }
    public double OtvAntipan_OtKraya(short pos)
    {
        if (IsOtvAntipan(pos))
            return _otvetkiAntipan[pos].OtKraya;
        else
            return 0;
    }
    public double OtvAntipan_Otstup(short pos)
    {
        if (IsOtvAntipan(pos))
            return _otvetkiAntipan[pos].Otstup;
        else
            return 0;
    }

    //-----Ответки под термоблокераторы
    public bool IsTermoblock(short num)
    {
        if(_termoblockerator.Count > num)
            return _termoblockerator[num] != null;
        return false;
    }

    public TermoblockDatas GetTermoblock(short num)
    {
        return IsTermoblock(num) 
            ? _termoblockerator[num].Datas 
            : new TermoblockDatas();
    }
}
