using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

[Guid("925741bc-3bf6-44c4-9355-9fe210f6da7e")]
public interface ITableData
{
    [DispId(1)]
    [Description("Задает, либо возвращает номер строки в таблице конструирования.")]
    int Row { get; set; }

    [DispId(2)]
    [Description("Задает, либо возвращает номер изделия.")]
    string Num { get; set; }

    [DispId(3)]
    [Description("Проверяет правильность строкового представления кода изделия.")]
    bool IsValidKod(string kod);

    [DispId(4)]
    [Description("Задает, либо возвращает код изделия.")]
    short Kod { get; set; }

    [DispId(5)]
    [Description("Задает, либо возвращает высоту изделия.")]
    short Height { get; set; }

    [DispId(6)]
    [Description("Задает, либо возвращает ширину изделия.")]
    short Width { get; set; }

    [DispId(7)]
    [Description("Задает, либо возвращает сторону открывания изделия.")]
    Otkrivanie Otkrivanie { get; set; }

    [DispId(8)]
    [Description("Задает, либо возвращает ширину активной створки двустворчатого изделия (для одностворатого изделия = 0).")]
    double WAktiv { get; set; }

    [DispId(9)]
    [Description("Задает, либо возвращает наличие нижнего притвора изделия (!!! только для ДМ!!! По умолчанию - есть).")]
    bool Pritvor { get; set; }

    [DispId(10)]
    [Description("Задает, либо возвращает атрибут 'СТ' изделия.")]
    bool ST { get; set; }

    [DispId(11)]
    [Description("Задает, либо возвращает атрибут 'EI' изделия.")]
    bool EI { get; set; }

    [DispId(12)]
    [Description("Задает, либо возвращает атрибут 'EIS' изделия.")]
    bool EIS { get; set; }

    [DispId(13)]
    [Description("Задает, либо возвращает атрибут 'DPM' изделия.")]
    bool DPM { get; set; }

    [DispId(14)]
    [Description("Задает, либо возвращает наличие калитки в изделии (!!!только для ВМ!!!).")]
    bool Kalit { get; set; }

    [DispId(15)]
    [Description("Задает, либо возвращает высоту калитки в изделии (!!!только для ВМ!!!).")]
    short HKalit
    { get; set; }

    [DispId(16)]
    [Description("Задает, либо возвращает ширину калитки в изделии (!!!только для ВМ!!!).")]
    short WKalit
    { get; set; }

    [DispId(17)]
    [Description("Задает, либо возвращает отступ калитки от уровня пола в изделии (!!!только для ВМ!!!).")]
    short KalitOtPola
    { get; set; }

    [DispId(18)]
    [Description("Задает, либо возвращает отступ калитки от замкового профиля в изделии (!!!только для ВМ!!!).")]
    short KalitOtZamka { get; set; }

    [DispId(19)]
    [Description("Задает, либо возвращает структуру параметров калитки изделия (!!!только для ВМ!!!).")]
    KalitkaParam KalitParam { get; set; }

    [DispId(20)]
    [Description("Проверяет правильность строкового представления порога изделия.")]
    bool IsValidPorog(string namePorog);

    [DispId(21)]
    [Description("Задает, либо возвращает порог изделия.")]
    short Porog { get; set; }

    [DispId(22)]
    [Description("Задает, либо возвращает массив наличников изделия. (индекс 0-верхний, 1-нижний, 2-правый, 3-левый)")]
    short[] Nalichniki { get; set; }

    [DispId(23)]
    [Description("Возвращает значение ширины наличника изделия по его индексу в массиве. (индекс 0-верхний, 1-нижний, 2-правый, 3-левый)")]
    short GetNalichnik(short index);

    [DispId(24)]
    [Description("Задает значение ширины наличника изделия по его индексу в массиве. (индекс 0-верхний, 1-нижний, 2-правый, 3-левый)")]
    void SetNalichnik(short index, short val);

    [DispId(25)]
    [Description("Задает, либо возвращает атрибут 'Intek' для притолоки изделия. (!!!только для ДМ!!!)")]
    bool Intek { get; set; }

    [DispId(26)]
    [Description("Задает, либо возвращает разборная ли коробка изделия. (!!!только для МАХ и ВМ!!!)")]
    bool Razbor { get; set; }

    [DispId(27)]
    [Description("Задает, либо возвращает наличие анкерных отверстий в притолоке изделия. (!!!только для ДМ!!!)")]
    bool AMak { get; set; }

    [DispId(28)]
    [Description("Задает, либо возвращает массив структур параметров замков изделия. (0-нижний, 1-верхний)")]
    ZamokParam[] Zamok { get; set; }

    [DispId(29)]
    [Description("Возвращает код замка изделия по его индексу в массиве. (0-нижний, 1-верхний)")]
    short GetZamok(short num);

    [DispId(30)]
    [Description("Задает код замка изделия по его индексу в массиве. (0-нижний, 1-верхний)")]
    void SetZamok(short num, short val);

    [DispId(31)]
    [Description("Проверяет наличие ручки по ее номеру в массиве.")]
    bool IsRuchka(short stvorka, short num);

    [DispId(32)]
    [Description("Задает, либо возвращает массив структур параметров ручек изделия.")]
    RuchkaParam[] GetRuchki(short stvorka);

    [DispId(33)]
    [Description("Возвращает код ручки изделия по ее индексу в массиве.")]
    RuchkaParam GetRuchka(short stvorka, short num);

    [DispId(34)]
    [Description("Задает код ручки изделия по ее индексу в массиве.")]
    void SetRuchka(short stvorka, short num, RuchkaParam val);

    [DispId(35)]
    [Description("Задает, либо возвращает массив структур параметров глазков изделия.")]
    GlazokParam[] Glazok { get; set; }

    [DispId(36)]
    [Description("Добавляет глазок в массив глазков.")]
    GlazokParam AddGlazok { set; }

    [DispId(37)]
    [Description("Задает, либо возвращает структуру параметров задвижки изделия.")]
    ZadvizhkaParam Zadvizhka { get; set; }

    [DispId(38)]
    [Description("Задает, либо возвращает количество противосъемников изделия.")]
    short Protivos { get; set; }

    [DispId(39)]
    [Description("Задает, либо возвращает вариацию вырезов под усиливающие квадраты изделия. (!!!только для ДМ!!!)")]
    VirezKvadrat Kvadrat { get; set; }

    [DispId(40)]
    [Description("Задает, либо возвращает вариацию кабельканала в изделии. (!!!только для ДМ!!!)")]
    KabelRaspolozhenie Kabel { get; set; }

    [DispId(41)]
    [Description("Задает, либо возвращает вариацию заземления в изделии. (!!!только для ДМ!!!)")]
    GNDRaspolozhenie GND { get; set; }

    [DispId(42)]
    [Description("Задает, либо возвращает вариацию кодового замка в изделии. (!!!только для ДМ!!!)")]
    KodoviyParam Kodoviy { get; set; }

    [DispId(43)]
    [Description("Задает, либо возвращает расположение кодового замка от уровня пола в изделии. (!!!только для ДМ!!!)")]
    short KodoviyOtPola { get; set; }

    [DispId(44)]
    [Description("Задает, либо возвращает наличие торцевых шпингалетов в изделии. (по умолчанию - НЕТ)")]
    bool TSpingalet { get; set; }

    [DispId(45)]
    [Description("Задает, либо возвращает толщину лицевого листа изделия.")]
    double Thick_LL { get; set; }

    [DispId(46)]
    [Description("Задает, либо возвращает толщину внутреннего листа (если есть) изделия.")]
    double Thick_VL { get; set; }

    [DispId(47)]
    [Description("Возвращает наличие окна в изделии по его номеру. (!!!только для ДМ!!! 0,1-активная; 2,3-пассивная створка)")]
    bool IsOkno(short num);

    [DispId(48)]
    [Description("Задает, либо возвращает массив структур параметров окон изделия. (!!!только для ДМ!!! 0,1-активная; 2,3-пассивная створка)")]
    OknoParam[] OknoArr { get; set; }

    [DispId(49)]
    [Description("Возвращает структуру параметров окна изделия по его номеру. (!!!только для ДМ!!! 0,1-активная; 2,3-пассивная створка)")]
    OknoParam GetOkno(short num);

    [DispId(50)]
    [Description("Задает структуру параметров окна изделия по его номеру. (!!!только для ДМ!!! 0,1-активная; 2,3-пассивная створка)")]
    void SetOkno(short num, OknoParam value);

    [DispId(51)]
    [Description("Возвращает наличие решетки в изделии по ее номеру. (!!!только для ДМ!!! 0,1-активная; 2,3-пассивная створка)")]
    bool IsResh(short num);

    [DispId(52)]
    [Description("Возвращает тип решетки в изделии по ее номеру. (!!!только для ДМ!!! 0,1-активная; 2,3-пассивная створка)")]
    eReshetka GetResh(short num);

    [DispId(53)]
    [Description("Задает тип решетки в изделии по ее номеру. (!!!только для ДМ!!! 0,1-активная; 2,3-пассивная створка)")]
    void SetResh(short num, eReshetka value);

    [DispId(54)]
    [Description("Возвращает структуру параметров решетки в изделии по ее номеру. (!!!только для ДМ!!! 0,1-активная; 2,3-пассивная створка)")]
    ReshParam GetReshPar(short num);

    [DispId(55)]
    [Description("Задает структуру параметров решетки в изделии по ее номеру. (!!!только для ДМ!!! 0,1-активная; 2,3-пассивная створка)")]
    void SetReshPar(short num, ReshParam value);

    [DispId(56)]
    [Description("Задает, либо возвращает тип защитной решетки окна в изделии. (!!!только для ДМ!!!)")]
    ZashResh ZResh { get; set; }

    [DispId(57)]
    [Description("Задает, либо возвращает наличие добора в изделии. (!!!только для ДМ!!!)")]
    bool Dobor { get; set; }

    [DispId(58)]
    [Description("Задает, либо возвращает ширину наличника добора в изделии. (!!!только для ДМ!!!)")]
    short[] Dobor_Nal { get; set; }

    [DispId(59)]
    [Description("Задает, либо возвращает глубину добора в изделии. (!!!только для ДМ!!!)")]
    short Dobor_Glub { get; set; }

