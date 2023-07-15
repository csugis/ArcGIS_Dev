using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;


namespace Test4
{
    public partial class FrmClassSymbol : Form
    {

        private IHookHelper m_hookHelper = null;
        private ITOCControl m_tocControl = null;
        private IFeatureLayer m_layer = null;
        private string m_strRendererField = string.Empty;
        private int m_classCount = 5; //默认初始分级数为5

        public FrmClassSymbol(object hook, ITOCControl toc, IFeatureLayer layer)
        {
            InitializeComponent();
            //定义带有地图对象参数、ITOCControl参数和图层参数的构造函数
            m_layer = layer;
            if (m_hookHelper == null)
                m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;
            m_tocControl = toc;

        }

        private void FrmClassSymbol_Load(object sender, EventArgs e)
        {
            //该窗体加载完成时就已经将选中图层的属性字段加载进ComboBox
            CbxFieldsAdditems(m_layer as IFeatureLayer);

        }
        private void CbxFieldsAdditems(IFeatureLayer featureLayer)
        {
            IFields fields = featureLayer.FeatureClass.Fields;
            //将属性为以下几个类型的字段添加进ComboBox控件
            for (int i = 0; i < fields.FieldCount; i++)
            {
                if ((fields.get_Field(i).Type == esriFieldType.esriFieldTypeDouble) ||
                  (fields.get_Field(i).Type == esriFieldType.esriFieldTypeInteger) ||
                  (fields.get_Field(i).Type == esriFieldType.esriFieldTypeSingle) ||
                  (fields.get_Field(i).Type == esriFieldType.esriFieldTypeSmallInteger))
                {
                    cbxFields.Items.Add(fields.get_Field(i).Name);
                }
            }
            cbxFields.SelectedIndex = 0;
        }

        private void cbxFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFields.SelectedItem != null)
            {
                m_strRendererField = cbxFields.SelectedItem.ToString();
                //在要素图层中找到选中的字段
                IFeatureClass featureClass = m_layer.FeatureClass;
                IField field = featureClass.Fields.get_Field(featureClass.FindField
        (m_strRendererField));
                //创建一个游标
                ICursor cursor = (ICursor)m_layer.Search(null, false);
                //创建一个数据统计对象并初始化其属性
                IDataStatistics dataStatistics = new DataStatisticsClass();
                dataStatistics.Field = field.Name;
                dataStatistics.Cursor = cursor;
                //得到统计结果
                IStatisticsResults statisticsResults = dataStatistics.Statistics;
                //计算窗体上显示的该属性字段的最大值和最小值
                txtMinValue.Text = statisticsResults.Minimum.ToString();
                txtMaxValue.Text = statisticsResults.Maximum.ToString();
            }

        }

        private void btnSymbolize_Click(object sender, EventArgs e)
        {
            //获得分级数
            m_classCount = Convert.ToInt32(nudClassCount.Value);
            if (m_strRendererField == null)
                return;
            else
                Render(m_strRendererField, m_classCount);

        }
        private void Render(string RenderField, int classCount)
        {
            double[] classes;
            IGeoFeatureLayer pGeoFeatureLayer = m_layer as IGeoFeatureLayer;
            ITable pTable = pGeoFeatureLayer.FeatureClass as ITable;
            //Itable接口位于Geodatabase类库中
            ITableHistogram pTableHistogram = new BasicTableHistogramClass();
            IBasicHistogram pBasicHistogram = pTableHistogram as IBasicHistogram;
            pTableHistogram.Field = RenderField;
            pTableHistogram.Table = pTable;
            object dataValues;
            object dataFrequent;
            pBasicHistogram.GetHistogram(out dataValues, out dataFrequent);
            //获取FeatureClass中的dataValues和datafrequent
            IClassifyGEN pClassifyGEN = new EqualIntervalClass();
            //根据上面的dataValues和datafrequent进行分级，分级数为classcout
            pClassifyGEN.Classify(dataValues, dataFrequent, ref classCount);
            //获取分段点
            classes = (double[])pClassifyGEN.ClassBreaks;
            IClassBreaksRenderer pClassBreakRenderer = new ClassBreaksRenderer();
            //断点数
            pClassBreakRenderer.BreakCount = classCount;
            pClassBreakRenderer.Field = RenderField;
            //按顺序排列
            pClassBreakRenderer.SortClassesAscending = true;
            IAlgorithmicColorRamp pColorRamp = new AlgorithmicColorRampClass();
            //设置颜色
            IRgbColor pRgbColor1 = new RgbColorClass();
            IRgbColor pRgbColor2 = new RgbColorClass();
            pRgbColor1.Red = 178;
            pRgbColor1.Green = 34;
            pRgbColor1.Blue = 34;
            pRgbColor2.Red = 255;
            pRgbColor2.Green = 193;
            pRgbColor2.Blue = 193;
            pColorRamp.FromColor = pRgbColor2;//起始
            pColorRamp.ToColor = pRgbColor1;//终止
            pColorRamp.Size = classCount;//颜色带数目
            bool ok = true;
            pColorRamp.CreateRamp(out ok);
            IEnumColors pEnumColors = pColorRamp.Colors;
            for (int i = 0; i < classCount; i++)
            {
                IColor pColor = pEnumColors.Next();
                ISymbol pSymbol = GetSymbol(pColor);
                pClassBreakRenderer.set_Symbol(i, pSymbol);
                pClassBreakRenderer.set_Label(i, classes[i].ToString() + "-" +
        classes[i + 1].ToString());
                pClassBreakRenderer.set_Break(i, classes[i + 1]);
            }
            pGeoFeatureLayer.Renderer = pClassBreakRenderer as IFeatureRenderer;
            //更新地图
            m_hookHelper.ActiveView.PartialRefresh(
            esriViewDrawPhase.esriViewGeography, null, null);
            m_tocControl.Update();
        }
        //获得点、线、面符号
        private ISymbol GetSymbol(IColor pColor)
        {
            ISymbol sym = null;
            switch (m_layer.FeatureClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    sym = new SimpleMarkerSymbolClass();
                    //定义点状样式和颜色
                    ISimpleMarkerSymbol pMarkerSymbol = sym as ISimpleMarkerSymbol;
                    pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSSquare;
                    pMarkerSymbol.Color = pColor;
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    sym = new SimpleLineSymbolClass();
                    //定义线状样式和颜色
                    ISimpleLineSymbol pLineSymbol = sym as ISimpleLineSymbol;
                    pLineSymbol.Style = esriSimpleLineStyle.esriSLSDot;
                    pLineSymbol.Color = pColor;
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    sym = new SimpleFillSymbolClass();
                    //定义面状颜色
                    ISimpleFillSymbol pFillSymbol = sym as ISimpleFillSymbol;
                    pFillSymbol.Color = pColor;
                    break;
                default:
                    return null;
            }
            return sym;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
