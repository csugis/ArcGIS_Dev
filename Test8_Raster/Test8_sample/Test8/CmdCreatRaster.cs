using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;


namespace Test8
{
    /// <summary>
    /// Command that works in ArcMap/Map/PageLayout
    /// </summary>
    [Guid("b6359943-5526-4f2a-bbd4-58353a4ac883")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Test8.CmdCreatRaster")]
    public sealed class CmdCreatRaster : BaseCommand
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
        public CmdCreatRaster()
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
        //创建并修改栅格数据集
        private IRasterDataset CreatRasterDS(string filePath, string rasterName)
        {
            //创建栅格工作工厂
            IRasterWorkspace2 rasterWorkspaceEx;
            IWorkspaceFactory pWorkspaceFactory = new
            RasterWorkspaceFactoryClass();
            rasterWorkspaceEx = pWorkspaceFactory.OpenFromFile(filePath, 0)
            as IRasterWorkspace2;
            IRasterStorageDef storageDef = new RasterStorageDef();
            storageDef.CompressionType =
            esriRasterCompressionType.esriRasterCompressionJPEG;
            IRasterDef rasterDef = new RasterDef();
            IPoint Origin = new PointClass();
            Origin.X = 0;
            Origin.Y = 0;
            //生成100*100的栅格数据
            int ColumnCnt = 100, RowCnt = 100;
            double sizex = 10, sizey = 10;
            int numBands = 3;
            IRasterDataset rasterDataset = null;
            rasterDataset = rasterWorkspaceEx.CreateRasterDataset(rasterName,
            "TIFF", Origin, ColumnCnt, RowCnt, sizex,
            sizey, numBands, rstPixelType.PT_FLOAT);
            IRaster pRaster = rasterDataset.CreateDefaultRaster() as IRaster;
            //读取50*50的栅格数据（左上角部分）作为像素块
            int Width = 50, Height = 50;
            IPnt blocksize = new PntClass();
            blocksize.SetCoords(Width, Height);
            IPixelBlock3 pPixelBlock3 = pRaster.CreatePixelBlock(blocksize) as
        IPixelBlock3;
            IPnt pnt = new PntClass();
            pnt.SetCoords(0, 0);
            pRaster.Read(pnt, pPixelBlock3 as IPixelBlock);
            System.Array pixels0 = (System.Array)pPixelBlock3.get_PixelData(0);
            System.Array pixels1 = (System.Array)pPixelBlock3.get_PixelData(1);
            System.Array pixels2 = (System.Array)pPixelBlock3.get_PixelData(2);
            //修改像素块的像素值
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    float value0 = 0, value1 = 0, value2 = 0;
                    value0 = (float)Math.Abs(Math.Sin(row)) * row;
                    value1 = (float)Math.Abs(Math.Sin(col)) * col;
                    value2 = (float)Math.Abs(Math.Sin(row)) * col;
                    pixels0.SetValue(Convert.ToByte(value0), col, row);
                    pixels1.SetValue(Convert.ToByte(value1), col, row);
                    pixels2.SetValue(Convert.ToByte(value2), col, row);
                }
            }
            pPixelBlock3.set_PixelData(0, pixels0);
            pPixelBlock3.set_PixelData(1, pixels1);
            pPixelBlock3.set_PixelData(2, pixels2);
            //将像素块写回栅格数据集
            IRasterEdit pRasterEdit = pRaster as IRasterEdit;
            pRasterEdit.Write(pnt, (IPixelBlock)pPixelBlock3);
            pRasterEdit.Refresh();
            return rasterDataset;
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
            // TODO: Add CmdCreatRaster.OnClick implementation
            // TODO: Add RasterCmd.OnClick implementation
            string pRasterFileName = null;
            string pPath = null;
            string pFileName = null;
            //调用系统“保存文件”窗体
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = " (*.tif)|*.tif ";
            saveFileDialog.Title = "选择栅格数据存放位置";
            saveFileDialog.FilterIndex = 1;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取栅格数据的保存路径和栅格数据名称
                pRasterFileName = saveFileDialog.FileName;
                if (pRasterFileName == "")
                    return;
                //获取栅格数据的保存路径
                pPath = System.IO.Path.GetDirectoryName(pRasterFileName);
                //获取栅格数据的名称
                pFileName = System.IO.Path.GetFileName(pRasterFileName);
                IRasterDataset pRasterDataset = CreatRasterDS(pPath, pFileName);
                //将栅格数据集添加到当前地图中
                IRasterLayer pRasterLayer = new RasterLayerClass();
                pRasterLayer.CreateFromDataset(pRasterDataset);
                m_hookHelper.FocusMap.AddLayer((ILayer)pRasterLayer);
                m_hookHelper.ActiveView.Extent =
        m_hookHelper.ActiveView.FullExtent;
            }

        }

        #endregion
    }
}
