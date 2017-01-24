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
        private GMESHFileStream.IReader reader;
        public Open()
        {
            storage = Buffer.getInstance();
        }

        public void callBack()
        {
            Console.WriteLine("Читаем файл...");
            try
            {
                string e = Path.GetExtension(storage.PathRead);
                if (e == ".xml")
                {
                    reader = new GMESHFileStream.XMLFile.XMLReader();
                    Geometry.IContour contour;
                    reader.read(storage.PathRead, out contour);
                    Geometry.IContour[] contours = new Geometry.IContour[1] { contour };
                    storage.Contour = contours;
                    if (storage.Contour != null)
                    {
                        Console.WriteLine("Готово");
                    }
                }
                if (e == ".obj")
                {
                    reader = new GMESHFileStream.OBJFile.OBJReaderCont();
                    Geometry.IContour contour;
                    reader.read(storage.PathRead, out contour);
                    Geometry.IContour[] contours = new Geometry.IContour[1] { contour };
                    storage.Contour = contours;
                    if (storage.Contour != null)
                    {
                        Console.WriteLine("Готово");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ошибка при чтении файла");
            }
        }
        
    }
}
