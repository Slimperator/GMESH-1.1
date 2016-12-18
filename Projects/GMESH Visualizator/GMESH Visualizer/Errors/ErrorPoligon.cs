using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using Preprocessing;

namespace Errors
{
    public class ErrorPoligon:IError
    {
        private int errorId;
        private string errorMasage;
        private Dictionary<IPoint,int> errorPoligon;

        public ErrorPoligon(int errorId, string errorMasage, Dictionary<IPoint,int> errorPoligon)
        {
            this.errorId = errorId;
            this.errorMasage = errorMasage;
            this.errorPoligon = errorPoligon;
        }

        public string getInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Error Poligon:");
            foreach (KeyValuePair<IPoint, int> i in errorPoligon)
            {
                sb.AppendFormat(" Point {0}:",i.Value);
                sb.AppendFormat(" x:{0}; y:{1};", i.Key.x, i.Key.y);
            }
            sb.AppendLine(" error ID = " + errorId + ";" +
                " Error Masage: " + errorMasage + ";");
            return sb.ToString();
        }

        public int getErrorObjectHesh()
        {
            return this.errorPoligon.GetHashCode();
        }


        public string getErrorObjectType()
        {
            return "poligon";
        }
    }
}
