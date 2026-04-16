namespace COM_DoorsLibrary
{
    public class OtsechkaOkna
    {
        public double Width { get; }

        public double ProsechkaWidth { get; }

        public double ProrezLegthGor { get; }
        public double ProrezLegthVert { get; }

        public int ProrezCountGor { get; }
        public int ProrezCountVert { get; }

        public double ProrezStepGor { get; }
        public double ProrezStepVert { get; }

        public bool IsValid { get; }

        public OtsechkaOkna(double virezWidth, double virezHeight, double otsechkaWidth, double prosechkaWidth)
        {
            Width = otsechkaWidth;

            IsValid = virezWidth >= Width * 2 && virezHeight >= Width * 2;

            ProrezCountGor = (int)(!IsValid ? 0 : (virezWidth - ProsechkaWidth * 2) / (50 + ProsechkaWidth));
            ProrezCountVert = (int)(!IsValid ? 0 : (virezHeight - ProsechkaWidth * 2 - Width * 2) / (50 + ProsechkaWidth));

            var stepLengthGor = virezWidth - ProsechkaWidth / ProrezCountGor;
            var stepLengthVert = virezHeight - ProsechkaWidth - Width * 2 / ProrezCountVert;

            ProrezLegthGor = stepLengthGor - 3;
            ProrezLegthVert = stepLengthVert - 3;

            ProrezStepGor = stepLengthGor;
            ProrezStepVert = stepLengthVert;
        }
    }
}
