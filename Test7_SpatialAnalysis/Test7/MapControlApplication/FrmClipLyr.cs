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
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geometry;


namespace MapControlApplication
{
    public partial class FrmClipLyr : Form
    {
        private string txtOutputPath = null;
        private IHookHelper m_hookHelper = null;

        public FrmClipLyr(object hook)
        {
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;
            InitializeComponent();
        }

        private void FrmClipLyr_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_hookHelper.FocusMap.LayerCount; i++)
            {
                //获取输入图层
                ILayer lyr = m_hookHelper.FocusMap.get_Layer(i);
                IFeatureLayer fLyr = lyr as IFeatureLayer;
                if (fLyr != null && fLyr.FeatureClass.ShapeType ==
        esriGeometryType.esriGeometryPolygon)
                    InputLayer.Items.Add(lyr.Name);
                //获取被裁的要素图层
                if (fLyr != null)
                    ClipLayer.Items.Add(lyr.Name);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dbfiledlg = new SaveFileDialog();
            dbfiledlg.Filter = "ShapeFile（*.shp）|*.shp";
            dbfiledlg.RestoreDirectory = true;
            if (dbfiledlg.ShowDialog() == DialogResult.OK)
            {
                txtOutputPath = dbfiledlg.FileName.ToString();
                if (System.IO.File.Exists(txtOutputPath))
                    System.IO.File.Delete(txtOutputPath);
                OutputLayer.Text = txtOutputPath;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            gp.AddOutputsToMap = true;
            IFeatureLayer pfl = null, pf2 = null;
            for (int i = 0; i < m_hookHelper.FocusMap.LayerCount; i++)
            {
                ILayer lyr = m_hookHelper.FocusMap.get_Layer(i);
                if (InputLayer.Text == lyr.Name)
                    pfl = lyr as IFeatureLayer;
                if (ClipLayer.Text == lyr.Name)
                    pf2 = lyr as IFeatureLayer;
            }
            //调用GP工具
            Clip myclip = new Clip();
            myclip.clip_features = pfl.FeatureClass;
            myclip.in_features = pf2.FeatureClass;
            myclip.out_feature_class = OutputLayer.Text;
            //执行裁剪工具
            gp.Execute(myclip, null);
            MessageBox.Show("裁剪完成");
            string fileDirectory = OutputLayer.Text.ToString().Substring(0, OutputLayer.Text.LastIndexOf("\\"));
            int j;
            j = OutputLayer.Text.LastIndexOf("\\");
            string tmpstr = OutputLayer.Text.ToString().Substring(j + 1);
            //添加缓冲区到当前图层
            IWorkspaceFactory pWorkspaceFactory = new
                        ShapefileWorkspaceFactory() as IWorkspaceFactory;
            IWorkspace pWS = pWorkspaceFactory.OpenFromFile(
                                                      fileDirectory, 0);
            IFeatureWorkspace pFS = pWS as IFeatureWorkspace;
            IFeatureClass pfc = pFS.OpenFeatureClass(tmpstr);
            IFeatureLayer pf3 = new FeatureLayer() as IFeatureLayer;
            pf3.FeatureClass = pfc;
            pf3.Name = pfc.AliasName;
            m_hookHelper.FocusMap.AddLayer(pf3);
            this.Close();
        }
    }
}
