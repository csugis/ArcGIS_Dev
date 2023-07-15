namespace Test8
{
    partial class FrmCreatCoutour
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxAddRasterLayers = new System.Windows.Forms.ComboBox();
            this.tbxCoutourInterval = new System.Windows.Forms.TextBox();
            this.tbxBasicCoutour = new System.Windows.Forms.TextBox();
            this.tbxSavePath = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSetPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择栅格图层：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "等高线间隔：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "基本等高线：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "输出目录：";
            // 
            // cbxAddRasterLayers
            // 
            this.cbxAddRasterLayers.FormattingEnabled = true;
            this.cbxAddRasterLayers.Location = new System.Drawing.Point(109, 13);
            this.cbxAddRasterLayers.Name = "cbxAddRasterLayers";
            this.cbxAddRasterLayers.Size = new System.Drawing.Size(161, 20);
            this.cbxAddRasterLayers.TabIndex = 4;
            this.cbxAddRasterLayers.SelectedIndexChanged += new System.EventHandler(this.cbxAddRasterLayers_SelectedIndexChanged);
            // 
            // tbxCoutourInterval
            // 
            this.tbxCoutourInterval.Location = new System.Drawing.Point(109, 55);
            this.tbxCoutourInterval.Name = "tbxCoutourInterval";
            this.tbxCoutourInterval.Size = new System.Drawing.Size(161, 21);
            this.tbxCoutourInterval.TabIndex = 5;
            // 
            // tbxBasicCoutour
            // 
            this.tbxBasicCoutour.Location = new System.Drawing.Point(109, 108);
            this.tbxBasicCoutour.Name = "tbxBasicCoutour";
            this.tbxBasicCoutour.Size = new System.Drawing.Size(161, 21);
            this.tbxBasicCoutour.TabIndex = 6;
            // 
            // tbxSavePath
            // 
            this.tbxSavePath.Location = new System.Drawing.Point(109, 155);
            this.tbxSavePath.Name = "tbxSavePath";
            this.tbxSavePath.Size = new System.Drawing.Size(161, 21);
            this.tbxSavePath.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(39, 218);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(168, 218);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSetPath
            // 
            this.btnSetPath.Location = new System.Drawing.Point(277, 155);
            this.btnSetPath.Name = "btnSetPath";
            this.btnSetPath.Size = new System.Drawing.Size(36, 23);
            this.btnSetPath.TabIndex = 10;
            this.btnSetPath.Text = ">";
            this.btnSetPath.UseVisualStyleBackColor = true;
            this.btnSetPath.Click += new System.EventHandler(this.btnSetPath_Click);
            // 
            // FrmCreatCoutour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 264);
            this.Controls.Add(this.btnSetPath);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxSavePath);
            this.Controls.Add(this.tbxBasicCoutour);
            this.Controls.Add(this.tbxCoutourInterval);
            this.Controls.Add(this.cbxAddRasterLayers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCreatCoutour";
            this.Text = "提取等高线";
            this.Load += new System.EventHandler(this.FrmCreatCoutour_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxAddRasterLayers;
        private System.Windows.Forms.TextBox tbxCoutourInterval;
        private System.Windows.Forms.TextBox tbxBasicCoutour;
        private System.Windows.Forms.TextBox tbxSavePath;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSetPath;
    }
}