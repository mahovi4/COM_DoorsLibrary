using static DM;

class Glazok
{
    private readonly GlazokParam glazokParam;
    public Glazok(short num, ref DMParam param, ref Constants cons)
    {
        glazokParam = param.Glazok[num];
    }
    public GlazokRaspolozhenie Raspolozhenie
    {
        get { return glazokParam.Raspolozhenie; }
    }
    public short OtPola
    {
        get { return glazokParam.OtPola; }
    }
}
