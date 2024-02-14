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

    public partial class Fragment_Porog : UserControl
    {
        private PorogParam porogParam;
        private readonly Constants cons = new Constants();
        private readonly short _kod = 0;

        public Fragment_Porog(short kod, PorogParam param = default)
        {
            InitializeComponent();
            _kod = kod;
            if (cons.CompareKod(_kod, "ОДЛ"))
                cbType.DataSource = Enum.GetNames(typeof(ODL_PorogNames));
            else
            {
                cbType.DataSource = Enum.GetNames(typeof(DM_PorogNames));
            }
            porogParam = param;
            Fill();
        }

        public PorogParam Param
        {
            get => porogParam;
            set
            {
                porogParam = value;
                Fill();
            }
        }

        private void Fill()
        {
            if (cons.CompareKod(_kod, "ОДЛ"))
                cbType.SelectedIndex = cbType.Items.IndexOf(Enum.GetName(typeof(ODL_PorogNames), porogParam.Kod));
            else
                cbType.SelectedIndex = cbType.Items.IndexOf(Enum.GetName(typeof(DM_PorogNames), porogParam.Kod));
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex > -1)
            {
                if (cons.CompareKod(_kod, "ОДЛ"))
                {
                    ODL_PorogNames pn = (ODL_PorogNames)Enum.Parse(typeof(ODL_PorogNames), cbType.SelectedItem.ToString());
                    porogParam.Kod = (short)pn;
                }
                else
                {
                    DM_PorogNames pn = (DM_PorogNames)Enum.Parse(typeof(DM_PorogNames), cbType.SelectedItem.ToString());
                    porogParam.Kod = (short)pn;
                }
            }
            else Fill();
        }
    }
}
