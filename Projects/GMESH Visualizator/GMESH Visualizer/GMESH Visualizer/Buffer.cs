using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using Preprocessing;
using Errors;

namespace GMESH_Visualizer
{
    public class Buffer
    {
        static Buffer instance = null;
        public List<IPoint> points { get; set; }
        public List<ICurve> lines { get; set; }
        public List<IError> errors { get; set; }
        public List<IContour> contour { get; set; }
        public graph.edge[][] graph { get; set; }
        public double meshGrad { get; set; }

        private Buffer()
        { }
        static public Buffer getInstance()
        {
            if (instance == null)
                instance = new Buffer();
            return instance;
        }
        public void clearBuffer()
        {
            this.points = null;
            this.lines = null;
            this.errors = null;
            this.contour = null;
            this.graph = null;
            this.meshGrad = 0;
        }
    }
}
