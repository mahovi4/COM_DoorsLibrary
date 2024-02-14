using System.Collections.Generic;

namespace COM_DoorsLibrary
{
    public sealed class KV07 : KVD
    {
        public override string Name => "КВ07";
        public override string Description => "Жардин";
        public override string MaketDir => @"k:\Заготовки, шаблоны\Квартирные двери\[СТ-КВ07]";
        public override double LL_Height => Data.Height - 45;
        public override double LL_Width => Data.Width + 144;
        public override double VL_Height => 0;
        public override double VL_Width => 0;
        public override double VP_Length => 0;
        public override double GP_Length => Data.Width - 57;
        public override double MP_Length => Data.Width - 89;
        public override double VS_Length => Data.Height;
        public override double GS_Length => Data.Width - 69;
        public override double RZK_Length => 0;
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

        public KV07(TableData data, Constants cons)
            : base(data, cons)
        {
            Parts.Add(new KVDPartInfo(Command_KVD.Лицевой_лист, "[СТ-КВ07]_Лицевой_лист.SLDPRT", $"{TemplateFileName}_LL"));
            Parts.Add(new KVDPartInfo(Command_KVD.Монтажный_профиль_нижний, "[СТ-КВ07]_Монтажный_уголок.SLDPRT", $"{TemplateFileName}_M"));
            Parts.Add(new KVDPartInfo(Command_KVD.Верхний_профиль, "[СТ-КВ07]_Торцевой_профиль.SLDPRT", $"{TemplateFileName}_T"));
            Parts.Add(new KVDPartInfo(Command_KVD.Замковая_стойка, "[СТ-КВ07]_Стойка_ЗС_ПС.SLDPRT", $"{TemplateFileName}_{GetNalichikKod(GetNalichnik())}_{GetPositionKod()}_ZS"));
            Parts.Add(new KVDPartInfo(Command_KVD.Петлевая_стойка, "[СТ-КВ07]_Стойка_ЗС_ПС.SLDPRT", $"{TemplateFileName}_{GetNalichikKod(GetNalichnik(false))}_{GetPositionKod(false)}_PS"));
            Parts.Add(new KVDPartInfo(Command_KVD.Притолока, "[СТ-КВ07]_Притолока.SLDPRT", $"{TemplateFileName}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_US"));
            Parts.Add(new KVDPartInfo(Command_KVD.Порог, "[СТ-КВ07]_Порог40.SLDPRT", $"{TemplateFileName}_{GetPorogKod()}"));

            //var llPath = $@"\{Name}\ЛИЦЕВОЙ ЛИСТ\{Data.Height}\{Data.Height}x{Data.Width}_[СТ-КВ07]_L.DXF";

            //var mpPath = $@"\{Name}\ПРОФИЛИ\{Data.Width}_[СТ-КВ07]_M.DXF";
            //var tpPath = $@"\{Name}\ПРОФИЛИ\{Data.Width}_[СТ-КВ07]_T.DXF";

            //var zsPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Вертикальные\{Data.Height}_[СТ-КВ07]_{GetNalichikKod(GetNalichnik())}_Z.DXF";
            //var psPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Вертикальные\{Data.Height}_[СТ-КВ07]_{GetNalichikKod(GetNalichnik(false))}_P.DXF";
            //var usPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Горизонтальные\{Data.Width}_[СТ-КВ07]_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_G.DXF";
            //var dsPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Горизонтальные\{Data.Width}_[СТ-КВ07]_{GetPorogKod()}.DXF";

            //pathes = new Dictionary<string, string>
            //{
            //    {$"{TemplateFileName}_LL.DXF", llPath},

            //    {$"{TemplateFileName}_M.DXF", mpPath},
            //    {$"{TemplateFileName}_T.DXF", tpPath},

            //    {$"{TemplateFileName}_{GetNalichikKod(GetNalichnik())}_{GetPositionKod()}_ZS.DXF", zsPath},
            //    {$"{TemplateFileName}_{GetNalichikKod(GetNalichnik(false))}_{GetPositionKod(false)}_PS.DXF", psPath},
            //    {$"{TemplateFileName}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_US.DXF", usPath},
            //    {$"{TemplateFileName}_{GetPorogKod()}.DXF", dsPath}
            //};
        }
    }
}
