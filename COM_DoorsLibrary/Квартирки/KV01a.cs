using System.Collections.Generic;

namespace COM_DoorsLibrary
{
    public sealed class KV01a : KVD
    {
        public override string Name => "КВ01a";
        public override string Description => "Комфорт-S";
        public override string MaketDir => @"k:\Заготовки, шаблоны\Квартирные двери\[KOMPF_S]";
        public override double LL_Height => Data.Height - 24;
        public override double LL_Width => Data.Width - 34;
        public override double VL_Height => 0;
        public override double VL_Width => 0;
        public override double VP_Length => Data.Height - 78.5;
        public override double GP_Length => Data.Width - 55.6;
        public override double MP_Length => Data.Width - 90.2;
        public override double VS_Length => Data.Height;
        public override double GS_Length => Data.Width - 103;
        public override double RZK_Length => Data.Height - 20;

        public override double Nalichnik(Raspolozhenie pos)
        {
            switch (Data.Nalichniki[(short) pos])
            {
                case 60:
                case 70:
                    if(pos == Raspolozhenie.Лев || pos == Raspolozhenie.Прав)
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

        public KV01a(TableData data, Constants cons)
            : base(data, cons)
        {
            var template = TemplateFileName.Substring(0, TemplateFileName.Length - 1);

            Parts.Add(new KVDPartInfo(Command_KVD.Лицевой_лист, "[KOMPH]_L.SLDPRT", $"{template}{GetOtkrivanieKod()}_LL"));
            Parts.Add(new KVDPartInfo(Command_KVD.Замковой_профиль, "[KOMPH]_Z_P_PROF.SLDPRT", $"{template}_ZP"));
            Parts.Add(new KVDPartInfo(Command_KVD.Петлевой_профиль, "[KOMPH]_Z_P_PROF.SLDPRT", $"{template}_PP"));
            Parts.Add(new KVDPartInfo(Command_KVD.Верхний_профиль, "[KOMPH]_U_PROF.SLDPRT", $"{template}_UP"));
            Parts.Add(new KVDPartInfo(Command_KVD.Нижний_профиль, "[KOMPH]_D_PROF.SLDPRT", $"{template}_DP"));
            Parts.Add(new KVDPartInfo(Command_KVD.Монтажный_профиль_нижний, "[KOMPH]_M_PROF.SLDPRT", $"{template}_TP"));
            Parts.Add(new KVDPartInfo(Command_KVD.Замковая_стойка, "[KOMPH]_K1_Z_P.SLDPRT", $"{template}_{GetNalichikKod(GetNalichnik())}{GetOtkrivanieKod()}_{GetPositionKod()}_ZS"));
            Parts.Add(new KVDPartInfo(Command_KVD.Петлевая_стойка, "[KOMPH]_K1_Z_P.SLDPRT", $"{template}_{GetNalichikKod(GetNalichnik(false))}{GetOtkrivanieKod()}_{GetPositionKod(false)}_PS"));
            Parts.Add(new KVDPartInfo(Command_KVD.Притолока, "[KOMPH]_G.SLDPRT", $"{template}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}{GetOtkrivanieKod()}_US"));
            Parts.Add(new KVDPartInfo(Command_KVD.Порог, "[KOMPH]_POR.SLDPRT", $"{template}_{GetOtkrivanieKod()}{GetPorogKod()}"));
            Parts.Add(new KVDPartInfo(Command_KVD.РЖК_Замковая, "[KOMPH]_RGK.SLDPRT", $"{template}_ZR"));
            Parts.Add(new KVDPartInfo(Command_KVD.РЖК_Петлевая, "[KOMPH]_RGK.SLDPRT", $"{template}_PR"));

            //var llPath = $@"\{Name}\ЛИЦЕВОЙ ЛИСТ\{GetFurnituraKod(Com.ЛицевойЛист)}\{GetMetalKod(data.Thick_LL)}\{Data.Height}\{Data.Height}x{Data.Width}_[KOMPH]_L.DXF";

            //var zpPath = $@"\{Name}\ПРОФИЛИ\Вертикальные\Замковые\{GetFurnituraKod(Com.Профили)}\{Data.Height}_[KOMPH]_Z_PROF_Z.DXF";
            //var ppPath = $@"\{Name}\ПРОФИЛИ\Вертикальные\Петлевые\{Data.Height}_[KOMPH]_Z_PROF_P.DXF";
            //var upPath = $@"\{Name}\ПРОФИЛИ\Горизонтальные\{Data.Width}_[KOMPH]_Z_PROF_U.DXF";
            //var dpPath = $@"\{Name}\ПРОФИЛИ\Горизонтальные\{Data.Width}_[KOMPH]_Z_PROF_D.DXF";
            //var tpPath = $@"\{Name}\ПРОФИЛИ\Горизонтальные\{Data.Width}_[KOMPH]_Z_PROF_Z.DXF";

            //var zsPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Вертикальные\Замковые\{GetFurnituraKod(Com.Профили)}\{Data.Height}_[KOMPH]_{GetNalichikKod(GetNalichnik())}_Z.DXF";
            //var psPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Вертикальные\Петлевые\{Data.Height}_[KOMPH]_{GetNalichikKod(GetNalichnik(false))}_P.DXF";
            //var usPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Горизонтальные\{Data.Width}_[KOMPH]_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}_G.DXF";
            //var dsPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\Горизонтальные\{Data.Width}_[KOMPH]_{GetPorogKod()}.DXF";

            //var zrgPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\РЖК\{Data.Height}_[KOMPH]_RGK_Z.DXF";
            //var prgPath = $@"\{Name}\ЭЛЕМЕНТЫ КОРОБКИ\РЖК\{Data.Height}_[KOMPH]_RGK_P.DXF";

            //pathes = new Dictionary<string, string>
            //{
            //    {$"{template}{GetOtkrivanieKod()}_LL.DXF", llPath},

            //    {$"{template}_ZP.DXF", zpPath},
            //    {$"{template}_PP.DXF", ppPath},
            //    {$"{template}_UP.DXF", upPath},
            //    {$"{template}_DP.DXF", dpPath},
            //    {$"{template}_TP.DXF", tpPath},

            //    {$"{template}_{GetNalichikKod(GetNalichnik())}{GetOtkrivanieKod()}_{GetPositionKod()}_ZS.DXF", zsPath},
            //    {$"{template}_{GetNalichikKod(GetNalichnik(false))}{GetOtkrivanieKod()}_{GetPositionKod(false)}_PS.DXF", psPath},
            //    {$"{template}_{GetNalichikKod(Data.Nalichniki[(int)Raspolozhenie.Верх])}{GetOtkrivanieKod()}_US.DXF", usPath},
            //    {$"{template}_{GetOtkrivanieKod()}{GetPorogKod()}.DXF", dsPath},

            //    {$"{template}_PR.DXF", prgPath},
            //    {$"{template}_ZR.DXF", zrgPath}
            //};
        }
    }
}
