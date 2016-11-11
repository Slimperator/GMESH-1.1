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

        public int write(string filename, AbstractMesh[] mesh, IContour[] Contours)
        {
            int[] numbers_in_real = new int[Contours.Count()];
            numbers_in_real[0] = 0;
            bool flagEqualsCurve = false;
            int[] i_control = new int[Contours.Count()];
            bool[] i_control_bool = new bool[Contours.Count()];
            int[] exstra_lines_count = new int[Contours.Count()];//размерность смежных кривых
            // bool[] j_control_bool = new bool[Contours.Count()];
            for (int i = 0; i < Contours.Count() - 1; i++)//берём 1ый контур из списка
                for (int j = 0; j < Contours.Count(); j++)//ищем соприкасаюиеся контуры. 
                {
                    if (j == i)
                        continue;
                    for (int k = 0; k < 4; k++)//ищем по сторонам    
                        for (int t = 0; t < 4; t++)
                        {

                            flagEqualsCurve = Geometry.Curve.Tools.equalityCurves(Contours[i][k], Contours[j][t]);
                            if (flagEqualsCurve == true)
                            {
                                flagEqualsCurve = Geometry.Curve.Tools.equalityCurves(Contours[i][k], Contours[j][t]);
                                numbers_in_real[i + 1] = j;
                                i_control[i] = k;
                                i_control[i + 1] = t;
                                if (k % 2 == 0)
                                {
                                    i_control_bool[i] = true;
                                }
                                else i_control_bool[i] = false;
                                if (t % 2 == 0)
                                {
                                    i_control_bool[i + 1] = true;
                                }
                                else i_control_bool[i + 1] = false;
                                break;
                            }

                        }
                    if (flagEqualsCurve)
                        break;
                }
            if (!File.Exists(filename))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filename))
                {

                    int i_i = 0;
                    int j_j = 0;
                    for (int c = 0; c < Contours.Count(); c++)
                    {
                        if (c == 0)
                        {
                            i_i = 0;
                            j_j = 0;
                            for (int i = i_i; i < mesh[numbers_in_real[c]].rows; i++)//колличесво строк в матрице
                                for (int j = j_j; j < mesh[numbers_in_real[c]].colums; j++)//колличество столбцов в матрице
                                {

                                    sw.Write("v");
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(mesh[numbers_in_real[c]][i, j].x));
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(mesh[numbers_in_real[c]][i, j].y));
                                    sw.Write(" ");
                                    sw.Write("0");
                                    sw.WriteLine();
                                    sw.WriteLine();
                                    sw.WriteLine();
                                    sw.WriteLine();
                                }
                            continue;
                        }

                        if ((i_control_bool[c] == true) && (i_control[c] != 0))//строка 2
                        {
                            exstra_lines_count[c] = mesh[numbers_in_real[c]].colums;
                            i_i = mesh[numbers_in_real[c]].rows - 2;
                            j_j = mesh[numbers_in_real[c]].colums - 1;
                            for (int i = i_i; i >= 0; i--)//колличесво строк в матрице
                                for (int j = j_j; j >= 0; j--)//колличество столбцов в матрице
                                {

                                    sw.Write("v");
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(mesh[numbers_in_real[c]][i, j].x));
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(mesh[numbers_in_real[c]][i, j].y));
                                    sw.Write(" ");
                                    sw.Write("0");
                                    sw.WriteLine();
                                }
                        }
                        if ((i_control_bool[c] == true) && (i_control[c] == 0))//строка 0
                        {
                            exstra_lines_count[c] = mesh[numbers_in_real[c]].colums;
                            i_i = 1;
                            j_j = 0;
                            int count = 0;
                            for (int i = i_i; i < mesh[numbers_in_real[c]].rows; i++)//колличесво строк в матрице
                                for (int j = j_j; j < mesh[numbers_in_real[c]].colums; j++)//колличество столбцов в матрице
                                {

                                    sw.Write("v");
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(mesh[numbers_in_real[c]][i, j].x));
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(mesh[numbers_in_real[c]][i, j].y));
                                    sw.Write(" ");
                                    sw.Write("0");
                                    sw.WriteLine();
                                    count++;
                                }
                            sw.Write(Convert.ToString(count));
                        }

                        if ((i_control_bool[c] == false) && (i_control[c] != 1))//столбец 3
                        {
                            exstra_lines_count[c] = mesh[numbers_in_real[c]].rows;
                            i_i = mesh[numbers_in_real[c]].rows - 1;
                            j_j = 1;

                            for (int j = j_j; j < mesh[numbers_in_real[c]].colums; j++)//колличество столбцов в матрице
                                for (int i = i_i; i >= 0; i--)//колличесво строк в матрице
                                {

                                    sw.Write("v");
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(mesh[numbers_in_real[c]][i, j].x));
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(mesh[numbers_in_real[c]][i, j].y));
                                    sw.Write(" ");
                                    sw.Write("0");
                                    sw.WriteLine();
                                }
                        }
                        if ((i_control_bool[c] == false) && (i_control[c] == 1))//столбец 1
                        {
                            exstra_lines_count[c] = mesh[numbers_in_real[c]].rows;
                            i_i = 0;
                            j_j = mesh[numbers_in_real[c]].colums - 2;
                            for (int j = j_j; j >= 0; j--)//колличество столбцов в матрице
                                for (int i = i_i; i < mesh[numbers_in_real[c]].rows; i++)//колличесво строк в матрице
                                {

                                    sw.Write("v");
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(mesh[numbers_in_real[c]][i, j].x));
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(mesh[numbers_in_real[c]][i, j].y));
                                    sw.Write(" ");
                                    sw.Write("0");
                                    sw.WriteLine();
                                }
                        }
                    }




                    sw.WriteLine("g all");
                    sw.WriteLine("s 1");
                    int k_repeat = 1;//для того чтобы граммотно проходиться по всем сеткам
                    int k_k = 0;//вспомогательная переменная для определения текущего положения
                    int S_gen_mesh = 0;//размерность общей сетки(меняется при каждой итерации)
                    for (int i = 0; i < Contours.Count(); i++)
                    {
                        if (i == 0)
                            S_gen_mesh += mesh[numbers_in_real[i]].rows * mesh[numbers_in_real[i]].colums;
                        else
                            S_gen_mesh += mesh[numbers_in_real[i]].rows * mesh[numbers_in_real[i]].colums - exstra_lines_count[i];


                        for (int k = k_repeat; k < S_gen_mesh; k++)
                        {


                            if ((k % mesh[numbers_in_real[i]].colums) == 0)
                            {
                                sw.Write("l");
                                sw.Write(" ");
                                sw.Write(Convert.ToString(k));
                                sw.Write(" ");
                                sw.Write(Convert.ToString(k + mesh[numbers_in_real[i]].colums));
                                sw.WriteLine();
                            }

                            // if (k > mesh[numbers_in_real[i]].rows * mesh[numbers_in_real[i]].colums - mesh[numbers_in_real[i]].colums)
                            if ((k > S_gen_mesh - mesh[numbers_in_real[i]].colums) && (i != Contours.Count() - 1))////для отрисовки перехода из одной сетки в другую
                            {
                                sw.Write("l");
                                sw.Write(" ");
                                sw.Write(Convert.ToString(k));
                                sw.Write(" ");
                                sw.Write(Convert.ToString(k + 1));
                                sw.WriteLine();

                                sw.Write("l");
                                sw.Write(" ");
                                sw.Write(Convert.ToString(k));
                                sw.Write(" ");
                                sw.Write(Convert.ToString(k + mesh[numbers_in_real[i]].colums));
                                sw.WriteLine();
                            }
                            if ((k > S_gen_mesh - mesh[numbers_in_real[i]].colums) && (i == Contours.Count() - 1))//для отрисовки последнего слоя общей сетки
                            {
                                sw.Write("l");
                                sw.Write(" ");
                                sw.Write(Convert.ToString(k));
                                sw.Write(" ");
                                sw.Write(Convert.ToString(k + 1));
                                sw.WriteLine();
                            }

                            // if ((k < mesh[numbers_in_real[i]].rows * mesh[numbers_in_real[i]].colums - mesh[numbers_in_real[i]].colums) && ((k % mesh[numbers_in_real[i]].colums) != 0))
                            if ((k < S_gen_mesh - mesh[numbers_in_real[i]].colums) && ((k % mesh[numbers_in_real[i]].colums) != 0)) //внутренность сетки с левой границей
                            {
                                sw.Write("l");
                                sw.Write(" ");
                                sw.Write(Convert.ToString(k));
                                sw.Write(" ");
                                sw.Write(Convert.ToString(k + 1));
                                sw.WriteLine();

                                sw.Write("l");
                                sw.Write(" ");
                                sw.Write(Convert.ToString(k));
                                sw.Write(" ");
                                sw.Write(Convert.ToString(k + mesh[numbers_in_real[i]].colums));
                                sw.WriteLine();
                            }

                            k_k = k;
                        }
                        k_repeat = k_k + 1;
                    }
                }
            }

            return 0;
        }
    }
}
