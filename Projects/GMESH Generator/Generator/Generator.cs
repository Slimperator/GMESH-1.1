using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Generator
{
    public class Generator : IMeshGenerator
    {
        public Generator()
        {
        }
        public AbstractMesh generate(IContour contour)
        {
            int minRows = Math.Min(contour[1].cutPoints.Length, contour[3].cutPoints.Length);          //находим минимум по-бокам
            int minColumns = Math.Min(contour[0].cutPoints.Length, contour[2].cutPoints.Length);        //находим минимум сверху и снизу
            AbstractMesh mesh = new RegMesh2D(minRows, minColumns, 0);
            double magic = (double)1 / (minRows - 1 );
            IPoint A, B;
            ICurve morphCurve;
            for (int i = 0; i < minColumns; i++)        //заполняем сетку точками верхней границы
            {
                mesh[0, i] = contour[0].cutPoints[i];
            }
            for (int i = 1; i < minRows - 1; i++)           //для всех строк, кроме первой и последней
            {
                A = contour[3].cutPoints[minRows - i - 1];            //Находим точки на боковых линиях, для их морфирования
                B = contour[1].cutPoints[i];
                morphCurve = new Geometry.Curve.Relocate(new Geometry.Curve.Morph(contour[2], contour[0], i * magic), A, B); //находим морфированную кривую.
                Geometry.Curve.Tools.slittingCurve(minColumns, morphCurve);
                for (int j = 0; j < morphCurve.cutPoints.Length; j++)      //для всех ячеек в строке
                {
                    mesh[i, j] = morphCurve.cutPoints[j];
                }
            }
            for (int i = 0; i < minColumns; i++)        //заполняем сетку точками нижней границы
            {
                mesh[minRows - 1, i] = contour[2].cutPoints[contour[2].cutPoints.Length - 1 - i];
            }
            return mesh;
        }
    }
}
