
namespace COM_DoorsLibrary.Формы.Фрагменты
{
    partial class Fragment_Glazok
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
            this.gbPars = new System.Windows.Forms.GroupBox();
            this.tbRaspol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRaspol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbPars.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPars
            // 
            this.gbPars.Controls.Add(this.tbRaspol);
            this.gbPars.Controls.Add(this.label2);
            this.gbPars.Controls.Add(this.cbRaspol);
            this.gbPars.Controls.Add(this.label1);
            this.gbPars.Location = new System.Drawing.Point(3, 3);
            this.gbPars.Name = "gbPars";
            this.gbPars.Size = new System.Drawing.Size(230, 75);
            this.gbPars.TabIndex = 0;
            this.gbPars.TabStop = false;
            this.gbPars.Text = "Параметры глазка: ";
            // 
            // tbRaspol
            // 
            this.tbRaspol.Location = new System.Drawing.Point(100, 46);
            this.tbRaspol.Name = "tbRaspol";
            this.tbRaspol.Size = new System.Drawing.Size(120, 20);
            this.tbRaspol.TabIndex = 3;
            this.tbRaspol.TextChanged += new System.EventHandler(this.tbRaspol_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Oт пола: ";
            // 
            // cbRaspol
            // 
            this.cbRaspol.FormattingEnabled = true;
            this.cbRaspol.Location = new System.Drawing.Point(100, 19);
            this.cbRaspol.Name = "cbRaspol";
            this.cbRaspol.Size = new System.Drawing.Size(120, 21);
            this.cbRaspol.TabIndex = 1;
            this.cbRaspol.SelectedIndexChanged += new System.EventHandler(this.cbRaspol_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Расположение: ";
            // 
            // Fragment_Glazok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPars);
            this.Name = "Fragment_Glazok";
            this.Size = new System.Drawing.Size(235, 80);
            this.gbPars.ResumeLayout(false);
            this.gbPars.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPars;
        private System.Windows.Forms.ComboBox cbRaspol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRaspol;
        private System.Windows.Forms.Label label2;
    }
}
