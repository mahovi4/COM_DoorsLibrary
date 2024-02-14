internal class KorobkaDVM
{
    private readonly StoykaDVM Stoyka;
    private readonly PritolokaDVM Pritoloka;
    private readonly PorogDVM Porog;
    private readonly bool razbor;

    public KorobkaDVM(ref DVMParam param, ref Constants cons, ref IniFile iniDVM)
    {
        razbor = param.Razbor;
        Stoyka = new StoykaDVM(ref param, ref cons);
        Pritoloka = new PritolokaDVM(ref param, ref cons, ref iniDVM);
        if (param.Porog.Kod != 0)
        {
            Porog = new PorogDVM(ref param, ref cons, ref iniDVM);
        }
    }

    public short Stoyka_Height {
        get { return Stoyka.Height; }
    }
    public short Stoyka_DoborHeight
    {
        get { return Stoyka.DoborHeight; }
    }
    public short Pritoloka_Height
    {
        get { return Pritoloka.Height; }
    }
    public short Pritoloka_DoborHeight
    {
        get { return Pritoloka.DoborHeight; }
    }
    public bool IsPorog
    {
        get {
            return Porog != null;
        }
    }
    public short Porog_Height
    {
        get {
            if (IsPorog)
            {
                return Porog.Height;
            }
            else
            {
                return 0;
            }
        }
    }
    public short Porog_DoborHeight
    {
        get {
            if (IsPorog)
            {
                return Porog.DoborHeight;
            }
            else
            {
                return 0;
            }
        }
    }
    public short Porog_Razvertka
    {
        get {
            if (IsPorog)
            {
                return Porog.Razvertka;
            }
            else
            {
                return 0;
            }
        }
    }
    public double Porog_Anker
    {
        get {
            if (IsPorog)
            {
                return Porog.Anker;
            }
            else
            {
                return 0;
            }
        }
    }
    public short Porog_VirezHeight
    {
        get {
            if (IsPorog)
            {
                return Porog.VirezHeight;
            }
            else
            {
                return 0;
            }
        }
    }
    public short Porog_Num
    {
        get { return Porog.Num; }
    }
    public bool IsRazbornaya
    {
        get { return razbor; }
    }
}
