using System;

internal class PorogDVM
{
    private readonly short _razvertka, _height, _doborHeight, Virez, _num;
    private readonly double _anker;

    public PorogDVM(ref DVMParam param, ref Constants cons, ref IniFile iniDVM)
    {
        _num = param.Porog.Kod;
        short k = short.Parse(iniDVM.ReadKey("Korobka", "DVM_K_GSK"));
        if ((param.Width - k) > cons.LIST_HIGHT)
        {
            _height = (short)(Math.Round((double)((param.Width - k) / 2)));
            _doborHeight = (short)((param.Width - k) - _height);
        }
        else
        {
            _height = (short)(param.Width - k);
            _doborHeight = 0;
        }
        switch (param.Porog.Kod)
        {
            case 40:
                _razvertka = short.Parse(iniDVM.ReadKey("Korobka", "DVM_RAZV_40"));
                Virez = short.Parse(iniDVM.ReadKey("Korobka", "DVM_VIREZ_40"));
                _anker = double.Parse(iniDVM.ReadKey("Korobka", "DVM_ANKER_40"));
                break;
            case 25:
                _razvertka = short.Parse(iniDVM.ReadKey("Korobka", "DVM_RAZV_25"));
                Virez = short.Parse(iniDVM.ReadKey("Korobka", "DVM_VIREZ_25"));
                _anker = double.Parse(iniDVM.ReadKey("Korobka", "DVM_ANKER_25"));
                break;
            case 14:
                _razvertka = short.Parse(iniDVM.ReadKey("Korobka", "DVM_RAZV_14"));
                Virez = short.Parse(iniDVM.ReadKey("Korobka", "DVM_VIREZ_14"));
                _anker = double.Parse(iniDVM.ReadKey("Korobka", "DVM_ANKER_14"));
                break;
            default:
                _razvertka = 0;
                Virez = 0;
                break;
        }
    }

    public short Height
    {
        get { return _height; }
    }
    public short DoborHeight
    {
        get { return _doborHeight; }
    }
    public short Razvertka
    {
        get { return _razvertka; }
    }
    public double Anker
    {
        get { return _anker; }
    }
    public short VirezHeight
    {
        get { return Virez; }
    }
    public short Num
    {
        get { return _num; }
    }
}
