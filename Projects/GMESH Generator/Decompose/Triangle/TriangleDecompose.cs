using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using Generator;
using Analyzer;
using System.Windows.Forms;

namespace Decompose.Triangle

{
    public class TriangleDecompose : IDecompose
    {
        private const double PART = 0.5;
        private double Max = 0;
        private IMeshGenerator gen = new Generator.Generator();
        private IGrade grade = new Analyzer.Grade.ArithmMeanGrade();
        private double Lenght;
        private Dictionary<IPoint[], ICurve> lineInsideTriangle = new Dictionary<IPoint[], ICurve>(3);

        public IContour[] decompose(IContour contour)
        {
            this.Lenght = contour.lenghtOfPart;
            Geometry.IPoint[] newPoints = FindCenters(contour, PART);  //пустой массив для середин линий
            Geometry.IPoint centre = FindTriangleCentre(newPoints); ;
            Geometry.IPoint[] aSidePoints = contour[0].cutPoints;// = slittingCurve2(contour[0])???
            Geometry.IPoint[] bSidePoints = contour[1].cutPoints;
            Geometry.IPoint[] cSidePoints = contour[2].cutPoints;
            IContour[] decFigures = FindeConture(centre, contour, aSidePoints, bSidePoints, cSidePoints); //пустая коллекция для фигур
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

        private IContour[] FindeConture(Geometry.IPoint centre, IContour contour, Geometry.IPoint[] PointsASide, Geometry.IPoint[] PointsBSide, Geometry.IPoint[] PointsCSide)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Form1 sim = new Form1();
            IContour[] decFigures = new IContour[3];
            lineInsideTriangle.Clear();
            int A = PointsASide.Length/2; 
            int B = PointsBSide.Length/2;
            int C = PointsCSide.Length/2; 
            decFigures[0] = DecomposeTriangle(contour[0], contour[2], PointsASide[0], PointsASide[A], PointsCSide[C], PointsCSide[PointsCSide.Length - 1], centre);
            decFigures[1] = DecomposeTriangle(contour[1], contour[0], PointsBSide[0], PointsBSide[B], PointsASide[A], PointsASide[PointsASide.Length - 1], centre);
            decFigures[2] = DecomposeTriangle(contour[2], contour[1], PointsCSide[0], PointsCSide[C], PointsBSide[B], PointsBSide[PointsBSide.Length - 1], centre);
            decFigures[0].lenghtOfPart = contour.lenghtOfPart;
            decFigures[1].lenghtOfPart = contour.lenghtOfPart;
            decFigures[2].lenghtOfPart = contour.lenghtOfPart;
            //sim.meshs = null;
            //sim.con = decFigures.ToArray();
            //sim.Show();
            //sim.Refresh();
            return decFigures;
        }
        private IContour[] FindeTheBestConture(Geometry.IPoint centre, IContour contour, Geometry.IPoint[] PointsASide, Geometry.IPoint[] PointsBSide, Geometry.IPoint[] PointsCSide)
        {
            IContour[] decFigures = new IContour[3];
            Max = 0;
            IContour[] bestContourCombo = new IContour[3];
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Form1 sim = new Form1();
            

            for (int i = 0; i < PointsASide.Length -2; i++)
            {
                for (int j = 0; j < PointsBSide.Length -2; j++)
                {
                    for (int c = 0; c < PointsCSide.Length -2; c++)
                    {
                        //ICurve[] lines = new ICurve[4];
                        lineInsideTriangle.Clear();
                        decFigures[0] = DecomposeTriangle(contour[0],contour[2],PointsASide[0], PointsASide[i + 1], PointsCSide[c + 1], PointsCSide[PointsCSide.Length - 1], centre);
                        decFigures[1] = DecomposeTriangle(contour[1],contour[0],PointsBSide[0], PointsBSide[j + 1], PointsASide[i + 1], PointsASide[PointsASide.Length - 1], centre);
                        decFigures[2] = DecomposeTriangle(contour[2],contour[1],PointsCSide[0], PointsCSide[c + 1], PointsBSide[j + 1], PointsBSide[PointsBSide.Length - 1], centre);
                        decFigures[0].lenghtOfPart = contour.lenghtOfPart;
                        decFigures[1].lenghtOfPart = contour.lenghtOfPart;
                        decFigures[2].lenghtOfPart = contour.lenghtOfPart;
                        double localGrade = 0;
                        List<AbstractMesh> meshs = new List<AbstractMesh>(); 
                        for (int f = 0; f < decFigures.Length; f++)
                        {
                            AbstractMesh mesh = gen.generate(decFigures[f]);
                            //meshs.Add(mesh);
                            localGrade += grade.calculate(mesh);
                        }
                        if (Max < (localGrade / 3))
                        {
                            Max = localGrade / 3;
                            bestContourCombo = decFigures;
                        }

                        //sim.meshs = meshs.ToArray();
                        //sim.con = decFigures.ToArray();
                        //sim.Show();
                        //sim.Refresh();
                    }
                }
            }
            //bestContourCombo[0].lenghtOfPart = 35;
            //bestContourCombo[1].lenghtOfPart = 35;
            //bestContourCombo[2].lenghtOfPart = 35;
            return bestContourCombo;
        }

        private IContour DecomposeTriangle(ICurve firstSide, ICurve secondSide, IPoint firstSidePointA, IPoint firstSidePointB, IPoint secondSidePointA, IPoint secondSidePointB, IPoint centre)
        {
            ICurve[] lines = new ICurve[4];
            ICurve firstInternalLine = null, secondInternalLine = null;
            foreach (KeyValuePair<IPoint[], ICurve> p in lineInsideTriangle)                                       //ищем, нет внутренних линий треугольника в словаре уже созданных
            {                                                                                                      //если находим, то создаем кривую задом наперед на основе найденной кривой
                if (p.Key[1].x == firstSidePointB.x && p.Key[1].y == firstSidePointB.y && centre == p.Key[0])
                {
                    firstInternalLine = new Geometry.Curve.ReverseCurve(p.Value);
                }
                if (p.Key[0].x == secondSidePointA.x && p.Key[0].y == secondSidePointA.y && centre == p.Key[1])
                {
                    secondInternalLine = new Geometry.Curve.ReverseCurve(p.Value);
                }
            }
            if (firstInternalLine == null)                                                                         //если в словаре ничего не найдено, создаем кривую и записываем её в словарь
            {
                firstInternalLine = new Geometry.Curve.Line(firstSidePointB, centre);
                Geometry.Curve.Tools.slittingCurve(Lenght, firstInternalLine);
                lineInsideTriangle.Add(new IPoint[2]{firstSidePointB, centre}, firstInternalLine);
            }
            if (secondInternalLine == null)
            {
                secondInternalLine = new Geometry.Curve.Line(centre, secondSidePointA);
                Geometry.Curve.Tools.slittingCurve(Lenght, secondInternalLine);
                lineInsideTriangle.Add(new IPoint[2] { centre, secondSidePointA }, secondInternalLine);
            }
            lines[0] = new Geometry.Curve.SubCurve(firstSide,firstSidePointA, firstSidePointB);
            lines[1] = firstInternalLine;
            lines[2] = secondInternalLine;
            lines[3] = new Geometry.Curve.SubCurve(secondSide,secondSidePointA, secondSidePointB);

            return new Geometry.Contour.Contour(lines);
        }
    }
}

