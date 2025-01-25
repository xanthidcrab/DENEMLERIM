using System.Windows;
using System.Windows.Input;

namespace Barcode.INTERFACES
{
    public interface IPositions
    {
        Point Position { get; set; }
        Point RealPosition { get; set; }
        void UserControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e);

    }
}