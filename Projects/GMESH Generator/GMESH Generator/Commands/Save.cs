using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMESHFileStream;
using System.IO;

namespace GMESH_Generator.Commands
{
    public class Save: ICommand
    {
        private Buffer storage;         //тут у нас пути сохранения, сетки, контура. буфер, в общем.
        private GMESHFileStream.IWriter writer = new GMESHFileStream.OBJFile.OBJCreator();            //создаем экземпляр писалки
        public Save()                   
        {
            storage = Buffer.getInstance(); //в конструкторе берем ссылку на наш буфер
        }
        public void callBack()
        {
            if (storage.Meshs == null || storage.PathSave == null)   //проверяем, есть ли что сохранять, и есть ли куда сохранять
                return;
            Console.WriteLine("Пишем сетку...");
            writer.write(storage.PathSave,storage.Meshs);             //сохраняем
            if (storage.AnaliseMesh == true)
            {
                string path = Path.GetDirectoryName(storage.PathRead) + @"\" + Path.GetFileNameWithoutExtension(storage.PathRead) + "GradAnalize.txt";
                File.Create(path);
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine(Convert.ToSingle(storage.MeshsEstimate));
                }
                storage.AnaliseMesh = false;
            }
        }
    }
}
