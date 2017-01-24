using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Decompose;
using Generator;
using Geometry;
using Geometry.Contour;
using Geometry.Curve;
using Analyzer.Grade;

namespace Decompose.Pentagon
{
    public class PentagonDecTetraAndTri : IDecompose
    {
        List<IPoint> points;

        public IContour[] decompose(IContour contour)
        {
            points = new List<IPoint>();
            for (int i = 0; i < contour.getSize(); i++) { points.Add(contour[i].cutPoints[0]); }

            List<IContour> contours = new List<IContour>();
            double bestGrade = -1;//наилучшая оценка (для сравнения)
            int bestIndex = 0;//индекс "наилучшей комбинации"
            // у нас возможны 5 вариантов разбиения контура на 3-к и 4-к
            //в цикле перебираем все, и ищем разбиение с наивысшим показателем оценки качества
            for (int i = 0; i < 5; i++)
            {
                // Декомпозиция (разбиваем)
                // Треугольник
                ICurve c = new Line(points[2], points[0]); 
                Geometry.Curve.Tools.slittingCurve(contour.lenghtOfPart,c);
                contours.Add(new Contour(new ICurve[] {contour[0], contour[1], c}));  //!!!!!!!!!!!!!!
                ICurve b = new ReverseCurve(c);
                // Четырёхугольник
                contours.Add(new Contour(new ICurve[] {contour[2], contour[3], contour[4], b}));
                contours[0].lenghtOfPart = contour.lenghtOfPart;
                contours[1].lenghtOfPart = contour.lenghtOfPart;
                // считаем качество
                // Треугольник
                double contourGrade = 0;

                IDecompose tria = new Triangle.TriangleDecompose(); 
                IContour[] conts = tria.decompose(contours[0]);
                for (int z = 0; z < 3; z++)
                    contourGrade += new ArithmMeanGrade().calculate(conts[z][0].getPoint(0), conts[z][1].getPoint(0), 
                        conts[z][2].getPoint(0), conts[z][3].getPoint(0));

                // Четырёхугольник

                contourGrade += new ArithmMeanGrade().calculate(contours[1][0].getPoint(0), contours[1][1].getPoint(0),
                        contours[1][2].getPoint(0), contours[1][3].getPoint(0));
                contourGrade = contourGrade/4.0;

                if (contourGrade > bestGrade)
                {
                    bestGrade = contourGrade;
                    bestIndex = i;
                }

                // мешаем точки
                IPoint tmpPoint = points[0];
                points.RemoveAt(0);
                points.Add(tmpPoint);
            }

            // в соответствии с индексом восстанавливаем порядок точек
            for (int i = 0; i < bestIndex; i++)
            {
                IPoint tmpPoint = points[0];
                points.RemoveAt(0);
                points.Add(tmpPoint);
            }
            contours.Clear();

            ICurve c1 = new Line(points[2], points[0]);
            Geometry.Curve.Tools.slittingCurve(contour.lenghtOfPart, c1);
            contours.Add(new Contour(new ICurve[] { contour[0], contour[1], c1 }));
            ICurve b1 = new ReverseCurve(c1);
            contours.Add(new Contour(new ICurve[] { contour[2], contour[3], contour[4], b1 }));
            contours[0].lenghtOfPart = contour.lenghtOfPart;
            contours[1].lenghtOfPart = contour.lenghtOfPart;

            return contours.ToArray();
        }
    }
}