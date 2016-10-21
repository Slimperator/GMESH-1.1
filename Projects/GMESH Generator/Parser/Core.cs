using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using GMESHFileStream;

namespace Parser
{
    public interface IPreprocessing
    {
        void convert(IReader reader, out IContour contour);
    }

    public interface IPostprocessing
    {
        void convert(IWriter writer, AbstractMesh[] meshs);
    }
}
