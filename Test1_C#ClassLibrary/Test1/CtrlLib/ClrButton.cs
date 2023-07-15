using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtrlLib
{
    public partial class ClrButton : Button
    {
        public ClrButton()
        {
            InitializeComponent();
        }
        private Color m_color1 = Color.LightBlue;//第1个颜色
        private Color m_color2 = Color.DarkRed;//第2个颜色
        private int m_color1Transparent = 50;//第1个颜色透明度
        private int m_color2Transparent = 50;//第2个颜色透明度
        public Color cuteColor1
        {
            get { return m_color1; }
            set { m_color1 = value; Invalidate(); }
        }
        public Color cuteColor2
        {
            get { return m_color2; }
            set { m_color2 = value; Invalidate(); }
            // Invalidate()为刷新窗口
        }
        public int cuteTransparent1
        {
            get { return m_color1Transparent; }
            set { m_color1Transparent = value; Invalidate(); }
        }
        public int cuteTransparent2
        {
            get { return m_color2Transparent; }
            set { m_color2Transparent = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            //创建两个半透明颜色
            Color c1 = Color.FromArgb(m_color1Transparent, m_color1);
            Color c2 = Color.FromArgb(m_color2Transparent, m_color2);
            //构建线性渐变画刷对象
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(
                                            ClientRectangle, c1, c2, 10);
            //用渐变色填充控件矩形客户区
            pe.Graphics.FillRectangle(b, ClientRectangle);
            //释放画刷资源
            b.Dispose();
        }
    }
}
