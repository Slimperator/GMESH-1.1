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
            //for (int i = 0; i < contour.getSize(); i++) { contour[i].accept(this); }

            List<IContour> contours = new List<IContour>();
            double bestGrade = -1;
            int bestIndex = 0;
            for (int i = 0; i < 5; i++)
            {
                // Декомпозиция
                // Треугольник
                contours.Add(new Contour(new ICurve[] {contour[0], contour[1], new Line(points[2], points[0])}));

                // Четырёхугольник
                contours.Add(new Contour(new ICurve[] {contour[2], contour[3], contour[4], new Line(points[0], points[2])}));

                // считаем качество
                // Треугольник
                double contourGrade = 0;
                //TODO: создать конкретные классы для IMeshGenerator
                IMeshGenerator generator = new Generator.Generator(); // = new TriaMeshGen(10, 10);
                AbstractMesh mesh = generator.generate(contours[0]);


                //TODO: сделать класс ArithmMeanGrade пабликом???

                contourGrade += new ArithmMeanGrade().calculate(mesh);

                //List<RegMesh2D> meshs = generator.generate(contours[0]);
                //foreach (RegMesh2D j in meshs)
                //    contour_grade += new ArithmMeanGrade().Calculate(j);

                // Четырёхугольник

                //TODO: создать конкретные классы для IMeshGenerator????

                generator = new Generator.Generator(); // = new QuadCleverMeshGen(10, 10);
                mesh = generator.generate(contours[1]);

                //TODO: сделать класс ArithmMeanGrade пабликом???

                contourGrade += new ArithmMeanGrade().calculate(mesh);
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

            contours.Add(new Contour(new ICurve[] {contour[0], contour[1], new Line(points[2], points[0])}));

            contours.Add(new Contour(new ICurve[] {contour[2], contour[3], contour[4], new Line(points[0], points[2])}));

            return contours.ToArray();
        }
    }
}