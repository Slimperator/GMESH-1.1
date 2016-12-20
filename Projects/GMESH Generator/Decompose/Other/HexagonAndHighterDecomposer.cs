using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using Analyzer;
using Generator;

namespace Decompose.Other
{
    public class HexagonAndHighterDecomposer: IDecompose
    {
        private List<IContour> bestContour = new List<IContour>();
        private double bestGrad;
        private IGrade gradeTool = new Analyzer.Grade.ArithmMeanGrade();
        private int size;

        public Geometry.IContour[] decompose(Geometry.IContour contour)
        {
            //проверяем, нужно ли количество углов
            size = contour.getSize();
            if (size < 6)
                return null;
            //формируем контура 
            for (int i = 0; i < size; i++)
            {
                List<IContour> Contours = new List<IContour>();
                Contours.AddRange(getNewContours(contour));
                double t = takeMyBreathAway(Contours);
                if (bestGrad < t)
                {
                    bestGrad = t;
                    bestContour = Contours;
                    contour = reformContour(1, contour);
                }
            }
            return bestContour.ToArray();
        }
        private IContour reformContour(int beginIndex, IContour contour)
        {
            //меняем индексацию контура
            List<ICurve> curves = new List<ICurve>();
            for (int i = beginIndex; i < contour.getSize(); i++)
                curves.Add(contour[i]);
            for (int i = 0; i < beginIndex; i++)
                curves.Add(contour[i]);
            return new Geometry.Contour.Contour(curves.ToArray());
        }
        private IContour[] getNewContours(IContour contour)
        {
            List<IContour> contours = new List<IContour>();
            //проводим линию между min+1 & max-1 точками контура
            ICurve newCurve = new Geometry.Curve.Line(contour[1].cutPoints[0], 
                contour[contour.getSize()-2].cutPoints[0]);
            //режем линию на кусочки
            Geometry.Curve.Tools.slittingCurve(contour.lenghtOfPart, newCurve);
            //формируем первый новый контур
            contours.Add(new Geometry.Contour.Contour
                (new ICurve[4] { contour[0], newCurve, contour[contour.getSize() - 2], contour[contour.getSize() - 1]}));
            //создаем линию с другим направлением, на основе новопроведенной
            ICurve newReversCurve = new Geometry.Curve.ReverseCurve(newCurve);
            //формируем оставшийся контур, без убранных линий
            List<ICurve> curvesForContourTwo = new List<ICurve>();
            for(int i = 1; i < contour.getSize() - 2; i++)
                curvesForContourTwo.Add(contour[i]);
            curvesForContourTwo.Add(newReversCurve);
            //если оставшаяся часть контура больше чем 4 угольник, то рекурсивно сново разбиваем контур, пока не докопаемся до истины
            if (curvesForContourTwo.Count > 4)
            {
                contours.AddRange(getNewContours(new Geometry.Contour.Contour(curvesForContourTwo.ToArray())));
            }
            else
                contours.Add(new Geometry.Contour.Contour(curvesForContourTwo.ToArray()));
            return contours.ToArray();
        }
        private double takeMyBreathAway(List<IContour> contours)
        {   //рассчитываем качество для всех контуров
            double grad = 0;
            foreach (IContour contour in contours)
                grad += gradeTool.calculate(contour[0].getPoint(0), contour[1].getPoint(0), 
                    contour[2].getPoint(0), contour[3].getPoint(0));
            return grad;
        }
    }
}
