using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClsLib;

namespace Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICalculateAreaAndVolume[] c = new ICalculateAreaAndVolume[3];
            try
            {
                double r = Convert.ToDouble(radius.Text);
                double h = Convert.ToDouble(height.Text);
                if (r <= 0 || h <= 0)
                {
                    throw new Exception("半径或高度不能小于等于0");
                }
                c[0] = new Sphere(r);
                sphereArea.Text = c[0].dArea.ToString();
                sphereVolume.Text = c[0].dVolume.ToString();
                c[1] = new Cylinder(r, h);
                cylinderArea.Text = c[1].dArea.ToString();
                cylinderVolume.Text = c[1].dVolume.ToString();
                c[2] = new Cone(r, h);
                coneArea.Text = c[2].dArea.ToString();
                coneVolume.Text = c[2].dVolume.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + "\n"
                    + err.Source + "\n"
                    + err.TargetSite + "\n"
                    + err.StackTrace);
            }

        }

        private void clrButton1_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in Controls)
            //找出当前controls内的所有TextBox
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }
        }
    }
}
