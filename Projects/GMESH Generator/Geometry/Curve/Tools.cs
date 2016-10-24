using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Curve
{
    public static class Tools
    {
        private static double h = 0.001;
        /// <summary>
        /// Метод вычисления длины кривой
        /// </summary>
        /// <param name="curve">Кривая, длина которой измеряется данным методом</param>
        /// <returns>Длина кривой</returns>
        public static double length(ICurve curve)
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

        public IPoint[] slittingCurve(double lenght, ICurve curve)
        {
            return null;
        }
    }
}
