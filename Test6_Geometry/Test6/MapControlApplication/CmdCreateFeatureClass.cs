using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;


namespace MapControlApplication
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("766d6da3-6c7e-462f-b159-216d84b29a94")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("MapControlApplication.CmdCreateFeatureClass")]
    public sealed class CmdCreateFeatureClass : BaseCommand
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Register(regKey);
            ControlsCommands.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(regKey);
            ControlsCommands.Unregister(regKey);
        }

        #endregion
        #endregion

        private IHookHelper m_hookHelper = null;
        public CmdCreateFeatureClass()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text
            base.m_caption = "";  //localizable text 
            base.m_message = "This should work in ArcMap/MapControl/PageLayoutControl";  //localizable text
            base.m_toolTip = "";  //localizable text
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                    m_hookHelper = null;
            }
            catch
            {
                m_hookHelper = null;
            }

            if (m_hookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            // TODO:  Add other initialization code
        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add CmdCreateFeatureClass.OnClick implementation
            //连接本地目录
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "（*.shp）|*.shp";
            saveFileDialog.Title = "新建多边形shp文件";
            saveFileDialog.CheckFileExists = false;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                IWorkspaceFactory pWorkspaceFactory = new
        ShapefileWorkspaceFactory();
                string localFilePath = saveFileDialog.FileName.ToString();
                //获取文件名，不带路径
                string fileNameExt = localFilePath.Substring(
        localFilePath.LastIndexOf("\\") + 1);
                string filename = fileNameExt.Substring(0,
        fileNameExt.LastIndexOf("."));
                //获得不带文件名的文件路径
                string FilePath = localFilePath.Substring(0,
        localFilePath.LastIndexOf("\\"));
                //打开Shapefile本地目录类型的地理数据库连接
                IWorkspace ipWorkspace = pWorkspaceFactory.OpenFromFile(
                FilePath, 0);
                //创建Shapefile本地文件的要素类
                IFeatureClass fc = CreateShapeFeatureClass(
                ipWorkspace as IFeatureWorkspace, filename,
                esriGeometryType.esriGeometryPolygon);
                //添加新创建的多边形要素类到当前地图
                IFeatureLayer layer = new FeatureLayerClass();
                layer.Name = fc.AliasName;
                layer.FeatureClass = fc;
                m_hookHelper.FocusMap.AddLayer(layer as ILayer);
            }
        }
        //创建点、线、面要素类
        private IFeatureClass CreateShapeFeatureClass(IFeatureWorkspace ws,
        string FCName, esriGeometryType type)
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
            IFeatureClass ipFeatCls = ws.CreateFeatureClass(FCName, ipFields, null,
            null, esriFeatureType.esriFTSimple, "Shape", "");
            return ipFeatCls;
        }
        //创建空间参考
        private ISpatialReference CreateSpatialReference()
        {
            ISpatialReferenceFactory pSRF = new SpatialReferenceEnvironmentClass();
            ISpatialReference pSpatialReference = pSRF.CreateProjectedCoordinateSystem(
            (int)esriSRProjCSType.esriSRProjCS_WGS1984UTM_21N);
            return pSpatialReference;
        }


        #endregion
    }
}
