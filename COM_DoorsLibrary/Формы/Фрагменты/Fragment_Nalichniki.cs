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
    public partial class Fragment_Nalichniki : UserControl
    {
        private short[] _nalichniki = { 0, 0, 0, 0 };
        bool nonNumberEntered = false;

        public Fragment_Nalichniki(short[] nalich)
        {
            InitializeComponent();
            _nalichniki = nalich;
            Fill();
        }

        private void Fill()
        {
            tbUp.Text = _nalichniki[(int)Raspolozhenie.Верх].ToString();
            tbDown.Text = _nalichniki[(int)Raspolozhenie.Ниж].ToString();
            tbLeft.Text = _nalichniki[(int)Raspolozhenie.Лев].ToString();
            tbRight.Text = _nalichniki[(int)Raspolozhenie.Прав].ToString();
        }

        public short[] Nalichniki
        {
            get => _nalichniki;
            set
            {
                _nalichniki = value;
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
        private void tbUp_TextChanged(object sender, EventArgs e)
        {
            if(short.TryParse(tbUp.Text, out short up))
            {
                if (up > 100) tbUp.Text = _nalichniki[(int)Raspolozhenie.Верх].ToString();
                else _nalichniki[(int)Raspolozhenie.Верх] = up;
            }
        }
        private void tbDown_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbDown.Text, out short down))
            {
                if (down > 100) tbDown.Text = _nalichniki[(int)Raspolozhenie.Ниж].ToString();
                else _nalichniki[(int)Raspolozhenie.Ниж] = down;
            }
        }
        private void tbLeft_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbLeft.Text, out short left))
            {
                if (left > 100) tbLeft.Text = _nalichniki[(int)Raspolozhenie.Лев].ToString();
                else _nalichniki[(int)Raspolozhenie.Лев] = left;
            }
        }
        private void tbRight_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbRight.Text, out short right))
            {
                if (right > 100) tbRight.Text = _nalichniki[(int)Raspolozhenie.Прав].ToString();
                else _nalichniki[(int)Raspolozhenie.Прав] = right;
            }
        }
    }
}
