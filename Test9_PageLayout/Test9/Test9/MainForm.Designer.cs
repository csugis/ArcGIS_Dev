namespace Test9
{
    partial class MainForm
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
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageMap = new System.Windows.Forms.TabPage();
            this.TabPageLayout = new System.Windows.Forms.TabPage();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.页面布局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建地图网格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除地图网格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图框架属性ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置边框ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置阴影ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置背景ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图整饰对象ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabPageMap.SuspendLayout();
            this.TabPageLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.页面布局ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(859, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(39, 21);
            this.menuFile.Text = "File";
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(180, 22);
            this.menuNewDoc.Text = "New Document";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(180, 22);
            this.menuOpenDoc.Text = "Open Document...";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(180, 22);
            this.menuSaveDoc.Text = "SaveDocument";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(180, 22);
            this.menuSaveAs.Text = "Save As...";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(180, 22);
            this.menuExitApp.Text = "Exit";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(3, 3);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(654, 434);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnFullExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnFullExtentUpdatedEventHandler(this.axMapControl1_OnFullExtentUpdated);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 25);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(859, 28);
            this.axToolbarControl1.TabIndex = 3;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTOCControl1.Location = new System.Drawing.Point(3, 53);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(188, 466);
            this.axTOCControl1.TabIndex = 4;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(499, 21);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 488);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(3, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(856, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(57, 17);
            this.statusBarXY.Text = "Test 123";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPageMap);
            this.tabControl1.Controls.Add(this.TabPageLayout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(191, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 466);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // TabPageMap
            // 
            this.TabPageMap.Controls.Add(this.axMapControl1);
            this.TabPageMap.Location = new System.Drawing.Point(4, 22);
            this.TabPageMap.Name = "TabPageMap";
            this.TabPageMap.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageMap.Size = new System.Drawing.Size(660, 440);
            this.TabPageMap.TabIndex = 0;
            this.TabPageMap.Text = "TabPageMap";
            this.TabPageMap.UseVisualStyleBackColor = true;
            // 
            // TabPageLayout
            // 
            this.TabPageLayout.Controls.Add(this.axPageLayoutControl1);
            this.TabPageLayout.Location = new System.Drawing.Point(4, 22);
            this.TabPageLayout.Name = "TabPageLayout";
            this.TabPageLayout.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageLayout.Size = new System.Drawing.Size(660, 440);
            this.TabPageLayout.TabIndex = 1;
            this.TabPageLayout.Text = "TabPageLayout";
            this.TabPageLayout.UseVisualStyleBackColor = true;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axPageLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(654, 434);
            this.axPageLayoutControl1.TabIndex = 9;
            this.axPageLayoutControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseMoveEventHandler(this.axPageLayoutControl1_OnMouseMove);
            // 
            // 页面布局ToolStripMenuItem
            // 
            this.页面布局ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建地图网格ToolStripMenuItem,
            this.删除地图网格ToolStripMenuItem,
            this.地图框架属性ToolStripMenuItem,
            this.地图整饰对象ToolStripMenuItem});
            this.页面布局ToolStripMenuItem.Name = "页面布局ToolStripMenuItem";
            this.页面布局ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.页面布局ToolStripMenuItem.Text = "页面布局";
            // 
            // 创建地图网格ToolStripMenuItem
            // 
            this.创建地图网格ToolStripMenuItem.Name = "创建地图网格ToolStripMenuItem";
            this.创建地图网格ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.创建地图网格ToolStripMenuItem.Text = "创建地图网格";
            this.创建地图网格ToolStripMenuItem.Click += new System.EventHandler(this.创建地图网格ToolStripMenuItem_Click);
            // 
            // 删除地图网格ToolStripMenuItem
            // 
            this.删除地图网格ToolStripMenuItem.Name = "删除地图网格ToolStripMenuItem";
            this.删除地图网格ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除地图网格ToolStripMenuItem.Text = "删除地图网格";
            this.删除地图网格ToolStripMenuItem.Click += new System.EventHandler(this.删除地图网格ToolStripMenuItem_Click);
            // 
            // 地图框架属性ToolStripMenuItem
            // 
            this.地图框架属性ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置边框ToolStripMenuItem,
            this.设置阴影ToolStripMenuItem,
            this.设置背景ToolStripMenuItem});
            this.地图框架属性ToolStripMenuItem.Name = "地图框架属性ToolStripMenuItem";
            this.地图框架属性ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.地图框架属性ToolStripMenuItem.Text = "地图框架属性";
            // 
            // 设置边框ToolStripMenuItem
            // 
            this.设置边框ToolStripMenuItem.Name = "设置边框ToolStripMenuItem";
            this.设置边框ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.设置边框ToolStripMenuItem.Text = "设置边框";
            this.设置边框ToolStripMenuItem.Click += new System.EventHandler(this.设置边框ToolStripMenuItem_Click);
            // 
            // 设置阴影ToolStripMenuItem
            // 
            this.设置阴影ToolStripMenuItem.Name = "设置阴影ToolStripMenuItem";
            this.设置阴影ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.设置阴影ToolStripMenuItem.Text = "设置阴影";
            this.设置阴影ToolStripMenuItem.Click += new System.EventHandler(this.设置阴影ToolStripMenuItem_Click);
            // 
            // 设置背景ToolStripMenuItem
            // 
            this.设置背景ToolStripMenuItem.Name = "设置背景ToolStripMenuItem";
            this.设置背景ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.设置背景ToolStripMenuItem.Text = "设置背景";
            this.设置背景ToolStripMenuItem.Click += new System.EventHandler(this.设置背景ToolStripMenuItem_Click);
            // 
            // 地图整饰对象ToolStripMenuItem
            // 
            this.地图整饰对象ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.地图整饰对象ToolStripMenuItem.Name = "地图整饰对象ToolStripMenuItem";
            this.地图整饰对象ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.地图整饰对象ToolStripMenuItem.Text = "地图整饰对象";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Legend",
            "MarkerNorthArrow",
            "ScaleLine",
            "ScaleText"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 541);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "ArcEngine Controls Application";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabPageMap.ResumeLayout(false);
            this.TabPageLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPageMap;
        private System.Windows.Forms.TabPage TabPageLayout;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.ToolStripMenuItem 页面布局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建地图网格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除地图网格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图框架属性ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置边框ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置阴影ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置背景ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图整饰对象ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
    }
}

