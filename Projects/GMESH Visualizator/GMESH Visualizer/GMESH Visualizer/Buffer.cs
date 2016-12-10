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
        List<IPoint> points { get; set; }
        List<ICurve> lines { get; set; }
        List<IError> errors { get; set; }
        List<IContour> contour { get; set; }
        graph graph { get; set; }

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
