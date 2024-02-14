using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public class Constants                                                      //Класс, хранящий в себе все глобальные константы
{
    private readonly IniFile ini;

    //==========================================================================================================================
    //--------------|Глобальные|------------------------------------------------------------------------------------------------
    //==========================================================================================================================

    public readonly int HL;                                                 //высота листа металла
    public readonly int WL;                                                 //ширина листа металла
    public readonly int TORCOVKA;                                           //величина торцовки листов с двух сторон листа в сумме
    public readonly int LIST_HIGHT;                                         // высота листа после торцовки
    public readonly int LIST_WIDTH;                                         //ширина листа после торцовки
    public readonly double[] LIST_THICKS = {0, 0.8, 1, 1.2, 1.4, 1.7, 2 };

    public readonly bool ST62;                                              //Активация технологии толщины полотна 62 мм

    //Размеры расположения фурнитуры от пола
    public readonly int RUCHKA_OT_POLA;                                     //Расположение ручки (нижнего замка) от пола
    public readonly int GLAZOK_OT_POLA;                                     //Расположение глазка от пола
    public readonly bool GLAZOK_PO_CENTRU;                                  //Расположение глазка по центру полотна
    public readonly int ZADVIZHKA_OT_POLA;                                  //Расположение задвижки от пола
    public readonly int ZAMOK2_OT_POLA;                                     //Расположение верхнего замка от пола
    public readonly int KODOVIY_OT_POLA;                                    //Расположение кодового замка от пола

    //-----коды изделий----------------------------------
    public readonly List<StKod> KOD = new List<StKod>();

    public readonly List<short> LIM_KALIT_H = new List<short>();
    public readonly List<short> LIM_KALIT_W = new List<short>();

    //-----деректории-----------------------------------
    //public readonly string DIR_MAIN = Environment.CurrentDirectory;       //корневая директория
    public readonly string DIR_MAIN;                                        //корневая директория
    public readonly string DIR_CONS_GLOBAL;                                 //директория глобальных констант
    public readonly string DIR_CONS_FURNIT;                                 //директория констант фурнитуры
    public readonly string DIR_CONS_ZAMOK;                                  //директория констант замков
    public readonly string DIR_WORK_TMP;                                    //рабочая директория для файлов сохранений
    public readonly string DIR_TEMPLATES;                                   //рабочая директория для файлов сохранений
    public readonly string DIR_KV_BASE;                                     //директория базы файлов квартирных дверей

    public Constants() {
        var dir = Directory.GetCurrentDirectory();
        var fi = new FileInfo(dir + "\\Settings.ini");

        if (fi.Exists) 
        {
            var tmpIni = new IniFile(dir + "\\Settings.ini");
            DIR_MAIN = tmpIni.ReadKey("Directoryes", "DIR_LIB");
            DIR_KV_BASE = tmpIni.ReadKey("Directoryes", "DIR_KVD");
        }
        else
            DIR_MAIN = @"\\nas\ГК СТАЛЛ-ДООРС\отдел конструкторский\Автоматическая_обработка_заказов\SDK_ClassLibrary";

        DIR_CONS_GLOBAL = DIR_MAIN + @"\Константы";
        DIR_CONS_FURNIT = DIR_CONS_GLOBAL + @"\Фурнитура";
        DIR_CONS_ZAMOK = DIR_CONS_FURNIT + @"\Замки";
        DIR_WORK_TMP = DIR_MAIN + @"\WorkDir";
        DIR_TEMPLATES = DIR_CONS_GLOBAL + @"\Шаблоны";

        //MessageBox.Show(dir);

        ini = new IniFile(DIR_CONS_GLOBAL + @"\Global.ini");

        HL = int.Parse(ini.ReadKey("Global", "HL"));
        WL = int.Parse(ini.ReadKey("Global", "WL"));
        TORCOVKA = int.Parse(ini.ReadKey("Global", "TORCOVKA"));
        LIST_HIGHT = HL - TORCOVKA;
        LIST_WIDTH = WL - TORCOVKA;

        ST62 = bool.Parse(ini.ReadKey("Global", "ST62"));
        RUCHKA_OT_POLA = int.Parse(ini.ReadKey("Global", "RUCHKA_OT_POLA"));
        GLAZOK_OT_POLA = int.Parse(ini.ReadKey("Global", "GLAZOK_OT_POLA"));
        GLAZOK_PO_CENTRU = bool.Parse(ini.ReadKey("Global", "GLAZOK_PO_CENTRU"));
        ZADVIZHKA_OT_POLA = int.Parse(ini.ReadKey("Global", "ZADVIZHKA_OT_POLA"));
        ZAMOK2_OT_POLA = int.Parse(ini.ReadKey("Global", "ZAMOK2_OT_POLA"));
        KODOVIY_OT_POLA = int.Parse(ini.ReadKey("Global", "KODOVIY_OT_POLA"));

        for (var i = 0; i <= 100; i++)
        {
            if (!ini.KeyExists("Kod", i.ToString())) 
                continue;

            var kod = new StKod
            {
                Value = short.Parse(ini.ReadKey("Kod", i.ToString())),
                Name = ini.ReadKey("Kod", i + "_S"),
                FilePref = ini.ReadKey("Kod", i + "_F")
            };

            KOD.Add(kod);
        }

        var iniDVM = new IniFile(DIR_CONS_GLOBAL + "\\DVM.ini");

        for (var i=1; i<=10; i++)
        {
            if (iniDVM.KeyExists("Ogranicheniya", "KALIT_H_" + i)) 
                LIM_KALIT_H.Add(short.Parse(iniDVM.ReadKey("Ogranicheniya", "KALIT_H_" + i)));
            if (iniDVM.KeyExists("Ogranicheniya", "KALIT_W_" + i))
                LIM_KALIT_W.Add(short.Parse(iniDVM.ReadKey("Ogranicheniya", "KALIT_W_" + i)));
        }
    }

    public bool CompareKod(short val, string str) 
    {
        var tmp = SearchKod(str);

        return tmp.Length != 0 && 
               tmp.Any(kod => kod == val);
    }
    public bool CompareKod(short val, string str1, string str2) 
    {
        var tmp = SearchKod(str1, str2);

        return tmp.Length > 0 && 
               tmp.Any(kod => kod == val);
    }
    public short[] SearchKod(string str) 
    {
        return (from kod in KOD 
            where kod.Name.IndexOf(str, StringComparison.Ordinal) >= 0 
            select kod.Value)
            .ToArray();
    }
    public short[] SearchKod(string str1, string str2) 
    {
        return (from kod in KOD 
            where kod.Name.IndexOf(str1, StringComparison.Ordinal) >= 0 
            where kod.Name.IndexOf(str2, StringComparison.Ordinal) >= 0 
            select kod.Value)
            .ToArray();
    }
    public short KodFromString(string str) 
    {
        if (string.IsNullOrEmpty(str)) return 0;
        
        if (short.TryParse(str, out var tmp))
            return (from k in KOD 
                where k.Value == tmp 
                select k.Value)
                .FirstOrDefault();

        return (from k in KOD 
            where k.Name.Equals(str) 
            select k.Value)
            .FirstOrDefault();
    }
    public string KodAsString(short val)
    {
        foreach (var kod in KOD
                     .Where(k => k.Value == val)) 
            return kod.Name;
        return "Нет";
    }
    public bool IsValidKod(string str)
    {
        return KodFromString(str) > 0;
    }
    public string FilePrefByKod(short val)
    {
        foreach (var kod in KOD
                     .Where(k => k.Value == val)) 
            return kod.FilePref;

        return "";
    }
    public StKod GetKOD(short val)
    {
        foreach (var k in KOD
                     .Where(k => k.Value == val)) 
            return k;

        return new StKod {Value = 0, Name = "", FilePref = ""};
    }
    public List<string> GetKodNames() {
        var str = new List<string>{"Нет"};

        str.AddRange(KOD
            .Select(kod => kod.Name));

        return str;
    }
    public double ListThikcByIndex(short i) 
    {
        if (i < LIST_THICKS.Length) 
            return LIST_THICKS[i];
        return 0;
    }
    public short ListThickIndex(double thick) 
    {
        for (short i = 0; i < LIST_THICKS.Length; i++) 
            if (Math.Abs(LIST_THICKS[i] - thick) < 0.00001) 
                return i;

        return - 1;
    }
    public string[] ListThikcsAsStr() 
    {
        var listThickStr = new string[LIST_THICKS.Length];

        for (var i = 0; i < LIST_THICKS.Length; i++) 
            listThickStr[i] = LIST_THICKS[i]
                .ToString(CultureInfo.CurrentCulture);

        return listThickStr;
    }
    public bool IsValidListThick(double val)
    {
        return LIST_THICKS
            .Any(thick => Math.Abs(thick - val) < 0.00001);
    }
    public bool IsValidPorog(string str)
    {
        if (string.IsNullOrEmpty(str)) return false;
        
        if (short.TryParse(str, out var tmp))
            return Enum.GetValues(typeof(DM_PorogNames))
                .Cast<short>()
                .Any(val => val == tmp);

        return Enum.GetNames(typeof(DM_PorogNames))
            .Any(s => s.Equals(str));
    }
    public short PorogFromString(string str)
    {
        if (string.IsNullOrEmpty(str)) return 0;
        
        if (short.TryParse(str, out var tmp))
            return Enum
                .GetValues(typeof(DM_PorogNames))
                .Cast<short>()
                .FirstOrDefault(val => val == tmp);
        
        if (Enum
            .GetNames(typeof(DM_PorogNames))
            .Any(s => s.Equals(str)))
            return (short)Enum.Parse(typeof(DM_PorogNames), str);

        return 0;
    }
    public string[] СompatPorogsByKod(string kod)
    {
        if (!IsValidKod(kod)) 
            return Array.Empty<string>();

        if (CompareKod(KodFromString(kod), "ДМ"))
            return Enum.GetNames(typeof(DM_PorogNames));
        if (CompareKod(KodFromString(kod), "ОДЛ"))
            return Enum.GetNames(typeof(ODL_PorogNames));
        return CompareKod(KodFromString(kod), "ВМ") 
            ? Enum.GetNames(typeof(VM_PorogNames)) 
            : Array.Empty<string>();
    }
    public bool IsValidZamok(string str)
    {
        if (string.IsNullOrEmpty(str)) 
            return false;

        if (short.TryParse(str, out var tmp))
            return Enum
                .GetValues(typeof(DM_Zamok1Names))
                .Cast<short>()
                .Any(val => val == tmp);
        
        return Enum
            .GetNames(typeof(DM_Zamok1Names))
            .Any(s => s.Equals(str));
    }
    public bool IsValidRuchka(string str)
    {
        if (string.IsNullOrEmpty(str)) 
            return false;

        if (short.TryParse(str, out var tmp))
            return Enum
                .GetValues(typeof(RuchkaNames))
                .Cast<object>()
                .Any(val => (short) val == tmp);
        
        return Enum
            .GetNames(typeof(RuchkaNames))
            .Any(s => s.Equals(str));
    }
    
}

