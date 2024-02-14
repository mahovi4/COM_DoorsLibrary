using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using COM_DoorsLibrary;

[Guid("d1e4680f-ff6b-49a2-9ad7-802ad3b3b682")]
public interface ILM
{
    [DispId(1)]
    [Description("Производит расчет изделия.")]
    void Init(DMParam data);

    [DispId(2)]
    [Description("Возвращает номер соответствующей строки в таблице конструирования.")]
    int Row { get; }

    [DispId(3)]
    [Description("Возвращает номер изделия, присваеваемый изделию системой 1С.")]
    string Num { get ; }

    [DispId(4)]
    [Description("Возвращает список ошибок, возникших в процессе расчета (в противном случае - пустая строка).")]
    string Errors { get; set; }

    [DispId(5)]
    [Description("Возвращает список конструкционных проблем, возникших в процессе расчета (в противном случае - пустая строка).")]
    string Problems{get;set;}

    [DispId(6)]
    [Description("Возвращает цифровой код изделия.")]
    short Kod{get;}

    [DispId(7)]
    [Description("Возвращает высоту изделия.")]
    short Height{get;}

    [DispId(8)]
    [Description("Возвращает ширину изделия.")]
    short Width{get; }

    [DispId(9)]
    [Description("Возвращает сторону открывания изделия.")]
    Otkrivanie Otkrivanie { get; }

    [DispId(10)]
    [Description("Возвращает имя DXF-файла детали по ее индексу.")]
    string Name(short index);

    [DispId(11)]
    [Description("Возвращает наличие пассивной створки в изделии.")]
    bool IsPassivka{get;}

    [DispId(12)]
    [Description("Возвращает ширину створки изделия.")]
    short Stvorka_Width(Stvorka stvorka);

    [DispId(13)]
    [Description("Возвращает высоту лицевого листа изделия.")]
    short LicevoyList_Height{get;}

    [DispId(14)]
    [Description("Возвращает ширину лицевого листа изделия по его створке.")]
    short LicevoyList_Width(Stvorka stvorka);

    [DispId(15)]
    [Description("Возвращает высоту внутреннего листа изделия.")]
    short VnutrenniyList_Height{get;}

    [DispId(16)]
    [Description("Возвращает ширину внутреннего листа изделия по его створке.")]
    short VnutrenniyList_Width(Stvorka stvorka);

    [DispId(17)]
    [Description("Возвращает высоту стойки по ее расположению в изделии.")]
    short Stoyka_Height(Raspolozhenie pos);

    [DispId(18)]
    [Description("Возвращает ширину развертки стойки по ее расположению в изделии.")]
    double Stoyka_Razvertka(Raspolozhenie pos);

    [DispId(19)]
    [Description("Возвращает код замка изделия.")]
    short Zamok_Kod{get;}

    [DispId(20)]
    [Description("Возвращает код ручки изделия.")]
    short Ruchka_Kod{get;}

    [DispId(21)]
    [Description("Возвращает код задвижки изделия.")]
    short Zadvizhka_Kod{get;}

    [DispId(22)]
    [Description("Возвращает параметры замка изделия.")]
    ZamokDatas Zamok { get; }

    [DispId(23)]
    [Description("Возвращает параметры задвижки изделия.")]
    ZadvizhkaDatas Zadvizhka { get; }
}

