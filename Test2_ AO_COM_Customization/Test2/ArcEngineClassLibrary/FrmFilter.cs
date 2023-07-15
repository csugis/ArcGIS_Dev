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
using ESRI.ArcGIS.Geodatabase;

namespace ArcEngineClassLibrary
{
    public partial class FrmFilter : Form
    {
        private IHookHelper m_hookhelper = null;
        public FrmFilter(IHookHelper hook)
        {
            m_hookhelper = hook;
            InitializeComponent();
        }

        private void FrmFilter_Load(object sender, EventArgs e)
        {
            AddAllLayerstoComboBox(comboBoxLayers);
            if (comboBoxLayers.Items.Count != 0)
            {
                comboBoxLayers.SelectedIndex = 0;
                buttonOk.Enabled = true;
                buttonClear.Enabled = true;
                buttonApply.Enabled = true;
            }
        }
        //只添加当前地图中的所有图层到组合框中
        private void AddAllLayerstoComboBox(ComboBox combox)
        {
            try
            {
                combox.Items.Clear();
                int pLayerCount = m_hookhelper.FocusMap.LayerCount;
                if (pLayerCount > 0)
                {
                    combox.Enabled = true;//组合框可用
                    checkBoxShowVectorOnly.Enabled = true;//复选框可用
                    for (int i = 0; i <= pLayerCount - 1; i++)
                    {
                        if (checkBoxShowVectorOnly.Checked)
                        {
                            if (m_hookhelper.FocusMap.get_Layer(i) is IFeatureLayer)
                                //只添加矢量图层
                                combox.Items.Add(
                                m_hookhelper.FocusMap.get_Layer(i).Name);
                        }
                        else
                            combox.Items.Add(
                            m_hookhelper.FocusMap.get_Layer(i).Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void checkBoxShowVectorOnly_CheckedChanged(object sender, EventArgs e)
        {
            AddAllLayerstoComboBox(comboBoxLayers);
            if (comboBoxLayers.Items.Count != 0)
                comboBoxLayers.SelectedIndex = 0;
            listBoxFields.Items.Clear();
        }

        private void comboBoxLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxFields.Items.Clear();
            listBoxValues.Items.Clear();
            string strSelectedLayerName = comboBoxLayers.Text;
            IFeatureLayer pFeatureLayer;
            IDisplayTable pDisPlayTable;
            try
            {
                for (int i = 0; i <= m_hookhelper.FocusMap.LayerCount - 1; i++)
                {
                    if (m_hookhelper.FocusMap.get_Layer(i).Name == strSelectedLayerName)
                    {
                        if (m_hookhelper.FocusMap.get_Layer(i) is IFeatureLayer)
                        {
                            pFeatureLayer = m_hookhelper.FocusMap.get_Layer(i)
        as IFeatureLayer;
                            //获得当前选择的图层
                            pDisPlayTable = pFeatureLayer as IDisplayTable;                    //根据选择图层更新字段列表
                            for (int j = 0; j <=
                            pDisPlayTable.DisplayTable.Fields.FieldCount - 1;
                                                   j++)
                            {
                                listBoxFields.Items.Add(
                                pDisPlayTable.DisplayTable.Fields.get_Field(j).Name);
                            }
                        }
                        else
                        {
                            MessageBox.Show("您选择的图层不能进行属性查询! " +
          "请重新选择"); break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void listBoxFields_DoubleClick(object sender, EventArgs e)
        {
            textBoxWhereClause.SelectedText =
                listBoxFields.SelectedItem.ToString() + " ";
        }

        private void listBoxValues_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxValues_DoubleClick(object sender, EventArgs e)
        {
            textBoxWhereClause.SelectedText = " " + listBoxValues.SelectedItem.ToString();
        }

        private void buttonGetValue_Click(object sender, EventArgs e)
        {
            if (listBoxFields.Text == "")
                MessageBox.Show("请选择一个属性字段！");
            else
            {
                try
                {
                    //这个名字是选中的属性字段的名称
                    string strSelectedFieldName = listBoxFields.Text;
                    listBoxValues.Items.Clear();
                    label1.Text = "";
                    IFeatureCursor pFeatureCursor;
                    IFeatureClass pFeatureClass;
                    IFeature pFeature;
                    if (strSelectedFieldName != null)
                    {
                        pFeatureClass = (GetLayerByName(comboBoxLayers.Text)
        as IFeatureLayer).FeatureClass;
                        pFeatureCursor = pFeatureClass.Search(null, true);
                        pFeature = pFeatureCursor.NextFeature();
                        int index = pFeatureClass.FindField(strSelectedFieldName);
                        while (pFeature != null)
                        {
                            //获取当前要素pFeature的第index个字段的属性值
                            string strValue = pFeature.get_Value(index).ToString();
                            //如果需要去掉重复的值
                            if (checkBoxGetUniqueValue.Checked)
                            {
                                //如果属性值是字符型，则添加单引号' '，
                                //方便后面WhereClause格式设置
                                if (pFeature.Fields.get_Field(index).Type == esriFieldType.esriFieldTypeString)
                                    strValue = "'" + strValue + "'";
                                if (listBoxValues.FindStringExact(strValue) == ListBox.NoMatches)
                                {
                                    //将字段唯一值添加到listBoxValues组合框
                                    listBoxValues.Items.Add(strValue);
                                }
                            }
                            else//否则添加所有的值，不考虑有没有重复
                            {
                                if (pFeature.Fields.get_Field(index).Type ==
        esriFieldType.esriFieldTypeString)
                                    strValue = "'" + strValue + "'";
                                listBoxValues.Items.Add(strValue);
                            }
                            //获取下一个要素
                            pFeature = pFeatureCursor.NextFeature();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
        //由名字获取图层
        private ILayer GetLayerByName(string strLayerName)
        {
            ILayer pLayer = null;
            for (int i = 0; i <= m_hookhelper.FocusMap.LayerCount - 1; i++)
            {
                if (strLayerName == m_hookhelper.FocusMap.get_Layer(i).Name)
                { pLayer = m_hookhelper.FocusMap.get_Layer(i); break; }
            }
            return pLayer;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (textBoxWhereClause.Text == "")
            {
                MessageBox.Show("请生成查询语句！");
                return;
            }
            //通过位置查询窗口最小化
            this.WindowState = FormWindowState.Minimized; PerformAttributeFilter();
            this.WindowState = FormWindowState.Normal;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            PerformAttributeFilter();
            this.Dispose();
        }
        //进行查询过滤实现条件显示要素图层
        private void PerformAttributeFilter()
        {
            try
            {
                IFeatureLayer pFeatureLayer;
                pFeatureLayer = GetLayerByName(comboBoxLayers.
        SelectedItem.ToString()) as IFeatureLayer;
                IFeatureLayerDefinition fLyrDef = pFeatureLayer as
        IFeatureLayerDefinition;
                fLyrDef.DefinitionExpression = textBoxWhereClause.Text;
                m_hookhelper.ActiveView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("您的查询语句可能有误,请检查 | " +
        ex.Message);
                return;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxWhereClause.Clear();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            textBoxWhereClause.SelectedText = " = ";
        }

        private void buttonBig_Click(object sender, EventArgs e)
        {
            textBoxWhereClause.SelectedText = " > ";
        }
    }
}
