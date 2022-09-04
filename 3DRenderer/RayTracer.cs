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

        public static double Vw = 1, Vh = 1;
        public static double Cw => Canvas != null ? Canvas.Width : 0; 
        public static double Ch => Canvas != null ? Canvas.Height : 0;
        public static double d = 1;
        public static double OFFSET = Cw / 2;


        public static Vector MakeOffset(Vector sourse) => new Vector((float)(sourse.X+OFFSET), (float)(sourse.Y + OFFSET), (float)(sourse.Z + OFFSET));
        public RayTracer(Canvas canvas)
        {
           Canvas = canvas;
        }

        public static void Draw(Canvas canvas)
        {

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
    }
}
