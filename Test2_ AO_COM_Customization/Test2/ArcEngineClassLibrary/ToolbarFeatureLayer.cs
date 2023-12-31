using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.ADF.BaseClasses;

namespace ArcEngineClassLibrary
{
    /// <summary>
    /// Summary description for ToolbarFeatureLayer.
    /// </summary>
    [Guid("dcb6a31c-887e-4860-a77a-9cbd453c360c")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcEngineClassLibrary.ToolbarFeatureLayer")]
    public sealed class ToolbarFeatureLayer : BaseToolbar
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
            MxCommandBars.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            MxCommandBars.Unregister(regKey);
        }

        #endregion
        #endregion

        public ToolbarFeatureLayer()
        {
            //
            // TODO: Define your toolbar here by adding items
            AddItem("esriArcMapUI.ZoomInTool");
            BeginGroup(); //Separator
            AddItem("{FBF8C3FB-0480-11D2-8D21-080009EE4E51}", 1);
            AddItem(new Guid("FBF8C3FB-0480-11D2-8D21-080009EE4E51"), 2);
            BeginGroup();
            // 添加用户自定制的按钮和工具
            AddItem("ArcEngineClassLibrary.CmdUVRenderer");
            AddItem("ArcEngineClassLibrary.ToolPolygonSelect");
        }

        public override string Caption
        {
            get
            {
                //TODO: Replace bar caption
                return "My C# Toolbar";
            }
        }
        public override string Name
        {
            get
            {
                //TODO: Replace bar ID
                return "ToolbarFeatureLayer";
            }
        }
    }
}