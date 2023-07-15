using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;


namespace ArcEngineClassLibrary
{
    /// <summary>
    /// Summary description for ToolPolygonSelect.
    /// </summary>
    [Guid("fbf90c05-88c7-4a57-ba4e-58450ccfdd98")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcEngineClassLibrary.ToolPolygonSelect")]
    public sealed class ToolPolygonSelect : BaseTool
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
        private ILayer m_layer = null;

        public ToolPolygonSelect()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "CSharpTest"; //localizable text 
            base.m_caption = "ToolPolygonSelect";  //localizable text 
            base.m_message = "This should work in ArcMap/MapControl/PageLayoutControl";  //localizable text
            base.m_toolTip = "ToolPolygonSelect";  //localizable text
            base.m_name = "CSharpTest_ToolPolygonSelect";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
            try
            {
                //
                // TODO: change resource name if necessary
                //
                string bitmapResourceName = GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                base.m_cursor = new System.Windows.Forms.Cursor(GetType(), GetType().Name + ".cur");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this tool is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            try
            {
                m_hookHelper = new HookHelperClass();
                m_hookHelper.Hook = hook;
                if (m_hookHelper.ActiveView == null)
                {
                    m_hookHelper = null;
                }
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
        /// Occurs when this tool is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add ToolPolygonSelect.OnClick implementation
            // 获得选择图层
            FrmSelectLayer frmSelectLayer = new FrmSelectLayer(m_hookHelper);
            frmSelectLayer.ShowDialog();
            m_layer = frmSelectLayer.lyr;
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolPolygonSelect.OnMouseDown implementation
            IRubberBand polygonRubber = new RubberPolygonClass();
            IPolygon polygon = polygonRubber.TrackNew(
                    m_hookHelper.ActiveView.ScreenDisplay, null) as IPolygon;
            // 进行多边形选择
            ISpatialFilter spFilter = new SpatialFilterClass();
            spFilter.Geometry = polygon;
            spFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
            IFeatureSelection fSel = m_layer as IFeatureSelection;
            fSel.SelectFeatures(spFilter,
                        esriSelectionResultEnum.esriSelectionResultNew, false);
            fSel.SelectionSet.Refresh();
            m_hookHelper.ActiveView.Refresh();
            // 显示选择结果属性表格
            FrmSelectResult pResult1 = new FrmSelectResult(m_layer as IFeatureLayer);
            pResult1.Show();

        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolPolygonSelect.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolPolygonSelect.OnMouseUp implementation
        }
        #endregion
    }
}
