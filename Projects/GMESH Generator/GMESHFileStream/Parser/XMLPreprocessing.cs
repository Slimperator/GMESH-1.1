using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;

namespace GMESHFileStream.Parser
{
    public class XMLPreprocessing: IPreprocessing
    {
        private IReader XMLreader;
        private GMESHFileStream.XMLFile.Gmesh xmlData;
        public XMLPreprocessing(GMESHFileStream.XMLFile.Gmesh xmlData)
        {
            this.xmlData = xmlData;
        }
        public void convert(IReader reader, out IContour contour)
        {
            XMLreader = reader;
            List <IPoint> points = new List<IPoint>();  
            List <ICurve> curves = new List<ICurve>();    
            foreach(XMLFile.Poligon poligon in xmlData.Poligons)
            {
                foreach(XMLFile.Point point in poligon.Points)              //Создаем объекты точек
                {
                    points.Add(new Geometry.Point.Point2D(point.x,point.y));
                }
                foreach(XMLFile.Curve curve in poligon.Curves)               //для каждой линии находим нужные точки в нашем списке
                {
                    if(curve.type == XMLFile.Curve.type_line.line)
                    {
                        curves.Add(new Geometry.Curve.Line(points[(int)curve.points[0]],points[(int)curve.points[1]]));
                    }
                    else
                    {
                         curves.Add(new Geometry.Curve.Bezier(points[(int)curve.points[0]],points[(int)curve.points[1]],points[(int)curve.points[2]],points[(int)curve.points[3]]));
                    }
                }
            }
            contour = new Geometry.Contour.Contour(curves.ToArray());           //отдаем контур
        }
    }
}

