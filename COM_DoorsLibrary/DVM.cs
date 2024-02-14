using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

[Guid("8320e458-76cb-4a84-ab8e-bfb67a0d982c")]
public interface IDVM
{
    [DispId(1)]
    [Description("Производит расчет изделия.")]
    void Init(DVMParam data);

    [DispId(2)]
    [Description("Производит проверку на отсутствие доборов в изделии.")]
    bool NulDobors{get;}

    [DispId(3)]
    [Description("Возвращает список ошибок, возникших в процессе расчета (в противном случае - пустая строка).")]
    string Errors{get;}

    [DispId(4)]
    [Description("Возвращает список конструкционных проблем, возникших в процессе расчета (в противном случае - пустая строка).")]
    string Problems {get;}

    [DispId(5)]
    [Description("Возвращает номер соответствующей строки в таблице конструирования.")]
    int Row {get;}

    [DispId(6)]
    [Description("Возвращает номер изделия, присваеваемый изделию системой 1С.")]
    string Num {get;}

    [DispId(7)]
    [Description("Возвращает имя DXF-файла детали по ее индексу.")]
    string Name(short conf);

    [DispId(8)]
    [Description("Возвращает высоту изделия.")]
    short Height {get;}

    [DispId(9)]
    [Description("Возвращает ширину изделия.")]
    short Width {get;}

    [DispId(10)]
    [Description("Производит проверку на наличие пассивной створки в изделии.")]
    bool IsPassivka {get;}

    [DispId(11)]
    [Description("Возвращает высоту створки по ее расположению в изделии.")]
    short Stvorka_Height(Stvorka stvorka);

    [DispId(12)]
    [Description("Возвращает ширину створки по ее расположению в изделии.")]
    short Stvorka_Width(Stvorka stvorka);

    [DispId(13)]
    [Description("Возвращает высоту лицевого листа изделия по его расположению.")]
    short LicevoyList_Height(Stvorka stvorka);

    [DispId(14)]
    [Description("Возвращает ширину лицевого листа изделия по его расположению.")]
    short LicevoyList_Width(Stvorka stvorka);

    [DispId(15)]
    [Description("Возвращает высоту внутреннего листа изделия по его расположению.")]
    short VnutrenniyList_Height(Stvorka stvorka);

    [DispId(16)]
    [Description("Возвращает ширину внутреннего листа изделия по его расположению.")]
    short VnutrenniyList_Width(Stvorka stvorka);

    [DispId(17)]
    [Description("Возвращает отступ лицевого листа изделия от пола.")]
    short LicevoyList_OtPola {get;}

    [DispId(18)]
    [Description("Возвращает отступ внутреннего листа изделия от пола.")]
    short VnutrenniyList_OtPola {get;}

    [DispId(19)]
    [Description("Производит проверку на наличие хотябы одного добора в изделии.")]
    bool IsEnyDobor {get;}

    [DispId(20)]
    [Description("Производит проверку на наличие вертикального добора лицевого листа по его расположению в изделии.")]
    bool LicList_IsVertDobor(Stvorka stvorka);

    [DispId(21)]
    [Description("Возвращает высоту вертикального добора лицевого листа по его расположению в изделии.")]
    short LicList_VertDobor_Height(Stvorka stvorka);

    [DispId(22)]
    [Description("Возвращает ширину вертикального добора лицевого листа по его расположению в изделии.")]
    short LicList_VertDobor_Width(Stvorka stvorka);

    [DispId(23)]
    [Description("Производит проверку на наличие горизонтального добора лицевого листа по его расположению в изделии.")]
    bool LicList_IsGorDobor(Stvorka stvorka);

    [DispId(24)]
    [Description("Возвращает высоту горизонтального добора лицевого листа по его расположению в изделии.")]
    short LicList_GorDobor_Height(Stvorka stvorka);

    [DispId(25)]
    [Description("Возвращает ширину горизонтального добора лицевого листа по его расположению в изделии.")]
    short LicList_GorDobor_Width(Stvorka stvorka);

