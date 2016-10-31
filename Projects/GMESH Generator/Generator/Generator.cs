using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Generator
{
    public class Generator:IMeshGenerator
    {
        public Generator()
        { 
        }
        public AbstractMesh generate(IContour contour)
        {
            int minRows = Math.Min(contour[1].cutPoints.Length, contour[3].cutPoints.Length);          //находим минимум по-бокам
            int minColumns = Math.Min(contour[0].cutPoints.Length, contour[2].cutPoints.Length);        //находим минимум сверху и снизу
            AbstractMesh mesh = new RegMesh2D(minRows, minColumns, 0);
            IPoint A, B;
            ICurve morphCurve;
            for (int i = 0; i < minRows; i++)           //для всех строк
            {
                A = contour[3].cutPoints[minRows - i - 1];            //Находим точки на боковых линиях, для их морфирования
                B = contour[1].cutPoints[i];  
                morphCurve = new Geometry.Curve.Relocate(new Geometry.Curve.Morph(contour[2], contour[0], i / minRows), A, B); //находим морфированную кривую.
                Geometry.Curve.Tools.slittingCurve(minColumns,morphCurve);
                for (int j = 0; j < morphCurve.cutPoints.Length; j++)      //для всех ячеек в строке
                {
                    mesh[i, j] = morphCurve.cutPoints[j];
                }
            }
            return mesh;
        }
    }
}
