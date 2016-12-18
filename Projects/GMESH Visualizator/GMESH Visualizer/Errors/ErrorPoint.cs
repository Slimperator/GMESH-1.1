using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Errors
{
    public class ErrorPoint: IError
    {
        private int errorId;
        private string errorMasage;
        private IPoint errorPoint;

        public ErrorPoint(int errorId, string errorMasage, IPoint errorPoint)
        {
            this.errorId = errorId;
            this.errorMasage = errorMasage;
            this.errorPoint = errorPoint;
        }

        public string getInfo()
        {
            string error = "Error Point: x=" + Convert.ToSingle(errorPoint.x) + ", y=" + Convert.ToSingle(errorPoint.y) + 
                "; error ID = " + errorId + ";" + 
                " Error Masage: " + errorMasage + ";";
            return error;
        }

        public int getErrorObjectHesh()
        {
            return this.errorPoint.GetHashCode();
        }


        public string getErrorObjectType()
        {
            return "point";
        }
    }
}
