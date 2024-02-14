
namespace COM_DoorsLibrary.Формы.Фрагменты
{
    partial class Fragment_Glazki
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
            this.gbParas = new System.Windows.Forms.GroupBox();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.lCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbParas.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbParas
            // 
            this.gbParas.AutoSize = true;
            this.gbParas.Controls.Add(this.btnMinus);
            this.gbParas.Controls.Add(this.btnPlus);
            this.gbParas.Controls.Add(this.lCount);
            this.gbParas.Controls.Add(this.label1);
            this.gbParas.Location = new System.Drawing.Point(3, 3);
            this.gbParas.Name = "gbParas";
            this.gbParas.Size = new System.Drawing.Size(265, 49);
            this.gbParas.TabIndex = 0;
            this.gbParas.TabStop = false;
            this.gbParas.Text = "Параметры глазков: ";
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(237, 10);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(22, 20);
            this.btnMinus.TabIndex = 3;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlus.Location = new System.Drawing.Point(209, 10);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(22, 20);
            this.btnPlus.TabIndex = 2;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // lCount
            // 
            this.lCount.AutoSize = true;
            this.lCount.Location = new System.Drawing.Point(179, 17);
            this.lCount.Name = "lCount";
            this.lCount.Size = new System.Drawing.Size(13, 13);
            this.lCount.TabIndex = 1;
            this.lCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество глазков в изделии:";
            // 
            // Fragment_Glazki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.gbParas);
            this.Name = "Fragment_Glazki";
            this.Size = new System.Drawing.Size(271, 55);
            this.gbParas.ResumeLayout(false);
            this.gbParas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox gbParas;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Label lCount;
        private System.Windows.Forms.Label label1;
    }
}
