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
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.SpatialAnalystTools;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DataSourcesRaster;

namespace Test8
{
    public partial class FrmEucDistance : Form
    {
        private IHookHelper m_hookHelper = null;
        private IMap m_map = null;
        private IFeatureLayer m_FeatureLayer = null;
        private string m_RasterFileName = null;
        private string m_Path = null;
        private string m_FileName = null;
        public FrmEucDistance(object hook)
        {
            InitializeComponent();
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;
            m_map = m_hookHelper.FocusMap;
        }

        private void FrmEucDistance_Load(object sender, EventArgs e)
        {
            CbxFeatureLayersAddItems();
        }
        private void CbxFeatureLayersAddItems()
        {
            if (GetLayers() == null)
                return;
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer pLayer = layers.Next();
            while (pLayer != null)
            {
                if (pLayer is IFeatureLayer)
                {
                    cbxLayerAddItems.Items.Add(pLayer.Name);
                }
                pLayer = layers.Next();
            }
        }
        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            //筛选矢量图层
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";// IFeatureLayer
            if (m_map.LayerCount != 0)
            {
                IEnumLayer layers = m_map.get_Layers(uid, true);
                return layers;
            }
            return null;
        }

        private void btnChooseSavePath_Click(object sender, EventArgs e)
        {
            //调用系统“保存文件”窗体
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.tif)|*.tif";
            saveFileDialog.Title = "选择欧式距离场存放位置";
            saveFileDialog.FilterIndex = 1;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取栅格数据的保存路径和栅格数据名称
                m_RasterFileName = saveFileDialog.FileName;
                if (m_RasterFileName == "")
                    return;
                //获取栅格数据的保存路径
                m_Path = System.IO.Path.GetDirectoryName(m_RasterFileName);
                //获取栅格数据的名称
                m_FileName = System.IO.Path.GetFileName(m_RasterFileName);
                //在tbxSavePath中显示路径和名称
                tbxSavePath.Text = m_RasterFileName;
            }
        }

        private void cbxLayerAddItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果CbxLayerAddItems控件中的图层不为空发生以下事件
            if (cbxLayerAddItems.SelectedItem != null)
            {
                string strRasterSelected = cbxLayerAddItems.SelectedItem.ToString();
                m_FeatureLayer = GetFeatureLayer(strRasterSelected);
            }
        }
        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            //通过所选择图层的名字来得到该图层
            if (GetLayers() == null)
                return null;
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer pLayer = null;
            while ((pLayer = layers.Next()) != null)
            {
                if (pLayer.Name == layerName)
                    return pLayer as IFeatureLayer;
            }
            return null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Geoprocessor GP = new Geoprocessor();
            GP.OverwriteOutput = true;
            //使用GeoProcessor工具生成欧氏距离场
            EucDistance eucDist = new EucDistance(m_FeatureLayer, m_RasterFileName);
            GP.Execute(eucDist, null);
            //pRasterLayer是生成的欧氏距离场
            IRasterLayer pRasterLayer = new RasterLayerClass();
            IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactoryClass();
            IRasterWorkspace pRasterWorkspace = (IRasterWorkspace)pWorkspaceFactory.OpenFromFile(m_Path, 0);
            IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(m_FileName);
            pRasterLayer.CreateFromDataset(pRasterDataset);
            //调用栅格图层渲染函数渲染生成的欧氏距离场栅格图层
            RasterStretchColorMapRender(pRasterLayer);
            m_hookHelper.FocusMap.AddLayer(pRasterLayer);
            m_hookHelper.ActiveView.Refresh();
        }
        public void RasterStretchColorMapRender(IRasterLayer pRasterlayer)
        {
            //栅格图层渲染函数
            try
            {
                IRaster pRaster = pRasterlayer.Raster;
                int intTransPValue = 30;
                IColor pFromColor = new RgbColorClass();
                //Red + (0x100 * Green) + (0x10000 * Blue);
                pFromColor.RGB = 255 + 0x100 * 255;
                IColor pToColor = new RgbColorClass();
                pToColor.RGB = 0x10000 * 255;
                IRasterStretchColorRampRenderer pStretchRender = (IRasterStretchColorRampRenderer)pRasterlayer.Renderer;
                IRasterRenderer pRasterRender = default(IRasterRenderer);
                pRasterRender = (IRasterRenderer)pStretchRender;
                pRasterRender.Raster = pRaster;
                pRasterRender.Update();
                IAlgorithmicColorRamp pColorRamp = new AlgorithmicColorRamp();
                pColorRamp.Size = 255;
                pColorRamp.FromColor = pFromColor;
                pColorRamp.ToColor = pToColor;
                bool outvalue = true;
                pColorRamp.CreateRamp(out outvalue);
                pStretchRender.BandIndex = 0;
                pStretchRender.ColorRamp = pColorRamp;
                if (intTransPValue > 0)
                {
                    IRasterDisplayProps pRRenProp =
                                    (IRasterDisplayProps)pStretchRender;
                    pRRenProp.TransparencyValue = intTransPValue;
                }
                pRasterRender.Update();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
