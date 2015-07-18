namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.butcos = new System.Windows.Forms.Button();
            this.butsin = new System.Windows.Forms.Button();
            this.buexp = new System.Windows.Forms.Button();
            this.butx2 = new System.Windows.Forms.Button();
            this.butx3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(453, 289);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // butcos
            // 
            this.butcos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butcos.Location = new System.Drawing.Point(503, 12);
            this.butcos.Name = "butcos";
            this.butcos.Size = new System.Drawing.Size(98, 23);
            this.butcos.TabIndex = 1;
            this.butcos.Text = "Cos(x)";
            this.butcos.UseVisualStyleBackColor = true;
            this.butcos.Click += new System.EventHandler(this.butcos_Click);
            // 
            // butsin
            // 
            this.butsin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butsin.Location = new System.Drawing.Point(503, 71);
            this.butsin.Name = "butsin";
            this.butsin.Size = new System.Drawing.Size(98, 23);
            this.butsin.TabIndex = 2;
            this.butsin.Text = "Sin(x)";
            this.butsin.UseVisualStyleBackColor = true;
            this.butsin.Click += new System.EventHandler(this.butsin_Click);
            // 
            // buexp
            // 
            this.buexp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buexp.Location = new System.Drawing.Point(503, 128);
            this.buexp.Name = "buexp";
            this.buexp.Size = new System.Drawing.Size(98, 23);
            this.buexp.TabIndex = 3;
            this.buexp.Text = "exp(x)";
            this.buexp.UseVisualStyleBackColor = true;
            this.buexp.Click += new System.EventHandler(this.buexp_Click);
            // 
            // butx2
            // 
            this.butx2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butx2.Location = new System.Drawing.Point(503, 193);
            this.butx2.Name = "butx2";
            this.butx2.Size = new System.Drawing.Size(98, 23);
            this.butx2.TabIndex = 4;
            this.butx2.Text = "x^2";
            this.butx2.UseVisualStyleBackColor = true;
            this.butx2.Click += new System.EventHandler(this.butx2_Click);
            // 
            // butx3
            // 
            this.butx3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butx3.Location = new System.Drawing.Point(503, 255);
            this.butx3.Name = "butx3";
            this.butx3.Size = new System.Drawing.Size(98, 23);
            this.butx3.TabIndex = 5;
            this.butx3.Text = "x^3";
            this.butx3.UseVisualStyleBackColor = true;
            this.butx3.Click += new System.EventHandler(this.butx3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 317);
            this.Controls.Add(this.butx3);
            this.Controls.Add(this.butx2);
            this.Controls.Add(this.buexp);
            this.Controls.Add(this.butsin);
            this.Controls.Add(this.butcos);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Function";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button butcos;
        private System.Windows.Forms.Button butsin;
        private System.Windows.Forms.Button buexp;
        private System.Windows.Forms.Button butx2;
        private System.Windows.Forms.Button butx3;




    }
}

