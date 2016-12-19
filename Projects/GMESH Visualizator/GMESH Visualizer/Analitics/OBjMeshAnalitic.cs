using System;
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
        List<IError> errors = new List<IError>();

        public List<IError> doAnalitics(Preprocessing.graph.edge[][] graph, List<IPoint> myLittlePoints, List<ICurve> curvesNeeded)
        {
            List<int> pows = new List<int>();
            
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
                    if(pointsRate.ContainsKey(elem.a))
                        pointsRate[elem.a] = pointsRate[elem.a] + 1;
                    else
                        pointsRate.Add(elem.a, 1);
                    if(pointsRate.ContainsKey(elem.b))
                        pointsRate[elem.b] = pointsRate[elem.b] + 1;
                    else
                        pointsRate.Add(elem.b, 1);
                }
            }

            foreach (KeyValuePair<int, int> point in pointsRate)
            {
                if (!(point.Value == 4 || point.Value == 2 || point.Value == 8))
                    errors.Add(new ErrorPoint(1, "wrong point rate", myLittlePoints[point.Key]));
            }
            
            foreach (ICurve i in curvesNeeded)
            {
                foreach (ICurve j in curvesNeeded)
                {
                    if (j == i) continue;
                    if (Tools.lineIntersectionCheck(i.getPoint(0.0), i.getPoint(1.0), j.getPoint(0.0), j.getPoint(1.0)) == true)
                    {
                        addErrorLineInErrorList(new ErrorCurve(1, "there is INTERSECTION!", i));
                        addErrorLineInErrorList(new ErrorCurve(2, "there is INTERSECTION!", j));
                    }
                }
            }
            return errors;
        }
        private void addErrorLineInErrorList(IError error)
        {
            if (!errors.Exists(t => t == error))
            {
                errors.Add(error);
            }
        }

    }
}
        
        
