using System;
using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы.Фрагменты
{
    public partial class Fragment_Reshetka : UserControl
    {
        private ReshParam reshParam = new ReshParam() { Type = eReshetka.нет, Height = 0, Width = 0, OtPola = 0 };
        private bool nonNumberEntered = false;
        private const string OT_POLA = "Расположение решетки от пола:";
        private const string OT_VERHA = "Расположение решетки от верха:";

        public Fragment_Reshetka(int num, ref ReshParam data, EnaleCommandResh com = EnaleCommandResh.all)
        {
            InitializeComponent();
            cbType.DataSource = Enum.GetNames(typeof(eReshetka));
            reshParam = data;
            if (num == 0 | num == 2)
                lOtPola.Text = OT_POLA;
            else
                lOtPola.Text = OT_VERHA;
            Enable(com);
            Fill();
        }

        private void Fill()
        {
            cbType.SelectedIndex = cbType.Items.IndexOf(reshParam.Type.ToString());
            tbHeight.Text = reshParam.Height.ToString();
            tbWidth.Text = reshParam.Width.ToString();
            tbOtPola.Text = reshParam.OtPola.ToString();
        }
        public void Enable(EnaleCommandResh command)
        {
            if (command == EnaleCommandResh.not)
            {
                lType.Enabled = false;
                cbType.Enabled = false;
                lHeight.Enabled = false;
                tbHeight.Enabled = false;
                lWidth.Enabled = false;
                tbWidth.Enabled = false;
                lOtPola.Enabled = false;
                tbOtPola.Enabled = false;
            }
            else if(command == EnaleCommandResh.onli_param)
            {
                lType.Enabled = true;
                cbType.Enabled = true;
                lHeight.Enabled = true;
                tbHeight.Enabled = true;
                lWidth.Enabled = true;
                tbWidth.Enabled = true;
                lOtPola.Enabled = false;
                tbOtPola.Enabled = false;
            }
            else
            {
                lType.Enabled = true;
                cbType.Enabled = true;
                lHeight.Enabled = true;
                tbHeight.Enabled = true;
                lWidth.Enabled = true;
                tbWidth.Enabled = true;
                lOtPola.Enabled = true;
                tbOtPola.Enabled = true;
            }
        }

        public ReshParam Param
        {
            get { return reshParam; }
            set
            {
                reshParam = value;
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
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex > -1)
                reshParam.Type = (eReshetka)Enum.Parse(typeof(eReshetka), cbType.SelectedItem.ToString());
            else
                Fill();
        }
        private void tbHeight_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbHeight.Text, out short h)) 
                reshParam.Height = h;
            else 
                tbHeight.Text = reshParam.Height.ToString();
        }
        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbWidth.Text, out short w)) 
                reshParam.Width = w;
            else 
                tbWidth.Text = reshParam.Width.ToString();
        }
        private void tbOtPola_TextChanged(object sender, EventArgs e)
        {
            if (short.TryParse(tbOtPola.Text, out short op)) 
                reshParam.OtPola = op;
            else 
                tbOtPola.Text = reshParam.OtPola.ToString();
        }
    }

    public enum EnaleCommandResh
    {
        not,
        onli_param,
        all
    }
}
