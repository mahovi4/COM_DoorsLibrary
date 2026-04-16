namespace COM_DoorsLibrary
{
    public sealed class KV10 : KVD
    {
        public override string Name => "КВ10";
        public override string Description => "КВ-1(70)";
        public override string MaketDir => @"k:\Заготовки, шаблоны\Квартирные двери\[KВ-1(70)]";
        public override double LL_OtPola => GetLlOtPola(Data.Porog);
        public override double LL_Height => Data.Height - GetPorCoefficient(Data.Porog);
        public override double LL_Width => Data.Width - 34;
        public override double VL_Height => 0;
        public override double VL_Width => 0;
        public override double VP_Length => Data.Height - GetPorVPCoefficient(Data.Porog);
        public override double GP_Length => Data.Width - 55.6;
        public override double MP_Length => Data.Width - 90.2;
        public override double ProtivosOtstup => Data.Porog == 40 ? 250 : 250 + 11;
        public override double VS_Length => Data.Height;
        public override double GS_Length => Data.Width - 103;
        public override double RZK_Length => Data.Height - 20;
        public override double POR_Pered => GetPorPered(Data.Porog);
        public override double POR_Zad => GetPorZad(Data.Porog);
        public override double RZP_Lengnth => GetRzpLength(Data.Height, Data.Porog);

        public override double Nalichnik(Raspolozhenie pos)
        {
            switch (Data.Nalichniki[(short)pos])
            {
                case 60:
                case 70:
                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return 76.15;
                    return 76.61;
                case 0:
                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return 26.64;
                    return 26.61;
                case 20:
                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return 46.64;
                    return 46.61;
                default:
                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return Data.Nalichniki[(short)pos] + 6.15;
                    return Data.Nalichniki[(short)pos] + 6.61;
            }
        }

        public KV10(TableData data, Constants cons)
            : base(data, cons)
        {
            var template = TemplateFileName;

            Parts.Add(new KVDPartInfo(Command_KVD.Лицевой_лист, "[ДК-1(70)]_L.SLDPRT", $"{template}{GetOtkrivanieKod()}_LL"));
            Parts.Add(new KVDPartInfo(Command_KVD.Замковой_профиль, "[ДК-1(70)]_Z_P_PROF.SLDPRT", $"{template}_ZP"));
            Parts.Add(new KVDPartInfo(Command_KVD.Петлевой_профиль, "[ДК-1(70)]_Z_P_PROF.SLDPRT", $"{template}_PP"));
            Parts.Add(new KVDPartInfo(Command_KVD.Верхний_профиль, "[ДК-1(70)]_U_PROF.SLDPRT", $"{template}_UP"));
            Parts.Add(new KVDPartInfo(Command_KVD.Нижний_профиль, "[ДК-1(70)]_D_PROF.SLDPRT", $"{template}_DP"));
            Parts.Add(new KVDPartInfo(Command_KVD.Монтажный_профиль_нижний, "[ДК-1(70)]_M_PROF.SLDPRT", $"{template}_TP"));
            Parts.Add(new KVDPartInfo(Command_KVD.Замковая_стойка, "[ДК-1(70)]_K1_Z_P.SLDPRT", $"{template}_{GetNalichikKod(GetNalichnik())}{GetOtkrivanieKod()}_{GetPositionKod()}_ZS"));
            Parts.Add(new KVDPartInfo(Command_KVD.Петлевая_стойка, "[ДК-1(70)]_K1_Z_P.SLDPRT", $"{template}_{GetNalichikKod(GetNalichnik(false))}{GetOtkrivanieKod()}_{GetPositionKod(false)}_PS"));
            Parts.Add(new KVDPartInfo(Command_KVD.Притолока, "[ДК-1(70)]_G.SLDPRT", $"{template}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}{GetOtkrivanieKod()}_US"));
            Parts.Add(new KVDPartInfo(Command_KVD.Порог, "[ДК-1(70)]_POR.SLDPRT", $"{template}_{GetOtkrivanieKod()}{GetPorogKod()}"));
            Parts.Add(new KVDPartInfo(Command_KVD.РЖК_Замковая, "[ДК-1(70)]_RGK.SLDPRT", $"{template}_ZR"));
            Parts.Add(new KVDPartInfo(Command_KVD.РЖК_Петлевая, "[ДК-1(70)]_RGK.SLDPRT", $"{template}_PR"));
            Parts.Add(new KVDPartInfo(Command_KVD.РЖ_полотна, "[ДК-1(70)]_RZP.SLDPRT", $"{template}_RZP"));
        }

        private static double GetPorCoefficient(short porogKod)
        {
            switch (porogKod)
            {
                case (short)PorogNames.Порог_14:
                case (short)PorogNames.Порог_25:
                case (short)PorogNames.Порог_25_скос:
                    return 13;

                default:
                    return 24;
            }
        }

        private static double GetPorVPCoefficient(short porogKod)
        {
            switch (porogKod)
            {
                case (short)PorogNames.Порог_14:
                case (short)PorogNames.Порог_25:
                case (short)PorogNames.Порог_25_скос:
                    return 67.5;

                default:
                    return 78.5;
            }
        }

        private double GetPorPered(short porogKod)
        {
            switch (porogKod)
            {
                case (short)PorogNames.Порог_25_скос:
                case (short)PorogNames.Порог_25:
                case (short)PorogNames.Порог_14:
                    return 91.15 - 7;

                case (short)PorogNames.Порог_40:
                    return 102.15 - 7;

                default:
                    return 0;
            }
        }

        private static double GetPorZad(short porogKod)
        {
            switch (porogKod)
            {
                case (short)PorogNames.Порог_14:
                    return 47.26;

                case (short)PorogNames.Порог_25_скос:
                    return 62.26;

                case (short)PorogNames.Порог_40:
                    return 85.6;

                default:
                    return 0;
            }
        }

        private double GetLlOtPola(short porogKod)
        {
            switch (porogKod)
            {
                case (short)PorogNames.Порог_14:
                case (short)PorogNames.Порог_25:
                case (short)PorogNames.Порог_25_скос:
                    return 5;

                default:
                    return 16;
            }
        }

        private static double GetRzpLength(short doorHeight, short porogKod)
        {
            switch (porogKod)
            {
                case (short)PorogNames.Порог_14:
                case (short)PorogNames.Порог_25:
                case (short)PorogNames.Порог_25_скос:
                    return doorHeight - 93;

                default:
                    return doorHeight - 93 - 11;
            }
        }
    }
}
