using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using GMESHFileStream;
using Parser;
using Decompose;
using Generator;
using System.IO;

namespace GMESH_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            path = System.IO.Path.Combine(path, "ObjExample5.obj");
            AbstractMesh mesh1 = new RegMesh2D(2, 0);
            AbstractMesh mesh2 = new RegMesh2D(3, 0);
            AbstractMesh mesh3 = new RegMesh2D(4, 0);
            //сетки для тестирования  
          // сетка mesh1
            mesh1[ 0, 0 ] = new Geometry.Point.Point2D(0.0,0.0);
            mesh1[ 0, 1 ] = new Geometry.Point.Point2D(0.0,1.0);
            mesh1[ 1, 0 ] = new Geometry.Point.Point2D(1.0,0.0);
            mesh1[ 1, 1 ] = new Geometry.Point.Point2D(1.0,1.0);

          // сетка mesh2
            mesh2[ 0, 0 ] = new Geometry.Point.Point2D(50,55);
            mesh2[ 0, 1 ] = new Geometry.Point.Point2D(57,60);
            mesh2[ 0, 2 ] = new Geometry.Point.Point2D(65,70);
            mesh2[ 1, 0 ] = new Geometry.Point.Point2D(72,75);
            mesh2[ 1, 1 ] = new Geometry.Point.Point2D(78,80);
            mesh2[ 1, 2 ] = new Geometry.Point.Point2D(85,90);
            mesh2[ 2, 0 ] = new Geometry.Point.Point2D(91,82);
            mesh2[ 2, 1 ] = new Geometry.Point.Point2D(80,75);
            mesh2[ 2, 2 ] = new Geometry.Point.Point2D(70,65);
                
       // сетка mesh3
            mesh3[ 0, 0 ] = new Geometry.Point.Point2D(100,103);
            mesh3[ 0, 1 ] = new Geometry.Point.Point2D(105,123);
            mesh3[ 0, 2 ] = new Geometry.Point.Point2D(125,131);
            mesh3[ 0, 3 ] = new Geometry.Point.Point2D(133,140);
            mesh3[ 1, 0 ] = new Geometry.Point.Point2D(142,145);
            mesh3[ 1, 1 ] = new Geometry.Point.Point2D(150,155);
            mesh3[ 1, 2 ] = new Geometry.Point.Point2D(160,165);
            mesh3[ 1, 3 ] = new Geometry.Point.Point2D(168,173);
            mesh3[ 2, 0 ] = new Geometry.Point.Point2D(175,178);
            mesh3[ 2, 1 ] = new Geometry.Point.Point2D(180,185);
            mesh3[ 2, 2 ] = new Geometry.Point.Point2D(190,195);
            mesh3[ 2, 3 ] = new Geometry.Point.Point2D(200,205);
            mesh3[ 3, 0 ] = new Geometry.Point.Point2D(210,202);
            mesh3[ 3, 1 ] = new Geometry.Point.Point2D(205,198);
            mesh3[ 3, 2 ] = new Geometry.Point.Point2D(196,190);
            mesh3[ 3, 3 ] = new Geometry.Point.Point2D(183,178);


            AbstractMesh[] mesharray = new AbstractMesh[1];
            mesharray[0] = mesh1;
            AbstractMesh[] mesharray1 = new AbstractMesh[3];
            mesharray1[0] = mesh2;
            mesharray1[1] = mesh1;
            mesharray1[2] = mesh3;

            IPoint point1= new Geometry.Point.Point2D(10, 35);
            IPoint point2 = new Geometry.Point.Point2D(25, 41);
            IPoint point3 = new Geometry.Point.Point2D(60, 71);

            //треугольник
            ICurve curve = new Geometry.Curve.Line(point1,point2);
            ICurve curve1 = new Geometry.Curve.Line(point2,point3);
            ICurve curve2 = new Geometry.Curve.Line(point3,point1);

            ICurve [] curvs = new ICurve[3]
            {curve,curve1,curve2};

            IContour k = new Geometry.Contour.Contour(curvs);
            IWriter test = new GMESHFileStream.OBJFile.OBJCreator();
            test.write(path, mesharray);
    
    
        }
    }
}
