using System.Collections.Generic;

namespace COM_DoorsLibrary
{
    public sealed class KV01b : KVD
    {
        public override string Name => "КВ01b";
        public override string Description => "Комфорт-ВО";
        public override string MaketDir => @"k:\Заготовки, шаблоны\Квартирные двери\[KOMPF_VO]";
        public override double LL_OtPola => GetLlOtPola(Data.Porog);
        public override double LL_Height => Data.Height - GetPorCoefficient(Data.Porog);
        public override double LL_Width => Data.Width + 129;
        public override double VL_Height => 0;
        public override double VL_Width => 0;
        public override double VP_Length => 0;
        public override double GP_Length => Data.Width - 95;
        public override double MP_Length => Data.Width - 95;
        public override double ProtivosOtstup => Data.Porog == 40 ? 250 : 250 + 11;
        public override double VS_Length => Data.Height - 20;
        public override double GS_Length => Data.Width;
        public override double RZK_Length => Data.Height - 2;
        public override double POR_Pered => GetPorPered(Data.Porog);
        public override double POR_Zad => GetPorZad(Data.Porog);
        public override double RZP_Lengnth => GetRzpLength(Data.Height, Data.Porog);

        public override double Nalichnik(Raspolozhenie pos)
        {
            switch (Data.Nalichniki[(short)pos])
            {
                case 50:
                case 100:
                    return 108.5;
                case 0:
                    return 61.5;
                default:
                    return Data.Nalichniki[(short)pos] + 58.5;
            }
        }

        public KV01b(TableData data, Constants cons)
            : base(data, cons)
        {
            var template = TemplateFileName.Substring(0, TemplateFileName.Length - 1);

            Parts.Add(new KVDPartInfo(Command_KVD.Лицевой_лист, "[KOMPH_VO]_L.SLDPRT", $"{template}_VO_LL"));
            Parts.Add(new KVDPartInfo(Command_KVD.Верхний_профиль, "[KOMPH_VO]_OBKU.SLDPRT", $"{template}_VO_OU"));
            Parts.Add(new KVDPartInfo(Command_KVD.Нижний_профиль, "[KOMPH_VO]_OBKD.SLDPRT", $"{template}_VO_OD"));
            Parts.Add(new KVDPartInfo(Command_KVD.Монтажный_профиль_нижний, "[KOMPH_VO]_NP.SLDPRT", $"{template}_VO_NP"));
            Parts.Add(new KVDPartInfo(Command_KVD.Замковая_стойка, "[KOMPH_VO]_K3_ZS_PS.SLDPRT", $"{template}_{GetNalichikKod(GetNalichnik())}_VO_{GetPositionKod()}_ZS"));
            Parts.Add(new KVDPartInfo(Command_KVD.Петлевая_стойка, "[KOMPH_VO]_K3_ZS_PS.SLDPRT", $"{template}_{GetNalichikKod(GetNalichnik(false))}_VO_{GetPositionKod(false)}_PS"));
            Parts.Add(new KVDPartInfo(Command_KVD.Притолока, "[KOMPH_VO]_K3_MAC.SLDPRT", $"{template}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_VO_US"));
            Parts.Add(new KVDPartInfo(Command_KVD.Порог, "[KOMPH_VO]_K3_POR.SLDPRT", $"{template}_VO_POR"));
            Parts.Add(new KVDPartInfo(Command_KVD.РЖК_Замковая, "[KOMPH_VO]_RZK.SLDPRT", $"{template}_VO_RZK"));
        }

        private static double GetPorCoefficient(short porogKod)
        {
            switch (porogKod)
            {
                case (short)PorogNames.Порог_14:
                case (short)PorogNames.Порог_25:
                case (short)PorogNames.Порог_25_скос:
                    return 29 + 4;

                default:
                    return 40;
            }
        }

        private double GetPorPered(short porogKod)
        {
            switch (porogKod)
            {
                case (short)PorogNames.Порог_25_скос:
                case (short)PorogNames.Порог_25:
                case (short)PorogNames.Порог_14:
                    return Data.LicPanel ? 79.65 : 71.65;

                case (short)PorogNames.Порог_40:
                    return Data.LicPanel ? 90.65 : 82.65;

                default:
                    return 0;
            }
        }

        private static double GetPorZad(short porogKod)
        {
            switch (porogKod)
            {
                case (short)PorogNames.Порог_14:
                    return 43.26;

                case (short)PorogNames.Порог_25_скос:
                    return 58.26;

                case (short)PorogNames.Порог_40:
                    return 82.75;

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
                    return 4;

                default:
                    return 15;
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
