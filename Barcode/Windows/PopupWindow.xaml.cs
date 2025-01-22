using Barcode.INTERFACES;
using Barcode.UCS;
using Barcode.UCS.Controls;
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
using System.Windows.Shapes;

namespace Barcode.Windows
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
        public MainWindow MainWindow { get; set; }
        public PopupWindow(IData data, MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            Data = data;
            Width = SystemParameters.PrimaryScreenWidth * 0.4;
            Height = SystemParameters.PrimaryScreenHeight * 0.6;
        }
        private IData _data;
        public IData Data {
            get { return _data; }
            set 
            {
                _data = value;
                LoadUI();
            }
        
        }

        private void LoadUI()
        {
            switch (Data.Type)
            {
                case 4:
                    MainBorder.Child = new PaperPopUp(this, Data as Paper);
                    break;
                default:
                    break;
            }
        }
    }
}
