using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GMESH_Generator.Commands
{
    public class Help: ICommand
    {
        public void callBack()
        {
            Console.WriteLine("******Help*****");
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("-o \"FullPathName\" - открытие файла (.XML) по указанному пути");
            Console.WriteLine("-s \"FullSaveName\" - указывает директорию для сохранения файла с сеткой (.OBJ).");
            Console.WriteLine("                      По-умолчанию: сохраняется в дирикторию исходника с таким же именем");
            Console.WriteLine("-help               - выводит справочную информацию о коммандах");
            Console.WriteLine("-cl                 - завершает сеанс программы. Если стоит в конце набора параметров, то завершит после их исполнения");
            Console.WriteLine("-q                  - вывод качества сетки в файл (.TXT) в дирикторию сохранения файла сетки. Сохраняется с тем же именем");
            Console.WriteLine("-nc                 - оставить программу открытой после выполнения при запуске из командной строки");
        }
    }
}
