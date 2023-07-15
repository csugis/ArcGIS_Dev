using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using stdole;


namespace Test9
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("bf2d41c4-1e67-46d7-ab22-8f6706584775")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Test9.CmdAddMapGrid")]
    public sealed class CmdAddMapGrid : BaseCommand
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
        public CmdAddMapGrid()
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
        private void CreatMeasuredGrid(IActiveView pActiveView,
IPageLayout pPageLayout)
        {
            IMap map = pActiveView.FocusMap;
            IMeasuredGrid pMeasuredGrid = new MeasuredGridClass();
            //设置格网基本属性
            pMeasuredGrid.FixedOrigin = false;
            pMeasuredGrid.Units = map.MapUnits;
            //纬度间隔
            pMeasuredGrid.XIntervalSize = 5;
            //经度间隔
            pMeasuredGrid.YIntervalSize = 5;
            //设置GridLable格式
            IGridLabel pGridLabel = null;
            IFormattedGridLabel pFormattedGridLabel =
        new FormattedGridLabelClass();
            INumericFormat pNumericFormat = new NumericFormatClass();
            pNumericFormat.AlignmentOption =
        esriNumericAlignmentEnum.esriAlignLeft;
            pNumericFormat.RoundingOption =
            esriRoundingOptionEnum.esriRoundNumberOfDecimals;
            pNumericFormat.RoundingValue = 0;
            pNumericFormat.ZeroPad = true;
            pFormattedGridLabel.Format = pNumericFormat as INumberFormat;
            pGridLabel = pFormattedGridLabel as IGridLabel;
            StdFont pStdFont = new stdole.StdFontClass();
            pStdFont.Name = "宋体";
            pStdFont.Size = 25;
            pGridLabel.Font = pStdFont as IFontDisp;
            IMapGrid pMapGrid = pMeasuredGrid as IMapGrid;
            pMapGrid.LabelFormat = pGridLabel;
            //将格网添加到地图上
            IGraphicsContainer graphicsContainer = pPageLayout as IGraphicsContainer;
            IFrameElement frameElement = graphicsContainer.FindFrame(map);
            IMapFrame mapFrame = frameElement as IMapFrame;
            IMapGrids mapGrids = null;
            mapGrids = mapFrame as IMapGrids;
            mapGrids.AddMapGrid(pMapGrid);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewBackground,
        null, null);
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
            // TODO: Add CmdAddMapGrid.OnClick implementation
            CreatMeasuredGrid(m_hookHelper.ActiveView, m_hookHelper.PageLayout);
        }

        #endregion
    }
}
