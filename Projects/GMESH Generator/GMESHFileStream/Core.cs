using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace GMESHFileStream
{
    public interface IWriter
    {
        int write(string filename, AbstractMesh[] mesh);
    }

    public interface IReader
    {
        int read(string filename, out IContour contour);
    }
    public interface IPreprocessing
    {
        void convert(IReader reader, out IContour contour);
    }

    public interface IPostprocessing
    {
        void convert(IWriter writer, AbstractMesh[] meshs);
    }
}
