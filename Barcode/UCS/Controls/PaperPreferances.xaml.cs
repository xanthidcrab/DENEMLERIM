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
    /// Interaction logic for PaperPreferances.xaml
    /// </summary>
    public partial class PaperPreferances : UserControl, IData, ISizes
    {
        private MainWindow _mainWindow;
        private int _ID;
        private string _ElementName;
        private Size _Size;
        public PaperPreferances()
        {
            InitializeComponent();
        }

        public MainWindow MainWindow
        {
            get => _mainWindow;
            set => _mainWindow = value;
        }
        public int ID
        {
            get => _ID;
            set => _ID = value;
        }
        public string ElementName 
        { 
            get => _ElementName; 
            set => _ElementName = value; 
        }

        public int Type => 3;

        public Size Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
