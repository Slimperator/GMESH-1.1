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
        private double[] CutParams;
        private int countPointsParentCurve;
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
        public SubCurve(ICurve mainCurve, double paramTBegin, double paramTEnd)
        {
            this.mainCurve = mainCurve;
            this.paramBegin = paramTBegin;
            this.paramEnd = paramTEnd;
            begin = this.mainCurve.getPoint(paramBegin);
            end = this.mainCurve.getPoint(paramEnd);
            this.Lenght = mainCurve.lenght;
            Initialize();
        }
        public SubCurve(ICurve mainCurve, IPoint Begin, IPoint End)
        {
            this.mainCurve = mainCurve;
            this.paramBegin = mainCurve.cutParams[mainCurve.cutPoints.ToList().FindIndex(x => x.x == Begin.x && x.y == Begin.y)];
            this.paramEnd = mainCurve.cutParams[mainCurve.cutPoints.ToList().FindIndex(x => x.x == End.x && x.y == End.y)];
            begin = Begin;
            end = End;
            this.Lenght = mainCurve.lenght;
            Initialize();
        }
        private void Initialize()
        {
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
            List<double> pt = new List<double>();

            for (int i = 0; i < mainCurve.cutParams.Length; i++)
            {
                if (mainCurve.cutParams[i] >= min && mainCurve.cutParams[i] <= max)
                {
                    pt.Add(mainCurve.cutParams[i]);
                    ps.Add(mainCurve.cutPoints[i]);
                }
            }
                
            CutParams = pt.ToArray();
            CutPoints = ps.ToArray();
        }
        public IPoint getPoint(double t)
        {
            if (notifyParent())//если кривая родитель поменялась, тогда обновляем данные
                Initialize();
            return this.mainCurve.getPoint(t * (max - min) + min);
        }

        public IPoint[] cutPoints
        {
            get
            {
                if (notifyParent())//если кривая родитель поменялась, тогда обновляем данные
                    Initialize();
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
        //Функция проверяет, не изменился ли кривая-родитель. Если кривая родитель изменилась, тогда возвращает true
        private bool notifyParent()
        {
            bool changeFlag = false;
            if (mainCurve.cutPoints.Length != countPointsParentCurve)
                return true;
            foreach (IPoint p in this.CutPoints)
            {
                if (Array.IndexOf(mainCurve.cutPoints,p) == -1)
                    changeFlag = true;
            }
            return changeFlag;
        }
    }
}
