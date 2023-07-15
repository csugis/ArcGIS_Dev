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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;

namespace Test8
{
    public partial class FrmStatistics : Form
    {
        private IHookHelper m_hookHelper = null;
        private IMap m_map = null;
        private IRasterLayer m_RasterLayer = null;
        public FrmStatistics(object hook)
        {
            InitializeComponent();
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;
            m_map = m_hookHelper.FocusMap;
        }

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            CbxRasterLayersAddItems();
        }
        //将当前地图中的所有栅格图层添加到组合框控件
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
        //获得当前地图的所有栅格图层
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
            //如果cbxAddRasterLayers控件中的图层不为空发生以下事件
            if (cbxAddRasterLayers.SelectedItem != null)
            {
                string strRasterSelected = cbxAddRasterLayers.SelectedItem.ToString();
                m_RasterLayer = GetRasterLayer(strRasterSelected);
            }
        }
        private IRasterLayer GetRasterLayer(string layerName)
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
                    return pLayer as IRasterLayer;
            }
            return null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            pRasterStistics(m_RasterLayer);
        }
        private void pRasterStistics(IRasterLayer rLayer)
        {
            IRaster2 r2 = rLayer.Raster as IRaster2;
            IRasterDataset rasterDataset = r2.RasterDataset;
            IRasterBandCollection rasterBands = (IRasterBandCollection)rasterDataset;
            IEnumRasterBand enumRasterBand = rasterBands.Bands;
            string sRasterStisticsResult = "Raster Statistics Result:\n";
            IRasterBand rasterBand = enumRasterBand.Next();
            while (rasterBand != null)
            {
                bool tmpBool;
                rasterBand.HasStatistics(out tmpBool);
                if (!tmpBool)
                    rasterBand.ComputeStatsAndHist();
                sRasterStisticsResult += GetRasterStistics(rasterBand) + "\n";
                rasterBand = enumRasterBand.Next();
            }
            //统计结果在rtbxResult中显示
            rtbxResult.Text = sRasterStisticsResult;
        }
        private string GetRasterStistics(IRasterBand rasterBand)
        {
            IRasterStatistics rasterStatistics = rasterBand.Statistics;
            string statisticsResult;
            statisticsResult = "" + rasterBand.Bandname + " Mean is：" + rasterStatistics.Mean.ToString() + " SD is：" + rasterStatistics.StandardDeviation.ToString();
            return statisticsResult;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
