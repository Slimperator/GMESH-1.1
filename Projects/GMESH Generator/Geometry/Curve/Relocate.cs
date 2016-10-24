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

        IPoint[] ICurve.cutPoints
        {
            get { return this.cutPoints; }
        }
        public Relocate(ICurve curve, IPoint newA, IPoint newB)
        {
            this.newA = newA;
            this.newB = newB;
            this.curve = curve;
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
    }
}
