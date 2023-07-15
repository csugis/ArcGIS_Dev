using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;


namespace MapControlApplication
{
    /// <summary>
    /// Summary description for ToolRomoveVertex.
    /// </summary>
    [Guid("e68bbc2c-5265-42e3-b0c8-4a41aeac6aa9")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("MapControlApplication.ToolRomoveVertex")]
    public sealed class ToolRomoveVertex : BaseTool
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
        private IFeature m_pgFeature = null;

        public ToolRomoveVertex()
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
            // TODO: Add ToolRomoveVertex.OnClick implementation
            FrmSelectLayer dlg = new FrmSelectLayer(m_hookHelper);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_layer = dlg.lyr as IFeatureLayer;
            }
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolRomoveVertex.OnMouseDown implementation
            if (m_layer == null)
                return;
            if (m_pgFeature == null)//先拉框选择多边形
            {
                ISpatialFilter ipSF = new SpatialFilterClass();
                IRubberBand ipRB = new RubberEnvelopeClass();
                IEnvelope env = ipRB.TrackNew(
        m_hookHelper.ActiveView.ScreenDisplay, null) as IEnvelope;
                ipSF.Geometry = env;
                ipSF.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                ((IFeatureSelection)m_layer).SelectFeatures(ipSF,
                        esriSelectionResultEnum.esriSelectionResultNew, true);
                m_hookHelper.ActiveView.PartialRefresh(
                        esriViewDrawPhase.esriViewGeoSelection, null, null);
                ISelection ipSel = m_hookHelper.FocusMap.FeatureSelection;
                if (ipSel == null)
                    return;
                ((IEnumFeature)ipSel).Reset();
                //获得当前选择多边形
                m_pgFeature = (IFeature)((IEnumFeature)ipSel).Next();
            }
            else//选择并删除多边形顶点
            {
                IPoint ipPoint = m_hookHelper.ActiveView.ScreenDisplay.
                            DisplayTransformation.ToMapPoint(X, Y);
                IGeometry ipGeo = m_pgFeature.Shape;
                IElement ele = new PolygonElementClass();
                ele.Geometry = ipGeo;
                IPolygon ipPolygon = (IPolygon)ele.Geometry;
                IHitTest ipHitTest = (IHitTest)ipPolygon;
                double hitDist = 1.0E12;
                double searchRadius = ipGeo.Envelope.Width / 4;
                int partIndex = -1, segIndex = -1;
                bool bHit = false, bRSide = false;
                IPoint hitPoint = new PointClass();
                bHit = ipHitTest.HitTest(ipPoint, searchRadius,
                    esriGeometryHitPartType.esriGeometryPartVertex,
                    hitPoint, ref hitDist, ref partIndex, ref segIndex, ref bRSide);
                if (bHit)
                {
                    RemoveVertex(ipPolygon, hitPoint, partIndex, segIndex);
                    m_pgFeature.Shape = ipPolygon;
                    m_pgFeature.Store();
                }
                ((IFeatureSelection)m_layer).Clear();
                m_hookHelper.ActiveView.Refresh();
                m_pgFeature = null;
            }
        }
        //删除多边形的节点
        private void RemoveVertex(IPolygon ipPolygon, IPoint hitPoint,
                                       int hitPartIndex, int hitSegmentIndex)
        {
            if (ipPolygon == null) return;
            IPointCollection ipPointCollection = null;
            ipPointCollection = ((IGeometryCollection)ipPolygon).get_Geometry(
                                            hitPartIndex) as IPointCollection;
            if (ipPointCollection.PointCount <= 3)
                return;
            IRelationalOperator iRO = hitPoint as IRelationalOperator;
            //与段起点重合
            if (iRO.Equals(ipPointCollection.get_Point(hitSegmentIndex)))
            {
                ipPointCollection.RemovePoints(hitSegmentIndex, 1);
            }
            //与段终点重合
            else if (iRO.Equals(ipPointCollection.get_Point(hitSegmentIndex + 1)))
            {
                ipPointCollection.RemovePoints(hitSegmentIndex + 1, 1);
            }
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolRomoveVertex.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolRomoveVertex.OnMouseUp implementation
        }
        #endregion
    }
}
