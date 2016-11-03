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
                contours.Add(new Contour(new ICurve[] {contour[0], contour[1], c}));
                ICurve b = new Line(points[0], points[2]);
                Geometry.Curve.Tools.slittingCurve(contour.lenghtOfPart, b);
                // Четырёхугольник
                contours.Add(new Contour(new ICurve[] {contour[2], contour[3], contour[4], b}));

                // считаем качество
                // Треугольник
                double contourGrade = 0;
                //TODO: создать конкретные классы для IMeshGenerator
                IDecompose tria = new Triangle.TriangleDecompose(); // = new TriaMeshGen(10, 10);
                IMeshGenerator gen = new Generator.Generator();
                IContour[] conts = tria.decompose(contours[0]);
                List<AbstractMesh> meshs = new List<AbstractMesh>();
                for (int z=0;z<conts.Length;z++)
                {
                    meshs.Add(gen.generate(conts[z]));
                }
                


                //TODO: сделать класс ArithmMeanGrade пабликом???
                for (int z = 0; z < meshs.Count; z++)
                    contourGrade += new ArithmMeanGrade().calculate(meshs[z]);

                //List<RegMesh2D> meshs = generator.generate(contours[0]);
                //foreach (RegMesh2D j in meshs)
                //    contour_grade += new ArithmMeanGrade().Calculate(j);

                // Четырёхугольник

                //TODO: создать конкретные классы для IMeshGenerator????

                meshs.Add(gen.generate(contours[1]));

                //TODO: сделать класс ArithmMeanGrade пабликом???

                contourGrade += new ArithmMeanGrade().calculate(meshs[3]);
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
            ICurve b1 = new Line(points[0], points[2]);
            Geometry.Curve.Tools.slittingCurve(contour.lenghtOfPart, b1);
            contours.Add(new Contour(new ICurve[] { contour[2], contour[3], contour[4], b1 }));

            return contours.ToArray();
        }
    }
}