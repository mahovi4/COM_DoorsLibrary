internal class DoborDVM
{
    private short _height, _width;

    public DoborDVM(short height, short width)
    {
        _height = height;
        _width = width;
    }
    public DoborDVM()
    {
        _height = 0;
        _width = 0;
    }

    public short Height
    {
        get { return _height; }
        set { _height = value; }
    }
    public short Width
    {
        get { return _width; }
        set { _width = value; }
    }
}
