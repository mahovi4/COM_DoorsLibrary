using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

[Guid("4fc83879-8b1b-4368-bef8-86a3ec098466")]
public interface IDM
{
    [DispId(1)]
    [Description("Производит расчет изделия.")]
    void Init(DMParam data);

    [DispId(2)]
    [Description("Возвращает номер строки в таблице конструирования, соответствующей данному изделию.")]
    int Row { get; }

    [DispId(3)]
    [Description("Возвращает номер данного изделия, присвоенный ему системой 1С.")]
    string Num { get; }

    [DispId(4)]
    [Description("Возвращает числовой код данного изделия.")]
    short Kod { get; }

    [DispId(5)]
    [Description("Возвращает перечень ошибок, возникших при расчете (в противном случае пустая строка).")]
    string Errors { get; }

    [DispId(6)]
    [Description("Возвращает перечень проблем в конструкции, возникших при расчете (в противном случае пустая строка).")]
    string Problems { get; }

    [DispId(7)]
    [Description("Возвращает монтажную высоту изделия.")]
    short Height { get; }

    [DispId(8)]
    [Description("Возвращает монтажную ширину изделия.")]
    short Width { get; }

    [DispId(9)]
    [Description("Возвращает имя DXF-файла детали изделия по индексу детали в конструкции.")]
    string Name(short index);

    [DispId(10)]
    [Description("Возвращает наличие добора в изделии.")]
    bool IsDobor { get; }

    [DispId(11)]
    [Description("Возвращает длину добора в изделии по его расположению.")]
    short Dobor_Length(Raspolozhenie pos);

    [DispId(12)]
    [Description("Возвращает глубину добора в изделии.")]
    short Dobor_Glubina { get; }

    [DispId(13)]
    [Description("Возвращает ширину наличника добора в изделии.")]
    short[] Dobor_Nalichnik { get; }

    [DispId(14)]
    [Description("Возвращает сторону открывания изделия.")]
    Otkrivanie Otkrivanie { get; }

    [DispId(15)]
    [Description("Возвращает высоту створки изделия.")]
    double Stvorka_Height(Stvorka stvorka);

    [DispId(16)]
    [Description("Возвращает ширину створки изделия.")]
    double Stvorka_Width(Stvorka stvorka);

    [DispId(17)]
    [Description("Возвращает высоту развертки лицевого листа по его створке.")]
    double LicevoyList_Height(Stvorka stvorka);

    [DispId(18)]
    [Description("Возвращает ширину развертки лицевого листа по его створке.")]
    double LicevoyList_Width(Stvorka stvorka);

    [DispId(19)]
    [Description("Возвращает высоту развертки внутреннего листа по его створке.")]
    double VnutrenniyList_Height(Stvorka stvorka);

    [DispId(20)]
    [Description("Возвращает ширину развертки внутреннего листа по его створке.")]
    double VnutrenniyList_Width(Stvorka stvorka);

    [DispId(21)]
    [Description("Возвращает величину отступа от пола до лицевого листа.")]
    short LicevoyList_OtPola { get; }

    [DispId(22)]
    [Description("Возвращает величину отступа от пола до внутреннего листа.")]
    short VnutrenniyList_OtPola { get; }

    [DispId(23)]
    [Description("Возвращает наличие пассивной створки в изделии.")]
    bool IsPassivka { get; }

    [DispId(24)]
    [Description("Возвращает наличие верхнего торцевого шпингалета в изделии.")]
    bool IsUpTShpingalet { get; }

    [DispId(25)]
    [Description("Возвращает наличие нижнего торцевого шпингалета в изделии.")]
    bool IsDownTShpingalet { get; }

    [DispId(26)]
    [Description("Возвращает наличие заземления в детали изделия по индексу детали.")]
    bool IsGND(short index);

    [DispId(27)]
    [Description("Возвращает наличие кабельканала в детали изделия по индексу детали.")]
    bool IsKabelKanal(short index);

    [DispId(28)]
    [Description("Возвращает количество вырезов под усиливающие квадраты.")]
    short VirezPodKvadrat_Count { get; }

    [DispId(29)]
    [Description("Возвращает наличие нижнего притвора в изделии.")]
    bool IsDownPritvor { get; }

    [DispId(30)]
    [Description("Возвращает ширину (полную видимую после гибки) наличника по его расположению в изделии.")]
    short Nalichnik(Raspolozhenie pos);

    [DispId(31)]
    [Description("Возвращает тип стойки (К1, К2, К3) по ее расположению в изделии.")]
    short Stoyka_Type(Raspolozhenie pos);

    [DispId(32)]
    [Description("Возвращает наличие нестандартного порога в изделии.")]
    bool IsPorogNestandart { get; }

    [DispId(33)]
    [Description("Возвращает высоту стойки по ее расположению в изделии.")]
    short HeightStoyki(Raspolozhenie pos);

    [DispId(34)]
    [Description("Возвращает наличие ответки под торцевой шпингалет в стойки по ее расположению в изделии.")]
    bool IsOtvetkaTorcShpin(Raspolozhenie pos);

    [DispId(35)]
    [Description("Возвращает наличие выпадающего порога в изделии.")]
    bool IsVipadPorog { get; }

    [DispId(36)]
    [Description("Возвращает наличие окна в изделии по номегу окна (0, 1 - активка; 2, 3 - пассивка).")]
    bool IsOkno(short num);

    [DispId(37)]
    [Description("Возвращает наличие решетки в изделии по номегу решетки (0, 1 - активка; 2, 3 - пассивка).")]
    bool IsReshetka(short num);

    [DispId(38)]
    [Description("Возвращает тип решетки в изделии по номегу решетки (0, 1 - активка; 2, 3 - пассивка).")]
    eReshetka Reshetka_Type(short num);