    [DispId(60)]
    [Description("Возвращает наличие фрамуги в изделии по ее номеру. (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    bool IsFramuga(short num);

    [DispId(61)]
    [Description("Задает, либо возвращает массив типов фрамуг в изделии. (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    FramugaType[] FrmugaArr { get; set; }

    [DispId(62)]
    [Description("Возвращает тип фрамуги в изделии по ее номеру. (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    FramugaType GetFramuga(short num);

    [DispId(63)]
    [Description("Задает тип фрамуги в изделии по ее номеру. (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    void SetFramuga(short num, FramugaType value);

    [DispId(64)]
    [Description("Задает, либо возвращает массив структур параметров фрамуг в изделии. (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    FramugaParam[] FramugaParArr { get; set; }

    [DispId(65)]
    [Description("Возвращает структуру параметров фрамуги в изделии по ее номеру. (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    FramugaParam GetFramugaPar(short num);

    [DispId(66)]
    [Description("Задает структуру параметров фрамуги в изделии по ее номеру. (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    void SetFramugaPar(short num, FramugaParam value);

    [DispId(67)]
    [Description("Возвращает наличие стекла во фрамуге по номеру фрамуги. (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    bool IsStekloFramugi(short numFr);

    [DispId(68)]
    [Description("Возвращает наличие стекла во фрамуге по номеру фрамуги и номеру стекла(если их несколько). (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    bool IsStekloFramugiByNum(short numFr, short numSt);

    [DispId(69)]
    [Description("Возвращает массив структур параметров стекол во фрамуге по ее номеру. (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    StekloParam[] GetStekloFramugiArr(short numFr);

    [DispId(70)]
    [Description("Задает массив структур параметров стекол во фрамуге по ее номеру. (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    void SetStekloFramugiArr(short numFr, StekloParam[] value);

    [DispId(71)]
    [Description("Возвращает структуру параметров стекла во фрамуге по ее номеру и номеру стекла. (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    StekloParam GetStekloFramugiByNum(short numFr, short numSt);

    [DispId(72)]
    [Description("Задает структуру параметров стекла во фрамуге по ее номеру и номеру стекла. (!!!только для ДМ!!! 0-верхняя, 1-нижняя, 2-правая, 3-левая)")]
    void SetStekloFramugiByNum(short numFr, short numSt, StekloParam value);

    [DispId(73)]
    [Description("Создает и возвращает объект класса ДМ в соответствии с кодом изделия (если код не соответствует классу ДМ, вернет null).")]
    DM CreateDM { get; }

    [DispId(74)]
    [Description("Создает и возвращает объект класса ЛМ в соответствии с кодом изделия (если код не соответствует классу ЛМ, вернет null).")]
    LM CreateLM { get; }

    [DispId(75)]
    [Description("Создает и возвращает объект класса ОДЛ в соответствии с кодом изделия (если код не соответствует классу ОДЛ, вернет null).")]
    ODL CreateODL { get; }

    [DispId(76)]
    [Description("Создает и возвращает объект класса ДВМ в соответствии с кодом изделия (если код не соответствует классу ДВМ, вернет null).")]
    DVM CreateDVM { get; }

    [DispId(77)]
    [Description("Создает и возвращает объект класса Фрвмуга, принадлежащей двери в соответствии с кодом изделия (если код не соответствует классу Фрамуга, вернет null).")]
    Framuga CreateFramugaDM(Raspolozhenie pos);

    [DispId(78)]
    [Description("Создает и возвращает объект класса Фрвмуга, принадлежащей воротам в соответствии с кодом изделия (если код не соответствует классу Фрамуга, вернет null).")]
    Framuga CreateFramugaVM(Raspolozhenie pos);

    [DispId(79)]
    DoborParam DoborParam { get; set; }

    [DispId(80)]
    string ER { get; set; }

    [DispId(81)]
    bool Bronya { get; set; }

    [DispId(82)]
    bool Termoblock { get; set; }

    [DispId(83)]
    bool EIW { get; set; }

    [DispId(84)]
    bool EIWS { get; set; }

    [DispId(85)]
    SdvigoviyParam SdvigoviyZamok { get; set; }
}

[Guid("5c9102be-2b05-4396-bb4f-9f39dcb44b54"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
public interface IETableData
{

}

[Guid("25e941a4-6b66-42ac-8e17-622bd4638eb6"), ClassInterface(ClassInterfaceType.None), ComSourceInterfaces(typeof(IETableData))]
[Description("Класс - структура входных параметров для расчета конструкции.")]
public class TableData : ITableData
{
    private readonly Constants cons = new Constants();

    private int _Row = 0;                                       //Номер строки таблици конструирования
    private string _num = "";                                   //Номер изделия
    private short _kod = 0;                                     //Код изделия
    private string _ER = "";                                    //Номер заказа

    private short _Height = 0;                                  //Высота изделия
    private short _Width = 0;                                   //Ширина изделия
                                                                //Сторона открывания (0-левая, 1-правая, 2-левая ВО, 3-правая ВО)
    private OtkrivanieParam _Otkrivanie = new OtkrivanieParam { Value = Otkrivanie.Левое, FromTable = ""};
    private WAktivParam _WAktiv = new WAktivParam { Value = 0d, FromTable = ""}; //Ширина активной створки

    private bool _Pritvor = true;                               //Наличие нижнего притвора по лицевому листу
    
    //---Технология-----------------------------------------------------------------------------------------------------------------------------
    private bool _ST = false;                                   //СТ технология
    private bool _EI = false;                                   //дверь EI
    private bool _EIS = false;                                  //дверь EIS
    private bool _DPM = false;                                  //дверь ДПМ
    private bool _EIW = false;                                  //двери EIW
    private bool _EIWS = false;                                 //двери EIWS

    //---Калитка--------------------------------------------------------------------------------------------------------------------------------
    private bool _Kalit = false;                                //Наличие калитки
    private KalitkaParam _KalitPar = new KalitkaParam { Height = 0, Width = 0, OtPola = 100, OtZamka = 100, Otkrivanie = Otkrivanie.Левое, FromTable = "" };

    //---Коробка--------------------------------------------------------------------------------------------------------------------------------
    private PorogParam _Porog = new PorogParam(); //Порог (0-нет, 40-40, 25-25, 14-14, 100-100, 2-выпадающий)
    private short[] _Nalichniki = { 0, 0, 0, 0 };               //Размеры наличников (Nalichniki(0)-верхний, N(1)-нижний, N(2)-правый, N(3)-левый)
    private bool _Intek = false;                                //Коробка Интек (да/нет)
    private bool _Razbor = false;                               //Разборная коробка (да/нет)
    private bool _AMak = false;                                 //Наличие анкеров в макушке

    //---Фурнитура------------------------------------------------------------------------------------------------------------------------------
    private ZamokParam[] _Zamok = new ZamokParam[2];         //Варианты замков
    private RuchkaParam[] _Ruchka_AS = new RuchkaParam[2];      //Варианты ручек активной створки
    private RuchkaParam[] _Ruchka_PS = new RuchkaParam[2];      //Варианты ручек пассивной створки
    private List<GlazokParam> _Glazok = new List<GlazokParam>();      //Варианты глазков
    //Варианты задвижки (0-нет, 401-ночной сторож, 402-ЗД-01, 403-ЗТ-150, 404-Торцевые шпингалеты(ворота))
    private ZadvizhkaParam _Zadvizhka = new ZadvizhkaParam();
    private short _Protivos = 0;                                //Количество противосъемников
    private VirezKvadrat _Kvadrat = 0;                          //Состояние вырезов под квадрат 8х8 (0- нет, 1- 2 выреза, 2 - 3 выреза)
    private KabelRaspolozhenie _Kabel = 0;                      //Наличие кабельперехода
    private string _KabelFromTable = "_";
    private GNDRaspolozhenie _GND = 0;                          //Вид заземления (0-нет, 1-только на стойке, 2-стойка + полотно)
    private string _GNDFromTable = "_";
    private KodoviyParam _Kodoviy = new KodoviyParam();         //Наличие кодового замка
    private bool _TSpingalet = false;                           //Наличие торцевых шпингалетов
    private bool _Bronya = false;                               //Наличие броненакладки
    private bool _Termoblock = false;                           //Наличие термоблокиратора
    private SdvigoviyParam _Sdvigoviy = new SdvigoviyParam();   //Наличие сдвигового замка
    private bool NStoTS = false;
    private bool _LicPanel = false;
    private bool _Zerkalo = false;

    //---Толщины листов-------------------------------------------------------------------------------------------------------------------------
    private double _Thick_LL = 0;                                //Толщина лицевого листа
    private double _Thick_VL = 0;                                //Толщина внутреннего листа

    //---Окна-----------------------------------------------------------------------------------------------------------------------------------
    private OknoParam[] _Okno = new OknoParam[4];

    //---Решетки--------------------------------------------------------------------------------------------------------------------------------
    private ReshParam[] _Resh = new ReshParam[4];
    private string _ReshFromTable = "_";
    private ZashResh _ZResh = 0;                                //Вид защитной решетки 

    //---Добор----------------------------------------------------------------------------------------------------------------------------------
    private bool _Dobor = false;                                //Наличие добора (Да/Нет)
    private DoborParam _DoborPar = new DoborParam();

    //---Фрамуги--------------------------------------------------------------------------------------------------------------------------------
    //(_Framuga(0)-верх, _Framuga(1)-ниж, _Framuga(2)-прав, _Framuga(3)-лев)
    private FramugaParam[] _Framuga = new FramugaParam[4];

    private string _Comments = "_";

    private short _AppRow = -1;                                 //Номер строки таблици приложения
    private bool _AppError = false;
    private bool _AppProblem = false;
    private string _AppMemory = "_";

    public void SaveToIni(string iniName)
    {
        string path = cons.DIR_WORK_TMP + "\\" + iniName + ".ini";
        SaveData(path);
    }
    public void SaveData(string iniName) 
    {
        FileInfo fileInfo = new FileInfo(iniName);
        if (!fileInfo.Exists) 
        {
            FileStream fs = File.Create(iniName);
            byte[] tmp = new ASCIIEncoding().GetBytes(";Рабочий файл, содержащий входные параметры изделия");
            fs.Write(tmp, 0, tmp.Length);
            fs.Close();
        }
        IniFile ini = new IniFile(iniName);
        string sek;
        
        if (cons.CompareKod(Kod, "ДМ") || cons.CompareKod(Kod, "MAX")) sek = "DM";
        else if (cons.CompareKod(Kod, "ЛМ")) sek = "LM";
        else if (cons.CompareKod(Kod, "ВМ")) sek = "VM";
        else if (cons.CompareKod(Kod, "ОДЛ")) sek = "ODL";
        else if (cons.CompareKod(Kod, "Фрамуга")) sek = "FR";
        else if (cons.CompareKod(Kod, "Комфорт-S")) sek = "KV01";
        else if (cons.CompareKod(Kod, "ДМ1-МДФ1")) sek = "KV05";
        else if (cons.CompareKod(Kod, "РИО") || cons.CompareKod(Kod, "КВ06")) sek = "КВ06";
        else if (cons.CompareKod(Kod, "Жардин")) sek = "KV07";
        else if (cons.CompareKod(Kod, "РИО металл-металл")) sek = "KV08";
        else sek = "???";

        short i;
        for (i = 1; i <= 500; i++) if (!ini.KeyExists(sek, i.ToString())) break;
        if (i == 500) {
            MessageBox.Show("Файл переполнен!" + '\n' +
                   "Количество изделий приблизилось к 500." + '\n' +
                   "Для избежания слишком тяжелых файлов, введите другое имя файла.");
            return;
        }

        ini.WriteKey(sek, i.ToString(), Num);

        ini.WriteKey(Num, "Row", _Row.ToString());
        ini.WriteKey(Num, "Num", _num);
        ini.WriteKey(Num, "Kod", _kod.ToString());
        ini.WriteKey(Num, "ER", _ER);

        ini.WriteKey(Num, "Height", _Height.ToString());
        ini.WriteKey(Num, "Width", _Width.ToString());
        ini.WriteKey(Num, "Otkrivanie", _Otkrivanie.Value.ToString());
        if (string.IsNullOrEmpty(_Otkrivanie.FromTable))
            ini.WriteKey(Num, "Otkrivanie_fromTable", "_");
        else
            ini.WriteKey(Num, "Otkrivanie_fromTable", _Otkrivanie.FromTable.Replace("\n", @"|"));
        ini.WriteKey(Num, "WAktiv", _WAktiv.Value.ToString());
        if (string.IsNullOrEmpty(_WAktiv.FromTable))
            ini.WriteKey(Num, "WAktiv_fromTable", "_");
        else
            ini.WriteKey(Num, "WAktiv_fromTable", _WAktiv.FromTable.Replace("\n", @"|"));
        ini.WriteKey(Num, "Pritvor", _Pritvor.ToString());

        ini.WriteKey(Num, "ST", _ST.ToString());
        ini.WriteKey(Num, "EI", _EI.ToString());
        ini.WriteKey(Num, "EIS", _EIS.ToString());
        ini.WriteKey(Num, "DPM", _DPM.ToString());
        ini.WriteKey(Num, "EIW", _EIW.ToString());
        ini.WriteKey(Num, "EIWS", _EIWS.ToString());

        ini.WriteKey(Num, "Kalit", _Kalit.ToString());
        ini.WriteKey(Num, "Kalit_Height", _KalitPar.Height.ToString());
        ini.WriteKey(Num, "Kalit_Width", _KalitPar.Width.ToString());
        ini.WriteKey(Num, "Kalit_OtPola", _KalitPar.OtPola.ToString());
        ini.WriteKey(Num, "Kalit_OtZamka", _KalitPar.OtZamka.ToString());
        ini.WriteKey(Num, "Kalit_Otkrivanie", _KalitPar.Otkrivanie.ToString());
        if(string.IsNullOrEmpty(_KalitPar.FromTable))
            ini.WriteKey(Num, "Kalit_FromTable", "_");
        else
            ini.WriteKey(Num, "Kalit_FromTable", _KalitPar.FromTable.Replace("\n", @"|"));

        ini.WriteKey(Num, "Porog", _Porog.Kod.ToString());
        if(string.IsNullOrEmpty(_Porog.FromTable))
            ini.WriteKey(Num, "Porog_FromTable", "_");
        else
            ini.WriteKey(Num, "Porog_FromTable", _Porog.FromTable.Replace("\n", @"|"));
        for (i = 0; i < 4; i++) 
            ini.WriteKey(Num, "Nalichnik(" + Enum.GetName(typeof(Raspolozhenie), i) + ")", GetNalichnik(i).ToString());
        ini.WriteKey(Num, "Intek", Intek.ToString());
        ini.WriteKey(Num, "Razbor", Razbor.ToString());
        ini.WriteKey(Num, "AMak", AMak.ToString());

        ini.WriteKey(Num, "Zamok_Count", _Zamok.Length.ToString());
        for(i=0; i<_Zamok.Length; i++)
        {
            ini.WriteKey(Num, "Zamok_"+(i+1), _Zamok[i].Kod.ToString());
            if(string.IsNullOrEmpty(_Zamok[i].Name))
                ini.WriteKey(Num, "Zamok_"+(i+1)+ "_Name", "_");
            else
                ini.WriteKey(Num, "Zamok_"+(i+1)+ "_Name", _Zamok[i].Name);
            ini.WriteKey(Num, "Zamok_" + (i + 1) + "_Cilinder", _Zamok[i].Cilinder.ToString());
            ini.WriteKey(Num, "Zamok_" + (i + 1) + "_Ruchka", _Zamok[i].Ruchka.ToString());
            ini.WriteKey(Num, "Zamok_" + (i + 1) + "_OtPola", _Zamok[i].OtPola.ToString());
            if(string.IsNullOrEmpty(_Zamok[i].FromTable))
                ini.WriteKey(Num, "Zamok_" + (i + 1) + "_FromTable", "_");
            else
                ini.WriteKey(Num, "Zamok_" + (i + 1) + "_FromTable", _Zamok[i].FromTable.Replace("\n", @"|"));
        }

        ini.WriteKey(Num, "RuchkaAS_Count", _Ruchka_AS.Length.ToString());
        for(i=0; i<_Ruchka_AS.Length; i++)
        {
            ini.WriteKey(Num, "RuchkaAS_" + (i + 1), _Ruchka_AS[i].Kod.ToString());
            if(string.IsNullOrEmpty(_Ruchka_AS[i].Name))
                ini.WriteKey(Num, "RuchkaAS_" + (i + 1) + "_Name", "_");
            else
                ini.WriteKey(Num, "RuchkaAS_" + (i + 1) + "_Name", _Ruchka_AS[i].Name);
            ini.WriteKey(Num, "RuchkaAS_" + (i + 1) + "_OtPola", _Ruchka_AS[i].OtPola.ToString());
            ini.WriteKey(Num, "RuchkaAS_" + (i + 1) + "_Mezhosevoe", _Ruchka_AS[i].Mezhosevoe.ToString());
            if(string.IsNullOrEmpty(_Ruchka_AS[i].FromTable))
                ini.WriteKey(Num, "RuchkaAS_" + (i + 1) + "_FromTable", "_");
            else
                ini.WriteKey(Num, "RuchkaAS_" + (i + 1) + "_FromTable", _Ruchka_AS[i].FromTable.Replace("\n", @"|"));
        }

        ini.WriteKey(Num, "RuchkaPS_Count", _Ruchka_PS.Length.ToString());
        for (i = 0; i < _Ruchka_PS.Length; i++)
        {
            ini.WriteKey(Num, "RuchkaPS_" + (i + 1), _Ruchka_PS[i].Kod.ToString());
            if (string.IsNullOrEmpty(_Ruchka_PS[i].Name))
                ini.WriteKey(Num, "RuchkaPS_" + (i + 1) + "_Name", "_");
            else
                ini.WriteKey(Num, "RuchkaPS_" + (i + 1) + "_Name", _Ruchka_PS[i].Name);
            ini.WriteKey(Num, "RuchkaPS_" + (i + 1) + "_OtPola", _Ruchka_PS[i].OtPola.ToString());
            ini.WriteKey(Num, "RuchkaPS_" + (i + 1) + "_Mezhosevoe", _Ruchka_PS[i].Mezhosevoe.ToString());
            if (string.IsNullOrEmpty(_Ruchka_PS[i].FromTable))
                ini.WriteKey(Num, "RuchkaPS_" + (i + 1) + "_FromTable", "_");
            else
                ini.WriteKey(Num, "RuchkaPS_" + (i + 1) + "_FromTable", _Ruchka_PS[i].FromTable.Replace("\n", @"|"));
        }

        ini.WriteKey(Num, "Glazok_Count", _Glazok.Count.ToString());
        for(i=0; i< _Glazok.Count; i++)
        {
            ini.WriteKey(Num, "Glazok_" + (i + 1) + "_Raspolozhenie", 
                                                            _Glazok[i].Raspolozhenie.ToString());
            ini.WriteKey(Num, "Glazok_" + (i + 1) + "_OtPola", _Glazok[i].OtPola.ToString());
            if(string.IsNullOrEmpty(_Glazok[i].FromTable))
                ini.WriteKey(Num, "Glazok_" + (i + 1) + "_FromTable", "_");
            else
                ini.WriteKey(Num, "Glazok_" + (i + 1) + "_FromTable", _Glazok[i].FromTable.Replace("\n", @"|"));
        }

        ini.WriteKey(Num, "Zadvizhka_Kod", _Zadvizhka.Kod.ToString());
        ini.WriteKey(Num, "Zadvizhka_OtPola", _Zadvizhka.OtPola.ToString());
        if(string.IsNullOrEmpty(_Zadvizhka.FromTable))
            ini.WriteKey(Num, "Zadvizhka_FromTable", "_");
        else
            ini.WriteKey(Num, "Zadvizhka_FromTable", _Zadvizhka.FromTable.Replace("\n", @"|"));

        ini.WriteKey(Num, "Sdvigoviy_Kod", _Sdvigoviy.Kod.ToString());
        ini.WriteKey(Num, "Sdvigoviy_Name", _Sdvigoviy.Name);
        ini.WriteKey(Num, "Sdvigoviy_FromTable", _Sdvigoviy.FromTable);

        ini.WriteKey(Num, "Protivos", Protivos.ToString());
        ini.WriteKey(Num, "Kvadrat", _Kvadrat.ToString());
        ini.WriteKey(Num, "Kabel", _Kabel.ToString());
        ini.WriteKey(Num, "GND", _GND.ToString());

        ini.WriteKey(Num, "Kodoviy", _Kodoviy.Type.ToString());
        ini.WriteKey(Num, "Kodoviy_OtPola", Kodoviy.OtPola.ToString());
        if(string.IsNullOrEmpty(Kodoviy.FromTable))
            ini.WriteKey(Num, "Kodoviy_FromTable", "_");
        else
            ini.WriteKey(Num, "Kodoviy_FromTable", Kodoviy.FromTable.Replace("\n", @"|"));

        ini.WriteKey(Num, "TSpingalet", TSpingalet.ToString());

        ini.WriteKey(Num, "Bronya", _Bronya.ToString());

        ini.WriteKey(Num, "Termoblock", _Termoblock.ToString());

        ini.WriteKey(Num, "Thick_LL", Thick_LL.ToString());
        ini.WriteKey(Num, "Thick_VL", Thick_VL.ToString());

        for (i = 0; i < _Okno.Length; i++) {
            if (IsOkno(i)) {
                ini.WriteKey(Num, "Okno_" + (i+1), "true");
                ini.WriteKey(Num, "Okno_" + (i + 1) + "_Thick", _Okno[i].Steklo.Thick.ToString());
                ini.WriteKey(Num, "Okno_" + (i + 1) + "_Height", _Okno[i].Steklo.Height.ToString());
                ini.WriteKey(Num, "Okno_" + (i + 1) + "_Width", _Okno[i].Steklo.Width.ToString());
                ini.WriteKey(Num, "Okno_" + (i + 1) + "_Gor", _Okno[i].GorRaspol.ToString());
                ini.WriteKey(Num, "Okno_" + (i + 1) + "_PoGor", _Okno[i].PoGorizontali.ToString());
                ini.WriteKey(Num, "Okno_" + (i + 1) + "_Vert", _Okno[i].VertRaspol.ToString());
                ini.WriteKey(Num, "Okno_" + (i + 1) + "_PoVert", _Okno[i].PoVertikali.ToString());
                if(string.IsNullOrEmpty(_Okno[i].FromTable))
                    ini.WriteKey(Num, "Okno_" + (i + 1) + "_FromTable", "_");
                else
                    ini.WriteKey(Num, "Okno_" + (i + 1) + "_FromTable", _Okno[i].FromTable.Replace("\n", @"|"));
            } else {
                ini.WriteKey(Num, "Okno_" + (i + 1), "false");
            }
        }

        
        for (i = 0; i < _Resh.Length; i++) {
            if (IsResh(i)) {
                ini.WriteKey(Num, "Resh_" + (i + 1), _Resh[i].Type.ToString());
                ini.WriteKey(Num, "Resh_" + (i + 1) + "_Height", _Resh[i].Height.ToString());
                ini.WriteKey(Num, "Resh_" + (i + 1) + "_Width", _Resh[i].Width.ToString());
                ini.WriteKey(Num, "Resh_" + (i + 1) + "_OtPola", _Resh[i].OtPola.ToString());
                if(string.IsNullOrEmpty(_Resh[i].FromTable))
                    ini.WriteKey(Num, "Resh_" + (i + 1) + "_FromTable", "_");
                else
                    ini.WriteKey(Num, "Resh_" + (i + 1) + "_FromTable", _Resh[i].FromTable.Replace("\n", @"|"));
            } else {
                ini.WriteKey(Num, "Resh_" + (i + 1), eReshetka.нет.ToString());
            }
        }

        ini.WriteKey(Num, "ZResh", _ZResh.ToString());

        ini.WriteKey(Num, "Dobor", _Dobor.ToString());
        for(i = 0; i < 4; i++)
        {
            ini.WriteKey(Num, "Dobor_Nalicnik(" + Enum.GetName(typeof(Raspolozhenie), i) + ")", _DoborPar.Nalicnik[i].ToString());
        }
        ini.WriteKey(Num, "Dobor_Glubina", _DoborPar.Glubina.ToString());
        if(string.IsNullOrEmpty(_DoborPar.FromTable))
            ini.WriteKey(Num, "Dobor_FromTable", "_");
        else
            ini.WriteKey(Num, "Dobor_FromTable", _DoborPar.FromTable.Replace("\n", @"|"));

        for (i = 0; i < _Framuga.Length; i++) {
            if (IsFramuga(i)) {
                ini.WriteKey(Num, "Framuga_" + (i + 1), _Framuga[i].Type.ToString());
                ini.WriteKey(Num, "Framuga_" + (i + 1) + "_Height", _Framuga[i].Height.ToString());
                ini.WriteKey(Num, "Framuga_" + (i + 1) + "_Width", _Framuga[i].Width.ToString());
                if (IsStekloFramugi(i)) {
                    ini.WriteKey(Num, "Framuga_" + (i + 1) + "_Steklo_Count", _Framuga[i].Steklo.Length.ToString());
                    for (short y = 0; y < _Framuga[i].Steklo.Length; y++) {
                        if (IsStekloFramugiByNum(i, y))
                        {
                            ini.WriteKey(Num, "Framuga_" + (i + 1) + "_Steklo_" + (y + 1), _Framuga[i].Steklo[y].Thick.ToString());
                            ini.WriteKey(Num, "Framuga_" + (i + 1) + "_Steklo_" + (y + 1) + "_Height", _Framuga[i].Steklo[y].Height.ToString());
                            ini.WriteKey(Num, "Framuga_" + (i + 1) + "_Steklo_" + (y + 1) + "_Width", _Framuga[i].Steklo[y].Width.ToString());
                        }
                    }
                }
                else
                    ini.WriteKey(Num, "Framuga_" + (i + 1) + "_Steklo_Count", "0");
            } else {
                ini.WriteKey(Num, "Framuga_" + (i + 1), FramugaType.нет.ToString());
            }
            if(string.IsNullOrEmpty(_Framuga[i].FromTable))
                ini.WriteKey(Num, "Framuga_" + (i + 1) + "_FromTable", "_");
            else
                ini.WriteKey(Num, "Framuga_" + (i + 1) + "_FromTable", _Framuga[i].FromTable.Replace("\n", @"|"));
        }

        if (string.IsNullOrEmpty(_Comments))
            ini.WriteKey(Num, "Comments", "_");
        else
            ini.WriteKey(Num, "Comments", _Comments.Replace("\n", @"|"));

        if(string.IsNullOrEmpty(_AppMemory))
            ini.WriteKey(Num, "AppMemory", "_");
        else
            ini.WriteKey(Num, "AppMemory", _AppMemory);
        ini.WriteKey(Num, "AppRow", _AppRow.ToString());
        ini.WriteKey(Num, "AppError", _AppError.ToString());
        ini.WriteKey(Num, "AppProblem", _AppProblem.ToString());
    }
    public void ReadFromIni(string iniName, string numProduct) {
        string[] files = Directory.GetFiles(cons.DIR_WORK_TMP);
        string fileName = cons.DIR_WORK_TMP + iniName;
        bool find = false;
        foreach (string s in files) {
            if (s == fileName) {
                find = true;
                break;
            }
        }
        if (!find) {
            MessageBox.Show("В рабочей папке не был найден файл - '" + iniName + "'!");
            return;
        }
        IniFile ini = new IniFile(cons.DIR_WORK_TMP + iniName);

        ReadIni(ref ini, numProduct);
    }
    internal void ReadFromIniByRef(ref IniFile ini, string numProduct) {
        ReadIni(ref ini, numProduct);
    }
    public void ReadDef(string iniName)
    {
        if (Directory.Exists(cons.DIR_TEMPLATES))
        {
            FileInfo file = new FileInfo(cons.DIR_TEMPLATES + @"\" + iniName + ".ini");
            if (file.Exists)
            {
                IniFile ini = new IniFile(cons.DIR_TEMPLATES + @"\" + iniName + ".ini");
                ReadIni(ref ini, "Def");
            }
            else MessageBox.Show("Файл " + iniName + " не найден!");
        }
        else MessageBox.Show("Папка " + cons.DIR_TEMPLATES + " не существует!");
    }
    private void ReadIni(ref IniFile iniFile, string numProduct) {
        IniFile ini = iniFile;
        _Row = int.Parse(ini.ReadKey(numProduct, "Row"));
        _num = ini.ReadKey(numProduct, "Num");
        _kod = short.Parse(ini.ReadKey(numProduct, "Kod"));
        _ER = ini.ReadKey(numProduct, "ER");

        _Height = short.Parse(ini.ReadKey(numProduct, "Height"));
        _Width = short.Parse(ini.ReadKey(numProduct, "Width"));
        _Otkrivanie.Value = (Otkrivanie)Enum.Parse(typeof(Otkrivanie), ini.ReadKey(numProduct, "Otkrivanie"));
        _Otkrivanie.FromTable = ini.ReadKey(numProduct, "Otkrivanie_fromTable").Replace(@"|", "\n");
        _WAktiv.Value = short.Parse(ini.ReadKey(numProduct, "WAktiv"));
        _WAktiv.FromTable = ini.ReadKey(numProduct, "WAktiv_fromTable").Replace(@"|", "\n");
        _Pritvor = bool.Parse(ini.ReadKey(numProduct, "Pritvor"));

        _ST = bool.Parse(ini.ReadKey(numProduct, "ST"));
        _EI = bool.Parse(ini.ReadKey(numProduct, "EI"));
        _EIS = bool.Parse(ini.ReadKey(numProduct, "EIS"));
        _DPM = bool.Parse(ini.ReadKey(numProduct, "DPM"));
        _EIW = bool.Parse(ini.ReadKey(numProduct, "EIW"));
        _EIWS = bool.Parse(ini.ReadKey(numProduct, "EIWS"));

        _Kalit = bool.Parse(ini.ReadKey(numProduct, "Kalit"));
        _KalitPar.Height = short.Parse(ini.ReadKey(numProduct, "Kalit_Height"));
        _KalitPar.Width = short.Parse(ini.ReadKey(numProduct, "Kalit_Width"));
        _KalitPar.OtPola = short.Parse(ini.ReadKey(numProduct, "Kalit_OtPola"));
        _KalitPar.OtZamka = short.Parse(ini.ReadKey(numProduct, "Kalit_OtZamka"));
        _KalitPar.Otkrivanie = (Otkrivanie)Enum.Parse(typeof(Otkrivanie), 
                                                        ini.ReadKey(numProduct, "Kalit_Otkrivanie"));
        _KalitPar.FromTable = ini.ReadKey(numProduct, "Kalit_FromTable").Replace(@"|", "\n");

        _Porog.Kod = short.Parse(ini.ReadKey(numProduct, "Porog"));
        _Porog.FromTable = ini.ReadKey(numProduct, "Porog_FromTable").Replace(@"|", "\n");
        for (short i = 0; i < 4; i++) _Nalichniki[i] = short.Parse(ini.ReadKey(numProduct, "Nalichnik(" + Enum.GetName(typeof(Raspolozhenie), i) + ")"));
        _Intek = bool.Parse(ini.ReadKey(numProduct, "Intek"));
        _Razbor = bool.Parse(ini.ReadKey(numProduct, "Razbor"));
        _AMak = bool.Parse(ini.ReadKey(numProduct, "AMak"));

        var zc = int.Parse(ini.ReadKey(numProduct, "Zamok_Count"));
        _Zamok = new ZamokParam[zc];
        for(var i = 0; i < zc; i++)
        {
            _Zamok[i].Kod = short.Parse(ini.ReadKey(numProduct, "Zamok_" + (i + 1)));
            _Zamok[i].Name = ini.ReadKey(numProduct, "Zamok_" + (i + 1) + "_Name");
            _Zamok[i].Cilinder = bool.Parse(ini.ReadKey(numProduct, "Zamok_" + (i + 1) + "_Cilinder"));
            _Zamok[i].Ruchka = bool.Parse(ini.ReadKey(numProduct, "Zamok_" + (i + 1) + "_Ruchka"));
            _Zamok[i].OtPola = short.Parse(ini.ReadKey(numProduct, "Zamok_" + (i + 1) + "_OtPola"));
            _Zamok[i].FromTable = ini.ReadKey(numProduct, "Zamok_" + (i + 1) + "_FromTable").Replace(@"|", "\n");
        }

        var rc = int.Parse(ini.ReadKey(numProduct, "RuchkaAS_Count"));
        _Ruchka_AS = new RuchkaParam[rc];
        for(var i = 0; i < rc; i++)
        {
            _Ruchka_AS[i].Kod = short.Parse(ini.ReadKey(numProduct, "RuchkaAS_" + (i + 1)));
            _Ruchka_AS[i].Name = ini.ReadKey(numProduct, "RuchkaAS_" + (i + 1) + "_Name");
            _Ruchka_AS[i].OtPola = short.Parse(ini.ReadKey(numProduct, "RuchkaAS_" + (i + 1) + "_OtPola"));
            _Ruchka_AS[i].Mezhosevoe = short.Parse(ini.ReadKey(numProduct, "RuchkaAS_" + (i + 1) + "_Mezhosevoe"));
            _Ruchka_AS[i].FromTable = ini.ReadKey(numProduct, "RuchkaAS_" + (i + 1) + "_FromTable").Replace(@"|", "\n");
        }
        rc = int.Parse(ini.ReadKey(numProduct, "RuchkaPS_Count"));
        _Ruchka_PS = new RuchkaParam[rc];
        for (int i = 0; i < rc; i++)
        {
            _Ruchka_PS[i].Kod = short.Parse(ini.ReadKey(numProduct, "RuchkaPS_" + (i + 1)));
            _Ruchka_PS[i].Name = ini.ReadKey(numProduct, "RuchkaPS_" + (i + 1) + "_Name");
            _Ruchka_PS[i].OtPola = short.Parse(ini.ReadKey(numProduct, "RuchkaPS_" + (i + 1) + "_OtPola"));
            _Ruchka_PS[i].Mezhosevoe = short.Parse(ini.ReadKey(numProduct, "RuchkaPS_" + (i + 1) + "_Mezhosevoe"));
            _Ruchka_PS[i].FromTable = ini.ReadKey(numProduct, "RuchkaPS_" + (i + 1) + "_FromTable").Replace(@"|", "\n");
        }

        _Glazok = new List<GlazokParam>();
        short cG = short.Parse(ini.ReadKey(numProduct, "Glazok_Count"));
        if (cG > 0) {
            for (short i = 0; i < cG; i++) {
                GlazokParam gp = new GlazokParam { 
                    Raspolozhenie = (GlazokRaspolozhenie)Enum.Parse(typeof(GlazokRaspolozhenie), ini.ReadKey(numProduct, "Glazok_" + (i + 1) + "_Raspolozhenie")),
                    OtPola = short.Parse(ini.ReadKey(numProduct, "Glazok_" + (i + 1) + "_OtPola")),
                    FromTable = ini.ReadKey(numProduct, "Glazok_" + (i + 1) + "_FromTable").Replace(@"|", "\n")
                };
            _Glazok.Add(gp);
            }
        }

        _Zadvizhka.Kod = short.Parse(ini.ReadKey(numProduct, "Zadvizhka_Kod"));
        _Zadvizhka.OtPola = short.Parse(ini.ReadKey(numProduct, "Zadvizhka_OtPola"));
        _Zadvizhka.FromTable = ini.ReadKey(numProduct, "Zadvizhka_FromTable").Replace(@"|", "\n");

        _Sdvigoviy.Kod = short.Parse(ini.ReadKey(numProduct, "Sdvigoviy_Kod"));
        _Sdvigoviy.Name = ini.ReadKey(numProduct, "Sdvigoviy_Name");
        _Sdvigoviy.FromTable = ini.ReadKey(numProduct, "Sdvigoviy_FromTable");

        _Protivos = short.Parse(ini.ReadKey(numProduct, "Protivos"));
        _Kvadrat = (VirezKvadrat)Enum.Parse(typeof(VirezKvadrat), ini.ReadKey(numProduct, "Kvadrat"));
        _Kabel = (KabelRaspolozhenie)Enum.Parse(typeof(KabelRaspolozhenie), ini.ReadKey(numProduct, "Kabel"));
        _GND = (GNDRaspolozhenie)Enum.Parse(typeof(GNDRaspolozhenie), ini.ReadKey(numProduct, "GND"));

        _Kodoviy.Type = (Kodoviy)Enum.Parse(typeof(Kodoviy), ini.ReadKey(numProduct, "Kodoviy"));
        _Kodoviy.OtPola = short.Parse(ini.ReadKey(numProduct, "Kodoviy_OtPola"));
        _Kodoviy.FromTable = ini.ReadKey(numProduct, "Kodoviy_FromTable").Replace(@"|", "\n");

        _TSpingalet = bool.Parse(ini.ReadKey(numProduct, "TSpingalet"));

        _Bronya = bool.Parse(ini.ReadKey(numProduct, "Bronya"));

        _Termoblock = bool.Parse(ini.ReadKey(numProduct, "Termoblock"));

        _Thick_LL = double.Parse(ini.ReadKey(numProduct, "Thick_LL"));
        _Thick_VL = double.Parse(ini.ReadKey(numProduct, "Thick_VL"));

        _Okno = new OknoParam[4];
        for (short i = 0; i < 4; i++) {
            bool okn = bool.Parse(ini.ReadKey(numProduct, "Okno_" + (i + 1)));
            if (okn) {
                _Okno[i].Steklo = new StekloParam 
                {
                    Height = short.Parse(ini.ReadKey(numProduct, "Okno_" + (i + 1) + "_Height")),
                    Width = short.Parse(ini.ReadKey(numProduct, "Okno_" + (i + 1) + "_Width")),
                    Thick = (StekloThicks)Enum.Parse(typeof(StekloThicks), 
                                                ini.ReadKey(numProduct, "Okno_" + (i + 1) + "_Thick"))
                };
                _Okno[i].GorRaspol = (GorRaspolozhenie)Enum.Parse(typeof(GorRaspolozhenie), 
                                                ini.ReadKey(numProduct, "Okno_" + (i + 1) + "_Gor"));
                _Okno[i].PoGorizontali = short.Parse(
                                                ini.ReadKey(numProduct, "Okno_" + (i + 1) + "_PoGor"));
                _Okno[i].VertRaspol = (VertRaspolozhenie)Enum.Parse(typeof(VertRaspolozhenie), 
                                                ini.ReadKey(numProduct, "Okno_" + (i + 1) + "_Vert"));
                _Okno[i].PoVertikali = short.Parse(
                                                ini.ReadKey(numProduct, "Okno_" + (i + 1) + "_PoVert"));
                _Okno[i].FromTable = ini.ReadKey(numProduct, "Okno_" + (i + 1) + "_FromTable").Replace(@"|", "\n");
            }
        }

        _Resh = new ReshParam[4];
        for (short i = 0; i < 4; i++) {
            _Resh[i].Type = (eReshetka)Enum.Parse(typeof(eReshetka), 
                                                ini.ReadKey(numProduct, "Resh_" + (i + 1)));
            if (_Resh[i].Type != eReshetka.нет) {
                _Resh[i].Height = short.Parse(ini.ReadKey(numProduct, "Resh_" + (i + 1) + "_Height"));
                _Resh[i].Width = short.Parse(ini.ReadKey(numProduct, "Resh_" + (i + 1) + "_Width"));
                _Resh[i].OtPola = short.Parse(ini.ReadKey(numProduct, "Resh_" + (i + 1) + "_OtPola"));
                _Resh[i].FromTable = ini.ReadKey(numProduct, "Resh_" + (i + 1) + "_FromTable").Replace(@"|", "\n");
            }
        }
        _ZResh = (ZashResh)Enum.Parse(typeof(ZashResh), ini.ReadKey(numProduct, "ZResh"));

        _Dobor = bool.Parse(ini.ReadKey(numProduct, "Dobor"));
        _DoborPar.Nalicnik = new short[4];
        for (int i=0; i<4; i++)
            _DoborPar.Nalicnik[i] = short.Parse(ini.ReadKey(numProduct, "Dobor_Nalicnik(" + Enum.GetName(typeof(Raspolozhenie), i) + ")"));
        _DoborPar.Glubina = short.Parse(ini.ReadKey(numProduct, "Dobor_Glubina"));
        _DoborPar.FromTable = ini.ReadKey(numProduct, "Dobor_FromTable").Replace(@"|", "\n");

        _Framuga = new FramugaParam[4];
        for (short i = 0; i < 4; i++) {
            _Framuga[i].Type = (FramugaType)Enum.Parse(typeof(FramugaType), ini.ReadKey(numProduct, "Framuga_" + (i + 1)));
            if (_Framuga[i].Type != FramugaType.нет) {
                _Framuga[i].Height = short.Parse(ini.ReadKey(numProduct, "Framuga_" + (i + 1) + "_Height"));
                _Framuga[i].Width = short.Parse(ini.ReadKey(numProduct, "Framuga_" + (i + 1) + "_Width"));
                int sc = int.Parse(ini.ReadKey(numProduct, "Framuga_" + (i + 1) + "_Steklo_Count"));
                _Framuga[i].Steklo = new StekloParam[sc];
                for (short y = 0; y < sc; y++) {
                    if (ini.KeyExists(numProduct, "Framuga_" + (i + 1) + "_Steklo_" + (y + 1))) {
                        _Framuga[i].Steklo[y].Thick = 
                            (StekloThicks)Enum.Parse(typeof(StekloThicks), ini.ReadKey(numProduct, "Framuga_" + (i + 1) + "_Steklo_" + (y + 1)));
                        _Framuga[i].Steklo[y].Height = short.Parse(ini.ReadKey(numProduct, "Framuga_" + (i + 1) + "_Steklo_" + (y + 1) + "_Height"));
                        _Framuga[i].Steklo[y].Width = short.Parse(ini.ReadKey(numProduct, "Framuga_" + (i + 1) + "_Steklo_" + (y + 1) + "_Width"));
                    }
                }
            }
            _Framuga[i].FromTable = ini.ReadKey(numProduct, "Framuga_" + (i + 1) + "_FromTable").Replace(@"|", "\n");
        }

        _Comments = ini.ReadKey(numProduct, "Comments").Replace(@"|", "\n");

        string tmp = ini.ReadKey(numProduct, "AppMemory");
        if (tmp.Equals("_"))
            _AppMemory = "";
        else
            _AppMemory = ini.ReadKey(numProduct, "AppMemory");
        _AppRow = short.Parse(ini.ReadKey(numProduct, "AppRow"));
        _AppError = bool.Parse(ini.ReadKey(numProduct, "AppError"));
        _AppProblem = bool.Parse(ini.ReadKey(numProduct, "AppProblem"));
    }

    public string TypeConstruct => 
        cons.KodAsString(_kod);
    public int Row
    {
        get => _Row;
        set => _Row = value;
    }
    public short AppRow {
        get => _AppRow;
        set => _AppRow = value;
    }
    public string Num {
        get => _num;
        set => _num = value;
    }
    public short Kod {
        get => _kod;
        set => _kod = value;
    }
    public bool IsValidKod(string kod) {
        return cons.IsValidKod(kod);
    }
    public string ER
    {
        get => _ER;
        set => _ER = value;
    }

    public short Height {
        get => _Height;
        set => _Height = value;
    }
    public short Width {
        get => _Width;
        set => _Width = value;
    }
    public Otkrivanie Otkrivanie {
        get => _Otkrivanie.Value;
        set => _Otkrivanie.Value = value;
    }
    public string OtkrFromTable {
        get => _Otkrivanie.FromTable;
        set => _Otkrivanie.FromTable = value;
    }
    public double WAktiv {
        get => _WAktiv.Value;
        set => _WAktiv.Value = value;
    }
    public WAktivParam WAktivPar
    {
        get => _WAktiv;
        set => _WAktiv = value;
    }
    public string WAktivFromTable
    {
        get => _WAktiv.FromTable;
        set => _WAktiv.FromTable = value;
    }
    public string WAktivForTable {
        get {
            switch (_WAktiv.Value) {
                case 0:
                    return "-";
                case 1:
                    return "Равнополые";
                default:
                    return WAktiv.ToString();
            }
        }
    }
    public bool Pritvor {
        get => _Pritvor;
        set => _Pritvor = value;
    }

    public bool ST {
        get => _ST;
        set => _ST = value;
    }
    public bool EI {
        get => _EI;
        set => _EI = value;
    }
    public bool EIS {
        get => _EIS;
        set => _EIS = value;
    }
    public bool DPM {
        get => _DPM;
        set => _DPM = value;
    }
    public bool EIW
    {
        get => _EIW;
        set => _EIW = value;
    }
    public bool EIWS
    {
        get => _EIWS;
        set => _EIWS = value;
    }

    public bool Kalit {
        get => _Kalit;
        set => _Kalit = value;
    }
    public string KalitFromTable {
        get => _KalitPar.FromTable;
        set => _KalitPar.FromTable = value;
    }
    public short HKalit {
        get {
            if (Kalit) return _KalitPar.Height;
            else return 0;
        }
        set => _KalitPar.Height = value;
    }
    public short WKalit {
        get {
            if (Kalit) return _KalitPar.Width;
            else return 0;
        }
        set => _KalitPar.Width = value;
    }
    public short KalitOtPola {
        get {
            if (Kalit) return _KalitPar.OtPola;
            else return 0;
        }
        set => _KalitPar.OtPola = value;
    }
    public short KalitOtZamka {
        get {
            if (Kalit) return _KalitPar.OtZamka;
            else return 0;
        }
        set => _KalitPar.OtZamka = value;
    }
    public KalitkaParam KalitParam {
        get => _KalitPar;
        set => _KalitPar = value;
    }
    public string KalitAsString {
        get {
            if (Kalit) return _KalitPar.AsString();
            else return "Нет";
        }
    }

    public short Porog {
        get => _Porog.Kod;
        set => _Porog.Kod = value;
    }
    public string PorogFromTable {
        get => _Porog.FromTable;
        set => _Porog.FromTable = value;
    }
    public PorogParam PorogPar
    {
        get => _Porog;
        set => _Porog = value;
    }
    public string Porog_name{
        get {
            return Enum.GetName(typeof(DM_PorogNames), _Porog.Kod);
        }
    }
    public bool IsValidPorog(string namePorog) {
        return cons.IsValidPorog(namePorog);
    }
    public void PorogFromString(string namePorog) {
        _Porog.Kod = cons.PorogFromString(namePorog);
    }

    public short[] Nalichniki {
        get => _Nalichniki;
        set => _Nalichniki = value;
    }
    public short GetNalichnik(short index)
    {
        if (index < _Nalichniki.Length) return _Nalichniki[index];
        else return -1;
    }
    public void SetNalichnik(short index, short val)
    {
        if (index < _Nalichniki.Length) _Nalichniki[index] = val;
    }
    public string NalichnikiAsStr {
        get {
            string str = "";
            for (int i = 0; i < 4; i++) {
                string tmp;
                switch (i) {
                    case 0:
                        tmp = "Верхний: ";
                        break;
                    case 1:
                        tmp = "Нижний: ";
                        break;
                    case 2:
                        tmp = "Правый: ";
                        break;
                    default:
                        tmp = "Левый: ";
                        break;
                }
                str += tmp + _Nalichniki[i].ToString();
                if (i < 3) str += '\n';
            }
            return str;
        }
        set {
            if (value != null && !value.Equals(""))
            {
                string[] subStr = value.Split('\n');
                for (int i = 0; i < subStr.Length; i++)
                {
                    string[] subSubStr = subStr[i].Split(':');
                    _Nalichniki[i] = short.Parse(subSubStr[1].Trim());
                }
            }
        }
    }

    public bool Intek {
        get => _Intek;
        set => _Intek = value;
    }
    public bool Razbor {
        get => _Razbor;
        set => _Razbor = value;
    }
    public bool AMak {
        get => _AMak;
        set => _AMak = value;
    }

    public ZamokParam[] Zamok
    {
        get => _Zamok;
        set => _Zamok = value;
    }
    public short GetZamok(short num)
    {
        if (num < _Zamok.Length) return _Zamok[num].Kod;
        else return 0;
    }
    public void SetZamok(short num, short val)
    {
        if (cons.IsValidZamok(val.ToString()) && num < _Zamok.Length)
        {
            _Zamok[num].Kod = val;
            _Zamok[num].Name = Enum.GetName(typeof(DM_Zamok1Names), val);
        }
    }
    public string GetZamokFromTable(short num) {
        if (num < _Zamok.Length) return _Zamok[num].FromTable;
        else return "";
    }
    public void SetZamokFromTable(short num, string val) {
        if (num < _Zamok.Length) _Zamok[num].FromTable = val;
    }

    public bool LicPanel
    {
        get => _LicPanel;
        set => _LicPanel = value;
    }
    public bool Zerkalo
    {
        get => _Zerkalo;
        set => _Zerkalo = value;
    }

    public bool IsRuchka(short stvorka, short num)
    {
        RuchkaParam[] ruchki = GetRuchki(stvorka);
        if (ruchki != null)
        {
            if (ruchki.Length > num)
                return !(ruchki[num].Kod == 0);
            else 
                return false;
        }
        else return false;
    }
    public RuchkaParam[] GetRuchki(short stvorka)
    {
        if (stvorka == (short)Stvorka.Активная)
            return _Ruchka_AS;
        else
            return _Ruchka_PS;
    }
    public void SetRuchki(short stvorka, RuchkaParam[] val)
    {
        if (stvorka == (short)Stvorka.Активная)
            _Ruchka_AS = val;
        else
            _Ruchka_PS = val;
    }
    public RuchkaParam GetRuchka(short stvorka, short num) 
    {
        if (IsRuchka(stvorka, num))
        {
            RuchkaParam[] ruchki = GetRuchki(stvorka);
            return ruchki[num];
        }
        else return new RuchkaParam();
    }
    public void SetRuchka(short stvorka, short num, RuchkaParam val)
    {
        if (stvorka == (short)Stvorka.Активная)
            _Ruchka_AS[num] = val;
        else
            _Ruchka_PS[num] = val;
    }
    public short GetRuchkaKod(short stvorka, short num)
    {
        if (IsRuchka(stvorka, num))
        {
            RuchkaParam[] ruchki = GetRuchki(stvorka);
            return ruchki[num].Kod;
        }
        else return 0;
    }
    public void SetRuchkaKod(short stvorka, short num, short kod)
    {
        if (cons.IsValidRuchka(Enum.GetName(typeof(RuchkaNames), kod)))
        {
            if (stvorka == (short)Stvorka.Активная)
            {
                _Ruchka_AS[num].Kod = kod;
                _Ruchka_AS[num].Name = Enum.GetName(typeof(RuchkaNames), kod);
            }
            else
            {
                _Ruchka_PS[num].Kod = kod;
                _Ruchka_PS[num].Name = Enum.GetName(typeof(RuchkaNames), kod);
            }
        }
    }
    public string GetRuchkaFromTable(short stvorka, short num)
    {
        RuchkaParam[] ruchki = GetRuchki(stvorka);
        if (num < ruchki.Length) 
            return ruchki[num].FromTable;
        else 
            return "";
    }
    public void SetRuchkaFromTable(short stvorka, short num, string val)
    {
        if(stvorka == (short)Stvorka.Активная)
            if (num < _Ruchka_AS.Length) _Ruchka_AS[num].FromTable = val;
        else
            if (num < _Ruchka_PS.Length) _Ruchka_PS[num].FromTable = val;
    }

    public GlazokParam[] Glazok {
        get => _Glazok.ToArray();
        set {
            _Glazok.Clear();
            if (value.Length > 0)
            {
                foreach (GlazokParam gp in value) _Glazok.Add(gp);
            }
        }
    }
    public GlazokParam AddGlazok
    {
        set
        {
            _Glazok.Add(value);
        }
    }
    public string GlazokAsString()
    {
        if (_Glazok.Count > 0)
        {
            string s = _Glazok.Count.ToString();
            foreach (GlazokParam g in _Glazok)
            {
                string tmp = g.AsString();
                if (!tmp.Equals(""))
                {
                    s += '\n' + tmp;
                }
            }
            return s;
        }
        else return "Нет";
    }
    //public void GlazokFromString(string str)
    //{
    //    if (str.Equals("") || str.Equals("Нет")) _Glazok = Array.Empty<GlazokParam>();
    //    else
    //    {
    //        string[] subStr = str.Split('\n');
    //        if (int.TryParse(subStr[0], out int count))
    //        {
    //            _Glazok = new GlazokParam[count];
    //            if (subStr.Length == 1)
    //            {
    //                for (int i = 0; i < count; i++)
    //                {
    //                    _Glazok[i].FromString("");
    //                }
    //            }
    //            else
    //            {
    //                if (subStr[1].Equals("")) _Glazok[0].FromString("");
    //                else {
    //                    string s = subStr[1];
    //                    if (subStr.Length > 2)
    //                    {
    //                        if (subStr[2].IndexOf("От пола: ") >= 0)
    //                        {
    //                            s += subStr[2];

    //                        }
    //                        else
    //                    }
    //                }
    //            }
    //        }
    //        else _Glazok = Array.Empty<GlazokParam>();
    //    }
    //}

    public ZadvizhkaParam Zadvizhka {
        get => _Zadvizhka;
        set => _Zadvizhka = value;
    }
    public SdvigoviyParam SdvigoviyZamok
    {
        get => _Sdvigoviy;
        set => _Sdvigoviy = value;
    }
    public void SetSdvigoviy(SdvigoviyNames sdvigoviy)
    {
        _Sdvigoviy.Kod = (short)sdvigoviy;
        _Sdvigoviy.Name = sdvigoviy.ToString();
    }
    public short Protivos {
        get => _Protivos;
        set => _Protivos = value;
    }
    public VirezKvadrat Kvadrat {
        get => _Kvadrat;
        set => _Kvadrat = value;
    }
    public KabelRaspolozhenie Kabel {
        get => _Kabel;
        set => _Kabel = value;
    }
    public string KabelFromTable {
        get => _KabelFromTable;
        set => _KabelFromTable = value;
    }
    public GNDRaspolozhenie GND {
        get => _GND;
        set => _GND = value;
    }
    public string GNDFromTable {
        get => _GNDFromTable;
        set => _GNDFromTable = value;
    }

    public KodoviyParam Kodoviy {
        get => _Kodoviy;
        set => _Kodoviy = value;
    }
    public string KodoviyFromTable {
        get => _Kodoviy.FromTable;
        set => _Kodoviy.FromTable = value;
    }
    public short KodoviyOtPola {
        get => _Kodoviy.OtPola;
        set => _Kodoviy.OtPola = value;
    }
    public bool TSpingalet {
        get => _TSpingalet;
        set => _TSpingalet = value;
    }
    public bool NSasTS
    {
        get => NStoTS;
        set => NStoTS = value;
    }
    public bool Bronya
    {
        get => _Bronya;
        set => _Bronya = value;
    }

    public bool Termoblock
    {
        get => _Termoblock;
        set => _Termoblock = value;
    }

    public double Thick_LL {
        get => _Thick_LL;
        set => _Thick_LL = value;
    }
    public double Thick_VL {
        get => _Thick_VL;
        set => _Thick_VL = value;
    }

    public bool IsOknoArr {
        get {
            if (_Okno != null && _Okno.Length > 0) return true;
            else return false;
        }
    }
    public bool IsOkno(short num) {
        if (IsOknoArr) return _Okno[num].Steklo.Thick != StekloThicks.Нет;
        else return false;
    }
    public OknoParam[] OknoArr {
        get => _Okno;
        set => _Okno = value;
    }
    public OknoParam GetOkno(short num)
    {
        if (IsOkno(num)) return _Okno[num];
        else return new OknoParam { Steklo = new StekloParam { Thick = 0, Height = 0, Width = 0 }, 
                                    GorRaspol = 0, 
                                    PoGorizontali = 0, 
                                    VertRaspol = 0, 
                                    PoVertikali = 0 };
    }
    public void SetOkno(short num, OknoParam value)
    {
        if (num < _Okno.Length) _Okno[num] = value;
    }
    public string OknoAsStringArr() {
        if (IsOknoArr) {
            string str = "";
            for (int i = 0; i < _Okno.Length; i++) {
                str += _Okno[i].AsString();
                if (i < _Okno.Length - 1) str += '\n';
            }
            return str;
        }
        else return "";
    }
    public void OknoFromString(string str)
    {
        if (!str.Equals("")) {
            string[] subStr = str.Split('\n');
            int count = subStr.Length / 3;
            _Okno = new OknoParam[4];
            for (int i = 0; i < count; i++) {
                int y = i * 3;
                _Okno[i].FromString(subStr[y] + '\n' + subStr[y + 1] + '\n' + subStr[y + 2]);
            }
        }
        else _Okno = Array.Empty<OknoParam>();
    }

    public bool IsReshArr {
        get {
            if (_Resh != null && _Resh.Length > 0) return true;
            else return false;
        }
    }
    public bool IsResh(short num) {
        if (IsReshArr) return _Resh[num].Type != global::eReshetka.нет;
        else return false;
    }
    public string ReshAsStringArr() {
        if (IsReshArr) {
            string strArr = "";
            for (int i = 0; i < _Resh.Length; i++) {
                strArr += _Resh[i].Type.ToString();
                if (i < _Resh.Length - 1) strArr += '\n';
            }
            return strArr;
        }
        else return "";
    }
    public void ReshFromStringArr(string str)
    {
        if (!str.Equals("")) {
            string[] subStr = str.Split('\n');
            for (int i = 0; i < subStr.Length; i++) _Resh[i].Type = (eReshetka)Enum.Parse(typeof(eReshetka), subStr[i]);
        }
    }
    public string ReshParAsStringArr {
        get
        {
            if (IsReshArr)
            {
                string strArr = "";
                for (int i = 0; i < _Resh.Length; i++)
                {
                    strArr += _Resh[i].AsString();
                    if (i < _Resh.Length - 1) strArr += '\n';
                }
                return strArr;
            }
            else return "";
        }
        set
        {
            if (!value.Equals(""))
            {
                string[] subStr = value.Split('\n');
                int count = subStr.Length / 2;
                for (int i = 0; i < count; i++)
                {
                    int y = i * 2;
                    _Resh[i].FromString(subStr[y] + '\n' + subStr[y + 1]);
                }
            }
        }
    }
    public string ReshAsString(short num) {
        if (IsResh(num)) return _Resh[num].Type.ToString();
        else return "";
    }
    public void ReshFromString(short num, string str)
    {
        if (!str.Equals("")) _Resh[num].Type = (eReshetka)Enum.Parse(typeof(eReshetka), str);
    }
    public string ReshParAsString(short num) {
        if (IsResh(num)) return _Resh[num].AsString();
        else return "";
    }
    public void ReshParFromString(short num, string str)
    {
        if (!str.Equals("")) _Resh[num].FromString(str);
    }
    public eReshetka GetResh(short num) {
        if (IsResh(num)) return _Resh[num].Type;
        else return eReshetka.нет;
    }
    public ReshParam[] ReshArr
    {
        get => _Resh;
        set => _Resh = value;
    }
    public void SetResh(short num, eReshetka value)
    {
        _Resh[num].Type = value;
    }
    public ReshParam GetReshPar(short num) {
        if (IsResh(num)) return _Resh[num];
        else return new ReshParam { Type = 0, Height = 0, Width = 0, OtPola = 0 };
    }
    public void SetReshPar(short num, ReshParam value)
    {
        _Resh[num] = value;
    }
    public string ReshFromTable {
        get => _ReshFromTable;
        set => _ReshFromTable = value;
    }
    public ZashResh ZResh {
        get => _ZResh;
        set => _ZResh = value;
    }

    public bool Dobor {
        get => _Dobor;
        set => _Dobor = value;
    }
    public DoborParam DoborParam
    {
        get => _DoborPar;
        set => _DoborPar = value;
    }
    public short[] Dobor_Nal {
        get => _DoborPar.Nalicnik;
        set => _DoborPar.Nalicnik = value;
    }
    public short Dobor_Glub {
        get => _DoborPar.Glubina;
        set => _DoborPar.Glubina = value;
    }
    public string DoborFromTable {
        get => _DoborPar.FromTable;
        set => _DoborPar.FromTable = value;
    }

    public bool IsFramugaArr {
        get
        {
            if (_Framuga != null && _Framuga.Length > 0) return true;
            else return false;
        }
    }
    public bool IsFramuga(short num) {
        if (IsFramugaArr && num < _Framuga.Length) return _Framuga[num].Type != FramugaType.нет;
        else return false;
    }
    public FramugaType[] FrmugaArr {
        get {
            if (IsFramugaArr) {
                FramugaType[] fr = new FramugaType[_Framuga.Length];
                for (int i = 0; i < _Framuga.Length; i++) fr[i] = _Framuga[i].Type;
                return fr;
            }
            else return null;
        }
        set {
            _Framuga = new FramugaParam[4];
            for (int i = 0; i < _Framuga.Length; i++) _Framuga[i].Type = value[i];
        }
    }
    public FramugaType GetFramuga(short num) {
        if (IsFramuga(num)) return _Framuga[num].Type;
        else return FramugaType.нет;
    }
    public void SetFramuga(short num, FramugaType value)
    {
        _Framuga[num].Type = value;
    }
    public FramugaParam[] FramugaParArr {
        get => _Framuga;
        set => _Framuga = value;
    }
    public FramugaParam GetFramugaPar(short num) {
        if (IsFramuga(num)) return _Framuga[num];
        else return new FramugaParam { Type = 0, Height = 0, Width = 0, Steklo = null };
    }
    public void SetFramugaPar(short num, FramugaParam value)
    {
        _Framuga[num] = value;
    }
    public string FramugaAsStringArr {
        get {
            if (IsFramugaArr) {
                string strArr = "";
                for (int i = 0; i < _Framuga.Length; i++) {
                    strArr += _Framuga[i].Type.ToString();
                    if (i < _Framuga.Length - 1) strArr += '\n';
                }
                return strArr;
            }
            else return "";
        }
        set {
            if (!value.Equals("")) {
                string[] subStr = value.Split('\n');
                for (int i = 0; i < _Framuga.Length; i++) _Framuga[i].Type = (FramugaType)Enum.Parse(typeof(FramugaType), subStr[i]);
            }
            else _Framuga = new FramugaParam[4];
        }
    }
    public string FramugaAsString(short num) {
        if (IsFramuga(num)) return _Framuga[num].Type.ToString();
        else return "";
    }
    public void FramugaFromString(short num, string value)
    {
        if (!value.Equals("")) _Framuga[num].Type = (FramugaType)Enum.Parse(typeof(FramugaType), value);
    }
    public string FramugaParAsString(short num) {
        if (IsFramuga(num)) return _Framuga[num].AsString();
        else return "";
    }
    public void FramugaParFromString(short num, string value)
    {
        if (!value.Equals("")) _Framuga[num].FromString(value);
    }
    public bool IsStekloFramugi(short numFr) {
        if (IsFramuga(numFr)) {
            if (_Framuga[numFr].Steklo != null && _Framuga[numFr].Steklo.Length > 0) return true;
            else return false;
        }
        else return false;
    }
    public bool IsStekloFramugiByNum(short numFr, short numSt) {
        if (IsStekloFramugi(numFr) && numSt < _Framuga[numFr].Steklo.Length) return _Framuga[numFr].Steklo[numSt].Thick != StekloThicks.Нет;
        else return false;
    }
    public StekloParam[] GetStekloFramugiArr(short numFr) {
        if (IsStekloFramugi(numFr)) return _Framuga[numFr].Steklo;
        else return null;
    }
    public void SetStekloFramugiArr(short numFr, StekloParam[] value)
    {
        if (value.Length > 0) {
            _Framuga[numFr].Steklo = new StekloParam[value.Length];
            _Framuga[numFr].Steklo = value;
        }
        else _Framuga[numFr].Steklo = null;
    }
    public StekloParam GetStekloFramugiByNum(short numFr, short numSt) {
        if (IsStekloFramugiByNum(numFr, numSt)) return _Framuga[numFr].Steklo[numSt];
        else return new StekloParam { Thick = 0, Height = 0, Width = 0 };
    }
    public void SetStekloFramugiByNum(short numFr, short numSt, StekloParam value)
    {
        if (IsFramuga(numFr)) _Framuga[numFr].Steklo[numSt] = value;
    }
    public string StekloFramugiAsString(short numFr) {
        if (IsStekloFramugi(numFr)) return _Framuga[numFr].StekloAsString();
        else return "";
    }
    public void StekloFramugiFromString(short numFr, string value)
    {
        if (!value.Equals("") && IsFramuga(numFr)) _Framuga[numFr].StekloFromString(value);
    }
    public string StekloFramugiAsStringByNum(short numFr, short numSt) {
        if (IsFramuga(numFr) && IsStekloFramugiByNum(numFr, numSt)) return _Framuga[numFr].Steklo[numSt].AsString();
        else return "";
    }
    public void StekloFramugiFromStringByNum(short numFr, short numSt, string value)
    {
        if (!value.Equals("") && IsFramuga(numFr)) _Framuga[numFr].Steklo[numSt].FromString(value);
    }

    public string Comments {
        get => _Comments;
        set => _Comments = value;
    }

    public bool AppError {
        get => _AppError;
        set => _AppError = value;
    }
    public bool AppProblem {
        get => _AppProblem;
        set => _AppProblem = value;
    }
    public string AppMemory {
        get => _AppMemory;
        set => _AppMemory = value;
    }

    public DMParam ForDM
    {
        get
        {
            DMParam dmp = new DMParam
            {
                Row = _Row,
                Num = _num,
                Kod = _kod,
                Height = _Height,
                Width = _Width,
                Otkrivanie = _Otkrivanie,
                WAktiv = _WAktiv,
                Pritvor = _Pritvor,
                ST = _ST,
                EI = _EI,
                EIS = _EIS,
                DPM = _DPM,
                Porog = _Porog,
                Nalichniki = _Nalichniki,
                Intek = _Intek,
                Razbor = _Razbor,
                AMak = _AMak,
                Zamok = _Zamok,
                RuchkaAS = _Ruchka_AS,
                RuchkaPS = _Ruchka_PS,
                Glazok = _Glazok.ToArray(),
                Zadvizhka = _Zadvizhka,
                Sdvigoviy = _Sdvigoviy,
                Protivos = _Protivos,
                Kvadrat = _Kvadrat,
                Kabel = _Kabel,
                KabelFromTable = _KabelFromTable,
                GND = _GND,
                GNDFromTable = _GNDFromTable,
                Kodoviy = _Kodoviy,
                TSpingalet = _TSpingalet,
                NSasTS = NStoTS,
                Termoblock = _Termoblock,
                Thick_LL = _Thick_LL,
                Thick_VL = _Thick_VL,
                Okno = _Okno,
                Resh = _Resh,
                ReshFromTable = _ReshFromTable,
                ZResh = _ZResh,
                Dobor = _Dobor,
                DoborPar = _DoborPar,
                Framuga = _Framuga,
                Comments = _Comments,
                AppRow  = _AppRow,
                AppError = _AppError,
                AppProblem = _AppProblem,
                AppMemory = _AppMemory
            };
            return dmp;
        }
    }
    public DM CreateDM
    {
        get
        {
            if (cons.CompareKod(Kod, "ДМ"))
            {
                DM dm = new DM();
                DMParam dmp = ForDM;
                dm.Init(dmp);
                return dm;
            }
            else
            {
                return null;
            }
        }
    }
    //public Framuga CreateFramuga(Raspolozhenie pos) //Otdelnaya
    //{

    //}
    public Framuga CreateFramugaDM(Raspolozhenie pos)
    {
        Framuga fr = new Framuga();
        fr.Init(ForDM, pos, false);
        return fr;
    }
    public Framuga CreateFramugaVM(Raspolozhenie pos)
    {
        Framuga fr = new Framuga();
        fr.Init(ForDM, pos, true);
        return fr;
    }
    public LM CreateLM
    {
        get
        {
            LM lm = new LM();
            lm.Init(ForDM);
            return lm;
        }
    }
    public ODLParam ForODL
    {
        get
        {
            ODLParam odlp = new ODLParam
            {
                Row = _Row,
                Num = _num,
                Kod = _kod,
                Height = _Height,
                Width = _Width,
                Otkrivanie = _Otkrivanie,
                WAktiv = _WAktiv,
                Porog = _Porog,
                Nalichniki = _Nalichniki,
                Zamok = _Zamok,
                Ruchka = _Ruchka_AS,
                Glazok = _Glazok.ToArray(),
                Zadvizhka = _Zadvizhka,
                Protivos = _Protivos,
                TSpingalet = _TSpingalet,
                Thick_LL = _Thick_LL,
                Comments = _Comments,
                AppRow = _AppRow,
                AppError = _AppError,
                AppProblem = _AppProblem,
                AppMemory = _AppMemory
            };
            return odlp;
        }
    }
    public ODL CreateODL
    {
        get
        {
            ODL odl = new ODL();
            odl.Init(ForODL);
            return odl;
        }
    }
    public DVMParam ForDVM
    {
        get
        {
            DVMParam dvmp = new DVMParam
            {
                Row = _Row,
                Num = _num,
                Kod = _kod,
                Height = _Height,
                Width = _Width,
                Otkrivanie = _Otkrivanie,
                WAktiv = _WAktiv,
                Kalit = _Kalit,
                KalitParam = _KalitPar,
                Porog = _Porog,
                Nalichniki = _Nalichniki,
                Razbor = _Razbor,
                Zamok = _Zamok,
                Ruchka = _Ruchka_AS,
                Glazok = _Glazok.ToArray(),
                Zadvizhka = _Zadvizhka,
                Protivos = _Protivos,
                TSpingalet = _TSpingalet,
                Thick_LL = _Thick_LL,
                Thick_VL = _Thick_VL,
                Okno = _Okno,
                Resh = _Resh,
                ReshFromTable = _ReshFromTable,
                ZResh = _ZResh,
                Framuga = _Framuga,
                Comments = _Comments,
                AppRow = _AppRow,
                AppError = _AppError,
                AppProblem = _AppProblem,
                AppMemory = _AppMemory
            };
            return dvmp;
        }
    }
    public DVM CreateDVM
    {
        get
        {
            DVM dvm = new DVM();
            dvm.Init(ForDVM);
            return dvm;
        }
    }
}

public struct OtkrivanieParam
{
    public Otkrivanie Value;
    public string FromTable;

    public OtkrivanieParam(Otkrivanie otkrivanie = Otkrivanie.Левое, string fromTable = "_")
    {
        Value = otkrivanie;
        FromTable = fromTable;
    }
}
public struct WAktivParam
{
    public double Value;
    public string FromTable;

    public WAktivParam(double value = 0, string fromTable = "_")
    {
        Value = value;
        FromTable = fromTable;
    }
}
public struct KalitkaParam
{
    public short Height;                                           //Высота калитки
    public short Width;                                            //Ширина калитки
    public Otkrivanie Otkrivanie;                                  //Сторона открывания калитки
    public short OtPola;                                           //Калитка от пола
    public short OtZamka;                                          //Калитка от замкового профиля
    public string FromTable;

    public KalitkaParam(short height = 0, short width = 0, Otkrivanie otkrivanie = Otkrivanie.Левое, short otPola = 100, short otZamka = 100, string fromTable = "_")
    {
        Height = height;
        Width = width;
        Otkrivanie = otkrivanie;
        OtPola = otPola;
        OtZamka = otZamka;
        FromTable = fromTable;
    }

    public string AsString()
    {
        return Height + "x" + Width + '\n' + "От замка: " + OtZamka + '\n' + "От пола: " + OtPola;
    }
    public void FromString(string str)
    {
        string[] subStr = str.Split('\n');
        string[] subGsubStr = subStr[0].Split('x');
        string[] subZsubStr = subStr[1].Split(':');
        string[] subPsubStr = subStr[2].Split(':');
        Height = short.Parse(subGsubStr[0]);
        Width = short.Parse(subGsubStr[1]);
        OtPola = short.Parse(subPsubStr[1].Trim());
        OtZamka = short.Parse(subZsubStr[1].Trim());
    }
}
public struct PorogParam
{
    public short Kod;
    public string FromTable;

    public PorogParam(short kod = 0, string fromTable = "_")
    {
        Kod = kod;
        FromTable = fromTable;
    }
}
public struct GlazokParam
{
    public GlazokRaspolozhenie Raspolozhenie;                                   //Расположение глазка по центру полотна (да/нет)
    public short OtPola;                                    //Расположение глазка от пола
    public string FromTable;

    public GlazokParam(GlazokRaspolozhenie raspolozhenie = GlazokRaspolozhenie.По_центру, short otPola = 1500, string fromTable = "_")
    {
        Raspolozhenie = raspolozhenie;
        OtPola = otPola;
        FromTable = fromTable;
    }

    public string AsString()
    {
        if (Raspolozhenie == GlazokRaspolozhenie.По_центру)
        {
            if (OtPola > 0) return "От пола: " + OtPola;
            else return "";
        }
        else
        {
            if (OtPola > 0) return "Над фурнитурой" + '\n' + "От пола: " + OtPola;
            else return "Над фурнитурой";
        }
    }
    public void FromString(string str)
    {
        if (!str.Equals(""))
        {
            string[] subStr = str.Split('\n');
            if (subStr[0].IndexOf("Над фурнитурой") >= 0)
            {
                Raspolozhenie = GlazokRaspolozhenie.Над_фурнитурой;
                if (subStr.Length > 1)
                {
                    string[] subSubStr = subStr[1].Split(':');
                    OtPola = short.Parse(subSubStr[1].Trim());
                }
                else OtPola = 0;
            }
            else
            {
                Raspolozhenie = GlazokRaspolozhenie.По_центру;
                string[] subSubStr = subStr[0].Split(':');
                OtPola = short.Parse(subSubStr[1].Trim());
            }
        }
        else
        {
            Raspolozhenie = GlazokRaspolozhenie.По_центру;
            OtPola = 0;
        }
    }
}
public struct ZamokParam
{
    public short Kod;
    public string Name;
    public short OtPola;
    public string FromTable;
    public bool Cilinder;
    public bool Ruchka;
    public bool ElMehZashelka;

    public ZamokParam(short kod = 0, string name = "_", short otPola = 0, bool cm = true, bool ruchka = true, string fromTable = "_", bool zashelka = false)
    {
        Kod = kod;
        Name = name;
        OtPola = otPola;
        Cilinder = cm;
        FromTable = fromTable;
        Ruchka = ruchka;
        ElMehZashelka = zashelka;
    }

    public string AsString()
    {
        string str = Name;
        if (OtPola > 0) str += '\n' + "От пола: " + OtPola;
        if (!Cilinder) str += '\n' + "Без цилиндра";
        if (ElMehZashelka) str += '\n' + "Электромеханическая защелка";
        return str;
    }
    public void FromString(string str)
    {
        if (!str.Equals(""))
        {
            string[] subStr = str.Split('\n');
            Name = subStr[0];
            Kod = (short)Enum.Parse(typeof(DM_Zamok1Names), Name);
            if (subStr.Length > 1)
            {
                string[] subSubStr = subStr[1].Split(':');
                OtPola = short.Parse(subSubStr[1]);
            }
        }
    }
}
public struct RuchkaParam
{
    public short Kod;
    public string Name;
    public short OtPola;
    public short Mezhosevoe;
    public string FromTable;

    public RuchkaParam(short kod = 0, string name = "_", short otPola = 1000, short mezhosevoe = 300, string fromTable = "_")
    {
        Kod = kod;
        Name = name;
        OtPola = otPola;
        Mezhosevoe = mezhosevoe;
        FromTable = fromTable;
    }

    public string AsString()
    {
        string s = Name;
        if (Mezhosevoe > 0) s += '\n' + Mezhosevoe;
        if (OtPola > 0) s += '\n' + "От пола: " + OtPola;
        return s;
    }
    public void FromString(string str)
    {
        if (!str.Equals(""))
        {
            string[] subStr = str.Split('\n');
            Name = subStr[0];
            Kod = (short)Enum.Parse(typeof(DM_RuchkaNames), Name);
            if (subStr.Length == 2)
            {
                if (subStr[1].IndexOf("От пола: ") >= 0)
                {
                    Mezhosevoe = 0;
                    string[] subSubStr = subStr[1].Split(':');
                    OtPola = short.Parse(subSubStr[1].Trim());
                }
                else
                {
                    OtPola = 0;
                    Mezhosevoe = short.Parse(subStr[1].Trim());
                }
            }
            else
            {
                Mezhosevoe = short.Parse(subStr[1].Trim());
                string[] subSubStr = subStr[2].Split(':');
                OtPola = short.Parse(subSubStr[1].Trim());
            }
        }
    }
}
public struct ZadvizhkaParam
{
    public short Kod;
    public short OtPola;
    public string FromTable;

    public ZadvizhkaParam(short kod = 0, short otPola = 1200, string fromTable = "_")
    {
        Kod = kod;
        OtPola = otPola;
        FromTable = fromTable;
    }
}
public struct SdvigoviyParam
{
    public short Kod;
    public string Name;
    public string FromTable;

    public SdvigoviyParam(short kod = 0, string name = "Нет", string fromTable = "_")
    {
        Kod = kod;
        Name = name;
        FromTable = fromTable;
    }
}
public struct KodoviyParam
{
    public Kodoviy Type;                                    //Тип расположения замка
    public short OtPola;                             //Кодовый замок от пола
    public string FromTable;

    public KodoviyParam(Kodoviy type = Kodoviy.Нет, short otPola = 1200, string fromTable = "_")
    {
        Type = type;
        OtPola = otPola;
        FromTable = fromTable;
    }
}
public struct DoborParam
{
    public short[] Nalicnik;                            //Ширина наличника добора
    public short Glubina;                              //Глубина добора
    public string FromTable;

    public DoborParam(short[] nalichnik = default, short glubina = 0, string fromTable = "_")
    {
        Nalicnik = nalichnik;
        Glubina = glubina;
        FromTable = fromTable;
    }

    public string AsString()
    {
        string tmp;
        if (Glubina > 0 | !FromTable.Equals("_"))
        {
            tmp = "Глубина " + Glubina + "\n";
            for (int i = 0; i < Nalicnik.Length; i++)
            {
                tmp += Enum.GetName(typeof(Raspolozhenie), i) + ": " + Nalicnik[i].ToString();
                if (i != 1 & i != 3)
                    tmp += "; ";
                else if (i == 1)
                    tmp += "; \n";
            }
        }
        else
            tmp = "Нет";
        return tmp;
    }
}
public struct OknoParam
{
    public StekloParam Steklo;                              //Параметры стеклопакета
    public GorRaspolozhenie GorRaspol;                      //Варианты горизонтального размещения окна (0-по центру, 1-от замкового, 2-от петлевого)
    public short PoGorizontali;                             //Значение горизонтального размещения окна
    public VertRaspolozhenie VertRaspol;                    //Варианты вертикального размещения окна (0-от пола, 1-от верха)
    public short PoVertikali;                               //Значение вертикального расположения окна
    public string FromTable;

    public OknoParam(StekloParam steklo = new StekloParam(), GorRaspolozhenie gorRaspol = GorRaspolozhenie.по_центру, short poGor = 0, 
                     VertRaspolozhenie vertRaspol = VertRaspolozhenie.от_пола, short poVert = 0, string fromTable = "_")
    {
        Steklo = steklo;
        GorRaspol = gorRaspol;
        PoGorizontali = poGor;
        VertRaspol = vertRaspol;
        PoVertikali = poVert;
        FromTable = fromTable;
    }

    public string AsString()
    {
        if (Steklo.Height > 0)
        {
            string gr, vr;
            if (GorRaspol == GorRaspolozhenie.по_центру) gr = "по центру";
            else if (GorRaspol == GorRaspolozhenie.от_замкового) gr = "от замка: " + PoGorizontali;
            else gr = "от петли: " + PoGorizontali;

            if (VertRaspol == VertRaspolozhenie.от_верха) vr = "От верха: ";
            else vr = "От пола: ";

            return Steklo.AsString() + '\n' + gr + '\n' + vr + PoVertikali;
        }
        else
            return "Нет";
    }
    public void FromString(string str)
    {
        if (!str.Equals(""))
        {
            string[] subStr = str.Split('\n');
            string[] subRsubStr = subStr[1].Split('x');
            Steklo.Height = short.Parse(subRsubStr[0]);
            Steklo.Width = short.Parse(subRsubStr[1]);
            Steklo.Thick = (StekloThicks)short.Parse(subRsubStr[2]);
            if (subStr[2].IndexOf("по центру") >= 0)
            {
                this.GorRaspol = GorRaspolozhenie.по_центру;
                PoGorizontali = 0;
            }
            else
            {
                string[] subGsubStr = subStr[2].Split(':');
                if (subGsubStr[0].IndexOf("от замка") >= 0) GorRaspol = GorRaspolozhenie.от_замкового;
                else GorRaspol = GorRaspolozhenie.от_петлевого;
                PoGorizontali = short.Parse(subGsubStr[1].Trim());
            }
            string[] subVsubStr = subStr[3].Split(':');
            if (subVsubStr[0].IndexOf("От верха") >= 0) VertRaspol = VertRaspolozhenie.от_верха;
            else VertRaspol = VertRaspolozhenie.от_пола;
            PoVertikali = short.Parse(subVsubStr[1].Trim());
        }
        else
        {
            Steklo.Thick = 0;
            Steklo.Height = 0;
            Steklo.Width = 0;
            GorRaspol = GorRaspolozhenie.по_центру;
            PoGorizontali = 0;
            VertRaspol = VertRaspolozhenie.от_пола;
            PoVertikali = 0;
        }
    }
}
public struct ReshParam
{
    public eReshetka Type;                                  //Вид решетки 
    public short Height;                                    //Высота решетки
    public short Width;                                     //Ширина решетки
    public short OtPola;                                    //Решетка от пола
    public string FromTable;

    public ReshParam(eReshetka type = eReshetka.нет, short height = 0, short width = 0, short otPola = 0, string fromTable = "_")
    {
        Type = type;
        Height = height;
        Width = width;
        OtPola = otPola;
        FromTable = fromTable;
    }

    public string AsString()
    {
        if (Type == eReshetka.нет) return "Нет";
        else return Height + "x" + Width + '\n' + "От пола: " + OtPola;
    }
    public void FromString(string str)
    {
        string[] subStr = str.Split('\n');
        string[] subGsubStr = subStr[0].Split('x');
        string[] subPsubStr = subStr[1].Split(':');
        Height = short.Parse(subGsubStr[0].Trim());
        Width = short.Parse(subGsubStr[1].Trim());
        OtPola = short.Parse(subPsubStr[1].Trim());
    }
}
public struct FramugaParam
{
    public string Num;
    public short Kod;
    public FramugaType Type;                                //Тип фрамуги
    public Raspolozhenie Raspolozhenie;
    public short Height;                                    //Высоты фрамуг
    public short Width;                                     //Ширины фрамуг
    public Otkrivanie Otkrivanie;
    public short ThickPolotna;
    public short[] Nalichniki;
    public StekloParam[] Steklo;
    public ReshParam Reshetka;
    public string FromTable;

    public FramugaParam(string num = "0", short kod = 0, FramugaType type = FramugaType.нет, Raspolozhenie raspolozhenie = Raspolozhenie.Верх, 
                        short height = 0, short width = 0, Otkrivanie otkrivanie = Otkrivanie.Левое, short thickPolotna = 53, string fromTable = "_")
    {
        Num = num;
        Kod = kod;
        Type = type;
        Raspolozhenie = raspolozhenie;
        Height = height;
        Width = width;
        Otkrivanie = otkrivanie;
        ThickPolotna = thickPolotna;
        Nalichniki = new short[4] { 0, 0, 0, 0 };
        Steklo = new StekloParam[0];
        Reshetka = new ReshParam();
        FromTable = fromTable;
    }

    public bool IsSteklo()
    {
        if (Steklo != null && Steklo.Length > 0) return true;
        else return false;
    }
    public bool IsSteklo(short num)
    {
        if (IsSteklo() && num < Steklo.Length) return Steklo[num].Thick != 0;
        else return false;
    }
    public string StekloAsString()
    {
        if (IsSteklo())
        {
            string strArr = "";
            for (int i = 0; i < Steklo.Length; i++)
            {
                strArr += Steklo[i].AsString();
                if (i < Steklo.Length - 1) strArr += '\n';
            }
            return strArr;
        }
        else return "";
    }
    public void StekloFromString(string str)
    {
        if (str != "")
        {
            string[] subStr = str.Split('\n');
            string[] stStr = new string[1];
            int c = -1;
            for (int i = 0; i < subStr.Length; i++)
            {
                if (subStr[i].IndexOf(":") >= 0) c++;
                stStr[c] += subStr[i] + '\n';
            }
            for (int i = 0; i < Steklo.Length; i++)
            {
                string[] subStStr = stStr[i].Split('\n');
                string s = "";
                for (int y = 0; y < subStStr.Length; y++)
                {
                    s += subStStr[i];
                    if (i < subStStr.Length - 1) c += '\n';
                }
                Steklo[i].FromString(s);
            }
        }
    }
    public string AsString()
    {
        if (Type == FramugaType.нет) return "Нет";
        else if (Type == FramugaType.глухая) return Height + "x" + Width;
        else return Height + "x" + Width + '\n' + StekloAsString();
    }
    public void FromString(string str)
    {
        if (str.Equals(""))
        {
            Height = 0;
            Width = 0;
            Steklo = null;
        }
        else
        {
            string[] subStr = str.Split('\n');
            string[] subGsubStr = subStr[0].Split('x');
            Height = short.Parse(subGsubStr[0].Trim());
            Width = short.Parse(subGsubStr[1].Trim());
            if (subStr.Length > 1)
            {
                for (int i = 0; i < subStr.Length - 2; i++)
                {
                    string tmp = subStr[i * 2 + 1] + '\n' + subStr[i * 2 + 2];
                    this.Steklo[i].FromString(tmp);
                }
            }
            else Steklo = null;
        }
    }
}
public struct StekloParam
{
    public StekloThicks Thick;
    public short Height;
    public short Width;

    public StekloParam(StekloThicks thick = StekloThicks.Нет, short height = 0, short width = 0)
    {
        Thick = thick;
        Height = height;
        Width = width;
    }

    public string AsString()
    {
        return "Стекло: " + '\n' + Height + "x" + Width + "x" + Thick;
    }
    public void FromString(string str)
    {
        if (!str.Equals(""))
        {
            string[] subStr = str.Split('\n');
            string[] subsubStr = subStr[1].Split('x');
            Thick = (StekloThicks)short.Parse(subsubStr[2].Trim());
            Height = short.Parse(subsubStr[0].Trim());
            Width = short.Parse(subsubStr[1].Trim());
        }
        else
        {
            Thick = 0;
            Height = 0;
            Width = 0;
        }
    }
}

public struct DMParam
{
    public int Row;                                       //Номер строки таблици конструирования
    public string Num;                                    //Номер изделия
    public short Kod;                                     //Код изделия

    public short Height;                                  //Высота изделия
    public short Width;                                   //Ширина изделия
    public OtkrivanieParam Otkrivanie;                    //Сторона открывания (0-левая, 1-правая, 2-левая ВО, 3-правая ВО)
    public WAktivParam WAktiv;                            //Ширина активной створки

    public bool Pritvor;                               //Наличие нижнего притвора по лицевому листу

    //---Технология------------------------------------------------------------------------------------------------------------------------------------
    public bool ST;                                   //СТ технология
    public bool EI;                                   //дверь EI
    public bool EIS;                                  //дверь EIS
    public bool DPM;                                  //дверь ДПМ

    //---Коробка---------------------------------------------------------------------------------------------------------------------------------------
    public PorogParam Porog;                          //Порог (0-нет, 40-40, 25-25, 14-14, 100-100, 2-выпадающий)
    public short[] Nalichniki;                        //Размеры наличников (Nalichniki(0)-верхний, Nalichniki(1)-нижний, Nalichniki(2)-правый, Nalichniki(3)-левый)
    public bool Intek;                                //Коробка Интек (да/нет)
    public bool Razbor;                               //Разборная коробка (да/нет)
    public bool AMak;                                 //Наличие анкеров в макушке

    //---Фурнитура-------------------------------------------------------------------------------------------------------------------------------------
    public ZamokParam[] Zamok;         //Варианты замков
    public RuchkaParam[] RuchkaAS;      //Варианты ручек
    public RuchkaParam[] RuchkaPS;      //Варианты ручек
    public GlazokParam[] Glazok;      //Варианты глазков
                                      //Варианты задвижки (0-нет, 401-ночной сторож, 402-ЗД-01, 403-ЗТ-150, 404-Торцевые шпингалеты(ворота))
    public ZadvizhkaParam Zadvizhka;
    public SdvigoviyParam Sdvigoviy;
    public short Protivos;                                //Количество противосъемников
    public VirezKvadrat Kvadrat;                          //Состояние вырезов под квадрат 8х8 (0- нет, 1- 2 выреза, 2 - 3 выреза)
    public KabelRaspolozhenie Kabel;                      //Наличие кабельперехода
    public string KabelFromTable;
    public GNDRaspolozhenie GND;                          //Вид заземления (0-нет, 1-только на стойке, 2-стойка + полотно)
    public string GNDFromTable;
    public KodoviyParam Kodoviy; //Наличие кодового замка
    public bool TSpingalet;                           //Наличие торцевых шпингалетов
    public bool Termoblock;                           //Наличие термоблокераторов
    public bool NSasTS;

    //---Толщины листов--------------------------------------------------------------------------------------------------------------------------------
    public double Thick_LL;                                //Толщина лицевого листа
    public double Thick_VL;                                //Толщина внутреннего листа

    //---Окна------------------------------------------------------------------------------------------------------------------------------------------
    public OknoParam[] Okno;

    //---Решетки---------------------------------------------------------------------------------------------------------------------------------------
    public ReshParam[] Resh;
    public string ReshFromTable;
    public ZashResh ZResh;                                //Вид защитной решетки 

    //---Добор-----------------------------------------------------------------------------------------------------------------------------------------
    public bool Dobor;                                    //Наличие добора (Да/Нет)
    public DoborParam DoborPar;

    //---Фрамуги---------------------------------------------------------------------------------------------------------------------------------------
    //(_Framuga(0)-верх, _Framuga(1)-ниж, _Framuga(2)-прав, _Framuga(3)-лев)
    public FramugaParam[] Framuga;

    public string Comments;

    public short AppRow;                                 //Номер строки таблици приложения
    public bool AppError;
    public bool AppProblem;
    public string AppMemory;

    public bool IsZamok(short num)
    {
        if (Zamok != null & Zamok.Length > num)
        {
            return !(Zamok[num].Kod == 0);
        }
        else return false;
    }
    public bool IsRuchka(short stvorka, short num)
    {
        RuchkaParam[] ruchka;
        if (stvorka == (int)Stvorka.Активная)
            ruchka = RuchkaAS;
        else
            ruchka = RuchkaPS;
        if (ruchka != null)
        {
            if (ruchka.Length > num)
                return !(ruchka[num].Kod == 0);
            else
                return false;
        }
        else return false;
    }
    public bool IsGlazok(short num)
    {
        return Glazok != null & Glazok.Length > num;
    }
    public bool IsOkno(short num)
    {
        if (Okno != null & Okno.Length > num)
        {
            return !(Okno[num].Steklo.Height == 0);
        }
        else return false;
    }
    public bool IsResh(short num)
    {
        if (Resh != null & Resh.Length > num)
        {
            return !(Resh[num].Type == eReshetka.нет);
        }
        else return false;
    }
    public bool IsFramuga(short num)
    {
        if (Framuga != null & Framuga.Length > num)
        {
            return !(Framuga[num].Type == FramugaType.нет);
        }
        else return false;
    }
}
public struct ODLParam
{
    public int Row;                                       //Номер строки таблици конструирования
    public string Num;                                    //Номер изделия
    public short Kod;                                     //Код изделия

    public short Height;                                  //Высота изделия
    public short Width;                                   //Ширина изделия
    public OtkrivanieParam Otkrivanie;                    //Сторона открывания (0-левая, 1-правая, 2-левая ВО, 3-правая ВО)
    public WAktivParam WAktiv;                                  //Ширина активной створки

    //---Коробка---------------------------------------------------------------------------------------------------------------------------------------
    public PorogParam Porog;                                   //Порог (0-нет, 40-40, 25-25, 14-14, 100-100, 2-выпадающий)
    public short[] Nalichniki;               //Размеры наличников (Nalichniki(0)-верхний, Nalichniki(1)-нижний, Nalichniki(2)-правый, Nalichniki(3)-левый)

    //---Фурнитура-------------------------------------------------------------------------------------------------------------------------------------
    public ZamokParam[] Zamok;         //Варианты замков
    public RuchkaParam[] Ruchka;      //Варианты ручек
    public GlazokParam[] Glazok;      //Варианты глазков
                                      //Варианты задвижки (0-нет, 401-ночной сторож, 402-ЗД-01, 403-ЗТ-150, 404-Торцевые шпингалеты(ворота))
    public ZadvizhkaParam Zadvizhka;
    public short Protivos;                                //Количество противосъемников
    public bool TSpingalet;                           //Наличие торцевых шпингалетов

    //---Толщины листов--------------------------------------------------------------------------------------------------------------------------------
    public double Thick_LL;                                //Толщина лицевого листа

    public string Comments;

    public short AppRow;                                 //Номер строки таблици приложения
    public bool AppError;
    public bool AppProblem;
    public string AppMemory;

    public bool IsZamok(short num)
    {
        if (Zamok != null & Zamok.Length > num)
        {
            return !(Zamok[num].Kod == 0);
        }
        else return false;
    }
    public bool IsRuchka(short num)
    {
        if (Ruchka != null & Ruchka.Length > num)
        {
            return !(Ruchka[num].Kod == 0);
        }
        else return false;
    }
    public bool IsGlazok(short num)
    {
        return Glazok != null & Glazok.Length > num;
    }
}
public struct DVMParam
{
    public int Row;                                       //Номер строки таблици конструирования
    public string Num;                                   //Номер изделия
    public short Kod;                                     //Код изделия

    public short Height;                                  //Высота изделия
    public short Width;                                   //Ширина изделия
    public OtkrivanieParam Otkrivanie;                    //Сторона открывания (0-левая, 1-правая, 2-левая ВО, 3-правая ВО)
    public WAktivParam WAktiv;                            //Ширина активной створки

    //---Калитка-----------------------------------------------------------------------------------------------------------------------------------------
    public bool Kalit;                                //Наличие калитки
    public KalitkaParam KalitParam;

    //---Коробка-----------------------------------------------------------------------------------------------------------------------------------------
    public PorogParam Porog;                                   //Порог (0-нет, 40-40, 25-25, 14-14, 100-100, 2-выпадающий)
    public short[] Nalichniki;               //Размеры наличников (Nalichniki(0)-верхний, Nalichniki(1)-нижний, Nalichniki(2)-правый, Nalichniki(3)-левый)
    public bool Razbor;                               //Разборная коробка (да/нет)

    //---Фурнитура---------------------------------------------------------------------------------------------------------------------------------------
    public ZamokParam[] Zamok;         //Варианты замков
    public RuchkaParam[] Ruchka;      //Варианты ручек
    public GlazokParam[] Glazok;      //Варианты глазков
    //Варианты задвижки (0-нет, 401-ночной сторож, 402-ЗД-01, 403-ЗТ-150, 404-Торцевые шпингалеты(ворота))
    public ZadvizhkaParam Zadvizhka;
    public short Protivos;                                //Количество противосъемников
    public bool TSpingalet;                           //Наличие торцевых шпингалетов

    //---Толщины листов----------------------------------------------------------------------------------------------------------------------------------
    public double Thick_LL;                                //Толщина лицевого листа
    public double Thick_VL;                                //Толщина внутреннего листа

    //---Окна--------------------------------------------------------------------------------------------------------------------------------------------
    public OknoParam[] Okno;

    //---Решетки-----------------------------------------------------------------------------------------------------------------------------------------
    public ReshParam[] Resh;
    public string ReshFromTable;
    public ZashResh ZResh;                                //Вид защитной решетки 

    //---Фрамуги-----------------------------------------------------------------------------------------------------------------------------------------
    //(_Framuga(0)-верх, _Framuga(1)-ниж, _Framuga(2)-прав, _Framuga(3)-лев)
    public FramugaParam[] Framuga;

    public string Comments;

    public short AppRow;                                 //Номер строки таблици приложения
    public bool AppError;
    public bool AppProblem;
    public string AppMemory;
}
public struct FramugaOtdelParam
{
    public string Num;
    public FramugaType Type;
    public short Height;
    public short Width;
    public Otkrivanie Otkrivanie;
    public StekloParam[] Steklo;
}

public enum Stvorka {
    Активная,
    Пассивная
}
public enum VirezKvadrat
{
    нет,
    _2_выреза,
    _3_выреза
}
public enum Otkrivanie {
    Левое,
    Правое,
    ЛевоеВО,
    ПравоеВО
}
public enum VarNalichnik {
    Без_наличника,
    Наличник_стандарт,
    Нет_слева_или_справа,
    Только_сверху,
    Нет_сверху,
    Нет_сверху_и_сбоку,
    По_периметру
}
public enum Kodoviy {
    Нет,
    Врезной_кнопки_на_лице,
    Врезной_кнопки_на_жопе,
    Врезной_пассивка_кнопки_на_лице,
    Врезной_пассивка_кнопки_на_жопе,
    Накладной_пассивка_кнопки_на_лице,
    Накладной_пассивка_кнопки_на_жопе
}
public enum eReshetka {
    нет,
    ПП_решетка,
    Вент_решетка
}
public enum ZashResh {
    нет,
    решетка_на_1сторону,
    решетка_на_2стороны
}
public enum FramugaType {
    нет,
    глухая,
    частичного_остекления,
    полного_остекления,
    с_жалюзийной_решеткой
}
public enum Raspolozhenie {
    Верх,
    Ниж,
    Прав,
    Лев
}
public enum GorRaspolozhenie {
    по_центру,
    от_замкового,
    от_петлевого
}
public enum VertRaspolozhenie { 
    от_пола,
    от_верха
}
public enum KabelRaspolozhenie
{
    нет,
    в_активке,
    в_пассивке
}
public enum GNDRaspolozhenie
{
    нет, 
    только_на_стойке, 
    стойка_и_полотно
}
public enum Tehnology
{
    Техничка,
    EI,
    EIS,
    EIW,
    EIWS,
    Техничка_EIS
}
