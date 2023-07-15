namespace MapControlApplication
{
    partial class FrmSelectAndBuf
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
            this.saveLayer = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtBufferDistance = new System.Windows.Forms.TextBox();
            this.selectLayer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveLayer
            // 
            this.saveLayer.FormattingEnabled = true;
            this.saveLayer.Location = new System.Drawing.Point(87, 94);
            this.saveLayer.Name = "saveLayer";
            this.saveLayer.Size = new System.Drawing.Size(161, 20);
            this.saveLayer.TabIndex = 57;
            this.saveLayer.SelectedIndexChanged += new System.EventHandler(this.saveLayer_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(59, 141);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 56;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 55;
            this.label4.Text = "保存图层";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(173, 141);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 54;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtBufferDistance
            // 
            this.txtBufferDistance.Location = new System.Drawing.Point(87, 49);
            this.txtBufferDistance.Name = "txtBufferDistance";
            this.txtBufferDistance.Size = new System.Drawing.Size(161, 21);
            this.txtBufferDistance.TabIndex = 53;
            // 
            // selectLayer
            // 
            this.selectLayer.FormattingEnabled = true;
            this.selectLayer.Location = new System.Drawing.Point(87, 12);
            this.selectLayer.Name = "selectLayer";
            this.selectLayer.Size = new System.Drawing.Size(161, 20);
            this.selectLayer.TabIndex = 52;
            this.selectLayer.SelectedIndexChanged += new System.EventHandler(this.selectLayer_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 50;
            this.label2.Text = "指定半径";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(27, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 12);
            this.Label1.TabIndex = 51;
            this.Label1.Text = "选择图层";
            // 
            // FrmSelectAndBuf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 189);
            this.Controls.Add(this.saveLayer);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtBufferDistance);
            this.Controls.Add(this.selectLayer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.Name = "FrmSelectAndBuf";
            this.Text = "FrmSelectAndBuf";
            this.Load += new System.EventHandler(this.FrmSelectAndBuf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox saveLayer;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtBufferDistance;
        internal System.Windows.Forms.ComboBox selectLayer;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label Label1;
    }
}