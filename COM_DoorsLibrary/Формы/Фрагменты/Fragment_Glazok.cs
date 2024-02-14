using System;
using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы.Фрагменты
{
    public partial class Fragment_Glazok : UserControl
    {
        private bool nonNumberEntered = false;
        private GlazokParam _data;
        private readonly Constants cons = new Constants();

        public Fragment_Glazok(ref GlazokParam data, int num = -1)
        {
            InitializeComponent();
            cbRaspol.DataSource = Enum.GetNames(typeof(GlazokRaspolozhenie));

            if (num == 0)
                gbPars.Text = "Параметры глазка 1: ";
            else if (num == 1)
                gbPars.Text = "Параметры глазка 2: ";
            else
                gbPars.Text = "Параметры глазка: ";

            _data = data;
            Fill();
        }

        public GlazokParam Glazok
        {
            get => _data;
            set
            {
                _data = value;
                Fill();
            }
        }

        private void Fill()
        {
            cbRaspol.SelectedIndex = cbRaspol.Items.IndexOf(_data.Raspolozhenie.ToString());
            if (_data.OtPola > 0)
                tbRaspol.Text = _data.OtPola.ToString();
            else
                tbRaspol.Text = cons.GLAZOK_OT_POLA.ToString();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }

            if (ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered)
            {
                e.Handled = true;
            }
        }
        private void tbRaspol_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbRaspol.Text, out short rasp))
                _data.OtPola = rasp;
            else
                Fill();
        }
        private void cbRaspol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRaspol.SelectedIndex > -1)
                _data.Raspolozhenie = (GlazokRaspolozhenie)Enum.Parse(typeof(GlazokRaspolozhenie), cbRaspol.SelectedItem.ToString());
            else 
                Fill();
        }
    }
}
