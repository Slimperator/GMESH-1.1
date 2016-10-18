using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Solvers
{
    class ForSmth: IContourDecompositor
    {
        private Geometry.IPoint[] pointsOfcurve;
        private const double PART = 0.5;
        private double Max = 0;
        private IMeshGen gen = new QuadCleverMeshGen(10);
        private IGrade grade = new ArithmMeanGrade();
        

        public IContour[] decomposed(IContour contour)
        {

            Geometry.IPoint[] newPoints = FindCenters(contour, PART);  //пустой массив для середин линий
            Geometry.IPoint L = FindTriangleCentre(newPoints); ;

            Geometry.IPoint[] aSidePoints = FindSidePoints(contour[0]);
            Geometry.IPoint[] bSidePoints = FindSidePoints(contour[1]);
            Geometry.IPoint[] cSidePoints = FindSidePoints(contour[2]);

            List<IContour> decFigures = FindeTheBestConture(L, contour, aSidePoints, bSidePoints, cSidePoints); //пустая коллекция для фигур
           
            return decFigures.ToArray();
        }

        private Geometry.IPoint[] FindCenters(IContour contour, double part)//находим середины линий
        {
            Geometry.IPoint[] newPoints = new Geometry.Point[contour.Size];
            for (int i = 0; i < contour.Size; ++i)
            {
                double x, y;

                contour[i].getPoint(part, out x, out y);
                newPoints[i] = new Geometry.Point(x, y);
            }
            return newPoints;
        }

        private Geometry.IPoint FindTriangleCentre(Geometry.IPoint[] newPoints)//поиск точки центра масс
        {
            Geometry.IPoint L = new Geometry.Point((newPoints[0].X + newPoints[1].X + newPoints[2].X) / 3, (newPoints[0].Y + newPoints[1].Y + newPoints[2].Y) / 3);
            return L;
        }

        private Geometry.IPoint[] FindSidePoints(ICurve contourside)
        {
            Geometry.IPoint[] sidePoints = new Geometry.Point[6];
            for (int i = 0; i < 3; i++)
            {
                for (double j = 0; j < sidePoints.Length; j++)
                {
                    double x, y;
                    contourside.getPoint(j, out x, out y);
                    sidePoints[(int)j] = new Geometry.Point(x, y);
                }
            }
            return sidePoints;
        }

        private List<IContour> FindeTheBestConture(Geometry.IPoint centre, IContour contour, Geometry.IPoint[] PointsASide, Geometry.IPoint[] PointsBSide, Geometry.IPoint[] PointsCSide)
        {
            List<IContour> decFigures = new List<IContour>();
            Max = 0;
            List<IContour> bestContourCombo = new List<IContour>();

            for (int i = 0; i < PointsASide.Length; i++)
            {
                for (int j = 0; j < PointsBSide.Length; j++)
                {
                    for (int c = 0; c < PointsCSide.Length; c++)
                    {
                        for (int d = 0; d < contour.Size; ++d)
                        {
                            List<ICurve> lines = new List<ICurve>();
                            int index = i == 0 ? contour.Size - 1 : i - 1;

                            lines.Add(new Line(PointsASide[0], PointsASide[i + 1]));
                            lines.Add(new Line(PointsASide[i + 1], centre));
                            lines.Add(new Line(centre, PointsCSide[i + 1]));
                            lines.Add(new Line(PointsCSide[i + 1], PointsCSide[5]));

                            lines.Add(new Line(PointsBSide[0], PointsBSide[i + 1]));
                            lines.Add(new Line(PointsBSide[i + 1], centre));
                            lines.Add(new Line(centre, PointsASide[i + 1]));
                            lines.Add(new Line(PointsASide[i + 1], PointsASide[5]));

                            lines.Add(new Line(PointsCSide[0], PointsCSide[i + 1]));
                            lines.Add(new Line(PointsCSide[i + 1], centre));
                            lines.Add(new Line(centre, PointsBSide[i + 1]));
                            lines.Add(new Line(PointsBSide[i + 1], PointsBSide[5]));
                            
                            IContour figure = new Contour(lines);
                            decFigures.Add(figure);
                            if (Max < (grade.Calculate(gen.Generate(figure)[0]) / 3))
                            {
                                Max = grade.Calculate(gen.Generate(figure)[0]) / 3;
                                decFigures = bestContourCombo; //Приравнять даный контур с theBestContour
                            }

                            //Здесь сравнение полученного значения качества с максимальным. сли лучше, то новый макс.
                        }
                    }
                }
            }
            return decFigures;
        }

        private List<IContour> DecomposeTriangle(IContour contour, Geometry.IPoint[] newPoints, Geometry.IPoint L)
        {
            List<IContour> decFigures = new List<IContour>();
            Max = 0;
            for (int i = 0; i < contour.Size; ++i)
            {
                List<ICurve> lines = new List<ICurve>();
                int index = i == 0 ? newPoints.Length - 1 : i - 1;

                lines.Add(new SubCurve(contour[i], 0, PART));
                lines.Add(new Line(newPoints[i], L));
                lines.Add(new Line(L, newPoints[index]));
                lines.Add(new SubCurve(contour[index], PART, 1));

                IContour figure = new Contour(lines);
                decFigures.Add(figure);
                Max += grade.Calculate(gen.Generate(figure)[0]);

            }
            return decFigures;
        }
        
    }
}

