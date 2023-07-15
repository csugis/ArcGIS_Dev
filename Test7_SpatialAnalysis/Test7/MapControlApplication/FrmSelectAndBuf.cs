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
    public partial class FrmSelectAndBuf : Form
    {
        private IFeatureLayer m_ipSelectedLyr = null;
        private IFeatureLayer m_ipPolygonLyr = null;
        private IHookHelper m_hookHelper = null;

        public FrmSelectAndBuf(IHookHelper hook)
        {
            m_hookHelper = hook;
            InitializeComponent();
        }
        public double bufDist
        {
            get
            {
                return Convert.ToDouble(txtBufferDistance.Text);
            }
        }
        public IFeatureLayer selectLyr
        {
            get
            {
                return m_ipSelectedLyr;
            }
        }
        public IFeatureLayer polygonLyr
        {
            get
            {
                return m_ipPolygonLyr;
            }
        }

        private void FrmSelectAndBuf_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_hookHelper.FocusMap.LayerCount; i++)
            {
                ILayer lyr = m_hookHelper.FocusMap.get_Layer(i);
                IFeatureLayer fLyr = lyr as IFeatureLayer;
                if (fLyr != null)
                    selectLayer.Items.Add(lyr.Name);
                if (fLyr != null && fLyr.FeatureClass.ShapeType ==
        esriGeometryType.esriGeometryPolygon)
                    saveLayer.Items.Add(lyr.Name);
            }
        }

        private void selectLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < m_hookHelper.FocusMap.LayerCount; i++)
            {
                ILayer lyr = m_hookHelper.FocusMap.get_Layer(i);
                if (lyr.Name == selectLayer.Text)
                {
                    m_ipSelectedLyr = lyr as IFeatureLayer;
                    break;
                }
            }
        }

        private void saveLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < m_hookHelper.FocusMap.LayerCount; i++)
            {
                ILayer lyr = m_hookHelper.FocusMap.get_Layer(i);
                if (lyr.Name == saveLayer.Text)
                {
                    m_ipPolygonLyr = lyr as IFeatureLayer;
                    break;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
