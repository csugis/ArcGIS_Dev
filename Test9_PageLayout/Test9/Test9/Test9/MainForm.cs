using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;

namespace Test9
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        private IMapControl3 m_mapControl = null;
        private IPageLayoutControl3 m_PageLayoutControl = null;
        private string m_mapDocumentName = string.Empty;
        #endregion

        #region class constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;
            m_PageLayoutControl = (IPageLayoutControl3)axPageLayoutControl1.Object;
            //disable the Save menu (since there is no document yet)
            menuSaveDoc.Enabled = false;
        }

        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open Document command
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;
            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
            }
            //拷贝主地图到页面布局窗口
            CopyAndOverwriteMap();
        }

        private void CopyAndOverwriteMap()
        {
            //新建对象拷贝类
            IObjectCopy objectCopy = new ObjectCopyClass();
            //获得主地图对象
            object fromMap = axMapControl1.Map;
            //获得页面布局地图对象
            object objMap = axPageLayoutControl1.ActiveView.FocusMap;
            //将主地图拷贝给页面布局地图
            objectCopy.Overwrite(fromMap, ref objMap);
            //设置页面布局地图范围为地图全局范围
            axPageLayoutControl1.Extent = axPageLayoutControl1.FullExtent;
            //刷新页面布局窗口
            axPageLayoutControl1.Refresh();
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void axMapControl1_OnFullExtentUpdated(object sender, IMapControlEvents2_OnFullExtentUpdatedEvent e)
        {
            //拷贝主地图到页面布局窗口
            CopyAndOverwriteMap();
        }

        private void axPageLayoutControl1_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.pageX.ToString("#######.##"), e.pageY.ToString("#######.##"), axPageLayoutControl1.ActiveView.FocusMap.MapUnits.ToString().Substring(4));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                axToolbarControl1.SetBuddyControl(axMapControl1.Object);
            }
            else
            {
                axToolbarControl1.SetBuddyControl(axPageLayoutControl1.Object);
            }
        }

        private void 创建地图网格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new CmdAddMapGrid();
            command.OnCreate(m_PageLayoutControl.Object);
            command.OnClick();
        }

        private void 删除地图网格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new CmdDelMapGrid();
            command.OnCreate(m_PageLayoutControl.Object);
            command.OnClick();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = "esriCarto." + toolStripComboBox1.ComboBox.Text;
            if (tabControl1.SelectedIndex == 1)
            {
                ICommand command = new ToolMapSurround(type);
                command.OnCreate(m_PageLayoutControl.Object);
                command.OnClick();
                axPageLayoutControl1.CurrentTool = command as ITool;
            }
        }

        private void 边框ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new CmdCreateBorder();
            command.OnCreate(m_PageLayoutControl.Object);
            command.OnClick();
        }

        private void 设置背景ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new CmdCreateBackG();
            command.OnCreate(m_PageLayoutControl.Object);
            command.OnClick();
        }

        private void 设置阴影ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICommand command = new CmdCreateShadow();
            command.OnCreate(m_PageLayoutControl.Object);
            command.OnClick();
        }
    }
}