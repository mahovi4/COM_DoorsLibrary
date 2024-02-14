
namespace COM_DoorsLibrary.Формы.Фрагменты
{
    partial class Fragment_WAktiv
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
            this.chRavnopol = new System.Windows.Forms.CheckBox();
            this.lWAktiv = new System.Windows.Forms.Label();
            this.tbWAktiv = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbWAktiv);
            this.groupBox1.Controls.Add(this.lWAktiv);
            this.groupBox1.Controls.Add(this.chRavnopol);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры створки: ";
            // 
            // chRavnopol
            // 
            this.chRavnopol.AutoSize = true;
            this.chRavnopol.Location = new System.Drawing.Point(7, 20);
            this.chRavnopol.Name = "chRavnopol";
            this.chRavnopol.Size = new System.Drawing.Size(133, 17);
            this.chRavnopol.TabIndex = 0;
            this.chRavnopol.Text = "Равнополые створки";
            this.chRavnopol.UseVisualStyleBackColor = true;
            this.chRavnopol.CheckedChanged += new System.EventHandler(this.chRavnopol_CheckedChanged);
            // 
            // lWAktiv
            // 
            this.lWAktiv.AutoSize = true;
            this.lWAktiv.Location = new System.Drawing.Point(7, 44);
            this.lWAktiv.Name = "lWAktiv";
            this.lWAktiv.Size = new System.Drawing.Size(143, 13);
            this.lWAktiv.TabIndex = 1;
            this.lWAktiv.Text = "Ширина активной створки:";
            // 
            // tbWAktiv
            // 
            this.tbWAktiv.Location = new System.Drawing.Point(157, 36);
            this.tbWAktiv.Name = "tbWAktiv";
            this.tbWAktiv.Size = new System.Drawing.Size(100, 20);
            this.tbWAktiv.TabIndex = 2;
            this.tbWAktiv.TextChanged += new System.EventHandler(this.tbWAktiv_TextChanged);
            this.tbWAktiv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbWAktiv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // Fragment_WAktiv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Fragment_WAktiv";
            this.Size = new System.Drawing.Size(270, 70);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbWAktiv;
        private System.Windows.Forms.Label lWAktiv;
        private System.Windows.Forms.CheckBox chRavnopol;
    }
}
