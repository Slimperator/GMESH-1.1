using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Parcer
{
    public interface IReader
    {
        void read(string path, out List<IPoint> listPoint, out List<ICurve> listCurve, out Preprocessing.graph.edge[][] meshCells);
    }
}
