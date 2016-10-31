using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace GMESHFileStream.XMLFile
{
    public class XMLReader: IReader
    {
        private List<Poligon> poligon = new List<Poligon>();
        private List<Curve> curve = new List<Curve>();
        private List<Point> point = new List<Point>();
        private XmlSerializer xml = new XmlSerializer(typeof(Gmesh));
        private Gmesh buffer = new Gmesh();
        private Parser.XMLPreprocessing preprocessing;

        public int read(string filename, out Geometry.IContour contour)
        {
            Stream stream = File.Open(filename, FileMode.Open);
            initializeBuffer();
            this.buffer = (Gmesh)xml.Deserialize(stream);
            stream.Close();
            preprocessing = new Parser.XMLPreprocessing(buffer);
            preprocessing.convert(this, out contour);
            return 0;
        }
        public void initializeBuffer()
        {
            point.Add(new Point(0, 0, 0));
            curve.Add(new Curve(Curve.type_line.line, 0, null, null));
            poligon.Add(new Poligon(curve, point));
            buffer.Poligons = poligon;
        }
    }
}
