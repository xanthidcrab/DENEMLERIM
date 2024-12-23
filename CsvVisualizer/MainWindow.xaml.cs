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
using System.Threading;
using System.Windows.Interop;

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
            ah.VerticalAlignment = VerticalAlignment.Center;
            ah.HorizontalAlignment = HorizontalAlignment.Center;
            
            Grid.SetColumn(ah, 1);
         
            App.DXFfields.LoadFiles(App.DXFfiles + "ORGA0001.dxf", ah);
           
        


            ah.MouseRightButtonDown += Ah_MouseRightButtonDown;
            ah.Name = "batu";
            ah.VerticalAlignment = VerticalAlignment.Center;
            ah.HorizontalAlignment = HorizontalAlignment.Center;
            harunbaba.Children.Add(ah);
            
            var a = App.DXFfields.path.Data as PathGeometry;
            var c = App.DXFfields.ExtrudePathWithThickness(a, 22, 31);
            //var c = App.DXFfields.ExtrudePolyline(App.DXFfields.lineses,100);
            ModelVisual3D modelVisual = new ModelVisual3D();
            modelVisual.Content = c;
            
            myModelGroup.Children.Add(c);
            
            // Viewport'a ekleyin

        }

        private void Ah_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var a = sender as Canvas;
            a.Visibility = Visibility.Hidden;
            myViewport.Visibility = Visibility.Visible;
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

        // ...

        public void abc()
        {
            myModelGroup.Children.Clear(); // ModelVisual3D içeriğini temizle
            var a = App.DXFfields.path.Data as PathGeometry;
            var c = App.DXFfields.ExtrudePathWithThickness(a, Convert.ToInt32(ekstruzyon.Text), Convert.ToInt32(ekstruzyon.Text));
            myModelGroup.Children.Add(c); // Yeni modeli ekle
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            abc();
        }

        private void fortyFiver2(object sender, RoutedEventArgs e)
        {
            switch (Ameriga2.Content)
            {
                case "45°":
                    Ameriga2.Content = "90°";
                    break;
                case "90°":
                    Ameriga2.Content = "135°";
                    break;
                case "135°":
                    Ameriga2.Content = "45°";
                    break;
                default:
                    break;
            }
        }

        private void fortyFiver(object sender, RoutedEventArgs e)
        {
            switch (Ameriga.Content)
            {
                case "45°":
                    Ameriga.Content = "90°";
                    break;
                case "90°":
                    Ameriga.Content = "135°";
                    break;
                case "135°":
                    Ameriga.Content = "45°";
                    break;
                default:
                    break;
            }

            // Geometriyi 45 derece kes
            var a = App.DXFfields.path.Data as PathGeometry;
            var c = App.DXFfields.ExtrudePathWithThickness(a, 222, 0);
            var cutGeometry = CutGeometryAt45Degrees(c);
            myModelGroup.Children.Clear(); // ModelVisual3D içeriğini temizle
            myModelGroup.Children.Add(cutGeometry);
        }

        private GeometryModel3D CutGeometryAt45Degrees(GeometryModel3D geometry)
        {
            // Geometriyi 45 derece kesmek için gerekli işlemler
            // Bu örnekte, geometriyi kesmek için basit bir yöntem kullanıyoruz
            var mesh = geometry.Geometry as MeshGeometry3D;
            var positions = mesh.Positions.ToList();
            var newPositions = new Point3DCollection();

            foreach (var position in positions)
            {
                if (position.Z < 0) // Z eksenine göre -45 derece kesim
                {
                    newPositions.Add(new Point3D(position.X, position.Y, position.Z * Math.Tan(-Math.PI / 4)));
                }
                else
                {
                    newPositions.Add(position);
                }
            }

            var newMesh = new MeshGeometry3D
            {
                Positions = newPositions,
                TriangleIndices = mesh.TriangleIndices,
                Normals = mesh.Normals,
                TextureCoordinates = mesh.TextureCoordinates
            };

            return new GeometryModel3D(newMesh, geometry.Material);
        }
    }
}
