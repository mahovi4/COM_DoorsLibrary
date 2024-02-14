
namespace COM_DoorsLibrary.Формы.Фрагменты
{
    partial class Fragment_Dobors
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
            this.chEnableDobor = new System.Windows.Forms.CheckBox();
            this.lGlubina = new System.Windows.Forms.Label();
            this.tbGlubina = new System.Windows.Forms.TextBox();
            this.gbNalichniki = new System.Windows.Forms.GroupBox();
            this.tbNalDown = new System.Windows.Forms.TextBox();
            this.tbNalRight = new System.Windows.Forms.TextBox();
            this.tbNalLeft = new System.Windows.Forms.TextBox();
            this.lNalDown = new System.Windows.Forms.Label();
            this.tbNalUp = new System.Windows.Forms.TextBox();
            this.lNalRight = new System.Windows.Forms.Label();
            this.lNalLeft = new System.Windows.Forms.Label();
            this.lNalUp = new System.Windows.Forms.Label();
            this.gbNalichniki.SuspendLayout();
            this.SuspendLayout();
            // 
            // chEnableDobor
            // 
            this.chEnableDobor.AutoSize = true;
            this.chEnableDobor.Location = new System.Drawing.Point(3, 3);
            this.chEnableDobor.Name = "chEnableDobor";
            this.chEnableDobor.Size = new System.Drawing.Size(108, 17);
            this.chEnableDobor.TabIndex = 0;
            this.chEnableDobor.Text = "Наличие добора";
            this.chEnableDobor.UseVisualStyleBackColor = true;
            this.chEnableDobor.CheckedChanged += new System.EventHandler(this.chEnableDobor_CheckedChanged);
            // 
            // lGlubina
            // 
            this.lGlubina.AutoSize = true;
            this.lGlubina.Location = new System.Drawing.Point(3, 30);
            this.lGlubina.Name = "lGlubina";
            this.lGlubina.Size = new System.Drawing.Size(87, 13);
            this.lGlubina.TabIndex = 1;
            this.lGlubina.Text = "Глубина добора";
            // 
            // tbGlubina
            // 
            this.tbGlubina.Location = new System.Drawing.Point(96, 27);
            this.tbGlubina.Name = "tbGlubina";
            this.tbGlubina.Size = new System.Drawing.Size(169, 20);
            this.tbGlubina.TabIndex = 2;
            this.tbGlubina.TextChanged += new System.EventHandler(this.tbGlubina_TextChanged);
            this.tbGlubina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbGlubina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // gbNalichniki
            // 
            this.gbNalichniki.Controls.Add(this.tbNalDown);
            this.gbNalichniki.Controls.Add(this.tbNalRight);
            this.gbNalichniki.Controls.Add(this.tbNalLeft);
            this.gbNalichniki.Controls.Add(this.lNalDown);
            this.gbNalichniki.Controls.Add(this.tbNalUp);
            this.gbNalichniki.Controls.Add(this.lNalRight);
            this.gbNalichniki.Controls.Add(this.lNalLeft);
            this.gbNalichniki.Controls.Add(this.lNalUp);
            this.gbNalichniki.Location = new System.Drawing.Point(6, 53);
            this.gbNalichniki.Name = "gbNalichniki";
            this.gbNalichniki.Size = new System.Drawing.Size(265, 75);
            this.gbNalichniki.TabIndex = 3;
            this.gbNalichniki.TabStop = false;
            this.gbNalichniki.Text = "Наличники: ";
            // 
            // tbNalDown
            // 
            this.tbNalDown.Location = new System.Drawing.Point(194, 19);
            this.tbNalDown.Name = "tbNalDown";
            this.tbNalDown.Size = new System.Drawing.Size(65, 20);
            this.tbNalDown.TabIndex = 15;
            this.tbNalDown.TextChanged += new System.EventHandler(this.tbNalDown_TextChanged);
            this.tbNalDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbNalDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // tbNalRight
            // 
            this.tbNalRight.Location = new System.Drawing.Point(194, 45);
            this.tbNalRight.Name = "tbNalRight";
            this.tbNalRight.Size = new System.Drawing.Size(65, 20);
            this.tbNalRight.TabIndex = 14;
            this.tbNalRight.TextChanged += new System.EventHandler(this.tbNalRight_TextChanged);
            this.tbNalRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbNalRight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // tbNalLeft
            // 
            this.tbNalLeft.Location = new System.Drawing.Point(64, 45);
            this.tbNalLeft.Name = "tbNalLeft";
            this.tbNalLeft.Size = new System.Drawing.Size(65, 20);
            this.tbNalLeft.TabIndex = 13;
            this.tbNalLeft.TextChanged += new System.EventHandler(this.tbNalLeft_TextChanged);
            this.tbNalLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbNalLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lNalDown
            // 
            this.lNalDown.AutoSize = true;
            this.lNalDown.Location = new System.Drawing.Point(138, 22);
            this.lNalDown.Name = "lNalDown";
            this.lNalDown.Size = new System.Drawing.Size(50, 13);
            this.lNalDown.TabIndex = 9;
            this.lNalDown.Text = "Нижний:";
            // 
            // tbNalUp
            // 
            this.tbNalUp.Location = new System.Drawing.Point(64, 19);
            this.tbNalUp.Name = "tbNalUp";
            this.tbNalUp.Size = new System.Drawing.Size(65, 20);
            this.tbNalUp.TabIndex = 12;
            this.tbNalUp.TextChanged += new System.EventHandler(this.tbNalUp_TextChanged);
            this.tbNalUp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.tbNalUp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lNalRight
            // 
            this.lNalRight.AutoSize = true;
            this.lNalRight.Location = new System.Drawing.Point(138, 48);
            this.lNalRight.Name = "lNalRight";
            this.lNalRight.Size = new System.Drawing.Size(50, 13);
            this.lNalRight.TabIndex = 11;
            this.lNalRight.Text = "Правый:";
            // 
            // lNalLeft
            // 
            this.lNalLeft.AutoSize = true;
            this.lNalLeft.Location = new System.Drawing.Point(6, 48);
            this.lNalLeft.Name = "lNalLeft";
            this.lNalLeft.Size = new System.Drawing.Size(44, 13);
            this.lNalLeft.TabIndex = 10;
            this.lNalLeft.Text = "Левый:";
            // 
            // lNalUp
            // 
            this.lNalUp.AutoSize = true;
            this.lNalUp.Location = new System.Drawing.Point(6, 22);
            this.lNalUp.Name = "lNalUp";
            this.lNalUp.Size = new System.Drawing.Size(52, 13);
            this.lNalUp.TabIndex = 8;
            this.lNalUp.Text = "Верхний:";
            // 
            // Fragment_Dobors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbNalichniki);
            this.Controls.Add(this.tbGlubina);
            this.Controls.Add(this.lGlubina);
            this.Controls.Add(this.chEnableDobor);
            this.Name = "Fragment_Dobors";
            this.Size = new System.Drawing.Size(275, 130);
            this.gbNalichniki.ResumeLayout(false);
            this.gbNalichniki.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chEnableDobor;
        private System.Windows.Forms.Label lGlubina;
        private System.Windows.Forms.TextBox tbGlubina;
        private System.Windows.Forms.GroupBox gbNalichniki;
        private System.Windows.Forms.TextBox tbNalDown;
        private System.Windows.Forms.TextBox tbNalRight;
        private System.Windows.Forms.TextBox tbNalLeft;
        private System.Windows.Forms.Label lNalDown;
        private System.Windows.Forms.TextBox tbNalUp;
        private System.Windows.Forms.Label lNalRight;
        private System.Windows.Forms.Label lNalLeft;
        private System.Windows.Forms.Label lNalUp;
    }
}
