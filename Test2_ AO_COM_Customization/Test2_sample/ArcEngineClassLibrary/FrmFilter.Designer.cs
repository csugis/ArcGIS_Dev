namespace ArcEngineClassLibrary
{
    partial class FrmFilter
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
            this.buttonGetValue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChar = new System.Windows.Forms.Button();
            this.checkBoxGetUniqueValue = new System.Windows.Forms.CheckBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.checkBoxShowVectorOnly = new System.Windows.Forms.CheckBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxWhereClause = new System.Windows.Forms.TextBox();
            this.labelDescription2 = new System.Windows.Forms.Label();
            this.labelDescription3 = new System.Windows.Forms.Label();
            this.labelDescription1 = new System.Windows.Forms.Label();
            this.buttonChars = new System.Windows.Forms.Button();
            this.buttonIs = new System.Windows.Forms.Button();
            this.buttonNot = new System.Windows.Forms.Button();
            this.buttonBrace = new System.Windows.Forms.Button();
            this.buttonOr = new System.Windows.Forms.Button();
            this.buttonBig = new System.Windows.Forms.Button();
            this.buttonBigEqual = new System.Windows.Forms.Button();
            this.buttonSmallEqual = new System.Windows.Forms.Button();
            this.buttonAnd = new System.Windows.Forms.Button();
            this.buttonSmall = new System.Windows.Forms.Button();
            this.buttonNotEqual = new System.Windows.Forms.Button();
            this.buttonLike = new System.Windows.Forms.Button();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.listBoxValues = new System.Windows.Forms.ListBox();
            this.labelValues = new System.Windows.Forms.Label();
            this.listBoxFields = new System.Windows.Forms.ListBox();
            this.Fields = new System.Windows.Forms.Label();
            this.comboBoxLayers = new System.Windows.Forms.ComboBox();
            this.LabelLayers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonGetValue
            // 
            this.buttonGetValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGetValue.Location = new System.Drawing.Point(196, 210);
            this.buttonGetValue.Name = "buttonGetValue";
            this.buttonGetValue.Size = new System.Drawing.Size(90, 23);
            this.buttonGetValue.TabIndex = 172;
            this.buttonGetValue.Text = "获得属性值";
            this.buttonGetValue.UseVisualStyleBackColor = true;
            this.buttonGetValue.Click += new System.EventHandler(this.buttonGetValue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 171;
            // 
            // buttonChar
            // 
            this.buttonChar.Location = new System.Drawing.Point(169, 181);
            this.buttonChar.Name = "buttonChar";
            this.buttonChar.Size = new System.Drawing.Size(21, 23);
            this.buttonChar.TabIndex = 170;
            this.buttonChar.Text = "_";
            this.buttonChar.UseVisualStyleBackColor = true;
            // 
            // checkBoxGetUniqueValue
            // 
            this.checkBoxGetUniqueValue.AutoSize = true;
            this.checkBoxGetUniqueValue.Location = new System.Drawing.Point(294, 249);
            this.checkBoxGetUniqueValue.Name = "checkBoxGetUniqueValue";
            this.checkBoxGetUniqueValue.Size = new System.Drawing.Size(120, 16);
            this.checkBoxGetUniqueValue.TabIndex = 169;
            this.checkBoxGetUniqueValue.Text = "去掉重复的属性值";
            this.checkBoxGetUniqueValue.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            this.buttonApply.Enabled = false;
            this.buttonApply.Location = new System.Drawing.Point(162, 364);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 168;
            this.buttonApply.Text = "应用";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // checkBoxShowVectorOnly
            // 
            this.checkBoxShowVectorOnly.AutoSize = true;
            this.checkBoxShowVectorOnly.Enabled = false;
            this.checkBoxShowVectorOnly.Location = new System.Drawing.Point(85, 43);
            this.checkBoxShowVectorOnly.Name = "checkBoxShowVectorOnly";
            this.checkBoxShowVectorOnly.Size = new System.Drawing.Size(108, 16);
            this.checkBoxShowVectorOnly.TabIndex = 167;
            this.checkBoxShowVectorOnly.Text = "只显示矢量图层";
            this.checkBoxShowVectorOnly.UseVisualStyleBackColor = true;
            this.checkBoxShowVectorOnly.CheckedChanged += new System.EventHandler(this.checkBoxShowVectorOnly_CheckedChanged);
            // 
            // buttonClear
            // 
            this.buttonClear.Enabled = false;
            this.buttonClear.Location = new System.Drawing.Point(22, 364);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 166;
            this.buttonClear.Text = "清空";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(328, 364);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 165;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(245, 364);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 164;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxWhereClause
            // 
            this.textBoxWhereClause.Location = new System.Drawing.Point(24, 298);
            this.textBoxWhereClause.Multiline = true;
            this.textBoxWhereClause.Name = "textBoxWhereClause";
            this.textBoxWhereClause.Size = new System.Drawing.Size(381, 55);
            this.textBoxWhereClause.TabIndex = 163;
            // 
            // labelDescription2
            // 
            this.labelDescription2.AutoSize = true;
            this.labelDescription2.Location = new System.Drawing.Point(115, 283);
            this.labelDescription2.Name = "labelDescription2";
            this.labelDescription2.Size = new System.Drawing.Size(0, 12);
            this.labelDescription2.TabIndex = 162;
            // 
            // labelDescription3
            // 
            this.labelDescription3.AutoSize = true;
            this.labelDescription3.Location = new System.Drawing.Point(171, 283);
            this.labelDescription3.Name = "labelDescription3";
            this.labelDescription3.Size = new System.Drawing.Size(35, 12);
            this.labelDescription3.TabIndex = 161;
            this.labelDescription3.Text = "Where";
            // 
            // labelDescription1
            // 
            this.labelDescription1.AutoSize = true;
            this.labelDescription1.Location = new System.Drawing.Point(24, 283);
            this.labelDescription1.Name = "labelDescription1";
            this.labelDescription1.Size = new System.Drawing.Size(89, 12);
            this.labelDescription1.TabIndex = 160;
            this.labelDescription1.Text = "Select * From ";
            // 
            // buttonChars
            // 
            this.buttonChars.Location = new System.Drawing.Point(147, 181);
            this.buttonChars.Name = "buttonChars";
            this.buttonChars.Size = new System.Drawing.Size(21, 23);
            this.buttonChars.TabIndex = 159;
            this.buttonChars.Text = "%";
            this.buttonChars.UseVisualStyleBackColor = true;
            // 
            // buttonIs
            // 
            this.buttonIs.Location = new System.Drawing.Point(147, 210);
            this.buttonIs.Name = "buttonIs";
            this.buttonIs.Size = new System.Drawing.Size(43, 23);
            this.buttonIs.TabIndex = 158;
            this.buttonIs.Text = "Is";
            this.buttonIs.UseVisualStyleBackColor = true;
            // 
            // buttonNot
            // 
            this.buttonNot.Location = new System.Drawing.Point(245, 181);
            this.buttonNot.Name = "buttonNot";
            this.buttonNot.Size = new System.Drawing.Size(43, 23);
            this.buttonNot.TabIndex = 157;
            this.buttonNot.Text = "Not";
            this.buttonNot.UseVisualStyleBackColor = true;
            // 
            // buttonBrace
            // 
            this.buttonBrace.Location = new System.Drawing.Point(196, 181);
            this.buttonBrace.Name = "buttonBrace";
            this.buttonBrace.Size = new System.Drawing.Size(43, 23);
            this.buttonBrace.TabIndex = 156;
            this.buttonBrace.Text = "( )";
            this.buttonBrace.UseVisualStyleBackColor = true;
            // 
            // buttonOr
            // 
            this.buttonOr.Location = new System.Drawing.Point(245, 152);
            this.buttonOr.Name = "buttonOr";
            this.buttonOr.Size = new System.Drawing.Size(43, 23);
            this.buttonOr.TabIndex = 155;
            this.buttonOr.Text = "Or";
            this.buttonOr.UseVisualStyleBackColor = true;
            // 
            // buttonBig
            // 
            this.buttonBig.Location = new System.Drawing.Point(147, 123);
            this.buttonBig.Name = "buttonBig";
            this.buttonBig.Size = new System.Drawing.Size(43, 23);
            this.buttonBig.TabIndex = 154;
            this.buttonBig.Text = ">";
            this.buttonBig.UseVisualStyleBackColor = true;
            this.buttonBig.Click += new System.EventHandler(this.buttonBig_Click);
            // 
            // buttonBigEqual
            // 
            this.buttonBigEqual.Location = new System.Drawing.Point(196, 123);
            this.buttonBigEqual.Name = "buttonBigEqual";
            this.buttonBigEqual.Size = new System.Drawing.Size(43, 23);
            this.buttonBigEqual.TabIndex = 153;
            this.buttonBigEqual.Text = "> =";
            this.buttonBigEqual.UseVisualStyleBackColor = true;
            // 
            // buttonSmallEqual
            // 
            this.buttonSmallEqual.Location = new System.Drawing.Point(196, 152);
            this.buttonSmallEqual.Name = "buttonSmallEqual";
            this.buttonSmallEqual.Size = new System.Drawing.Size(43, 23);
            this.buttonSmallEqual.TabIndex = 152;
            this.buttonSmallEqual.Text = "< =";
            this.buttonSmallEqual.UseVisualStyleBackColor = true;
            // 
            // buttonAnd
            // 
            this.buttonAnd.Location = new System.Drawing.Point(245, 123);
            this.buttonAnd.Name = "buttonAnd";
            this.buttonAnd.Size = new System.Drawing.Size(43, 23);
            this.buttonAnd.TabIndex = 151;
            this.buttonAnd.Text = "And";
            this.buttonAnd.UseVisualStyleBackColor = true;
            // 
            // buttonSmall
            // 
            this.buttonSmall.Location = new System.Drawing.Point(147, 152);
            this.buttonSmall.Name = "buttonSmall";
            this.buttonSmall.Size = new System.Drawing.Size(43, 23);
            this.buttonSmall.TabIndex = 150;
            this.buttonSmall.Text = "<";
            this.buttonSmall.UseVisualStyleBackColor = true;
            // 
            // buttonNotEqual
            // 
            this.buttonNotEqual.Location = new System.Drawing.Point(196, 94);
            this.buttonNotEqual.Name = "buttonNotEqual";
            this.buttonNotEqual.Size = new System.Drawing.Size(43, 23);
            this.buttonNotEqual.TabIndex = 149;
            this.buttonNotEqual.Text = "< >";
            this.buttonNotEqual.UseVisualStyleBackColor = true;
            // 
            // buttonLike
            // 
            this.buttonLike.Location = new System.Drawing.Point(245, 94);
            this.buttonLike.Name = "buttonLike";
            this.buttonLike.Size = new System.Drawing.Size(43, 23);
            this.buttonLike.TabIndex = 148;
            this.buttonLike.Text = "Like";
            this.buttonLike.UseVisualStyleBackColor = true;
            // 
            // buttonEqual
            // 
            this.buttonEqual.Location = new System.Drawing.Point(147, 94);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(43, 23);
            this.buttonEqual.TabIndex = 147;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = true;
            this.buttonEqual.Click += new System.EventHandler(this.buttonEqual_Click);
            // 
            // listBoxValues
            // 
            this.listBoxValues.FormattingEnabled = true;
            this.listBoxValues.HorizontalScrollbar = true;
            this.listBoxValues.ItemHeight = 12;
            this.listBoxValues.Location = new System.Drawing.Point(294, 94);
            this.listBoxValues.Name = "listBoxValues";
            this.listBoxValues.ScrollAlwaysVisible = true;
            this.listBoxValues.Size = new System.Drawing.Size(113, 148);
            this.listBoxValues.TabIndex = 146;
            this.listBoxValues.SelectedIndexChanged += new System.EventHandler(this.listBoxValues_SelectedIndexChanged);
            this.listBoxValues.DoubleClick += new System.EventHandler(this.listBoxValues_DoubleClick);
            // 
            // labelValues
            // 
            this.labelValues.AutoSize = true;
            this.labelValues.Location = new System.Drawing.Point(287, 79);
            this.labelValues.Name = "labelValues";
            this.labelValues.Size = new System.Drawing.Size(53, 12);
            this.labelValues.TabIndex = 145;
            this.labelValues.Text = " 属性值:";
            // 
            // listBoxFields
            // 
            this.listBoxFields.FormattingEnabled = true;
            this.listBoxFields.HorizontalScrollbar = true;
            this.listBoxFields.ItemHeight = 12;
            this.listBoxFields.Location = new System.Drawing.Point(24, 94);
            this.listBoxFields.Name = "listBoxFields";
            this.listBoxFields.ScrollAlwaysVisible = true;
            this.listBoxFields.Size = new System.Drawing.Size(117, 172);
            this.listBoxFields.TabIndex = 144;
            this.listBoxFields.DoubleClick += new System.EventHandler(this.listBoxFields_DoubleClick);
            // 
            // Fields
            // 
            this.Fields.AutoSize = true;
            this.Fields.Location = new System.Drawing.Point(22, 79);
            this.Fields.Name = "Fields";
            this.Fields.Size = new System.Drawing.Size(59, 12);
            this.Fields.TabIndex = 143;
            this.Fields.Text = "属性字段:";
            // 
            // comboBoxLayers
            // 
            this.comboBoxLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLayers.Enabled = false;
            this.comboBoxLayers.FormattingEnabled = true;
            this.comboBoxLayers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxLayers.Location = new System.Drawing.Point(85, 15);
            this.comboBoxLayers.Name = "comboBoxLayers";
            this.comboBoxLayers.Size = new System.Drawing.Size(318, 20);
            this.comboBoxLayers.TabIndex = 142;
            this.comboBoxLayers.SelectedIndexChanged += new System.EventHandler(this.comboBoxLayers_SelectedIndexChanged);
            // 
            // LabelLayers
            // 
            this.LabelLayers.AutoSize = true;
            this.LabelLayers.Location = new System.Drawing.Point(20, 18);
            this.LabelLayers.Name = "LabelLayers";
            this.LabelLayers.Size = new System.Drawing.Size(59, 12);
            this.LabelLayers.TabIndex = 141;
            this.LabelLayers.Text = "图层名称:";
            // 
            // FrmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 398);
            this.Controls.Add(this.buttonGetValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonChar);
            this.Controls.Add(this.checkBoxGetUniqueValue);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.checkBoxShowVectorOnly);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxWhereClause);
            this.Controls.Add(this.labelDescription2);
            this.Controls.Add(this.labelDescription3);
            this.Controls.Add(this.labelDescription1);
            this.Controls.Add(this.buttonChars);
            this.Controls.Add(this.buttonIs);
            this.Controls.Add(this.buttonNot);
            this.Controls.Add(this.buttonBrace);
            this.Controls.Add(this.buttonOr);
            this.Controls.Add(this.buttonBig);
            this.Controls.Add(this.buttonBigEqual);
            this.Controls.Add(this.buttonSmallEqual);
            this.Controls.Add(this.buttonAnd);
            this.Controls.Add(this.buttonSmall);
            this.Controls.Add(this.buttonNotEqual);
            this.Controls.Add(this.buttonLike);
            this.Controls.Add(this.buttonEqual);
            this.Controls.Add(this.listBoxValues);
            this.Controls.Add(this.labelValues);
            this.Controls.Add(this.listBoxFields);
            this.Controls.Add(this.Fields);
            this.Controls.Add(this.comboBoxLayers);
            this.Controls.Add(this.LabelLayers);
            this.Name = "FrmFilter";
            this.Text = "FrmFilter";
            this.Load += new System.EventHandler(this.FrmFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChar;
        private System.Windows.Forms.CheckBox checkBoxGetUniqueValue;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.CheckBox checkBoxShowVectorOnly;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxWhereClause;
        private System.Windows.Forms.Label labelDescription2;
        private System.Windows.Forms.Label labelDescription3;
        private System.Windows.Forms.Label labelDescription1;
        private System.Windows.Forms.Button buttonChars;
        private System.Windows.Forms.Button buttonIs;
        private System.Windows.Forms.Button buttonNot;
        private System.Windows.Forms.Button buttonBrace;
        private System.Windows.Forms.Button buttonOr;
        private System.Windows.Forms.Button buttonBig;
        private System.Windows.Forms.Button buttonBigEqual;
        private System.Windows.Forms.Button buttonSmallEqual;
        private System.Windows.Forms.Button buttonAnd;
        private System.Windows.Forms.Button buttonSmall;
        private System.Windows.Forms.Button buttonNotEqual;
        private System.Windows.Forms.Button buttonLike;
        private System.Windows.Forms.Button buttonEqual;
        private System.Windows.Forms.ListBox listBoxValues;
        private System.Windows.Forms.Label labelValues;
        private System.Windows.Forms.ListBox listBoxFields;
        private System.Windows.Forms.Label Fields;
        private System.Windows.Forms.ComboBox comboBoxLayers;
        private System.Windows.Forms.Label LabelLayers;
    }
}