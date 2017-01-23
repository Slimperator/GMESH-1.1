using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Curve
{
    public class Line : ICurve
    {
        public IPoint l1 { get; private set; }
        public IPoint l2 { get; private set; }
        private IPoint[] CutPoints = new IPoint[0];
        private double Lenght;
        private double[] CutParams = new double[0];
        private List<ICurve> childs = new List<ICurve>(); 

        public Line(IPoint l1, IPoint l2)
        {
            this.l1 = l1;
            this.l2 = l2;
            this.lenght = Math.Round(Tools.length(this), 4);
        }

        public IPoint getPoint(double t)
        {
            return new Point.Point2D((1 - t) * this.l1.x + t * l2.x, (1 - t) * this.l1.y + t * l2.y);
        }
        public double[] cutParams
        {
            get
            {
                return this.CutParams;
            }
            set
            {
                this.CutParams = value;
            }
        }
        public double lenght
        {
            get
            {
                return this.Lenght;
            }
            private set
            {
                this.Lenght = value;
            }
        }
        public IPoint[] cutPoints
        {
            get
            {
                return this.CutPoints;
            }
            set
            {
                this.CutPoints = value;
            }
        }
        public List<ICurve> childCurves
        {
            get
            {
                return this.childs;
            }
            set
            {
                this.childs = value;
            }
        }
    }
}
