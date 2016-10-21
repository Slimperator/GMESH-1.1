using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Contour
{
    public class Contour:IContour
    {
        private ICurve[] curves;

        public Contour(ICurve[] curves)
        {
            this.curves = curves;
        }

        public int getSize()
        {
            return curves.Length;
        }

        public ICurve this[int i]
        {
            get { return curves[i]; }
        }
    }
}
