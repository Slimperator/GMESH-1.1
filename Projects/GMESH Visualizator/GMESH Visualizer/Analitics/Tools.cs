using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Analitics
{
    public class Tools
    {
        public static bool lineIntersectionCheck(IPoint a1, IPoint b1, IPoint a2, IPoint b2)
        {
            if (((a1.y - b1.y) * (b2.x - a2.x) - (a2.y - b2.y) * (b1.x - a1.x)) == 0 || (b2.x - a2.x) == 0)
                return false;
            else
            {
                double x = ((a1.x * b1.y - b1.x * a1.y) * (b2.x - a2.x) - (a2.x * b2.y - b2.x * a2.y) * (b1.x - a1.x)) / ((a1.y - b1.y) * (b2.x - a2.x) - (a2.y - b2.y) * (b1.x - a1.x));
                double y = ((a2.y - b2.y) * x - (a2.x * b2.y - b2.x * a2.y)) / (b2.x - a2.x);

                if (((a1.x <= x) && (b1.x >= x) && (a2.x <= x) && (b2.x >= x)) || ((a1.y <= y) && (b1.y >= y) && (a2.y <= y) && (b2.y >= y)))

                    return true;
                else
                    return false;
            }
        }
    }
}
