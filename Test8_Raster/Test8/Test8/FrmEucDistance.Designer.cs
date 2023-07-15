namespace Test8
{
    partial class FrmEucDistance
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxLayerAddItems = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSavePath = new System.Windows.Forms.TextBox();
            this.btnChooseSavePath = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择矢量图层：";
            // 
            // cbxLayerAddItems
            // 
            this.cbxLayerAddItems.FormattingEnabled = true;
            this.cbxLayerAddItems.Location = new System.Drawing.Point(120, 13);
            this.cbxLayerAddItems.Name = "cbxLayerAddItems";
            this.cbxLayerAddItems.Size = new System.Drawing.Size(121, 20);
            this.cbxLayerAddItems.TabIndex = 1;
            this.cbxLayerAddItems.SelectedIndexChanged += new System.EventHandler(this.cbxLayerAddItems_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "设定保存位置：";
            // 
            // tbxSavePath
            // 
            this.tbxSavePath.Location = new System.Drawing.Point(120, 54);
            this.tbxSavePath.Name = "tbxSavePath";
            this.tbxSavePath.Size = new System.Drawing.Size(121, 21);
            this.tbxSavePath.TabIndex = 3;
            // 
            // btnChooseSavePath
            // 
            this.btnChooseSavePath.Location = new System.Drawing.Point(248, 51);
            this.btnChooseSavePath.Name = "btnChooseSavePath";
            this.btnChooseSavePath.Size = new System.Drawing.Size(16, 23);
            this.btnChooseSavePath.TabIndex = 4;
            this.btnChooseSavePath.Text = ">";
            this.btnChooseSavePath.UseVisualStyleBackColor = true;
            this.btnChooseSavePath.Click += new System.EventHandler(this.btnChooseSavePath_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(31, 99);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(152, 98);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmEucDistance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 150);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnChooseSavePath);
            this.Controls.Add(this.tbxSavePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxLayerAddItems);
            this.Controls.Add(this.label1);
            this.Name = "FrmEucDistance";
            this.Text = "欧氏距离栅格";
            this.Load += new System.EventHandler(this.FrmEucDistance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxLayerAddItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSavePath;
        private System.Windows.Forms.Button btnChooseSavePath;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
    }
}