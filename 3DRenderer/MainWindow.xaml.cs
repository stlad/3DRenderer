using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace _3DRenderer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RayTracer.Canvas = MainCanvas;
            RayTracer.Render();
            //RayTracer.PutPixel(new Vector(0,0), Color.FromArgb(255,255,255,255));
            //RayTracer.PutPixel(new Vector(-100, -100), Color.FromArgb(255, 255, 0, 0));

        }
    }
}
