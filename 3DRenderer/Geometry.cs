using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DRenderer
{
    internal class Geometry
    {
    }


    public class Vector
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(float x, float y) : this(x, y, 0) { }
        public Vector(Vector v) : this(v.X, v.Y, v.Z) { }

        public double Length() => Math.Sqrt(X * X + Y * Y + Z * Z);

        public static Vector operator+(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector operator-(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector operator*(Vector v, float c) => new Vector(v.X * c, v.Y * c, v.Z * c);

        public static double ScalarMult(Vector a, Vector b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

    }


    public class Sphere
    {
        public Vector Center { get; set; }
        public float Radius { get; set; }

        public Sphere(Vector center, float radius)
        {
            Center = center;
            Radius = radius;
        }
    }

}
