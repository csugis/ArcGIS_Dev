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
using ESRI.ArcGIS.Display;

namespace Test3
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        private IMapControl3 m_mapControl = null;
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

            //disable the Save menu (since there is no document yet)
            menuSaveDoc.Enabled = false;
            //为TOCControl设置伙伴控件
            axTOCControl1.SetBuddyControl(axMapControl1);

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
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void axMapControl1_OnMapReplaced_1(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //使鼠标中键滚轮无效
            axMapControl2.AutoMouseWheel = false;
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
                statusBarXY.Text = System.IO.Path.GetFileName (m_mapDocumentName);
            }
            //拷贝主地图到鹰眼窗口
            CopyAndOverwriteMap();

        }

        private void CopyAndOverwriteMap()
        {
            //新建对象拷贝类
            IObjectCopy objCopy = new ObjectCopyClass();
            //获得主地图对象
            object fromMap = axMapControl1.Map;
            //获得鹰眼地图对象
            object objMap = axMapControl2.Map;
            //将主地图拷贝给鹰眼地图
            objCopy.Overwrite(fromMap, ref objMap);
            //设置鹰眼地图范围为地图全局范围
            axMapControl2.Extent = axMapControl2.FullExtent;
            //刷新鹰眼窗口
            axMapControl2.Refresh();
        }

        private void axMapControl1_OnFullExtentUpdated(object sender, IMapControlEvents2_OnFullExtentUpdatedEvent e)
        {
            //拷贝主地图到鹰眼窗口
            CopyAndOverwriteMap();

        }

        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            //新建一个矩形元素对象
            IElement ele = new RectangleElementClass();
            //矩形设置为主地图的显示范围
            ele.Geometry = axMapControl1.Extent;
            //新建一个简单填充样式对象
            IFillSymbol symbol = new SimpleFillSymbolClass();
            //新建一个RGB颜色对象
            IRgbColor clr = new RgbColorClass();
            //设置填充样式对象的颜色为无色、透明
            clr.NullColor = true;
            clr.Transparency = 0;
            symbol.Color = clr;
            //新建一个线样式对象
            ILineSymbol linSymbol = new SimpleLineSymbolClass();
            //设置填充样式对象的边框为红色
            IRgbColor linClr = new RgbColorClass();
            linClr.Red = 255;
            linSymbol.Color = linClr;
            symbol.Outline = linSymbol;
            //用填充样式对象来绘制矩形元素
            ((IFillShapeElement)ele).Symbol = symbol;
            //删除鹰眼中的所有元素
            axMapControl2.ActiveView.GraphicsContainer.DeleteAllElements();
            //将矩形元素添加到鹰眼中，并局部刷新
            axMapControl2.ActiveView.GraphicsContainer.AddElement(ele, 0);
            axMapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

        }

        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //鹰眼中交互绘制矩形框
            IEnvelope env = axMapControl2.TrackRectangle();
            //将矩形框设置为主地图的显示范围，并更新鹰眼
            axMapControl1.Extent = env;
            axMapControl2.Refresh();

        }
    }
}