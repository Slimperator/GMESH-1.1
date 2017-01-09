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
        double[] cutParams { get; set; } //костыль обыкновенный. править во втором релизе
        IPoint getPoint(double t);
        double lenght { get;}
        List<ICurve> childCurves { get; set; }
    }

    public interface IContour
    {
        double lenghtOfPart { get; set; }
        int getSize();
        ICurve this[int i] { get; set; }
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
