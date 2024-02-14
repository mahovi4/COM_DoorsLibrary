using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы.Фрагменты
{
    public abstract partial class Fragment : UserControl
    {
        public Fragment()
        {
            InitializeComponent();
        }

        public abstract object Param { get; set; }
    }
}
