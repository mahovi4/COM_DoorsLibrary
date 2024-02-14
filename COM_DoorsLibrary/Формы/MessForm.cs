using COM_DoorsLibrary.Формы.Фрагменты;
using System;
using System.Windows.Forms;

namespace COM_DoorsLibrary.Формы
{
    public partial class MessForm : Form
    {
        private readonly UserControl fragment;
        private readonly MessFormVar var = MessFormVar.нет;
        private readonly TableData _data;
        Label lFromTable = new Label();
        private int lh = 0;
        private string fromTable = "";

        public MessForm(MessFormVar val, ref TableData data)
        {
            InitializeComponent();
            var = val;
            _data = data;
            if (var != MessFormVar.нет)
            {
                switch (var)
                {
                    default:
                        return;
                    case MessFormVar.Порог:
                        fragment = new Fragment_Porog(_data.Kod, _data.PorogPar);
                        Text = "Введите параметры порога.";
                        fromTable = _data.PorogFromTable;
                        break;
                    case MessFormVar.Наличники:
                        fragment = new Fragment_Nalichniki(_data.Nalichniki);
                        Text = "Введите размеры наличников.";
                        break;
                    case MessFormVar.Створки:
                        fragment = new Fragment_WAktiv(_data.WAktivPar);
                        Text = "Введите параметры сворок.";
                        fromTable = _data.WAktivFromTable;
                        break;
                    case MessFormVar.Замок_1:
                        fragment = new Fragment_Zamok(_data.Kod, _data.Zamok[0], 0, _data.Kodoviy);
                        Text = "Введите параметры замка нижнего.";
                        fromTable = _data.GetZamokFromTable(0);
                        break;
                    case MessFormVar.Замок_2:
                        fragment = new Fragment_Zamok(_data.Kod, _data.Zamok[1], 1, _data.Kodoviy);
                        Text = "Введите параметры замка верхнего.";
                        fromTable = _data.GetZamokFromTable(1);
                        break;
                    case MessFormVar.Ручка_1:
                        fragment = new Fragment_Ruchka(_data.Kod, _data.GetRuchka((short)Stvorka.Активная, 0));
                        Text = "Введите параметры ручки.";
                        fromTable = _data.GetRuchkaFromTable((short)Stvorka.Активная, 0); 
                        break;
                    case MessFormVar.Ручка_2:
                        fragment = new Fragment_Ruchka(_data.Kod, _data.GetRuchka((short)Stvorka.Активная, 1));
                        Text = "Введите параметры ручки.";
                        fromTable = _data.GetRuchkaFromTable((short)Stvorka.Активная, 1);
                        break;
                    case MessFormVar.Ручка_3:
                        fragment = new Fragment_Ruchka(_data.Kod, _data.GetRuchka((short)Stvorka.Пассивная, 0));
                        Text = "Введите параметры ручки.";
                        fromTable = _data.GetRuchkaFromTable((short)Stvorka.Пассивная, 0);
                        break;
                    case MessFormVar.Ручка_4:
                        fragment = new Fragment_Ruchka(_data.Kod, _data.GetRuchka((short)Stvorka.Пассивная, 1));
                        Text = "Введите параметры ручки.";
                        fromTable = _data.GetRuchkaFromTable((short)Stvorka.Пассивная, 1);
                        break;
                    case MessFormVar.Задвижка:
                        fragment = new Fragment_Zadvizhka(_data.Kod, _data.Zadvizhka);
                        Text = "Введите параметры задвижки.";
                        fromTable = _data.Zadvizhka.FromTable;
                        break;
                    case MessFormVar.Глазок:
                        Fragment_Glazki fg = new Fragment_Glazki(_data.Glazok);
                        Text = "Введите параметры глазков.";
                        if (_data.Glazok.Length > 1)
                            fromTable = _data.Glazok[0].FromTable + '\n' + _data.Glazok[1].FromTable;
                        else if (_data.Glazok.Length > 0)
                            fromTable = _data.Glazok[0].FromTable;
                        fg.ChangeHeight += new ChangeHeightHandler(Fragment_Resize);
                        fragment = fg;
                        break;
                    case MessFormVar.Добор:
                        fragment = new Fragment_Dobors(_data.Dobor, _data.DoborParam);
                        Text = "Введите параметры доборов.";
                        fromTable = _data.DoborFromTable;
                        break;
                    case MessFormVar.Окно_1:
                        fragment = new Fragment_Okno(ref _data.OknoArr[0]);
                        Text = "Введите параметры окна 1.";
                        fromTable = _data.OknoArr[0].FromTable;
                        break;
                    case MessFormVar.Окно_2:
                        fragment = new Fragment_Okno(ref _data.OknoArr[1]);
                        Text = "Введите параметры окна 2.";
                        fromTable = _data.OknoArr[1].FromTable;
                        break;
                    case MessFormVar.Окно_3:
                        fragment = new Fragment_Okno(ref _data.OknoArr[2]);
                        Text = "Введите параметры окна 3.";
                        fromTable = _data.OknoArr[2].FromTable;
                        break;
                    case MessFormVar.Окно_4:
                        fragment = new Fragment_Okno(ref _data.OknoArr[3]);
                        Text = "Введите параметры окна 4.";
                        fromTable = _data.OknoArr[3].FromTable;
                        break;
                    case MessFormVar.Решетка_1:
                        fragment = new Fragment_Reshetka(0, ref _data.ReshArr[0]);
                        Text = "Введите параметры решетки 1.";
                        fromTable = _data.ReshArr[0].FromTable;
                        break;
                    case MessFormVar.Решетка_2:
                        fragment = new Fragment_Reshetka(1, ref _data.ReshArr[1]);
                        Text = "Введите параметры решетки 2.";
                        fromTable = _data.ReshArr[1].FromTable;
                        break;
                    case MessFormVar.Решетка_3:
                        fragment = new Fragment_Reshetka(2, ref _data.ReshArr[2]);
                        Text = "Введите параметры решетки 3.";
                        fromTable = _data.ReshArr[2].FromTable;
                        break;
                    case MessFormVar.Решетка_4:
                        fragment = new Fragment_Reshetka(3, ref _data.ReshArr[3]);
                        Text = "Введите параметры решетки 4.";
                        fromTable = _data.ReshArr[3].FromTable;
                        break;
                    case MessFormVar.Калитка:
                        fragment = new Fragment_Kalitka(_data.KalitParam);
                        Text = "Введите параметры калитки.";
                        fromTable = _data.KalitFromTable;
                        break;
                    case MessFormVar.Фрамуга_верх:
                        Fragment_Framuga frf1 = new Fragment_Framuga(ref _data, Raspolozhenie.Верх);
                        Text = "Введите параметры верхней фрамуги.";
                        fromTable = _data.FramugaParArr[(int)Raspolozhenie.Верх].FromTable;
                        frf1.ChangeHeight += new ChangeHeightHandler(Fragment_Resize);
                        fragment = frf1;
                        break;
                    case MessFormVar.Фрамуга_низ:
                        Fragment_Framuga frf2 = new Fragment_Framuga(ref _data, Raspolozhenie.Ниж);
                        Text = "Введите параметры нижней фрамуги.";
                        fromTable = _data.FramugaParArr[(int)Raspolozhenie.Ниж].FromTable;
                        frf2.ChangeHeight += new ChangeHeightHandler(Fragment_Resize);
                        fragment = frf2;
                        break;
                    case MessFormVar.Фрамуга_прав:
                        Fragment_Framuga frf3 = new Fragment_Framuga(ref _data, Raspolozhenie.Прав);
                        Text = "Введите параметры правой вставки.";
                        fromTable = _data.FramugaParArr[(int)Raspolozhenie.Прав].FromTable;
                        frf3.ChangeHeight += new ChangeHeightHandler(Fragment_Resize);
                        fragment = frf3;
                        break;
                    case MessFormVar.Фрамуга_лев:
                        Fragment_Framuga frf4 = new Fragment_Framuga(ref _data, Raspolozhenie.Лев);
                        Text = "Введите параметры левой фрамуги.";
                        fromTable = _data.FramugaParArr[(int)Raspolozhenie.Лев].FromTable;
                        frf4.ChangeHeight += new ChangeHeightHandler(Fragment_Resize);
                        fragment = frf4;
                        break;
                }
                if (!string.IsNullOrEmpty(fromTable))
                {
                    lFromTable.AutoSize = false;
                    lFromTable.Text = "Данные из таблицы: " + '\n' + fromTable;
                    //lFromTable.AutoSize = true;
                    lFromTable.Width = 265;
                    //lFromTable.Refresh();
                    lFromTable.Height = 100;
                    lh = lFromTable.Height + 10;
                }
                Fill();
            }
        }

