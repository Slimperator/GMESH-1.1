using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Geometry;
using Errors;
using Analyzer;
using Parcer;
using Analitics;

namespace GMESH_Visualizer
{
    public partial class GmeshVisualizer : Form
    {
        Buffer buffer = Buffer.getInstance();                            //буффер
        Analitics.OBjMeshAnalitic analitica = new OBjMeshAnalitic();     //проверка на ошибки
        IReader reader; //= new ObjReader();                             //читалка
        Gradient gradient = new Gradient();                              //градиент
        IGrade gradeAnalise = new Analyzer.Grade.ArithmMeanGrade();      //оценка качества
        IError selectError = null;                                       //текущая выбранная ошибка (которая будет подсчевиваться)
        
        public GmeshVisualizer()
        {
            InitializeComponent();
            updateMeshInfoDataGridSetView();
        }

        private void contourToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All files|*.*";
            openFileDialog1.Title = "Open Contour File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Открываем файл
            }
        }

        private void meshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "OBJ files|*.obj*";
            openFileDialog1.Title = "Open Mesh File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    List<IPoint> points;
                    List<ICurve> lines;
                    Preprocessing.graph.edge[][] graph;
                    reader.read(openFileDialog1.FileName, out points, out lines, out graph);
                    buffer.graph = graph;
                    buffer.lines = lines;
                    buffer.points = points;
                    tryAnaliseMesh();
                }
                catch 
                {
                    return;  //добавить еррор окно.
                }
            }
        }

        private void contourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "All files|*.*";
            saveFileDialog1.Title = "Save Contour File";
            saveFileDialog1.ShowDialog();

            if(saveFileDialog1.FileName != "")
            {

            }
        }

        private void meshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "All files|*.*";
            saveFileDialog1.Title = "Save Mesh File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {

            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {

        }

        private void tryAnaliseMesh()
        {
            buffer.errors = analitica.doAnalitics(buffer.graph, buffer.points);
        }

        private void updateMeshInfoDataGridSetView()
        {
            this.MeshInfoDataGridView.Rows.Add(buffer.errors.Count);
            foreach(IError error in buffer.errors)
            {
                this.MeshInfoDataGridView.Rows[buffer.errors.IndexOf(error)].Cells[0].Value = Properties.Resources.Error;
                this.MeshInfoDataGridView.Rows[buffer.errors.IndexOf(error)].Cells[1].Value = error.getInfo();
            }
        }

        private void MESHDisplay_Paint(object sender, PaintEventArgs e)
        {
            //рисуем точки
            foreach (IPoint point in buffer.points)
            {
                //проверяем наличие данного объекта в списке ошибок по сравнению хеш сумм
                if (buffer.errors.Exists(t => t.getErrorObjectHesh() == point.GetHashCode()))
                    e.Graphics.DrawEllipse(Pens.Red, Convert.ToSingle(point.x) - 3, Convert.ToSingle(point.y) - 3, 6, 6);
                else
                e.Graphics.DrawEllipse(Pens.Black, Convert.ToSingle(point.x) - 3, Convert.ToSingle(point.y) - 3, 6, 6);
            }
            //рисуем линии
            foreach (ICurve curve in buffer.lines)
            {
                //проверяем наличие данного объекта в списке ошибок по сравнению хеш сумм
                if (buffer.errors.Exists(t => t.getErrorObjectHesh() == curve.GetHashCode()))
                    e.Graphics.DrawLine(Pens.Red, Convert.ToSingle(curve.getPoint(0).x), Convert.ToSingle(curve.getPoint(0).y),
    Convert.ToSingle(curve.getPoint(1).x), Convert.ToSingle(curve.getPoint(1).y));
                else
                e.Graphics.DrawLine(Pens.Black, Convert.ToSingle(curve.getPoint(0).x), Convert.ToSingle(curve.getPoint(0).y),
                    Convert.ToSingle(curve.getPoint(1).x), Convert.ToSingle(curve.getPoint(1).y));
            }
            //рисуем контур, если он есть
            if (buffer.contour != null)
            {
                for(int i = 0; i<buffer.contour.getSize(); i++)
                    e.Graphics.DrawLine(Pens.Blue, Convert.ToSingle(buffer.contour[i].getPoint(0).x), Convert.ToSingle(buffer.contour[i].getPoint(0).y),
                    Convert.ToSingle(buffer.contour[i].getPoint(1).x), Convert.ToSingle(buffer.contour[i].getPoint(1).y));
            }
            //выделяем элемент, если есть выделенный
            if (selectError != null)
            {
                if(selectError.getErrorObjectType() == "curve")
                    foreach (ICurve curve in buffer.lines)
                        if (selectError.getErrorObjectHesh() == curve.GetHashCode())
                            e.Graphics.DrawLine(new Pen(Color.Red,3), Convert.ToSingle(curve.getPoint(0).x), Convert.ToSingle(curve.getPoint(0).y),
            Convert.ToSingle(curve.getPoint(1).x), Convert.ToSingle(curve.getPoint(1).y));

                if(selectError.getErrorObjectType() == "point")
                    foreach (IPoint point in buffer.points)
                        if (selectError.getErrorObjectHesh() == point.GetHashCode())
                            e.Graphics.DrawEllipse(Pens.Red, Convert.ToSingle(point.x) - 3, Convert.ToSingle(point.y) - 3, 10, 10);
            }
            //в цикл ниже добавить закраску ячеек
            //считаем качество для всех квадратов. если фигура не квадрат, то её не записываем.
            double grad = 0;
            foreach (Preprocessing.graph.edge[] eges in buffer.graph)
            {
                if (eges.Length != 4)
                    continue;
                grad += gradeAnalise.calculate(buffer.points[eges[0].a], buffer.points[eges[1].a], buffer.points[eges[2].a], buffer.points[eges[3].a]);
            }
            buffer.meshGrad = grad / buffer.graph.Length;

            MESHDisplay.Refresh();
        }

        private void MeshInfoDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //если в буфере ошибок ошибок нет, или их меньше ячеек, а запись ячейки есть, то ошибка
            if (buffer.errors == null || buffer.errors.Count <= e.RowIndex)
                return;
            //ставим в текущую ошибку ошибку из буффера с индексом строки, чтобы выделить её на экране жирненьким
            selectError = buffer.errors[e.RowIndex];
            //обновляем дисплей
            MESHDisplay.Invalidate();
        }
    }
}