public struct StKod {
    public short Value;
    public string Name;
    public string FilePref;
}

public enum DM_Zamok1Names {
    Нет = 0,
    ПП = 1,
    Просам_ЗВ_4 = 3,
    Фуаро_900 = 4,
    Просам_ЗВ_8 = 5,
    Меттем_842 = 6,
    Гардиан_12_11 = 9,
    Гардиан_30_01 = 11,
    Apecs_R_0002_CR = 12,
    Apecs_T_52 = 13,
    Бордер_ЗВ8_6 = 14,
    Гардиан_32_11 = 15,
    Гардиан_10_01 = 16,
    Гардиан_12_01 = 17,
    Гардиан_35_11 = 18,
    Гардиан_30_11 = 19,
    Гардиан_32_01 = 21,
    Apecs_30_R = 22,
    Crit_7_RPM = 23,
    ECO_GBS_81 = 25
}
public enum DM_Zamok2Names {
    Нет = 0,
    Просам_ЗВ_8 = 5,
    Меттем_842 = 6,
    Гардиан_30_01 = 11,
    Apecs_R_0002_CR = 12,
    Бордер_ЗВ8_6 = 14,
    Гардиан_10_01 = 16,
    Гардиан_12_01 = 17
}
public enum LM_ZamokNames
{
    Нет = 0,
    ПП_стандарт = 1,
    ПП_без_цилиндра = 2,
    Просам_ЗВ_8 = 5,
    Меттем_842 = 6,
    ПП_без_ручки = 20
}
public enum VM_ZamokNames
{
    Нет = 0,
    ПП_стандарт = 1
}
public enum KT_Zamok1Names
{
    Нет = 0,
    Гардиан_32_11 = 15
}
public enum KT_Zamok2Names
{
    Нет = 0,
    Гардиан_10_01 = 16,
    Гардиан_30_01 = 11
}
public enum DF_Zamok1Names
{
    Нет = 0,
    Гардиан_12_11 = 9
}
public enum DF_Zamok2Names
{
    Нет = 0,
    Гардиан_10_01 = 16
}
public enum KV_Zamok1Names
{
    Нет = 0,
    Гардиан_32_11 = 15
}
public enum KV_Zamok2Names
{
    Нет = 0,
    Гардиан_30_01 = 11,
    Гардиан_50_01 = 24
}
public enum ODL_ZamokNames
{
    Нет = 0,
    ПП = 1,
    Г_12_11_ручка_фланец = 9,
    Просам_ЗВ_8 = 5,
    Почтовый = 26
}
public enum PorogNames
{
    Нет = 0,
    Выподающий = 2,
    Порог_14 = 14,
    Порог_14_2_мм = 15,
    Порог_20_мм = 20,
    Порог_25 = 25,
    Порог_25_скос = 26,
    Порог_26_плоский = 27,
    Порог_30_шип_паз = 30,
    Порог_40 = 40,
    Порог_40_анкер = 41,
    Порог_100 = 100
}
public enum DM_PorogNames {
    Нет = 0,
    Выподающий = 2,
    Порог_14 = 14,
    Порог_14_2_мм = 15,
    Порог_25 = 25,
    Порог_25_скос = 26,
    Порог_30_шип_паз = 30,
    Порог_40 = 40,
    Порог_40_анкер = 41,
    Порог_100 = 100
}
public enum VM_PorogNames
{
    Нет = 0,
    Порог_14 = 14,
    Порог_25 = 25,
    Порог_40 = 40
}
public enum ODL_PorogNames
{
    Нет = 0,
    Порог_14_мм = 14,
    Порог_20_мм = 20,
    Порог_25_мм = 25
}
public enum DM_RuchkaNames 
{
    Нет = 0,
    Ручка_скоба = 1,
    Ручка_кнопка = 2,
    Ручка_фланец = 3,
    Ручка_Вега = 4,
    Ручка_черная_планка = 5,
    Ручка_уголок = 6,
    Ручка_планка_Просам = 9,
    PB_1300 = 11,
    PB_1700A = 12,
    PB_1700C = 13,
    АП_DoorLock = 14
}
public enum LM_RuchkaNames
{
    Нет = 0,
    Ручка_фланец = 3,
    Ручка_Вега = 4,
    Ручка_черная_планка = 5,
    РЯ_180 = 7,
    Ручка_Потайная = 8
}
public enum ODL_RuchkaNames
{
    Нет = 0,
    Ручка_кнопка = 2,
    Ручка_фланец = 3,
    Ручка_Вега = 4,
    Ручка_черная_планка = 5,
    Ручка_РЯ_180 = 7,
    Ручка_Потайная = 8
}
public enum DM_ZadvizhkaName {
    Нет,
    Ночной_сторож,
    ЗД_01,
    ЗТ_150
}
public enum KV_ZadvizhkaName
{
    Нет = 0,
    Ночной_сторож = 1
}
public enum AntipanikaNames {
    Нет = 0,
    Apecs_1300_1_створкa = 101,
    Apecs_1700_1_створкa = 102,
    DL_1_створкa = 103,
    Apecs_1300_2_створки = 104,
    Apecs_1700_2_створки = 105,
    DL_2_створки = 106,
    Apecs_1300_1700С = 107,
    Apecs_1700А_1700С = 108
}
public enum LM_Zamok1Names
{
    Нет = 0,
    ПП_стандарт = 1,
    ПП_без_ручки = 20,
    Меттем_842 = 6,
    Просам_ЗВ_8 = 5,
}
public enum StekloThicks {
    Нет = 0,
    _6_мм = 6,
    _8_мм = 8,
    _27_мм = 27,
    _24_мм = 24
}
public enum GlazokRaspolozhenie
{
    По_центру,
    Над_фурнитурой
}