    [DispId(26)]
    [Description("Производит проверку на наличие добавочного добора лицевого листа по его расположению в изделии.")]
    bool LicList_IsDopDobor(Stvorka stvorka);

    [DispId(27)]
    [Description("Возвращает высоту добавочного добора лицевого листа по его расположению в изделии.")]
    short LicList_DopDobor_Height(Stvorka stvorka);

    [DispId(28)]
    [Description("Возвращает ширину добавочного добора лицевого листа по его расположению в изделии.")]
    short LicList_DopDobor_Width(Stvorka stvorka);

    [DispId(29)]
    [Description("Производит проверку на наличие вертикального добора внутреннего листа по его расположению в изделии.")]
    bool VnutList_IsVertDobor(Stvorka stvorka);

    [DispId(30)]
    [Description("Возвращает высоту вертикального добора внутреннего листа по его расположению в изделии.")]
    short VnutList_VertDobor_Height(Stvorka stvorka);

    [DispId(31)]
    [Description("Возвращает ширину вертикального добора внутреннего листа по его расположению в изделии.")]
    short VnutList_VertDobor_Width(Stvorka stvorka);

    [DispId(32)]
    [Description("Производит проверку на наличие горизонтального добора внутреннего листа по его расположению в изделии.")]
    bool VnutList_IsGorDobor(Stvorka stvorka);

    [DispId(33)]
    [Description("Возвращает высоту горизонтального добора внутреннего листа по его расположению в изделии.")]
    short VnutList_GorDobor_Height(Stvorka stvorka);

    [DispId(34)]
    [Description("Возвращает ширину горизонтального добора внутреннего листа по его расположению в изделии.")]
    short VnutList_GorDobor_Width(Stvorka stvorka);

    [DispId(35)]
    [Description("Производит проверку на наличие добавочного добора внутреннего листа по его расположению в изделии.")]
    bool VnutList_IsDopDobor(Stvorka stvorka);

    [DispId(36)]
    [Description("Возвращает высоту добавочного добора внутреннего листа по его расположению в изделии.")]
    short VnutList_DopDobor_Height(Stvorka stvorka);

    [DispId(37)]
    [Description("Возвращает ширину добавочного добора внутреннего листа по его расположению в изделии.")]
    short VnutList_DopDobor_Width(Stvorka stvorka);

    [DispId(38)]
    [Description("Возвращает высоту вертикального профиля створки изделия.")]
    short VertProf_Height {get;}

    [DispId(39)]
    [Description("Возвращает высоту добора вертикального профиля створки изделия.")]
    short VertProf_Dobor_Height {get;}

    [DispId(40)]
    [Description("Возвращает отступ вертикального профиля створки изделия от пола.")]
    short VertProf_OtPola {get;}

    [DispId(41)]
    [Description("Возвращает длину горизонтального профиля створки изделия по его разположению.")]
    short GorProf_Height(Stvorka stvorka);

    [DispId(42)]
    [Description("Возвращает длину добора горизонтального профиля створки изделия по его разположению.")]
    short GorProf_Dobor_Height(Stvorka stvorka);

    [DispId(43)]
    [Description("Возвращает высоту вертикальной стойки коробки изделия.")]
    short Stoyka_Height {get;}

    [DispId(44)]
    [Description("Возвращает высоту добора вертикальной стойки коробки изделия.")]
    short Stoyka_Dobor_Height {get;}

    [DispId(45)]
    [Description("Возвращает длину притолоки коробки изделия.")]
    short Pritoloka_Height { get; }

    [DispId(46)]
    [Description("Возвращает длину добора притолоки коробки изделия.")]
    short Pritoloka_Dobor_Height { get; }

    [DispId(47)]
    [Description("Производит проверку на наличие порога в изделии.")]
    bool IsPorog {get;}

