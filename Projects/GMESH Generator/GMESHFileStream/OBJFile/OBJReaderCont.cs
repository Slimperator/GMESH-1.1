﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using Geometry.Point;
using System.IO;

namespace GMESHFileStream.OBJFile
{
    public class OBJReaderCont : IReader
    {
        public int read(string filename, out IContour contour)
        {
            List<IPoint> listPoint = new List<IPoint>();//сюдабудем писать вершинки
            List<ICurve> listCurve = new List<ICurve>();//сюда отрезки
            List<int> someInts = new List<int>();//индексы точек(от 0)
            StreamReader objReader = new StreamReader(filename);
            string[] objPoints;//для парсинга строки
            string[] objLines;//для парсинга строки
            int[] objPointsID = new int[3];//значение х у для каждой точки
            List<int> forPows = new List<int>();
            char delimiter = ' ';
            string line;
            while ((line = objReader.ReadLine()) != null)
            {
                if (line.ToString() != "")
                {
                    if (line[0].ToString() == "v")
                    {
                        objPoints = line.Split(delimiter);
                        listPoint.Add(new Point2D(Convert.ToDouble(objPoints[1]), Convert.ToDouble(objPoints[2])));

                    }
                    if (line[0].ToString() == "l")
                    {

                        objLines = line.Split(delimiter);
                        someInts.Add(Convert.ToInt32(objLines[1]) - 1);
                        someInts.Add(Convert.ToInt32(objLines[2]) - 1);
                        listCurve.Add(new Geometry.Curve.Line(listPoint[Convert.ToInt32(objLines[1]) - 1], listPoint[Convert.ToInt32(objLines[2]) - 1]));
                    }
                }
            }
            contour = new Geometry.Contour.Contour(listCurve.ToArray());
            return 0;
        }
    }
}


