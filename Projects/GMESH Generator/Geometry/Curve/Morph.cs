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

        public Morph(ICurve a, ICurve b, double alpha)
        {
            this.a = a;
            this.b = b;
            this.alpha = alpha;
        }

        public IPoint getPoint(double t)
        {
            IPoint A = a.getPoint(1 - t);
            IPoint B = b.getPoint(t);
            return new Point.Point2D(this.alpha * A.x + (1 - this.alpha) * B.x, this.alpha * A.y + (1 - this.alpha) * B.y);
        }

        public IPoint[] cutPoints
        {
            get { throw new NotImplementedException(); }
        }

        public void slittingCurve(double lenght)
        {
            throw new NotImplementedException();
        }
    }
}
