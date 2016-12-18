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
        private string[] args;
        private String pathToSave, pathToRead;
        private bool closeRunTimeFlag = false, analiseMesh = false;
        private double meshsEstimate = -1;
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
        public string[] Args
        {
            get { return this.args; }
            set { this.args = value; }
        }
        public bool CloseRunTimeFlag
        {
            get { return this.closeRunTimeFlag; }
            set { this.closeRunTimeFlag = value; }
        }
        public bool AnaliseMesh
        {
            get { return this.analiseMesh; }
            set { this.analiseMesh = value; }
        }
        public double MeshsEstimate
        {
            get { return this.meshsEstimate; }
            set { this.meshsEstimate = value; }
        }
        public void clearBuffer()
        {
            contour = new List<IContour>();
            meshs = new List<AbstractMesh>();
            args = null;
            pathToRead = null;
            pathToSave = null;
            analiseMesh = false;
            meshsEstimate = 0;
        }
    }
}
