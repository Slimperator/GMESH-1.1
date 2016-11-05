using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Geometry;

namespace GMESH_Generator
{
    public partial class TestVisualizerForInternalMeshForm : Form
    {
        public AbstractMesh mesh;
        public IContour con;
        public TestVisualizerForInternalMeshForm()
        {
            InitializeComponent();
        }

        private void TestVisualizerForInternalMeshForm_Paint(object sender, PaintEventArgs e)
        {
            //тут рисуем сетку
            for (int i = 0; i < mesh.rows; i++)
            {
                for (int j = 0; j < mesh.colums; j++)
                {
                    float f = Convert.ToSingle(mesh[i, j].x);
                    float g = Convert.ToSingle(mesh[i, j].y);
                    e.Graphics.FillEllipse(Brushes.Red, f, g, 10, 10);
                }
            }
            //тут контур по факту
            e.Graphics.DrawLine(Pens.Black, Convert.ToSingle(con[0].cutPoints[0].x), Convert.ToSingle(con[0].cutPoints[0].y), Convert.ToSingle(con[0].cutPoints[con[0].cutPoints.Length - 1].x), Convert.ToSingle(con[0].cutPoints[con[0].cutPoints.Length - 1].y));
            e.Graphics.DrawLine(Pens.Black, Convert.ToSingle(con[1].cutPoints[0].x), Convert.ToSingle(con[1].cutPoints[0].y), Convert.ToSingle(con[1].cutPoints[con[1].cutPoints.Length - 1].x), Convert.ToSingle(con[1].cutPoints[con[1].cutPoints.Length - 1].y));
            e.Graphics.DrawLine(Pens.Black, Convert.ToSingle(con[2].cutPoints[0].x), Convert.ToSingle(con[2].cutPoints[0].y), Convert.ToSingle(con[2].cutPoints[con[2].cutPoints.Length - 1].x), Convert.ToSingle(con[2].cutPoints[con[2].cutPoints.Length - 1].y));
            e.Graphics.DrawLine(Pens.Black, Convert.ToSingle(con[3].cutPoints[0].x), Convert.ToSingle(con[3].cutPoints[0].y), Convert.ToSingle(con[3].cutPoints[con[3].cutPoints.Length - 1].x), Convert.ToSingle(con[3].cutPoints[con[3].cutPoints.Length - 1].y));
           //тут ожидаемый контур
            e.Graphics.DrawLine(Pens.Blue, 170, 64, 465, 65);
            e.Graphics.DrawLine(Pens.Blue, 465, 65, 464, 238);
            e.Graphics.DrawLine(Pens.Blue, 464, 238, 169, 237);
            e.Graphics.DrawLine(Pens.Blue, 169, 237, 170, 64);
            //тут рисуем точки cutPoints. Для каждой кривой раскрашиваем своим цветом
            Brush[] b = new Brush[4] { Brushes.Brown, Brushes.Green, Brushes.DarkGoldenrod, Brushes.ForestGreen };
            for (int i = 0; i < 4; i++)
            {
                
                for (int j = 0; j < con[i].cutPoints.Length; j++)
                {
                    float f = Convert.ToSingle(con[i].cutPoints[j].x);
                    float g = Convert.ToSingle(con[i].cutPoints[j].y);
                    e.Graphics.FillEllipse(b[i], f, g, 5, 5);
                }
            }
        }
    }
}
