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
    public class Point
    {
        [XmlAttribute]
        public uint id;
        [XmlAttribute]
        public double x { get; set; }
        [XmlAttribute]
        public double y { get; set; }

        public Point() { }
        /// <summary>
        /// Часть буфера, хранящего данные с xml документа.
        /// Хранит информацию о точке
        /// </summary>
        public Point(uint id, double x, double y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
        }
    }
}
