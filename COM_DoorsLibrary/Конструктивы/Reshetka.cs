using System;
using static DM;

internal class Reshetka
{
    private readonly short ROtPola, RVir, k;
    private readonly double ROtstup, ROtKraya, WLL, WVL;
    private readonly ReshParam reshParam;

    public Reshetka(ref DMParam param, short num, StvorkaDM stvorka)
    {
        reshParam = param.Resh[num];
        if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
        {
            if (param.Nalichniki[(short)Raspolozhenie.Верх] == 0)
                k = 25;
            else
                k = 10;
        }
        else
        {
            k = 25;
        }
        ROtPola = reshParam.OtPola;
        switch (num)
        {
            case 0:
                WLL = stvorka.LList_Width;
                WVL = stvorka.VList_Width;
                break;
            case 1:
                ROtPola = (short)(param.Height - reshParam.Height - reshParam.OtPola - k + 17);
                WLL = stvorka.LList_Width;
                WVL = stvorka.VList_Width;
                break;
            case 2:
                WLL = stvorka.LList_Width;
                WVL = stvorka.VList_Width;
                break;
            case 3:
                ROtPola = (short)(param.Height - reshParam.Height - reshParam.OtPola - k + 17);
                WLL = stvorka.LList_Width;
                WVL = stvorka.VList_Width;
                break;
        }
        if (reshParam.Type == eReshetka.ПП_решетка)
        {
            double dtmp = ((double)reshParam.Height / 40);
            dtmp--;
            if ((dtmp - (Math.Truncate(dtmp))) >= 0.5)
                RVir = (short)Math.Ceiling(dtmp);
            else
                RVir = (short)Math.Floor(dtmp);
            ROtstup = (reshParam.Height - (RVir * 2 - 1) * 20) / 2;
            if (param.Otkrivanie.Value == Otkrivanie.Левое | param.Otkrivanie.Value == Otkrivanie.Правое)
            {
                ROtKraya = WLL + 100 + (WVL / 2);
            }
            else
            {
                ROtKraya = WLL / 2;
            }
        }
        else
        {
            RVir = 2;
            ROtstup = 0;
            ROtKraya = 0;
        }
    }

    public short Hight
    {
        get
        {
            if (reshParam.Type == eReshetka.ПП_решетка)
            {
                return reshParam.Height;
            }
            else
            {
                if (reshParam.Height > 20)
                {
                    return (short)(reshParam.Height - 20);
                }
                else
                {
                    return reshParam.Height;
                }
            }
        }
    }
    public short Width
    {
        get
        {
            if (reshParam.Type == eReshetka.ПП_решетка)
            {
                return reshParam.Width;
            }
            else
            {
                if (reshParam.Width > 20)
                {
                    return (short)(reshParam.Width - 20);
                }
                else
                {
                    return reshParam.Width;
                }
            }
        }
    }
    public short OtPola
    {
        get { return ROtPola; }
    }
    public short Vir
    {
        get { return RVir; }
    }
    public double Otstup
    {
        get { return ROtstup; }
    }
    public double OtKraya
    {
        get { return ROtKraya; }
    }
    public eReshetka Type
    {
        get { return reshParam.Type; }
    }
}

