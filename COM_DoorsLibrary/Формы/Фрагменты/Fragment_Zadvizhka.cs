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
    public partial class Fragment_Zadvizhka : UserControl
    {
        private bool nonNumberEntered = false;
        private ZadvizhkaParam _data;
        private short _kod;
        private readonly Constants cons = new Constants();

        public Fragment_Zadvizhka(short kod, ZadvizhkaParam data)
        {
            InitializeComponent();

            if(cons.CompareKod(kod, "Комфорт-S") || cons.CompareKod(kod, "РИО") || 
                cons.CompareKod(kod, "КВ06") || cons.CompareKod(kod, "Жардин") || 
                cons.CompareKod(kod, "ДМ1-МДФ1"))
                cbType.DataSource = Enum.GetNames(typeof(KV_ZadvizhkaName));
            else
                cbType.DataSource = Enum.GetNames(typeof(ZadvizhkaNames));

            _data = data;
            _kod = kod;
            Fill();
        }

        public ZadvizhkaParam Zadvizhka
        {
            get => _data;
            set
            {
                _data = value;
                Fill();
            }
        }

        private void Fill()
        {
            if (cons.CompareKod(_kod, "Комфорт-S") || cons.CompareKod(_kod, "РИО") ||
                cons.CompareKod(_kod, "КВ06") || cons.CompareKod(_kod, "Жардин") ||
                cons.CompareKod(_kod, "ДМ1-МДФ1"))
            {
                cbType.SelectedIndex = cbType.Items.IndexOf(Enum.GetName(typeof(KV_ZadvizhkaName), _data.Kod));
                Enable(false);
                tbRaspol.Text = cons.ZADVIZHKA_OT_POLA.ToString();
            }
            else
            {
                cbType.SelectedIndex = cbType.Items.IndexOf(Enum.GetName(typeof(ZadvizhkaNames), _data.Kod));

                if (_data.OtPola > 0 & _data.OtPola != cons.ZADVIZHKA_OT_POLA)
                {
                    Enable(true);
                    tbRaspol.Text = _data.OtPola.ToString();
                }
                else
                {
                    Enable(false);
                    tbRaspol.Text = cons.ZADVIZHKA_OT_POLA.ToString();
                }
            }
        }
        private void Enable(bool enable)
        {
            lRaspol.Enabled = enable;
            tbRaspol.Enabled = enable;
        }
        
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex > -1)
            {
                if (cons.CompareKod(_kod, "Комфорт-S") || cons.CompareKod(_kod, "РИО") ||
                cons.CompareKod(_kod, "КВ06") || cons.CompareKod(_kod, "Жардин") ||
                cons.CompareKod(_kod, "ДМ1-МДФ1"))
                {
                    KV_ZadvizhkaName zn = (KV_ZadvizhkaName)Enum.Parse(typeof(KV_ZadvizhkaName), cbType.SelectedItem.ToString());
                    _data.Kod = (short)zn;
                }
                else
                {
                    ZadvizhkaNames zn = (ZadvizhkaNames)Enum.Parse(typeof(ZadvizhkaNames), cbType.SelectedItem.ToString());
                    _data.Kod = (short)zn;
                }
            }
            else Fill();
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
