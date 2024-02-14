
namespace COM_DoorsLibrary.Формы.Фрагменты
{
    partial class Fragment_Steklo
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
            this.gbSteklo = new System.Windows.Forms.GroupBox();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.lWidth = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.lHeight = new System.Windows.Forms.Label();
            this.cbThick = new System.Windows.Forms.ComboBox();
            this.lThick = new System.Windows.Forms.Label();
            this.gbSteklo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSteklo
            // 
            this.gbSteklo.Controls.Add(this.tbWidth);
            this.gbSteklo.Controls.Add(this.lWidth);
            this.gbSteklo.Controls.Add(this.tbHeight);
            this.gbSteklo.Controls.Add(this.lHeight);
            this.gbSteklo.Controls.Add(this.cbThick);
            this.gbSteklo.Controls.Add(this.lThick);
            this.gbSteklo.Location = new System.Drawing.Point(3, 3);
            this.gbSteklo.Name = "gbSteklo";
            this.gbSteklo.Size = new System.Drawing.Size(265, 75);
            this.gbSteklo.TabIndex = 0;
            this.gbSteklo.TabStop = false;
            this.gbSteklo.Text = "Параметры остекления";
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(186, 46);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(65, 20);
            this.tbWidth.TabIndex = 5;
            this.tbWidth.TextChanged += new System.EventHandler(this.tbWidth_TextChanged);
            this.tbWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lWidth
            // 
            this.lWidth.AutoSize = true;
            this.lWidth.Location = new System.Drawing.Point(131, 53);
            this.lWidth.Name = "lWidth";
            this.lWidth.Size = new System.Drawing.Size(49, 13);
            this.lWidth.TabIndex = 4;
            this.lWidth.Text = "Ширина:";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(60, 46);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(65, 20);
            this.tbHeight.TabIndex = 3;
            this.tbHeight.TextChanged += new System.EventHandler(this.tbHeight_TextChanged);
            this.tbHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lHeight
            // 
            this.lHeight.AutoSize = true;
            this.lHeight.Location = new System.Drawing.Point(6, 53);
            this.lHeight.Name = "lHeight";
            this.lHeight.Size = new System.Drawing.Size(48, 13);
            this.lHeight.TabIndex = 2;
            this.lHeight.Text = "Высота:";
            // 
            // cbThick
            // 
            this.cbThick.FormattingEnabled = true;
            this.cbThick.Location = new System.Drawing.Point(141, 19);
            this.cbThick.Name = "cbThick";
            this.cbThick.Size = new System.Drawing.Size(110, 21);
            this.cbThick.TabIndex = 1;
            this.cbThick.SelectedIndexChanged += new System.EventHandler(this.cbThick_SelectedIndexChanged);
            // 
            // lThick
            // 
            this.lThick.AutoSize = true;
            this.lThick.Location = new System.Drawing.Point(6, 27);
            this.lThick.Name = "lThick";
            this.lThick.Size = new System.Drawing.Size(129, 13);
            this.lThick.TabIndex = 0;
            this.lThick.Text = "Толщина стеклопакета:";
            // 
            // Fragment_Steklo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSteklo);
            this.Name = "Fragment_Steklo";
            this.Size = new System.Drawing.Size(270, 80);
            this.gbSteklo.ResumeLayout(false);
            this.gbSteklo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSteklo;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Label lWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label lHeight;
        private System.Windows.Forms.ComboBox cbThick;
        private System.Windows.Forms.Label lThick;
    }
}
