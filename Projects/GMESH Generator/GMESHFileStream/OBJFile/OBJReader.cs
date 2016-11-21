using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using System.IO;

namespace GMESHFileStream.OBJFile
{
    public class OBJReader
    {
        public void read(string path, out List<IPoint> points, out List<ICurve> curves)
        {
            points = new List<IPoint>();
            curves = new List<ICurve>();
            StreamReader objReader = new StreamReader(path);
            string[] objPoints;
            int[] objPointsID = new int[3];
            IPoint tmp = null;
            char delimiter = 's';
            string line;
            //String[] substrings = value.Split(delimiter);
            
            while ((line = objReader.ReadLine()) != null)
            {

                if (line[0].ToString() == "v")
                {
                    objPoints = line.Split(delimiter);
                    tmp.x = Convert.ToDouble(objPoints[1]);
                    tmp.y = Convert.ToDouble(objPoints[2]);
                    points.Add(tmp);
                }
               // else break;
                    if (line[0].ToString() == "l")
                    {
                       
                        for (int i=0; i< line.Count(); i++)
                        {
                            objPointsID[i] = line[i];
                        }
                        
                        curves.Add(new Geometry.Curve.Line(points[objPointsID[1] - 1], points[objPointsID[2]-1]));

                        
                    }
                
               
            }

        }
    }
}
