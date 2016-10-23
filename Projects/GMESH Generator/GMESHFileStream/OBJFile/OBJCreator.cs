using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using System.IO;

namespace GMESHFileStream.OBJFile
{
    public class OBJCreator : IWriter
    {

        public int write(string filename, AbstractMesh[] mesh)
        {

            if (!File.Exists(filename))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filename))
                {
                    for (int i = 0; i < mesh[0].rows; i++)//колличесво строк в матрице
                        for (int j = 0; j < mesh[0].colums; j++)//колличество столбцов в матрице
                        {
                            sw.Write("v");
                            sw.Write(Convert.ToString(mesh[0][i, j].x));
                            sw.Write(" ");
                            sw.Write(Convert.ToString(mesh[0][i, j].y));
                            sw.Write(" ");
                            sw.Write("0");
                            sw.WriteLine();
                        }
                    sw.WriteLine("g all");
                    sw.WriteLine("s 1");

                    for (int k = 0; k < mesh[0].rows * mesh[0].colums - 1; k++)
                    {
                        sw.Write("l");
                        sw.Write(Convert.ToString(k));
                        sw.Write(" ");
                        sw.Write(Convert.ToString(k + 1));
                        sw.WriteLine();

                        sw.Write("l");
                        sw.Write(Convert.ToString(k));
                        sw.Write(" ");
                        sw.Write(Convert.ToString(k + mesh[0].rows));
                        sw.WriteLine();

                        sw.Write("l");
                        sw.Write(Convert.ToString(k + 1));
                        sw.Write(" ");
                        sw.Write(Convert.ToString(k + mesh[0].rows + 1));
                        sw.WriteLine();

                        sw.Write("l");
                        sw.Write(Convert.ToString(k));
                        sw.Write(" ");
                        sw.Write(Convert.ToString(k + mesh[0].rows));
                        sw.WriteLine();


                    }
                }
            }
            return 0;
        }
    }
}
