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

namespace Barcode.UCS
{
    /// <summary>
    /// Interaction logic for Paper.xaml
    /// </summary>
    public partial class Paper : UserControl, IData, ISizes
    {
        private MainWindow _mainWindow;
        private int _id;
        private string _elementName;
        private int _type;
        private Size _size;
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
            get => _type;
            set => _type = value;
        }
        public Size Size
        {
            get => _size;
            set => _size = value;
        }


        public Paper()
        {
            InitializeComponent();
        }
    }
}
