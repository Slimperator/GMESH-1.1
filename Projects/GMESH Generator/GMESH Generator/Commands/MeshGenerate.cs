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
            switch (storage.Contour[0].getSize())                //определяем необходимость декомпозиции контура
            {
                case 3:
                    Console.WriteLine("Декомпозируем треугольник...");
                    decomposeContourLine(storage.Contour[0]);
                    decomposer = new Decompose.Triangle.TriangleDecompose();
                    storage.Contour = decomposer.decompose(storage.Contour[0]);
                    break;
                case 5:
                    Console.WriteLine("Декомпозируем четырехугольник...");
                    IContour[] cs1, cs2;
                    decomposeContourLine(storage.Contour[0]);                    //Разбили контур
                    decomposer = new Decompose.Pentagon.PentagonDecTetraAndTri();    //погрузили в пятиугольный
                    cs1 = decomposer.decompose(storage.Contour[0]);        //получили контур, где 0 - треугольник, 1 четыреугольник
                    decomposer = new Decompose.Triangle.TriangleDecompose(); //погружаем треугольник в декомпозитор
                    cs2 = decomposer.decompose(cs1[0]);
                    List <IContour>cs = new  List<IContour>();
                    cs.Add(cs1[1]);
                    cs.Add(cs2[0]);
                    cs.Add(cs2[1]);
                    cs.Add(cs2[2]);
                    storage.Contour = cs.ToArray();
                    break;
            }
            Console.WriteLine("Генерируем сетку...");
            foreach (IContour x in storage.Contour)       //для всех контуров генерируем сетку
            {
                decomposeContourLine(x);
                meshs.Add(generetor.generate(x));
            }
            storage.Meshs = meshs.ToArray();
        }
        private void decomposeContourLine(IContour contour)
        {
            for (int i = 0; i < contour.getSize(); i++)
            {
                if (contour[i].cutPoints == null)
                    Geometry.Curve.Tools.slittingCurve(contour.lenghtOfPart, contour[i]);
            }
        }
    }
}
