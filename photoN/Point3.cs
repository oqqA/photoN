using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photoN
{
   class Point3
   {
      public double x;
      public double y;
      public double z;

      public Point3(double _x, double _y, double _z)
      {
         x = _x;
         y = _y;
         z = _z;
      }

      public Point3(int _x, int _y, int _z)
      {
         x = _x;
         y = _y;
         z = _z;
      }

      public Point3(float _x, float _y, float _z)
      {
         x = _x;
         y = _y;
         z = _z;
      }

      public Point3()
      {
      }

      public static Point3 operator +(Point3 p1, Point3 p2)
      {
         return new Point3(p1.x + p2.x, p1.y + p2.y, p1.z + p2.z);
      }

      public static Point3 operator -(Point3 p1, Point3 p2)
      {
         return new Point3(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);
      }

      public static Point3 operator *(Point3 p1, Point3 p2)
      {
         return new Point3(p1.y*p2.z - p1.z*p2.y, p1.z*p2.x - p1.x*p2.z, p1.x*p2.y - p1.y*p2.x);
      }

      public Point3 normalize()
      {
         double length_of_v = Math.Sqrt((x * x) + (y * y) + (z * z));
         return new Point3(x / length_of_v, y / length_of_v, z / length_of_v);
      }

   }
}
