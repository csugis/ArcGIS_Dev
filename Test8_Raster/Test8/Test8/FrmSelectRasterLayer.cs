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


namespace Test8
{
    public partial class FrmSelectRasterLayer : Form
    {
        private IHookHelper m_hookHelper = null;
        private IMap m_map = null;
        private IRasterLayer m_RasterLayer = null;
        //只读属性获取选择图层
        public IRasterLayer rasterLayer
        {
            get { return m_RasterLayer; }
        }

        public FrmSelectRasterLayer(IHookHelper hookHelper)
        {
            InitializeComponent();
            m_hookHelper = hookHelper;
            m_map = hookHelper.FocusMap;

        }

        private void FrmSelectRasterLayer_Load(object sender, EventArgs e)
        {
            CbxRasterLayersAddItems();
        }

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            //如果cbxAddRasterLayers控件中的图层不为空
            if (cbxAddRasterLayers.SelectedItem != null)
            {
                string strRasterSelected = cbxAddRasterLayers.SelectedItem.ToString();
                m_RasterLayer = GetRasterLayer(strRasterSelected);
            }
            this.Close();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            m_RasterLayer = null;
            this.Close();
        }
    }
}
