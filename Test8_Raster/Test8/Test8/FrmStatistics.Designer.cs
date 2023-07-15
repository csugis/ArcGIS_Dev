namespace Test8
{
    partial class FrmStatistics
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
            this.cbxAddRasterLayers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbxResult = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择图层：";
            // 
            // cbxAddRasterLayers
            // 
            this.cbxAddRasterLayers.FormattingEnabled = true;
            this.cbxAddRasterLayers.Location = new System.Drawing.Point(85, 13);
            this.cbxAddRasterLayers.Name = "cbxAddRasterLayers";
            this.cbxAddRasterLayers.Size = new System.Drawing.Size(121, 20);
            this.cbxAddRasterLayers.TabIndex = 1;
            this.cbxAddRasterLayers.SelectedIndexChanged += new System.EventHandler(this.cbxAddRasterLayers_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "统计结果：";
            // 
            // rtbxResult
            // 
            this.rtbxResult.Location = new System.Drawing.Point(17, 108);
            this.rtbxResult.Name = "rtbxResult";
            this.rtbxResult.ReadOnly = true;
            this.rtbxResult.Size = new System.Drawing.Size(213, 96);
            this.rtbxResult.TabIndex = 3;
            this.rtbxResult.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(32, 266);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(155, 266);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 312);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rtbxResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxAddRasterLayers);
            this.Controls.Add(this.label1);
            this.Name = "FrmStatistics";
            this.Text = "栅格数据集统计";
            this.Load += new System.EventHandler(this.FrmStatistics_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxAddRasterLayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbxResult;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
    }
}