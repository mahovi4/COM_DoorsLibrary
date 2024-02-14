using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

[Guid("12015862-818d-409c-916e-a8b99e41eb5c")]
public interface IConstructor
{
    string Add(TableData param);

    short AddFromFile(string fileName);

    short GetDMIndexByNum(string num);

    DM GetDMByNum(string num);

    short GetLMIndexByNum(string num);

    LM GetLMByNum(string num);

    short GetVMIndexByNum(string num);

    DVM GetVMByNum(string num);

    short GetODLIndexByNum(string num);

    ODL GetODLByNum(string num);

    short GetFrIndexByNum(string num);

    Framuga GetFrByNum(string num);

    bool Remove(string num);

    string CheckingForErrors(TableData param);

    string CheckingForProblems(TableData param);

    DM[] DMs {get;}

    LM[] LMs {get;}

    DVM[] VMs {get; }

    ODL[] ODLs { get; }

    Framuga[] Framugs { get; }

    TableData[] TDatasInFile(string fileName);
}

[Guid("a87df8c3-9c0f-4a3a-9b22-8bb68f874ca4"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
public interface IEConstructor { }

[Guid("1fd747f9-654d-4883-ae1d-10ac84e18ef4"), ClassInterface(ClassInterfaceType.None), ComSourceInterfaces(typeof(IEConstructor))]
[Description("Класс компановщик изделий (для пакетной обработки и возвращения коллекций объектов изделий).")]
public class Constructor : IConstructor
{
    private readonly List<DM> _DMs = new List<DM>();
    private readonly List<LM> _LMs = new List<LM>();
    private readonly List<DVM> _DVMs = new List<DVM>();
    private readonly List<ODL> _ODLs = new List<ODL>();
    private readonly List<Framuga> _Framugs = new List<Framuga>();
    private readonly Constants cons = new Constants();
    private readonly IniFile ini;

    public Constructor() : base()
    {
        ini = new IniFile(cons.DIR_CONS_GLOBAL + @"\Constructor.ini");
    }

    private bool CheckWeightList(List<DM> list)
    {
        return list.Count < short.Parse(ini.ReadKey("Constructor", "LIM_DM"));
    }
    private bool CheckWeightList(List<LM> list)
    {
        return list.Count < short.Parse(ini.ReadKey("Constructor", "LIM_LM"));
    }
    private bool CheckWeightList(List<DVM> list)
    {
        return list.Count < short.Parse(ini.ReadKey("Constructor", "LIM_VM"));
    }
    private bool CheckWeightList(List<ODL> list)
    {
        return list.Count < short.Parse(ini.ReadKey("Constructor", "LIM_ODL"));
    }
    private bool CheckWeightList(List<Framuga> list)
    {
        return list.Count < short.Parse(ini.ReadKey("Constructor", "LIM_FR"));
    }

    private short GetCount(string name, ref IniFile iniFile)
    {
        int i;
        int loopTo = int.Parse(ini.ReadKey("Constructor", "LIM_" + name)) - 1;
        for (i = 1; i <= loopTo; i++)
        {
            if (!iniFile.KeyExists(name, i.ToString()))
            {
                break;
            }
        }

        return (short)(i - 1);
    }
    private short GetCount(ref IniFile ini)
    {
        int count = 0;
        count += GetCount("DM", ref ini);
        count += GetCount("LM", ref ini);
        count += GetCount("VM", ref ini);
        count += GetCount("ODL", ref ini);
        count += GetCount("FR", ref ini);
        return (short)count;
    }
    private short AddSomeCount(ref IniFile ini, string nameProduct, short count)
    {
        int c = 0;
        for (int i = 1; i <= count; i++)
        {
            TableData td = new TableData();
            td.ReadFromIniByRef(ref ini, ini.ReadKey(nameProduct, i.ToString()));
            if (Add(td) == "OK")
            {
                c += 1;
            }
        }
        return (short)c;
    }

    private short RaspolozhenieFr(ref TableData param)
    {
        for (short i = 0; i <= 3; i++)
        {
            if (param.GetFramuga(i) != FramugaType.нет)
            {
                return i;
            }
        }
        return -1;
    }

    public DM[] DMs
    {
        get
        {
            return _DMs.ToArray();
        }
    }
    public LM[] LMs
    {
        get
        {
            return _LMs.ToArray();
        }
    }
    public DVM[] VMs
    {
        get
        {
            return _DVMs.ToArray();
        }
    }
    public ODL[] ODLs
    {
        get
        {
            return _ODLs.ToArray();
        }
    }
    public Framuga[] Framugs
    {
        get
        {
            return _Framugs.ToArray();
        }
    }

    public string WorkFolder
    {
        get
        {
            return cons.DIR_WORK_TMP;
        }
    }

    public TableData[] TDatasInFile(string fileName)
    {
        TableData[] tDatas;
        IniFile tmpIni;
        int c = 0, cDM, cLM, cVM, cODL, cFR;
        string[] nums;

        if (Strings.Right(fileName, 4) == ".ini")
        {
            tmpIni = new IniFile(fileName);
        }
        else
        {
            Interaction.MsgBox("Указанный файл не является ini-файлом", (MsgBoxStyle)16, "Constructor");
            tDatas = new TableData[] { };
            return tDatas;
        }

        tDatas = new TableData[(GetCount(ref tmpIni))];
        nums = new string[tDatas.Length];
        cDM = GetCount("DM", ref tmpIni);
        cLM = GetCount("LM", ref tmpIni);
        cVM = GetCount("VM", ref tmpIni);
        cODL = GetCount("ODL", ref tmpIni);
        cFR = GetCount("FR", ref tmpIni);
        if (cDM > 0)
        {
            for (short i = 1, loopTo = (short)cDM; i <= loopTo; i++)
            {
                nums[c] = tmpIni.ReadKey("DM", i.ToString());
                c += 1;
            }
        }
        if (cLM > 0)
        {
            for (short i = 1, loopTo1 = (short)cLM; i <= loopTo1; i++)
            {
                nums[c] = tmpIni.ReadKey("LM", i.ToString());
                c += 1;
            }
        }
        if (cVM > 0)
        {
            for (short i = 1, loopTo2 = (short)cVM; i <= loopTo2; i++)
            {
                nums[c] = tmpIni.ReadKey("VM", i.ToString());
                c += 1;
            }
        }
        if (cODL > 0)
        {
            for (short i = 1, loopTo3 = (short)cODL; i <= loopTo3; i++)
            {
                nums[c] = tmpIni.ReadKey("ODL", i.ToString());
                c += 1;
            }
        }
        if (cFR > 0)
        {
            for (short i = 1, loopTo4 = (short)cFR; i <= loopTo4; i++)
            {
                nums[c] = tmpIni.ReadKey("FR", i.ToString());
                c += 1;
            }
        }
        if (tDatas.Length > 0)
        {
            for (short i = 0; i < tDatas.Length; i++)
            {
                tDatas[i] = new TableData();
                tDatas[i].ReadFromIniByRef(ref tmpIni, nums[i]);
            }
        }

        return tDatas;
    }
    public string Add(TableData param)
    {
        string err = "";
        if (cons.CompareKod(param.Kod, "ДМ") | cons.CompareKod(param.Kod, "MAX"))
        {
            if (CheckWeightList(_DMs)) {
                DM dm = new DM();
                dm.Init(param);
                err = dm.Errors;
                if (err.Equals("")) {
                    _DMs.Add(dm);
                    return "OK";
                }
                else {
                    return err;
                }
            }
            else {
                return "Достигнут придел массива DM! ";
            }
        }
        else if (cons.CompareKod(param.Kod, "ЛМ"))
        {
            if (CheckWeightList(_LMs))
            {
                var lm = new LM();
                lm.Init(param);
                err = lm.Errors;
                if (string.IsNullOrEmpty(err))
                {
                    _LMs.Add(lm);
                    return "OK";
                }
                else
                {
                    return err;
                }
            }
            else
            {
                return "Достигнут придел массива LM! ";
            }
        }
        else if (cons.CompareKod(param.Kod, "ВМ"))
        {
            if (CheckWeightList(_DVMs))
            {
                DVM vm = new DVM();
                vm.Init(param);
                err = vm.Errors;
                if (string.IsNullOrEmpty(err))
                {
                    _DVMs.Add(vm);
                    return "OK";
                }
                else
                {
                    return err;
                }
            }
            else
            {
                return "Достигнут придел массива VM! ";
            }
        }
        else if (cons.CompareKod(param.Kod, "ОДЛ"))
        {
            if (CheckWeightList(_ODLs))
            {
                ODL odl = new ODL();
                odl.Init(param);
                err = odl.Errors;
                if (string.IsNullOrEmpty(err))
                {
                    _ODLs.Add(odl);
                    return "OK";
                }
                else
                {
                    return err;
                }
            }
            else
            {
                return "Достигнут придел массива ODL! ";
            }
        }
        else if (cons.CompareKod(param.Kod, "Фрамуга"))
        {
            if (CheckWeightList(_Framugs))
            {
                Framuga fr = new Framuga();
                short r = RaspolozhenieFr(ref param);
                if (r > -1)
                {
                    fr.Init(ref param, (Raspolozhenie)r, false);
                    err = fr.Errors;
                    if (err.Equals(""))
                    {
                        _Framugs.Add(fr);
                        return "OK";
                    }
                    else
                    {
                        return err;
                    }
                }
                else
                {
                    return "Необнаружено расположение фрамуги! ";
                }
            }
            else
            {
                return "Достигнут придел массива Framuga! ";
            }
        }
        else if (cons.CompareKod(param.Kod, "ДОБОР"))
        {
            if (CheckWeightList(_DMs))
            {
                DM dm = new DM();
                dm.Init(param);
                err = dm.Errors;
                if (err.Equals(""))
                {
                    _DMs.Add(dm);
                    return "OK";
                }
                else
                {
                    return err;
                }
            }
            else
            {
                return "Достигнут придел массива DM! ";
            }
        }
        else
        {
            return "Неизвестный мне код! ";
        }
    }

    public short AddFromFile(string fileName)
    {
        IniFile tmpINI;
        if (fileName.IndexOf(@"\") >= 0 | fileName.IndexOf("/") >= 0)
        {
            if (fileName.IndexOf(".ini") >= 0)
            {
                tmpINI = new IniFile(fileName);
            }
            else
            {
                Interaction.MsgBox("Имя ini-файла неверно!" + '\n' + "Измените имя и попробуйте снова.", (MsgBoxStyle)16, "Неверное имя файла");
                return 0;
            }
        }
        else
        {
            tmpINI = new IniFile(cons.DIR_WORK_TMP + @"\" + fileName);
        }

        var count = default(int);
        int CountDM = GetCount("DM", ref tmpINI);
        int CountLM = GetCount("LM", ref tmpINI);
        int CountDVM = GetCount("VM", ref tmpINI);
        int CountODL = GetCount("ODL", ref tmpINI);
        int CountFr = GetCount("FR", ref tmpINI);
        if (CountDM > 0)
        {
            count += AddSomeCount(ref tmpINI, "DM", (short)CountDM);
        }

        if (CountLM > 0)
        {
            count += AddSomeCount(ref tmpINI, "LM", (short)CountLM);
        }

        if (CountDVM > 0)
        {
            count += AddSomeCount(ref tmpINI, "VM", (short)CountDVM);
        }

        if (CountODL > 0)
        {
            count += AddSomeCount(ref tmpINI, "ODL", (short)CountODL);
        }

        if (CountFr > 0)
        {
            count += AddSomeCount(ref tmpINI, "FR", (short)CountFr);
        }

        return (short)count;
    }
    public short GetDMIndexByNum(string num)
    {
        for (short i = 0; i < _DMs.Count; i++)
        {
            if (_DMs[i] is object)
            {
                if (_DMs[i].Num.Equals(num))
                    return i;
            }
        }

        return -1;
    }
    public DM GetDMByNum(string num)
    {
        foreach (DM dm in _DMs)
        {
            if (dm.Num.Equals(num))
                return dm;
        }
        return null;
    }
    public short GetLMIndexByNum(string num)
    {
        for (short i = 0; i < _LMs.Count; i++)
        {
            if (_LMs[i] is object)
            {
                if (_LMs[i].Num.Equals(num))
                    return i;
            }
        }

        return -1;
    }
    public LM GetLMByNum(string num)
    {
        foreach (LM lm in _LMs)
        {
            if (lm.Num.Equals(num))
                return lm;
        }
        return null;
    }
    public short GetVMIndexByNum(string num)
    {
        for (short i = 0; i < _DVMs.Count; i++)
        {
            if (_DVMs[i] is object)
            {
                if (_DVMs[i].Num.Equals(num))
                    return i;
            }
        }
        return -1;
    }
    public DVM GetVMByNum(string num)
    {
        foreach (DVM dvm in _DVMs)
        {
            if (dvm.Num.Equals(num))
                return dvm;
        }
        return null;
    }
    public short GetODLIndexByNum(string num)
    {
        for (short i = 0; i < _ODLs.Count; i++)
        {
            if (_ODLs[i] != null)
            {
                if (_ODLs[i].Num.Equals(num))
                    return i;
            }
        }
        return -1;
    }
    public ODL GetODLByNum(string num)
    {
        foreach (ODL odl in _ODLs)
        {
            if (odl.Num.Equals(num))
                return odl;
        }
        return null;
    }
    public short GetFrIndexByNum(string num)
    {
        for (short i = 0; i < _Framugs.Count; i++)
        {
            if (_Framugs[i] != null)
            {
                if (_Framugs[i].Num.Equals(num))
                    return i;
            }
        }

        return -1;
    }
    public Framuga GetFrByNum(string num)
    {
        foreach (Framuga fr in _Framugs)
        {
            if (fr.Num.Equals(num))
                return fr;
        }
        return null;
    }
    public bool Remove(string num)
    {
        if (GetDMByNum(num) != null)
        {
            return _DMs.Remove(GetDMByNum(num));
        }
        else if (GetLMByNum(num) != null)
        {
            return _LMs.Remove(GetLMByNum(num));
        }
        else if (GetVMByNum(num) != null)
        {
            return _DVMs.Remove(GetVMByNum(num));
        }
        else if (GetODLByNum(num) != null)
        {
            return _ODLs.Remove(GetODLByNum(num));
        }
        else if (GetFrByNum(num) != null)
        {
            return _Framugs.Remove(GetFrByNum(num));
        }
        else
        {
            return false;
        }
    }
    public string CheckingForErrors(TableData param)
    {
        if (cons.CompareKod(param.Kod, "ДМ") | cons.CompareKod(param.Kod, "MAX"))
        {
            DM dm = new DM();
            dm.Init(param);
            return dm.Errors;
        }
        else if (cons.CompareKod(param.Kod, "ЛМ"))
        {
            LM lm = new LM();
            lm.Init(param);
            return lm.Errors;
        }
        else if (cons.CompareKod(param.Kod, "ВМ"))
        {
            DVM dvm = new DVM();
            dvm.Init(param);
            return dvm.Errors;
        }
        else if (cons.CompareKod(param.Kod, "ОДЛ"))
        {
            ODL odl = new ODL();
            odl.Init(param);
            return odl.Errors;
        }
        else if (cons.CompareKod(param.Kod, "Фрамуга"))
        {
            for (short y = 0; y <= 3; y++)
            {
                if (param.GetFramuga(y) != FramugaType.нет)
                {
                    Framuga fr = new Framuga();
                    fr.Init(ref param, (Raspolozhenie)y, false);
                    return fr.Errors;
                }
            }

            return "Не нашел ни одной фрамуги!";
        }
        else
        {
            return "Неизвестный мне код!";
        }
    }
    public string CheckingForProblems(TableData param)
    {
        if (cons.CompareKod(param.Kod, "ДМ") | cons.CompareKod(param.Kod, "MAX"))
        {
            DM dm = new DM();
            dm.Init(param);
            return dm.Problems;
        }
        else if (cons.CompareKod(param.Kod, "ЛМ"))
        {
            LM lm = new LM();
            lm.Init(param);
            return lm.Problems;
        }
        else if (cons.CompareKod(param.Kod, "ВМ"))
        {
            DVM dvm = new DVM();
            dvm.Init(param);
            return dvm.Problems;
        }
        else if (cons.CompareKod(param.Kod, "ОДЛ"))
        {
            ODL odl = new ODL();
            odl.Init(param);
            return odl.Problems;
        }
        else if (cons.CompareKod(param.Kod, "Фрамуга"))
        {
            for (short y = 0; y <= 3; y++)
            {
                if (!(param.GetFramuga(y) == FramugaType.нет))
                {
                    var fr = new Framuga();
                    fr.Init(ref param, (Raspolozhenie)y, false);
                    return fr.Problems;
                }
            }

            return "Не нашел ни одной фрамуги!";
        }
        else
        {
            return "Неизвестный мне код!";
        }
    }

    public string[] СompatPorogsByKod(string kod)
    {
        return cons.СompatPorogsByKod(kod);
    }
    public string[] ListThikcsAsStr()
    {
        return cons.ListThikcsAsStr();
    }
    public string[] OtkrivanieNames()
    {
        return Enum.GetNames(typeof(Otkrivanie));
    }
    public string[] GetKodNames()
    {
        return cons.GetKodNames().ToArray();
    }
    
}
