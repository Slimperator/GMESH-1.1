using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using Generator;
using Analyzer;

namespace Decompose.Triangle

{
    public class TriangleDecompose : IDecompose
    {
        //private Geometry.IPoint[] pointsOfcurve;
        private const double PART = 0.5;
        private double Max = 0;
        private IMeshGenerator gen = new Generator.Generator();
        private IGrade grade = new Analyzer.Grade.ArithmMeanGrade(); 

        public IContour[] decompose(IContour contour)
        {
            Geometry.IPoint[] newPoints = FindCenters(contour, PART);  //пустой массив для середин линий
            Geometry.IPoint centre = FindTriangleCentre(newPoints); ;
            Geometry.IPoint[] aSidePoints = contour[0].cutPoints;// = slittingCurve2(contour[0])???
            Geometry.IPoint[] bSidePoints = contour[1].cutPoints;
            Geometry.IPoint[] cSidePoints = contour[2].cutPoints;
            IContour[] decFigures = FindeTheBestConture(centre, contour, aSidePoints, bSidePoints, cSidePoints); //пустая коллекция для фигур
            return decFigures.ToArray();
        }

        private Geometry.IPoint[] FindCenters(IContour contour, double part)//находим середины линий
        {
            Geometry.IPoint[] newPoints = new Geometry.IPoint[contour.getSize()];
            for (int i = 0; i < contour.getSize(); ++i)
            {
                newPoints[i] = contour[i].getPoint(part);
            }
            return newPoints;
        }

        private Geometry.IPoint FindTriangleCentre(Geometry.IPoint[] newPoints)//поиск точки центра масс
        {
            return new Geometry.Point.Point2D((newPoints[0].x + newPoints[1].x + newPoints[2].x) / 3, (newPoints[0].y + newPoints[1].y + newPoints[2].y) / 3);
        }

        private IContour[] FindeTheBestConture(Geometry.IPoint centre, IContour contour, Geometry.IPoint[] PointsASide, Geometry.IPoint[] PointsBSide, Geometry.IPoint[] PointsCSide)
        {
            IContour[] decFigures = new IContour[3];
            Max = 0;
            IContour[] bestContourCombo = new IContour[3];

            for (int i = 0; i < PointsASide.Length; i++)
            {
                for (int j = 0; j < PointsBSide.Length; j++)
                {
                    for (int c = 0; c < PointsCSide.Length; c++)
                    {
                        ICurve[] lines = new ICurve[4];
                        DecomposeTriangle(PointsASide[0], PointsASide[i + 1], PointsCSide[c + 1], PointsCSide[PointsCSide.Length - 1], centre);
                        decFigures[0] = new Geometry.Contour.Contour(lines);
                        DecomposeTriangle(PointsBSide[0], PointsBSide[j + 1], PointsASide[i + 1], PointsASide[PointsASide.Length - 1], centre);
                        decFigures[1] = new Geometry.Contour.Contour(lines);
                        DecomposeTriangle(PointsCSide[0], PointsCSide[c + 1], PointsBSide[j + 1], PointsBSide[PointsBSide.Length - 1], centre);
                        decFigures[2] = new Geometry.Contour.Contour(lines);                      
                        double localGrade = 0;
                        for (int f = 0; f < decFigures.Length; f++)
                        {
                            localGrade += grade.calculate(gen.generate(decFigures[f]));
                        }
                        if (Max < (localGrade / 3))
                        {
                            Max = localGrade / 3;
                            bestContourCombo = decFigures;
                        }
                    }
                }
            }
            return bestContourCombo;
        }

        private IContour DecomposeTriangle(Geometry.IPoint firstSidePointA, Geometry.IPoint firstSidePointB, Geometry.IPoint secondSidePointA, Geometry.IPoint secondSidePointB, IPoint centre)
        {
            ICurve[] lines = new ICurve[4];
            lines[0] = new Geometry.Curve.Line(firstSidePointA, firstSidePointB);
            lines[1] = new Geometry.Curve.Line(firstSidePointB, centre);
            lines[2] = new Geometry.Curve.Line(centre, secondSidePointA);
            lines[3] = new Geometry.Curve.Line(secondSidePointA, secondSidePointB);

            return new Geometry.Contour.Contour(lines);
        }
    }
}

