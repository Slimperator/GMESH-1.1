using Decompose.Triangle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Geometry;

namespace TestGenerator
{
    
    
    /// <summary>
    ///This is a test class for TriangleDecomposeTest and is intended
    ///to contain all TriangleDecomposeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TriangleDecomposeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for FindCenters
        ///</summary>
         [TestMethod()]
        [DeploymentItem("Decompose.dll")]
        public void FindCentersTest()
        {
            TriangleDecompose_Accessor target = new TriangleDecompose_Accessor(); // TODO: Initialize to an appropriate value

            Geometry.IPoint[] sidePointsCentres = new Geometry.IPoint[3];

            sidePointsCentres[0] = new Geometry.Point.Point2D(3, 4);
            sidePointsCentres[1] = new Geometry.Point.Point2D(9, 4);
            sidePointsCentres[2] = new Geometry.Point.Point2D(6, 0);
            bool goodFlag = false;
            IPoint centre = target.FindTriangleCentre(sidePointsCentres);
            IPoint expectedCentre = new Geometry.Point.Point2D(6, (double)(8.0 / 3.0));
           
            if (expectedCentre.x == centre.x && expectedCentre.y == centre.y)
                goodFlag = true;

            Assert.AreEqual(true, goodFlag);
        }

        /// <summary>
        ///A test for FindTriangleCentre
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Decompose.dll")]
        public void FindTriangleCentreTest()
        {
            TriangleDecompose_Accessor target = new TriangleDecompose_Accessor(); // TODO: Initialize to an appropriate value

            IPoint p1 = new Geometry.Point.Point2D(0, 0);
            IPoint p2 = new Geometry.Point.Point2D(6, 8);
            IPoint p3 = new Geometry.Point.Point2D(12, 0);

            ICurve side1 = new Geometry.Curve.Line(p1, p2);
            ICurve side2 = new Geometry.Curve.Line(p2, p3);
            ICurve side3 = new Geometry.Curve.Line(p3, p1);


            ICurve[] mytriangle = new ICurve[3] { side1, side2, side3 };
            IContour realtriangle = new Geometry.Contour.Contour(mytriangle);
            Geometry.IPoint[] sideCentrePoints = new Geometry.IPoint[realtriangle.getSize()];

            sideCentrePoints = target.FindCenters(realtriangle, 0.5);
            Geometry.IPoint[] expectedCentres = new Geometry.IPoint[3];
            expectedCentres[0] = new Geometry.Point.Point2D(3, 4);
            expectedCentres[1] = new Geometry.Point.Point2D(9, 4);
            expectedCentres[2] = new Geometry.Point.Point2D(6, 0);

            bool flag = true;
            for (int i = 0; i < sideCentrePoints.Length; i++)
            {
                if (expectedCentres[i].x != sideCentrePoints[i].x && expectedCentres[i].y != sideCentrePoints[i].y)
                {
                    flag = false;
                }
            }
            Assert.AreEqual(true, flag);
            
        }

        /// <summary>
        ///A test for DecomposeTriangle
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Decompose.dll")]  
        public void DecomposeTriangleTest()   
        {
            TriangleDecompose_Accessor target = new TriangleDecompose_Accessor(); // TODO: Initialize to an appropriate value
            IPoint p1 = new Geometry.Point.Point2D(0, 0);
            IPoint p2 = new Geometry.Point.Point2D(6, 8);
            IPoint p3 = new Geometry.Point.Point2D(12, 0);

            ICurve side1 = new Geometry.Curve.Line(p1, p2);
            ICurve side2 = new Geometry.Curve.Line(p2, p3);
            ICurve side3 = new Geometry.Curve.Line(p3, p1);


            ICurve[] mytriangle = new ICurve[3] { side1, side2, side3 };
            IContour realtriangle = new Geometry.Contour.Contour(mytriangle);

            Geometry.IPoint[] sidePointsCentres = new Geometry.IPoint[3];
            sidePointsCentres[0] = new Geometry.Point.Point2D(3, 4);
            sidePointsCentres[1] = new Geometry.Point.Point2D(9, 4);
            sidePointsCentres[2] = new Geometry.Point.Point2D(6, 0);
            IPoint centre = new Geometry.Point.Point2D(6, (double)(8.0 / 3.0));
            for (int i = 0; i < realtriangle.getSize(); i++)
            {
                Geometry.Curve.Tools.slittingCurve(3, realtriangle[i]);
            }

            IContour[] decFigures = new IContour[3];
            //больше не нужны:
            //side1.lenght = 3;
            //side2.lenght = 3;
            //side3.lenght = 3;
            decFigures[0] = target.DecomposeTriangle(side1, side3, realtriangle[0].cutPoints[0], sidePointsCentres[0], sidePointsCentres[2], realtriangle[2].cutPoints[2], centre);
            decFigures[1] = target.DecomposeTriangle(side2, side1, realtriangle[1].cutPoints[0], sidePointsCentres[1], sidePointsCentres[0], realtriangle[0].cutPoints[2], centre);
            decFigures[2] = target.DecomposeTriangle(side3, side2, realtriangle[2].cutPoints[0], sidePointsCentres[2], sidePointsCentres[1], realtriangle[1].cutPoints[2], centre);

            
            IContour[] expectedSquares = new IContour[3];
            ICurve[] expectedlines1 = new ICurve[4];
            expectedlines1[0] = new Geometry.Curve.Line(p1, sidePointsCentres[0]);
            expectedlines1[1] = new Geometry.Curve.Line(sidePointsCentres[0], centre);
            expectedlines1[2] = new Geometry.Curve.Line(centre, sidePointsCentres[2]);
            expectedlines1[3] = new Geometry.Curve.Line(sidePointsCentres[2], p1);
           

            expectedSquares[0] = new Geometry.Contour.Contour(expectedlines1);

            ICurve[] expectedlines2 = new ICurve[4];
            expectedlines2[0] = new Geometry.Curve.Line(p2, sidePointsCentres[1]);
            expectedlines2[1] = new Geometry.Curve.Line(sidePointsCentres[1], centre);
            expectedlines2[2] = new Geometry.Curve.Line(centre, sidePointsCentres[0]);
            expectedlines2[3] = new Geometry.Curve.Line(sidePointsCentres[0], p2);

            expectedSquares[1] = new Geometry.Contour.Contour(expectedlines2);

            ICurve[] expectedlines3 = new ICurve[4];
            expectedlines3[0] = new Geometry.Curve.Line(p3, sidePointsCentres[2]);
            expectedlines3[1] = new Geometry.Curve.Line(sidePointsCentres[2], centre);
            expectedlines3[2] = new Geometry.Curve.Line(centre, sidePointsCentres[1]);
            expectedlines3[3] = new Geometry.Curve.Line(sidePointsCentres[1], p3);

            expectedSquares[2] = new Geometry.Contour.Contour(expectedlines3);

            bool flag = false;
            for (int i = 0; i < expectedSquares.Length; i++)
            {
                if (expectedSquares[i] == decFigures[i])             
                {
                    flag = true;
                }
            }
            Assert.AreEqual(true, flag);
        }

    }
}
