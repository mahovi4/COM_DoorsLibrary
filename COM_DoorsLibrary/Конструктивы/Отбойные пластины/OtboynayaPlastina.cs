
namespace COM_DoorsLibrary
{
    public class OtboynayaPlastina
    {
        public const int coefZavisimosti = 15;
        public const int otstup = 25;
        public const int minStep = 150;
        public const int maxStep = 200;

        public int Width
        {
            get => width;
            set
            {
                width = value;
                Calculate();
            }
        }

        public int Height { get; }

        public Stvorka Stvorka { get; }
        public PositionPlastina Position { get; }

        public int Otstup { get; }

        public int XCount { get; private set; }
        public int YCount { get; private set; }

        public double XStep { get; private set; }
        public double YStep { get; private set; }

        public string Name { get; }

        private int width;

        public OtboynayaPlastina(int height, Stvorka stvorka, PositionPlastina position, int otstup)
        {
            Height = height;
            Stvorka = stvorka;
            Position = position;
            Otstup = otstup;
            Name =
                $"{(position == PositionPlastina.Лицевая ? "Внеш" : "Внут")}_{(stvorka == Stvorka.Активная ? "Акт" : "Пас")}";
        }

        private void Calculate()
        {
            if (width > maxStep + otstup * 2)
            {
                var tmp = ((double) width - otstup * 2) / minStep;
                var step = tmp.Round();
                XStep = ((double)width - otstup*2) / step;
                XCount = step + 1;
            }
            else
            {
                XCount = 2;
                XStep = width - otstup * 2;
            }

            if (Height > maxStep + otstup * 2)
            {
                var tmp = ((double)Height - otstup * 2) / minStep;
                var step = tmp.Round();
                YStep = ((double)Height - otstup*2) / step;
                YCount = step + 1;
            }
            else
            {
                YCount = 2;
                YStep = Height - otstup * 2;
            }
        }
    }
}
