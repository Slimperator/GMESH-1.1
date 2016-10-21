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
        IPoint[] cutPoints { get; }
        IPoint getPoint(double t);
        void slittingCurve(double lenght);
    }

    public interface IContour
    {
        int getSize();
        ICurve this[int i] { get; }
    }

    public abstract class AbstractMesh
    {
        protected IPoint[,] meshPoints;
        protected int rows;
        protected int colums;
        public double sigma { get; set; }
        public IPoint this[int i, int j]
        {
            get { return meshPoints[i, j]; }
            set { meshPoints[i, j] = value; }
        }
    }
}
