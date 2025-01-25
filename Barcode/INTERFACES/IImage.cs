using Barcode.UCS;
using System.Windows.Media.Imaging;

namespace Barcode.INTERFACES
{
    public interface IImage: IHasPaper
    {
        string ImagePath { get; set; }
        BitmapImage Bitmap { get;  }
    }
}
