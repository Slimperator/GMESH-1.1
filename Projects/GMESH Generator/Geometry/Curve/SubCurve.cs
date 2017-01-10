using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Curve
{
    public class SubCurve : ICurve
    {
        private ICurve mainCurve;
        public IPoint begin { get; private set; }
        public IPoint end { get; private set; }
        private double paramBegin, paramEnd, max, min;
        private IPoint[] CutPoints = null;
        private double Lenght;
        private double[] CutParams = null;
        private int countPointsParentCurve;
        private List<ICurve> childs = new List<ICurve>();
        private bool reversFlag = false;

        public SubCurve(ICurve mainCurve, double paramTBegin, double paramTEnd)
        {
            this.mainCurve = mainCurve;
            this.paramBegin = paramTBegin;
            this.paramEnd = paramTEnd;
            begin = this.mainCurve.getPoint(paramBegin);
            end = this.mainCurve.getPoint(paramEnd);
            mainCurve.childCurves.Add(this);
            Initialize();
        }
        public SubCurve(ICurve mainCurve, IPoint Begin, IPoint End)
        {
            this.mainCurve = mainCurve;
            this.paramBegin = mainCurve.cutParams[mainCurve.cutPoints.ToList().FindIndex(x => x.x == Begin.x && x.y == Begin.y)];
            this.paramEnd = mainCurve.cutParams[mainCurve.cutPoints.ToList().FindIndex(x => x.x == End.x && x.y == End.y)];
            begin = Begin;
            end = End;
            mainCurve.childCurves.Add(this);
            Initialize();
        }
        ~SubCurve()
        {
            mainCurve.childCurves.Remove(this);
        }

        private void Initialize()
        {
            if (paramBegin > paramEnd)
            {
                reversFlag = true;
                max = paramBegin;
                min = paramEnd;
            }
            if (paramBegin < paramEnd)
            {
                reversFlag = false;
                max = paramEnd;
                min = paramBegin;
            }
            this.countPointsParentCurve = mainCurve.cutPoints.Length;
            List<IPoint> ps = new List<IPoint>();                   //формируем массив точек-разделителей на основе исходной кривой
            List<double> pt = new List<double>();

            for (int i = 0; i < mainCurve.cutParams.Length; i++)
            {
                if (mainCurve.cutParams[i] >= min && mainCurve.cutParams[i] <= max)
                {
                    pt.Add((mainCurve.cutParams[i] - min) / (max - min));
                    ps.Add(mainCurve.cutPoints[i]);
                }
            }
            CutParams = pt.ToArray();
            CutPoints = ps.ToArray();
            this.Lenght = Math.Round(Tools.length(this), 4);
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
                if (notifyParent())//если кривая родитель поменялась, тогда обновляем данные
                    Initialize();
                synchronizeCutPoints(value);
            }
        }
        public double[] cutParams
        {
            get
            {
                //if (notifyParent())//если кривая родитель поменялась, тогда обновляем данные
                    //Initialize();
                return this.CutParams;
            }
            set
            {
                synchronizeCutParams(value);
            }
        }
        public IPoint getPoint(double t)
        {
            if (notifyParent())//если кривая родитель поменялась, тогда обновляем данные
                Initialize();
            return this.mainCurve.getPoint(t * (max - min) + min);
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
        //Функция проверяет, не изменился ли кривая-родитель. Если кривая родитель изменилась, тогда возвращает true
        private bool notifyParent()
        {
            bool changeFlag = false;
            if ((mainCurve.cutPoints == null & this.countPointsParentCurve!=0) || mainCurve.cutPoints.Length != countPointsParentCurve)
                return true;
            foreach (IPoint p in this.CutPoints)
            {
                if (Array.IndexOf(mainCurve.cutPoints, p) == -1)
                    changeFlag = true;
            }
            return changeFlag;
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
        private void synchronizeCutParams(double[] newParams)
        {
            int indexBegin;
            List<double> oldMainParams = new List<double>();
            List<double> oldThisParams;
            if ((mainCurve.cutParams == null || mainCurve.cutParams.Length == 0) && ((newParams != null) && (newParams.Length != 0)))
            {
                oldMainParams = newParams.ToList();
                for (int i = 0; i < oldMainParams.Count; i++)
                    oldMainParams[i] = oldMainParams[i] * (max - min) + min;
            }
            else
            {
                oldMainParams = mainCurve.cutParams.ToList();
                if (!reversFlag)
                {
                    if (this.CutParams != null && this.CutParams.Length != 0)
                    {
                        oldThisParams = this.CutParams.ToList();
                        //приводим параметры отрезка к параметрам родительской кривой.
                        for (int i = 0; i < oldThisParams.Count; i++)
                            oldThisParams[i] = oldThisParams[i] * (max - min) + min;
                        //находим элемент, с которого начинается массив элементов отрезка в родительской кривой
                        indexBegin = oldMainParams.IndexOf(oldThisParams[0]);
                        //удаляем все старые элементы из родительской кривой и вставляем новые
                        oldMainParams.RemoveRange(indexBegin, oldThisParams.Count);
                    }
                    else
                    {
                        //если отрезок был пуст, то находим индекс вхождения в массив родителя при помощи сопоставления индекса начала отрезка
                        //и существующих индексов в родителе
                        indexBegin = Array.FindLastIndex(mainCurve.cutParams, t => t < paramBegin);
                        //если мы не нашли в родителе ничего, удовлетворяющего нашему условию, то вставляем с нуля 
                        indexBegin = indexBegin == -1 ? 0 : indexBegin;
                    }
                    //если нечего вставлять, то просто удаляем точки
                    if (newParams != null)
                        if (newParams.Length != 0)
                        {
                            List<double> newMainParams = newParams.ToList();
                            for (int i = 0; i < newMainParams.Count; i++)
                                newMainParams[i] = newMainParams[i] * (max - min) + min;
                            //если индекс начала указывает на нулевой элемент, то вставляем сначала. Иначе, с предыдущего места коллекции
                            if (indexBegin == 0)
                                oldMainParams.InsertRange(indexBegin, newMainParams);
                            else
                                oldMainParams.InsertRange(indexBegin - 1, newMainParams);
                        }
                }
                else
                {
                    if (this.CutParams != null && this.CutParams.Length != 0)
                    {
                        oldThisParams = this.CutParams.ToList();
                        //приводим параметры отрезка к параметрам родительской кривой.
                        for (int i = 0; i < oldThisParams.Count; i++)
                            oldThisParams[i] = oldThisParams[i] * (max - min) + min;
                        //находим элемент, с которого начинается массив элементов отрезка в родительской кривой
                        indexBegin = oldMainParams.LastIndexOf(oldThisParams[0]);
                        //удаляем все старые элементы из родительской кривой и вставляем новые
                        oldMainParams.RemoveRange(indexBegin - (oldThisParams.Count - 1), oldThisParams.Count);
                    }
                    else
                    {
                        //если отрезок был пуст, то находим индекс вхождения в массив родителя при помощи сопоставления индекса начала отрезка
                        //и существующих индексов в родителе
                        indexBegin = Array.FindIndex(mainCurve.cutParams, t => t > paramBegin);
                        //если мы не нашли в родителе ничего, удовлетворяющего нашему условию, то вставляем с конца 
                        indexBegin = indexBegin == -1 ? mainCurve.cutParams.Length - 1 : indexBegin;
                    }
                    //если нечего вставлять, то просто удаляем точки
                    if (newParams != null)
                        if (newParams.Length != 0)
                        {
                            List<double> newMainParams = newParams.ToList();
                            for (int i = 0; i < newMainParams.Count; i++)
                                newMainParams[i] = newMainParams[i] * (max - min) + min;
                            //если индекс начала указывает на нулевой элемент, то вставляем сначала. Иначе, с предыдущего места коллекции
                            if (indexBegin - (this.CutParams.Length - 1) == 0)
                                oldMainParams.InsertRange(indexBegin - (this.CutParams.Length - 1), newMainParams);
                            else
                                oldMainParams.InsertRange(indexBegin - (this.CutParams.Length - 1) - 1, newMainParams);
                        }
                }
            }
            mainCurve.cutParams = oldMainParams.ToArray();
            this.CutParams = newParams;
        }
        private void synchronizeCutPoints(IPoint[] newPoints)
        {
            int indexBegin;
            List<IPoint> oldMainPoints = new List<IPoint>();
            if ((mainCurve.cutPoints == null || mainCurve.cutPoints.Length == 0) && (newPoints != null && newPoints.Length != 0))
            {
                oldMainPoints = newPoints.ToList();
            }
            else
            {
                oldMainPoints = mainCurve.cutPoints.ToList();
                if (!reversFlag)
                {
                    if (this.CutPoints != null && this.CutPoints.Length != 0)
                    {
                        //находим элемент, с которого начинается массив элементов отрезка в родительской кривой
                        indexBegin = oldMainPoints.IndexOf(this.CutPoints[0]);
                        //удаляем все старые элементы из родительской кривой и вставляем новые
                        oldMainPoints.RemoveRange(indexBegin, this.CutPoints.Length);
                    }
                    else
                    {   //если отрезок был пуст, то находим индекс вхождения в массив родителя при помощи сопоставления индекса начала отрезка
                        //и существующих индексов в родителе
                        indexBegin = Array.FindLastIndex(mainCurve.cutParams, t => t < paramBegin);
                        //если мы не нашли в родителе ничего, удовлетворяющего нашему условию, то вставляем с нуля 
                        indexBegin = indexBegin == -1 ? 0 : indexBegin;
                    }
                    //если нечего вставлять, то просто удаляем точки
                    if (newPoints != null)
                        if (newPoints.Length != 0)
                            if (indexBegin == 0)
                                oldMainPoints.InsertRange(indexBegin, newPoints);
                            else
                                oldMainPoints.InsertRange(indexBegin - 1, newPoints);
                }
                else
                {
                    if (this.CutPoints != null && this.CutPoints.Length != 0)
                    {
                        //находим элемент, с которого начинается массив элементов отрезка в родительской кривой
                        indexBegin = oldMainPoints.LastIndexOf(this.CutPoints[0]);
                        //удаляем все старые элементы из родительской кривой и вставляем новые
                        oldMainPoints.RemoveRange(indexBegin - (this.CutPoints.Length - 1), this.CutPoints.Length);
                    }
                    else
                    {   //если отрезок был пуст, то находим индекс вхождения в массив родителя при помощи сопоставления индекса начала отрезка
                        //и существующих индексов в родителе
                        indexBegin = Array.FindIndex(mainCurve.cutParams, t => t > paramBegin);
                        //если мы не нашли в родителе ничего, удовлетворяющего нашему условию, то вставляем с конца 
                        indexBegin = indexBegin == -1 ? mainCurve.cutParams.Length - 1 : indexBegin;
                    }
                    //если нечего вставлять, то просто удаляем точки
                    if (newPoints != null)
                        if (newPoints.Length != 0)
                            if (indexBegin - (this.CutPoints.Length - 1) == 0)
                                oldMainPoints.InsertRange(indexBegin - (this.CutPoints.Length - 1), newPoints);
                            else
                                oldMainPoints.InsertRange(indexBegin - (this.CutPoints.Length - 1) - 1, newPoints);
                }
            }
            mainCurve.cutPoints = oldMainPoints.ToArray();
            this.CutPoints = newPoints;
        }
    }
}
