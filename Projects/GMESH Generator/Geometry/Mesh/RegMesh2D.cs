using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class RegMesh2D: AbstractMesh
    {
        private double sigma;
        private int size;
        public RegMesh2D(int size, int sigma)
        {
            this.meshPoints = new IPoint[size, size];
            this.size = size;
            this.sigma = sigma;
        }

        public override int rows
        {
            get { return this.size; }
            protected set { this.size = value; }
        }

        public override int colums
        {
            get { return this.size; }
            protected set { this.size = value; }
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