    [DispId(48)]
    [Description("Возвращает длину порога коробки изделия.")]
    short Porog_Height {get;}

    [DispId(49)]
    [Description("Возвращает длину добора порога коробки изделия.")]
    short Porog_Dobor_Height { get; }

    [DispId(50)]
    [Description("Возвращает развертку порога коробки изделия.")]
    short Porog_Razvertka {get;}

    [DispId(51)]
    [Description("Возвращает отступ анкера от края порога коробки изделия.")]
    double Porog_Anker {get;}

    [DispId(52)]
    [Description("Возвращает высоту выреза по порогу в стойках коробки изделия.")]
    short Porog_Virez_Height { get; }

    [DispId(53)]
    [Description("Возвращает код порога коробки изделия.")]
    short Porog_Num { get; }

    [DispId(54)]
    [Description("Производит проверку разборная ли коробки изделия.")]
    bool Korobka_IsRazbornaya {get;}

    [DispId(55)]
    [Description("Производит проверку наличия калитки в изделии.")]
    bool IsKalitka { get; }

    [DispId(56)]
    [Description("Возвращает высоту калитки в изделии.")]
    short Kalitka_Height { get; }

    [DispId(57)]
    [Description("Возвращает ширину калитки в изделии.")]
    short Kalitka_Width {get;}

    [DispId(58)]
    [Description("Возвращает отступ калитки в изделии от пола.")]
    short Kalitka_OtPola {get;}

    [DispId(59)]
    [Description("Возвращает отступ калитки в изделии от замкового профиля створки.")]
    short Kalitka_OtZamkovogoProf {get;}

    [DispId(60)]
    [Description("Возвращает высоту лицевого листа калитки в изделии.")]
    short Kalitka_LicList_Hight {get;}

    [DispId(61)]
    [Description("Возвращает высоту внутреннего листа калитки в изделии.")]
    short Kalitka_VnutList_Hight {get;}

    [DispId(62)]
    [Description("Возвращает ширину лицевого листа калитки в изделии.")]
    short Kalitka_LicList_Width {get;}

    [DispId(63)]
    [Description("Возвращает ширину внутреннего листа калитки в изделии.")]
    short Kalitka_VnutList_Width {get;}

    [DispId(64)]
    [Description("Возвращает длину вертикального профиля калитки в изделии.")]
    short Kalitka_VertProf { get; }

    [DispId(65)]
    [Description("Возвращает отступ вертикального профиля калитки в изделии от пола.")]
    short Kalitka_VertProf_OtPola {get;}

    [DispId(66)]
    [Description("Возвращает длину горизонтального профиля калитки в изделии.")]
    short Kalitka_GorProf {get;}

    [DispId(67)]
    [Description("Возвращает длину вертикального профиля обрамления калитки в створке изделии.")]
    short Kalitka_Obramlenie_VertProf { get; }

    [DispId(68)]
    [Description("Возвращает длину горизонтального профиля обрамления калитки в створке изделии.")]
    short Kalitka_Obramlenie_GorProf { get; }

    [DispId(69)]
    [Description("Возвращает отступ лицевого листа калитки в изделии от пола.")]
    short Kalitka_LicList_OtPola {get;}

    [DispId(70)]
    [Description("Возвращает отступ внутреннего листа калитки в изделии от пола.")]
    short Kalitka_VnutList_OtPola { get; }

    [DispId(71)]
    [Description("Возвращает высоту выреза под калитку на лицевом листе створки изделия.")]
    short Kalitka_LicList_Virez_Height { get; }

    [DispId(72)]
    [Description("Возвращает ширину выреза под калитку на лицевом листе створки изделия.")]
    short Kalitka_LicList_Virez_Width { get; }

    [DispId(73)]
    [Description("Возвращает высоту выреза под калитку на внутреннем листе створки изделия.")]
    short Kalitka_VnutList_Virez_Height { get; }

    [DispId(74)]
    [Description("Возвращает ширину выреза под калитку на внутреннем листе створки изделия.")]
    short Kalitka_VnutList_Virez_Width {get;}

