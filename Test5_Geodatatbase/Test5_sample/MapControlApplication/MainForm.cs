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
using ESRI.ArcGIS.DataSourcesGDB;


namespace MapControlApplication
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
                statusBarXY.Text = Path.GetFileName(m_mapDocumentName);
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void connectSDEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //数据库工作空间工厂对象
            IWorkspaceFactory wsFactory = new SdeWorkspaceFactoryClass(); IPropertySet ps = new PropertySetClass(); //属性集
            ps.SetProperty("SERVER", "DESKTOP-0A280IH"); //服务器名称
            ps.SetProperty("INSTANCE", ""); //实例名
            ps.SetProperty("DATABASE", "sde"); //数据库名称
            ps.SetProperty("USER", "sa"); //用户名
            ps.SetProperty("PASSWORD", "123456789"); //密码
                                                     //打开SDE数据库连接工作空间
            IWorkspace ipWorkspace = wsFactory.Open(ps, 0);
            //获得工作空间下的所有要素数据集Datasets
            IEnumDataset eds = ipWorkspace.get_Datasets(
            esriDatasetType.esriDTFeatureDataset);
            //依次获取每个数据集Dataset
            IDataset ds = null;
            ds = eds.Next();
            while (ds != null)
            {
                if (ds is IFeatureDataset)
                {
                    //获取数据集的子集
                    IEnumDataset subs = ds.Subsets;
                    subs.Reset();
                    IDataset pds = subs.Next();
                    //对子集进行遍历
                    while (pds != null)
                    {
                        //判断是否是要素类
                        if (pds.Type == esriDatasetType.esriDTFeatureClass)
                        {
                            IFeatureClass fc = pds as IFeatureClass;
                            IFeatureLayer layer = new FeatureLayerClass();
                            layer.Name = fc.AliasName;
                            layer.FeatureClass = fc;
                            //将要素图层添加至地图窗口
                            axMapControl1.AddLayer(layer as ILayer);
                        }
                        pds = subs.Next();
                    }
                }
                ds = eds.Next();
            }
            //获取直接存储在工作空间下的所有要素类FeatureClasses
            eds = ipWorkspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
            //获取每个要素类FeatureClass
            IFeatureClass fcl = eds.Next() as IFeatureClass;
            while (fcl != null)
            {
                if (fcl is IFeatureClass)
                {
                    IFeatureLayer layer = new FeatureLayerClass();
                    layer.Name = fcl.AliasName;
                    layer.FeatureClass = fcl; //为图层指定要素类
                                              //将图层添加至地图窗口
                    axMapControl1.AddLayer(layer as ILayer);
                }
                fcl = eds.Next() as IFeatureClass;
            }
        }
    }
}