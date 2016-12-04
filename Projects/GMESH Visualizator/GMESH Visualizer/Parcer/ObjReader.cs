using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using Geometry.Point;
using System.IO;

namespace Parcer
{
    public class ObjReader
    {
        public List<IPoint> objReader(string path)
        {
            List<IPoint> listPoint = new List<IPoint>();//сюдабудем писать вершинки
            StreamReader objReader = new StreamReader(path);
            string[] objPoints;
            string[] objLines;
            int[] objPointsID = new int[3];//значение х у для каждой точки
            List<int> forPows = new List<int>();
            IPoint tmp = null;
            char delimiter = ' ';
            string line;
            //String[] substrings = value.Split(delimiter);

            while ((line = objReader.ReadLine()) != null)
            {
                if (line.ToString() != "")
                {
                    if (line[0].ToString() == "v")
                    {
                        objPoints = line.Split(delimiter);
                        listPoint.Add(new Point2D(Convert.ToDouble(objPoints[1]), Convert.ToDouble(objPoints[2])));

                    }
                    // else break;
                    if (line[0].ToString() == "l")
                    {
                        objLines = line.Split(delimiter);
                        forPows.Add(Convert.ToInt32(objLines[1]));
                        forPows.Add(Convert.ToInt32(objLines[2]));
                    }


                }
                forPows.Sort();
                var arr = forPows.GroupBy(j => j).Select(j => j.Count()).ToArray();
                for (int i = 1; i < listPoint.Count; i++)
                {
                    listPoint[i].rate = arr[i];
                }
            }
            return listPoint;
        }

    }
}
