﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Contour
{
    public class Contour:IContour
    {
        private ICurve[] Curves;
        private double LenghtOfPart;
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