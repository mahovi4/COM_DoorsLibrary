using System.Collections.Generic;

namespace COM_DoorsLibrary
{
    public sealed class KV01b : KVD
    {
        public override string Name => "КВ01b";
        public override string Description => "Комфорт-ВО";
        public override string MaketDir => @"k:\Заготовки, шаблоны\Квартирные двери\[KOMPF_VO]";
        public override double LL_Height => Data.Height - 40;
        public override double LL_Width => Data.Width + 129;
        public override double VL_Height => 0;
        public override double VL_Width => 0;
        public override double VP_Length => 0;
        public override double GP_Length => Data.Width - 95;
        public override double MP_Length => Data.Width - 95;
        public override double VS_Length => Data.Height - 20;
        public override double GS_Length => Data.Width;
        public override double RZK_Length => Data.Height - 2;
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

            //var llPath = $@"\{Name}\ЛИЦЕВОЙ ЛИСТ\{GetFurnituraKod(Com.ЛицевойЛист)}\{Data.Height}\{Data.Height}x{Data.Width}_[KOMPH]_VO_L.DXF";

            //var npPath = $@"\{Name}\ПРОФИЛИ\{Data.Width}_[KOMPH]_VO_NP.DXF";
            //var ouPath = $@"\{Name}\ПРОФИЛИ\{Data.Width}_[KOMPH]_VO_OU.DXF";
            //var odPath = $@"\{Name}\ПРОФИЛИ\{Data.Width}_[KOMPH]_VO_OD.DXF";

            //var zsPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Вертикальные\Замковые\{GetFurnituraKod(Com.Профили)}\{Data.Height}_[KOMPH]_{GetNalichikKod(GetNalichnik())}_VO_Z.DXF";
            //var psPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Вертикальные\Петлевые\{Data.Height}_[KOMPH]_{GetNalichikKod(GetNalichnik(false))}_VO_P.DXF";
            //var usPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Горизонтальные\{Data.Width}_[KOMPH]_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_VO_G.DXF";
            //var dsPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Горизонтальные\{Data.Width}_[KOMPH]_VO_POR.DXF";

            //var rzPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\РЖК\{Data.Height}_[KOMPH]_VO_RZK.DXF";

            //pathes = new Dictionary<string, string>
            //{
            //    {$"{template}_VO_LL.DXF", llPath},

            //    {$"{template}_VO_NP.DXF", npPath},
            //    {$"{template}_VO_OU.DXF", ouPath},
            //    {$"{template}_VO_OD.DXF", odPath},

            //    {$"{template}_{GetNalichikKod(GetNalichnik())}_VO_{GetPositionKod()}_ZS.DXF", zsPath},
            //    {$"{template}_{GetNalichikKod(GetNalichnik(false))}_VO_{GetPositionKod(false)}_PS.DXF", psPath},
            //    {$"{template}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_VO_US.DXF", usPath},
            //    {$"{template}_VO_POR.DXF", dsPath},

            //    {$"{template}_VO_RZK.DXF", rzPath}
            //};
        }
    }
}
