namespace MapControlApplication
{
    partial class FrmBufferGP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGPing = new System.Windows.Forms.Button();
            this.btnOutputLayer = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGPor = new System.Windows.Forms.Button();
            this.txtBufferDistance = new System.Windows.Forms.TextBox();
            this.selectLayer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGPing
            // 
            this.btnGPing.Location = new System.Drawing.Point(33, 150);
            this.btnGPing.Name = "btnGPing";
            this.btnGPing.Size = new System.Drawing.Size(79, 23);
            this.btnGPing.TabIndex = 49;
            this.btnGPing.Text = "BufferGPing";
            this.btnGPing.UseVisualStyleBackColor = true;
            this.btnGPing.Click += new System.EventHandler(this.btnGPor_Click);
            // 
            // btnOutputLayer
            // 
            this.btnOutputLayer.Location = new System.Drawing.Point(262, 99);
            this.btnOutputLayer.Name = "btnOutputLayer";
            this.btnOutputLayer.Size = new System.Drawing.Size(24, 21);
            this.btnOutputLayer.TabIndex = 48;
            this.btnOutputLayer.Text = ">";
            this.btnOutputLayer.UseVisualStyleBackColor = true;
            this.btnOutputLayer.Click += new System.EventHandler(this.btnOutputLayer_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(90, 99);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(161, 21);
            this.txtOutputPath.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "保存路径：";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(218, 150);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGPor
            // 
            this.btnGPor.Location = new System.Drawing.Point(131, 150);
            this.btnGPor.Name = "btnGPor";
            this.btnGPor.Size = new System.Drawing.Size(81, 23);
            this.btnGPor.TabIndex = 45;
            this.btnGPor.Text = "BufferGPor";
            this.btnGPor.UseVisualStyleBackColor = true;
            this.btnGPor.Click += new System.EventHandler(this.btnGPor_Click_1);
            // 
            // txtBufferDistance
            // 
            this.txtBufferDistance.Location = new System.Drawing.Point(90, 58);
            this.txtBufferDistance.Name = "txtBufferDistance";
            this.txtBufferDistance.Size = new System.Drawing.Size(161, 21);
            this.txtBufferDistance.TabIndex = 43;
            // 
            // selectLayer
            // 
            this.selectLayer.FormattingEnabled = true;
            this.selectLayer.Location = new System.Drawing.Point(90, 21);
            this.selectLayer.Name = "selectLayer";
            this.selectLayer.Size = new System.Drawing.Size(161, 20);
            this.selectLayer.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 39;
            this.label3.Text = "公里";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 40;
            this.label2.Text = "指定半径";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(30, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 12);
            this.Label1.TabIndex = 41;
            this.Label1.Text = "选择图层";
            // 
            // FrmBufferGP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 200);
            this.Controls.Add(this.btnGPing);
            this.Controls.Add(this.btnOutputLayer);
            this.Controls.Add(this.txtOutputPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGPor);
            this.Controls.Add(this.txtBufferDistance);
            this.Controls.Add(this.selectLayer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.Name = "FrmBufferGP";
            this.Text = "FrmBufferGP";
            this.Load += new System.EventHandler(this.FrmBufferGP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGPing;
        private System.Windows.Forms.Button btnOutputLayer;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGPor;
        private System.Windows.Forms.TextBox txtBufferDistance;
        internal System.Windows.Forms.ComboBox selectLayer;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label Label1;
    }
}