    [DispId(39)]
    [Description("Возвращает наличие фрамуги в изделии по ее расположению.")]
    bool IsFramuga(Raspolozhenie pos);

    [DispId(40)]
    [Description("Возвращает объект класса Framuga по ее расположению в изделии.")]
    Framuga Framuga(Raspolozhenie pos);
    [DispId(41)]
    [Description("Возвращает развертку наличника добора в изделии.")]
    double[] Dobor_Nalichnik_Razv { get; }
}

[Guid("844a28b8-8f1b-4ea7-8933-65a1a36c71bd"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
public interface IEDM
{

}

[Guid("a7c72949-786c-4faf-b26f-e4b2bf679c0c"), ClassInterface(ClassInterfaceType.None), ComSourceInterfaces(typeof(IEDM))]
[Description("Класс расчета ДМ.")]
public class DM : IDM
{
    private StKod _Kod;
    private short Koef2mm = 0, k62 = 0, k70 = 0;
    private string _name = "", NameDob = "", _ERRORS = "", _PROBLEMS = "";

    private readonly Constants cons = new Constants();
    private IniFile ini;

    private StvorkaDM Aktivka, Passivka;
    private KorobkaDM Korobka;
    private Furniture Furniture;
    private readonly Okno[] Okna = new Okno[4];
    private readonly Reshetka[] Reshetki = new Reshetka[4];
    private readonly Framuga[] Framugi = new Framuga[4];

    private DMParam param;

    public void Init(TableData tData)
    {
        Init(tData.ForDM);
    }
    public void Init(DMParam data)
    {
        Constants cons = new Constants();
        param = data;
        _Kod = cons.GetKOD(param.Kod);
        if (!cons.CompareKod(data.Kod, "ДОБОР"))
        {
            ini = new IniFile(cons.DIR_CONS_GLOBAL + "\\DM.ini");

            k62 = cons.CompareKod(param.Kod, "(62)") ? short.Parse(ini.ReadKey("Koef", "KOEF_62")) : (short)0;
            k70 = cons.CompareKod(param.Kod, "(70)") ? short.Parse(ini.ReadKey("Koef", "KOEF_90")) : (short)0;
            Koef2mm = param.Thick_VL == 2 ? short.Parse(ini.ReadKey("Koef", "DM2_K_WVA_T2")) : (short)0;

            //==================================|Анализ конфирурации|==================================== (все подробности анализа в функции CheckConfig)
            CheckConfig();

            //===============================|Создание и расчет коробки|================================= (все подробности расчета в классе KorobkaDM)
            Korobka = new KorobkaDM(ref param, ref ini);

            //===============================|Создание и расчет створок|================================== (все подробности расчета в классе StvorkaDM)
            if (param.WAktiv.Value == 0)
                Aktivka = new StvorkaDM(ref param, Stvorka.Активная, ref cons, ref ini, ref Korobka);
            else
            {
                Aktivka = new StvorkaDM(ref param, Stvorka.Активная, ref cons, ref ini, ref Korobka);
                Passivka = new StvorkaDM(ref param, Stvorka.Пассивная, ref cons, ref ini, ref Korobka);
            }

            //=====================================|Фурнитура|============================================
            Furniture = new Furniture();
            Furniture.Error += OnError;
            Furniture.Problem += OnProblem;
            Furniture.Calculate(ref param, ref cons, ref ini, in Aktivka);

            //========================================|Окна|========================================== (все подробности расчета в классе Okno)
            for (short i = 0; i < 4; i++)
            {
                StvorkaDM stvorka;
                if (i == 0 | i == 1)
                    stvorka = Aktivka;
                else
                    stvorka = Passivka;
                if (param.IsOkno(i)) Okna[i] = new Okno(ref param, i, stvorka, ref cons, ref ini);
                else Okna[i] = null;
            }

            //=======================================|Решетки|======================================== (все подробности расчета в классе Reshetka)
            for (short i = 0; i < 4; i++)
            {
                StvorkaDM stvorka;
                if (i == 0 | i == 1)
                    stvorka = Aktivka;
                else
                    stvorka = Passivka;
                if (param.IsResh(i)) Reshetki[i] = new Reshetka(ref param, i, stvorka);
            }

            //=======================================|Фрамуги|======================================== (все подробности расчета в классе Framuga)
            for (short i = 0; i < 4; i++)
            {
                if (param.IsFramuga(i))
                {
                    Framugi[i] = new Framuga();
                    Framugi[i].Init(param, (Raspolozhenie)i, false);
                }
                else Framugi[i] = null;
            }

            CheckForErrors();
            CheckForProblems();
        }

        //======================================================================================
        //-----------------------------------|ПРИСВОЕНИЕ ИМЕНИ|---------------------------------
        //======================================================================================
        string otkr;
        if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.ЛевоеВО)
        {
            otkr = "_L_";
        }
        else
        {
            otkr = "_R_";
        }

        _name = _Kod.FilePref + otkr + param.Num;

        //Присвоение имени добору
        if (cons.CompareKod(param.Kod, "ДОБОР"))
        {
            NameDob = cons.FilePrefByKod(param.Kod) + param.Num;
        }
        else
        {
            NameDob = cons.FilePrefByKod(cons.SearchKod("ДОБОР")[0]) + param.Num;
        }
    }

    private void CheckConfig()
    {
        if (param.Height % 10 != 0)
            Errors = "Высота не кратна 10! ";
        if (param.Width % 10 != 0)
            Errors = "Ширина не кратна 10! ";
        if (param.Zamok[1].Kod == 20)
        {
            param.Zamok[1].Kod = 1;
            Problems = "Замок без пробивки под ручки! ";
        }
        if (param.Zamok[0].ElMehZashelka)
        {
            if (cons.CompareKod(param.Kod, "ДМ-2"))
                param.Kabel = KabelRaspolozhenie.в_пассивке;
            else
                param.Kabel = KabelRaspolozhenie.нет;
        }
    }
    private void CheckForProblems()
    {
        if (param.Zamok[0].Kod == (short) DM_Zamok1Names.Просам_ЗВ_4)
        {
            if (param.RuchkaAS[0].Kod != (short) RuchkaNames.Ручка_планка_Просам &&
                param.RuchkaAS[0].Kod != (short) RuchkaNames.Ручка_фланец)
                Problems = "Замок 'Просам ЗВ-4' не укомплектован подходящей ручкой!";
        }
        if (param.Height <= 1200)
            Problems = "Дверь слишком низкая, проверь противосъемы с анкерами!";
        if(param.Nalichniki[(int)Raspolozhenie.Ниж] > 0)
            Problems = "Снизу есть наличник. ";

        if (param.RuchkaAS[0].Kod == (short) RuchkaNames.Ручка_скоба & param.RuchkaAS[0].Mezhosevoe > 400)
            Problems = "Проверь расположение ручки на активной створке!";
        if (param.RuchkaPS[0].Kod == (short)RuchkaNames.Ручка_скоба & param.RuchkaPS[0].Mezhosevoe > 400)
            Problems = "Проверь расположение ручки на пассивной створке!";

        if (IsOkno(0))
        {
            if (param.RuchkaAS[0].Kod == (short)RuchkaNames.Ручка_скоба | param.RuchkaAS[0].Kod == (short)RuchkaNames.Ручка_кнопка)
                if (Aktivka.VList_Width - Okna[0].WVirVL - Okna[0].OtCrayaVL - Furniture.Ruchka_OtKraya((short)Stvorka.Активная, 0, 1) < 80)
                    Problems = "Окно близко к ручке. ";
            if (param.RuchkaAS[1].Kod == (short)RuchkaNames.Ручка_скоба | param.RuchkaAS[1].Kod == (short)RuchkaNames.Ручка_кнопка)
                if (Aktivka.VList_Width - Okna[0].WVirVL - Okna[0].OtCrayaVL - Furniture.Ruchka_OtKraya((short)Stvorka.Активная, 1, 1) < 80)
                    Problems = "Окно близко к ручке. ";
        }
        if (IsOkno(1))
        {
            if (param.RuchkaAS[0].Kod == (short)RuchkaNames.Ручка_скоба | param.RuchkaAS[0].Kod == (short)RuchkaNames.Ручка_кнопка)
                if (Aktivka.VList_Width - Okna[1].WVirVL - Okna[1].OtCrayaVL - Furniture.Ruchka_OtKraya((short)Stvorka.Активная, 0, 1) < 80)
                    Problems = "Окно близко к ручке. ";
            if (param.RuchkaAS[1].Kod == (short)RuchkaNames.Ручка_скоба | param.RuchkaAS[1].Kod == (short)RuchkaNames.Ручка_кнопка)
                if (Aktivka.VList_Width - Okna[1].WVirVL - Okna[1].OtCrayaVL - Furniture.Ruchka_OtKraya((short)Stvorka.Активная, 1, 1) < 80)
                    Problems = "Окно близко к ручке. ";
        }
        if (param.Zadvizhka.Kod == (short)ZadvizhkaNames.Ночной_сторож)
        {
            if (IsOkno(0))
                if ((Aktivka.VList_Width - Okna[0].WVirVL - Okna[0].OtCrayaVL) < (250 + Koef2mm))
                    Problems = "Окно близко к ночному сторожу. ";
            if (IsOkno(1))
                if ((Aktivka.VList_Width - Okna[1].WVirVL - Okna[1].OtCrayaVL) < (250 + Koef2mm))
                    Problems = "Окно близко к ночному сторожу. ";
        }
        for (short i = 0; i < Okna.Length; i++) {
            if (IsOkno(i))
                if((Okna[i].OtPola + Okna[i].HVirLL) < Aktivka.LList_Hight / 2)
                    Problems = "Необходимо проверить высоту расположения окна " + (i + 1) + ". ";
        }
        for (short i = 0; i < param.Okno.Length; i++)
            if (param.IsOkno(i) & param.Okno[i].Steklo.Height == param.Okno[i].Steklo.Width)
                Problems = "Высота и ширина окна " + (i + 1) + " равны, возможно окно круглое. ";
        
        if (param.IsOkno(0) & param.IsOkno(2))
        {
            if (param.Okno[0].VertRaspol == param.Okno[2].VertRaspol)
            {
                if (param.Okno[0].PoVertikali != param.Okno[2].PoVertikali)
                    Problems = "Окна на активной и пассивной створке на разной высоте. ";
                if(param.Okno[0].VertRaspol != param.Okno[2].VertRaspol)
                    Problems = "Окна на активной и пассивной створке имеют разное расположение. ";
            }
        }
        if (param.IsOkno(1) & param.IsOkno(3))
        {
            if (param.Okno[1].VertRaspol == param.Okno[3].VertRaspol)
            {
                if (param.Okno[1].PoVertikali != param.Okno[3].PoVertikali)
                    Problems = "Окна на активной и пассивной створке на разной высоте. ";
                if (param.Okno[1].VertRaspol != param.Okno[3].VertRaspol)
                    Problems = "Окна на активной и пассивной створке имеют разное расположение. ";
            }
        }
        if (Korobka.IsPorogNestandart)
            Problems = "Присутствует не стандартный порог. Выполнена как безпороговая. ";
        if (Aktivka.VList_Width > (cons.LIST_WIDTH))
            Problems = "Развертка внутреннего листа активной створки равна " + Aktivka.VList_Width + ", что больше ширины листа! ";
        if (Passivka != null)
        {
            if (Passivka.VList_Width > (cons.LIST_WIDTH))
                Problems = "Развертка внутреннего листа пассивной створки равна " + Passivka.VList_Width + ", что больше ширины листа! ";
        }
        foreach(Raspolozhenie pos in Enum.GetValues(typeof(Raspolozhenie)))
        {
            if (!IsFramuga(pos)) continue;
            var fr = Framuga(pos);
            var w = fr.Steklo_Width / 1000f;
            var h = fr.Steklo_Hight / 1000f;
            var gs = w * h;
            if(gs > 2)
            {
                //MessageBox.Show("Размер стекла фрамуги " + pos.ToString() + " равен " + gs + " м.кв, что больше 2 м.кв!", Num);
                MessageBox.Show($"Размер стекла фрамуги {pos} равен {gs} м.кв, что больше 2 м.кв!", Num);
                Problems = $"Размер стекла фрамуги {pos} равен {gs} м.кв, что больше 2 м.кв!";
            }
        }

        if (Furniture.IsKodoviy && Furniture.ContainsRuchka((short) RuchkaNames.Ручка_скоба) && Furniture.Zamki.Length > 0)
        {
            if (Furniture.Zamki.Length > 1 || Furniture.Zamki[0].OtPola > 1000)
                Problems = "Проверь позиции кодового замка и ручки-скобы!";
        }
    }
    private void CheckForErrors()
    {
        if (param.DPM & param.EIS)
        {
            if (param.Porog.Kod == 0)
                Errors = "Дверь EIS не может быть без порога. ";
            //else if (param.Porog.Kod == 2)
            //{
            //    Errors = "Дверь EIS не может быть с выпадающим порогом. ";
            //}
            else if (param.Porog.Kod == 14)
                Errors = "Дверь EIS не может быть с 14 порогом. ";
        }
        if (Passivka != null)
        {
            if (param.Porog.Kod == 2)
            {
                var minLength = float.Parse(ini.ReadKey("Porog", "DM_POR_VIPAD_LENGTH_MIN"));
                if (param.RuchkaPS[0].Kod == (int) RuchkaNames.PB_1300 || 
                    param.RuchkaPS[0].Kod == (int)RuchkaNames.PB_1700A || 
                    param.RuchkaPS[0].Kod == (int)RuchkaNames.АП_DoorLock)
                {
                    if (Passivka.Width < minLength + 60)
                        Errors = "Выпадающий порог нельзя установить в створку с врезной антипаникой и шириной меньше " + (minLength + 60) + " мм. ";
                }
                else if (Passivka.Width < minLength)
                    Errors = "Выпадающий порог нельзя установить в створку меньше " + minLength + " мм. ";
            }
            if (param.RuchkaPS[0].Kod == (short)RuchkaNames.PB_1300 & Passivka.Width < 439)
                Errors = "Антипанику нельзя установить на створку меньше 439 мм. ";
            if ((param.RuchkaPS[0].Kod == (short)RuchkaNames.PB_1700A | param.RuchkaPS[0].Kod == (short)RuchkaNames.PB_1700C) & Passivka.Width < 300)
                Errors = "Антипанику нельзя установить на створку меньше 300 мм. ";
            if (Passivka.Width < float.Parse(ini.ReadKey("Gabarite", "DM_PASSIV_WIDTH_MIN")))
                Errors = "Пассивная створка = " + Passivka.Width + ", что меньше " + ini.ReadKey("Gabarite", "DM_PASSIV_WIDTH_MIN") + " мм. ";
            if (param.Kod == 3 & Passivka.Width == 0)
                Errors = "(MAX) одностворчатым быть не может! ";
        }
        else
        {
            if (param.Kod == 3)
                Errors = "(MAX) одностворчатым быть не может! ";
        }
        if (cons.CompareKod(param.Kod, "ДМ-1"))
        {
            int minH = param.DPM ? int.Parse(ini.ReadKey("Gabarite", "DPM_HEIGHT_MIN")) : int.Parse(ini.ReadKey("Gabarite", "DM_HEIGHT_MIN"));
            int maxH = param.DPM ? int.Parse(ini.ReadKey("Gabarite", "DPM_HEIGHT_MAX")) : int.Parse(ini.ReadKey("Gabarite", "DM_HEIGHT_MAX"));
            int minW = param.DPM ? int.Parse(ini.ReadKey("Gabarite", "DPM1_WIDTH_MIN")) : int.Parse(ini.ReadKey("Gabarite", "DM1_WIDTH_MIN"));
            int maxW = param.DPM ? int.Parse(ini.ReadKey("Gabarite", "DPM1_WIDTH_MAX")) : int.Parse(ini.ReadKey("Gabarite", "DM1_WIDTH_MAX"));
            if(param.Height < minH)
                Errors = "Дверь слишком низкая (не менее " + minH + "). ";
            if (param.Height > maxH)
                Errors = "Превышена максимальная высота изделия (не более " + maxH + "). ";
            if(param.Width < minW)
                Errors = "Дверь слишком узкая (не менее " + minW + "). ";
            if (param.Width > maxW)
                Errors = "Превышена максимальная ширина изделия (не более " + maxW + "). ";
        }
        if (cons.CompareKod(param.Kod, "ДМ-2"))
        {
            int minH = param.DPM ? int.Parse(ini.ReadKey("Gabarite", "DPM_HEIGHT_MIN")) : int.Parse(ini.ReadKey("Gabarite", "DM_HEIGHT_MIN"));
            int maxH = param.DPM ? int.Parse(ini.ReadKey("Gabarite", "DPM_HEIGHT_MAX")) : int.Parse(ini.ReadKey("Gabarite", "DM_HEIGHT_MAX"));
            int minW = param.DPM ? int.Parse(ini.ReadKey("Gabarite", "DPM2_WIDTH_MIN")) : int.Parse(ini.ReadKey("Gabarite", "DM2_WIDTH_MIN"));
            int maxW = param.DPM ? int.Parse(ini.ReadKey("Gabarite", "DPM2_WIDTH_MAX")) : int.Parse(ini.ReadKey("Gabarite", "DM2_WIDTH_MAX"));
            if (param.Height < minH)
                Errors = "Дверь слишком низкая (не менее " + minH + "). ";
            if (param.Height > maxH)
                Errors = "Превышена максимальная высота изделия (не более " + maxH + "). ";
            if (param.Width < minW)
                Errors = "Дверь слишком узкая (не менее " + minW + "). ";
            if (param.Width > maxW)
                Errors = "Превышена максимальная ширина изделия (не более " + maxW + "). ";
        }
        if (param.Kod == 3 & param.Width > 2300)
            Errors = "Превышена максимальная ширина изделия (не более 2300). ";
        if (param.Kod != 21 & Aktivka.Width > 1120)
            Errors = "Превышена максимальная ширина активной створки (не более 1120). ";
        if (param.Nalichniki[1] > 0 & param.Porog.Kod > 5)
            Errors = "Порог " + param.Porog.Kod + " мм и наличник снизу! Такого не может быть! ";
    }

    private void OnProblem(string message)
    {
        Problems = message;
    }
    private void OnError(string message)
    {
        Errors = message;
    }

    //=======================================|Вывод информации|====================================
    //-----строка таблицы конструирования
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
    public short Kod
    {
        get { return _Kod.Value; }
    }

    public string TypeKostruct
    {
        get => _Kod.Name;
    }
    public string Errors
    {
        get => string.IsNullOrEmpty(_ERRORS) ? "" : _ERRORS;
        set => _ERRORS += value;
    }
    public string Problems
    {
        get => string.IsNullOrEmpty(_PROBLEMS) ? "" : _PROBLEMS;
        set => _PROBLEMS += value;
    }

    public short Height
    {
        get { return param.Height; }
    }
    public short Width
    {
        get { return param.Width; }
    }
    public string Name(short index)
    {
        switch (index)
        {
            case 1:
            case 2:
                return _name;
            case 3:
                return NameDob;
            default:
                return Korobka.Name(index);
        }
    }

    public bool IsDobor
    {
        get { return param.Dobor; }
    }
    public short Dobor_Length(Raspolozhenie pos)
    {
        if (pos == Raspolozhenie.Верх | pos == Raspolozhenie.Ниж)
        {
            return (short)(param.Width + 6);
        }
        else
        {
            return (short)(param.Height + 2);
        }
    }
    public short Dobor_Glubina
    {
        get { return (short)(param.DoborPar.Glubina + 10); }
    }
    public double[] Dobor_Nalichnik_Razv
    {
        get 
        {
            double[] arr = new double[4];
            for (int i = 0; i < 4; i++)
            {
                if(param.DoborPar.Nalicnik[i] > 0)
                    arr[i] = param.DoborPar.Nalicnik[i] + 5.6;
                else
                    arr[i] = param.DoborPar.Nalicnik[i] + 25.6;
            } 
            return arr; 
        }
    }
    public short[] Dobor_Nalichnik
    {
        get
        {
            return param.DoborPar.Nalicnik;
        }
    }

    public Otkrivanie Otkrivanie
    {
        get { return param.Otkrivanie.Value; }
    }
    public double Stvorka_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return Aktivka.Hight;
        }
        else
        {
            if (!(Passivka == null))
            {
                return Passivka.Hight;
            }
            else
            {
                return 0;
            }
        }
    }
    public double Stvorka_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return Aktivka.Width;
        }
        else
        {
            if (!(Passivka == null))
            {
                return Passivka.Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public double LicevoyList_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return Aktivka.LList_Hight;
        }
        else
        {
            if (!(Passivka == null))
            {
                return Passivka.LList_Hight;
            }
            else
            {
                return 0;
            }
        }
    }
    public double LicevoyList_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return Aktivka.LList_Width;
        }
        else
        {
            if (!(Passivka == null))
            {
                return Passivka.LList_Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public double VnutrenniyList_Height(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return Aktivka.VList_Hight;
        }
        else
        {
            if (!(Passivka == null))
            {
                return Passivka.VList_Hight;
            }
            else
            {
                return 0;
            }
        }
    }
    public double VnutrenniyList_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return Aktivka.VList_Width;
        }
        else
        {
            if (!(Passivka == null))
            {
                return Passivka.VList_Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public short LicevoyList_OtPola
    {
        get { return Aktivka.LListOtPola; }
    }
    public short VnutrenniyList_OtPola
    {
        get { return Aktivka.VListOtPola; }
    }
    public bool IsPassivka
    {
        get { return !(Passivka == null); }
    }
    public short Vstavka_Width(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
            return Aktivka.Vstavka_Width;
        else
            return Passivka.Vstavka_Width;
    }
    public double VirezPoPorogu_Height
    {
        get
        {
            if (!(Passivka == null))
            {
                return Passivka.VirezPoPorogu_Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public double VirezPoPorogu_Width
    {
        get
        {
            if (!(Passivka == null))
            {
                return Passivka.VirezPoPorogu_Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public short LeftGib(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return Aktivka.LeftGib;
        }
        else
        {
            if (!(Passivka == null))
            {
                return Passivka.LeftGib;
            }
            else
            {
                return 0;
            }
        }
    }
    public short RightGib(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return Aktivka.RightGib;
        }
        else
        {
            if (!(Passivka == null))
            {
                return Passivka.RightGib;
            }
            else
            {
                return 0;
            }
        }
    }
    public short UpGib(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return Aktivka.UpGib;
        }
        else
        {
            if (!(Passivka == null))
            {
                return Passivka.UpGib;
            }
            else
            {
                return 0;
            }
        }
    }
    public short KompensVirez
    {
        get { return Aktivka.KompensVirez; }
    }
    public bool IsDownGib
    {
        get { return Aktivka.IsDownGib; }
    }
    public bool IsDownPritvor
    {
        get { return param.Pritvor; }
    }
    public bool IsSekPloskost(Stvorka stvorka)
    {
        if (stvorka == Stvorka.Активная)
        {
            return Aktivka.IsSekPl;
        }
        else
        {
            if (!(Passivka == null))
            {
                return Passivka.IsSekPl;
            }
            else
            {
                return false;
            }
        }
    }

    public bool IsGND(short index)
    {
        if (index == 1 | index == 2)
        {
            return Aktivka.IsGND;
        }
        else if (index == 4 | index == 5)
        {
            return Korobka.GND(index);
        }
        else
        {
            return false;
        }
    }
    public bool IsKabelKanal(short index)
    {
        
        if (index == 4 | index == 5)
        {
            return Korobka.KabelKanal(index);
        }
        else if (index == 1)
        {
            return Aktivka.IsKabelKanal;
        }
        else if (index == 2)
        {
            return Passivka.IsKabelKanal;
        }
        else
        {
            return false;
        }
    }
    public short VirezPodKvadrat_Count
    {
        get { return (short)param.Kvadrat; }
    }
    
    public short SPorog_OtKraya
    {
        get => Aktivka.SPorog_OtKraya;
    }
    public short Nalichnik(Raspolozhenie pos)
    {
        return Korobka.Nalichnik(((short)pos));
    }
    public short Stoyka_Type(Raspolozhenie pos)
    {
        return Korobka.TypeStoyki(pos);
    }
    public bool IsVipadPorog
    {
        get { return param.Porog.Kod == 2; }
    }
    public bool IsPorogNestandart
    {
        get { return Korobka.IsPorogNestandart; }
    }
    public bool IsObrezkaNalichnika(Raspolozhenie pos)
    {
        return Korobka.IsObrezkaNalichnika(pos);
    }
    public bool IsAnkerInPritoloka
    {
        get { return param.AMak; }
    }
    public double NalichnikStoyki(Raspolozhenie pos)
    {
        return Korobka.NalichnikStoyki(pos);
    }
    public short HeightStoyki(Raspolozhenie pos)
    {
        return Korobka.HightStoyki(pos);
    }
    public double GabaritStoyki(Raspolozhenie pos)
    {
            if (Korobka.IsStoyka(pos)) return Korobka.GabaritStoyki(pos);
            else return 0;
    }
    public double GlubinaStoyki(Raspolozhenie pos)
    {
        return Korobka.GlubinaStoyki(pos);
    }
    public double StikovkaStoyki(Raspolozhenie pos)
    {
        return Korobka.StikovkaStoyki(pos);
    }
    public double ZanizhenieStoyki(Raspolozhenie pos)
    {
        return Korobka.ZanizhenieStoyki(pos);
    }
    public short UpZaglushkaNSStoyki(Raspolozhenie pos)
    {
        return Korobka.UpZaglushkaNSStoyki(pos);
    }
    public short DownZaglushkaNSStoyki(Raspolozhenie pos)
    {
        return Korobka.DownZaglushkaNSStoyki(pos);
    }
    public double DownZanizhenieStoyki(Raspolozhenie pos)
    {
        return Korobka.DownZanizhenieStoyki(pos);
    }
    public double RazvertkaStoyki(Raspolozhenie pos)
    {
        return Korobka.RazvertkaStoyki(pos);
    }

    public double DAnker1Stoyki(Raspolozhenie pos)
    {
        return Korobka.DAnker1Stoyki(pos);
    }
    public double DAnker2Stoyki(Raspolozhenie pos)
    {
        return Korobka.DAnker2Stoyki(pos);
    }
    public double AnkerOtKraya(Raspolozhenie pos)
    {
        return Korobka.AnkerOtKraya(pos);
    }
    public short AnkerOtPola(short num)
    {
        return Korobka.AnkerOtPola(num); 
    }

    public bool IsOkno(short num)
    {
        return Okna[num] != null; 
    }
    public short Okno_Height(short num, short pos)
    {
        if (IsOkno(num))
        {
            if (pos == 0)
            {
                return Okna[num].HVirLL;
            }
            else
            {
                return Okna[num].HVirVL;
            }
        }
        else
        {
            return 0;
        }
    }
    public short Okno_Width(short num, short pos)
    {
        if (IsOkno(num))
        {
            if (pos == 0)
            {
                return Okna[num].WVirLL;
            }
            else
            {
                return Okna[num].WVirVL;
            }
        }
        else
        {
            return 0;
        }
    }
    public double Okno_OtKraya(short num, short pos)
    {
        if (IsOkno(num))
        {
            if (pos == 0)
            {
                return Okna[num].OtCrayaLL;
            }
            else
            {
                return Okna[num].OtCrayaVL;
            }
        }
        else
        {
            return 0;
        }
    }
    public double Okno_OtPola(short num)
    {
        if (IsOkno(num))
        {
            return Okna[num].OtPola;
        }
        else
        {
            return 0;
        }
    }

    public bool IsReshetka(short num)
    {
        return !(Reshetki[num] == null);
    }
    public eReshetka Reshetka_Type(short num)
    {
            if (IsReshetka(num))
            {
                return Reshetki[num].Type;
            }
            else
            {
                return 0;
            }
    }
    public short Reshetka_Height(short num)
    {
        if (IsReshetka(num))
        {
            return Reshetki[num].Hight;
        }
        else
        {
            return 0;
        }
    }
    public short Reshetka_Width(short num)
    {
        if (IsReshetka(num))
        {
            return Reshetki[num].Width;
        }
        else
        {
            return 0;
        }
    }
    public double Reshetka_OtKraya(short num)
    {
        if (IsReshetka(num))
        {
            return Reshetki[num].OtKraya;
        }
        else
        {
            return 0;
        }
    }
    public short Reshetka_OtPola(short num)
    {
        if (IsReshetka(num))
        {
            return Reshetki[num].OtPola;
        }
        else
        {
            return 0;
        }
    }
    public short Reshetka_Virezi_Count(short num)
    {
        if (IsReshetka(num))
        {
            return Reshetki[num].Vir;
        }
        else
        {
            return 0;
        }
    }
    public double Reshetka_Virezi_Otstup(short num)
    {
        if (IsReshetka(num))
        {
            return Reshetki[num].Otstup;
        }
        else
        {
            return 0;
        }
    }

    public ZamokDatas[] Zamki
    {
        get
        {
            return Furniture.Zamki;
        }
    }
    public ZamokDatas Zamok(short num)
    {
        return Furniture.Zamok(num);
    }
    public short Zamok_Kod(short num, short konf)
    {
        if (konf == 1 | konf == 2 | konf == 6)
        {
            return Furniture.Zamok_Index(num);
        }
        else if (konf == 4)
        {
            return Korobka.Zamok_Kod(num, Raspolozhenie.Лев);
        }
        else if (konf == 5)
        {
            return Korobka.Zamok_Kod(num, Raspolozhenie.Прав);
        }
        else
        {
            return 0;
        }
    }
    public double Zamok_Otstup(short num)
    {
            switch (param.Otkrivanie.Value)
            {
                case Otkrivanie.Правое:
                case Otkrivanie.ПравоеВО:
                    return Furniture.Zamok_Otstup(num, Korobka.TypeStoyki(Raspolozhenie.Лев));
                default:
                    return Furniture.Zamok_Otstup(num, Korobka.TypeStoyki(Raspolozhenie.Прав));
            }
    }
    public double Zamok_OtKraya(short num, short pos)
    {
        if (Furniture.IsZamok(num))
        {
            return Furniture.Zamok_OtKraya(num, pos);
        }
        else
        {
            return 0;
        }
    }
    public double Zamok_OtTela(short num)
    {
        return Furniture.Zamok_OtTela(num);
    }
    public int Zamok_OtPola(short num)
    {
        return Furniture.Zamok_OtPola(num);
    }
    public double Zamok_Otvetka_OtPola(short num)
    {
        return Furniture.Zamok_Otvetka_OtPola(num);
    }
    public string Zamok_Name(short num)
    {
        return Furniture.Zamok_Name(num);
    }
    public string[] Zamok_VirezNames(short num)
    {
        return Furniture.Zamok_VirezNames(num);
    }
    public string[] Zamok_SketchNames(short num)
    {
        return Furniture.Zamok_SketchNames(num);
    }

    //public double Antipanika_OtLeftKrayaVA
    //{
    //    get { return Furniture.Antipanika_OtLeftKrayaVA; }
    //}
    //public double Antipanika_OtLeftKrayaVP
    //{
    //    get { return Furniture.Antipanika_OtLeftKrayaVP; }
    //}
    //public double Antipanika_OtRightKrayaVP
    //{
    //    get { return Furniture.Antipanika_OtRightKrayaVP; }
    //}
    //public double Antipanika_Zashelka_OtPola
    //{
    //    get
    //    {
    //        if (Furniture.Zamok(1) == 107 | Furniture.Zamok(1) == 108)
    //        {
    //            if (Korobka.TypeStoyki(Raspolozhenie.Ниж) == 14)
    //            {
    //                return 41.5;
    //            }
    //            else
    //            {
    //                return 51.5;
    //            }
    //        }
    //        else
    //        {
    //            return 0;
    //        }
    //    }
    //}

    public double Kodoviy_OtShir
    {
        get { return Furniture.Kodoviy_OtShir; }
    }
    public string Kodoviy_Name
    {
        get { return Furniture.Kodoviy_Name; }
    }
    public double Kodoviy_OtKraya(short pos)
    {
        return Furniture.Kodoviy_OtKraya(pos);
    }
    public double Kodoviy_OtTela
    {
        get { return Furniture.Kodoviy_OtTela; }
    }
    public short Kodoviy_OtPola
    {
        get { return Furniture.Kodoviy_OtPola; }
    }
    public short Kodoviy_Kod(short konf)
    {
        if (konf == 1 | konf == 2)
        {
            return (short)Furniture.Kodoviy_Type;
        }
        else if (konf == 4)
        {
            return Korobka.ZamokKodoviy(Raspolozhenie.Лев);
        }
        else if (konf == 5)
        {
            return Korobka.ZamokKodoviy(Raspolozhenie.Прав);
        }
        else
        {
            return 0;
        }
    }

    public bool IsRuchka(short stvorka, short num)
    {
        return Furniture.IsRuchka(stvorka, num);
    }
    public short Ruchka_Kod(short stvorka, short num)
    {
        return Furniture.Ruchka_Kod(stvorka, num);
    }
    public double Ruchka_OtKraya(short stvorka, short num, short pos)
    {
        return Furniture.Ruchka_OtKraya(stvorka, num, pos);
    }
    public double Ruchka_OtLeftKraya(short stvorka, short num, short pos)
    {
        return Furniture.Ruchka_OtLeftKraya(stvorka, num, pos);
    }
    public short Ruchka_OtPola(short stvorka, short num)
    {
        return Furniture.Ruchka_OtPola(stvorka, num);
    }
    public short Ruchka_Mezhosevoe(short stvorka, short num)
    {
        return Furniture.Ruchka_Mezhosevoe(stvorka, num);
    }
    public string Ruchka_VirezName(short stvorka, short num)
    {
        return Furniture.Ruchka_VirezName(stvorka, num);
    }
    public string Ruchka_SketchName(short stvorka, short num)
    {
        return Furniture.Ruchka_SketchName(stvorka, num);
    }

    public short Zadvizhka_Kod(short konf)
    {
            if (konf == 1 | konf == 2)
            {
                return Furniture.Zadvizhka_Kod(0);
            }
            else if (konf == 4)
            {
                return Korobka.Zadvizhka(Raspolozhenie.Лев);
            }
            else if (konf == 5)
            {
                return Korobka.Zadvizhka(Raspolozhenie.Прав);
            }
            else
            {
                return 0;
            }
    }
    public double Zadvizhka_OtKrayaVA
    {
        get { return Furniture.Zadvizhka_OtKpayaVA(0); }
    }
    public double Zadvizhka_Vertushok_OtKraya
    {
        get
        {
            if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
                return Aktivka.LList_Width + Aktivka.VList_Width + 100 - Furniture.Zadvizhka_Vertushok_OtKraya(0);
            return Aktivka.LList_Width - Furniture.Zadvizhka_Vertushok_OtKraya(0);
        }
    }
    public double Zadvizhka_Otstup(short stoykaType)
    {
        return Furniture.Zadvizhka_Otstup(0, stoykaType);
    }
    public short Zadvizhka_OtPola
    {
        get { return Furniture.Zadvizhka_OtPola(0); }
    }

    public bool IsSdvigoviy => Furniture.IsSdvigoviy();
    public SdvigoviyData Sdvigoviy => Furniture.Sdvigoviy;

    public bool IsGlazok(short num)
    {
        return Furniture.IsGlazok(num);
    }
    public double Glazok_OtKraya(short num, short pos)
    {
        if (Furniture.Glazok_Raspolozhenie(num) == GlazokRaspolozhenie.По_центру)
        {
            if (pos == 0)
            {
                if (param.Thick_LL == 2)
                {
                    return Aktivka.LList_Width / 2;
                }
                else
                {
                    return Aktivka.LList_Width / 2;
                }
            }
            else
            {
                if (param.Thick_VL == 2)
                {
                    return Passivka is null ? Aktivka.VList_Width / 2 : ((Aktivka.VList_Width + k62 + (k70/2)) / 2) - (52 + k62/2);
                }
                else
                {
                    return Aktivka.VList_Width / 2;
                }
            }
        }
        else
        {
            return Furniture.Zamok_OtKraya(1, pos);
        }
    }
    public double Glazok_OtPola(short num)
    {
        if (IsGlazok(num))
        {
            return Furniture.Glazok_OtPola(num);
        }
        else
        {
            return 0;
        }
    }

    public short Protivos_Count
    {
        get { return Furniture.Protivos_Count; }
    }
    public double Protivos_OtKraya
    {
        get { return Furniture.Protivos_OtKraya; }
    }
    public short Protivos_OtPola(short num)
    {
        return Furniture.Protivos_OtPola(num);
    }

    public bool IsUpTShpingalet
    {
        get
        {
            if (!(Passivka == null))
            {
                return Passivka.IsUpTShpingalet;
            }
            else
            {
                return false;
            }
        }
    }
    public bool IsDownTShpingalet
    {
        get
        {
            if (!(Passivka == null))
            {
                return Passivka.IsDownTShpingalet;
            }
            else
            {
                return false;
            }
        }
    }
    public bool IsTorcShpingalet(short num)
    {
        return Furniture.IsTorcShpingalet(num);
    }
    public bool IsOtvetkaTorcShpin(Raspolozhenie pos)
    {
        return Korobka.OtvetkaTorcShpin(pos);
    }
    public short TorcSpingalet_Count
    {
        get { return Furniture.TorcShpingalet_Count; }
    }
    public double TorcShpingalet_OtKraya
    {
        get { return Furniture.TorcShpingalet_OtKraya; }
    }
    public double TorcShpingalet_Otvetka_Diam
    {
        get { return Furniture.TorcShpingalet_Otvetka_Diam; }
    }
    public double TorcShpingalet_Otvetka_OtKraya
    {
        get { return Furniture.TorcShpingalet_Otvetka_OtKraya; }
    }
    public double TorcShpingalet_Otvrtka_Otstup(short i)
    {
        return Furniture.TorcShpingalet_Otvetka_Otstup(i);
    }

    public bool NSasTS => param.NSasTS;
    public double TPWidth
    {
        get
        {
            if (k62 > 0) return 60;
            if (k70 > 0) return 68;
            return 51;
        }
    }

    public double TPOtKraya
    {
        get
        {
            if (k62 > 0) return 25.4;
            if (k70 > 0) return 31;
            return 20.89;
        }
    }

    public bool IsAPanOnPassiv
    {
        get
        {
            if (param.RuchkaPS.Length > 0)
                foreach (RuchkaParam rp in param.RuchkaPS)
                    if (rp.Kod == 11 | rp.Kod == 12 | rp.Kod == 14)
                        return true;
            return false;
        }
    }
    public float APanOtNiza
    {
        get
        {
            return Furniture.APanOtNiza;
        }
    }
    public bool IsOtvAntipan(short pos)
    {
        return Furniture.IsOtvAntipan(pos);
    }
    public double OtvAntipan_Diam(short pos)
    {
        if (IsOtvAntipan(pos))
            return Furniture.OtvAntipan_Diam(pos);
        else
            return 0;
    }
    public double OtvAntipan_OtKraya(short pos)
    {
        return Furniture.OtvAntipan_OtKraya(pos);
    }
    public double OtvAntipan_Otstup(short pos)
    {
        return Furniture.OtvAntipan_Otstup(pos); 
    }

    public bool IsFramuga(Raspolozhenie pos)
    {
        if (Framugi != null & Framugi.Length > 0) return Framugi[(short)pos] != null;
        else return false;
    }
    public Framuga Framuga(Raspolozhenie pos)
    {
        if (IsFramuga(pos)) return Framugi[(short)pos];
        else return null;
    }

    public bool IsTermoblock(short num) => 
        Furniture.IsTermoblock(num);

    public TermoblockDatas GetTermoblock(short num) =>
        Furniture.GetTermoblock(num);
}
