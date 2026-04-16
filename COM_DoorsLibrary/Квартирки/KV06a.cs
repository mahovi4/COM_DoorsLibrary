using System.Collections.Generic;

namespace COM_DoorsLibrary
{
    public sealed class KV06a : KVD
    {
        public override string Name => "КВ06a";
        public override string Description => "РИО-Классика, РИО-Муар, РИО-Медный_Антик";
        public override bool IsLicPanel => false;
        public override bool IsCG => true;
        public override string MaketDir => @"k:\Заготовки, шаблоны\Квартирные двери\[СТ-КВ06]\";
        public override double LL_OtPola => 0;
        public override double LL_Height => Data.Height - 44;
        public override double LL_Width => Data.Width + 136;
        public override double VL_Height => 0;
        public override double VL_Width => 0;
        public override double VP_Length => Data.Height - 76; //Уголок монтажный петлевой
        public override double GP_Length => Data.Width - 56; //Торцевые профили
        public override double MP_Length => Data.Width - 88; //Уголок монтажный нижний
        public override double ProtivosOtstup => 231;
        public override double VS_Length => Data.Height;
        public override double GS_Length => Data.Width - 69;
        public override double RZK_Length => 0;
        public override double RZK_PR_Length => 0;
        public override double POR_Pered => 0;
        public override double POR_Zad => 0;
        public override double RZP_Lengnth => 0;
        public override double Styazh_Lengnth => 0;

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
                default:
                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return Data.Nalichniki[(short)pos] + 7.92;
                    return Data.Nalichniki[(short)pos] + 7.76;
            }
        }

        public KV06a(TableData data, Constants cons)
            : base(data, cons)
        {
            var template = TemplateFileName.Substring(0, TemplateFileName.Length - 1);

            Parts.Add(new KVDPartInfo(Command_KVD.Лицевой_лист, "[СТ-КВ06]_Лицевой_лист.SLDPRT", $"{template}_Лицевой лист"));
            Parts.Add(new KVDPartInfo(Command_KVD.Монтажный_профиль_петлевой, "[СТ-КВ06]_Монтажный_уголок_петлевой.SLDPRT", $"{template}_Уголок монтажный петлевой"));
            Parts.Add(new KVDPartInfo(Command_KVD.Монтажный_профиль_нижний, "[СТ-КВ06]_Монтажный_уголок_нижний.SLDPRT", $"{template}_Уголок монтажный нижний"));
            Parts.Add(new KVDPartInfo(Command_KVD.Верхний_профиль, "[СТ-КВ06]_Торцевой_профиль_верхний.SLDPRT", $"{template}_Торцевой профиль верхний"));
            Parts.Add(new KVDPartInfo(Command_KVD.Нижний_профиль, "[СТ-КВ06]_Торцевой_профиль_нижний.SLDPRT", $"{template}_Торцевой профиль нижний"));
            Parts.Add(new KVDPartInfo(Command_KVD.Замковая_стойка, "[СТ-КВ06]_Стойка_ЗС_ПС.SLDPRT", $"{template}_{GetNalichikKod(GetNalichnik())}_{GetPositionKod()}_Стойка замковая"));
            Parts.Add(new KVDPartInfo(Command_KVD.Петлевая_стойка, "[СТ-КВ06]_Стойка_ЗС_ПС.SLDPRT", $"{template}_{GetNalichikKod(GetNalichnik(false))}_{GetPositionKod(false)}_Стойка петлевая"));
            Parts.Add(new KVDPartInfo(Command_KVD.Притолока, "[СТ-КВ06]_Притолока.SLDPRT", $"{template}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_Притолока"));
            Parts.Add(new KVDPartInfo(Command_KVD.Порог, "[СТ-КВ06]_Порог.SLDPRT", $"{template}_{GetPorogKod()}"));
        }
    }
}
