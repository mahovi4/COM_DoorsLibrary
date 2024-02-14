internal class ListPolotnaDVM
{
    private readonly short _height; 
    private short _width;

    private DoborDVM VDobor;
    private readonly DoborDVM GDobor;
    private readonly DoborDVM DDobor;

    public ListPolotnaDVM(short fullHeight, short fullWidth, ref Constants cons)
    {
        short listHeight = (short)cons.LIST_HIGHT;
        short listWidth = (short)cons.LIST_WIDTH;

        if (fullHeight > listHeight)
        {
            if ((fullHeight - listHeight) < 150)
            {
                _height = (short)(listHeight - (150 - (fullHeight - listHeight)));
            }
            else
            {
                _height = listHeight;
            }
            GDobor = new DoborDVM();
        }
        else
        {
            _height = fullHeight;
        }
        if (fullWidth > listWidth)
        {
            if ((fullWidth - listWidth) < 150)
            {
                _width = (short)(listWidth - (150 - (fullWidth - listWidth)));
            }
            else
            {
                _width = listWidth;
            }
            VDobor = new DoborDVM();
        }
        else
        {
            _width = fullWidth;
        }
        if (!(VDobor == null))
        {
            VDobor.Height = _height;
            VDobor.Width = (short)(fullWidth - _width);
        }
        if (!(GDobor == null))
        {
            short _fullHeight;
            short _fullWidth;
            _fullWidth = (short)(fullHeight - _height);
            _fullHeight = fullWidth;
            if (_fullWidth > listWidth & (_fullHeight > listWidth | _fullHeight > listHeight))
            {
                GDobor.Height = _width;
                GDobor.Width = _fullWidth;
                DDobor = new DoborDVM((short)(_fullHeight - _width), _fullWidth);
            }
            GDobor.Height = _fullHeight;
            GDobor.Width = _fullWidth;
        }
    }

    public void AddVertDobor(int width)
    {
        VDobor = new DoborDVM(_height, (short)width);
        _width -= (short)width;
    }
    public short Height
    {
        get { return _height; }
    }
    public short Width
    {
        get { return _width; }
    }
    public bool IsVertDobor
    {
        get
        {
            if (!(VDobor == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public short VertDobor_Height
    {
        get
        {
            if (!(VDobor == null))
            {
                return VDobor.Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public short VertDobor_Width
    {
        get
        {
            if (!(VDobor == null))
            {
                return VDobor.Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public bool IsGorDobor
    {
        get
        {
            if (!(GDobor == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public short GorDobor_Height
    {
        get
        {
            if (!(GDobor == null))
            {
                return GDobor.Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public short GorDobor_Width
    {
        get
        {
            if (!(GDobor == null))
            {
                return GDobor.Width;
            }
            else
            {
                return 0;
            }
        }
    }
    public bool IsDopDobor
    {
        get
        {
            if (!(DDobor == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public short DopDobor_Height
    {
        get
        {
            if (!(DDobor == null))
            {
                return DDobor.Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public short DopDobor_Width
    {
        get
        {
            if (!(DDobor == null))
            {
                return DDobor.Width;
            }
            else
            {
                return 0;
            }
        }
    }
}
