using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry.Contour
{
    public class Tools
    {   //ВНИМАНИЕ!!! Для фигур больше 5-угольника использовать ТОЛЬКО с универсальным алгоритмом декомпозиции. С остальными будет лажа
        public static List<IContour> greedyContourDivader(List<IContour> contours, double partSize)
        {
            List<IContour> result = new List<IContour>();
            IContour currentContour = null;
            ICurve beginCurve = null;
            int index = 0;
            //ищем самую маленькую кривую. с неё начинаем разрезку.
            for (int j =0; j < contours.Count; j++)
            {
                for (int i = 0; i < contours[j].getSize(); i++)
                {
                    contours[j][i].cutParams = null;
                    contours[j][i].cutPoints = null;
                    if (beginCurve == null || beginCurve.lenght >= contours[j][i].lenght)
                    {
                        beginCurve = contours[j][i];
                        currentContour = contours[j];
                        index = i;
                    }
                }
            }
            //режем первую кривую. Если длина самой маленькой кривой меньше или равно длине ячейки, то уменьшаем длину ячейки на разницу между кривой и ячейкой
            //если они равны, то уменьшаем длину ячейки на 0.1
            if (currentContour[index].lenght < partSize)
                partSize = partSize - (partSize - currentContour[index].lenght);
            if (currentContour[index].lenght == partSize)
                partSize *= 0.1;
            Curve.Tools.slittingCurve(partSize, currentContour[index]);
            //режем по-очереди все контура
            while (contours.Count != 0)
            {
                //ищем индекс контура с целой разрезанной стороной
                index = findeIndexContourWithCutCurve(contours);
                //записываем его в промежуточную переменную
                IContour newContour = contours[index];
                //режем контур на кусочки
                cutContour(ref newContour, partSize);
                //результат записываем в новый список, удаляем контур по индексу из старого списка
                result.Add(newContour);
                contours.RemoveAt(index);
            }
            return result;
        }
        private static void cutContour(ref IContour contour, double partSize)
        {
            ICurve north = contour[0], south = contour[2], east = contour[1], west = contour[3];
            //смотрим верхнюю и нижнюю границы
            cutBoard(ref north, ref south, partSize);
            //смотрим боковые границы
            cutBoard(ref east, ref west, partSize);
            contour[0] = north;
            contour[1] = east;
            contour[2] = south;
            contour[3] = west;
        }
        private static void cutBoard(ref ICurve curve1, ref ICurve curve2, double partSize)
        {
            //если обе кривые не разрезаны, ищем меньшую, режем её, потом режем противоположную на тоже количество точек
            if ((curve1.cutPoints == null || curve1.cutPoints.Length == 0) & (curve2.cutPoints == null||curve2.cutPoints.Length == 0))
            {
                if (curve1.lenght < curve2.lenght)
                {
                    Curve.Tools.slittingCurve(partSize, curve1);
                    Curve.Tools.slittingCurve(curve1.cutPoints.Length, curve2);
                }
                else 
                {
                    Curve.Tools.slittingCurve(partSize, curve2);
                    Curve.Tools.slittingCurve(curve2.cutPoints.Length, curve1);
                }
                return;
            }
            //иначе ищем кривую, которая уже разрезана, и режем противоположную на тоже количество точек
            if (curve1.cutPoints != null && curve1.cutPoints.Length != 0)
            {
                Curve.Tools.slittingCurve(curve1.cutPoints.Length, curve2);
            }
            else
            {
                Curve.Tools.slittingCurve(curve2.cutPoints.Length, curve1);
            }
        }
        private static int findeIndexContourWithCutCurve(List<IContour> contours)
        {
            foreach (IContour contour in contours)
            {
                for (int i = 0; i < contour.getSize(); i++)
                {
                    //если прямая уже разрезана
                    if (contour[i].cutPoints != null & contour[i].cutParams != null)
                    {   //если у прямой нет потомков
                        if (contour[i].childCurves == null || contour[i].childCurves.Count == 0)
                            return contours.IndexOf(contour);
                        else 
                        { //или все потомки уже разрезаны
                            if (!contour[i].childCurves.Exists(t => t.cutPoints == null))
                            {
                                return contours.IndexOf(contour);
                            }
                        }
                    }
                }
            }
            return -1;
        }
    }
}
