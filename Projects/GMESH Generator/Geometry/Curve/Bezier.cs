﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Geometry.Curve
{
    public class Bezier : ICurve
    {
        public IPoint P0 { get; private set; }
        public IPoint P1 { get; private set; }
        public IPoint P2 { get; private set; }
        public IPoint P3 { get; private set; }
        private IPoint[] CutPoints = new IPoint[0];
        private double Lenght;
        private double[] CutParams = new double[0];
        private List<ICurve> childs = new List<ICurve>(); 

        public Bezier(IPoint P0, IPoint P1, IPoint P2, IPoint P3)
        {
            this.P0 = P0;
            this.P1 = P1;
            this.P2 = P2;
            this.P3 = P3;
            this.lenght = Math.Round(Tools.length(this), 4);
        }

        public IPoint getPoint(double t)
        {
            return new Point.Point2D(this.P0.x * (1 - t) * (1 - t) * (1 - t) + 3 * t * P1.x * (1 - t) * (1 - t) + 3 * t * t * P2.x * (1 - t) + t * t * t * P3.x,
                this.P0.y * (1 - t) * (1 - t) * (1 - t) + 3 * t * P1.y * (1 - t) * (1 - t) + 3 * t * t * P2.y * (1 - t) + t * t * t * P3.y);
        }
        public double[] cutParams
        {
            get
            {
                return this.CutParams;
            }
            set
            {
                this.CutParams = value;
            }
        }
        public double lenght
        {
            get
            {
                return this.Lenght;
            }
            private set
            {
                this.Lenght = value;
            }
        }
        public IPoint[] cutPoints
        {
            get
            {
                return this.CutPoints;
            }
            set
            {
                this.CutPoints = value;
            }
        }
        public List<ICurve> childCurves
        {
            get
            {
                return this.childs;
            }
            set
            {
                this.childs = value;
            }
        }
    }
}

