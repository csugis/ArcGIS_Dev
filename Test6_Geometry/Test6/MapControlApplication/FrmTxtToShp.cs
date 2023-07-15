using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;


namespace MapControlApplication
{
    public partial class FrmTxtToShp : Form
    {
        private IPointCollection m_pts = null;
        private IHookHelper m_hookHelper = null;

        public FrmTxtToShp(object hook)
        {
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;
            InitializeComponent();
        }
        //读取文本文件转换为点集
        private IPointCollection GetPoints(string txtFileName)
        {
            try
            {
                IMultipoint pts = new MultipointClass();
                IPointCollection ptsCol = pts as IPointCollection;
                //常用的分隔符为逗号、空格、制位符
                char[] datachar = new char[] { ',', ' ', '\t' };
                //定义文件流
                System.IO.FileStream FileStream =
        new System.IO.FileStream(txtFileName, FileMode.Open);
                StreamReader StreamReader = new StreamReader(
        FileStream, Encoding.Default);//读取文件流
                                      //以行为单位进行读取，跳过一行文件头
                string stringLine = StreamReader.ReadLine();
                while ((stringLine = StreamReader.ReadLine()) != null) //读取点信息
                {
                    string[] strArray = stringLine.Split(datachar);//以上述分隔符分割
                    IPoint point = new PointClass();
                    //将strArray赋给Point
                    point.M = Convert.ToDouble(strArray[0].Trim());
                    point.X = Convert.ToDouble(strArray[1]);
                    point.Y = Convert.ToDouble(strArray[2]);
                    ptsCol.AddPoint(point);
                }
                StreamReader.Close();
                return ptsCol;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog txtDialog = new OpenFileDialog();
            txtDialog.Multiselect = false;
            txtDialog.Title = "打开txt文件";
            txtDialog.Filter = "txt坐标文件（*.txt）|*.txt";
            if (txtDialog.ShowDialog() == DialogResult.OK)
            {
                TxtFile.Text = txtDialog.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog txtDialog = new SaveFileDialog();
            txtDialog.Title = "保存为shp文件";
            txtDialog.Filter = "shapefile文件（*.shp）|*.shp";
            if (txtDialog.ShowDialog() == DialogResult.OK)
            {
                SavePath.Text = txtDialog.FileName;
            }
        }

        private void TxtToPoint_Click(object sender, EventArgs e)
        {
            IMap map = m_hookHelper.FocusMap;
            m_pts = GetPoints(TxtFile.Text);
            if (m_pts == null)
            {
                MessageBox.Show("选择文件是空");
            }
            else
            {
                //调用CreatePointShpFromPoints函数
                IFeatureLayer pFeatureLayer = CreatePointShpFromPoints(
        m_pts, SavePath.Text);
                map.AddLayer(pFeatureLayer);
            }
        }
        private IFeatureLayer CreatePointShpFromPoints(IPointCollection pts,
string FilePath)
        {
            int index = FilePath.LastIndexOf('\\');
            string Folder = FilePath.Substring(0, index);
            string ShapeName = "pt" + FilePath.Substring(index + 1);
            IWorkspaceFactory ws = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace fws = (IFeatureWorkspace)ws.OpenFromFile(Folder, 0);
            IFeatureClass ptFeatureCls = CreateShapeFeatureClass(fws, ShapeName,
             esriGeometryType.esriGeometryPoint);
            for (int j = 0; j < pts.PointCount; j++) //将点集的值逐个赋给新建的Point中
            {
                IPoint pt = new PointClass(); //新建PointClass
                pt.X = pts.get_Point(j).X;
                pt.Y = pts.get_Point(j).Y;
                IFeature Feature = ptFeatureCls.CreateFeature();//创建要素
                Feature.Shape = pt;//将Point赋给Feature.Shape
                Feature.Store();//存储要素
            }
            IFeatureLayer PoFeatureLayer = new FeatureLayerClass();
            PoFeatureLayer.Name = ptFeatureCls.AliasName;
            PoFeatureLayer.FeatureClass = ptFeatureCls;
            return PoFeatureLayer;
        }
        //创建点、线、面要素类
        private IFeatureClass CreateShapeFeatureClass(IFeatureWorkspace ws, string FCName,
                                    esriGeometryType type)
        {
            //设置字段组
            IFieldsEdit ipFields = (IFieldsEdit)new Fields();
            ipFields.FieldCount_2 = 2; //设置字段数
            IFieldEdit ipField = (IFieldEdit)new Field();
            ipField.Name_2 = "ObjectID";
            ipField.AliasName_2 = "FID";
            ipField.Type_2 = esriFieldType.esriFieldTypeOID;
            ipFields.set_Field(0, ipField);
            // 设置几何形状字段
            IGeometryDefEdit ipGeoDef = (IGeometryDefEdit)new GeometryDef();
            ISpatialReference ipSR = CreateSpatialReference();
            ipGeoDef.SpatialReference_2 = ipSR; //设置空间索引
                                                // 设置要素几何类型
            ipGeoDef.GeometryType_2 = type;
            IFieldEdit ipField3 = (IFieldEdit)new Field();
            ipField3.Name_2 = "Shape";
            ipField3.AliasName_2 = "shape";
            ipField3.Type_2 = esriFieldType.esriFieldTypeGeometry;
            ipField3.GeometryDef_2 = ipGeoDef;
            ipFields.set_Field(1, ipField3);
            // 在工作空间下创建要素类
            IFeatureClass ipFeatCls = ws.CreateFeatureClass(FCName, ipFields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
            return ipFeatCls;
        }
        //创建空间参考
        private ISpatialReference CreateSpatialReference()
        {
            ISpatialReferenceFactory pSRF = new SpatialReferenceEnvironmentClass();
            ISpatialReference pSpatialReference = pSRF.CreateProjectedCoordinateSystem((int)esriSRProjCSType.esriSRProjCS_WGS1984UTM_21N);
            return pSpatialReference;
        }

        private void TxtToPolygon_Click(object sender, EventArgs e)
        {
            IMap map = m_hookHelper.FocusMap;
            m_pts = GetPoints(TxtFile.Text);
            if (m_pts == null)
            {
                MessageBox.Show("选择文件是空");
            }
            else
            {
                IFeatureLayer pFeatureLayer = CreatePolygonShpFromPoints(
        m_pts, SavePath.Text);
                map.AddLayer(pFeatureLayer);
            }
        }
        private IFeatureLayer CreatePolygonShpFromPoints(IPointCollection pts,
string FilePath)
        {
            int index = FilePath.LastIndexOf('\\');
            string Folder = FilePath.Substring(0, index);
            string ShapeName = "poly" + FilePath.Substring(index + 1);
            IWorkspaceFactory ws = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace fws = (IFeatureWorkspace)ws.OpenFromFile(Folder, 0);
            IFeatureClass polyFeatureCls = CreateShapeFeatureClass(fws, ShapeName,
             esriGeometryType.esriGeometryPolygon);
            //创建多边形类
            IPolygon polygon = new PolygonClass();
            IPointCollection polygonCol = polygon as IPointCollection;
            polygonCol.AddPointCollection(pts);
            IFeature pFeature = polyFeatureCls.CreateFeature();//创建要素
            pFeature.Shape = polygon;
            pFeature.Store();
            IFeatureLayer pFeaturelayer = new FeatureLayerClass();
            pFeaturelayer.Name = polyFeatureCls.AliasName;
            pFeaturelayer.FeatureClass = polyFeatureCls;
            return pFeaturelayer;
        }
    }
}
