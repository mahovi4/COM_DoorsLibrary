internal class OtvAntipan
{
    private readonly double _otKraya, _otstup, _diam;
    public OtvAntipan(double otKraya, double otstup, double diam)
    {
        _otKraya = otKraya;
        _otstup = otstup;
        _diam = diam;
    }
    public double OtKraya
    {
        get { return _otKraya; }
    }
    public double Otstup
    {
        get { return _otstup; }
    }
    public double Diam
    {
        get { return _diam; }
    }
}