[Guid("26672c67-22b6-447d-bdba-b84cfa6c6e1d"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
public interface IELM
{

}

[Guid("b46d7324-7cb5-4485-be4f-51388ec4db9e"), ClassInterface(ClassInterfaceType.None), ComSourceInterfaces(typeof(IELM))]
[Description("Класс расчета люков.")]
public class LM : ILM
{
    private short _WAktiv, _WPassiv, _HLL, _HVL, _WLLAS, _WVLAS, _WLLPS, _WVLPS, _HZPS, _HUDS, _protivos;
    private double _WZS, _WPS, _WUS, _WDS;
    private double _glubST, _glubPR;
    private short _koef62; //_stKoef62;
    private string _ERRORS, _PROBLEMS;
    private const short leftGib = 9, rightGib = 9, topGib = 9, bottomGib = 9;
    private double llThick = 1.2, vlThick = 1.2;

    private Zamok _zamok;
    private Ruchka _ruchka;
    private Zadvizhka _zadvizhka;

    private Constants cons = new Constants();
    private IniFile ini;
    private DMParam param;
    
    public void Init(TableData tdata)
    {
        Init(tdata.ForDM);
    }
    public void Init(DMParam data)
    {
        param = data;
        ini = new IniFile(cons.DIR_CONS_GLOBAL + "\\LM.ini");

        _koef62 = cons.CompareKod(param.Kod, "(62)") ? short.Parse(ini.ReadKey("LM", "LM_K_62")) : (short)0;
        //_stKoef62 = cons.CompareKod(param.Kod, "(62)") ? short.Parse(ini.ReadKey("LM", "LM_K_S_62")) : (short)0;

        llThick = data.Thick_LL;
        vlThick = data.Thick_VL;

        if (param.Height % 10 != 0)
            Errors = "Высота не кратна 10! ";
        if (param.Width % 10 != 0)
            Errors = "Ширина не кратна 10! ";
        if (param.Porog.Kod == 14 | param.Porog.Kod == 25 | param.Porog.Kod == 2)
            Errors = "Порог " + param.Porog + " у люка быть не может! ";
        if (param.WAktiv.Value.EqualsDouble(0))
        {
            _WAktiv = 0;
            _WPassiv = 0;
        }
        else
        {
            if (param.WAktiv.Value.EqualsDouble(1))
            {
                _WAktiv = (short)((Width - short.Parse(ini.ReadKey("LM", "LM_K_WSTV"))) / 2);
                _WPassiv = _WAktiv;
            }
            else
            {
                _WAktiv = (short)param.WAktiv.Value;
                _WPassiv = (short)(Width - _WAktiv - short.Parse(ini.ReadKey("LM", "LM_K_WSTV")));
            }
        }
        if (_WAktiv == 0)
        {
            _HLL = (short)(Height - short.Parse(ini.ReadKey("LM", "LM1_K_HLL")));
            _HVL = (short)(Height - short.Parse(ini.ReadKey("LM", "LM1_K_HVL")));
        }
        else
        {
            _HLL = (short)(Height - short.Parse(ini.ReadKey("LM", "LM2_K_HLL")));
            _HVL = (short)(Height - short.Parse(ini.ReadKey("LM", "LM2_K_HVL")));
        }
        if (_WAktiv == 0)
        {
            _WLLAS = (short)(Width - short.Parse(ini.ReadKey("LM", "LM1_K_WLL")));
            _WVLAS = (short)(Width + short.Parse(ini.ReadKey("LM", "LM1_K_WVL")) + (_koef62 * 2));
        }
        else
        {
            _WLLAS = (short)(_WAktiv + short.Parse(ini.ReadKey("LM", "LM2_K_AS_WLL")));
            _WVLAS = (short)(_WAktiv + short.Parse(ini.ReadKey("LM", "LM2_K_AS_WVL")) + (_koef62 * 2));
            _WLLPS = (short)(_WPassiv + short.Parse(ini.ReadKey("LM", "LM2_K_PS_WLL")) + _koef62);
            _WVLPS = (short)(_WPassiv + short.Parse(ini.ReadKey("LM", "LM2_K_PS_WVL")) + _koef62);
        }
        _HZPS = Height;
        _HUDS = (short)(Width - short.Parse(ini.ReadKey("LM", "LM_K_GSK")));

        if (param.Otkrivanie.Value == Otkrivanie.ЛевоеВО | param.Otkrivanie.Value == Otkrivanie.ПравоеВО)
            for (var i = 0; i < 4; i++) param.Nalichniki[i] = 0;

        var minNal = short.Parse(ini.ReadKey("LM", "LM_MIN_NAL"));
        for(var i=0; i<4; i++)
        {
            var tmp = "";
            switch (i)
            {
                case 0:
                    tmp = "Верхний";
                    break;
                case 1:
                    tmp = "Нижний";
                    break;
                case 2:
                    tmp = "Правый";
                    break;
                case 3:
                    tmp = "Левый";
                    break;
            }
            if (param.Nalichniki[i] > 0 & param.Nalichniki[i] < minNal)
                Errors = tmp + " наличник меньше " + minNal + " мм! ";
        }

        var razv = double.Parse(ini.ReadKey("LM", "LM_RAZV")) + (_koef62);
        switch (param.Otkrivanie.Value)
        {
            case Otkrivanie.Левое:
            {
                if (param.Nalichniki[2] > minNal)
                    _WZS = razv + param.Nalichniki[2];
                else
                    _WZS = razv + minNal;
                if (param.Nalichniki[3] > minNal)
                    _WPS = razv + param.Nalichniki[3];
                else
                    _WPS = razv + minNal;
                break;
            }
            case Otkrivanie.Правое:
            {
                if (param.Nalichniki[3] > minNal)
                    _WZS = razv + param.Nalichniki[3];
                else
                    _WZS = razv + minNal;
                if (param.Nalichniki[2] > minNal)
                    _WPS = razv + param.Nalichniki[2];
                else
                    _WPS = razv + minNal;
                break;
            }
            case Otkrivanie.ЛевоеВО:
            case Otkrivanie.ПравоеВО:
            default:
                _WZS = razv + minNal;
                _WPS = razv + minNal;
                break;
        }

        if (param.Nalichniki[0] > minNal)
            _WUS = razv + param.Nalichniki[0];
        else
            _WUS = razv + minNal;
        if (param.Nalichniki[1] > minNal)
            _WDS = razv + param.Nalichniki[1];
        else
            _WDS = razv + minNal;

        _glubST = double.Parse(ini.ReadKey("LM", "LM_ST_V_GLUB")) + _koef62;
        _glubPR = double.Parse(ini.ReadKey("LM", "LM_ST_G_GLUB")) + _koef62;
        
        if(param.Zamok[0].Kod > 0)
            _zamok = new Zamok(0, ref param, ref cons);
        _protivos = (short)(short.Parse(ini.ReadKey("LM", "LM_PROTIVOS")) + _koef62 / 2);

        if (param.RuchkaAS.Length > 0 && param.RuchkaAS[0].Kod > 0)
            _ruchka = new Ruchka((short) Stvorka.Активная, 0, _koef62, 0, ref param, ref cons);

        if (param.Zadvizhka.Kod > 0)
            _zadvizhka = new Zadvizhka(ref param, ref cons, ref ini);

        CheckForProblems();
    }

    private void CheckForProblems()
    {
        if (_zamok != null)
        {
            if (!_zamok.Datas.Suvald & !_zamok.Datas.CM)
                Problems = "Замок без пробивки под цилиндр! ";
            if (_ruchka != null)
            {
                if (!_zamok.Datas.Ruchka & _ruchka.IsZamkovaya)
                    Errors = $"Замок без защелки {_zamok.Name} укомплектован замковой ручкой {_ruchka.Name}! ";
                if(_zamok.Datas.Ruchka & _ruchka.IsZamkovaya & !_zamok.IsSovmestima(_ruchka.Kod))
                    Errors = $"Замок {_zamok.Name} не совместим с ручкой {_ruchka.Name}! ";
            }
            if (_zamok.Datas.Ruchka && (_ruchka == null || !_ruchka.IsZamkovaya))
                Problems = $"Замок с защелкой {_zamok.Name} не укомплектован замковой ручкой! ";
        }
        //if (cons.CompareKod(param.Kod, "ЛМ-1") & param.Width > 1170)
        //    Problems = "Люк шире чем 1170! Будет со швом! ";
        if(_HVL > (cons.LIST_WIDTH))
        {
            if (_WVLAS > (cons.LIST_WIDTH))
                Problems = "Развертка внутреннего листа активки не влезает в лист! ";
            if (_WVLPS > (cons.LIST_WIDTH))
                Problems = "Развертка внутреннего листа пассивной не влезает в лист! ";
        }
    }

    public int Row => param.Row;
    public short AppRow => param.AppRow;
    public string Num => param.Num;
    public string Errors
    {
        get => _ERRORS;
        set => _ERRORS += value;
    }
    public string Problems
    {
        get => _PROBLEMS;
        set => _PROBLEMS += value;
    }
    public short Kod => param.Kod;
    public short Height => param.Height;
    public short Width => param.Width;
    public Otkrivanie Otkrivanie => 
        param.Otkrivanie.Value;
    public string Name(short index)
    {
        string _name;
        if (_WAktiv == 0)
            _name = "ЛМ1";
        else
            _name = "ЛМ2";
        if (_koef62 > 0)
            _name += "_(СТ62)";
        else
            _name += "_(СТ53)";

        return index == 1 
            ? _name + "_P_" + param.Num 
            : _name + "_K_" + param.Num;
    }
    public bool IsPassivka => _WPassiv > 0;
    public short Stvorka_Width(Stvorka stvorka)
    {
        return stvorka == Stvorka.Активная 
            ? _WAktiv 
            : _WPassiv;
    }
    public short LicevoyList_Height => 
        llThick.EqualsDouble(2) 
                ? (short)(_HLL + 2) 
                : _HLL;
    public short LicevoyList_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
            return llThick.EqualsDouble(2) 
                ? (short)(_WLLAS + 2) 
                : _WLLAS;
        return llThick.EqualsDouble(2) 
            ? (short)(_WLLPS + 2) 
            : _WLLPS;
    }
    public short VnutrenniyList_Height => _HVL;
    public short VnutrenniyList_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
            return vlThick.EqualsDouble(2) 
                ? (short)(_WVLAS - 4) 
                : _WVLAS; 

        return vlThick.EqualsDouble(2) 
            ? (short)(_WVLPS - 4) 
            : _WVLPS;
    }

    public short GetGib(Raspolozhenie side)
    {
        switch (side)
        {
            case Raspolozhenie.Лев:
                return llThick.EqualsDouble(2) 
                    ? (short)(leftGib + 1) 
                    : leftGib;
            case Raspolozhenie.Прав:
                return llThick.EqualsDouble(2)
                    ? (short)(rightGib + 1)
                    : rightGib;
            case Raspolozhenie.Верх:
                return llThick.EqualsDouble(2)
                    ? (short)(topGib + 1)
                    : topGib;
            case Raspolozhenie.Ниж:
                return llThick.EqualsDouble(2)
                    ? (short)(bottomGib + 1)
                    : bottomGib;
            default:
                throw new ArgumentOutOfRangeException(nameof(side), side, null);
        }
    }

    public short Stoyka_Height(Raspolozhenie pos)
    {
            return pos == Raspolozhenie.Лев | pos == Raspolozhenie.Прав 
                ? _HZPS 
                : _HUDS;
    }
    public double Stoyka_Razvertka(Raspolozhenie pos)
    {
        switch (pos)
        {
            case Raspolozhenie.Верх:
                return _WUS;
            case Raspolozhenie.Ниж:
                return _WDS;
            case Raspolozhenie.Лев:
                return _WZS;
            case Raspolozhenie.Прав:
            default:
                return _WPS;
        }
    }
    public double Stoyka_Glubina(Raspolozhenie pos)
    {
        return pos == Raspolozhenie.Верх | pos == Raspolozhenie.Ниж
            ? _glubPR
            : _glubST;
    }
    public short Zamok_Kod => _zamok?.Datas.Kod ?? (short)0;
    public short Ruchka_Kod => _ruchka?.Kod ?? (short)0;
    public short Zadvizhka_Kod => _zadvizhka?.Kod ?? (short)0; 
    public ZamokDatas Zamok => _zamok.Datas;
    public short Protivos_OtKraya => _protivos;
    public ZadvizhkaDatas Zadvizhka => _zadvizhka.Datas;
    public double Zadvizhka_Vertushok_OtKraya
    {
        get
        {
            if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
                return LicevoyList_Width(Stvorka.Активная) + VnutrenniyList_Width(Stvorka.Активная) + 100 - _zadvizhka.VertushokOtKraya;
            return LicevoyList_Width(Stvorka.Активная) - _zadvizhka.VertushokOtKraya;
        }
    }

    public double Zadvizhka_Otstup => 
        _zadvizhka.Otvetka_Otstup(2);

    public double Zadvizhka_OtCentra
    {
        get
        {
            if (_zamok is null || _zamok.Datas.Kod == 0)
                return 0.001;
            return 250;
        }
    }
}
