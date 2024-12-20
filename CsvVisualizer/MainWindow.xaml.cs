using CsvVisualizer.CLASSES;
using netDxf.Entities;
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
using HelixToolkit; // HelixToolkit namespace'i
using netDxf; // netDxf namespace'i
using HelixToolkit.Wpf;
using Assimp;

namespace CsvVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Canvas ah = new Canvas();    
            App.DXFfields.LoadFiles(App.DXFfiles + "ORGA0005.dxf", ah);
            var a = App.DXFfields.path.Data as PathGeometry;
            var c = App.DXFfields.ExtrudePath(a,0);
            ModelVisual3D modelVisual = new ModelVisual3D();
            modelVisual.Content = c;
            
            myModelGroup.Children.Add(c);
            // Viewport'a ekleyin
            
        }
       

        private System.Windows.Point _previousMousePosition;
        private double _rotationX = 0; // X ekseni etrafındaki toplam dönüş
        private double _rotationY = 0; // Y ekseni etrafındaki toplam dönüş
        private void Viewport3D_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _previousMousePosition = e.GetPosition(this);
            this.CaptureMouse();
        }

       

        private void Viewport3D_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.ReleaseMouseCapture();
        }
    }
}
