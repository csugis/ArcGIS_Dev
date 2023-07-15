using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;

namespace MapControlApplication
{
    public partial class FrmCreateFeatureClass : Form
    {
        //获得要素类几何类型
        public esriGeometryType type
        {
            get
            {
                if (rPoint.Checked)
                    return esriGeometryType.esriGeometryPoint;
                else if (rLine.Checked)
                    return esriGeometryType.esriGeometryPolyline;
                else if (rPolygon.Checked)
                    return esriGeometryType.esriGeometryPolygon;
                else
                    return esriGeometryType.esriGeometryNull;
            }
        }
        //获得要素数据集名
        public string dataset
        {
            get
            {
                return textBoxDataset.Text;
            }
        }
        //获得要素类名
        public string featureCls
        {
            get
            {
                return textBoxfeatureCls.Text;
            }
        }

        public FrmCreateFeatureClass()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close(); 
        }
    }
}
