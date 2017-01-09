using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Contour
{
    public class Contour:IContour
    {
        public static double DefaultLenghtPart = 0;
        private ICurve[] Curves;
        private double LenghtOfPart = DefaultLenghtPart; //костылек :)
        public Contour(ICurve[] curves)
        {
            this.Curves = curves;
        }

        public int getSize()
        {
            return Curves.Length;
        }

        public ICurve this[int i]
        {
            get { return Curves[i]; }
            set { this.Curves[i] = value; }
        }

        public double lenghtOfPart
        {
            get
            {
                return LenghtOfPart;
            }
            set
            {
                this.LenghtOfPart = value;
            }
        }
    }
}
