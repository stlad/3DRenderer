using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace _3DRenderer
{
    public class RayTracer
    {
        public static Canvas Canvas { get; set; }

        public static Scene Scene = new Scene();

        public static double Vw = 1, Vh = 1;
        public static double Cw => Canvas != null ? Canvas.Width : 0; 
        public static double Ch => Canvas != null ? Canvas.Height : 0;
        public static double d = 1;
        public static double OFFSET => Cw / 2;


        public static Vector MakeOffset(Vector sourse) => new Vector((sourse.X+OFFSET), (sourse.Y + OFFSET), (sourse.Z + OFFSET));
      
        public static void Render()
        {
            var O = new Vector(0, 0);//new Vector(0+OFFSET,0+OFFSET);
            for(int x = (int)(-Cw / 2); x <= Cw / 2;x++)
            {
                for(int y = (int)(-Ch/2); y <= Ch / 2;y++)
                {
                    var D = CanvasToViewPort(x, y);
                    var color = TraceRay(O, D, 1, double.MaxValue);
                    PutPixel(new Vector(x, y), color);
                }
            }
        }

        private static Vector CanvasToViewPort(double x, double y) => new Vector(x * (Vw / Cw), y * (Vh / Ch), d);

        private static Color TraceRay(Vector O, Vector D, double tMin, double tMax)
        {
            var closestT = double.MaxValue;
            Sphere closestSphere = null;
            for(int i = 0; i < Scene.Spheres.Count;i++)
            {
                var sphere = Scene.Spheres[i];
                var t = IntersectRaySphere(O, D, sphere);

                if (t[0] >= tMin && t[0] <= tMax && t[0] < closestT)
                {
                    closestT = t[0];
                    closestSphere = sphere;
                }
                if (t[1] >= tMin && t[1] <= tMax && t[1] < closestT)
                {
                    closestT = t[1];
                    closestSphere = sphere;
                }

            }

            if (closestSphere is null) 
                return Color.FromArgb(255,0,0,0);
            return closestSphere.Color;

        }

        public static void PutPixel(Vector pt, Color color)
        {
            var offsetedPt = MakeOffset(pt); 
            var point = new Line();
            point.X1 = offsetedPt.X;
            point.X2 = offsetedPt.X+1;
            point.Y1 = offsetedPt.Y;
            point.Y2 = offsetedPt.Y+1;
            point.Stroke = new SolidColorBrush(color);
            point.StrokeThickness = 1;
            Canvas.Children.Add(point);
        }

        private static Vector IntersectRaySphere(Vector O, Vector D, Sphere sphere)
        {
            var c = sphere.Center;
            var r = sphere.Radius;

            var oc = O - c;
            var k1 = Vector.ScalarMult(D, D);
            var k2 = 2 * Vector.ScalarMult(oc, D);
            var k3 = Vector.ScalarMult(oc, oc) - r * r;

            var discriminant = k2*k2 - 4*k1*k3;
            if (discriminant < 0)
                return new Vector(double.MaxValue, double.MaxValue);

            var t1 = (-k2 + Math.Sqrt(discriminant)) / (2 * k1);
            var t2 = (-k2 - Math.Sqrt(discriminant)) / (2 * k1);

            return new Vector(t1, t2);
        }
    }

    public class Scene
    {
        public List<Sphere> Spheres = new List<Sphere>
        {
            new Sphere(new Vector(0,-1,3),1, Color.FromArgb(255,255,0,0)),
            //new Sphere(new Vector(-2,0,4),1, Color.FromArgb(255,0,255,0))
        };
    }

}
