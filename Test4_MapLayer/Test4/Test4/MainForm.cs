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
            //���axTOCControl1�ؼ��ĵ�ǰѡ����
            esriTOCControlItem type = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap basicMap = null;
            ILayer layer = null;
            object unk = null, data = null;
            axTOCControl1.GetSelectedItem(ref type, ref basicMap, ref layer, ref unk,
         ref data);
            //�統ǰѡ��������Ϊͼ���������Ҽ�
            if (type == esriTOCControlItem.esriTOCControlItemLayer
                && layer != null
                && e.button == 2)
            {
                //�洢��ǰѡ��ͼ��
                m_layerSelected = layer;
                //�����Ҽ��˵�
                contextMenuStrip1.Show(axTOCControl1, e.x, e.y);
            }

        }

        private void ����һ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lCnt = axMapControl1.LayerCount;
            for (int i = 0; i < lCnt; i++)
            {
                //�õ���ǰѡ��ͼ�㣬�Ҹò㲻����ײ�
                if (axMapControl1.get_Layer(i).Name == m_layerSelected.Name
        && i + 1 < lCnt)
                {
                    //����ǰѡ��ͼ�������ƶ�һ��
                    axMapControl1.MoveLayerTo(i, i + 1);
                    break;
                }
            }

        }

        private void ����һ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //���axMapControl1�е�ͼ�����
            int lCnt = axMapControl1.LayerCount;
            //ѭ��axMapControl1������ͼ��
            for (int i = 0; i < lCnt; i++)
            {
                //�õ���ǰѡ��ͼ�㣬�Ҹò㲻�����ϲ�
                if (axMapControl1.get_Layer(i).Name == m_layerSelected.Name
        && i - 1 >= 0)
                {
                    //����ǰѡ��ͼ�������ƶ�һ��
                    axMapControl1.MoveLayerTo(i, i - 1);
                    break;
                }
            }

        }

        private void ɾ��ͼ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int lCnt = axMapControl1.LayerCount;
            for (int i = 0; i < lCnt; i++)
            {
                //�õ���ǰѡ��ͼ��
                if (axMapControl1.get_Layer(i).Name == m_layerSelected.Name)
                {
                    //����ǰѡ��ͼ���axMapControl1��ɾ��
                    axMapControl1.DeleteLayer(i);
                    break;
                }
            }

        }

        private void ����ȾToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer pGeoFeatureLayer = m_layerSelected as
 IGeoFeatureLayer;
            //������ɫ����
            IRgbColor pRgbColor = new RgbColorClass();
            pRgbColor.Red = 0;
            pRgbColor.Green = 200;
            pRgbColor.Blue = 100;
            //����������
            ISymbol sym = null;
            switch (pGeoFeatureLayer.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    sym = new SimpleMarkerSymbolClass();
                    //�����״��ʽ����ɫ
                    ISimpleMarkerSymbol pMarkerSymbol = sym as ISimpleMarkerSymbol;
                    pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSSquare;
                    pMarkerSymbol.Color = pRgbColor;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    sym = new SimpleLineSymbolClass();
                    //������״��ʽ����ɫ
                    ISimpleLineSymbol pLineSymbol = sym as ISimpleLineSymbol;
                    pLineSymbol.Style = esriSimpleLineStyle.esriSLSDot;
                    pLineSymbol.Color = pRgbColor;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    sym = new SimpleFillSymbolClass();
                    //������״��ɫ
                    ISimpleFillSymbol pFillSymbol = sym as ISimpleFillSymbol;
                    pFillSymbol.Color = pRgbColor;
                    break;
                default:
                    return;
            }
            //��ʼ��ISimpleRenderer����
            ISimpleRenderer pSimpleRenderer;
            pSimpleRenderer = new SimpleRendererClass();
            pSimpleRenderer.Symbol = sym;
            //ʹͼ������ʾ���ַ���Ϊ��ѡ�ֶ�
            pSimpleRenderer.Label = "SimpleSymbol";
            pSimpleRenderer.Description = "Description";
            //����Ⱦ����������ͼ��
            pGeoFeatureLayer.Renderer = pSimpleRenderer as IFeatureRenderer;
            axMapControl1.ActiveView.Refresh();
            axTOCControl1.Update();

        }

        private void �ּ���ȾToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClassSymbol frmClassSymbol = new FrmClassSymbol(m_mapControl.Object, m_tocControl, m_layerSelected as IFeatureLayer);
            frmClassSymbol.Show();

        }
    }
}