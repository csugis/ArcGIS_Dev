using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using System.Windows.Forms;


namespace MapControlApplication
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("abb93a5f-34db-4b23-8d86-e69d81e9dd42")]
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
            //�½����˵������ݿⲢ�Զ�������
            SaveFileDialog dbfiledlg = new SaveFileDialog();
            dbfiledlg.Filter = "�ռ����ݿ��ļ���*.mdb��|*.mdb";
            dbfiledlg.RestoreDirectory = true;
            if (dbfiledlg.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = dbfiledlg.FileName.ToString();
                if (System.IO.File.Exists(localFilePath))
                    System.IO.File.Delete(localFilePath);
                //��ò����ļ������ļ�·��
                string FilePath = localFilePath.Substring(0,
                                       localFilePath.LastIndexOf("\\"));
                //��ȡ�ļ���������·��
                string fileNameExt = localFilePath.Substring(
        localFilePath.LastIndexOf("\\") + 1);
                string fileName = fileNameExt.Substring(0,
        fileNameExt.LastIndexOf("."));
                IWorkspaceFactory ipWSFactory = new AccessWorkspaceFactory();
                IWorkspaceName ipWsName = ipWSFactory.Create(
        FilePath, fileName, null, 0);
                IWorkspace ipWorkspace = ipWSFactory.OpenFromFile(
        localFilePath, 0);
                string datasetName = null;
                string featureclsName = null;
                esriGeometryType type = esriGeometryType.esriGeometryNull;        //��һ��Ҫ������ѡ��Ի���
                FrmCreateFeatureClass dlg = new FrmCreateFeatureClass();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    type = dlg.type; //Ҫ���༸�����ͣ��㡢�ߡ���
                    datasetName = dlg.dataset; //Ҫ�����ݼ�����
                    featureclsName = dlg.featureCls; //Ҫ��������
                    ISpatialReference ipSr =         //��ǰ�򿪵�ͼ�Ŀռ�����
        m_hookHelper.FocusMap.SpatialReference;
                    IFeatureClass ipFeatCls = CreateFeatureClass(ipWorkspace as
        IFeatureWorkspace, datasetName, featureclsName, ipSr, type);
                    IFeatureLayer ipFeatLyr = new FeatureLayerClass();
                    // �½���ͼ���Ĭ����
                    ipFeatLyr.Name = featureclsName;
                    ipFeatLyr.FeatureClass = ipFeatCls;
                    m_hookHelper.FocusMap.AddLayer(ipFeatLyr);
                }
            }
        }
        //�����㡢�ߡ���Ҫ����
        private IFeatureClass CreateFeatureClass(IFeatureWorkspace ipWorkspace,
        string dsName, string fcName,
                                 ISpatialReference ipSr, esriGeometryType type)
        {
            //�����ֶ���
            IFieldsEdit ipFields = (IFieldsEdit)new Fields();
            ipFields.FieldCount_2 = 2; //�����ֶ���
            IFieldEdit ipField = (IFieldEdit)new Field();
            ipField.Name_2 = "ObjectID";
            ipField.AliasName_2 = "FID";
            ipField.Type_2 = esriFieldType.esriFieldTypeOID;
            ipFields.set_Field(0, ipField);
            // ���ü�����״�ֶ�
            IGeometryDefEdit ipGeoDef = (IGeometryDefEdit)new GeometryDef();
            ipGeoDef.SpatialReference_2 = ipSr; //���ÿռ�����
                                                // ����Ҫ�ؼ�������
            ipGeoDef.GeometryType_2 = type;
            IFieldEdit ipField3 = (IFieldEdit)new Field();
            ipField3.Name_2 = "Shape";
            ipField3.AliasName_2 = "shape";
            ipField3.Type_2 = esriFieldType.esriFieldTypeGeometry;
            ipField3.GeometryDef_2 = ipGeoDef;
            ipFields.set_Field(1, ipField3);
            // �ڹ����ռ��´���Ҫ�����ݼ���Ҫ�����ݼ�����dsName
            IFeatureDataset ipFeatDs = ipWorkspace.CreateFeatureDataset(dsName,
        ipSr);
            // ��Ҫ�����ݼ��´���Ҫ���࣬Ҫ��������fcName
            IFeatureClass ipFeatCls = ipFeatDs.CreateFeatureClass(fcName, ipFields,
         null, null, esriFeatureType.esriFTSimple, "Shape", "");
            return ipFeatCls;
        }


        #endregion
    }
}
