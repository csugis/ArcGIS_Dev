using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcEngineClassLibrary
{
    public partial class FrmSelectLayer : Form
    {
        private IHookHelper m_hookhelper = null;
        private ILayer m_layer = null;
        public ILayer lyr
        {
            get { return m_layer; }
        }

        public FrmSelectLayer(IHookHelper hook)
        {
            m_hookhelper = hook;
            InitializeComponent();
        }

        private void FrmSelectLayer_Load(object sender, EventArgs e)
        {
            CbxLayersAddItems();
        }
        //获取当前地图所有要素图层，并添加到组合框
        private void CbxLayersAddItems()
        {
            IEnumLayer layers = m_hookhelper.FocusMap.Layers;
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    cbxLayersChoose.Items.Add(layer.Name);
                }
                layer = layers.Next();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string strLayer = cbxLayersChoose.SelectedItem.ToString();
            m_layer = GetFeatureLayer(strLayer);
            this.Close();
        }
        //由名字获得要素图层
        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            //get the layers from the maps
            IEnumLayer layers = m_hookhelper.FocusMap.Layers;
            layers.Reset();
            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                if (layer.Name == layerName)
                    return layer as IFeatureLayer;
            }
            return null;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