public enum ZamokNames
{
    Нет = 0,
    ПП = 1,
    Просам_ЗВ_4 = 3,
    Фуаро_900 = 4,
    Просам_ЗВ_8 = 5,
    Меттем_842 = 6,
    Гардиан_12_11 = 9,
    Гардиан_30_01 = 11,
    Apecs_R_0002_CR = 12,
    Apecs_T_52 = 13,
    Бордер_ЗВ8_6 = 14,
    Гардиан_32_11 = 15,
    Гардиан_10_01 = 16,
    Гардиан_12_01 = 17,
    Гардиан_35_11 = 18,
    Гардиан_30_11 = 19,
    Гардиан_32_01 = 21,
    Apecs_30_R = 22,
    Crit_7_RPM = 23,
    Гардиан_50_01 = 24,
    ECO_GBS_81 = 25,
    Почтовый = 26
}
public enum RuchkaNames
{
    Нет = 0,
    Ручка_скоба = 1,
    Ручка_кнопка = 2,
    Ручка_фланец = 3,
    Ручка_Вега = 4,
    Ручка_черная_планка = 5,
    Ручка_уголок = 6,
    Ручка_РЯ_180 = 7,
    Ручка_Потайная = 8,
    Ручка_планка_Просам = 9,
    PB_1300 = 11,
    PB_1700A = 12,
    PB_1700C = 13,
    АП_DoorLock = 14
}
public enum ZadvizhkaNames
{
    Нет = 0,
    Ночной_сторож = 1,
    ЗД_01 = 2,
    ЗТ_150 = 3
}

public enum SdvigoviyNames
{
    Нет,
    Aler_AL250
}