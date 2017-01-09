using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Curve
{
    public class Relocate:ICurve
    {
        private IPoint newA, newB;
        private ICurve curve;
        private IPoint[] cutPoints;
        private double Lenght;
        private double[] CutParams;
        private List<ICurve> childs = new List<ICurve>(); 

        public Relocate(ICurve curve, IPoint newA, IPoint newB)
        {
            this.newA = newA;
            this.newB = newB;
            this.curve = curve;
            this.lenght = Math.Round(Tools.length(this), 4);
        }

        public IPoint getPoint(double t)
        {
            IPoint A = this.curve.getPoint(0);
            IPoint B = this.curve.getPoint(1);
            IPoint NewPoint = this.curve.getPoint(t);
            NewPoint.x += (1 - t) * (this.newA.x - A.x) + t * (this.newB.x - B.x);
            NewPoint.y += (1 - t) * (this.newA.y - A.y) + t * (this.newB.y - B.y);
            return NewPoint;
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
        IPoint[] ICurve.cutPoints
        {
            get { return this.cutPoints; }
            set { this.cutPoints = value; }
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
