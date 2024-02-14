using System;

internal class PritolokaDVM
{
    private readonly short _height, _doborHeight;

    public PritolokaDVM(ref DVMParam param, ref Constants cons, ref IniFile iniDVM)
    {
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
    }

    public short Height
    {
        get { return _height; }
    }
    public short DoborHeight
    {
        get { return _doborHeight; }
    }
}
