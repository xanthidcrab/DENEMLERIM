using Barcode.Classes;
using Barcode.INTERFACES;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Barcode.UCS
{
    /// <summary>
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class Image : UserControl, IData, IPositions, ISizes, IConvertDataRow, IImage
    {
        private MainWindow _mainWindow;
        private int _id;
        private string _elementName;
        private int _type;
        private Point _position;
        private Point _Realposition;
        private Size _size;
        private Size _Realsize;
        private Paper _paper;

        public Paper Paper
            {
            get { return _paper; } 
            set 
            {
                _paper = value;
            }
            }


        public CRUD CRUD
        {
            get => MainWindow.Crud;
        }
        
        public Size Size
        {
            get 
            {
                _size.Width = mainImage.Width;
                _size.Height = mainImage.Height;
                return _size;
            } 
            set  {
                mainImage.Width = value.Width;
                mainImage.Height = value.Height;
               
                
            }
            
        }
        public Size RealSize
        {
            get
            {
            
                return _Realsize;
            }
            set
            {
                _Realsize = value;

            }

        }
        public void RelsizeFirstDef()
        {
            Helpers.ElementAllignerWidth(this, Paper);

        }
        private void ArrangeImage(Size size)
        {
            
        }

        public MainWindow MainWindow
        {
            get => _mainWindow;
            set => _mainWindow = value;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string ElementName
        {
            get => _elementName;
            set => _elementName = value;
        }

        public int Type
        {
            get => 0;
        }

        public Point Position
        {
            get 
            {
                _position.X = Canvas.GetLeft(this);
                _position.Y = Canvas.GetTop(this);
                return _position;
            }
            set
            {
                Canvas.SetLeft(this, value.X);
                Canvas.SetTop(this, value.Y);
            }
        }
        public Point RealPosition
        {
            get
            {
                return _Realposition;
            }
            set
            {
               _Realposition = value;
                Helpers.PositionsAlligner(Paper, this);
            }
        }
        public string ImagePath
        {
            get => mainImage.Source.ToString();
            set => mainImage.Source = new BitmapImage(new Uri(value));
        }
        public BitmapImage Bitmap
        {
            get
            {
                // Orijinal bitmapi al
                var originalBitmap = new BitmapImage(new Uri(mainImage.Source.ToString()));

                // Orijinal boyutları al
                double originalWidth = originalBitmap.PixelWidth;
                double originalHeight = originalBitmap.PixelHeight;

                // Eğer bitmap 200x200'den büyükse, oranlayarak küçült
                if (originalWidth > 200 || originalHeight > 200)
                {
                    // 24x24 hedef boyutlar için ölçek faktörünü hesapla
                    double scaleFactor = Math.Min(24.0 / originalWidth, 24.0 / originalHeight);

                    // Yeni ölçeklendirilmiş bitmap oluştur
                    var scaledBitmap = new TransformedBitmap(originalBitmap, new System.Windows.Media.ScaleTransform(scaleFactor, scaleFactor));

                    // TransformedBitmap'i BitmapImage'e dönüştür
                    var resizedBitmap = new BitmapImage();
                    using (var stream = new System.IO.MemoryStream())
                    {
                        var encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(scaledBitmap));
                        encoder.Save(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);

                        resizedBitmap.BeginInit();
                        resizedBitmap.CacheOption = BitmapCacheOption.OnLoad;
                        resizedBitmap.StreamSource = stream;
                        resizedBitmap.EndInit();
                    }

                    return resizedBitmap; // Küçültülmüş bitmap döndür
                }

                // Bitmap zaten küçükse, oranlanmış olarak direkt döndür
                return originalBitmap; // Bu satırda artık orijinal bitmap döndürülmüyor
            }
        }

        public Image()
        {
            InitializeComponent();
            

        }

        public DataRow ConvertDataRow()
        {
            DataRow row = MainWindow.Crud.ImageTable.NewRow();
            row["ID"] = ID;
            row["ElementName"] = ElementName;
            row["Width"] = RealSize.Width;
            row["Height"] = RealSize.Height;
            row["ImagePath"] = mainImage.Source.ToString();
            row["Xpos"] = RealPosition.X;
            row["Ypos"] = RealPosition.Y;
            return row;
         }

        public void UserControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.ElementContainer.SelectedIndex = ID;
        }
    }
}
