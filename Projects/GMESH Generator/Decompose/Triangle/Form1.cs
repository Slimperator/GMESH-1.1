using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Geometry;

namespace Decompose.Triangle
{
    public partial class Form1 : Form
    {
        public AbstractMesh[] meshs;
        public IContour[] con;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /*foreach (AbstractMesh mesh in meshs)
            {
                for (int i = 0; i < mesh.rows; i++)
                {
                    for (int j = 0; j < mesh.colums; j++)
                    {
                        float f = Convert.ToSingle(mesh[i, j].x);
                        float g = Convert.ToSingle(mesh[i, j].y);
                        e.Graphics.FillEllipse(Brushes.Red, f, g, 10, 10);
                    }
                }
            }*/

            for (int i = 0; i < 3; i++)
            {
                e.Graphics.DrawLine(Pens.Black, Convert.ToSingle(con[i][0].cutPoints[0].x), Convert.ToSingle(con[i][0].cutPoints[0].y), Convert.ToSingle(con[i][0].cutPoints[con[i][0].cutPoints.Length - 1].x), Convert.ToSingle(con[i][0].cutPoints[con[i][0].cutPoints.Length - 1].y));
                e.Graphics.DrawLine(Pens.Black, Convert.ToSingle(con[i][1].cutPoints[0].x), Convert.ToSingle(con[i][1].cutPoints[0].y), Convert.ToSingle(con[i][1].cutPoints[con[i][1].cutPoints.Length - 1].x), Convert.ToSingle(con[i][1].cutPoints[con[i][1].cutPoints.Length - 1].y));
                e.Graphics.DrawLine(Pens.Black, Convert.ToSingle(con[i][2].cutPoints[0].x), Convert.ToSingle(con[i][2].cutPoints[0].y), Convert.ToSingle(con[i][2].cutPoints[con[i][2].cutPoints.Length - 1].x), Convert.ToSingle(con[i][2].cutPoints[con[i][2].cutPoints.Length - 1].y));
                e.Graphics.DrawLine(Pens.Black, Convert.ToSingle(con[i][3].cutPoints[0].x), Convert.ToSingle(con[i][3].cutPoints[0].y), Convert.ToSingle(con[i][3].cutPoints[con[i][3].cutPoints.Length - 1].x), Convert.ToSingle(con[i][3].cutPoints[con[i][3].cutPoints.Length - 1].y));
            }
        }
    }
}
