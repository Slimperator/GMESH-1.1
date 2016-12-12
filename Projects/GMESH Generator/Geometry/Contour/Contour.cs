﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Contour
{
    public class Contour:IContour
    {
        public static double DefaultLenghtPart;
        private ICurve[] Curves;
        public static double LenghtOfPart = DefaultLenghtPart; //костылек :)
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
