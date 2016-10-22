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
            this.colums = size;
            this.rows = size;
            this.sigma = sigma;
        }

        public override int rows
        {
            get { return this.rows; }
        }

        public override int colums
        {
            get { return this.colums; }
        }

        public override double sigma
        {
            get
            {
                return this.sigma;
            }
            set
            {
                this.sigma = value;
            }
        }
    }
}
