using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы.Фрагменты
{
    public partial class Fragment_Kalitka : UserControl
    {
        private KalitkaParam kalitkaParam = new KalitkaParam() { Height = 0, Width = 0, Otkrivanie = Otkrivanie.Левое, OtPola = 100, OtZamka = 100, FromTable = "" };
        private bool nonNumberEntered = false;
        private readonly List<short> limH = new List<short>();
        private readonly List<short> limW = new List<short>();

        public Fragment_Kalitka(KalitkaParam data)
        {
            InitializeComponent();
            cbOtkrivanie.DataSource = Enum.GetNames(typeof(Otkrivanie));
            kalitkaParam = data;
            Constants cons = new Constants();
            limH = cons.LIM_KALIT_H;
            limW = cons.LIM_KALIT_W;
            Fill();
        }

        private void Fill()
        {
            tbHeight.Text = kalitkaParam.Height.ToString();
            tbWidth.Text = kalitkaParam.Width.ToString();
            cbOtkrivanie.SelectedIndex = cbOtkrivanie.Items.IndexOf(kalitkaParam.Otkrivanie.ToString());
            tbOtPola.Text = kalitkaParam.OtPola.ToString();
            tbOtZamka.Text = kalitkaParam.OtZamka.ToString();
        }
        
        public KalitkaParam Param
        {
            get { return kalitkaParam; }
            set
            {
                kalitkaParam = value;
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
        private short GetRazmer(string razmer, List<short> limRazmers, string title)
        {
            if (!string.IsNullOrEmpty(razmer))
            {
                if (short.TryParse(razmer, out short outR))
                {
                    if (FindRazmer(outR, limRazmers)) 
                        return outR;
                    else
                    {
                        DialogResult res = MessageBox.Show(title,
                                                           "Введенная '" + title + "' является не стандартной!" + '\n' + "Продолжить с этим значением?",
                                                           MessageBoxButtons.YesNo,
                                                           MessageBoxIcon.Question);
                        if (res == DialogResult.Yes) 
                            return outR;
                        else 
                            return 0;
                    }
                }
                else
                    return 0;
            }
            else
                return 0;
        }
        private bool FindRazmer(short razmer, List<short> limRazmers)
        {
            foreach (short r in limRazmers) if (razmer == r) return true;
            return false;
        }

        private void tbHeight_TextChanged(object sender, EventArgs e)
        {
            short getH = GetRazmer(tbHeight.Text, limH, "Высота калитки");
            if (getH > 0) kalitkaParam.Height = getH;
            else tbHeight.Text = kalitkaParam.Height.ToString();
        }
        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            short getW = GetRazmer(tbWidth.Text, limW, "Ширина калитки");
            if (getW > 0) kalitkaParam.Width = getW;
            else tbWidth.Text = kalitkaParam.Width.ToString();
        }
        private void tbOtPola_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbOtPola.Text))
            {
                if(short.TryParse(tbOtPola.Text, out short otPola))
                    kalitkaParam.OtPola = otPola;
                else
                    tbOtPola.Text = kalitkaParam.OtPola.ToString();
            }
            else 
                tbOtPola.Text = kalitkaParam.OtPola.ToString();
        }
        private void tbOtZamka_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbOtZamka.Text))
            {
                if(short.TryParse(tbOtZamka.Text, out short otZamka))
                    kalitkaParam.OtZamka = otZamka;
                else
                    tbOtZamka.Text = kalitkaParam.OtZamka.ToString();
            } 
            else 
                tbOtZamka.Text = kalitkaParam.OtZamka.ToString();
        }
        private void cbOtkrivanie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOtkrivanie.SelectedIndex > -1)
                kalitkaParam.Otkrivanie = (Otkrivanie)Enum.Parse(typeof(Otkrivanie), cbOtkrivanie.SelectedItem.ToString());
            else
                cbOtkrivanie.SelectedIndex = cbOtkrivanie.Items.IndexOf(kalitkaParam.Otkrivanie);
        }
    }
}
