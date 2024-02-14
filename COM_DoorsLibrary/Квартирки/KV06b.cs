using System.Collections.Generic;

namespace COM_DoorsLibrary
{
    public sealed class KV06b : KVD
    {
        public override string Name => "КВ06b";
        public override string Description => "Айсберг, Елена, Венера и т.д.";
        public override string MaketDir => @"k:\Заготовки, шаблоны\Квартирные двери\[СТ-КВ06]\";
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

        public KV06b(TableData data, Constants cons)
            : base(data, cons)
        {
            var template = TemplateFileName.Substring(0, TemplateFileName.Length - 1);

            Parts.Add(new KVDPartInfo(Command_KVD.Лицевой_лист, "[СТ-КВ06]_Лицевой_лист.SLDPRT", $"{template}_LL"));
            Parts.Add(new KVDPartInfo(Command_KVD.Монтажный_профиль_нижний, "[СТ-КВ06]_Монтажный_уголок.SLDPRT", $"{template}_M"));
            Parts.Add(new KVDPartInfo(Command_KVD.Верхний_профиль, "[СТ-КВ06]_Торцевой_профиль.SLDPRT", $"{template}_T"));
            Parts.Add(new KVDPartInfo(Command_KVD.Замковая_стойка, "[СТ-КВ06]_Стойка_ЗС_ПС.SLDPRT", $"{template}_{GetNalichikKod(GetNalichnik())}_{GetPositionKod()}_ZS"));
            Parts.Add(new KVDPartInfo(Command_KVD.Петлевая_стойка, "[СТ-КВ06]_Стойка_ЗС_ПС.SLDPRT", $"{template}_{GetNalichikKod(GetNalichnik(false))}_{GetPositionKod(false)}_PS"));
            Parts.Add(new KVDPartInfo(Command_KVD.Притолока, "[СТ-КВ06]_Притолока.SLDPRT", $"{template}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_US"));
            Parts.Add(new KVDPartInfo(Command_KVD.Порог, "[СТ-КВ06]_Порог.SLDPRT", $"{template}_{GetPorogKod()}"));

            //var llPath = $@"\{Name}\ЛИЦЕВОЙ ЛИСТ\{Data.Height}\{Data.Height}x{Data.Width}_[СТ-КВ06]_L.DXF";

            //var mpPath = $@"\{Name}\ПРОФИЛИ\{Data.Width}_[СТ-КВ06]_M.DXF";
            //var tpPath = $@"\{Name}\ПРОФИЛИ\{Data.Width}_[СТ-КВ06]_T.DXF";

            //var zsPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Вертикальные\{Data.Height}_[СТ-КВ06]_{GetNalichikKod(GetNalichnik())}_Z.DXF";
            //var psPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Вертикальные\{Data.Height}_[СТ-КВ06]_{GetNalichikKod(GetNalichnik(false))}_P.DXF";
            //var usPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Горизонтальные\{Data.Width}_[СТ-КВ06]_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_G.DXF";
            //var dsPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Горизонтальные\{Data.Width}_[СТ-КВ06]_{GetPorogKod()}.DXF";

            //pathes = new Dictionary<string, string>
            //{
            //    {$"{template}_LL.DXF", llPath},

            //    {$"{template}_M.DXF", mpPath},
            //    {$"{template}_T.DXF", tpPath},

            //    {$"{template}_{GetNalichikKod(GetNalichnik())}_{GetPositionKod()}_ZS.DXF", zsPath},
            //    {$"{template}_{GetNalichikKod(GetNalichnik(false))}_{GetPositionKod(false)}_PS.DXF", psPath},
            //    {$"{template}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_US.DXF", usPath},
            //    {$"{template}_{GetPorogKod()}.DXF", dsPath}
            //};
        }
    }
}
