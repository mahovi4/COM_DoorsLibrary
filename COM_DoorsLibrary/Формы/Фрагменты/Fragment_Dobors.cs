using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы.Фрагменты
{
    public partial class Fragment_Dobors : UserControl
    {
        private bool enable = false;
        private short glubina = 0;
        private short[] nalichniki = { 60, 0, 60, 60 };
        private string fromTable = "_";
        bool nonNumberEntered = false;

        public Fragment_Dobors(bool en, DoborParam param)
        {
            InitializeComponent();
            enable = en;
            glubina = param.Glubina;
            nalichniki = param.Nalicnik;
            fromTable = param.FromTable;
            Fill();
        }

        private void Fill()
        {
            chEnableDobor.Checked = enable;
            tbGlubina.Text = glubina.ToString();
            tbNalLeft.Text = nalichniki[(int)Raspolozhenie.Лев].ToString();
            tbNalRight.Text = nalichniki[(int)Raspolozhenie.Прав].ToString();
            tbNalUp.Text = nalichniki[(int)Raspolozhenie.Верх].ToString();
            tbNalDown.Text = nalichniki[(int)Raspolozhenie.Ниж].ToString();
            EnableBlocks(enable);
        }
        private void EnableBlocks(bool en)
        {
            lGlubina.Enabled = en;
            tbGlubina.Enabled = en;
            lNalLeft.Enabled = en;
            tbNalLeft.Enabled = en;
            lNalRight.Enabled = en;
            tbNalRight.Enabled = en;
            lNalUp.Enabled = en;
            tbNalUp.Enabled = en;
            lNalDown.Enabled = en;
            tbNalDown.Enabled = en;
            gbNalichniki.Enabled = en;
        }

        public short[] Nalichniki
        {
            get => nalichniki;
            set
            {
                nalichniki = value;
                Fill();
            }
        }
        public short Glubina
        {
            get => glubina;
            set
            {
                glubina = value;
                Fill();
            }
        }
        public bool EnableDobor
        {
            get => enable;
            set
            {
                enable = value;
                Fill();
            }
        }
        public DoborParam Param
        {
            get
            {
                return new DoborParam { Glubina = glubina, Nalicnik = nalichniki, FromTable = fromTable };
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

        private void chEnableDobor_CheckedChanged(object sender, EventArgs e)
        {
            EnableDobor = chEnableDobor.Checked;
        }
        private void tbGlubina_TextChanged(object sender, EventArgs e)
        {
            Glubina = short.Parse(tbGlubina.Text);
        }
        private void tbNalUp_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbNalUp.Text, out short up))
            {
                if (up > 100) tbNalUp.Text = nalichniki[(int)Raspolozhenie.Верх].ToString();
                else nalichniki[(int)Raspolozhenie.Верх] = up;
            }
            else
                tbNalUp.Text = nalichniki[(int)Raspolozhenie.Верх].ToString();
        }
        private void tbNalDown_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbNalDown.Text, out short down))
            {
                if (down > 100) tbNalDown.Text = nalichniki[(int)Raspolozhenie.Ниж].ToString();
                else nalichniki[(int)Raspolozhenie.Ниж] = down;
            }
            else
                tbNalDown.Text = nalichniki[(int)Raspolozhenie.Ниж].ToString();
        }
        private void tbNalLeft_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbNalLeft.Text, out short left))
            {
                if (left > 100) tbNalLeft.Text = nalichniki[(int)Raspolozhenie.Лев].ToString();
                else nalichniki[(int)Raspolozhenie.Лев] = left;
            }
            else
                tbNalLeft.Text = nalichniki[(int)Raspolozhenie.Лев].ToString();
        }
        private void tbNalRight_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbNalRight.Text, out short right))
            {
                if (right > 100) tbNalRight.Text = nalichniki[(int)Raspolozhenie.Прав].ToString();
                else nalichniki[(int)Raspolozhenie.Прав] = right;
            }
            else
                tbNalRight.Text = nalichniki[(int)Raspolozhenie.Прав].ToString();
        }
    }
}
