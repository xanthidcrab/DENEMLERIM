using Barcode.Classes;
using Barcode.INTERFACES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using static System.Net.Mime.MediaTypeNames;

namespace Barcode.UCS
{
    /// <summary>
    /// Interaction logic for Paper.xaml
    /// </summary>
    public partial class Paper : UserControl, IData, ISizes, IConvertDataRow
    {
        private MainWindow _mainWindow;
        private int _id;
        private string _elementName;
        private int _type;
        private Size _size;
        private CRUD _crud;
        private ObservableCollection<IData> elementList;

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
            get => 4;
            set => _type = value;
        }
        public Size Size
        {
            get 
            { 
                return new Size(Width, Height); 
            }
            set 
            {
                Width = value.Width;
                Height = value.Height;
                _size = value;
            }
        }
        public ObservableCollection<IData> ElementList {
            get => elementList;
            set => elementList = value;
        }
        public CRUD CRUD
        {
            get
            {
                return _crud;

            }
            set
            {
                _crud = value;
            }
        }

        public Paper()
        {
            ElementList = new ObservableCollection<IData>();
            ElementList.CollectionChanged += ElementList_CollectionChanged;
            _crud= new CRUD();
            InitializeComponent();

        }

        private void ElementList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            MainWindow.MainElementList = ElementList;
        }

        public DataRow ConvertDataRow()
        {
            DataRow row = CRUD.PaperTable.NewRow();
            row["ID"] = _id;
            row["ElementName"] = _elementName;
            row["Width"] = _size.Width;
            row["Height"] = _size.Height;

            return row;

        }

       

    }
}
