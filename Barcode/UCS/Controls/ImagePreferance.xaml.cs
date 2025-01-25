using Barcode.INTERFACES;
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
    /// Interaction logic for ImagePreferance.xaml
    /// </summary>
    public partial class ImagePreferance : UserControl
    {
        public ImagePreferance(IData Element)
        {
            InitializeComponent();
            this.Element = Element as Image;
        }
        private Image _element;
        public Image Element { 
            
            get { return _element; } 
            set { _element = value;
                LoadUI(); }
        
        }

        private void LoadUI()
        {
            ElementNamePaper.Text = Element.ElementName;
            WidthPaper.Text = Element.RealSize.Width.ToString();
            HeightPaper.Text = Element.RealSize.Width.ToString();
            ImagePath.Text = Element.ImagePath;
            xpos.Text = Element.RealPosition.X.ToString();
            ypos.Text = Element.RealPosition.Y.ToString();
            IDtb.Text = Element.ID.ToString();
            
            MainImage.Source = Element.Bitmap;
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
