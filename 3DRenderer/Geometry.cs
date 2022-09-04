using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _3DRenderer
{
    internal class Geometry
    {
    }


    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(double x, double y) : this(x, y, 0) { }
        public Vector(Vector v) : this(v.X, v.Y, v.Z) { }

        public double Length() => Math.Sqrt(X * X + Y * Y + Z * Z);

        public static Vector operator+(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector operator-(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector operator*(Vector v, float c) => new Vector(v.X * c, v.Y * c, v.Z * c);

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return X;
                    case 1: return Y;
                    case 2: return Z;
                    default: throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    case 2: Z = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }
        public static double ScalarMult(Vector a, Vector b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

    }


    public class Sphere
    {
        public Vector Center { get; set; }
        public float Radius { get; set; }
        public Color Color { get; set; } 

        public Sphere(Vector center, float radius, Color col)
        {
            Center = center;
            Radius = radius;
            Color = col;
        }

        public Sphere(Vector center, float radius) : this(center, radius, Color.FromArgb(255, 100, 100, 100)) { }
    }

}
