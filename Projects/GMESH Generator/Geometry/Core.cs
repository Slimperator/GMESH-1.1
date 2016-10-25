using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public interface IPoint
    {
        double x { get; set; }
        double y { get; set; }    
    }

    public interface ICurve
    {
        IPoint[] cutPoints { get; set; }
        IPoint getPoint(double t);
    }

    public interface IContour
    {
        double lenghtOfPart { get; set; }
        int getSize();
        ICurve this[int i] { get; }
    }

    public abstract class AbstractMesh
    {
        protected IPoint[,] meshPoints;
        public abstract int rows { get; protected set; }
        public abstract int colums { get; protected set; }
        public abstract double sigma { get; set; }
        public IPoint this[int i, int j]
        {
            get { return meshPoints[i, j]; }
            set { meshPoints[i, j] = value; }
        }
    }
}
