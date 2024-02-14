using System;
using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы.Фрагменты
{
    public partial class Fragment_Steklo : UserControl
    {
        private StekloParam stekloParam = new StekloParam() { Thick = StekloThicks.Нет, Height = 0, Width = 0 };
        private bool nonNumberEntered = false;

        public Fragment_Steklo(ref StekloParam data, short index = -1, EnabeCommand com = EnabeCommand.all)
        {
            InitializeComponent();
            cbThick.DataSource = Enum.GetNames(typeof(StekloThicks));
            stekloParam = data;
            if (index > -1) Added((short)(index + 1));
            Enable(com);
            Fill();
        }

        private void Fill()
        {
            cbThick.SelectedIndex = cbThick.Items.IndexOf(stekloParam.Thick.ToString());
            tbHeight.Text = stekloParam.Height.ToString();
            tbWidth.Text = stekloParam.Width.ToString();
        }
        public void Added(short index)
        {
            string tmp = gbSteklo.Text;
            if (index > 0) gbSteklo.Text = "Стекло-" + index + ": ";
            else gbSteklo.Text = "Параметры остекления: ";
        }
        internal void Enable(EnabeCommand command)
        {
            if (command == EnabeCommand.not)
            {
                gbSteklo.Enabled = false;
                lThick.Enabled = false;
                cbThick.Enabled = false;
                lHeight.Enabled = false;
                tbHeight.Enabled = false;
                lWidth.Enabled = false;
                tbWidth.Enabled = false;
            }
            else if (command == EnabeCommand.only_Type)
            {
                gbSteklo.Enabled = true;
                lThick.Enabled = true;
                cbThick.Enabled = true;
                lHeight.Enabled = false;
                tbHeight.Enabled = false;
                lWidth.Enabled = false;
                tbWidth.Enabled = false;
            }
            else if (command == EnabeCommand.all)
            {
                gbSteklo.Enabled = true;
                lThick.Enabled = true;
                cbThick.Enabled = true;
                lHeight.Enabled = true;
                tbHeight.Enabled = true;
                lWidth.Enabled = true;
                tbWidth.Enabled = true;
            }
        }

        public StekloParam Param
        {
            get { return stekloParam; }
            set { 
                stekloParam = value;
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
        private void cbThick_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbThick.SelectedIndex > -1)
                stekloParam.Thick = (StekloThicks)Enum.Parse(typeof(StekloThicks), cbThick.SelectedItem.ToString());
            else
                Fill();
        }
        private void tbHeight_TextChanged(object sender, EventArgs e)
        {
            if(short.TryParse(tbHeight.Text, out short sh))
                stekloParam.Height = sh;
            else 
                tbHeight.Text = stekloParam.Height.ToString();
        }
        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            if(short.TryParse(tbWidth.Text, out short sw))
                stekloParam.Width = sw;
            else 
                tbWidth.Text = stekloParam.Width.ToString();
        }
    }

    public enum EnabeCommand
    {
        not,
        only_Type,
        all
    }
}
