using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Errors
{
    public class ErrorPoligon
    {
        private int errorId;
        private string errorMasage;
        private List<int[]> errorPoligon;

        public ErrorPoligon(int errorId, string errorMasage, List<int[]> errorPoligon)
        {
            this.errorId = errorId;
            this.errorMasage = errorMasage;
            this.errorPoligon = errorPoligon;
        }

        public string getInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Error Poligon:");
            foreach(int[] i in errorPoligon)
            {
                sb.AppendFormat(" Point {0}:",errorPoligon.IndexOf(i));
                sb.AppendFormat(" x:{0}; y:{1};", i[0], i[1]);
            }
            sb.AppendLine(" error ID = " + errorId + ";" +
                " Error Masage: " + errorMasage + ";");
            return sb.ToString();
        }
    }
}
