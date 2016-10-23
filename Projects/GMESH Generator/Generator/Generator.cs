using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Generator
{
    public class Generator:IMeshGenerator
    {
        private IContour contour;
        private int meshSize;
        private IPoint[] aSideCutPoints, bSideCutPoints;
        public Generator()
        { 
        }
        public AbstractMesh generate(IContour contour)
        {
            this.contour = contour;
            meshSize = contour[0].cutPoints.Length;
            return null;
        }
    }
}
