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
    public class Curve
    {
        public enum type_line { line, bezier }
        [XmlAttribute]
        public uint id;
        [XmlAttribute]
        public type_line type;
        [XmlArrayItem("ID")]
        public List<uint> points;
        [XmlArrayItem]
        public List<string> special;

        public Curve() { }
        /// <summary>
        /// Часть буфера, хранящего данные с xml документа.
        /// Хранит информацию о кривой. Список точек представлен их id. Special - специальные параметры кривой.
        /// </summary>
        public Curve(type_line type, uint id, List<uint> points, List<string> special)
        {
            this.type = type;
            this.id = id;
            this.points = points;
            this.special = special;
        }
    }
}
