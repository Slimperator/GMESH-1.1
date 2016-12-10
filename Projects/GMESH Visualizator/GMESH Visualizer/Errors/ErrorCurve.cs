using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace Errors
{
    class ErrorCurve: IError
    {
        private int errorId;
        private string errorMasage;
        private ICurve errorCurve;

        public ErrorCurve(int errorId, string errorMasage, ICurve errorCurve)
        {
            this.errorId = errorId;
            this.errorMasage = errorMasage;
            this.errorCurve = errorCurve;
        }

        public string getInfo()
        {
            string error = "Error Curve: x1=" + Convert.ToSingle(errorCurve.getPoint(0.0).x) + ", y1=" + Convert.ToSingle(errorCurve.getPoint(0.0).y) +
                ", x2=" + Convert.ToSingle(errorCurve.getPoint(1.0).x) + ", y2=" + Convert.ToSingle(errorCurve.getPoint(1.0).y) +
                "; error ID = " + errorId + ";" + 
                " Error Masage: " + errorMasage + ";";
            return error;
        }
    }
}
