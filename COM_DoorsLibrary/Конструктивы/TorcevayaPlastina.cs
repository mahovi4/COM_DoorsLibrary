using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM_DoorsLibrary
{
    public class TorcevayaPlastina
    {
        public const double DesiredGroove = 50;
        public const double Punching = 3;

        public double Width { get; }

        public double Length { get; }

        public double OtstupPetlya { get; }

        public double OtstupZamok { get; }

        public double OtstupZamok2 { get; }

        public double Zaglushka_Width { get; }

        public double Zaglushka_Length { get; }

        public double Groove { get; }

        public int Count { get; }

        public double Step { get; }

        public double Gap { get; }

        public TorcevayaPlastina(double width, double length, double otstupPetlya, double otstupZamok = 0, bool tm = false, double otstupZamok2 = 0, double zaglushkaWidth = 0, double zaglushkaLength = 0)
        {
            Width = width;
            Length = length;
            OtstupPetlya = otstupPetlya;
            OtstupZamok = otstupZamok == 0 ? otstupPetlya : otstupZamok;
            OtstupZamok2 = otstupZamok2;
            Zaglushka_Width = zaglushkaWidth;
            Zaglushka_Length = zaglushkaLength;

            var des = tm ? DesiredGroove * 2 : DesiredGroove;
            Gap = tm ? 1 : 0.001;

            Count = (int)((Length - Punching) / (des + Punching));

            Groove = (Length - Punching) / Count - Punching;

            Step = Groove + Punching;
        }
    }
}
