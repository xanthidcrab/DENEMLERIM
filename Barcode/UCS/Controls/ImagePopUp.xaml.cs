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
           
            Size size = new Size(Convert.ToDouble(WidthPaper), Convert.ToDouble(HeightPaper));
            Image.Size = size;
            Image.ImagePath = openFileDialog.FileName;
            Image.MainWindow = Popup.MainWindow;

            if (Popup.MainWindow.CurrentPaper != null)
            {
                Canvas.SetLeft(Image, 50);
                Canvas.SetTop(Image, 50);
                Popup.MainWindow.CurrentPaper.MainCanvas.Children.Add(Image);
                Popup.MainWindow.CurrentPaper.ElementList.Add(Image);
            }
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
