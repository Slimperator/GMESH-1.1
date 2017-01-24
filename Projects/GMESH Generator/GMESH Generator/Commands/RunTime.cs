using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GMESH_Generator.Commands
{
    public class RunTime: ICommand
    {
        private Dictionary<Params, string> keys = new Dictionary<Params, string>()
        {
            {Params.SavePath, "-s"},
            {Params.OpenPath, "-o"},
            {Params.HelpCommand, "-help"},
            {Params.Close, "-cl"},
            {Params.Analizer, "-q"},
            {Params.CloseAfterRun, "-cl"},
            {Params.OpenAfterRun, "-nc"},
        };
        private string[] args;
        private Buffer buffer = Buffer.getInstance();
        private bool exitFlag = false, saveFlag = false, openFlag = false;
        private ICommand command;
        public void callBack()
        {
            //берем аргументы из буфера
            args = buffer.Args;
            //ищем аргументы в словаре
            foreach (string arg in args)
            {
                if (saveFlag == true)
                {   //проверяем, верен ли путь. если нет, завершаем чтение команд
                    string path = arg; //.Substring(2, arg.Length - 4);
                    if (Directory.Exists(Path.GetDirectoryName(path)))
                    {
                        buffer.PathSave = path;
                        saveFlag = false;
                        continue;
                    }
                    else
                    {
                        buffer.Args = null;
                        saveFlag = false;
                        return;
                    }
                }
                if (openFlag == true)
                {   //проверяем, верен ли путь. если нет, завершаем чтение команд
                    string path = arg;//arg.Substring(1, arg.Length-2);
                    if (Directory.Exists(Path.GetDirectoryName(path)) && File.Exists(path))
                    {
                        buffer.PathRead = path;
                        openFlag = false;
                        continue;
                    }
                    else
                    {
                        buffer.Args = null;
                        openFlag = false;
                        return;
                    }
                }
                switch (argumentSearcher(arg))
                {
                    case Params.SavePath:
                        saveFlag = true;
                        break;
                    case Params.OpenPath:
                        openFlag = true;
                        break;
                    case Params.OpenAfterRun:
                        buffer.CloseRunTimeFlag = false;
                        break;
                    case Params.HelpCommand:
                        buffer.clearBuffer();
                        command = new Commands.Help();
                        command.callBack();
                        exitFlag = true;
                        break;
                    case Params.CloseAfterRun:
                        buffer.CloseRunTimeFlag = true;
                        break;
                    case Params.Close:
                        exitFlag = true;
                        buffer.CloseRunTimeFlag = true; //посылаем сигнал, что программа отработала
                        break;
                    case Params.Analizer:
                        buffer.AnaliseMesh = true;
                        break;
                    default:
                        exitFlag = true;
                        break;
                }
                if (exitFlag == true)
                {
                    buffer.clearBuffer();
                    return;
                }
            }
            if (buffer.PathRead == null || buffer.PathRead == "")
                return;
            command = new Commands.Open();
            command.callBack();
            command = new Commands.MeshGenerate();
            command.callBack();
            //если путь для сейва не указан, берем родительский каталог и сохраняем сетку под тем же именем
            if (buffer.PathSave == null || buffer.PathSave == "")
                buffer.PathSave = Path.GetDirectoryName(buffer.PathRead) + @"\" + Path.GetFileNameWithoutExtension(buffer.PathRead) + "MESH.obj";
            if (buffer.AnaliseMesh == true)
            {
                command = new Commands.GradAnalize();
                command.callBack();
            }
            command = new Commands.Save();
            command.callBack();
            buffer.clearBuffer();
        }
        private Params argumentSearcher(string arg)
        {
            //ищем аргумент в словаре по значениям. Если нашли, возвращаем ключ. Если нет, возвращаем ничего
            string str = arg + "           "; //костылек :)
            try
            {
                return keys.First(t => t.Value == str.Substring(0, t.Value.Length)).Key;
            }
            catch
            {
                return Params.Nothing;
            }
        }
    }
}
