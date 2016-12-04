using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GMESH_Visualizer
{
   public class Gradient
    {
      // В данном методе возвращется цвет. Чем ближе будет оценка (status) к 1, тем более красным будет цвет
      // status= 0.01 - зелёный
      // status= 1 - ярко-красный
         double status; // оценка квадратика          

       public Color GetCellColor(double status)
       {
           if (status > 1) status = 1;
           if (status < 0) status = 0;

           int G = (int)(255.0 * status);
           int R = 255 - G;
           int B = 0;
           int A = 255;

           return Color.FromArgb(A, R, G, B);
       }
       
    }
}

 