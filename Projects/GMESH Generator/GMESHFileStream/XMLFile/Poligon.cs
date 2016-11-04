using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace GMESHFileStream.XMLFile
{
    [Serializable]
    public class Poligon
    {
        [XmlArrayItem]
        public List<Curve> Curves;
        [XmlArrayItem]
        public List<Point> Points;

        public Poligon() { }
        /// <summary>
        /// Часть буфера, хранящего данные с xml документа.
        /// Хранит список Кривых и список Точек.
        /// </summary>
        public Poligon(List<Curve> Curves, List<Point> Points)
        {
            this.Curves = Curves;
            this.Points = Points;
        }
    }
}
