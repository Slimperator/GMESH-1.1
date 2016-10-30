using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generator;
using Geometry;
using Decompose;

namespace GMESH_Generator.Commands
{
    public class MeshGenerate: ICommand
    {
        private Buffer storage;
        private IDecompose decomposer;
        private IMeshGenerator generetor;
        private List<AbstractMesh> meshs = new List<AbstractMesh>();
        public MeshGenerate()
        {
            storage = Buffer.getInstance();
            generetor = new Generator.Generator();
        }
        public void callBack()
        {
            if (storage.Contour == null) 
                return;
            switch (storage.Contour.Length)                //определяем необходимость декомпозиции контура
            {
                case 3:
                    decomposer = new Decompose.Triangle.TriangleDecompose();
                    storage.Contour = decomposer.decompose(storage.Contour[0]);
                    break;
                case 5:
                    decomposer = new Decompose.Pentagon.PentagonDecTetraAndTri();
                    storage.Contour = decomposer.decompose(storage.Contour[0]);
                    break;
            }
            foreach (IContour x in storage.Contour)       //для всех контуров генерируем сетку
            {
                meshs.Add(generetor.generate(x));
            }
            storage.Meshs = meshs.ToArray();
        }
        /*private void decomposeContourLine(IContour contour)
        {
            for (int i = 0; i < 4; i++)
            {
                if (contour[i].cutPoints == null)
                    Geometry.Curve.Tools.slittingCurve()
            }
        }*/
    }
}
