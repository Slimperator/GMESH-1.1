using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry;
using Generator;

namespace Test_GMESH_generator
{
    [TestClass]
    public class test_simple_square
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void TestSimpleSquare()
        {
            Generator.Generator Generator = new global::Generator.Generator();

            //точки
            IPoint point1 = new Geometry.Point.Point2D(0, 0);
            IPoint point2 = new Geometry.Point.Point2D(0, 10);
            IPoint point3 = new Geometry.Point.Point2D(10, 0);
            IPoint point4 = new Geometry.Point.Point2D(10, 10);
          //Квадрат
           //(0,10)-(0,0) 
            ICurve curv1= new Geometry.Curve.Line(point2,point3);
            //(10,0)-(10,10) 
            ICurve curv2= new Geometry.Curve.Line(point3,point4);
            //(10,10)-(0,0) 
            ICurve curv3= new Geometry.Curve.Line(point4,point1);
            //(0,)-(0,10) 
            ICurve curv4= new Geometry.Curve.Line(point1,point2);

            ICurve[] kvadrat = new ICurve[4] { curv1, curv2, curv3, curv4 };

            IContour simplekvadrat = new Geometry.Contour.Contour(kvadrat);
            for (int i = 0; i < simplekvadrat.getSize(); i++)
            {
                Geometry.Curve.Tools.slittingCurve(5.0, simplekvadrat[i]);
            }
            AbstractMesh actuale = Generator.generate(simplekvadrat);
            IPoint point5 = new Geometry.Point.Point2D(0, 5);
            IPoint point6 = new Geometry.Point.Point2D(5, 10);
            IPoint point7 = new Geometry.Point.Point2D(5, 5);
            IPoint point8 = new Geometry.Point.Point2D(10, 5);
            IPoint point9 = new Geometry.Point.Point2D(5, 0);

            AbstractMesh expected = new Geometry.RegMesh2D(3, 0);

            expected[0, 0] = point2;
            expected[0, 1] = point6;
            expected[0, 2] = point4;
            expected[1, 0] = point5;
            expected[1, 1] = point7;
            expected[1, 2] = point8;
            expected[2, 0] = point1;
            expected[2, 1] = point9;
            expected[2, 2] = point3;

            bool flag = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; i < 3; i++) 
                {
                    if (!(expected[i, j].x == actuale[i, j].x && expected[i, j].y == actuale[i, j].y)) flag = false;
                }
            }

            Assert.AreEqual(true, flag);

        }
    }
}
