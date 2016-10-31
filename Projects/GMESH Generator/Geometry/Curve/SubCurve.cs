using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Curve
{
    public class SubCurve: ICurve
    {
        private ICurve mainCurve;
        public IPoint begin { get; private set; }
        public IPoint end { get; private set; }
        private double paramBegin, paramEnd, max, min;
        private IPoint[] CutPoints;
        private double Lenght;
 
        public SubCurve(ICurve mainCurve, double paramTBegin, double paramTEnd)
        {
            this.mainCurve = mainCurve;
            this.paramBegin = paramTBegin;
            this.paramEnd = paramTEnd;
            begin = this.mainCurve.getPoint(paramBegin);
            end = this.mainCurve.getPoint(paramEnd);
            this.Lenght = mainCurve.lenght;
            if (paramBegin > paramEnd) 
            {
                max = paramBegin; 
                min = paramEnd;
            }
            if (paramBegin < paramEnd) 
            { 
                max = paramEnd; 
                min = paramBegin;
            }
            List<IPoint> ps = new List<IPoint>();                   //формируем массив точек-разделителей на основе исходной кривой
            for (int i = 0; i < mainCurve.cutPoints.Length; i++)
            {
                if (Tools.getParam(mainCurve, i * Lenght) >= min && Tools.getParam(mainCurve, i * Lenght) <= max)
                    ps.Add(mainCurve.cutPoints[i]);
            }
            CutPoints = ps.ToArray();
        }
        public IPoint getPoint(double t)
        {
            return this.mainCurve.getPoint(t * (max - min) + min);
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
        double  ICurve.lenght
        {
	        get 
	        { 
		        return this.Lenght; 
	        }
	        set 
	        { 
		        throw new NotImplementedException(); 
	        }
        }
    }
}
