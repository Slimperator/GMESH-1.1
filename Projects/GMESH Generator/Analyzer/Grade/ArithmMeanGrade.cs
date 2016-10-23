using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using Geometry.Curve;

namespace Analyzer.Grade
{
    class ArithmMeanGrade:IGrade
    {

        public double calculate(Geometry.AbstractMesh mesh)
        {
            List<double> average = new List<double>(); //среднее

            for (int i = 0; i < mesh.rows - 1; i++)
            {
                for (int j = 0; j < mesh.colums - 1; j++)
                {
                    average.Add(CalculateSquare(mesh[i, j], mesh[i, j + 1], mesh[i + 1, j + 1], mesh[i + 1, j]));
                }
            }

            double sum = 0;
            foreach (double i in average)
            {
                sum += i;
            }

            return sum / ((mesh.colums - 1) * (mesh.rows - 1));
        }

        private double CalculateSquare(IPoint p1, IPoint p2, IPoint p3, IPoint p4)
        {
            double alpha = 0.5;

            List<Line> curves = new List<Line>();
            curves.Add(new Line(p1, p2));
            curves.Add(new Line(p2, p3));
            curves.Add(new Line(p3, p4));
            curves.Add(new Line(p4, p1));

            List<double> a = new List<double>();
            foreach (Line curve in curves)
            {
                double l = Tools.length(curve);
                double round = 1000000000;
                l = (long)(l * round) / round;
                a.Add(l);
            }
            //double Lmin = Math.Min(Math.Min(Math.Min(a[0], a[1]), a[2]), a[3]);
            //double Lmax = Math.Max(Math.Max(Math.Max(a[0], a[1]), a[2]), a[3]);
            double L = Math.Min(Math.Min(Math.Min(a[0], a[1]), a[2]), a[3]) / Math.Max(Math.Max(Math.Max(a[0], a[1]), a[2]), a[3]);
            a.Clear();



            double A1, A2, B1, B2, C1, C2;
            A1 = p1.y - p2.y;
            B1 = p2.x - p1.x;
            C1 = p1.x * p2.y - p2.x * p1.y;
            A2 = p2.y - p3.y;
            B2 = p3.x - p2.x;
            C2 = p2.x * p3.y - p3.x * p2.y;
            if ((A1 * A2 + B1 * B2) == 0) a.Add(90.0);
            else
            {
                double angle = Math.Atan((A1 * B2 - A2 * B1) / (A1 * A2 + B1 * B2)) * 180.0 / Math.PI;
                if (angle < 0) a.Add(180.0 + angle);
                else a.Add(angle);
            }

            A1 = p2.y - p3.y;
            B1 = p3.x - p2.x;
            C1 = p2.x * p3.y - p3.x * p2.y;
            A2 = p3.y - p4.y;
            B2 = p4.x - p3.x;
            C2 = p3.x * p4.y - p4.x * p3.y;
            if ((A1 * A2 + B1 * B2) == 0) a.Add(90.0);
            else
            {
                double angle = Math.Atan((A1 * B2 - A2 * B1) / (A1 * A2 + B1 * B2)) * 180.0 / Math.PI;
                if (angle < 0) a.Add(180.0 + angle);
                else a.Add(angle);
            }

            A1 = p3.y - p4.y;
            B1 = p4.x - p3.x;
            C1 = p3.x * p4.y - p4.x * p3.y;
            A2 = p4.y - p1.y;
            B2 = p1.x - p4.x;
            C2 = p4.x * p1.y - p1.x * p4.y;
            if ((A1 * A2 + B1 * B2) == 0) a.Add(90.0);
            else
            {
                double angle = Math.Atan((A1 * B2 - A2 * B1) / (A1 * A2 + B1 * B2)) * 180.0 / Math.PI;
                if (angle < 0) a.Add(180.0 + angle);
                else a.Add(angle);
            }

            A1 = p4.y - p1.y;
            B1 = p1.x - p4.x;
            C1 = p4.x * p1.y - p1.x * p4.y;
            A2 = p1.y - p2.y;
            B2 = p2.x - p1.x;
            C2 = p1.x * p2.y - p2.x * p1.y;
            if ((A1 * A2 + B1 * B2) == 0) a.Add(90.0);
            else
            {
                double angle = Math.Atan((A1 * B2 - A2 * B1) / (A1 * A2 + B1 * B2)) * 180.0 / Math.PI;
                if (angle < 0) a.Add(180.0 + angle);
                else a.Add(angle);
            }

            //double Umin = Math.Min(Math.Min(Math.Min(a[0], a[1]), a[2]), a[3]);
            //double Umax = Math.Max(Math.Max(Math.Max(a[0], a[1]), a[2]), a[3]);
            double U = Math.Min(Math.Min(Math.Min(a[0], a[1]), a[2]), a[3]) / Math.Max(Math.Max(Math.Max(a[0], a[1]), a[2]), a[3]);

            a.Clear();


            return (U * alpha + (1 - alpha) * L);
        }
    }
}
