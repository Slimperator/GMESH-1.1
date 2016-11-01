using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GMESH_Generator.Commands
{
    public class Open: ICommand
    {
        private Buffer storage;
        private GMESHFileStream.IReader reader = new GMESHFileStream.XMLFile.XMLReader();
        public Open()
        {
            storage = Buffer.getInstance();
        }

        public void callBack()
        {
            Console.WriteLine("Читаем файл...");
            string e = Path.GetExtension(storage.PathRead);
            if (e == ".xml")
            {
                Geometry.IContour contour;
                reader.read(storage.PathRead, out contour);
                Geometry.IContour[] contours = new Geometry.IContour[1] { contour};
                storage.Contour = contours;
                if (storage.Contour != null)
                {
                    Console.WriteLine("Готово");
                }
            }
        }
        
    }
}
