using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
namespace Generator
{
    public interface IMeshGenerator
    {
         AbstractMesh generate(IContour contour);
    }
}
