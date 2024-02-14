using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы.Фрагменты
{
    public delegate void ChangeHeightHandler(object sender, int deltaHeight);

    public partial class Fragment_Glazki : UserControl
    {
        private List<GlazokParam> _datas = new List<GlazokParam>();
        private readonly List<Fragment_Glazok> fragments = new List<Fragment_Glazok>();

        public event ChangeHeightHandler ChangeHeight;

        public Fragment_Glazki(GlazokParam[] datas)
        {
            InitializeComponent();
            for (int i = 0; i < datas.Length; i++)
                _datas.Add(datas[i]);
            Fill();
        }

        public GlazokParam[] Glazki
        {
            get
            {
                for (int i = 0; i < fragments.Count; i++) _datas[i] = fragments[i].Glazok;
                return _datas.ToArray();
            }
            set
            {
                _datas.Clear();
                foreach (var gp in value)
                    _datas.Add(gp);
                Fill();
            }
        }

        private void Fill()
        {
            fragments.Clear();
            for(int i=0; i<_datas.Count; i++)
            {
                int c;
                if (_datas.Count > 1)
                    c = i;
                else
                    c = -1;
                GlazokParam gp = _datas[i];
                AddFragment(ref gp, c);
            }
            lCount.Text = _datas.Count.ToString();
            EnableButton();
        }
        private void EnableButton()
        {
            if(_datas.Count > 1)
            {
                btnPlus.Enabled = false;
                btnMinus.Enabled = true;
            }
            else if(_datas.Count < 1)
            {
                btnPlus.Enabled = true;
                btnMinus.Enabled = false;
            }
            else
            {
                btnPlus.Enabled = true;
                btnMinus.Enabled = true;
            }
        }
        private void Add()
        {
            GlazokParam gp = new GlazokParam { Raspolozhenie = GlazokRaspolozhenie.По_центру, OtPola = 0, FromTable = "" };
            _datas.Add(gp);
            AddFragment(ref gp, _datas.Count - 1);
            lCount.Text = _datas.Count.ToString();
            EnableButton();
        }
        private void AddFragment(ref GlazokParam data, int num)
        {
            Fragment_Glazok frg = new Fragment_Glazok(ref data, num);
            frg.Left = 6;
            if (num <= 0)
                frg.Top = lCount.Top + lCount.Height + 5;
            else
                frg.Top = fragments[num - 1].Top + fragments[num - 1].Height + 5;
            Height += frg.Height + 5;
            gbParas.Height += frg.Height + 5;
            gbParas.Controls.Add(frg);
            fragments.Add(frg);
            OnChangeHeight(frg.Height + 5);
        }
        private void Remove()
        {
            int delta = gbParas.Controls[gbParas.Controls.Count - 1].Height;
            _datas.Remove(_datas[_datas.Count - 1]);
            gbParas.Height -= gbParas.Controls[gbParas.Controls.Count - 1].Height + 5;
            Height -= gbParas.Controls[gbParas.Controls.Count - 1].Height + 5;
            gbParas.Controls.Remove(gbParas.Controls[gbParas.Controls.Count - 1]);
            fragments.Remove(fragments[fragments.Count - 1]);
            lCount.Text = _datas.Count.ToString();
            EnableButton();
            OnChangeHeight((delta +5) * (-1));
        }

        protected virtual void OnChangeHeight(int deltaHeight)
        {
            ChangeHeight?.Invoke(this, deltaHeight);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Add();
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            Remove();
        }
    }
}
