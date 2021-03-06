﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using GMESHFileStream;
using Decompose;
using Generator;
using System.IO;
using System.Windows.Forms;

namespace GMESH_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Geometry.Contour.Contour.DefaultLenghtPart = 5;
            Buffer buffer = Buffer.getInstance();
            ICommand command = new Commands.RunTime();
            Console.Clear();
            Console.WriteLine("### GMESH Generator v1.1 ###");
            if (args.Length != 0)
            {
                buffer.CloseRunTimeFlag = true;
                buffer.Args = args;
            }
            do
            {
                if (buffer.Args == null)
                {
                    string str = @Console.ReadLine();
                    buffer.Args = str.Split(' ');
                    for(int i = 0; i < buffer.Args.Length; i++)
                    {
                        if (buffer.Args[i].StartsWith("\"") & buffer.Args[i].EndsWith("\""))
                        {
                            buffer.Args[i] = buffer.Args[i].Substring(1, buffer.Args[i].Length - 2);
                        }
                    }
                }
                command.callBack();
            } while (!buffer.CloseRunTimeFlag);
            Environment.Exit(0);


            //Если хочешь использовать визуализатор
            //1) Добавь using System.Windows.Forms;
            //2) расскоменть следующие строки:
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //TestVisualizerForInternalMeshForm sim = new TestVisualizerForInternalMeshForm();
            //sim.meshs = buff.Meshs;
            //sim.cons = buff.Contour;
            //Application.Run(sim);

            /*string path = Directory.GetCurrentDirectory();
            path = System.IO.Path.Combine(path, "ObjExample2.obj");
            AbstractMesh mesh1 = new RegMesh2D(2, 0);
            AbstractMesh mesh2 = new RegMesh2D(3, 0);
            AbstractMesh mesh3 = new RegMesh2D(4, 0);
            AbstractMesh mesh4 = new RegMesh2D(6, 0);
            //сетки для тестирования  
            // сетка mesh1
            mesh1[0, 0] = new Geometry.Point.Point2D(21, 24);
            mesh1[0, 1] = new Geometry.Point.Point2D(25, 28);
            mesh1[1, 0] = new Geometry.Point.Point2D(30, 34);
            mesh1[1, 1] = new Geometry.Point.Point2D(36, 40);

            // сетка mesh2
            mesh2[0, 0] = new Geometry.Point.Point2D(50, 55);
            mesh2[0, 1] = new Geometry.Point.Point2D(57, 60);
            mesh2[0, 2] = new Geometry.Point.Point2D(65, 70);
            mesh2[1, 0] = new Geometry.Point.Point2D(72, 75);
            mesh2[1, 1] = new Geometry.Point.Point2D(78, 80);
            mesh2[1, 2] = new Geometry.Point.Point2D(85, 90);
            mesh2[2, 0] = new Geometry.Point.Point2D(91, 82);
            mesh2[2, 1] = new Geometry.Point.Point2D(80, 75);
            mesh2[2, 2] = new Geometry.Point.Point2D(70, 65);

            // сетка mesh3
            mesh3[0, 0] = new Geometry.Point.Point2D(100, 103);
            mesh3[0, 1] = new Geometry.Point.Point2D(105, 123);
            mesh3[0, 2] = new Geometry.Point.Point2D(125, 131);
            mesh3[0, 3] = new Geometry.Point.Point2D(133, 140);
            mesh3[1, 0] = new Geometry.Point.Point2D(142, 145);
            mesh3[1, 1] = new Geometry.Point.Point2D(150, 155);
            mesh3[1, 2] = new Geometry.Point.Point2D(160, 165);
            mesh3[1, 3] = new Geometry.Point.Point2D(168, 173);
            mesh3[2, 0] = new Geometry.Point.Point2D(175, 178);
            mesh3[2, 1] = new Geometry.Point.Point2D(180, 185);
            mesh3[2, 2] = new Geometry.Point.Point2D(190, 195);
            mesh3[2, 3] = new Geometry.Point.Point2D(200, 205);
            mesh3[3, 0] = new Geometry.Point.Point2D(210, 202);
            mesh3[3, 1] = new Geometry.Point.Point2D(205, 198);
            mesh3[3, 2] = new Geometry.Point.Point2D(196, 190);
            mesh3[3, 3] = new Geometry.Point.Point2D(183, 178);

            //сетка mesh 4

            mesh4[0, 0] = new Geometry.Point.Point2D(5, 5.2);
            mesh4[0, 1] = new Geometry.Point.Point2D(5.6, 5.8);
            mesh4[0, 2] = new Geometry.Point.Point2D(6, 6.2);
            mesh4[0, 3] = new Geometry.Point.Point2D(6.4, 6.8);
            mesh4[0, 4] = new Geometry.Point.Point2D(7, 7.2);
            mesh4[0, 5] = new Geometry.Point.Point2D(7.6, 8);
            //
            mesh4[1, 0] = new Geometry.Point.Point2D(8.2, 8.4);
            mesh4[1, 1] = new Geometry.Point.Point2D(8.6, 8.8);
            mesh4[1, 2] = new Geometry.Point.Point2D(9.0, 9.2);
            mesh4[1, 3] = new Geometry.Point.Point2D(9.4, 9.6);
            mesh4[1, 4] = new Geometry.Point.Point2D(9.8, 10);
            mesh4[1, 5] = new Geometry.Point.Point2D(10.2, 10.4);
            //
            mesh4[2, 0] = new Geometry.Point.Point2D(11, 14);
            mesh4[2, 1] = new Geometry.Point.Point2D(14, 16);
            mesh4[2, 2] = new Geometry.Point.Point2D(17, 20);
            mesh4[2, 3] = new Geometry.Point.Point2D(21, 23);
            mesh4[2, 4] = new Geometry.Point.Point2D(25, 27);
            mesh4[2, 5] = new Geometry.Point.Point2D(28, 30);
            //
            mesh4[3, 0] = new Geometry.Point.Point2D(31, 31.5);
            mesh4[3, 1] = new Geometry.Point.Point2D(31.7, 32);
            mesh4[3, 2] = new Geometry.Point.Point2D(32.2, 32.5);
            mesh4[3, 3] = new Geometry.Point.Point2D(32.7, 33);
            mesh4[3, 4] = new Geometry.Point.Point2D(33.5, 34);
            mesh4[3, 5] = new Geometry.Point.Point2D(34.5, 35);
            //
            mesh4[4, 0] = new Geometry.Point.Point2D(40, 41.5);
            mesh4[4, 1] = new Geometry.Point.Point2D(42, 44);
            mesh4[4, 2] = new Geometry.Point.Point2D(44, 47);
            mesh4[4, 3] = new Geometry.Point.Point2D(47.5, 48);
            mesh4[4, 4] = new Geometry.Point.Point2D(48.5, 49);
            mesh4[4, 5] = new Geometry.Point.Point2D(49.5, 50);
            //
            mesh4[5, 0] = new Geometry.Point.Point2D(100, 103);
            mesh4[5, 1] = new Geometry.Point.Point2D(100, 103);
            mesh4[5, 2] = new Geometry.Point.Point2D(100, 103);
            mesh4[5, 3] = new Geometry.Point.Point2D(100, 103);
            mesh4[5, 4] = new Geometry.Point.Point2D(100, 103);
            mesh4[5, 5] = new Geometry.Point.Point2D(100, 103);
            // сетка mesh4



            AbstractMesh[] mesharray = new AbstractMesh[1];
            mesharray[0] = mesh1;
            AbstractMesh[] mesharray1 = new AbstractMesh[3];
            mesharray1[0] = mesh2;
            mesharray1[1] = mesh1;
            mesharray1[2] = mesh3;

            IPoint point1 = new Geometry.Point.Point2D(10, 35);
            IPoint point2 = new Geometry.Point.Point2D(25, 41);
            IPoint point3 = new Geometry.Point.Point2D(60, 71);

            //треугольник
            ICurve curve = new Geometry.Curve.Line(point1, point2);
            ICurve curve1 = new Geometry.Curve.Line(point2, point3);
            ICurve curve2 = new Geometry.Curve.Line(point3, point1);

            ICurve[] curvs = new ICurve[3] { curve, curve1, curve2 };

            IContour k = new Geometry.Contour.Contour(curvs);
            IWriter test = new GMESHFileStream.OBJFile.OBJCreator();
            test.write(path, mesharray, null);
            */
            /*//тестовое дерьмо для отрезков
            IPoint x1 = new Geometry.Point.Point2D(0, 0);
            IPoint x2 = new Geometry.Point.Point2D(100, 0);
            IPoint x3 = new Geometry.Point.Point2D(100, 100);
            IPoint x4 = new Geometry.Point.Point2D(0, 100);
            IPoint C = new Geometry.Point.Point2D(50, 50);

            ICurve curve = new Geometry.Curve.Line(x1, x2);
            ICurve curve1 = new Geometry.Curve.Line(x2, x3);
            ICurve curve2 = new Geometry.Curve.Line(x3, x4);
            ICurve curve3 = new Geometry.Curve.Line(x4, x1);
            Geometry.Curve.Tools.slittingCurve(10.0, curve);
            Geometry.Curve.Tools.slittingCurve(10.0, curve3);
            ICurve Scurve = new Geometry.Curve.SubCurve(curve, curve.cutPoints[0], curve.cutPoints[4]);
            ICurve Scurve1 = new Geometry.Curve.SubCurve(curve3, curve3.cutPoints[5], curve3.cutPoints[curve3.cutPoints.Length-1]);

            ICurve[] curvs = new ICurve[4] { Scurve, new Geometry.Curve.Line(curve.cutPoints[4], C), new Geometry.Curve.Line(C, curve3.cutPoints[5]), Scurve1 };

            IContour k = new Geometry.Contour.Contour(curvs);
            buff.Contour = new IContour[1] { k };*/
            //ICurve line = new Geometry.Curve.Line(new Geometry.Point.Point2D(0, 0), new Geometry.Point.Point2D(100, 0));
            //Geometry.Curve.Tools.slittingCurve((int)10, line);
        }
    }
}