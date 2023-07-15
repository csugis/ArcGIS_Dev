namespace Tester
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.coneVolume = new System.Windows.Forms.TextBox();
            this.coneArea = new System.Windows.Forms.TextBox();
            this.cylinderVolume = new System.Windows.Forms.TextBox();
            this.cylinderArea = new System.Windows.Forms.TextBox();
            this.sphereVolume = new System.Windows.Forms.TextBox();
            this.sphereArea = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.TextBox();
            this.radius = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.clrButton1 = new CtrlLib.ClrButton();
            this.ctrlCalculate1 = new CtrlLib.CtrlCalculate();
            this.SuspendLayout();
            // 
            // coneVolume
            // 
            this.coneVolume.Location = new System.Drawing.Point(257, 201);
            this.coneVolume.Name = "coneVolume";
            this.coneVolume.Size = new System.Drawing.Size(100, 21);
            this.coneVolume.TabIndex = 79;
            // 
            // coneArea
            // 
            this.coneArea.Location = new System.Drawing.Point(113, 201);
            this.coneArea.Name = "coneArea";
            this.coneArea.Size = new System.Drawing.Size(100, 21);
            this.coneArea.TabIndex = 78;
            // 
            // cylinderVolume
            // 
            this.cylinderVolume.Location = new System.Drawing.Point(257, 151);
            this.cylinderVolume.Name = "cylinderVolume";
            this.cylinderVolume.Size = new System.Drawing.Size(100, 21);
            this.cylinderVolume.TabIndex = 77;
            // 
            // cylinderArea
            // 
            this.cylinderArea.Location = new System.Drawing.Point(113, 151);
            this.cylinderArea.Name = "cylinderArea";
            this.cylinderArea.Size = new System.Drawing.Size(100, 21);
            this.cylinderArea.TabIndex = 76;
            // 
            // sphereVolume
            // 
            this.sphereVolume.Location = new System.Drawing.Point(257, 96);
            this.sphereVolume.Name = "sphereVolume";
            this.sphereVolume.Size = new System.Drawing.Size(100, 21);
            this.sphereVolume.TabIndex = 75;
            // 
            // sphereArea
            // 
            this.sphereArea.Location = new System.Drawing.Point(113, 96);
            this.sphereArea.Name = "sphereArea";
            this.sphereArea.Size = new System.Drawing.Size(100, 21);
            this.sphereArea.TabIndex = 74;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 73;
            this.label7.Text = "Cone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 72;
            this.label6.Text = "Cylinder";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 71;
            this.label5.Text = "Sphere";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 70;
            this.label4.Text = "Volume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 69;
            this.label3.Text = "Area";
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(279, 17);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(100, 21);
            this.height.TabIndex = 68;
            // 
            // radius
            // 
            this.radius.Location = new System.Drawing.Point(85, 17);
            this.radius.Name = "radius";
            this.radius.Size = new System.Drawing.Size(100, 21);
            this.radius.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 66;
            this.label2.Text = "Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 65;
            this.label1.Text = "Radius";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 64;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clrButton1
            // 
            this.clrButton1.cuteColor1 = System.Drawing.Color.LightBlue;
            this.clrButton1.cuteColor2 = System.Drawing.Color.DarkRed;
            this.clrButton1.cuteTransparent1 = 50;
            this.clrButton1.cuteTransparent2 = 50;
            this.clrButton1.Location = new System.Drawing.Point(247, 250);
            this.clrButton1.Name = "clrButton1";
            this.clrButton1.Size = new System.Drawing.Size(75, 23);
            this.clrButton1.TabIndex = 80;
            this.clrButton1.Text = "clear";
            this.clrButton1.UseVisualStyleBackColor = true;
            this.clrButton1.Click += new System.EventHandler(this.clrButton1_Click);
            // 
            // ctrlCalculate1
            // 
            this.ctrlCalculate1.Location = new System.Drawing.Point(404, 0);
            this.ctrlCalculate1.Name = "ctrlCalculate1";
            this.ctrlCalculate1.Size = new System.Drawing.Size(379, 304);
            this.ctrlCalculate1.TabIndex = 81;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 302);
            this.Controls.Add(this.ctrlCalculate1);
            this.Controls.Add(this.clrButton1);
            this.Controls.Add(this.coneVolume);
            this.Controls.Add(this.coneArea);
            this.Controls.Add(this.cylinderVolume);
            this.Controls.Add(this.cylinderArea);
            this.Controls.Add(this.sphereVolume);
            this.Controls.Add(this.sphereArea);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.height);
            this.Controls.Add(this.radius);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox coneVolume;
        private System.Windows.Forms.TextBox coneArea;
        private System.Windows.Forms.TextBox cylinderVolume;
        private System.Windows.Forms.TextBox cylinderArea;
        private System.Windows.Forms.TextBox sphereVolume;
        private System.Windows.Forms.TextBox sphereArea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.TextBox radius;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private CtrlLib.ClrButton clrButton1;
        private CtrlLib.CtrlCalculate ctrlCalculate1;
    }
}

