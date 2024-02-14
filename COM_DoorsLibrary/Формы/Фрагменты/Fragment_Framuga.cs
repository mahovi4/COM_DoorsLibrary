using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы.Фрагменты
{
    public partial class Fragment_Framuga : UserControl
    {
        private FramugaParam framugaParam;
        private Framuga framuga = new Framuga();
        private bool nonNumberEntered = false;
        private readonly List<Fragment_Steklo> fragmentsSt;
        private Fragment_Reshetka fragmentResh;
        private readonly int limSteklo = 4;

        public event ChangeHeightHandler ChangeHeight;

        public Fragment_Framuga(ref TableData data, Raspolozhenie pos)
        {
            InitializeComponent();
            cbType.DataSource = Enum.GetNames(typeof(FramugaType));
            framuga.Init(ref data, pos);
            framugaParam = framuga.Param;
            fragmentsSt = new List<Fragment_Steklo>();
            fragmentResh = new Fragment_Reshetka(0, ref framugaParam.Reshetka);
            Fill();
        }

        private void Fill()
        {
            cbType.SelectedIndex = cbType.Items.IndexOf(framugaParam.Type.ToString());
            tbHeight.Text = framugaParam.Height.ToString();
            tbWidth.Text = framugaParam.Width.ToString();
            lOsteklenie.Text = framugaParam.Type == FramugaType.с_жалюзийной_решеткой ? "Решетка: " : "Остекление: ";

            if(framugaParam.Type == FramugaType.нет | framugaParam.Type == FramugaType.глухая) 
                FillPanel(FillCommand.нет);
            else if(framugaParam.Type == FramugaType.полного_остекления)
            {
                if (framugaParam.Steklo == null) 
                    framugaParam.Steklo = new StekloParam[1] { new StekloParam() { Thick = StekloThicks.Нет, Height = 0, Width = 0 } };
                else if(framugaParam.Steklo.Length == 0 | framugaParam.Steklo.Length > 1)
                    framugaParam.Steklo = new StekloParam[1] { new StekloParam() { Thick = StekloThicks.Нет, Height = 0, Width = 0 } };
                FillPanel(FillCommand.Стекла);
            }
            else if(framugaParam.Type == FramugaType.частичного_остекления)
            {
                if(framugaParam.Steklo == null)
                    framugaParam.Steklo = new StekloParam[1] { new StekloParam() { Thick = StekloThicks.Нет, Height = 0, Width = 0 } };
                else if (framugaParam.Steklo.Length == 0)
                    framugaParam.Steklo = new StekloParam[1] { new StekloParam() { Thick = StekloThicks.Нет, Height = 0, Width = 0 } };
                FillPanel(FillCommand.Стекла);
            }
            else if(framugaParam.Type == FramugaType.с_жалюзийной_решеткой)
            {
                FillPanel(FillCommand.Решетка);
            }
            EnableBloks();
        }
        private void FillPanel(FillCommand command)
        {
            int oldH = scFramuga.Panel2.Height;
            scFramuga.Panel2.Controls.Clear();
            if (command == FillCommand.Стекла)
            {
                fragmentsSt.Clear();
                if (framugaParam.Steklo.Length > 1)
                {
                    for (short i = 0; i < framugaParam.Steklo.Length; i++)
                    {
                        fragmentsSt.Add(new Fragment_Steklo(ref framugaParam.Steklo[i], i) {
                            Left = 0,
                            Top = Size.Height * i
                        });
                        scFramuga.Panel2.Controls.Add(fragmentsSt[i]);
                    }
                }
                else
                {
                    fragmentsSt.Add(new Fragment_Steklo(ref framugaParam.Steklo[0]){
                        Left = 0,
                        Top = 0
                    });
                    scFramuga.Panel2.Controls.Add(fragmentsSt[0]);
                }
            }
            else if(command == FillCommand.Решетка)
            {
                fragmentResh = new Fragment_Reshetka(0, ref framugaParam.Reshetka)
                {
                    Left = 0,
                    Top = 0
                };
                scFramuga.Panel2.Controls.Add(fragmentResh);
            }
            OnChangeHeight(scFramuga.Panel2.Height - oldH);
        }
        private void EnableBloks()
        {
            if (framugaParam.Type == FramugaType.нет)
            {
                lHeight.Enabled = false;
                tbHeight.Enabled = false;
                lWidth.Enabled = false;
                tbWidth.Enabled = false;
                lOsteklenie.Enabled = false;
                btnPlus.Enabled = false;
                btnMinus.Enabled = false;
            }
            else if (framugaParam.Type == FramugaType.глухая)
            {
                lHeight.Enabled = true;
                tbHeight.Enabled = true;
                lWidth.Enabled = true;
                tbWidth.Enabled = true;
                lOsteklenie.Enabled = false;
                btnPlus.Enabled = false;
                btnMinus.Enabled = false;
            }
            else if (framugaParam.Type == FramugaType.полного_остекления | framugaParam.Type == FramugaType.с_жалюзийной_решеткой)
            {
                lHeight.Enabled = true;
                tbHeight.Enabled = true;
                lWidth.Enabled = true;
                tbWidth.Enabled = true;
                lOsteklenie.Enabled = true;
                btnPlus.Enabled = false;
                btnMinus.Enabled = false;
                foreach (Fragment_Steklo fr in fragmentsSt) fr.Enable(EnabeCommand.only_Type);
                fragmentResh.Enable(EnaleCommandResh.onli_param);
            }
            else if (framugaParam.Type == FramugaType.частичного_остекления)
            {
                lHeight.Enabled = true;
                tbHeight.Enabled = true;
                lWidth.Enabled = true;
                tbWidth.Enabled = true;
                lOsteklenie.Enabled = true;
                btnPlus.Enabled = false;
                btnMinus.Enabled = false;
                foreach (Fragment_Steklo fr in fragmentsSt) fr.Enable(EnabeCommand.all);
            }
        }

        public FramugaParam Param
        {
            get
            {
                if(framugaParam.Type == FramugaType.нет | framugaParam.Type == FramugaType.глухая)
                {
                    framugaParam.Steklo = new StekloParam[] { };
                    framugaParam.Reshetka = new ReshParam() { Type = eReshetka.нет, Height = 0, Width = 0, OtPola = 0 };
                }
                else if(framugaParam.Type == FramugaType.полного_остекления)
                {
                    framugaParam.Steklo = new StekloParam[1];
                    framugaParam.Steklo[0] = fragmentsSt[0].Param;
                    framugaParam.Reshetka = new ReshParam() { Type = eReshetka.нет, Height = 0, Width = 0, OtPola = 0 };
                }
                else if(framugaParam.Type == FramugaType.частичного_остекления)
                {
                    framugaParam.Steklo = new StekloParam[fragmentsSt.Count];
                    for (int i = 0; i < fragmentsSt.Count; i++) framugaParam.Steklo[i] = fragmentsSt[i].Param;
                    framugaParam.Reshetka = new ReshParam() { Type = eReshetka.нет, Height = 0, Width = 0, OtPola = 0 };
                }
                else
                {
                    framugaParam.Steklo = new StekloParam[] { };
                    framugaParam.Reshetka = fragmentResh.Param;
                }
                return framugaParam;
            }
            set
            {
                framugaParam = value;
                Fill();
            }
        }

        protected virtual void OnChangeHeight(int deltaHeight)
        {
            ChangeHeight?.Invoke(this, deltaHeight);
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                        nonNumberEntered = true;
                }
            }

            if (ModifierKeys == Keys.Shift)
                nonNumberEntered = true;
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered)
                e.Handled = true;
        }
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex > -1)
                framugaParam.Type = (FramugaType)Enum.Parse(typeof(FramugaType), cbType.SelectedItem.ToString());
            Fill();
            EnableBloks();
        }
        private void tbHeight_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbHeight.Text))
            {
                if (short.TryParse(tbHeight.Text, out short h))
                {
                    framugaParam.Height = h;
                    if (h > 0 & framugaParam.Type == FramugaType.полного_остекления)
                    {
                        StekloParam steklo = framuga.CalculateSteklo(framugaParam);
                        fragmentsSt[0].Param = steklo;
                    }
                }
                else
                    tbHeight.Text = framugaParam.Height.ToString();
            }
            else 
                tbHeight.Text = framugaParam.Height.ToString();
        }
        private void tbWidth_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbWidth.Text))
            {
                if (short.TryParse(tbWidth.Text, out short w))
                {
                    framugaParam.Width = w;
                    if (w > 0 & framugaParam.Type == FramugaType.полного_остекления)
                    {
                        StekloParam steklo = framuga.CalculateSteklo(framugaParam);
                        fragmentsSt[0].Param = steklo;
                    }
                }
                else
                    tbWidth.Text = framugaParam.Width.ToString();
            }
            else tbWidth.Text = framugaParam.Width.ToString();
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (fragmentsSt.Count < limSteklo)
            {
                Array.Resize(ref framugaParam.Steklo, framugaParam.Steklo.Length + 1);
                int lastIndex = framugaParam.Steklo.Length - 1;
                framugaParam.Steklo[lastIndex] = new StekloParam() { Thick = framugaParam.Steklo[lastIndex - 1].Thick, 
                                                                     Height = framugaParam.Steklo[lastIndex - 1].Height, 
                                                                     Width = framugaParam.Steklo[lastIndex - 1].Width };
                Fill();
            }
            btnPlus.Enabled = fragmentsSt.Count < limSteklo;
            btnMinus.Enabled = fragmentsSt.Count > 1;
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (fragmentsSt.Count > 0)
                Array.Resize(ref framugaParam.Steklo, framugaParam.Steklo.Length - 1);
            btnMinus.Enabled = fragmentsSt.Count > 0;
            btnPlus.Enabled = fragmentsSt.Count < 4;
        }
    }

    enum FillCommand
    {
        нет,
        Стекла,
        Решетка
    }
}
