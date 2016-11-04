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
    public class Gmesh
    {
        [XmlArrayItem]
        public List<Poligon> Poligons = new List<Poligon>();
        /// <summary>
        /// Буфер, хранящий данные с xml документа.
        /// Хранит список полигонов.
        /// </summary>
        public Gmesh() { }
    }
}