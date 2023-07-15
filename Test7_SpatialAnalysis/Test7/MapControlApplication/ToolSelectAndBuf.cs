using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;


namespace MapControlApplication
{
    /// <summary>
    /// Summary description for ToolSelectAndBuf.
    /// </summary>
    [Guid("d23330df-4be6-4fc5-9ba6-ed0060596fa2")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("MapControlApplication.ToolSelectAndBuf")]
    public sealed class ToolSelectAndBuf : BaseTool
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
        private IFeatureLayer m_selectLyr = null;
        private IFeatureLayer m_polygonLyr = null;
        private double m_dBufDist = 0.0;
        



        public ToolSelectAndBuf()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = ""; //localizable text 
            base.m_caption = "";  //localizable text 
            base.m_message = "This should work in ArcMap/MapControl/PageLayoutControl";  //localizable text
            base.m_toolTip = "";  //localizable text
            base.m_name = "";   //unique id, non-localizable (e.g. "MyCategory_MyTool")
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
            // TODO: Add ToolSelectAndBuf.OnClick implementation
            FrmSelectAndBuf frmBuffer = new FrmSelectAndBuf(m_hookHelper);
            if (frmBuffer.ShowDialog() == DialogResult.OK)
            {
                m_selectLyr = frmBuffer.selectLyr;
                m_polygonLyr = frmBuffer.polygonLyr;
                m_dBufDist = frmBuffer.bufDist;
            }
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolSelectAndBuf.OnMouseDown implementation
            //判断图层是否为空
            if (m_selectLyr == null || m_polygonLyr == null)
                return;
            IFeatureLayer ipSelLyr = m_selectLyr;
            IFeatureLayer ipPolygonLyr = m_polygonLyr;
            //进行多边形选择
            IRubberBand ipRubber = new RubberEnvelopeClass();
            IGeometry polygon = ipRubber.TrackNew(m_hookHelper.
                                          ActiveView.ScreenDisplay, null);
            ISpatialFilter ipSpatialFilter = new SpatialFilterClass();
            ipSpatialFilter.Geometry = polygon;
            ipSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
            IFeatureSelection ipFeatSelect = ipSelLyr as IFeatureSelection;
            ipFeatSelect.Clear();
            //选择单个要素
            ipFeatSelect.SelectFeatures(ipSpatialFilter,
                        esriSelectionResultEnum.esriSelectionResultNew, true);
            ipFeatSelect.SelectionSet.Refresh();
            m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.
                                    esriViewGeoSelection, null, null);
            //生成选择要素的缓冲区
            BufferSeclected(ipFeatSelect, ipPolygonLyr);
            m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.
                                         esriViewGeoSelection, null, null);
        }
        //调用ITopologicalOperator接口生成缓冲区
        private void BufferSeclected(IFeatureSelection ipFeatSelect,
        IFeatureLayer ipPolygonLyr)
        {
            ICursor cur = null;
            if (ipFeatSelect.SelectionSet.Count <= 0) return;
            ipFeatSelect.SelectionSet.Search(null, true, out cur);
            IFeature feature = cur.NextRow() as IFeature;
            ITopologicalOperator to = feature.Shape as ITopologicalOperator;
            //自定义缓冲区半径
            IPolygon poly = to.Buffer(m_dBufDist) as IPolygon;
            IFeature polyFeature = ipPolygonLyr.FeatureClass.CreateFeature();
            polyFeature.Shape = poly;
            polyFeature.Store();
            m_hookHelper.ActiveView.Refresh();
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolSelectAndBuf.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolSelectAndBuf.OnMouseUp implementation
        }
        #endregion
    }
}
