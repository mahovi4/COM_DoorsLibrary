
namespace COM_DoorsLibrary.Формы.Фрагменты
{
    partial class Fragment_Ruchka
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lMezhosev = new System.Windows.Forms.Label();
            this.tbMezhosev = new System.Windows.Forms.TextBox();
            this.chRaspol = new System.Windows.Forms.CheckBox();
            this.tbRaspol = new System.Windows.Forms.TextBox();
            this.lRaspol = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lRaspol);
            this.groupBox1.Controls.Add(this.tbRaspol);
            this.groupBox1.Controls.Add(this.chRaspol);
            this.groupBox1.Controls.Add(this.tbMezhosev);
            this.groupBox1.Controls.Add(this.lMezhosev);
            this.groupBox1.Controls.Add(this.cbType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры ручки: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Модель ручки: ";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(95, 19);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(164, 21);
            this.cbType.TabIndex = 1;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // lMezhosev
            // 
            this.lMezhosev.AutoSize = true;
            this.lMezhosev.Location = new System.Drawing.Point(6, 54);
            this.lMezhosev.Name = "lMezhosev";
            this.lMezhosev.Size = new System.Drawing.Size(181, 13);
            this.lMezhosev.TabIndex = 2;
            this.lMezhosev.Text = "Межосевое расстояние крепежа: ";
            // 
            // tbMezhosev
            // 
            this.tbMezhosev.Location = new System.Drawing.Point(194, 46);
            this.tbMezhosev.Name = "tbMezhosev";
            this.tbMezhosev.Size = new System.Drawing.Size(65, 20);
            this.tbMezhosev.TabIndex = 3;
            this.tbMezhosev.TextChanged += new System.EventHandler(this.tbMezhosev_TextChanged);
            this.tbMezhosev.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbMezhosev.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // chRaspol
            // 
            this.chRaspol.AutoSize = true;
            this.chRaspol.Location = new System.Drawing.Point(9, 76);
            this.chRaspol.Name = "chRaspol";
            this.chRaspol.Size = new System.Drawing.Size(185, 17);
            this.chRaspol.TabIndex = 4;
            this.chRaspol.Text = "Изменить расположение ручки";
            this.chRaspol.UseVisualStyleBackColor = true;
            this.chRaspol.CheckedChanged += new System.EventHandler(this.chRaspol_CheckedChanged);
            // 
            // tbRaspol
            // 
            this.tbRaspol.Location = new System.Drawing.Point(194, 99);
            this.tbRaspol.Name = "tbRaspol";
            this.tbRaspol.Size = new System.Drawing.Size(65, 20);
            this.tbRaspol.TabIndex = 5;
            this.tbRaspol.TextChanged += new System.EventHandler(this.tbRaspol_TextChanged);
            this.tbRaspol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbRaspol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lRaspol
            // 
            this.lRaspol.AutoSize = true;
            this.lRaspol.Location = new System.Drawing.Point(9, 106);
            this.lRaspol.Name = "lRaspol";
            this.lRaspol.Size = new System.Drawing.Size(160, 13);
            this.lRaspol.TabIndex = 6;
            this.lRaspol.Text = "Расположение ручки от пола -";
            // 
            // Fragment_Ruchka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Fragment_Ruchka";
            this.Size = new System.Drawing.Size(270, 130);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMezhosev;
        private System.Windows.Forms.Label lMezhosev;
        private System.Windows.Forms.Label lRaspol;
        private System.Windows.Forms.TextBox tbRaspol;
        private System.Windows.Forms.CheckBox chRaspol;
    }
}
