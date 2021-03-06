﻿using System;
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
                foreach (var r in mesh)
                {
                    int nx = r.rows;
                    int ny = r.colums;
                    for (int i = 0; i < nx; i++)
                        for (int j = 0; j < ny; j++)
                        {
                            int a = nodes[new Point2D(r[i, j].x, r[i, j].y)];
                            if (j < ny - 1)
                            {
                                int b = nodes[new Point2D(r[i, j + 1].x, r[i, j + 1].y)];
                                edge e = new edge(a, b);
                                if (!links.ContainsKey(e))
                                {
                                    links.Add(e, links.Count);
                                    sw.Write("l");
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(a + 1));
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(b + 1));
                                    sw.WriteLine();
                                }
                            }
                            if (i < nx - 1)
                            {
                                int b = nodes[new Point2D(r[i + 1, j].x, r[i + 1, j].y)];
                                edge e = new edge(a, b);
                                if (!links.ContainsKey(e))
                                {
                                    links.Add(e, links.Count);
                                    sw.Write("l");
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(a + 1));
                                    sw.Write(" ");
                                    sw.Write(Convert.ToString(b + 1));
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
