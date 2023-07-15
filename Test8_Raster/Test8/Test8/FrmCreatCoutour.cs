using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;

namespace Test8
{
    public partial class FrmCreatCoutour : Form
    {
        private IHookHelper m_hookHelper = null;
        private IMap m_map = null;
        private IRasterLayer m_RasterLayer = null;
        private string m_ShapeFileName = null;
        private string m_Path = null;
        private string m_FileName = null;
        public FrmCreatCoutour(object hook)
        {
            InitializeComponent();
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;
            m_map = m_hookHelper.FocusMap;
        }

        private void FrmCreatCoutour_Load(object sender, EventArgs e)
        {
            CbxRasterLayersAddItems();
        }
        //将当前地图中所有栅格图层添加到组合框
        private void CbxRasterLayersAddItems()
        {
            if (GetLayers() == null)
                return;
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer pLayer = layers.Next();
            while (pLayer != null)
            {
                if (pLayer is IRasterLayer)
                {
                    cbxAddRasterLayers.Items.Add(pLayer.Name);
                }
                pLayer = layers.Next();
            }
        }
        //获取当前地图中的所有栅格图层
        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            //筛选栅格图层
            uid.Value = "{D02371C7-35F7-11D2-B1F2-00C04F8EDEFF}";
            // IRasterLayer
            if (m_map.LayerCount != 0)
            {
                IEnumLayer layers = m_map.get_Layers(uid, true);
                return layers;
            }
            return null;
        }

        private void cbxAddRasterLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果cbxAddRasterLayers控件中的图层不为空
            if (cbxAddRasterLayers.SelectedItem != null)
            {
                string strRasterSelected = cbxAddRasterLayers.SelectedItem.ToString();
                m_RasterLayer = GetRasterLayer(strRasterSelected);
            }
        }
        //通过名字来得到图层
        private IRasterLayer GetRasterLayer(string layerName)
        {
            if (GetLayers() == null)
                return null;
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer pLayer = null;
            while ((pLayer = layers.Next()) != null)
            {
                if (pLayer.Name == layerName)
                    return pLayer as IRasterLayer;
            }
            return null;
        }

        private void btnSetPath_Click(object sender, EventArgs e)
        {
            //调用系统“保存文件”窗体
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.shp)|*.shp";
            saveFileDialog.Title = "选择等值线图层存放位置";
            saveFileDialog.FilterIndex = 1;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取等值线图层的保存路径和等值线图层名称
                m_ShapeFileName = saveFileDialog.FileName;
                if (m_ShapeFileName == "")
                    return;
                //获取等值线图层的保存路径
                m_Path = System.IO.Path.GetDirectoryName(m_ShapeFileName);
                //获取等值线图层的名称
                m_FileName = System.IO.Path.GetFileName(m_ShapeFileName);
                //在tbxSavePath中显示路径和名称
                tbxSavePath.Text = m_ShapeFileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CreatCoutour(m_RasterLayer);
        }
        //提取等值线
        private void CreatCoutour(IRasterLayer rasterLayer)
        {
            IRasterLayer rLyr = rasterLayer;
            ISurfaceOp2 pSurfaceOp = default(ISurfaceOp2);
            pSurfaceOp = new RasterSurfaceOp() as ISurfaceOp2;
            IGeoDataset pRasterDataset = rLyr as IGeoDataset;
            IWorkspace pShpWS = default(IWorkspace);
            //打开Shapefile工作空间
            IWorkspaceFactory pShpWorkspaceFactory = new
        ShapefileWorkspaceFactory();
            pShpWS = pShpWorkspaceFactory.OpenFromFile(m_Path, 0);
            //提取等值线
            pSurfaceOp = new RasterSurfaceOp() as ISurfaceOp2;
            IRasterAnalysisEnvironment pRasterAEnv =
        (IRasterAnalysisEnvironment)pSurfaceOp;
            pRasterAEnv.OutWorkspace = pShpWS;
            IGeoDataset pOutput = default(IGeoDataset);
            IFeatureClass pFeatureClass = default(IFeatureClass);
            IFeatureLayer pFLayer = default(IFeatureLayer);
            string strInterval = tbxCoutourInterval.Text;
            string strBase = tbxBasicCoutour.Text;
            double douInterval = Convert.ToDouble(strInterval);
            double douBase = Convert.ToDouble(strBase);
            object tmpbase;
            tmpbase = (object)douBase;
            object tmpmy = 1;
            pOutput = pSurfaceOp.Contour(pRasterDataset, douInterval,
            ref tmpbase, ref tmpmy);
            pFeatureClass = (IFeatureClass)pOutput;
            //添加等值线到当前地图
            pFLayer = new FeatureLayer();
            pFLayer.FeatureClass = pFeatureClass;
            IGeoFeatureLayer pGeoFL = default(IGeoFeatureLayer);
            pGeoFL = (IGeoFeatureLayer)pFLayer;
            pGeoFL.DisplayAnnotation = false;
            pGeoFL.DisplayField = "CONTOUR";
            pGeoFL.Name = m_FileName;
            m_hookHelper.FocusMap.AddLayer(pGeoFL);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
