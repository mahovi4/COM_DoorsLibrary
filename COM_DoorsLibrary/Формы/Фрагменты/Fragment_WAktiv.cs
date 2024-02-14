using System;
using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы.Фрагменты
{
    public partial class Fragment_WAktiv : UserControl
    {
        private bool nonNumberEntered = false;
        private WAktivParam _data;

        public Fragment_WAktiv(WAktivParam data)
        {
            InitializeComponent();
            _data = data;
            Fill();
        }

        private void Enable(bool enable)
        {
            lWAktiv.Enabled = enable;
            tbWAktiv.Enabled = enable;
        }
        private void Fill()
        {
            if (_data.Value == 1)
            {
                chRavnopol.Checked = true;
                tbWAktiv.Text = "1";
            }
            else
            {
                chRavnopol.Checked = false;
                tbWAktiv.Text = _data.Value.ToString();
            }
        }

        public WAktivParam WAktiv
        {
            get => _data;
            set
            {
                _data = value;
                Fill();
            }
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

        private void tbWAktiv_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tbWAktiv.Text, out double wakt))
                _data.Value = wakt;
            else
                tbWAktiv.Text = _data.Value.ToString();
        }
        private void chRavnopol_CheckedChanged(object sender, EventArgs e)
        {
            Enable(!chRavnopol.Checked);
            if (chRavnopol.Checked)
            {
                tbWAktiv.Text = "1";
                _data.Value = 1;
            }
        }
    }
}
