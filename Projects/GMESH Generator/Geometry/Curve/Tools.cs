using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Curve
{
    public static class Tools
    {
        private static double h = 0.01;
        /// <summary>
        /// Метод вычисления длины кривой
        /// </summary>
        /// <param name="curve">Кривая, длина которой измеряется данным методом</param>
        /// <returns>Длина кривой</returns>
        public static double length(ICurve curve) //ХРАНИТЬ В КРИВОЙ, ВМЕСТО ПОСТОЯННЫХ ВЫЗОВОВ. Оптимизация
        {
            IPoint A, B;
            double result = 0.0;
            for (double t = 0; t < 1; t += h)
            {
                A = curve.getPoint(t);
                B = curve.getPoint(t + h);
                result += Math.Sqrt(Math.Pow(A.x - B.x, 2) + Math.Pow(A.y - B.y, 2));
            }
            return result;
        }
        /// <summary>
        /// Метод вычисляет параметр t, соответствующий длине части дуги
        /// </summary>
        /// <param name="curve">Кривая, для которой вычисляется параметр</param>
        /// <param name="length">Длина, соответствующая искомому параметру</param>
        /// <returns>Параметр t</returns>
        public static double getParam(ICurve curve, double length)
        {
            return length / Tools.length(curve);
        }
        public static void slittingCurve(double length, ICurve curve)
        {
            curve.lenght = length;
            List<IPoint> cutPoints = new List<IPoint>();
            List<double> param = new List<double>();
            double d = Tools.length(curve);
            double i = 0.0;
            for (; i <= d; i += length)             //добавить =
            {
                param.Add(getParam(curve, i));
                cutPoints.Add(curve.getPoint(getParam(curve, i)));
            }
            if (d - i == 0)                                 //если остатка у линии нет, то возвращаем найденные точки    
            {
                curve.cutPoints = cutPoints.ToArray();
                curve.cutParams = param.ToArray();
            }
            if (d - i >= length / 2)                         //если остаток больше половины длины ячейки, то делаем длину меньше, количество точек увеличиваем на 1
                slittingCurve(cutPoints.Count() + 1, curve);
            else
                slittingCurve(cutPoints.Count(), curve);     //если остаток меньше половины длины ячейки, то делаем длину больше, количество точек не меняется
        }
        public static void slittingCurve(int points, ICurve curve)
        {
            double tOfPart = (double)1 / (points - 1);
            List<IPoint> cutPoints = new List<IPoint>();
            List<double> param = new List<double>();
            double d = Tools.length(curve);
            for (double i = 0; i <= 1; i += tOfPart)              //добавить =
            {
                param.Add(i);
                cutPoints.Add(curve.getPoint(i));
            }
            if (cutPoints.Count != points)
            {
                param.Add(1);
                cutPoints.Add(curve.getPoint(1));
            }
            curve.cutPoints = cutPoints.ToArray();
            curve.cutParams = param.ToArray();
        }
        /// <summary>
        /// Метод проверяет две кривые на равенство. В том числе, если кривая перевернута
        /// </summary>
        public static bool equalityCurves(ICurve curve1, ICurve curve2)
        {
            bool straight = true, forward = true;
            if (curve1.cutPoints.Length != curve2.cutPoints.Length)
            {
                return false;
            }
            for (int i = 0; i < curve1.cutPoints.Length; i++)
            {
                if (curve1.cutPoints[i] != curve2.cutPoints[i])
                {
                    straight = false;
                }
                if (curve1.cutPoints[i] != curve2.cutPoints[curve2.cutPoints.Length - 1 - i])
                {
                    forward = false;
                }
                if (straight == false && forward == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
