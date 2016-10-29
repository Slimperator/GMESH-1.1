using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMESHFileStream;

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

            writer.write(storage.PathSave,storage.Meshs, storage.Contour);             //сохраняем
        }
    }
}