    [DispId(75)]
    [Description("Возвращает отступ выреза под калитку на лицевом листе створки изделия от пола.")]
    short Kalitka_LicList_VIrez_OtPola { get; }

    [DispId(76)]
    [Description("Возвращает отступ выреза под калитку на лицевом листе створки изделия от замкового профиля.")]
    short Kalitka_LicList_VIrez_OtZamkProf { get; }

    [DispId(77)]
    [Description("Возвращает отступ выреза под калитку на внутреннем листе створки изделия от пола.")]
    short Kalitka_VnutList_VIrez_OtPola {get;}

    [DispId(78)]
    [Description("Возвращает отступ выреза под калитку на внутреннем листе створки изделия от замкового профиля.")]
    short Kalitka_VnutList_VIrez_OtZamkProf { get; }

    [DispId(79)]
    [Description("Возвращает код замка в изделии.")]
    short Zamok { get; }

    [DispId(80)]
    [Description("Возвращает код задвижки в изделии.")]
    short Zadvizhka { get; }
}

[Guid("4e5e3295-6660-4edb-bf88-1c694c918eab"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
public interface IEDVM
{

}

[Guid("e550002b-938c-4ada-833b-c2c1366d0b67"), ClassInterface(ClassInterfaceType.None), ComSourceInterfaces(typeof(IEDVM))]
[Description("Класс расчета доборных ворот.")]
public class DVM : IDVM
{
    private short _height, _width, torcShpinOtKraya;

    internal StvorkaDVM AktivStvorka;
    internal StvorkaDVM PassivStvorka;
    internal KorobkaDVM Korobka;
    internal KalitkaDVM Kalitka;

    private string _name;

    private Constants cons;
    private IniFile ini;
    private DVMParam param;

    public void Init(TableData tData)
    {
        Init(tData.ForDVM);
    }
    public void Init(DVMParam data)
    {
        param = data;
        cons = new Constants();
        ini = new IniFile(cons.DIR_CONS_GLOBAL + "\\DVM.ini");

        _height = param.Height;
        _width = param.Width;
        if (param.WAktiv.Value == 0d)
        {
            AktivStvorka = new StvorkaDVM(ref param, Stvorka.Активная, ref cons, ref ini);
        }
        else
        {
            AktivStvorka = new StvorkaDVM(ref param, Stvorka.Активная, ref cons, ref ini);
            PassivStvorka = new StvorkaDVM(ref param, Stvorka.Пассивная, ref cons, ref ini);
        }
        if (param.WAktiv.Value != 0d)
        {
            if (AktivStvorka.IsVertDoborLicLista & !PassivStvorka.IsVertDoborLicLista)
            {
                PassivStvorka.AddVertDoborLicLista(AktivStvorka.VertDoborLicLista_Width);
            }
            else if (!AktivStvorka.IsVertDoborLicLista & PassivStvorka.IsVertDoborLicLista)
            {
                AktivStvorka.AddVertDoborLicLista(PassivStvorka.VertDoborLicLista_Width);
            }
            if (AktivStvorka.IsVertDoborVnutLista & !PassivStvorka.IsVertDoborVnutLista)
            {
                PassivStvorka.AddVertDoborVnutLista(AktivStvorka.VertDoborVnutLista_Width);
            }
            else if (!AktivStvorka.IsVertDoborVnutLista & PassivStvorka.IsVertDoborVnutLista)
            {
                AktivStvorka.AddVertDoborVnutLista(PassivStvorka.VertDoborVnutLista_Width);
            }
        }
        Korobka = new KorobkaDVM(ref param, ref cons, ref ini);
        if (param.Zadvizhka.Kod == 404)
        {
            switch (param.Porog.Kod)
            {
                case 40:
                case 0:
                    torcShpinOtKraya = short.Parse(ini.ReadKey("DVM", "DVM_TSHPIN_40"));
                    break;
                default:
                    torcShpinOtKraya = short.Parse(ini.ReadKey("DVM", "DVM_TSHPIN"));
                    break;
            }
        }
        if (param.Kalit)
        {
            Kalitka = new KalitkaDVM(ref param, ref ini);
        }
        if (param.Kalit)
        {
            _name = "ВМк_(ST63)_";
        }
        else
        {
            if (param.WAktiv.Value == 0d)
            {
                _name = "ВМ1_(ST63)_";
            }
            else
            {
                _name = "ВМ2_(ST63)_";
            }
        }
    }

    public bool NulDobors
    {
        get
        {
            if (AktivStvorka.IsVertDoborLicLista & AktivStvorka.IsVertDoborVnutLista & AktivStvorka.IsGorDoborLicLista & AktivStvorka.IsGorDoborVnutLista)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    public string Errors
    {
        get
        {
            string tmp = "";
            if (param.Height % 10 != 0)
                tmp += "Высота не кратна 10! ";
            if (param.Width % 10 != 0)
                tmp += "Ширина не кратна 10! ";
            if (IsKalitka)
            {
                if ((AktivStvorka.Height - (Kalitka.VIrezVnutList_OtPola - AktivStvorka.VnutListOtPola) - 60) < Kalitka.VirezVnutList_Height)
                {
                    tmp += "Калитка по высоте не вмещается в створку! ";
                }
            }
            return tmp;
        }
    }
    public string Problems
    {
        get
        {
            string tmp;
            tmp = "";
            if (param.Zadvizhka.Kod == 404)
            {
                tmp += " Торцевые шпингалеты в воротах!";
                if (param.Height > 2480)
                {
                    tmp += " При этой высоте шпингалеты не целесообразны!";
                }
            }
            if (param.Zamok[0].Kod == 2)
            {
                tmp += "Замок без пробивки под цилиндр! ";
            }
            else if (param.Zamok[1].Kod == 20)
            {
                tmp += "Замок без пробивки под ручки! ";
            }
            return tmp;
        }
    }
    public int Row
    {
        get { return param.Row; }
    }
    public short AppRow
    {
        get { return param.AppRow; }
    }
    public string Num
    {
        get { return param.Num; }
    }
    public string Name(short conf)
    {
        if (conf == 1)
        {
            return _name + "P_" + param.Num;
        }
        else if (conf == 2)
        {
            return _name + "K_" + param.Num;
        }
        else
        {
            return _name + "D_" + param.Num;
        }
    }
    public short Height
    {
        get { return _height; }
    }
    public short Width
    {
        get { return _width; }
    }
    public short TorcSpingalet_OtKpaya
    {
        get { return torcShpinOtKraya; }
    }
    public bool IsPassivka
    {
        get { return PassivStvorka != null; }
    }
    public short Stvorka_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.Height;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public short Stvorka_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.Width;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public short LicevoyList_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.LicList_Height;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.LicList_Height;
            }
            else
            {
                return 0;
             }
        }
    }
    public short LicevoyList_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.LicList_Width;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.LicList_Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public short VnutrenniyList_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.VnutList_Height;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.VnutList_Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public short VnutrenniyList_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.VnutList_Width;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.VnutList_Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public short LicevoyList_OtPola
    {
        get { return AktivStvorka.LicListOtPola; }
    }
    public short VnutrenniyList_OtPola
    {
        get { return AktivStvorka.VnutListOtPola; }
    }
    public bool IsEnyDobor
    {
        get
        {
            if (LicList_IsGorDobor(Stvorka.Активная) | LicList_IsVertDobor(Stvorka.Активная) | LicList_IsGorDobor(Stvorka.Пассивная) | LicList_IsVertDobor(Stvorka.Пассивная))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool LicList_IsVertDobor(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.IsVertDoborLicLista;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.IsVertDoborLicLista;
            }
            else
            {
                return false;
            }
        }
    }
    public short LicList_VertDobor_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.VertDoborLicLista_Height;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.VertDoborLicLista_Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public short LicList_VertDobor_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.VertDoborLicLista_Width;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.VertDoborLicLista_Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public bool LicList_IsGorDobor(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.IsGorDoborLicLista;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.IsGorDoborLicLista;
            }
            else
            {
                return false;
            }
        }
    }
    public short LicList_GorDobor_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.GorDoborLicLista_Height;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.GorDoborLicLista_Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public short LicList_GorDobor_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.GorDoborLicLista_Width;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.GorDoborLicLista_Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public bool LicList_IsDopDobor(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.IsDopDoborLicLista;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.IsDopDoborLicLista;
            }
            else
            {
                return false;
            }
        }
    }
    public short LicList_DopDobor_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.DopDoborLicLista_Height;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.DopDoborLicLista_Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public short LicList_DopDobor_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.DopDoborLicLista_Width;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.DopDoborLicLista_Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public bool VnutList_IsVertDobor(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.IsVertDoborVnutLista;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.IsVertDoborVnutLista;
            }
            else
            {
                return false;
            }
        }
    }
    public short VnutList_VertDobor_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.VertDoborVnutLista_Height;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.VertDoborVnutLista_Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public short VnutList_VertDobor_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.VertDoborVnutLista_Width;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.VertDoborVnutLista_Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public bool VnutList_IsGorDobor(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.IsGorDoborVnutLista;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.IsGorDoborVnutLista;
            }
            else
            {
                return false;
            }
        }
    }
    public short VnutList_GorDobor_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.GorDoborVnutLista_Height;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.GorDoborVnutLista_Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public short VnutList_GorDobor_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.GorDoborVnutLista_Width;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.GorDoborVnutLista_Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public bool VnutList_IsDopDobor(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.IsDopDoborVnutLista;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.IsDopDoborVnutLista;
            }
            else
            {
                return false;
            }
        }
    }
    public short VnutList_DopDobor_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.DopDoborVnutLista_Height;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.DopDoborVnutLista_Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public short VnutList_DopDobor_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.DopDoborVnutLista_Width;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.DopDoborVnutLista_Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public short VertProf_Height
    {
        get { return AktivStvorka.VertProf; }
    }
    public short VertProf_Dobor_Height
    {
        get { return AktivStvorka.VertProfDobor; }
    }
    public short VertProf_OtPola
    {
        get { return (short)(VnutrenniyList_OtPola + 1); }
    }
    public short GorProf_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.GorProf;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.GorProf;
            }
            else
            {
                return 0;
            }
        }
    }
    public short GorProf_Dobor_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return AktivStvorka.GorProfDobor;
        }
        else
        {
            if (IsPassivka)
            {
                return PassivStvorka.GorProfDobor;
            }
            else
            {
                return 0;
            }
        }
    }
    public short Stoyka_Height
    {
        get { return Korobka.Stoyka_Height; }
    }
    public short Stoyka_Dobor_Height
    {
        get { return Korobka.Stoyka_DoborHeight; }
    }
    public short Pritoloka_Height
    {
        get { return Korobka.Pritoloka_Height; }
    }
    public short Pritoloka_Dobor_Height
    {
        get { return Korobka.Pritoloka_DoborHeight; }
    }
    public bool IsPorog
    {
        get { return Korobka.IsPorog; }
    }
    public short Porog_Height
    {
        get {
            if (IsPorog) return Korobka.Porog_Height;
            else return 0;
        }
    }
    public short Porog_Dobor_Height
    {
        get {
            if (IsPorog) return Korobka.Porog_DoborHeight;
            else return 0;
        }
    }
    public short Porog_Razvertka
    {
        get { if (IsPorog)
                return Korobka.Porog_Razvertka;
            else
                return 0; }
    }
    public double Porog_Anker
    {
        get { if (IsPorog)
                return Korobka.Porog_Anker;
            else
                return 0; }
    }
    public short Porog_Virez_Height
    {
        get { if (IsPorog)
                return Korobka.Porog_VirezHeight;
            else
                return 0; }
    }
    public short Porog_Num
    {
        get { if (IsPorog)
                return Korobka.Porog_Num;
            else
                return 0; }
    }
    public bool Korobka_IsRazbornaya
    {
        get { return Korobka.IsRazbornaya; }
    }
    public bool IsKalitka
    {
        get { return Kalitka != null; }
    }
    public short Kalitka_Height
    {
        get
        {
            if (IsKalitka)
                return Kalitka.Height;
            else
                return 0;
        }
    }
    public short Kalitka_Width
    {
        get
        {
            if (IsKalitka)
                return Kalitka.Width;
            else
                return 0;
        }
    }
    public short Kalitka_OtPola
    {
        get
        {
            if (IsKalitka)
                return Kalitka.OtPola;
            else
                return 0;
        }
    }
    public short Kalitka_OtZamkovogoProf
    {
        get
        {
            if (IsKalitka)
                return Kalitka.OtZamkovogoProf;
            else
                return 0;
        }
    }
    public short Kalitka_LicList_Hight
    {
        get
        {
            if (IsKalitka)
                return Kalitka.LicList_Hight;
            else
                return 0;
        }
    }
    public short Kalitka_VnutList_Hight
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VnutList_Hight;
            else
                return 0;
        }
    }
    public short Kalitka_LicList_Width
    {
        get
        {
            if (IsKalitka)
                return Kalitka.LicList_Width;
            else
                return 0;
        }
    }
    public short Kalitka_VnutList_Width
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VnutList_Width;
            else
                return 0;
        }
    }
    public short Kalitka_VertProf
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VertProf;
            else
                return 0;
        }
    }
    public short Kalitka_VertProf_OtPola
    {
        get { return (short)(Kalitka.OtPola + 9); }
    }
    public short Kalitka_GorProf
    {
        get
        {
            if (IsKalitka)
                return Kalitka.GorProf;
            else
                return 0;
        }
    }
    public short Kalitka_Obramlenie_VertProf
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VertProfObramleniya;
            else
                return 0;
        }
    }
    public short Kalitka_Obramlenie_GorProf
    {
        get
        {
            if (IsKalitka)
                return Kalitka.GorProfObramleniya;
            else
                return 0;
        }
    }
    public short Kalitka_LicList_OtPola
    {
        get
        {
            if (IsKalitka)
                return Kalitka.LicListOtPola;
            else
                return 0;
        }
    }
    public short Kalitka_VnutList_OtPola
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VnutListOtPola;
            else
                return 0;
        }
    }
    public short Kalitka_LicList_Virez_Height
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VirezLicList_Height;
            else
                return 0;
        }
    }
    public short Kalitka_LicList_Virez_Width
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VirezLicList_Width;
            else
                return 0;
        }
    }
    public short Kalitka_VnutList_Virez_Height
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VirezVnutList_Height;
            else
                return 0;
        }
    }
    public short Kalitka_VnutList_Virez_Width
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VirezVnutList_Width;
            else
                return 0;
        }
    }
    public short Kalitka_LicList_VIrez_OtPola
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VIrezLicList_OtPola;
            else
                return 0;
        }
    }
    public short Kalitka_LicList_VIrez_OtZamkProf
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VIrezLicList_OtZamkProf;
            else
                return 0;
        }
    }
    public short Kalitka_VnutList_VIrez_OtPola
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VIrezVnutList_OtPola;
            else
                return 0;
        }
    }
    public short Kalitka_VnutList_VIrez_OtZamkProf
    {
        get
        {
            if (IsKalitka)
                return Kalitka.VIrezVnutList_OtZamkProf;
            else
                return 0;
        }
    }
    public short Zamok
    {
        get { return param.Zamok[1].Kod; }
    }
    public short Zadvizhka
    {
        get { return param.Zadvizhka.Kod; }
    }
}
