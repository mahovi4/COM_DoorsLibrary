
namespace COM_DoorsLibrary.Формы.Фрагменты
{
    partial class Fragment_Okno
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
            this.scOkno = new System.Windows.Forms.SplitContainer();
            this.gbRaspolozheie = new System.Windows.Forms.GroupBox();
            this.tbVR = new System.Windows.Forms.TextBox();
            this.cbVR = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGR = new System.Windows.Forms.TextBox();
            this.cbGR = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scOkno)).BeginInit();
            this.scOkno.Panel2.SuspendLayout();
            this.scOkno.SuspendLayout();
            this.gbRaspolozheie.SuspendLayout();
            this.SuspendLayout();
            // 
            // scOkno
            // 
            this.scOkno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scOkno.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scOkno.IsSplitterFixed = true;
            this.scOkno.Location = new System.Drawing.Point(0, 0);
            this.scOkno.Name = "scOkno";
            this.scOkno.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scOkno.Panel1
            // 
            this.scOkno.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.scOkno.Panel1MinSize = 0;
            // 
            // scOkno.Panel2
            // 
            this.scOkno.Panel2.Controls.Add(this.gbRaspolozheie);
            this.scOkno.Panel2MinSize = 0;
            this.scOkno.Size = new System.Drawing.Size(275, 190);
            this.scOkno.SplitterDistance = 80;
            this.scOkno.TabIndex = 0;
            // 
            // gbRaspolozheie
            // 
            this.gbRaspolozheie.Controls.Add(this.tbVR);
            this.gbRaspolozheie.Controls.Add(this.cbVR);
            this.gbRaspolozheie.Controls.Add(this.label2);
            this.gbRaspolozheie.Controls.Add(this.tbGR);
            this.gbRaspolozheie.Controls.Add(this.cbGR);
            this.gbRaspolozheie.Controls.Add(this.label1);
            this.gbRaspolozheie.Location = new System.Drawing.Point(3, 3);
            this.gbRaspolozheie.Name = "gbRaspolozheie";
            this.gbRaspolozheie.Size = new System.Drawing.Size(265, 105);
            this.gbRaspolozheie.TabIndex = 0;
            this.gbRaspolozheie.TabStop = false;
            this.gbRaspolozheie.Text = "Расположение окна";
            // 
            // tbVR
            // 
            this.tbVR.Location = new System.Drawing.Point(194, 74);
            this.tbVR.Name = "tbVR";
            this.tbVR.Size = new System.Drawing.Size(65, 20);
            this.tbVR.TabIndex = 5;
            this.tbVR.TextChanged += new System.EventHandler(this.tbVR_TextChanged);
            this.tbVR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbVR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // cbVR
            // 
            this.cbVR.FormattingEnabled = true;
            this.cbVR.Location = new System.Drawing.Point(6, 73);
            this.cbVR.Name = "cbVR";
            this.cbVR.Size = new System.Drawing.Size(182, 21);
            this.cbVR.TabIndex = 4;
            this.cbVR.SelectedIndexChanged += new System.EventHandler(this.cbVR_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "По вертикали:";
            // 
            // tbGR
            // 
            this.tbGR.Location = new System.Drawing.Point(194, 33);
            this.tbGR.Name = "tbGR";
            this.tbGR.Size = new System.Drawing.Size(65, 20);
            this.tbGR.TabIndex = 2;
            this.tbGR.TextChanged += new System.EventHandler(this.tbGR_TextChanged);
            this.tbGR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbGR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // cbGR
            // 
            this.cbGR.FormattingEnabled = true;
            this.cbGR.Location = new System.Drawing.Point(6, 32);
            this.cbGR.Name = "cbGR";
            this.cbGR.Size = new System.Drawing.Size(182, 21);
            this.cbGR.TabIndex = 1;
            this.cbGR.SelectedIndexChanged += new System.EventHandler(this.cbGR_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "По горизонтали:";
            // 
            // Fragment_Okno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scOkno);
            this.Name = "Fragment_Okno";
            this.Size = new System.Drawing.Size(275, 190);
            this.scOkno.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scOkno)).EndInit();
            this.scOkno.ResumeLayout(false);
            this.gbRaspolozheie.ResumeLayout(false);
            this.gbRaspolozheie.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scOkno;
        private System.Windows.Forms.GroupBox gbRaspolozheie;
        private System.Windows.Forms.TextBox tbVR;
        private System.Windows.Forms.ComboBox cbVR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGR;
        private System.Windows.Forms.ComboBox cbGR;
        private System.Windows.Forms.Label label1;
    }
}
