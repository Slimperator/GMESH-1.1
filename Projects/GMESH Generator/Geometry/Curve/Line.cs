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
        public IPoint[] cutPoints
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public Line(IPoint l1, IPoint l2)
        {
            this.l1 = l1;
            this.l2 = l2;

        }

        public IPoint getPoint(double t)
        {
            return new Point.Point2D((1 - t) * this.l1.x + t * l2.x, (1 - t) * this.l1.y + t * l2.y);
        }
    }
}
