using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Geometry;
using System.IO;
using Geometry.Point;

namespace GMESHFileStream.OBJFile
{
    /// <summary>
    /// класс для рёбер
    /// </summary>

    class edge : IEquatable<edge>, IComparable<edge>
    {
        public int a, b;

        public edge(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public bool Equals(edge other)
        {
            return this.a == other.a && this.b == other.b;
        }

        public int CompareTo(edge other)
        {
            if (this.a != other.a) return (int)Math.Sign(this.a - other.a);
            return (int)Math.Sign(this.b - other.b);
        }
    }

    public class OBJCreator : IWriter
    {

        public int write(string filename, AbstractMesh[] mesh)
        {
            SortedList<Point2D, int> nodes = new SortedList<Point2D, int>();
            // Console.Write("\nNODES");
            if (File.Exists(filename))       //костыль, чтобы всегда создавался новый файл
                File.Delete(filename);
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(filename))
            {
                foreach (var r in mesh)
                {
                    for (int i = 0; i < r.rows; i++)
                        for (int j = 0; j < r.colums; j++)
                        {
                            Point2D p = new Point2D(r[i, j].x, r[i, j].y);
                            if (nodes.ContainsKey(p)) continue;
                            // Console.Write("\n{0} - x={1}  y={2}", nodes.Count, p.x, p.y);
                            sw.Write("v");
                            sw.Write(" ");
                            sw.Write(Convert.ToString(r[i, j].x));
                            sw.Write(" ");
                            sw.Write(Convert.ToString(r[i, j].y));
                            sw.Write(" ");
                            sw.Write("0");
                            sw.WriteLine();
                            nodes.Add(p, nodes.Count);
                        }
                }
                sw.WriteLine();
                sw.WriteLine("g all");
                sw.WriteLine("s 1");
                sw.WriteLine();
                SortedList<edge, int> links = new SortedList<edge, int>();
                //  Console.Write("\nLINKS");
                foreach (var r in mesh)
                {
                    int nx = r.rows;
                    int ny = r.colums;
                    for (int i = 0; i < nx; i++)
                        for (int j = 0; j < ny; j++)
                        {
                            int a = nodes[new Point2D(r[i, j].x, r[i, j].y)] + 1;
                            if (j < ny - 1)
                            {
                                int b = nodes[new Point2D(r[i, j + 1].x, r[i, j + 1].y)] + 1;
                                edge e = new edge(a, b);
                                if (!links.ContainsKey(e))
                                {
                                    links.Add(e, links.Count);
                                    //  Console.Write("\n{0} - {1}", a, b);
                                    sw.Write("l");
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(a));
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(b));
                                    sw.WriteLine();
                                }
                            }
                            if (i < nx - 1)
                            {
                                int b = nodes[new Point2D(r[i + 1, j].x, r[i + 1, j].y)] + 1;
                                edge e = new edge(a, b);
                                if (!links.ContainsKey(e))
                                {
                                    links.Add(e, links.Count);
                                    // Console.Write("\n{0} - {1}", a, b);
                                    sw.Write("l");
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(a));
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(b));
                                    sw.WriteLine();
                                }
                            }

                        }
                }
            }
            return 0;
        }
    }
}
