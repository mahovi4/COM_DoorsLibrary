
namespace COM_DoorsLibrary.Формы.Фрагменты
{
    partial class Fragment_Framuga
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
            this.scFramuga = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.lOsteklenie = new System.Windows.Forms.Label();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.lWidth = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.lHeight = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scFramuga)).BeginInit();
            this.scFramuga.Panel1.SuspendLayout();
            this.scFramuga.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scFramuga
            // 
            this.scFramuga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scFramuga.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scFramuga.IsSplitterFixed = true;
            this.scFramuga.Location = new System.Drawing.Point(0, 0);
            this.scFramuga.Name = "scFramuga";
            this.scFramuga.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scFramuga.Panel1
            // 
            this.scFramuga.Panel1.Controls.Add(this.groupBox1);
            this.scFramuga.Size = new System.Drawing.Size(275, 190);
            this.scFramuga.SplitterDistance = 95;
            this.scFramuga.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMinus);
            this.groupBox1.Controls.Add(this.btnPlus);
            this.groupBox1.Controls.Add(this.lOsteklenie);
            this.groupBox1.Controls.Add(this.tbWidth);
            this.groupBox1.Controls.Add(this.lWidth);
            this.groupBox1.Controls.Add(this.tbHeight);
            this.groupBox1.Controls.Add(this.lHeight);
            this.groupBox1.Controls.Add(this.cbType);
            this.groupBox1.Controls.Add(this.lType);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры фрамуги";
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(242, 72);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(22, 20);
            this.btnMinus.TabIndex = 8;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(214, 72);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(22, 20);
            this.btnPlus.TabIndex = 7;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // lOsteklenie
            // 
            this.lOsteklenie.AutoSize = true;
            this.lOsteklenie.Location = new System.Drawing.Point(6, 79);
            this.lOsteklenie.Name = "lOsteklenie";
            this.lOsteklenie.Size = new System.Drawing.Size(68, 13);
            this.lOsteklenie.TabIndex = 6;
            this.lOsteklenie.Text = "Остекление";
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(199, 46);
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
            this.lWidth.Location = new System.Drawing.Point(144, 53);
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
            this.cbType.Location = new System.Drawing.Point(88, 19);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(176, 21);
            this.cbType.TabIndex = 1;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.Location = new System.Drawing.Point(6, 27);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(76, 13);
            this.lType.TabIndex = 0;
            this.lType.Text = "Тип фрамуги:";
            // 
            // Fragment_Framuga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scFramuga);
            this.Name = "Fragment_Framuga";
            this.Size = new System.Drawing.Size(275, 190);
            this.scFramuga.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scFramuga)).EndInit();
            this.scFramuga.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scFramuga;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Label lOsteklenie;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Label lWidth;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label lHeight;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lType;
    }
}
