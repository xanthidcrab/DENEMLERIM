using Barcode.Classes;
using Barcode.INTERFACES;
using Barcode.Properties;
using Barcode.Windows;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Barcode.UCS.Controls
{
    /// <summary>
    /// Interaction logic for ImagePopUp.xaml
    /// </summary>
    public partial class ImagePopUp : UserControl
    {
        public PopupWindow Popup { get; set; }
        public Image Image { get; set; }
        public ImagePopUp(PopupWindow popup, IData image)
        {
            InitializeComponent();
            Popup = popup;
            Image = (Image)image;
            if (Popup.MainWindow.CurrentPaper != null)
            {
                IDtb.Text = Popup.MainWindow.CurrentPaper.ElementList.Count.ToString();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Bir resim dosyası seçin",
                Filter = "Imge Files|*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.gif",
                FilterIndex = 1,
                Multiselect = false
            };
            openFileDialog.ShowDialog();
           
            Image.ImagePath = openFileDialog.FileName;
            ImagePath.Text = openFileDialog.FileName;
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            Size size = new Size(Convert.ToDouble(WidthPaper.Text), Convert.ToDouble(HeightPaper.Text));
            Image.Paper = Popup.MainWindow.CurrentPaper;
            Image.RealSize = size;
            Helpers.ElementAllignerWidth(Image, Image.Paper);
            Image.MainWindow = Popup.MainWindow;
            Image.ElementName = ElementNamePaper.Text;
            Image.ID = Popup.MainWindow.CurrentPaper.ElementList.Count;
            if (Popup.MainWindow.CurrentPaper != null)
            {
                double x = 0;
                double y = 0;
                Double.TryParse(xpos.Text,out x);
                Double.TryParse(ypos.Text,out y);
                Point point = new Point(x, y);
                this.Image.RealPosition = point;
                Helpers.WidthAligner(Image.Paper, Image);

                Popup.MainWindow.CurrentPaper.MainCanvas.Children.Add(Image);
                Popup.MainWindow.CurrentPaper.ElementList.Add(Image);
            }
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Popup.Close();
        }
    }
}
