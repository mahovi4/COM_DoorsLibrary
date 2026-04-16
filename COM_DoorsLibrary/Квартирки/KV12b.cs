using System.Collections.Generic;

namespace COM_DoorsLibrary
{
    public sealed class KV12b : KVD
    {
        public override string Name => "КВ12b";
        public override string Description => "Орфей";
        public override bool IsLicPanel => true;
        public override bool IsCG => true;
        public override string MaketDir => @"k:\Заготовки, шаблоны\Квартирные двери\[СТ-КВ12]\";
        public override double LL_OtPola => 0;
        public override double LL_Height => Data.Height - 44;
        public override double LL_Width => Data.Width + 136;
        public override double VL_Height => 0;
        public override double VL_Width => 0;
        public override double VP_Length => Data.Height - 76.5; //Уголок монтажный петлевой
        public override double GP_Length => Data.Width - 56; //Торцевые профили
        public override double MP_Length => Data.Width - 87; //Уголок монтажный нижний
        public override double ProtivosOtstup => 231;
        public override double VS_Length => Data.Height;
        public override double GS_Length => Data.Width - 69;
        public override double RZK_Length => Data.Height;
        public override double RZK_PR_Length => Data.Width - 101;
        public override double POR_Pered => 0;
        public override double POR_Zad => 0;
        public override double RZP_Lengnth => Data.Height - 107;
        public override double Styazh_Lengnth => Data.Width - 88;

        public override double Nalichnik(Raspolozhenie pos)
        {
            switch (Data.Nalichniki[(short)pos])
            {
                case 60:
                case 70:
                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return 77.92;

                    return 77.76;
                case 0:
                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return 28.92;
                    return 27.76;
                case 20:
                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return 48.92;
                    return 47.76;
                default:
                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return Data.Nalichniki[(short)pos] + 7.92;
                    return Data.Nalichniki[(short)pos] + 7.76;
            }
        }

        public KV12b(TableData data, Constants cons)
            : base(data, cons)
        {
            var template = TemplateFileName.Substring(0, TemplateFileName.Length - 1);

            Parts.Add(new KVDPartInfo(Command_KVD.Лицевой_лист, "[СТ-КВ12]_Лицевой лист.SLDPRT", $"{template}_Лицевой лист"));
            Parts.Add(new KVDPartInfo(Command_KVD.Монтажный_профиль_петлевой, "[СТ-КВ12]_Уголок монтажный петлевой.SLDPRT", $"{template}_Уголок монтажный петлевой"));
            Parts.Add(new KVDPartInfo(Command_KVD.Монтажный_профиль_нижний, "[СТ-КВ12]_Уголок монтажный нижний.SLDPRT", $"{template}_Уголок монтажный нижний"));
            Parts.Add(new KVDPartInfo(Command_KVD.Верхний_профиль, "[СТ-КВ12]_Профиль торцевой верхний.SLDPRT", $"{template}_Торцевой профиль верхний"));
            Parts.Add(new KVDPartInfo(Command_KVD.Нижний_профиль, "[СТ-КВ12]_Профиль торцевой нижний.SLDPRT", $"{template}_Торцевой профиль нижний"));
            Parts.Add(new KVDPartInfo(Command_KVD.Замковая_стойка, "[СТ-КВ12]_Стойка ЗС_ПС.SLDPRT", $"{template}_{GetNalichikKod(GetNalichnik())}_{GetPositionKod()}_Стойка замковая"));
            Parts.Add(new KVDPartInfo(Command_KVD.Петлевая_стойка, "[СТ-КВ12]_Стойка ЗС_ПС.SLDPRT", $"{template}_{GetNalichikKod(GetNalichnik(false))}_{GetPositionKod(false)}_Стойка петлевая"));
            Parts.Add(new KVDPartInfo(Command_KVD.Притолока, "[СТ-КВ12]_Притолока.SLDPRT", $"{template}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_Притолока"));
            Parts.Add(new KVDPartInfo(Command_KVD.Порог, "[СТ-КВ12]_Порог.SLDPRT", $"{template}_{GetPorogKod()}"));
            Parts.Add(new KVDPartInfo(Command_KVD.РЖ_полотна, "[СТ-КВ12]_РЖП.SLDPRT", $"{template}_РЖП (2шт)"));
            Parts.Add(new KVDPartInfo(Command_KVD.РЖК_Замковая, "[СТ-КВ12]_РЖК ЗС_ПС.SLDPRT", $"{template}_РЖК ЗС-ПС (2шт)"));
            Parts.Add(new KVDPartInfo(Command_KVD.РЖК_Прит_Пор, "[СТ-КВ12]_РЖК притолка порог.SLDPRT", $"{template}_РЖК прит-пор (2шт)"));
        }
    }
}
