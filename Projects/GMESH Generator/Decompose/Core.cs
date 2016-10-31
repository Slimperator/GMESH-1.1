using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Decompose
{
    public interface IDecompose
    {
        IContour[] decompose(IContour contour); 
    }
}
