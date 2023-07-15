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
using ESRI.ArcGIS.Geometry;


namespace MapControlApplication
{
    public partial class FrmSelectLayer : Form
    {
        //保存选择到的要素图层
        private ILayer m_layer = null;
        //定义IHookHelper接口获取主应用程序资源
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
        //获取当前地图所有的多边形要素图层，并添加到组合框
        private void CbxLayersAddItems()
        {
            IEnumLayer layers = m_hookhelper.FocusMap.Layers;
            layers.Reset();
            IFeatureLayer layer = layers.Next() as IFeatureLayer;
            while (layer != null)
            {
                //如果是多边形要素图层，添加到组合框控件
                if (layer is IFeatureLayer && layer.FeatureClass.ShapeType ==
        esriGeometryType.esriGeometryPolygon)
                {
                    cbxLayersChoose.Items.Add(layer.Name);
                }
                layer = layers.Next() as IFeatureLayer;
            }
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
    }
}
