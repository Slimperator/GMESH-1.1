using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Point
{
    public class Point2D:IPoint
    {
        private double x;
        private double y;
        private int rate;

        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        double IPoint.x
        {
            get
            {
                return x;
            }
            set
            {
                this.x = value;
            }
        }

        double IPoint.y
        {
            get
            {
                return y;
            }
            set
            {
                this.y = value;
            }
        }
        int IPoint.rate
        {
            get
            {
                return rate;
            }
            set
            {
                this.rate = value;
            }
        }
    }
}
