using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    public class RegMesh2D: AbstractMesh
    {
        private double Sigma;
        private int x,y;
        public RegMesh2D(int size, int sigma)
        {
            this.meshPoints = new IPoint[size, size];
            this.x = size;
            this.y = size;
            this.sigma = sigma;
        }
        public RegMesh2D(int rows, int columns, int sigma)
        {
            this.x = columns;
            this.y = rows;
            this.sigma = sigma;
            this.meshPoints = new IPoint[y, x];
        }
        public override int rows
        {
            get { return this.y; }
            protected set { this.y = value; }
        }

        public override int colums
        {
            get { return this.x; }
            protected set { this.x = value; }
        }

        public override double sigma
        {
            get
            {
                return this.Sigma;
            }
            set
            {
                this.Sigma = value;
            }
        }
    }
}
