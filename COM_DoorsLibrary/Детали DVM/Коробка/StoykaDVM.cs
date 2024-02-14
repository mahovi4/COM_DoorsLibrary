using System;

internal class StoykaDVM
{
    private readonly short _height, _doborHeight;

    public StoykaDVM(ref DVMParam param, ref Constants cons)
    {
        if (param.Height > cons.LIST_HIGHT)
        {
            _height = (short)(Math.Round((double)(param.Height / 2)));
            _doborHeight = (short)(param.Height - _height);
        }
        else
        {
            _height = param.Height;
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
