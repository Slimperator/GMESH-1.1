using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace GMESH_Generator
{
    public class Buffer                  //синглтон хранилище
    {
        private static Buffer instance;
        private List <IContour> contour = new List<IContour>();
        private List<AbstractMesh> meshs = new List<AbstractMesh>();
        private String pathToSave, pathToRead;
        public Buffer() { }
        public static Buffer getInstance()
        {
            if (instance==null)
            {
                instance = new Buffer();
            }
            return instance;
        }
        public IContour[] Contour
        {
            get { return contour.ToArray(); }
            set { this.contour = value.ToList(); }
        }
        public AbstractMesh[] Meshs
        {
            get { return meshs.ToArray(); }
            set { this.meshs = value.ToList(); }
        }
        public String PathSave
        {
            get { return pathToSave; }
            set { this.pathToSave = value; }
        }
        public String PathRead
        {
            get { return pathToRead; }
            set { this.pathToRead = value; }
        }
    }
}
