using System.Collections.Generic;

namespace COM_DoorsLibrary
{
    public sealed class KV08 : KVD
    {
        public override string Name => "КВ08";
        public override string Description => "РИО-Метал_Метал";
        public override string MaketDir => @"k:\Заготовки, шаблоны\Квартирные двери\[СТ-КВ08]";
        public override double LL_Height => Data.Height - 29;
        public override double LL_Width => Data.Width - 34;
        public override double VL_Height => Data.Height - 83;
        public override double VL_Width => Data.Width + 46;
        public override double VP_Length => 0;
        public override double GP_Length => Data.Width - 91.4;
        public override double MP_Length => 0;
        public override double VS_Length => Data.Height;
        public override double GS_Length => Data.Width - 69;
        public override double RZK_Length => 0;
        public override double Nalichnik(Raspolozhenie pos)
        {
            switch (Data.Nalichniki[(short)pos])
            {
                case 60:
                case 70:
                    if(Data.Otkrivanie == Otkrivanie.Левое || Data.Otkrivanie == Otkrivanie.Правое)
                        return 77.62;

                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return Data.Nalichniki[(short)pos] + 7.84;

                    return Data.Nalichniki[(short)pos] + 7.63;

                case 50:
                case 100:
                    if (Data.Otkrivanie == Otkrivanie.Левое || Data.Otkrivanie == Otkrivanie.Правое)
                        return Data.Nalichniki[(short)pos] + 7.62;

                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return 107.84;

                    return 107.63;
                case 0:
                    if (Data.Otkrivanie == Otkrivanie.Левое || Data.Otkrivanie == Otkrivanie.Правое)
                        return 27.62;

                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return 49 + 7.84;

                    return 49 + 7.63;
                default:
                    if (Data.Otkrivanie == Otkrivanie.Левое || Data.Otkrivanie == Otkrivanie.Правое)
                        return Data.Nalichniki[(short) pos] + 7.62;

                    if (pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
                        return Data.Nalichniki[(short)pos] + 7.84;

                    return Data.Nalichniki[(short)pos] + 7.63;
            }
        }

        public KV08(TableData data, Constants cons)
            : base(data, cons)
        {
            Parts.Add(new KVDPartInfo(Command_KVD.Лицевой_лист, "[СТ-КВ08]_Лицевой_лист.SLDPRT", $"{TemplateFileName}_LL"));
            Parts.Add(new KVDPartInfo(Command_KVD.Внутренний_лист, "[СТ-КВ08]_Внутренний_лист.SLDPRT", $"{TemplateFileName}_VL"));
            Parts.Add(new KVDPartInfo(Command_KVD.Верхний_профиль, "[СТ-КВ08]_Торцевой_профиль.SLDPRT", $"{TemplateFileName}_TP"));
            Parts.Add(new KVDPartInfo(Command_KVD.Замковая_стойка, 
                (Data.Otkrivanie== Otkrivanie.Левое || Data.Otkrivanie == Otkrivanie.Правое 
                    ? "[СТ-КВ08]_Стойка_ЗС_ПС.SLDPRT" 
                    : "[СТ-КВ08-К3]_Стойка_ЗС_ПС.SLDPRT"), 
                $"{TemplateFileName}_{GetNalichikKod(GetNalichnik())}_{GetPositionKod()}_ZS"));
            Parts.Add(new KVDPartInfo(Command_KVD.Петлевая_стойка,
                (Data.Otkrivanie == Otkrivanie.Левое || Data.Otkrivanie == Otkrivanie.Правое
                    ? "[СТ-КВ08]_Стойка_ЗС_ПС.SLDPRT"
                    : "[СТ-КВ08-К3]_Стойка_ЗС_ПС.SLDPRT"),
                $"{TemplateFileName}_{GetNalichikKod(GetNalichnik(false))}_{GetPositionKod(false)}_PS"));
            Parts.Add(new KVDPartInfo(Command_KVD.Притолока,
                (Data.Otkrivanie == Otkrivanie.Левое || Data.Otkrivanie == Otkrivanie.Правое
                    ? "[СТ-КВ08]_Притолока.SLDPRT"
                    : "[СТ-КВ08-К3]_Притолока.SLDPRT"),
                $"{TemplateFileName}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_US"));
            Parts.Add(new KVDPartInfo(Command_KVD.Порог,
                (Data.Otkrivanie == Otkrivanie.Левое || Data.Otkrivanie == Otkrivanie.Правое
                    ? "[СТ-КВ08]_Порог.SLDPRT"
                    : "[СТ-КВ08-К3]_Порог.SLDPRT"),
                $"{TemplateFileName}_{GetPorogKod()}"));

            //var llPath = $@"\{Name}\ЛИЦЕВОЙ ЛИСТ\{GetFurnituraKod(Com.ЛицевойЛист)}\{Data.Height}\{Data.Height}x{Data.Width}_[СТ-КВ08]{GetOtkrivanieKod()}_L.DXF";
            //var vlPath = $@"\{Name}\ВНУТРЕННИЙ ЛИСТ\{GetFurnituraKod(Com.ВнутреннийЛист)}\{Data.Height}\{Data.Height}x{Data.Width}_[СТ-КВ08]{GetOtkrivanieKod()}_V.DXF";

            //var tpPath = $@"\{Name}\ПРОФИЛИ\{Data.Width}_[СТ-КВ08]_T.DXF";

            //var zsPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Вертикальные\Замковые\{GetFurnituraKod(Com.Профили)}\{Data.Height}_[СТ-КВ08]_{GetNalichikKod(GetNalichnik())}{GetOtkrivanieKod()}_Z.DXF";
            //var psPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Вертикальные\Петлевые\{Data.Height}_[СТ-КВ08]_{GetNalichikKod(GetNalichnik(false))}{GetOtkrivanieKod()}_P.DXF";
            //var usPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Горизонтальные\{Data.Width}_[СТ-КВ08]_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}{GetOtkrivanieKod()}_G.DXF";
            //var dsPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Горизонтальные\{Data.Width}_[СТ-КВ08]_{GetPorogKod()}.DXF";

            //pathes = new Dictionary<string, string>
            //{
            //    {$"{TemplateFileName}_LL.DXF", llPath},
            //    {$"{TemplateFileName}_VL.DXF", vlPath},

            //    {$"{TemplateFileName}_TP.DXF", tpPath},

            //    {$"{TemplateFileName}_{GetNalichikKod(GetNalichnik())}_{GetPositionKod()}_ZS.DXF", zsPath},
            //    {$"{TemplateFileName}_{GetNalichikKod(GetNalichnik(false))}_{GetPositionKod(false)}_PS.DXF", psPath},
            //    {$"{TemplateFileName}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_US.DXF", usPath},
            //    {$"{TemplateFileName}_{GetPorogKod()}.DXF", dsPath}
            //};
        }
    }
}
