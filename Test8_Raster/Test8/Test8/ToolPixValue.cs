using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;


namespace Test8
{
    /// <summary>
    /// Summary description for ToolPixValue.
    /// </summary>
    [Guid("05235191-ea30-47a1-87e2-622af8c1ea9a")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Test8.ToolPixValue")]
    public sealed class ToolPixValue : BaseTool
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
        private IRasterLayer m_rasterLayer = null;

        public ToolPixValue()
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
        public string GetPixValue(IRasterLayer pRasterlayer, IPoint pt)
        {
            IRaster pRaster = pRasterlayer.Raster;
            IRasterProps rasterProps = (IRasterProps)pRaster;
            IEnvelope extent = rasterProps.Extent;
            IRelationalOperator pRO = pt as IRelationalOperator;
            if (!pRO.Within(extent)) //点坐标不在栅格范围内
                return null;
            IRaster2 pRaster2 = pRaster as IRaster2;
            //根据点坐标查询栅格行列号
            int row = pRaster2.ToPixelRow(pt.Y);
            int col = pRaster2.ToPixelColumn(pt.X);
            string strInquirePVResult = "Inquire Pixel Value Result:\n";
            IRaster2 r2 = pRasterlayer.Raster as IRaster2;
            IRasterDataset rasterDataset = r2.RasterDataset;
            IRasterBandCollection rasterBands = (IRasterBandCollection)rasterDataset;
            int i = 0, cntBands = rasterBands.Count;
            //根据点坐标查询栅格各波段像元值
            for (i = 0; i < cntBands; i++)
            {
                strInquirePVResult += rasterBands.Item(i).Bandname + ": ";
                strInquirePVResult += pRaster2.GetPixelValue(i, col, row).ToString()
         + "\n";
            }
            return strInquirePVResult;
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
            // TODO: Add ToolPixValue.OnClick implementation
            // TODO: Add ToolPixValue.OnClick implementation
            FrmSelectRasterLayer FrmSelectRasterLayer = new
            FrmSelectRasterLayer(m_hookHelper);
            FrmSelectRasterLayer.ShowDialog();
            m_rasterLayer = FrmSelectRasterLayer.rasterLayer;

        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolPixValue.OnMouseDown implementation
            //// TODO:  Add ToolPixValue.OnMouseDown implementation
            IPoint pPoint = m_hookHelper.ActiveView.ScreenDisplay.
            DisplayTransformation.ToMapPoint(X, Y);
            string msg = GetPixValue(m_hookHelper.FocusMap.get_Layer(0) as IRasterLayer, pPoint);
            MessageBox.Show(msg);

        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolPixValue.OnMouseMove implementation
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            // TODO:  Add ToolPixValue.OnMouseUp implementation
        }
        #endregion
    }
}
