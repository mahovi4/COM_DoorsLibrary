using System;
using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы.Фрагменты
{
    public partial class Fragment_Zamok : UserControl
    {
        private bool nonNumberEntered = false;
        private readonly Constants cons = new Constants();
        private ZamokParam _data;
        private KodoviyParam _kdata;
        private readonly short _kod = 0;
        private readonly short _num = 0;

        public Fragment_Zamok(short kod, ZamokParam data, short num = 0, KodoviyParam kdata = default)
        {
            InitializeComponent();
            _data = data;
            _kdata = kdata;
            _kod = kod;
            _num = num;
            if (cons.CompareKod(kod, "ДМ") | cons.CompareKod(kod, "MAX"))
            {
                chbKodoviy.Enabled = true;
                if (num == 0)
                {
                    if (kdata.Type != Kodoviy.Нет)
                        cbZamok.DataSource = Enum.GetNames(typeof(Kodoviy));
                    else
                        cbZamok.DataSource = Enum.GetNames(typeof(DM_Zamok1Names));
                }
                else
                {
                    if (kdata.Type != Kodoviy.Нет)
                        cbZamok.DataSource = Enum.GetNames(typeof(Kodoviy));
                    else
                        cbZamok.DataSource = Enum.GetNames(typeof(DM_Zamok2Names));
                }
            }
            else if (cons.CompareKod(kod, "ЛМ"))
            {
                chbKodoviy.Enabled = false;
                cbZamok.DataSource = Enum.GetNames(typeof(LM_ZamokNames));
            }
            else if (cons.CompareKod(kod, "ОДЛ"))
            {
                chbKodoviy.Enabled = false;
                cbZamok.DataSource = Enum.GetNames(typeof(ODL_ZamokNames));
            }
            else if (cons.CompareKod(kod, "ВМ"))
            {
                chbKodoviy.Enabled = false;
                cbZamok.DataSource = Enum.GetNames(typeof(VM_ZamokNames));
            }
            else if (cons.CompareKod(kod, "РИО") || cons.CompareKod(kod, "КВ06") || cons.CompareKod(kod, "Жардин"))
            {
                chbKodoviy.Enabled = false;
                if(num == 0)
                    cbZamok.DataSource = Enum.GetNames(typeof(KV_Zamok1Names));
                else
                    cbZamok.DataSource = Enum.GetNames(typeof(KV_Zamok2Names));
            }
            else if (cons.CompareKod(kod, "Комфорт-S"))
            {
                chbKodoviy.Enabled = false;
                if (num == 0)
                    cbZamok.DataSource = Enum.GetNames(typeof(KT_Zamok1Names));
                else
                    cbZamok.DataSource = Enum.GetNames(typeof(KT_Zamok2Names));
            }
            else if (cons.CompareKod(kod, "ДМ1-МДФ1"))
            {
                chbKodoviy.Enabled = false;
                if (num == 0)
                    cbZamok.DataSource = Enum.GetNames(typeof(DF_Zamok1Names));
                else
                    cbZamok.DataSource = Enum.GetNames(typeof(DF_Zamok2Names));
            }

            Fill();
        }

        private void Fill()
        {
            if (cons.CompareKod(_kod, "ДМ") | cons.CompareKod(_kod, "MAX"))
            {
                if (_num == 0)
                {
                    if (_kdata.Type != Kodoviy.Нет)
                    {
                        chbKodoviy.Checked = true;
                        cbZamok.SelectedIndex = cbZamok.Items.IndexOf(_kdata.Type);
                    }
                    else
                    {
                        chbKodoviy.Checked = false;
                        cbZamok.SelectedIndex = cbZamok.Items.IndexOf(Enum.GetName(typeof(DM_Zamok1Names), _data.Kod));
                    }
                }
                else
                {
                    if (_kdata.Type != Kodoviy.Нет)
                    {
                        chbKodoviy.Checked = true;
                        cbZamok.SelectedIndex = cbZamok.Items.IndexOf(_kdata.Type);
                    }
                    else
                    {
                        chbKodoviy.Checked = false;
                        cbZamok.SelectedIndex = cbZamok.Items.IndexOf(Enum.GetName(typeof(DM_Zamok2Names), _data.Kod));
                    }
                }
            }
            else if (cons.CompareKod(_kod, "ЛМ"))
            {
                chbKodoviy.Checked = false;
                cbZamok.SelectedIndex = cbZamok.Items.IndexOf(Enum.GetName(typeof(LM_ZamokNames), _data.Kod));
            }
            else if (cons.CompareKod(_kod, "ОДЛ"))
            {
                chbKodoviy.Checked = false;
                cbZamok.SelectedIndex = cbZamok.Items.IndexOf(Enum.GetName(typeof(ODL_ZamokNames), _data.Kod));
            }
            else if (cons.CompareKod(_kod, "ВМ"))
            {
                chbKodoviy.Checked = false;
                cbZamok.SelectedIndex = cbZamok.Items.IndexOf(Enum.GetName(typeof(VM_ZamokNames), _data.Kod));
            }
            else if (cons.CompareKod(_kod, "РИО") || cons.CompareKod(_kod, "КВ06") || cons.CompareKod(_kod, "Жардин"))
            {
                chbKodoviy.Checked = false;
                if (_num == 0)
                    cbZamok.SelectedIndex = cbZamok.Items.IndexOf(Enum.GetName(typeof(KV_Zamok1Names), _data.Kod));
                else
                    cbZamok.SelectedIndex = cbZamok.Items.IndexOf(Enum.GetName(typeof(KV_Zamok2Names), _data.Kod));
            }
            else if (cons.CompareKod(_kod, "Комфорт-S"))
            {
                chbKodoviy.Checked = false;
                if (_num == 0)
                    cbZamok.SelectedIndex = cbZamok.Items.IndexOf(Enum.GetName(typeof(KT_Zamok1Names), _data.Kod));
                else
                    cbZamok.SelectedIndex = cbZamok.Items.IndexOf(Enum.GetName(typeof(KT_Zamok2Names), _data.Kod));
            }
            else if (cons.CompareKod(_kod, "ДМ1-МДФ1"))
            {
                chbKodoviy.Checked = false;
                if (_num == 0)
                    cbZamok.SelectedIndex = cbZamok.Items.IndexOf(Enum.GetName(typeof(DF_Zamok1Names), _data.Kod));
                else
                    cbZamok.SelectedIndex = cbZamok.Items.IndexOf(Enum.GetName(typeof(DF_Zamok2Names), _data.Kod));
            }

            int otPola;
            if (_kdata.Type != Kodoviy.Нет)
                otPola = cons.KODOVIY_OT_POLA;
            else
            {
                if (_num == 0)
                    otPola = cons.RUCHKA_OT_POLA;
                else
                    otPola = cons.ZAMOK2_OT_POLA;
            }
            if (_data.OtPola > 0 & _data.OtPola != otPola)
            {
                tbRaspol.Text = _data.OtPola.ToString();
                chRaspol.Checked = true;
                Enable(true);
            }
            else
            {
                tbRaspol.Text = otPola.ToString();
                chRaspol.Checked = false;
                Enable(false);
            }
        }
        private void Enable(bool enable)
        {
            lRaspol.Enabled = enable;
            tbRaspol.Enabled = enable;
        }

        public ZamokParam Zamok
        {
            get => _data;
            set
            {
                _data = value;
                Fill();
            }
        }
        public KodoviyParam KZamok
        {
            get => _kdata;
            set
            {
                _kdata = value;
                Fill();
            }
        }

        private void chbKodoviy_CheckedChanged(object sender, EventArgs e)
        {
            if (chbKodoviy.Checked)
            {
                cbZamok.DataSource = Enum.GetNames(typeof(Kodoviy));
                cbZamok.SelectedIndex = 0;
                if (_kdata.Type == Kodoviy.Нет)
                    _kdata.Type = Kodoviy.Врезной_кнопки_на_лице;
            }
            else
            {
                cbZamok.DataSource = Enum.GetNames(typeof(ZamokNames));
                cbZamok.SelectedIndex = 0;
            }
        }
        private void cbZamok_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbZamok.SelectedIndex > -1)
            {
                if (cons.CompareKod(_kod, "ДМ") | cons.CompareKod(_kod, "MAX"))
                {
                    if (chbKodoviy.Checked)
                        _kdata.Type = (Kodoviy)Enum.Parse(typeof(Kodoviy), cbZamok.SelectedItem.ToString());
                    else
                    {
                        ZamokNames zn = (ZamokNames)Enum.Parse(typeof(ZamokNames), cbZamok.SelectedItem.ToString());
                        _data.Kod = (short)zn;
                    }
                }
                else if (cons.CompareKod(_kod, "ЛМ"))
                {
                    LM_ZamokNames zn = (LM_ZamokNames)Enum.Parse(typeof(LM_ZamokNames), cbZamok.SelectedItem.ToString());
                    _data.Kod = (short)zn;
                }
                else if (cons.CompareKod(_kod, "ОДЛ"))
                {
                    ODL_ZamokNames zn = (ODL_ZamokNames)Enum.Parse(typeof(ODL_ZamokNames), cbZamok.SelectedItem.ToString());
                    _data.Kod = (short)zn;
                }
                else if (cons.CompareKod(_kod, "ВМ"))
                {
                    VM_ZamokNames zn = (VM_ZamokNames)Enum.Parse(typeof(VM_ZamokNames), cbZamok.SelectedItem.ToString());
                    _data.Kod = (short)zn;
                }
                else if (cons.CompareKod(_kod, "РИО") || cons.CompareKod(_kod, "КВ06") || cons.CompareKod(_kod, "Жардин"))
                {
                    if (_num == 0)
                        _data.Kod = (short)(VM_ZamokNames)Enum.Parse(typeof(KV_Zamok1Names), cbZamok.SelectedItem.ToString());
                    else
                        _data.Kod = (short)(VM_ZamokNames)Enum.Parse(typeof(KV_Zamok2Names), cbZamok.SelectedItem.ToString());
                }
                else if (cons.CompareKod(_kod, "Комфорт-S"))
                {
                    if (_num == 0)
                        _data.Kod = (short)(VM_ZamokNames)Enum.Parse(typeof(KT_Zamok1Names), cbZamok.SelectedItem.ToString());
                    else
                        _data.Kod = (short)(VM_ZamokNames)Enum.Parse(typeof(KT_Zamok2Names), cbZamok.SelectedItem.ToString());
                }
                else if (cons.CompareKod(_kod, "ДМ1-МДФ1"))
                {
                    if (_num == 0)
                        _data.Kod = (short)(VM_ZamokNames)Enum.Parse(typeof(DF_Zamok1Names), cbZamok.SelectedItem.ToString());
                    else
                        _data.Kod = (short)(VM_ZamokNames)Enum.Parse(typeof(DF_Zamok2Names), cbZamok.SelectedItem.ToString());
                }
            }
            else 
                Fill();
        }
        private void chRaspol_CheckedChanged(object sender, EventArgs e)
        {
            Enable(chRaspol.Checked);
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
    }
}
