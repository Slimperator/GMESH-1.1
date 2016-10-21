using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class RegMesh2D: AbstractMesh
    {
        public RegMesh2D(int size, int sigma)
        {
            this.meshPoints = new IPoint[size, size];
            this.sigma = sigma;
        }
    }
}
