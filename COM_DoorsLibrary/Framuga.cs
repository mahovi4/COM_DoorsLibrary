using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.Windows.Forms;

[Guid("01a6c265-8dbb-47ea-9c52-3b1fab87ee19")]
public interface IFramuga
{
    [DispId(1)]
    [Description("Возвращает номер изделия, присвоенный системой 1С.")]
    void Init(FramugaParam param, bool VM);

    [DispId(2)]
    [Description("Возвращает номер изделия, присвоенный системой 1С.")]
    string Num { get; }

    [DispId(3)]
    [Description("Возвращает список ошибок, возникших при расчете изделия (в противном случае - пустая строка).")]
    string Errors { get; }

    [DispId(4)]
    [Description("Возвращает список конструктивных проблем, возникших при расчете изделия (в противном случае - пустая строка).")]
    string Problems { get; }

    [DispId(5)]
    [Description("Возвращает высоту листа изделия по его позиции (0-лицевой лист, 1-внутренний).")]
    double List_Height(short pos);

    [DispId(6)]
    [Description("Возвращает ширину листа изделия по его позиции (0-лицевой лист, 1-внутренний).")]
    double List_Width(short pos);

    [DispId(7)]
    [Description("Возвращает длину торцевой заглушки изделия.")]
    short TorcZaglushka_Length { get; }

    [DispId(8)]
    [Description("Возвращает ширину торцевой заглушки изделия.")]
    short TorcZaglushka_Width { get; }

    [DispId(9)]
    [Description("Возвращает длину наличника изделия по его расположению.")]
    short Nalichnik_Length(Raspolozhenie pos);

    [DispId(10)]
    [Description("Возвращает ширину развертки наличника изделия по его расположению.")]
    short Nalichnik_Razvertka(Raspolozhenie pos);

    [DispId(11)]
    [Description("Возвращает тип стойки (К1, К2, К3) изделия по ее расположению.")]
    short Stoyka_Type(Raspolozhenie pos);

    [DispId(12)]
    [Description("Возвращает длину стойки изделия по ее расположению.")]
    short Stoyka_Length(Raspolozhenie pos);

    [DispId(13)]
    [Description("Возвращает длину Z-профиля по его расположению в изделии.")]
    short Zprofil_Length(Raspolozhenie pos);

    [DispId(14)]
    [Description("Возвращает ширину развертки Z-профиля изделия.")]
    short Zprofil_Razvertka { get; }

    [DispId(15)]
    [Description("Возвращает ширину развертки порога изделия.")]
    short Porog_Razvertka { get; }

    [DispId(16)]
    [Description("Возвращает высоту стекла изделия.")]
    short Steklo_Hight { get; }

    [DispId(17)]
    [Description("Возвращает ширину стекла изделия.")]
    short Steklo_Width { get; }
}

