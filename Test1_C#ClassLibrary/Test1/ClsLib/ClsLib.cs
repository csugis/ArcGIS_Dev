using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsLib
{
    public interface ICalculateAreaAndVolume
    {
        double dArea { get; }
        double dVolume { get; }
    }
    public class Circle //基类，不需要计算表面积和体积
    {
        protected double radius;
        public Circle(double r)
        {
            radius = r;
        }
        public double dRadius
        {
            get { return radius; }
            set { radius = value; }
        }
    }
    public class Sphere : Circle, ICalculateAreaAndVolume//球体类
    {
        public Sphere(double r) : base(r)
        {
        }
        public double dArea
        {
            get { return (4 * Math.PI * radius * radius); }
        }
        public double dVolume
        {
            get { return (4 * Math.PI * Math.Pow(radius, 3) / 3); }
        }
    }
    public class Cylinder : Circle, ICalculateAreaAndVolume//圆柱类
    {
        private double height;//高度字段
        public Cylinder(double r, double h) : base(r)
        {
            height = h;
        }
        public double dArea
        {
            get
            {
                return (2 * Math.PI * radius * radius
              + 2 * Math.PI * radius * height);
            }
        }
        public double dVolume
        {
            get { return (Math.PI * radius * radius * height); }
        }
        public double dHeight
        {
            get { return height; }
            set { height = value; }
        }
    }
    public class Cone : Circle, ICalculateAreaAndVolume//圆锥类
    {
        private double height;//高度字段
        public Cone(double r, double h) : base(r)
        {
            height = h;
        }
        public double dArea
        {
            get
            {
                return (Math.PI * radius * (radius
              + Math.Sqrt(height * height + radius * radius)));
            }
        }
        public double dVolume
        {
            get { return (Math.PI * radius * radius * height / 3); }
        }
        public double dHeight
        {
            get { return height; }
            set { height = value; }
        }
    }

}
