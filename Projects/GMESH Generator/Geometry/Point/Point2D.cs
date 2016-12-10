using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Point
{
    public class Point2D:IPoint, IEquatable<Point2D>, IComparable<Point2D> 
    {
        private double x;
        private double y;

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
        public bool Equals(Point2D other) 
        { 
            return this.x == other.x && this.y == other.y; 
        } 

        public int CompareTo(Point2D other) 
        { 
            if (this.x != other.x) return (int)Math.Sign(this.x - other.x); 
            return (int)Math.Sign(this.y - other.y); 
        } 
    }
}