[Guid("cc6de3da-dc9f-482b-ad4e-69fc1d5e3d76"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
public interface IEFramuga
{

}

[Guid("593690ec-f42a-4812-99a9-90a53a9c259f"), ClassInterface(ClassInterfaceType.None), ComSourceInterfaces(typeof(IEFramuga))]
[Description("Класс расчета фрамуги.")]
public class Framuga : IFramuga
{
    private FramugaParam framugaParam;

    private short kVMP, kVMZ, koef90, koef62, kp62, kp90, kz62;
    private readonly string _errors, _problems;

    private readonly Constants cons = new Constants();
    private IniFile ini;
    private IniFile iniDM;

    public void Init(ref TableData data, Raspolozhenie raspol, bool VM = false)
    {
        Init(data.ForDM, raspol, VM);
    }
    public void Init(DMParam param, Raspolozhenie raspol, bool VM = false) {
        FramugaParam frPar = param.Framuga[(short)raspol];
        frPar.Num = param.Num;
        frPar.Raspolozhenie = raspol;
        frPar.Otkrivanie = param.Otkrivanie.Value;
        frPar.Nalichniki = new short[4];

        switch (frPar.Raspolozhenie) {
            case Raspolozhenie.Верх:
                frPar.Nalichniki[0] = param.Nalichniki[0];
                frPar.Nalichniki[1] = 0;
                frPar.Nalichniki[2] = param.Nalichniki[2];
                frPar.Nalichniki[3] = param.Nalichniki[3];
                break;
            case Raspolozhenie.Ниж:
                frPar.Nalichniki[0] = 0;
                string dNal;
                bool bNal;
                short sNal = 0;
                do
                {
                    dNal = Interaction.InputBox("Введите величину нижнего наличника нижней фрамуги" + '\n' + "Если нижнего наличника нет, то введите 0", 
                                                "Нижний наличник нижней фрамуги");
                    if (dNal == "") 
                    {
                        MessageBox.Show("Ничего не введено!");
                        bNal = false;
                    } 
                    else 
                    {
                        if (short.TryParse(dNal, out sNal)) 
                            bNal = true;
                        else 
                        {
                            MessageBox.Show("Введенное значение не является числом!");
                            bNal = false;
                        }
                    }
                } while (!bNal) ;

                frPar.Nalichniki[1] = sNal;
                frPar.Nalichniki[2] = param.Nalichniki[2];
                frPar.Nalichniki[3] = param.Nalichniki[3];
                break;
            case Raspolozhenie.Прав:
                for (int i = 0; i <= 1; i++)
                {
                    if (param.Framuga[i].Type == FramugaType.нет)
                        frPar.Nalichniki[i] = param.Nalichniki[i];
                    else
                    {
                        if (param.Framuga[i].Type == FramugaType.полного_остекления & param.Nalichniki[i] == 0)
                            frPar.Nalichniki[i] = 0;
                        else
                            frPar.Nalichniki[i] = 60;
                        frPar.Nalichniki[i] = 60;
                    }
                }

                frPar.Nalichniki[2] = param.Nalichniki[2];
                frPar.Nalichniki[3] = 0;
                break;
            default:
                for (int i = 0; i <= 1; i++)
                {
                    if (param.Framuga[i].Type == FramugaType.нет)
                        frPar.Nalichniki[i] = param.Nalichniki[i];
                    else
                    {
                        if (param.Framuga[i].Type == FramugaType.полного_остекления & param.Nalichniki[i] == 0)
                            frPar.Nalichniki[i] = 0;
                        else
                            frPar.Nalichniki[i] = 60;
                    }
                }

                frPar.Nalichniki[2] = 0;
                frPar.Nalichniki[3] = param.Nalichniki[3];
                break;
        }

        if(frPar.ThickPolotna == 0 & param.Kod > 0)
        {
            if (cons.CompareKod(param.Kod, "ДМ", "(70)"))
                frPar.ThickPolotna = 70;
            else if (cons.ST62 & cons.CompareKod(param.Kod, "ДМ", "(62)"))
                frPar.ThickPolotna = 62;
            else
                frPar.ThickPolotna = 53;
        }
        else if(frPar.ThickPolotna == 0 & param.Kod == 0)
            frPar.ThickPolotna = 53;

        Init(frPar, VM);
    }
    public void Init(FramugaParam param, bool VM = false)
    {
        framugaParam = param;
        ini = new IniFile(cons.DIR_CONS_GLOBAL + "\\Framuga.ini");
        iniDM = new IniFile(cons.DIR_CONS_GLOBAL + "\\DM.ini");
        if (VM) {
            kVMP = short.Parse(ini.ReadKey("Framuga", "K_VMP"));
            kVMZ = short.Parse(ini.ReadKey("Framuga", "K_VMZ"));
            koef90 = 0;
            kp90 = 0;
            koef62 = 0;
            kp62 = 0;
            kz62 = 0;
        } 
        else {
            kVMP = 0;
            kVMZ = 0;
            if (framugaParam.ThickPolotna == 70) 
            {
                koef90 = short.Parse(iniDM.ReadKey("Koef", "KOEF_90"));
                kp90 = short.Parse(ini.ReadKey("Framuga", "POF_K_70"));
                koef62 = 0;
                kp62 = 0;
                kz62 = 0;
            }
            else if (framugaParam.ThickPolotna == 62)
            {
                koef90 = 0;
                kp90 = 0;
                koef62 = short.Parse(iniDM.ReadKey("Koef", "KOEF_62"));
                kp62 = short.Parse(ini.ReadKey("Framuga", "POF_K_POR_62"));
                kz62 = short.Parse(ini.ReadKey("Framuga", "POF_K_ZP_62"));
            }
            else {
                koef90 = 0;
                kp90 = 0;
                koef62 = 0;
                kp62 = 0;
                kz62 = 0;
            }
        }
        
        //if (cons.CompareKod(framugaParam.Kod, "Фрамуга", "частичного") | cons.CompareKod(param.Kod, "Фрамуга", "жалюзийной"))
        //    framugaParam.Type = FramugaType.частичного_остекления;
        //else if (cons.CompareKod(param.Kod, "Фрамуга", "полного")) 
        //    framugaParam.Type = FramugaType.полного_остекления;
        //else 
        //    framugaParam.Type = FramugaType.глухая;

        if (framugaParam.Type != FramugaType.глухая & framugaParam.Type != FramugaType.нет)
        {
            if (framugaParam.Steklo == null)
                framugaParam.Steklo = new StekloParam[1];
            framugaParam.Steklo[0] = CalculateSteklo(framugaParam);
        }
    }

    public StekloParam CalculateSteklo(FramugaParam frParam)
    {
        StekloParam stParam = new StekloParam() { Height = 0, Width = 0, Thick = StekloThicks._27_мм};
        if(framugaParam.Steklo != null)
            stParam.Thick = framugaParam.Steklo[0].Thick;
        if (frParam.Type == FramugaType.полного_остекления)
        {
            switch (frParam.Raspolozhenie)
            {
                case Raspolozhenie.Верх:
                case Raspolozhenie.Ниж:
                    if (frParam.Otkrivanie == Otkrivanie.Левое | frParam.Otkrivanie == Otkrivanie.Правое)
                    {
                        if (frParam.Nalichniki[(short)frParam.Raspolozhenie] > 0)
                            stParam.Height = (short)(frParam.Height - short.Parse(ini.ReadKey("StekloFramugi", "ST_H_K_K1")));
                        else
                            stParam.Height = (short)(frParam.Height - short.Parse(ini.ReadKey("StekloFramugi", "ST_H_K_K2")));
                        short k = 0;
                        if (frParam.Nalichniki[(int)Raspolozhenie.Прав] == 0)
                            k += short.Parse(ini.ReadKey("StekloFramugi", "ST_W_K_K2"));
                        if (frParam.Nalichniki[3] == 0)
                            k += short.Parse(ini.ReadKey("StekloFramugi", "ST_W_K_K2"));
                        stParam.Width = (short)(frParam.Width - short.Parse(ini.ReadKey("StekloFramugi", "ST_W_K")) - k);
                    }
                    else
                    {
                        if (frParam.Nalichniki[(short)frParam.Raspolozhenie] > 0)
                            stParam.Height = (short)(frParam.Height - short.Parse(ini.ReadKey("StekloFramugi", "ST_H_K_K3_1")));
                        else
                            stParam.Height = (short)(frParam.Height - short.Parse(ini.ReadKey("StekloFramugi", "ST_H_K_K3_2")));
                        stParam.Width = (short)(frParam.Width - short.Parse(ini.ReadKey("StekloFramugi", "ST_W_K_K3")));
                    }
                    break;
                case Raspolozhenie.Лев:
                    if (frParam.Otkrivanie == Otkrivanie.Левое | frParam.Otkrivanie == Otkrivanie.Правое)
                    {
                        if (frParam.Nalichniki[0] > 0)
                            stParam.Height = (short)(frParam.Height - short.Parse(ini.ReadKey("StekloVstavki", "ST_H_K_K1")));
                        else
                            stParam.Height = (short)(frParam.Height - short.Parse(ini.ReadKey("StekloVstavki", "ST_H_K_K2")));
                        if (frParam.Nalichniki[3] > 0)
                            stParam.Width = (short)(frParam.Width - short.Parse(ini.ReadKey("StekloVstavki", "ST_W_K")));
                        else
                            stParam.Width = (short)(frParam.Width - short.Parse(ini.ReadKey("StekloVstavki", "ST_W_K")) -
                                                                    short.Parse(ini.ReadKey("StekloVstavki", "ST_W_K_K2")));
                    }
                    else
                    {
                        stParam.Height = (short)(frParam.Height - short.Parse(ini.ReadKey("StekloVstavki", "ST_H_K_K3")));
                        if (frParam.Nalichniki[3] > 0)
                            stParam.Width = (short)(frParam.Width - short.Parse(ini.ReadKey("StekloVstavki", "ST_W_K_K3_1")));
                        else
                            stParam.Width = (short)(frParam.Width - short.Parse(ini.ReadKey("StekloVstavki", "ST_W_K_K3_2")));
                    }
                    break;
                default:
                    if (frParam.Otkrivanie == Otkrivanie.Левое | frParam.Otkrivanie == Otkrivanie.Правое)
                    {
                        if (frParam.Nalichniki[0] > 0)
                            stParam.Height = (short)(frParam.Height - short.Parse(ini.ReadKey("StekloVstavki", "ST_H_K_K1")));
                        else
                            stParam.Height = (short)(frParam.Height - short.Parse(ini.ReadKey("StekloVstavki", "ST_H_K_K2")));
                        if (frParam.Nalichniki[2] > 0)
                            stParam.Width = (short)(frParam.Width - short.Parse(ini.ReadKey("StekloVstavki", "ST_W_K")));
                        else
                            stParam.Width = (short)(frParam.Width - short.Parse(ini.ReadKey("StekloVstavki", "ST_W_K")) -
                                                                    short.Parse(ini.ReadKey("StekloVstavki", "ST_W_K_K2")));
                    }
                    else
                    {
                        stParam.Height = (short)(frParam.Height - short.Parse(ini.ReadKey("StekloVstavki", "ST_H_K_K3")));
                        if (frParam.Nalichniki[2] > 0)
                            stParam.Width = (short)(frParam.Width - short.Parse(ini.ReadKey("StekloVstavki", "ST_W_K_K3_1")));
                        else
                            stParam.Width = (short)(frParam.Width - short.Parse(ini.ReadKey("StekloVstavki", "ST_W_K_K3_2")));
                    }
                    break;
            }

        }
        else if (frParam.Type == FramugaType.частичного_остекления)
        {
            stParam.Height += 20;
            stParam.Width += 20;
        }
        return stParam;
    }

    public FramugaParam Param
    {
        get => framugaParam;
    }
    public string Num
    {
        get { return framugaParam.Num; }
    }
    public string Errors
    {
        get { return _errors; }
    }
    public string Problems
    {
        get { return _problems; }
    }
    public double List_Height(short pos)
    {
        if (framugaParam.Type == FramugaType.полного_остекления) {
            return 0;
        }
        else {
            if (pos == 0) {
                if (framugaParam.Raspolozhenie == Raspolozhenie.Верх | framugaParam.Raspolozhenie == Raspolozhenie.Ниж) {
                    return framugaParam.Height + short.Parse(ini.ReadKey("Framuga", "K_LL")) + koef62 + koef90 / 2 + kVMP;
                }
                else {
                    return framugaParam.Height;
                }
            }
            else {
                if (framugaParam.Raspolozhenie == Raspolozhenie.Верх | framugaParam.Raspolozhenie == Raspolozhenie.Ниж) {
                    return framugaParam.Height + short.Parse(ini.ReadKey("Framuga", "K_VL")) + koef62 + koef90 / 2 + kVMP;
                }
                else {
                    return framugaParam.Height;
                }
            }
        }
    }
    public double List_Width(short pos)
    {
        if (framugaParam.Type == FramugaType.полного_остекления) {
            return 0;
        }
        else {
            if (pos == 0) {
                if (framugaParam.Raspolozhenie == Raspolozhenie.Верх | framugaParam.Raspolozhenie == Raspolozhenie.Ниж) {
                    return framugaParam.Width;
                }
                else {
                    return framugaParam.Width + short.Parse(ini.ReadKey("Framuga", "K_LL")) + koef62 + koef90 / 2 + kVMP;
                }
            }
            else {
                if (framugaParam.Raspolozhenie == Raspolozhenie.Верх | framugaParam.Raspolozhenie == Raspolozhenie.Ниж)
                {
                    return framugaParam.Width;
                }
                else
                {
                    return framugaParam.Width + short.Parse(ini.ReadKey("Framuga", "K_VL")) + koef62 + koef90 / 2 + kVMP;
                }
            }
        }
    }
    public short TorcZaglushka_Length
    {
        get
        {
            if (framugaParam.Type == FramugaType.полного_остекления)
            {
                return 0;
            }
            else
            {
                if (framugaParam.Raspolozhenie == Raspolozhenie.Верх | framugaParam.Raspolozhenie == Raspolozhenie.Ниж)
                {
                    return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "K_TZ")));
                }
                else
                {
                    return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "K_TZ")));
                }
            }
        }
    }
    public short TorcZaglushka_Width
    {
        get
        {
            if (framugaParam.Type == FramugaType.полного_остекления)
            {
                return 0;
            }
            else
            {
                return (short)(short.Parse(ini.ReadKey("Framuga", "W_TZ")) + koef62 + koef90 / 2 + kVMZ);
            }
        }
    }
    public short Nalichnik_Length(Raspolozhenie pos) {
        if (framugaParam.Type == FramugaType.полного_остекления) {
            return 0;
        }
        else {
            switch (pos) {
                case Raspolozhenie.Верх:
                case Raspolozhenie.Ниж:
                    if (framugaParam.Raspolozhenie == Raspolozhenie.Верх | framugaParam.Raspolozhenie == Raspolozhenie.Ниж) {
                        if (framugaParam.Nalichniki[(short)pos] > 0) {
                            return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "K_G_NAL")));
                        }
                        else {
                            return 0;
                        }
                    }
                    else {
                        if (framugaParam.Nalichniki[(short)pos] > 0) {
                            return (short)(framugaParam.Width - 60);
                        }
                        else {
                            return 0;
                        }
                    }
                default:
                    if (framugaParam.Raspolozhenie == Raspolozhenie.Верх | framugaParam.Raspolozhenie == Raspolozhenie.Ниж) {
                        if (framugaParam.Nalichniki[(short)pos] > 0) {
                            return (short)(framugaParam.Height - 60);
                        }
                        else {
                            return 0;
                        }
                    }
                    else {
                        if (framugaParam.Nalichniki[(short)pos] > 0) {
                            return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "K_V_NAL")));
                        }
                        else {
                            return 0;
                        }
                    }
            }
        }
    }
    public short Nalichnik_Razvertka(Raspolozhenie pos)
    {
        if (framugaParam.Type == FramugaType.полного_остекления)
        {
            return 0;
        }
        else
        {
            if (framugaParam.Nalichniki[(short)pos] > 0)
            {
                return (short)(framugaParam.Nalichniki[(short)pos] + short.Parse(ini.ReadKey("Framuga", "K_R_NAL")));
            }
            else
            {
                return 0;
            }
        }
    }
    public short Stoyka_Type(Raspolozhenie pos)
    {
        if (framugaParam.Type == FramugaType.полного_остекления)
        {
            if (framugaParam.Nalichniki[(short)pos] == 0)
            {
                return 2;
            }
            else
            {
                if (framugaParam.Otkrivanie == Otkrivanie.Левое | framugaParam.Otkrivanie == Otkrivanie.Правое)
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
        }
        else
        {
            return 0;
        }
    }
    public short Stoyka_Length(Raspolozhenie pos)
    {
        if (framugaParam.Type == FramugaType.полного_остекления)
        {
            if (framugaParam.Raspolozhenie == Raspolozhenie.Верх | framugaParam.Raspolozhenie == Raspolozhenie.Ниж)
            {
                switch (pos)
                {
                    case Raspolozhenie.Верх:
                        if (framugaParam.Otkrivanie == Otkrivanie.Левое | framugaParam.Otkrivanie == Otkrivanie.Правое)
                        {
                            if (framugaParam.Nalichniki[2] > 0 & framugaParam.Nalichniki[3] > 0)
                            {
                                return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_PR_K1_K1")));
                            }
                            else if (framugaParam.Nalichniki[2] == 0 & framugaParam.Nalichniki[3] == 0)
                            {
                                return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_PR_K1_K1")) - 
                                                                    short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")) * 2);
                            }
                            else
                            {
                                return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_PR_K1_K1")) - 
                                                                    short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")));
                            }
                        }
                        else
                        {
                            return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_PR_K1_K1")) - 
                                                                short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")) * 2);
                        }
                    case Raspolozhenie.Ниж:
                        return framugaParam.Width;
                    default:
                        if (framugaParam.Otkrivanie == Otkrivanie.Левое | framugaParam.Otkrivanie == Otkrivanie.Правое)
                        {
                            if (framugaParam.Nalichniki[0] > 0)
                            {
                                if (framugaParam.Nalichniki[2] > 0 & framugaParam.Nalichniki[3] > 0)
                                {
                                    return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K1")));
                                }
                                else
                                {
                                    return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K1_K2")));
                                }
                            }
                            else
                            {
                                return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")));
                            }
                        }
                        else
                        {
                            return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")));
                        }
                }
            }
            else
            {
                short tmpNal;
                if (framugaParam.Raspolozhenie == Raspolozhenie.Лев)
                {
                    tmpNal = framugaParam.Nalichniki[3];
                }
                else
                {
                    tmpNal = framugaParam.Nalichniki[2];
                }
                switch (pos)
                {
                    case Raspolozhenie.Верх:
                    case Raspolozhenie.Ниж:
                        if (framugaParam.Otkrivanie == Otkrivanie.Левое | framugaParam.Otkrivanie == Otkrivanie.Правое)
                        {
                            if (tmpNal > 0 & framugaParam.Nalichniki[0] > 0)
                            {
                                return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K1")));
                            }
                            else if (tmpNal == 0 & framugaParam.Nalichniki[0] == 0)
                            {
                                return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")));
                            }
                            else
                            {
                                return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K1_K2")));
                            }
                        }
                        else
                        {
                            return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")));
                        }
                    case Raspolozhenie.Прав:
                        if (framugaParam.Raspolozhenie == Raspolozhenie.Лев)
                        {
                            return framugaParam.Height;
                        }
                        else
                        {
                            if (framugaParam.Otkrivanie == Otkrivanie.Левое | framugaParam.Otkrivanie == Otkrivanie.Правое)
                            {
                                if (framugaParam.Nalichniki[0] > 0)
                                {
                                    return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_PR_K1_K1")) - 
                                                                         short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")));
                                }
                                else
                                {
                                    return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_PR_K1_K1")) - 
                                                                         short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")) * 2);
                                }
                            }
                            else
                            {
                                return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_PR_K1_K1")) - 
                                                                     short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")) * 2);
                            }
                        }
                    default:
                        if (framugaParam.Raspolozhenie == Raspolozhenie.Прав)
                        {
                            return framugaParam.Height;
                        }
                        else
                        {
                            if (framugaParam.Otkrivanie == Otkrivanie.Левое | framugaParam.Otkrivanie == Otkrivanie.Правое)
                            {
                                if (framugaParam.Nalichniki[0] > 0)
                                {
                                    return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_PR_K1_K1")) - 
                                                                         short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")));
                                }
                                else
                                {
                                    return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_PR_K1_K1")) - 
                                                                         short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")) * 2);
                                }
                            }
                            else
                            {
                                return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_PR_K1_K1")) - 
                                                                     short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")) * 2);
                            }
                        }
                }
            }
        }
        else
        {
            return 0;
        }
    }
    public short Zprofil_Length(Raspolozhenie pos)
    {
            if (framugaParam.Type == FramugaType.полного_остекления)
            {
                if (framugaParam.Raspolozhenie == Raspolozhenie.Верх | framugaParam.Raspolozhenie == Raspolozhenie.Ниж)
                {
                    switch (pos)
                    {
                        case Raspolozhenie.Верх:
                        case Raspolozhenie.Ниж:
                            if (framugaParam.Otkrivanie == Otkrivanie.Левое | framugaParam.Otkrivanie == Otkrivanie.Правое)
                            {
                                if (framugaParam.Nalichniki[2] > 0 & framugaParam.Nalichniki[3] > 0)
                                {
                                    return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_ZV_K1")));
                                }
                                else if (framugaParam.Nalichniki[2] == 0 & framugaParam.Nalichniki[3] == 0)
                                {
                                    return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_ZV_K1")) - 
                                                                        short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")) * 2);
                                }
                                else
                                {
                                    return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_ZV_K1")) -    
                                                                        short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")));
                                }
                            }
                            else
                            {
                                return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_ZV_K1")) - 
                                                                    short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")) * 2);
                            }
                        default:
                            if (framugaParam.Otkrivanie == Otkrivanie.Левое | framugaParam.Otkrivanie == Otkrivanie.Правое)
                            {
                                if (framugaParam.Nalichniki[0] > 0)
                                {
                                    return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_ZB_K1")));
                                }
                                else
                                {
                                    return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_ZB_K2")));
                                }
                            }
                            else
                            {
                                return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_ZB_K2")));
                            }
                    }
                }
                else
                {
                    short tmpNal;
                    if (framugaParam.Raspolozhenie == Raspolozhenie.Лев)
                    {
                        tmpNal = framugaParam.Nalichniki[3];
                    }
                    else
                    {
                        tmpNal = framugaParam.Nalichniki[2];
                    }
                    switch (pos)
                    {
                        case Raspolozhenie.Верх:
                        case Raspolozhenie.Ниж:
                            if (framugaParam.Otkrivanie == Otkrivanie.Левое | framugaParam.Otkrivanie == Otkrivanie.Правое)
                            {
                                if (tmpNal > 0)
                                {
                                    return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_ZB_K1")));
                                }
                                else
                                {
                                    return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_ZB_K2")));
                                }
                            }
                            else
                            {
                                return (short)(framugaParam.Width - short.Parse(ini.ReadKey("Framuga", "POF_K_ZB_K2")));
                            }
                        default:
                            if (framugaParam.Otkrivanie == Otkrivanie.Левое | framugaParam.Otkrivanie == Otkrivanie.Правое)
                            {
                                if (framugaParam.Nalichniki[0] > 0)
                                {
                                    return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_ZV_K1")) - 
                                                                         short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")));
                                }
                                else
                                {
                                    return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_ZV_K1")) - 
                                                                         short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")) * 2);
                                }
                            }
                            else
                            {
                                return (short)(framugaParam.Height - short.Parse(ini.ReadKey("Framuga", "POF_K_ZV_K1")) - 
                                                                     short.Parse(ini.ReadKey("Framuga", "POF_K_ST_K2")) * 2);
                            }
                    }
                }
            }
            else
            {
                return 0;
            }
    }
    public short Porog_Razvertka
    {
        get
        {
            if (framugaParam.Type == FramugaType.полного_остекления)
            {
                if (framugaParam.Otkrivanie == Otkrivanie.Левое | framugaParam.Otkrivanie == Otkrivanie.Правое)
                {
                    return (short)(short.Parse(ini.ReadKey("Framuga", "POF_R_POR_NO")) + kp62 + kp90);
                }
                else
                {
                    return (short)(short.Parse(ini.ReadKey("Framuga", "POF_R_POR_VO")) + kp62 + kp90);
                }
            }
            else
            {
                return 0;
            }
        }
    }
    public short Zprofil_Razvertka
    {
        get
        {
            if (framugaParam.Type == FramugaType.полного_остекления)
            {
                short kTS;
                kTS = (short)(framugaParam.Steklo[0].Thick - 6);
                return (short)(Math.Round(short.Parse(ini.ReadKey("Framuga", "POF_GIB_ZP_K")) * 2 + 
                                          short.Parse(ini.ReadKey("Framuga", "POF_GIB_ZP_O")) - 3.4) - kTS + kz62 + (koef90 / 2));
            }
            else
            {
                return 0;
            }
        }
    }
    public short Steklo_Hight
    {
        get
        {
            if (framugaParam.Type == FramugaType.полного_остекления | framugaParam.Type == FramugaType.частичного_остекления) return framugaParam.Steklo[0].Height;
            else return 0;
        }
    }
    public short Steklo_Width
    {
        get
        {
            if (framugaParam.Type == FramugaType.полного_остекления | framugaParam.Type == FramugaType.частичного_остекления) return framugaParam.Steklo[0].Width;
            else return 0;
        }
    }
}
