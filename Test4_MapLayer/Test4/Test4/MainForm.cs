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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace Test4
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        private IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;
        private ILayer m_layerSelected = null;
        private ITOCControl m_tocControl = null;
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
            m_tocControl = (ITOCControl)axTOCControl1.Object;
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
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void axTOCControl1_OnMouseUp(object sender, ITOCControlEvents_OnMouseUpEvent e)
        {
            //获得axTOCControl1控件的当前选择项
            esriTOCControlItem type = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap basicMap = null;
            ILayer layer = null;
            object unk = null, data = null;
            axTOCControl1.GetSelectedItem(ref type, ref basicMap, ref layer, ref unk,
         ref data);
            //如当前选择项类型为图层对象，鼠标右键
            if (type == esriTOCControlItem.esriTOCControlItemLayer
                && layer != null
                && e.button == 2)
            {
                //存储当前选择图层
                m_layerSelected = layer;
                //弹出右键菜单
                contextMenuStrip1.Show(axTOCControl1, e.x, e.y);
            }

        }

        private void 向下一层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lCnt = axMapControl1.LayerCount;
            for (int i = 0; i < lCnt; i++)
            {
                //得到当前选择图层，且该层不是最底层
                if (axMapControl1.get_Layer(i).Name == m_layerSelected.Name
        && i + 1 < lCnt)
                {
                    //将当前选择图层向下移动一层
                    axMapControl1.MoveLayerTo(i, i + 1);
                    break;
                }
            }

        }

        private void 向上一层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得axMapControl1中的图层个数
            int lCnt = axMapControl1.LayerCount;
            //循环axMapControl1中所有图层
            for (int i = 0; i < lCnt; i++)
            {
                //得到当前选择图层，且该层不是最上层
                if (axMapControl1.get_Layer(i).Name == m_layerSelected.Name
        && i - 1 >= 0)
                {
                    //将当前选择图层向上移动一层
                    axMapControl1.MoveLayerTo(i, i - 1);
                    break;
                }
            }

        }

        private void 删除图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lCnt = axMapControl1.LayerCount;
            for (int i = 0; i < lCnt; i++)
            {
                //得到当前选择图层
                if (axMapControl1.get_Layer(i).Name == m_layerSelected.Name)
                {
                    //将当前选择图层从axMapControl1中删除
                    axMapControl1.DeleteLayer(i);
                    break;
                }
            }

        }

        private void 简单渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer pGeoFeatureLayer = m_layerSelected as
 IGeoFeatureLayer;
            //设置颜色属性
            IRgbColor pRgbColor = new RgbColorClass();
            pRgbColor.Red = 0;
            pRgbColor.Green = 200;
            pRgbColor.Blue = 100;
            //定义填充符号
            ISymbol sym = null;
            switch (pGeoFeatureLayer.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    sym = new SimpleMarkerSymbolClass();
                    //定义点状样式和颜色
                    ISimpleMarkerSymbol pMarkerSymbol = sym as ISimpleMarkerSymbol;
                    pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSSquare;
                    pMarkerSymbol.Color = pRgbColor;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    sym = new SimpleLineSymbolClass();
                    //定义线状样式和颜色
                    ISimpleLineSymbol pLineSymbol = sym as ISimpleLineSymbol;
                    pLineSymbol.Style = esriSimpleLineStyle.esriSLSDot;
                    pLineSymbol.Color = pRgbColor;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    sym = new SimpleFillSymbolClass();
                    //定义面状颜色
                    ISimpleFillSymbol pFillSymbol = sym as ISimpleFillSymbol;
                    pFillSymbol.Color = pRgbColor;
                    break;
                default:
                    return;
            }
            //初始化ISimpleRenderer对象
            ISimpleRenderer pSimpleRenderer;
            pSimpleRenderer = new SimpleRendererClass();
            pSimpleRenderer.Symbol = sym;
            //使图例中显示的字符串为所选字段
            pSimpleRenderer.Label = "SimpleSymbol";
            pSimpleRenderer.Description = "Description";
            //将渲染器赋给地理图层
            pGeoFeatureLayer.Renderer = pSimpleRenderer as IFeatureRenderer;
            axMapControl1.ActiveView.Refresh();
            axTOCControl1.Update();

        }

        private void 分级渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClassSymbol frmClassSymbol = new FrmClassSymbol(m_mapControl.Object, m_tocControl, m_layerSelected as IFeatureLayer);
            frmClassSymbol.Show();

        }
    }
}