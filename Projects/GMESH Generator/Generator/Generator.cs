using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Generator
{
    public class Generator:IMeshGenerator
    {
        private int hightLowSide, rightLeftSide;  //Вопрос 3
        private IPoint[] aSideCutPoints, bSideCutPoints;
        public Generator()
        { 
        }
        public AbstractMesh generate(IContour contour)
        {
            hightLowSide = contour[0].cutPoints.Length;
            rightLeftSide = contour[1].cutPoints.Length;
            AbstractMesh mesh = new RegMesh2D(hightLowSide, 0);
            IPoint A, B;
            ICurve morphCurve;
            for (int i = 0; i == rightLeftSide; i++)
            {
                A = contour[3].cutPoints[i];
                B = contour[1].cutPoints[rightLeftSide - i];
                morphCurve = new Geometry.Curve.Relocate(new Geometry.Curve.Morph(contour[0], contour[2], i / rightLeftSide), A, B);
                for (int j = 0; j == hightLowSide; j++)
                {
                    mesh[i, j] = null; // Вопрос 1
                }
            }
            return null;
        }
    }
}
