using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3DDENEME
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        private PerspectiveCamera _camera;

        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void MainWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double zoomFactor = 1.1;
            if (e.Delta > 0)
            {
                camera.Position = new Point3D(camera.Position.X / zoomFactor, camera.Position.Y / zoomFactor, camera.Position.Z / zoomFactor);
            }
            else
            {
                camera.Position = new Point3D(camera.Position.X * zoomFactor, camera.Position.Y * zoomFactor, camera.Position.Z * zoomFactor);
            }
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                var mousePos = e.GetPosition(this);
                double dx = mousePos.X - _lastMousePos.X;
                double dy = mousePos.Y - _lastMousePos.Y;

                double panFactor = 0.01;
                camera.Position = new Point3D(camera.Position.X - dx * panFactor, camera.Position.Y + dy * panFactor, camera.Position.Z);
                _lastMousePos = mousePos;
            }
        }

        private Point _lastMousePos;

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                _lastMousePos = e.GetPosition(this);
            }
        }
    }
}
