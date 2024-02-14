
namespace COM_DoorsLibrary.Формы.Фрагменты
{
    partial class Fragment_Zamok
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbKodoviy = new System.Windows.Forms.CheckBox();
            this.lRaspol = new System.Windows.Forms.Label();
            this.tbRaspol = new System.Windows.Forms.TextBox();
            this.chRaspol = new System.Windows.Forms.CheckBox();
            this.cbZamok = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbKodoviy);
            this.groupBox1.Controls.Add(this.lRaspol);
            this.groupBox1.Controls.Add(this.tbRaspol);
            this.groupBox1.Controls.Add(this.chRaspol);
            this.groupBox1.Controls.Add(this.cbZamok);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры замка: ";
            // 
            // chbKodoviy
            // 
            this.chbKodoviy.AutoSize = true;
            this.chbKodoviy.Location = new System.Drawing.Point(9, 44);
            this.chbKodoviy.Name = "chbKodoviy";
            this.chbKodoviy.Size = new System.Drawing.Size(113, 17);
            this.chbKodoviy.TabIndex = 5;
            this.chbKodoviy.Text = "Замок - Кодовый";
            this.chbKodoviy.UseVisualStyleBackColor = true;
            this.chbKodoviy.CheckedChanged += new System.EventHandler(this.chbKodoviy_CheckedChanged);
            // 
            // lRaspol
            // 
            this.lRaspol.AutoSize = true;
            this.lRaspol.Location = new System.Drawing.Point(6, 96);
            this.lRaspol.Name = "lRaspol";
            this.lRaspol.Size = new System.Drawing.Size(167, 13);
            this.lRaspol.TabIndex = 3;
            this.lRaspol.Text = "Расположение замка от пола - ";
            // 
            // tbRaspol
            // 
            this.tbRaspol.Location = new System.Drawing.Point(179, 93);
            this.tbRaspol.Name = "tbRaspol";
            this.tbRaspol.Size = new System.Drawing.Size(80, 20);
            this.tbRaspol.TabIndex = 3;
            this.tbRaspol.TextChanged += new System.EventHandler(this.tbRaspol_TextChanged);
            this.tbRaspol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbRaspol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // chRaspol
            // 
            this.chRaspol.AutoSize = true;
            this.chRaspol.Location = new System.Drawing.Point(9, 70);
            this.chRaspol.Name = "chRaspol";
            this.chRaspol.Size = new System.Drawing.Size(189, 17);
            this.chRaspol.TabIndex = 2;
            this.chRaspol.Text = "Изменить расположение замка";
            this.chRaspol.UseVisualStyleBackColor = true;
            this.chRaspol.CheckedChanged += new System.EventHandler(this.chRaspol_CheckedChanged);
            // 
            // cbZamok
            // 
            this.cbZamok.FormattingEnabled = true;
            this.cbZamok.Location = new System.Drawing.Point(96, 19);
            this.cbZamok.Name = "cbZamok";
            this.cbZamok.Size = new System.Drawing.Size(163, 21);
            this.cbZamok.TabIndex = 1;
            this.cbZamok.SelectedIndexChanged += new System.EventHandler(this.cbZamok_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Модель замка:";
            // 
            // Fragment_Zamok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Fragment_Zamok";
            this.Size = new System.Drawing.Size(270, 125);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lRaspol;
        private System.Windows.Forms.TextBox tbRaspol;
        private System.Windows.Forms.CheckBox chRaspol;
        private System.Windows.Forms.ComboBox cbZamok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbKodoviy;
    }
}
