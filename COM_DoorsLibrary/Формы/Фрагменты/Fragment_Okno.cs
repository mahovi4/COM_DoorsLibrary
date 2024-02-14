using System;
using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы.Фрагменты
{
    public partial class Fragment_Okno : UserControl
    {
        private OknoParam oknoParam = new OknoParam() { Steklo = new StekloParam() { Thick = StekloThicks.Нет, Height = 0, Width = 0 },
                                                        GorRaspol = GorRaspolozhenie.по_центру,
                                                        PoGorizontali = 0,
                                                        VertRaspol = VertRaspolozhenie.от_пола,
                                                        PoVertikali = 0 };
        private bool nonNumberEntered = false;
        private readonly Fragment_Steklo frSteklo;

        public Fragment_Okno(ref OknoParam data)
        {
            InitializeComponent();
            cbGR.DataSource = Enum.GetNames(typeof(GorRaspolozhenie));
            cbVR.DataSource = Enum.GetNames(typeof(VertRaspolozhenie));
            oknoParam = data;
            frSteklo = new Fragment_Steklo(ref data.Steklo);
            Fill();
        }

        private void Fill()
        {
            cbGR.SelectedIndex = cbGR.Items.IndexOf(oknoParam.GorRaspol.ToString());
            cbVR.SelectedIndex = cbVR.Items.IndexOf(oknoParam.VertRaspol.ToString());
            tbGR.Text = oknoParam.PoGorizontali.ToString();
            tbVR.Text = oknoParam.PoVertikali.ToString();
            SetVisible();
        }
        private void SetVisible()
        {
            if (oknoParam.GorRaspol == GorRaspolozhenie.по_центру)
                tbGR.Enabled = false;
            else
                tbGR.Enabled = true;
        }

        public OknoParam Param
        {
            get
            {
                oknoParam.Steklo = (StekloParam)frSteklo.Param;
                return oknoParam;
            }
            set
            {
                oknoParam = value;
                Fill();
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            frSteklo.Left = 0;
            frSteklo.Top = 0;
            scOkno.Panel1.Controls.Clear();
            scOkno.Panel1.Controls.Add(frSteklo);
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
        private void cbGR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGR.SelectedIndex > -1)
            {
                oknoParam.GorRaspol = (GorRaspolozhenie)Enum.Parse(typeof(GorRaspolozhenie), cbGR.SelectedItem.ToString());
                SetVisible();
            }
            else Fill();
        }
        private void tbGR_TextChanged(object sender, EventArgs e)
        {
            if(short.TryParse(tbGR.Text, out short gr))
                oknoParam.PoGorizontali = gr;
            else 
                tbGR.Text = oknoParam.PoGorizontali.ToString();
        }
        private void cbVR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVR.SelectedIndex > -1)
                oknoParam.VertRaspol = (VertRaspolozhenie)Enum.Parse(typeof(VertRaspolozhenie), cbVR.SelectedItem.ToString());
            else
                Fill();
        }
        private void tbVR_TextChanged(object sender, EventArgs e)
        {
            if(short.TryParse(tbVR.Text, out short vr))
                oknoParam.PoVertikali = vr;
            else 
                tbVR.Text = oknoParam.PoVertikali.ToString();
        }
    }
}
