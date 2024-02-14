
namespace COM_DoorsLibrary.Формы.Фрагменты
{
    partial class Fragment_Kalitka
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbGab = new System.Windows.Forms.GroupBox();
            this.cbOtkrivanie = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbOtZamka = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbOtPola = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ttKalitka = new System.Windows.Forms.ToolTip(this.components);
            this.gbGab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGab
            // 
            this.gbGab.Controls.Add(this.cbOtkrivanie);
            this.gbGab.Controls.Add(this.label5);
            this.gbGab.Controls.Add(this.tbWidth);
            this.gbGab.Controls.Add(this.tbHeight);
            this.gbGab.Controls.Add(this.label2);
            this.gbGab.Controls.Add(this.label1);
            this.gbGab.Location = new System.Drawing.Point(3, 3);
            this.gbGab.Name = "gbGab";
            this.gbGab.Size = new System.Drawing.Size(270, 75);
            this.gbGab.TabIndex = 0;
            this.gbGab.TabStop = false;
            this.gbGab.Text = "Габариты калитки: ";
            // 
            // cbOtkrivanie
            // 
            this.cbOtkrivanie.FormattingEnabled = true;
            this.cbOtkrivanie.Location = new System.Drawing.Point(131, 45);
            this.cbOtkrivanie.Name = "cbOtkrivanie";
            this.cbOtkrivanie.Size = new System.Drawing.Size(133, 21);
            this.cbOtkrivanie.TabIndex = 5;
            this.cbOtkrivanie.SelectedIndexChanged += new System.EventHandler(this.cbOtkrivanie_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Сторона открывания: ";
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(199, 19);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(65, 20);
            this.tbWidth.TabIndex = 3;
            this.tbWidth.TextChanged += new System.EventHandler(this.tbWidth_TextChanged);
            this.tbWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(63, 19);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(65, 20);
            this.tbHeight.TabIndex = 2;
            this.tbHeight.TextChanged += new System.EventHandler(this.tbHeight_TextChanged);
            this.tbHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ширина: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Высота: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbOtZamka);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbOtPola);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 75);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Расположение калитки: ";
            // 
            // tbOtZamka
            // 
            this.tbOtZamka.Location = new System.Drawing.Point(199, 45);
            this.tbOtZamka.Name = "tbOtZamka";
            this.tbOtZamka.Size = new System.Drawing.Size(65, 20);
            this.tbOtZamka.TabIndex = 3;
            this.ttKalitka.SetToolTip(this.tbOtZamka, "Расположение калитки в створке относительно замкового профиля створки (стандартно" +
        " - 100 мм)");
            this.tbOtZamka.TextChanged += new System.EventHandler(this.tbOtZamka_TextChanged);
            this.tbOtZamka.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbOtZamka.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "От замкового профиля (100 мм): ";
            // 
            // tbOtPola
            // 
            this.tbOtPola.Location = new System.Drawing.Point(199, 19);
            this.tbOtPola.Name = "tbOtPola";
            this.tbOtPola.Size = new System.Drawing.Size(65, 20);
            this.tbOtPola.TabIndex = 1;
            this.ttKalitka.SetToolTip(this.tbOtPola, "Расположение калитки в створки относительно уровня пола (стандартно - 100 мм)");
            this.tbOtPola.TextChanged += new System.EventHandler(this.tbOtPola_TextChanged);
            this.tbOtPola.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbOtPola.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Расположение от пола (100 мм): ";
            // 
            // Fragment_Kalitka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbGab);
            this.Name = "Fragment_Kalitka";
            this.Size = new System.Drawing.Size(275, 160);
            this.gbGab.ResumeLayout(false);
            this.gbGab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbOtZamka;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbOtPola;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip ttKalitka;
        private System.Windows.Forms.ComboBox cbOtkrivanie;
        private System.Windows.Forms.Label label5;
    }
}
