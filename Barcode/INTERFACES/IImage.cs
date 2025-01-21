using System.Windows.Media.Imaging;

namespace Barcode.INTERFACES
{
    public interface IImage
    {
        string ImagePath { get; set; }
        BitmapImage Bitmap { get; set; }
    }
}
