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
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.AnalysisTools;
using ESRI.ArcGIS.Geoprocessor;


namespace MapControlApplication
{
    public partial class FrmBufferGP : Form
    {
        private IHookHelper m_hookHelper = null;
        public FrmBufferGP(object hook)
        {
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;
            InitializeComponent();
        }

        private void FrmBufferGP_Load(object sender, EventArgs e)
        {
            CbxLayersAddItems();
        }
        //获取当前地图所有矢量图层，并添加到组合框
        private void CbxLayersAddItems()
        {
            IEnumLayer layers = m_hookHelper.FocusMap.Layers;
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    selectLayer.Items.Add(layer.Name);
                }
                layer = layers.Next();
            }
        }

        private void btnOutputLayer_Click(object sender, EventArgs e)
        {
            //设置输出图层的路径
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "保存为shp文件";
            saveDlg.Filter = "shapefile文件（*.shp）|*.shp";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                txtOutputPath.Text = saveDlg.FileName;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGPor_Click(object sender, EventArgs e)
        {
            double bufferDistance;           //缓冲距离
            double.TryParse(txtBufferDistance.Text, out bufferDistance);
            //获取需要生成缓冲区的图层
            IFeatureLayer pFeatureLayer = (IFeatureLayer)
            GetLayerByName(selectLayer.SelectedItem.ToString());
            Geoprocessor gp = new Geoprocessor();
            //设置是否覆盖原有文件
            gp.OverwriteOutput = true;
            gp.AddOutputsToMap = true;
            string unit = "Kilometers";
            //实例化Buffer对象
            ESRI.ArcGIS.AnalysisTools.Buffer buffer =
               new ESRI.ArcGIS.AnalysisTools.Buffer(
            pFeatureLayer, txtOutputPath.Text,
            Convert.ToString(bufferDistance) + " " + unit);
            //执行地理处理工具
            IGeoProcessorResult results = (IGeoProcessorResult)gp.Execute(buffer, null);
            //添加缓冲区图层到当前地图中
            Add2Map();
        }
        //根据名字获取图层
        private ILayer GetLayerByName(string strLayerName)
        {
            ILayer pLayer = null;
            for (int i = 0; i <= m_hookHelper.FocusMap.LayerCount - 1; i++)
            {
                if (strLayerName == m_hookHelper.FocusMap.get_Layer(i).Name)
                { pLayer = m_hookHelper.FocusMap.get_Layer(i); break; }
            }
            return pLayer;
        }
        //添加缓冲区图层到当前地图中
        private void Add2Map()
        {
            string fileDirectory = txtOutputPath.Text.ToString().Substring(0,
            txtOutputPath.Text.LastIndexOf("\\"));
            int j;
            j = txtOutputPath.Text.LastIndexOf("\\");
            string tmpstr = txtOutputPath.Text.ToString().Substring(j + 1);
            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory()
            as IWorkspaceFactory;
            IWorkspace pWS = pWorkspaceFactory.OpenFromFile(fileDirectory, 0);
            IFeatureWorkspace pFS = pWS as IFeatureWorkspace;
            IFeatureClass pfc = pFS.OpenFeatureClass(tmpstr);
            IFeatureLayer pfl = new FeatureLayer() as IFeatureLayer;
            pfl.FeatureClass = pfc;
            pfl.Name = pfc.AliasName;
            IRgbColor pColor = new RgbColor() as IRgbColor;
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 255;
            //产生一个线符号对象
            ILineSymbol pOutline = new SimpleLineSymbol();
            pOutline.Width = 2;
            pOutline.Color = pColor;
            //设置颜色属性
            pColor = new RgbColor();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 100;
            //设置填充符号的属性
            ISimpleFillSymbol pFillSymbol = new SimpleFillSymbol();
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutline;
            pFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
            ISimpleRenderer pRen;
            IGeoFeatureLayer pGeoFeatLyr = pfl as IGeoFeatureLayer;
            pRen = pGeoFeatLyr.Renderer as ISimpleRenderer;
            pRen.Symbol = pFillSymbol as ISymbol;
            pGeoFeatLyr.Renderer = pRen as IFeatureRenderer;
            ILayerEffects pLayerEffects = pfl as ILayerEffects;
            pLayerEffects.Transparency = 150;
            m_hookHelper.FocusMap.AddLayer(pfl);
        }

        private void btnGPor_Click_1(object sender, EventArgs e)
        {
            double bufferDistance;           //缓冲距离
            double.TryParse(txtBufferDistance.Text, out bufferDistance);
            //获取需要生成缓冲区的图层
            IFeatureLayer pFeatureLayer = (IFeatureLayer)GetLayerByName(
            selectLayer.SelectedItem.ToString());
            IGeoProcessor2 gp = new GeoProcessorClass();
            IGeoProcessorResult results = new GeoProcessorResultClass();
            gp.OverwriteOutput = true;
            string unit = "Kilometers";
            IVariantArray parameters = new VarArrayClass();
            parameters.Add(pFeatureLayer);
            parameters.Add(txtOutputPath.Text);
            parameters.Add(Convert.ToString(bufferDistance) + " " + unit);
            //执行地理处理工具
            results = gp.Execute("Buffer_analysis", parameters, null);
            //添加缓冲区图层到当前地图中
            Add2Map();
        }
    }
}
