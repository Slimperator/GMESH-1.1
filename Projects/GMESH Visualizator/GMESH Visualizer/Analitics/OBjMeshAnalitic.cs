﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using Parcer;
using Errors;

namespace Analitics
{
    public class OBjMeshAnalitic
    {
        public readonly int rate;
        public OBjMeshAnalitic() {}

        public List<IError> doAnalitics(Preprocessing.graph.edge[][] graph, List<IPoint> myLittlePoints)
        {
            List<int> pows = new List<int>();
            List<IError> errors = new List<IError>();
            Dictionary<int, int> pointsRate = new Dictionary<int, int>();
            foreach (Preprocessing.graph.edge[] array in graph)
            {
                if (array.Length != 4)
                {
                    Dictionary<IPoint, int> wrongPoly = new Dictionary<IPoint, int>();
                    foreach (Preprocessing.graph.edge elem in array)
                    {
                        wrongPoly.Add(myLittlePoints[elem.a], elem.a);
                    }
                    errors.Add(new ErrorPoligon(1, "wrong poligon", wrongPoly));
                }
                foreach (Preprocessing.graph.edge elem in array)
                {
                    try
                    {
                        var r = pointsRate.First(t => t.Key == elem.a);
                        pointsRate[r.Key] = r.Value + 1;
                    }
                    catch
                    {
                        pointsRate.Add(elem.a, 1);
                    }
                    try
                    {
                        var r = pointsRate.First(t => t.Key == elem.b);
                        pointsRate[r.Key] = r.Value + 1;
                    }
                    catch
                    {
                        pointsRate.Add(elem.b, 1);
                    }
                }
            }


            foreach (KeyValuePair<int, int> point in pointsRate)
            {
                if (point.Value > 4 || point.Value < 2)
                    errors.Add(new ErrorPoint(1, "wrong point rate", myLittlePoints[point.Key]));
            }
            return errors;
        }

    }
}
        
        
