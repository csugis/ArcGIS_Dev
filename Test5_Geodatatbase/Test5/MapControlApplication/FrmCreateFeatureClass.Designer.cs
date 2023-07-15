namespace MapControlApplication
{
    partial class FrmCreateFeatureClass
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rPoint = new System.Windows.Forms.RadioButton();
            this.rLine = new System.Windows.Forms.RadioButton();
            this.rPolygon = new System.Windows.Forms.RadioButton();
            this.OK = new System.Windows.Forms.Button();
            this.textBoxDataset = new System.Windows.Forms.TextBox();
            this.textBoxfeatureCls = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "要素类名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "要素数据集名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rPoint);
            this.groupBox1.Controls.Add(this.rLine);
            this.groupBox1.Controls.Add(this.rPolygon);
            this.groupBox1.Location = new System.Drawing.Point(34, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 63);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "几何类型";
            // 
            // rPoint
            // 
            this.rPoint.AutoSize = true;
            this.rPoint.Checked = true;
            this.rPoint.Location = new System.Drawing.Point(17, 32);
            this.rPoint.Name = "rPoint";
            this.rPoint.Size = new System.Drawing.Size(53, 16);
            this.rPoint.TabIndex = 11;
            this.rPoint.TabStop = true;
            this.rPoint.Text = "Point";
            this.rPoint.UseVisualStyleBackColor = true;
            // 
            // rLine
            // 
            this.rLine.AutoSize = true;
            this.rLine.Location = new System.Drawing.Point(88, 32);
            this.rLine.Name = "rLine";
            this.rLine.Size = new System.Drawing.Size(47, 16);
            this.rLine.TabIndex = 12;
            this.rLine.TabStop = true;
            this.rLine.Text = "Line";
            this.rLine.UseVisualStyleBackColor = true;
            // 
            // rPolygon
            // 
            this.rPolygon.AutoSize = true;
            this.rPolygon.Location = new System.Drawing.Point(155, 32);
            this.rPolygon.Name = "rPolygon";
            this.rPolygon.Size = new System.Drawing.Size(65, 16);
            this.rPolygon.TabIndex = 13;
            this.rPolygon.TabStop = true;
            this.rPolygon.Text = "Polygon";
            this.rPolygon.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(94, 172);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 31;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // textBoxDataset
            // 
            this.textBoxDataset.Location = new System.Drawing.Point(34, 136);
            this.textBoxDataset.Name = "textBoxDataset";
            this.textBoxDataset.Size = new System.Drawing.Size(101, 21);
            this.textBoxDataset.TabIndex = 34;
            // 
            // textBoxfeatureCls
            // 
            this.textBoxfeatureCls.Location = new System.Drawing.Point(160, 136);
            this.textBoxfeatureCls.Name = "textBoxfeatureCls";
            this.textBoxfeatureCls.Size = new System.Drawing.Size(100, 21);
            this.textBoxfeatureCls.TabIndex = 36;
            // 
            // FrmCreateFeatureClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 214);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.textBoxDataset);
            this.Controls.Add(this.textBoxfeatureCls);
            this.Name = "FrmCreateFeatureClass";
            this.Text = "FrmCreateFeatureClass";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rPoint;
        private System.Windows.Forms.RadioButton rLine;
        private System.Windows.Forms.RadioButton rPolygon;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TextBox textBoxDataset;
        private System.Windows.Forms.TextBox textBoxfeatureCls;
    }
}