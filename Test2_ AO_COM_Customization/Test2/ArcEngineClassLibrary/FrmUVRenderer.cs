using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace ArcEngineClassLibrary
{
    public partial class FrmUVRenderer : Form
    {
        private IHookHelper m_hookhelper = null;
        private IActiveView m_activeView = null;
        private IMap m_map = null;
        private IFeatureLayer m_layer2Symbolize = null;
        string strRendererField = string.Empty;
        public FrmUVRenderer(IHookHelper hook)
        {
            m_hookhelper = hook;
            m_activeView = m_hookhelper.ActiveView;
            m_map = m_hookhelper.FocusMap;
            InitializeComponent();
        }

        private void FrmUVRenderer_Load(object sender, EventArgs e)
        {
            CbxLayersAddItems();
        }
        //将图层列表添加到组合框
        private void CbxLayersAddItems()
        {
            if (GetLayers() == null) return;
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IFeatureLayer)
                {
                    cbxLayers2Symbolize.Items.Add(layer.Name);
                }
                layer = layers.Next();
            }
        }
        //获得当前地图的要素图层列表
        private IEnumLayer GetLayers()
        {
            UID uid = new UIDClass();
            // 接口IFeatureLayer的IID
            uid.Value = "{40A9E885-5533-11d0-98BE-00805F7CED21}";
            if (m_map.LayerCount != 0)
            {
                IEnumLayer layers = m_map.get_Layers(uid, true);
                return layers;
            }
            return null;
        }

        private void cbxLayers2Symbolize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxLayers2Symbolize.SelectedItem != null)
            {
                string strLayer2Symbolize =
        cbxLayers2Symbolize.SelectedItem.ToString();
                //获得选择到的图层
                m_layer2Symbolize = GetFeatureLayer(strLayer2Symbolize);
                CbxFieldsAdditems(m_layer2Symbolize);
                strRendererField = cbxFields.Items[0].ToString();
                cbxFields.Text = strRendererField;
            }
        }
        private IFeatureLayer GetFeatureLayer(string layerName)
        {
            //get the layers from the maps
            if (GetLayers() == null) return null;
            IEnumLayer layers = GetLayers();
            layers.Reset();
            ILayer layer = null;
            while ((layer = layers.Next()) != null)
            {
                if (layer.Name == layerName)
                    return layer as IFeatureLayer;
            }
            return null;
        }
        //添加字段列表到组合框
        private void CbxFieldsAdditems(IFeatureLayer featureLayer)
        {
            IFields fields = featureLayer.FeatureClass.Fields;
            IField field = null;
            cbxFields.Items.Clear();
            for (int i = 0; i < fields.FieldCount; i++)
            {
                field = fields.get_Field(i);
                if (field.Type != esriFieldType.esriFieldTypeGeometry)
                    cbxFields.Items.Add(field.Name);
            }
        }

        private void btnSymbolize_Click(object sender, EventArgs e)
        {
            if (m_layer2Symbolize == null) return;
            Renderer();
        }
        //唯一值渲染
        private void Renderer()
        {
            IGeoFeatureLayer pGeoFeatureL = (IGeoFeatureLayer)m_layer2Symbolize;
            IFeatureClass featureClass = pGeoFeatureL.FeatureClass;
            string strRendererField = string.Empty;
            strRendererField = cbxFields.SelectedItem.ToString();
            //找出rendererField在字段中的编号 
            int lfieldNumber = featureClass.FindField(strRendererField);
            if (lfieldNumber == -1)
            {
                MessageBox.Show("Can't find field called " + strRendererField);
                return;
            }
            IUniqueValueRenderer pUniqueValueR = CreateRenderer(featureClass);
            if (pUniqueValueR == null) return;
            pGeoFeatureL.Renderer = (IFeatureRenderer)pUniqueValueR;
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, m_activeView.Extent);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //创建唯一值渲染器
        private IUniqueValueRenderer CreateRenderer(IFeatureClass featureClass)
        {
            int uniqueValuesCount = GetUniqueValuesCount(featureClass,
         strRendererField);
            System.Collections.IEnumerator enumerator = GetUniqueValues(
        featureClass, strRendererField);
            if (uniqueValuesCount == 0) return null;
            IEnumColors pEnumRamp =
        GetEnumColorsByRandomColorRamp(uniqueValuesCount);
            pEnumRamp.Reset();
            IUniqueValueRenderer pUniqueValueR = new UniqueValueRendererClass();
            //只用一个字段进行单值着色
            pUniqueValueR.FieldCount = 1;
            //用于区分着色的字段
            pUniqueValueR.set_Field(0, strRendererField);
            IColor pColor = null;
            ISymbol symbol = null;
            enumerator.Reset();
            while (enumerator.MoveNext())
            {
                object codeValue = enumerator.Current;
                pColor = pEnumRamp.Next();
                switch (featureClass.ShapeType)//不同的要素图层类型
                {
                    case esriGeometryType.esriGeometryPoint: //点
                        ISimpleMarkerSymbol markerSymbol = new
        SimpleMarkerSymbolClass() as ISimpleMarkerSymbol;
                        markerSymbol.Color = pColor;
                        symbol = markerSymbol as ISymbol;
                        break;
                    case esriGeometryType.esriGeometryPolyline: //线
                        ISimpleLineSymbol lineSymbol = new
         SimpleLineSymbolClass() as ISimpleLineSymbol;
                        lineSymbol.Color = pColor;
                        symbol = lineSymbol as ISymbol;
                        break;
                    case esriGeometryType.esriGeometryPolygon: //多边形
                        ISimpleFillSymbol fillSymbol = new
        SimpleFillSymbolClass() as ISimpleFillSymbol;
                        fillSymbol.Color = pColor;
                        symbol = fillSymbol as ISymbol;
                        break;
                    default:
                        break;
                }
                //将每次得到的要素字段值和修饰它的符号放入着色对象中
                pUniqueValueR.AddValue(codeValue.ToString(),
         strRendererField, symbol);
            }
            return pUniqueValueR;
        }
        //使用数据统计组件对象获得字段的唯一值列表
        private System.Collections.IEnumerator GetUniqueValues(
        IFeatureClass featureClass, string strField)
        {
            ICursor cursor = (ICursor)featureClass.Search(null, false);
            IDataStatistics dataStatistics = new DataStatisticsClass();
            dataStatistics.Field = strField;
            dataStatistics.Cursor = cursor;
            System.Collections.IEnumerator enumerator = dataStatistics.UniqueValues;
            return enumerator;
        }
        //使用数据统计组件对象获得字段的唯一值的个数
        private int GetUniqueValuesCount(IFeatureClass featureClass, string strField)
        {
            ICursor cursor = (ICursor)featureClass.Search(null, false);
            IDataStatistics dataStatistics = new DataStatisticsClass();
            dataStatistics.Field = strField;
            dataStatistics.Cursor = cursor;
            System.Collections.IEnumerator enumerator = dataStatistics.UniqueValues;
            return dataStatistics.UniqueValueCount;
        }
        //生成一个颜色列表，用于唯一值渲染
        private IEnumColors GetEnumColorsByRandomColorRamp(int colorSize)
        {
            IRandomColorRamp pColorRamp = new RandomColorRampClass();
            //起始和终止颜色
            pColorRamp.StartHue = 0;
            pColorRamp.EndHue = 360;
            pColorRamp.MinSaturation = 15;
            pColorRamp.MaxSaturation = 30;
            pColorRamp.MinValue = 99;
            pColorRamp.MaxValue = 100;
            pColorRamp.Size = colorSize;
            bool ok = true;
            pColorRamp.CreateRamp(out ok);
            IEnumColors pEnumRamp = pColorRamp.Colors;
            pEnumRamp.Reset();
            return pEnumRamp;
        }

    }
}
