
namespace COM_DoorsLibrary.Формы.Фрагменты
{
    partial class Fragment_Reshetka
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
            this.gbReshetka = new System.Windows.Forms.GroupBox();
            this.tbOtPola = new System.Windows.Forms.TextBox();
            this.lOtPola = new System.Windows.Forms.Label();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.lWidth = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.lHeight = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lType = new System.Windows.Forms.Label();
            this.gbReshetka.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReshetka
            // 
            this.gbReshetka.Controls.Add(this.tbOtPola);
            this.gbReshetka.Controls.Add(this.lOtPola);
            this.gbReshetka.Controls.Add(this.tbWidth);
            this.gbReshetka.Controls.Add(this.lWidth);
            this.gbReshetka.Controls.Add(this.tbHeight);
            this.gbReshetka.Controls.Add(this.lHeight);
            this.gbReshetka.Controls.Add(this.cbType);
            this.gbReshetka.Controls.Add(this.lType);
            this.gbReshetka.Location = new System.Drawing.Point(3, 3);
            this.gbReshetka.Name = "gbReshetka";
            this.gbReshetka.Size = new System.Drawing.Size(265, 105);
            this.gbReshetka.TabIndex = 0;
            this.gbReshetka.TabStop = false;
            this.gbReshetka.Text = "Параметры решетки";
            // 
            // tbOtPola
            // 
            this.tbOtPola.Location = new System.Drawing.Point(186, 72);
            this.tbOtPola.Name = "tbOtPola";
            this.tbOtPola.Size = new System.Drawing.Size(65, 20);
            this.tbOtPola.TabIndex = 7;
            this.tbOtPola.TextChanged += new System.EventHandler(this.tbOtPola_TextChanged);
            this.tbOtPola.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbOtPola.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lOtPola
            // 
            this.lOtPola.AutoSize = true;
            this.lOtPola.Location = new System.Drawing.Point(6, 79);
            this.lOtPola.Name = "lOtPola";
            this.lOtPola.Size = new System.Drawing.Size(172, 13);
            this.lOtPola.TabIndex = 6;
            this.lOtPola.Text = "Расположение решетки от пола:";
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
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(87, 19);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(164, 21);
            this.cbType.TabIndex = 1;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.Location = new System.Drawing.Point(6, 27);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(75, 13);
            this.lType.TabIndex = 0;
            this.lType.Text = "Тип решетки:";
            // 
            // Fragment_Reshetka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbReshetka);
            this.Name = "Fragment_Reshetka";
            this.Size = new System.Drawing.Size(270, 110);
            this.gbReshetka.ResumeLayout(false);
            this.gbReshetka.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReshetka;
        private System.Windows.Forms.TextBox tbOtPola;
        private System.Windows.Forms.Label lOtPola;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Label lWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label lHeight;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lType;
    }
}
