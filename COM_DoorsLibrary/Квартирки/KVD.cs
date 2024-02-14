using System;
using System.Collections.Generic;

namespace COM_DoorsLibrary
{
    public abstract class KVD
    {
        public string Num { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }
        public string ModelName { get; }
        public string TemplateFileName => 
            $"{Data.Num}_{Name}";
        public abstract string MaketDir { get; }

        private protected Dictionary<string, string> pathes;

        public Dictionary<string, string> Pathes => pathes;

        public TableData Data { get; }
        private protected Constants Constants;

        protected KVD(TableData data, Constants cons)
        {
            Data = data;
            Constants = cons;
            
            Num = Data.Num;
            ModelName = Constants.GetKOD(data.Kod).Name;

            Parts = new List<KVDPartInfo>();

            if (Data.Zamok[0].Kod == 0)
                throw new ArgumentException(
                    $"{Data.Num} - {ModelName} без замка быть не может!");
        }

        private protected string GetNalichikKod(short nalichnik)
        {
            switch (nalichnik)
            {
                case 0:
                case 20:
                    return "N00";
                case 40:
                    return "N40";
                case 70:
                    return "N70";
                case 60:
                    switch (Name)
                    {
                        case "КВ05":
                            return "N60";
                        case "КВ01b":
                            return "N50";
                        default:
                            return "N70";
                    }
                case 50:
                    return "N50";
                case 80:
                    return "N80";
                default:
                    throw new ArgumentException($"{Data.Num} - наличник {nalichnik} является не стандартным!");
            }
        }

        private protected short GetNalichnik(bool zamkovaya = true)
        {
            if (Data.Otkrivanie == Otkrivanie.Левое || Data.Otkrivanie == Otkrivanie.ЛевоеВО)
                return zamkovaya 
                    ? Data.Nalichniki[(int) Raspolozhenie.Прав] 
                    : Data.Nalichniki[(int)Raspolozhenie.Лев];

            return zamkovaya
                ? Data.Nalichniki[(int)Raspolozhenie.Лев]
                : Data.Nalichniki[(int)Raspolozhenie.Прав];
        }

        private protected string GetPorogKod()
        {
            switch (Data.Porog)
            {
                case (short)PorogNames.Порог_40:
                    return "POR_40";
                case (short)PorogNames.Порог_20_мм:
                    return "POR_20";
                case (short)PorogNames.Порог_26_плоский:
                    return "POR_26";
                default:
                    throw new ArgumentException(
                        $"{Data.Num} - Порог {Data.Porog} для {ModelName} не определен");
            }
        }

        private protected string GetPositionKod(bool zamkovaya = true)
        {
            if (Data.Otkrivanie == Otkrivanie.Левое || Data.Otkrivanie == Otkrivanie.ЛевоеВО)
                return zamkovaya ? "R" : "L";

            return zamkovaya ? "L" : "R";
        }

        private protected string GetFurnituraKod(Com com)
        {
            var tmp = "";

            if (Data.Zamok[0].Kod == (short)ZamokNames.Гардиан_32_11)
                tmp += "G32.11";
            if (Data.Zamok[0].Kod == (short)ZamokNames.Гардиан_12_11)
                tmp += "G12.11";
            if (Data.Glazok.Length > 0 && (com == Com.ЛицевойЛист || com == Com.ВнутреннийЛист))
                tmp += "+GL";
            if (Data.Zamok[1].Kod == (short)ZamokNames.Гардиан_10_01)
                tmp += "+G10.01";
            if (Data.Zamok[1].Kod == (short)ZamokNames.Гардиан_30_01)
                tmp += "+G30.01";
            if (Data.Zamok[1].Kod == (short)ZamokNames.Гардиан_50_01)
                tmp += "+G50.01";
            if (Data.Zadvizhka.Kod > 0 && (com != Com.ЛицевойЛист || 
                                           (com == Com.ЛицевойЛист && 
                                            (Data.Otkrivanie == Otkrivanie.ЛевоеВО || 
                                             Data.Otkrivanie == Otkrivanie.ПравоеВО))))
                tmp += "+NS";
            if (Data.Bronya && (com == Com.ЛицевойЛист || com == Com.ВнутреннийЛист))
                tmp += "+DEF5512";

            return tmp;
        }

        public abstract double LL_Height { get; }
        public abstract double LL_Width { get; }

        public abstract double VL_Height { get; }
        public abstract double VL_Width { get; }

        public abstract double VP_Length { get; }
        public abstract double GP_Length { get; }
        public abstract double MP_Length { get; }

        public abstract double VS_Length { get; }
        public abstract double GS_Length { get; }

        public abstract double RZK_Length { get; }

        public abstract double Nalichnik(Raspolozhenie pos);

        public List<KVDPartInfo> Parts { get; }

        private protected string GetMetalKod(double thick)
        {
            return Math.Abs(thick - 2) < 0.0001 
                ? "2.0" 
                : "1.2-1.4";
        }

        private protected string GetOtkrivanieKod()
        {
            if (Data.Otkrivanie == Otkrivanie.ЛевоеВО || Data.Otkrivanie == Otkrivanie.ПравоеВО)
                return "_VO";
            return "";
        }

        private protected enum Com
        {
            ЛицевойЛист,
            ВнутреннийЛист,
            Профили
        }

        
    }

    public enum Command_KVD
    {
        Лицевой_лист,
        Внутренний_лист,
        Замковой_профиль,
        Петлевой_профиль,
        Верхний_профиль,
        Нижний_профиль,
        Монтажный_профиль_нижний,
        Монтажный_профиль_петлевой,
        Замковая_стойка,
        Петлевая_стойка,
        Притолока,
        Порог,
        РЖК_Замковая,
        РЖК_Петлевая
    }
}
