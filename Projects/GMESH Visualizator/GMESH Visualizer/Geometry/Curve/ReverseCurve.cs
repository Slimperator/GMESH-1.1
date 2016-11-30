using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Curve
{
    public class ReverseCurve : ICurve
    {
        private ICurve curve;
        private IPoint[] CutPoints;
        private double[] CutParams;

        public ReverseCurve()
        {
            this.curve = null;
            this.CutParams = null;
            this.CutPoints = null;
        }

        public ReverseCurve(ICurve curve)
        {
            this.curve = curve;
            this.CutPoints = new IPoint[this.curve.cutPoints.Length];
            this.CutParams = new double[this.curve.cutParams.Length];
            for (int i = 0; i < this.curve.cutPoints.Length; i++)
            {
                this.CutPoints[i] = this.curve.cutPoints[this.curve.cutPoints.Length - 1 - i];
            }
            for (int i = 0; i < this.curve.cutParams.Length; i++)
            {
                this.CutParams[i] = this.curve.cutParams[this.curve.cutParams.Length - 1 - i];
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

        public IPoint getPoint(double t)
        {
            return this.curve.getPoint(1 - t);
        }

        public double lenght
        {
            get
            {
                return this.curve.lenght;
            }
            set
            {
                this.curve.lenght = value;
            }
        }
    }
}
