using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Point
{
    public class Point2D:IPoint
    {
        public double x { get; set; }
        public double y { get; set; }
        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
