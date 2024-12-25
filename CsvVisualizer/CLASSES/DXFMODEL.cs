using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CsvVisualizer.CLASSES
{
    public class DXFMODEL : ICreateSelf
    {
        public int ID { get; set; }
        public double Angle { get; set; }
        public string StockCode { get; set; }
        public System.Windows.Shapes.Path Contour { get; set; }
        public double Widht { get; set; }
        public double Height { get; set; }
        public DXFMODEL()
        {
            Contour = new System.Windows.Shapes.Path();
        }
        public void CreateSelf(SortedList<int, DXFMODEL> parent)
        {
            Contour = App.DXFfields.ReturnDxf(AppDomain.CurrentDomain.BaseDirectory + "DXF\\" + StockCode + ".dxf");
            Rect bounds = Contour.Data.Bounds;
            Widht = bounds.Width;
            Height = bounds.Height;
            CreateImageIfNotExists();
        }

        private void CreateImageIfNotExists()
        {
            // Create a dummy canvas
            var canvas = new System.Windows.Controls.Canvas();

            // Remove Contour from its previous parent if it has one
            if (Contour.Parent is System.Windows.Controls.Panel parentPanel)
            {
                parentPanel.Children.Remove(Contour);
            }

            // Add the Contour path to the canvas
            canvas.Children.Add(Contour);

            // Set the size of the canvas
            canvas.Width = 96;
            canvas.Height = 96;

            // Center the canvas
            System.Windows.Controls.Canvas.SetLeft(canvas, (96 - Widht) / 2);
            System.Windows.Controls.Canvas.SetTop(canvas, (96 - Height) / 2);

            // Render the canvas to a PNG image
            var renderTargetBitmap = new System.Windows.Media.Imaging.RenderTargetBitmap(96, 96, 96, 96, System.Windows.Media.PixelFormats.Pbgra32);
            renderTargetBitmap.Render(canvas);

            // Save the PNG image to the specified file location
            var pngEncoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
            pngEncoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(renderTargetBitmap));
            using (var fileStream = new System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory + "DXF\\" + StockCode + ".png", System.IO.FileMode.Create))
            {
                pngEncoder.Save(fileStream);
            }
        }
    }
}
