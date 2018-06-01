using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace photoN
{
   public partial class Form1 : Form
   {
      Bitmap bmp;
      Graphics graph;
      static Point centerWindow;
      static Point centercenterWindow;
      static List<Point3> model = new List<Point3>();

      static List<List<int>> polygons = new List<List<int>>();


      const int width = 800;
      const int height = 800;
      const int depth = 255;

      static Point3 light_dir = new Point3(1, -1, 1).normalize();
      static Point3 eye = new Point3(1,1,3);
      static Point3 center = new Point3(0,0,0);

      double[,] ModelView = Lookat( eye, center, new Point3(4, 1, 0) );
      double[,] Projection = new double[4, 4];

      double[,] ViewPort = new ViewportClass().ViewportRes(width / 8, height / 8, width * 3 / 4, height * 3 / 4, depth);
      
      public Form1()
      {
         InitializeComponent();

        // Projection[3, 2] = -1 / (eye - center).normalize();
      }

      public void LoadObj()
      {
         openFileDialog1.ShowDialog();
         //openFileDialog1.FileName = @"C:\Users\shakal\Desktop\lowpolydeer.obj";

         this.Focus();

         StreamReader file = new StreamReader(openFileDialog1.FileName);
         String line; 
         while ((line = file.ReadLine()) != null)
         {
            line = line.Replace('.', ',');
            String[] localS = line.Split(new char[] { ' ' });
            if (localS.Length >= 4)
            {
               if (localS[0] == "v")
                  model.Add(new Point3(double.Parse(localS[1]), double.Parse(localS[2]), double.Parse(localS[3])));
               if (localS[0] == "f")
               {
                  List<int> localLines = new List<int>();

                  for (int i = 1; i <= 3; i++)
                  {
                     String[] localSL = localS[i].Split(new char[] { '/' });
                     localLines.Add(int.Parse(localSL[0]));
                  }

                  polygons.Add(localLines);
               }

            }
            
         }

         file.Close();
         timer1.Enabled = true;
         timer1.Start();
      }

      private void reInit()
      {
         bmp = new Bitmap(pic.Width, pic.Height);
         graph = Graphics.FromImage(bmp);
         centerWindow = new Point(pic.Width/2, pic.Height/2);
         centercenterWindow = new Point(pic.Width / 2, pic.Height / 2);
      }

      Point3 light = new Point3(0, 0, 300);
      double zoom = 3;

      public void Draw()
      {
         graph.Clear(Color.Gray);

         Point3 buf = model[0];
         foreach (Point3 p in model)
         {
           // graph.DrawEllipse(Pens.White, centerWindow.X + (int)p.z/4, centerWindow.Y*2 - (int)p.y/4, 2, 2);
         }

         foreach (var p in polygons)
         {
            Point[] mas = new Point[p.Count];

            for (int i = 0; i < p.Count; i++)
            {
               mas[i] = new Point(centercenterWindow.X + (int)((centerWindow.X + model[p[i] - 1].x) / zoom), centercenterWindow.Y + (int)((centerWindow.Y - model[p[i] - 1].y) / zoom));
               double[,] j = new double[1, 3];
               j[0, 0] = model[p[i] - 1].x;
               j[0, 1] = model[p[i] - 1].y;
               j[0, 2] = model[p[i] - 1].z;
               //j = sumMatrix(sumMatrix(sumMatrix(ViewPort, Projection), ModelView), j);

            }


            if (radioButton1.Checked)
               graph.DrawPolygon(Pens.White, mas);
            else
            {
               Point3 normal = (model[p[0]-1] - model[p[1]-1]) * (model[p[0]-1] - model[p[2]-1]);
               normal.normalize();
               double intensive = normal.x * light.x + normal.y * light.y + normal.z * light.z;
               if (intensive > 0)
               {
                  intensive /= 3000000;
                  intensive = intensive > 1 ? 1 : intensive;
                  graph.FillPolygon(new SolidBrush(Color.FromArgb((int)(intensive * 255), (int)(intensive * 255), (int)(intensive * 255))), mas);
               }

            }
         }

         pic.Image = bmp;
      }

      static double[,] Lookat(Point3 eye, Point3 center, Point3 up)
      {
         Point3 z = (eye - center).normalize();
         Point3 x = (up * z).normalize();
         Point3 y = (z * x).normalize();
         double[,] Minv = new double[3,3];
         double[,] Tr = new double[4,4];

         Minv[0,0] = x.x;
         Minv[0,1] = y.x;
         Minv[0,2] = z.x;

         Minv[1,0] = x.y;
         Minv[1,1] = y.y;
         Minv[1,2] = z.y;

         Minv[2,0] = x.z;
         Minv[2,1] = y.z;
         Minv[2,2] = z.z;

         Tr[3,1] = -center.x;
         Tr[3,2] = -center.y;
         Tr[3,3] = -center.z;
         
         return sumMatrix(Minv, Tr);
      }

      static double[,] sumMatrix(double[,] p1, double[,] p2)
      {
         if (p1.GetLength(0) != p2.GetLength(1)) return null;

         double[,] newMatrix = new double[p1.GetLength(0), p2.GetLength(1)];

         for (int y = 0; y < p1.GetLength(0); y++)
         {
            for (int x = 0; x < p2.GetLength(1); x++)
            {
               double sum = 0;
               for (int i = 0; i < p1.GetLength(0); i++)
               {
                  sum += p1[i, y] * p2[x, i];
               }
               newMatrix[x, y] = sum;
            }
         }

         return newMatrix;
      }

      // events

      private void timer1_Tick(object sender, EventArgs e)
      {
         Draw();
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         reInit();
         LoadObj();
      }

      private void Form1_SizeChanged(object sender, EventArgs e)
      {
         reInit();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         LoadObj();
      }

      private void pic_MouseWheel(object sender, MouseEventArgs e)
      {
         zoom = e.Delta < 0 ? zoom + 0.05 : zoom - 0.05 ;
      }

      private void pic_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            downMouse = new Point(e.X, e.Y);
            OldCenterWindow = centerWindow;
         }
      }

      Point OldCenterWindow;
      Point downMouse;

      private void pic_MouseMove(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {

               centerWindow = new Point(OldCenterWindow.X + (int)((e.X - downMouse.X) * zoom), OldCenterWindow.Y + (int)((e.Y - downMouse.Y) * zoom));

         }
      }

   }
}
