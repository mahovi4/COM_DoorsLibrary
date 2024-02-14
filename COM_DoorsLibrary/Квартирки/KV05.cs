using System.Collections.Generic;

namespace COM_DoorsLibrary
{
    public sealed class KV05 : KVD
    {
        public override string Name => "КВ05";
        public override string Description => "ДМ1-МДФ1";
        public override string MaketDir { get; }
        public override double LL_Height { get; }
        public override double LL_Width { get; }
        public override double VL_Height { get; }
        public override double VL_Width { get; }
        public override double VP_Length { get; }
        public override double GP_Length { get; }
        public override double MP_Length { get; }
        public override double VS_Length { get; }
        public override double GS_Length { get; }
        public override double RZK_Length { get; }
        public override double Nalichnik(Raspolozhenie pos)
        {
            throw new System.NotImplementedException();
        }

        public KV05(TableData data, Constants cons)
            : base(data, cons)
        {
            var llPath = $@"\{Name}\ЛИЦЕВОЙ ЛИСТ\{GetFurnituraKod(Com.ЛицевойЛист)}\{GetMetalKod(Data.Thick_LL)}\{Data.Height}\{Data.Height}x{Data.Width}_[DM1MDF1]_L.DXF";
            var vlPath = $@"\{Name}\ВНУТРЕННИЙ ЛИСТ\{GetFurnituraKod(Com.ЛицевойЛист)}\{GetMetalKod(Data.Thick_LL)}\{Data.Height}\{Data.Height}x{Data.Width}_[DM1MDF1]_V.DXF";

            var zpoPath = $@"\{Name}\ПРОФИЛИ\Вертикальные\{GetFurnituraKod(Com.Профили)}\{Data.Height}_[DM1MDF1]_ZO_PO.DXF";
            var udoPath = $@"\{Name}\ПРОФИЛИ\Горизонтальные\{Data.Width}_[DM1MDF1]_UDO.DXF";
            var tpPath = $@"\{Name}\ПРОФИЛИ\Горизонтальные\{Data.Width}_[DM1MDF1]_Z_TORZ.DXF";

            var zsPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Вертикальные\Замковые\{GetFurnituraKod(Com.Профили)}\{Data.Height}_[DM1MDF1]_{GetNalichikKod(GetNalichnik())}_ZS.DXF";
            var psPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Вертикальные\Петлевые\{Data.Height}_[DM1MDF1]_{GetNalichikKod(GetNalichnik(false))}_PS.DXF";
            var usPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Горизонтальные\{Data.Width}_[DM1MDF1]_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_UPS.DXF";
            var dsPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Горизонтальные\{Data.Width}_[DM1MDF1]_POR.DXF";

            pathes = new Dictionary<string, string>
            {
                {$"{TemplateFileName}_LL.DXF", llPath},
                {$"{TemplateFileName}_VL.DXF", vlPath},

                {$"{TemplateFileName}_ZPO.DXF", zpoPath},
                {$"{TemplateFileName}_UDO.DXF", udoPath},
                {$"{TemplateFileName}_TP.DXF", tpPath},

                {$"{TemplateFileName}_{GetNalichikKod(GetNalichnik())}_{GetPositionKod()}_ZS.DXF", zsPath},
                {$"{TemplateFileName}_{GetNalichikKod(GetNalichnik(false))}_{GetPositionKod(false)}_PS.DXF", psPath},
                {$"{TemplateFileName}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_US.DXF", usPath},
                {$"{TemplateFileName}_POR.DXF", dsPath}
            };
        }
    }
}
