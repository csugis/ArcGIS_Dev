using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace MapControlApplication
{
    public partial class FrmSelectLayer : Form
    {
        private ILayer m_layer = null;
        private IHookHelper m_hookhelper = null;

        public ILayer lyr
        {
            get
            {
                return m_layer;
            }
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
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            m_layer = null;
            this.Close();
        }

        private void cbxLayersChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumLayer layers = m_hookhelper.FocusMap.Layers;
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    if (layer.Name == cbxLayersChoose.Text)
                    {
                        m_layer = layer;
                        break;
                    }
                }
                layer = layers.Next();
            }
        }
    }
}
