using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Curve
{
    public class Morph:ICurve
    {
        private ICurve a;
        private ICurve b;
        private double alpha;
        private IPoint[] CutPoints = new IPoint[0];
        private double Lenght;
        private double[] CutParams = new double[0];
        private List<ICurve> childs = new List<ICurve>(); 
        public Morph(ICurve a, ICurve b, double alpha)
        {
            this.a = a;
            this.b = b;
            this.alpha = alpha;
            this.lenght = Math.Round(Tools.length(this), 4);
        }

        public IPoint getPoint(double t)
        {
            IPoint A = a.getPoint(1 - t);
            IPoint B = b.getPoint(t);
            return new Point.Point2D(this.alpha * A.x + (1 - this.alpha) * B.x, this.alpha * A.y + (1 - this.alpha) * B.y);
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
