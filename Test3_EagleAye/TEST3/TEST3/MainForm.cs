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
            //ΪTOCControl���û��ؼ�
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
            //ʹ����м�������Ч
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
            //��������ͼ��ӥ�۴���
            CopyAndOverwriteMap();

        }

        private void CopyAndOverwriteMap()
        {
            //�½����󿽱���
            IObjectCopy objCopy = new ObjectCopyClass();
            //�������ͼ����
            object fromMap = axMapControl1.Map;
            //���ӥ�۵�ͼ����
            object objMap = axMapControl2.Map;
            //������ͼ������ӥ�۵�ͼ
            objCopy.Overwrite(fromMap, ref objMap);
            //����ӥ�۵�ͼ��ΧΪ��ͼȫ�ַ�Χ
            axMapControl2.Extent = axMapControl2.FullExtent;
            //ˢ��ӥ�۴���
            axMapControl2.Refresh();
        }

        private void axMapControl1_OnFullExtentUpdated(object sender, IMapControlEvents2_OnFullExtentUpdatedEvent e)
        {
            //��������ͼ��ӥ�۴���
            CopyAndOverwriteMap();

        }

        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            //�½�һ������Ԫ�ض���
            IElement ele = new RectangleElementClass();
            //��������Ϊ����ͼ����ʾ��Χ
            ele.Geometry = axMapControl1.Extent;
            //�½�һ���������ʽ����
            IFillSymbol symbol = new SimpleFillSymbolClass();
            //�½�һ��RGB��ɫ����
            IRgbColor clr = new RgbColorClass();
            //���������ʽ�������ɫΪ��ɫ��͸��
            clr.NullColor = true;
            clr.Transparency = 0;
            symbol.Color = clr;
            //�½�һ������ʽ����
            ILineSymbol linSymbol = new SimpleLineSymbolClass();
            //���������ʽ����ı߿�Ϊ��ɫ
            IRgbColor linClr = new RgbColorClass();
            linClr.Red = 255;
            linSymbol.Color = linClr;
            symbol.Outline = linSymbol;
            //�������ʽ���������ƾ���Ԫ��
            ((IFillShapeElement)ele).Symbol = symbol;
            //ɾ��ӥ���е�����Ԫ��
            axMapControl2.ActiveView.GraphicsContainer.DeleteAllElements();
            //������Ԫ����ӵ�ӥ���У����ֲ�ˢ��
            axMapControl2.ActiveView.GraphicsContainer.AddElement(ele, 0);
            axMapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

        }

        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //ӥ���н������ƾ��ο�
            IEnvelope env = axMapControl2.TrackRectangle();
            //�����ο�����Ϊ����ͼ����ʾ��Χ��������ӥ��
            axMapControl1.Extent = env;
            axMapControl2.Refresh();

        }
    }
}