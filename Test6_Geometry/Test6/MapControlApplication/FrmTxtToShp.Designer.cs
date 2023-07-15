namespace MapControlApplication
{
    partial class FrmTxtToShp
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
            this.btnSave = new System.Windows.Forms.Button();
            this.TxtToPolygon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SavePath = new System.Windows.Forms.TextBox();
            this.TxtToPoint = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.TxtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(306, 77);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 23);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TxtToPolygon
            // 
            this.TxtToPolygon.Location = new System.Drawing.Point(216, 129);
            this.TxtToPolygon.Margin = new System.Windows.Forms.Padding(2);
            this.TxtToPolygon.Name = "TxtToPolygon";
            this.TxtToPolygon.Size = new System.Drawing.Size(117, 28);
            this.TxtToPolygon.TabIndex = 29;
            this.TxtToPolygon.Text = "TxtToPolygonShp";
            this.TxtToPolygon.UseVisualStyleBackColor = true;
            this.TxtToPolygon.Click += new System.EventHandler(this.TxtToPolygon_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "保存路径：";
            // 
            // SavePath
            // 
            this.SavePath.Location = new System.Drawing.Point(95, 79);
            this.SavePath.Margin = new System.Windows.Forms.Padding(2);
            this.SavePath.Name = "SavePath";
            this.SavePath.Size = new System.Drawing.Size(194, 21);
            this.SavePath.TabIndex = 27;
            // 
            // TxtToPoint
            // 
            this.TxtToPoint.Location = new System.Drawing.Point(68, 129);
            this.TxtToPoint.Margin = new System.Windows.Forms.Padding(2);
            this.TxtToPoint.Name = "TxtToPoint";
            this.TxtToPoint.Size = new System.Drawing.Size(98, 28);
            this.TxtToPoint.TabIndex = 26;
            this.TxtToPoint.Text = "TxtToPointShp";
            this.TxtToPoint.UseVisualStyleBackColor = true;
            this.TxtToPoint.Click += new System.EventHandler(this.TxtToPoint_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(306, 30);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(59, 21);
            this.btnOpen.TabIndex = 25;
            this.btnOpen.Text = "...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // TxtFile
            // 
            this.TxtFile.Location = new System.Drawing.Point(95, 30);
            this.TxtFile.Margin = new System.Windows.Forms.Padding(2);
            this.TxtFile.Name = "TxtFile";
            this.TxtFile.Size = new System.Drawing.Size(194, 21);
            this.TxtFile.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "文本文件：";
            // 
            // FrmTxtToShp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 183);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.TxtToPolygon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SavePath);
            this.Controls.Add(this.TxtToPoint);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.TxtFile);
            this.Controls.Add(this.label1);
            this.Name = "FrmTxtToShp";
            this.Text = "FrmTxtToShp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button TxtToPolygon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SavePath;
        private System.Windows.Forms.Button TxtToPoint;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox TxtFile;
        private System.Windows.Forms.Label label1;
    }
}