using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Analyzer
{
    public interface IGrade
    {
        double calculate(AbstractMesh mesh);
        double calculate(IPoint p1, IPoint p2, IPoint p3, IPoint p4);
    }
}
