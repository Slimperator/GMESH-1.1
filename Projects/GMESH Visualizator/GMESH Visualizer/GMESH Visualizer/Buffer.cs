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

        private Buffer()
        { }
        static public Buffer getInstance()
        {
            if (instance == null)
                instance = new Buffer();
            return instance;
        } 
    }
}
