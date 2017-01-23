using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Curve
{
    public class ReverseCurve : ICurve
    {
        private ICurve curve;
        private IPoint[] CutPoints = new IPoint[0];
        private double[] CutParams = new double[0];
        private double Lenght;
        private bool synchronizeFlag = false;
        private List<ICurve> childs = new List<ICurve>();

        public ReverseCurve()
        {
            this.curve = null;
            this.CutParams = null;
            this.CutPoints = null;
        }
        public ReverseCurve(ICurve curve)
        {
            this.curve = curve;
            this.lenght = curve.lenght;
            synchronizeCutPoints(curve, this);
            synchronizeCutParams(curve, this);
        }

        private void synchronizeCutPoints(ICurve parent, ICurve child)
        {
            synchronizeFlag = true;
            if (parent.cutPoints == null)
                child.cutPoints = null;
            else
            {
                child.cutPoints = new IPoint[parent.cutPoints.Length];
                for (int i = 0; i < parent.cutPoints.Length; i++)
                {
                    child.cutPoints[i] = parent.cutPoints[parent.cutPoints.Length - 1 - i];
                }
            }
            synchronizeFlag = false;
        }
        private void synchronizeCutParams(ICurve parent, ICurve child)
        {
            synchronizeFlag = true;
            if (parent.cutParams == null)
                child.cutParams = null;
            else
            {
                child.cutParams = new double[parent.cutParams.Length];
                for (int i = 0; i < parent.cutParams.Length; i++)
                {
                    child.cutParams[i] = parent.cutParams[parent.cutParams.Length - 1 - i];
                }
            }
            synchronizeFlag = false;
        }
        public IPoint getPoint(double t)
        {
            return this.curve.getPoint(1 - t);
        }
        public IPoint[] cutPoints
        {
            get
            {
                if (!synchronizeFlag)
                    synchronizeCutPoints(curve, this);
                return this.CutPoints;
            }
            set
            {
                this.CutPoints = value;
                if (!synchronizeFlag)
                    synchronizeCutPoints(this, curve);
            }
        }
        public double[] cutParams
        {
            get
            {
                if (!synchronizeFlag)
                    synchronizeCutParams(curve, this);
                return this.CutParams;
            }
            set
            {
                this.CutParams = value;
                if (!synchronizeFlag)
                    synchronizeCutParams(this, curve);
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
