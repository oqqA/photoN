using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photoN
{
   public class ViewportClass : IViewport
   {
      public double[,] Viewport()
      {
         //...
         throw new NotImplementedException();
      }

      public double[,] ViewportRes(int x, int y, int w, int h, int depth)
      {
         double[,] m = new double[4, 4];
         m[0, 3] = x + w / 2f;
         m[1, 3] = y + h / 2f;
         m[2, 3] = depth / 2f;

         m[0, 0] = w / 2f;
         m[1, 1] = h / 2f;
         m[2, 2] = depth / 2f;
         return m;
      }

      
   }
}