        private void Fill()
        {
            scForm.Height = fragment.Height + lh + scForm.SplitterWidth + 35;
            scForm.SplitterDistance = fragment.Height + lh;
            Height = scForm.Height + 35;

            fragment.Left = 0;
            fragment.Top = 0;
            scForm.Panel1.Controls.Add(fragment);

            lFromTable.Left = 3;
            lFromTable.Top = fragment.Height + 3;
            scForm.Panel1.Controls.Add(lFromTable);
        }

        public void btnOk_Click(object sender, EventArgs e)
        {
            switch (var)
            {
                case MessFormVar.Порог:
                    Fragment_Porog frp = (Fragment_Porog)fragment;
                    _data.PorogPar = frp.Param;
                    break;
                case MessFormVar.Наличники:
                    Fragment_Nalichniki frn = (Fragment_Nalichniki)fragment;
                    _data.Nalichniki = frn.Nalichniki;
                    break;
                case MessFormVar.Створки:
                    Fragment_WAktiv frwa = (Fragment_WAktiv)fragment;
                    _data.WAktivPar = frwa.WAktiv;
                    break;
                case MessFormVar.Замок_1:
                    Fragment_Zamok frz1 = (Fragment_Zamok)fragment;
                    _data.Zamok[0] = frz1.Zamok;
                    _data.Kodoviy = frz1.KZamok;
                    break;
                case MessFormVar.Замок_2:
                    Fragment_Zamok frz2 = (Fragment_Zamok)fragment;
                    _data.Zamok[1] = frz2.Zamok;
                    if(_data.Kodoviy.Type == Kodoviy.Нет)
                        _data.Kodoviy = frz2.KZamok;
                    else
                        if(_data.Zamok[0].Kod>0)
                            _data.Kodoviy = frz2.KZamok;
                    break;
                case MessFormVar.Ручка_1:
                    Fragment_Ruchka frr1 = (Fragment_Ruchka)fragment;
                    _data.SetRuchka((short)Stvorka.Активная, 0, frr1.Ruchka);
                    break;
                case MessFormVar.Ручка_2:
                    Fragment_Ruchka frr2 = (Fragment_Ruchka)fragment;
                    _data.SetRuchka((short)Stvorka.Активная, 1, frr2.Ruchka);
                    break;
                case MessFormVar.Ручка_3:
                    Fragment_Ruchka frr3 = (Fragment_Ruchka)fragment;
                    _data.SetRuchka((short)Stvorka.Пассивная, 0, frr3.Ruchka);
                    break;
                case MessFormVar.Ручка_4:
                    Fragment_Ruchka frr4 = (Fragment_Ruchka)fragment;
                    _data.SetRuchka((short)Stvorka.Пассивная, 1, frr4.Ruchka);
                    break;
                case MessFormVar.Задвижка:
                    Fragment_Zadvizhka frz = (Fragment_Zadvizhka)fragment;
                    _data.Zadvizhka = frz.Zadvizhka;
                    break;
                case MessFormVar.Глазок:
                    Fragment_Glazki frg = (Fragment_Glazki)fragment;
                    _data.Glazok = frg.Glazki;
                    break;
                case MessFormVar.Калитка:
                    Fragment_Kalitka frk = (Fragment_Kalitka)fragment;
                    _data.KalitParam = frk.Param;
                    break;
                case MessFormVar.Добор:
                    Fragment_Dobors frd = (Fragment_Dobors)fragment;
                    _data.Dobor = frd.EnableDobor;
                    _data.DoborParam = frd.Param;
                    break;
                case MessFormVar.Окно_1:
                    Fragment_Okno fro1 = (Fragment_Okno)fragment;
                    _data.OknoArr[0] = fro1.Param;
                    break;
                case MessFormVar.Окно_2:
                    Fragment_Okno fro2 = (Fragment_Okno)fragment;
                    _data.OknoArr[1] = fro2.Param;
                    break;
                case MessFormVar.Окно_3:
                    Fragment_Okno fro3 = (Fragment_Okno)fragment;
                    _data.OknoArr[2] = fro3.Param;
                    break;
                case MessFormVar.Окно_4:
                    Fragment_Okno fro4 = (Fragment_Okno)fragment;
                    _data.OknoArr[3] = fro4.Param;
                    break;
                case MessFormVar.Решетка_1:
                    Fragment_Reshetka frrh1 = (Fragment_Reshetka)fragment;
                    _data.ReshArr[0] = frrh1.Param;
                    break;
                case MessFormVar.Решетка_2:
                    Fragment_Reshetka frrh2 = (Fragment_Reshetka)fragment;
                    _data.ReshArr[1] = frrh2.Param;
                    break;
                case MessFormVar.Решетка_3:
                    Fragment_Reshetka frrh3 = (Fragment_Reshetka)fragment;
                    _data.ReshArr[2] = frrh3.Param;
                    break;
                case MessFormVar.Решетка_4:
                    Fragment_Reshetka frrh4 = (Fragment_Reshetka)fragment;
                    _data.ReshArr[3] = frrh4.Param;
                    break;
                case MessFormVar.Стекло:
                    //Fragment_Steklo frs = (Fragment_Steklo)fragment;
                    //_param = frs.Param;
                    break;
                case MessFormVar.Фрамуга_верх:
                    Fragment_Framuga frf1 = (Fragment_Framuga)fragment;
                    _data.FramugaParArr[(int)Raspolozhenie.Верх] = frf1.Param;
                    break;
                case MessFormVar.Фрамуга_низ:
                    Fragment_Framuga frf2 = (Fragment_Framuga)fragment;
                    _data.FramugaParArr[(int)Raspolozhenie.Ниж] = frf2.Param;
                    break;
                case MessFormVar.Фрамуга_прав:
                    Fragment_Framuga frf3 = (Fragment_Framuga)fragment;
                    _data.FramugaParArr[(int)Raspolozhenie.Прав] = frf3.Param;
                    break;
                case MessFormVar.Фрамуга_лев:
                    Fragment_Framuga frf4 = (Fragment_Framuga)fragment;
                    _data.FramugaParArr[(int)Raspolozhenie.Лев] = frf4.Param;
                    break;
            }
            Hide();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void MessForm_Load(object sender, EventArgs e)
        {
            btnOk.DialogResult = DialogResult.Yes;
            btnCancel.DialogResult = DialogResult.Cancel;
        }
        private void Fragment_Resize(object sender, int deltaHeight)
        {
            Height += deltaHeight;
            scForm.Height += deltaHeight;
        }
    }

    public enum MessFormVar
    {
        нет,
        Порог,
        Наличники,
        Створки,
        Замок_1,
        Замок_2,
        Ручка_1,
        Ручка_2,
        Ручка_3,
        Ручка_4,
        Задвижка,
        Глазок,
        Стекло,
        Добор,
        Решетка_1,
        Решетка_2,
        Решетка_3,
        Решетка_4,
        Окно_1,
        Окно_2,
        Окно_3,
        Окно_4,
        Калитка,
        Фрамуга_верх,
        Фрамуга_низ,
        Фрамуга_прав,
        Фрамуга_лев,
    }
}
