using System;
using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы.Фрагменты
{
    public partial class Fragment_Ruchka : UserControl
    {
        private bool nonNumberEntered = false;
        private readonly Constants cons = new Constants();
        private RuchkaParam _data;

        public Fragment_Ruchka(short kod, RuchkaParam data)
        {
            InitializeComponent();
            if(cons.CompareKod(kod, "ДМ") | cons.CompareKod(kod, "MAX"))
                cbType.DataSource = Enum.GetNames(typeof(DM_RuchkaNames));
            else if(cons.CompareKod(kod, "ЛМ"))
                cbType.DataSource = Enum.GetNames(typeof(LM_RuchkaNames));
            else if(cons.CompareKod(kod, "ОДЛ"))
                cbType.DataSource = Enum.GetNames(typeof(ODL_RuchkaNames));
            else
                cbType.DataSource = Enum.GetNames(typeof(RuchkaNames));
            _data = data;
            Fill();
        }

        private void Fill()
        {
            cbType.SelectedIndex = cbType.Items.IndexOf(Enum.GetName(typeof(RuchkaNames), _data.Kod));
            if ((RuchkaNames)Enum.ToObject(typeof(RuchkaNames), _data.Kod) == RuchkaNames.Ручка_скоба)
            {
                EnableMezhosev(true);
                tbMezhosev.Text = _data.Mezhosevoe.ToString();
            }
            else
            {
                EnableMezhosev(false);
                tbMezhosev.Text = "";
            }

            if(_data.OtPola > 0 & _data.OtPola != cons.RUCHKA_OT_POLA)
            {
                EnableRaspol(true);
                tbRaspol.Text = _data.OtPola.ToString();
            }
            else
            {
                EnableRaspol(false);
                tbRaspol.Text = cons.RUCHKA_OT_POLA.ToString();
            }
        }
        private void EnableMezhosev(bool enable)
        {
            lMezhosev.Enabled = enable;
            tbMezhosev.Enabled = enable;
        }
        private void EnableRaspol(bool enable)
        {
            lRaspol.Enabled = enable;
            tbRaspol.Enabled = enable;
        }

        public RuchkaParam Ruchka
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
        private void tbRaspol_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbRaspol.Text, out short rasp))
                _data.OtPola = rasp;
            else
                Fill();
        }
        private void tbMezhosev_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbMezhosev.Text, out short mezh))
                _data.Mezhosevoe = mezh;
            else
                Fill();
        }
        private void chRaspol_CheckedChanged(object sender, EventArgs e)
        {
            EnableRaspol(chRaspol.Checked);
        }
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex > -1)
            {
                RuchkaNames rn = (RuchkaNames)Enum.Parse(typeof(RuchkaNames), cbType.SelectedItem.ToString());
                _data.Kod = (short)rn;
                if (!(rn == RuchkaNames.Ручка_скоба | rn == RuchkaNames.Ручка_кнопка | rn == RuchkaNames.Ручка_уголок |
                   rn == RuchkaNames.Ручка_РЯ_180 | rn == RuchkaNames.Ручка_Потайная))
                {
                    chRaspol.Enabled = false;
                    EnableRaspol(false);
                }
                else
                {
                    chRaspol.Enabled = true;
                    EnableRaspol(true);
                }
                Fill();
            }
            else Fill();
        }
    }
}
