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

namespace Barcode.UCS
{
    /// <summary>
    /// Interaction logic for LabelBorcode.xaml
    /// </summary>
    public partial class LabelBorcode : UserControl
    {
        private MainWindow _Mainwindow;

        public MainWindow MainWindow
        {
            get => _Mainwindow;
            set => _Mainwindow = value;
        }
        private int _ID;
        public int ID
        {
            get => _ID;
            set => _ID = value;
        }
        private string _ElementName;
        public string ElementName
        {
            get => _ElementName;
            set => _ElementName = value;
        }

        public int Type => 3;

        public Point Position
        {
            get => new Point(Canvas.GetLeft(this), Canvas.GetTop(this));
            set
            {
                Canvas.SetLeft(this, value.X);
                Canvas.SetTop(this, value.Y);
            }
        }
        private Point _RealPoint;
        public Point RealPosition
        {
            get => _RealPoint;
            set => _RealPoint = value;
        }
        private string _BarcodeCode;

        public string BarcodeCode
        {
            get => _BarcodeCode;
            set => _BarcodeCode = value;
        }

        private string _BarcodeType;

        public string BarcodeType
        {
            get => _BarcodeCode;
            set => _BarcodeCode = value;
        }
        private int _Seperator;
        public int Seperator
        {
            get => _Seperator;
            set => _Seperator = value;
        }

        public void UserControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
        public LabelBorcode()
        {
            InitializeComponent();
        }
    }
}
