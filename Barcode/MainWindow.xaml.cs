using Barcode.Classes;
using Barcode.INTERFACES;
using Barcode.UCS;
using Barcode.Windows;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
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

namespace Barcode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Paper CurrentPaper 
        { 
            get 
            {
             return currentPaper;
            }
            set {
                currentPaper = value;
                LoadTable();
                    }
        }

        private void LoadTable()
        {
            IDtb.Text = currentPaper.ID.ToString();
            ElementNamePaper.Text = currentPaper.ElementName;
            Size newSize = Helpers.TempSize;
            WidthPaper.Text = newSize.Width.ToString();
            HeightPaper.Text = newSize.Height.ToString();

        }

        private ObservableCollection<Paper> _ListOfPapers;
        private Paper currentPaper;

        public ObservableCollection<Paper> ListOfPapers
        {
            get {
                return _ListOfPapers; 
            }
            set { 
                _ListOfPapers = value;
            }
        }
        private ObservableCollection<IData> _MainElementlist;

        public ObservableCollection<IData> MainElementList
        {
            get { return _MainElementlist; }
            set 
            { 
                _MainElementlist = value;
                OnMainElementListChange();
            }
        }

        private void OnMainElementListChange()
        {
            ElementContainer.Items.Clear();
            foreach (IData item in MainElementList)
            {
                TextBlock textBox = new TextBlock()
                {
                    Text = item.ElementName
                };
                ElementContainer.Items.Add(textBox);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            CRUD cRUD = new CRUD();
            ListOfPapers =new ObservableCollection<Paper>();
            MainElementList = new ObservableCollection<IData>();
            ListOfPapers.CollectionChanged += ListOfPapers_CollectionChanged;
            cRUD.SaveXml("HRN");
            Helpers.UpdateUI(PaperCb);
        }

        private void ListOfPapers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (PaperCb.Items.Count > 0)
            {
                PaperCb.ItemsSource = null;
                PaperCb.Items.Clear();
            }
            foreach (IData item in ListOfPapers)
            {
                PaperCb.Items.Add(item.ElementName);
            }
            PaperCb.SelectedIndex = ListOfPapers.Count - 1;
            PaperCb.Items.Refresh();

        }

        private void AddTextButton(object sender, RoutedEventArgs e)
        {

        }

        private void AddImageButton(object sender, RoutedEventArgs e)
        {
            UCS.Image img = new UCS.Image();
            img.MainWindow = this;
            PopupWindow window = new PopupWindow(img, this);
            window.ShowDialog();
        }

        private void OpenPaper(object sender, RoutedEventArgs e)
        {
            

        }

        private void AddBarcodeButton(object sender, RoutedEventArgs e)
        {

        }

        private void PrintButton(object sender, RoutedEventArgs e)
        {

        }

        private void SavePaper(object sender, RoutedEventArgs e)
        {

        }

        private void AddPaper(object sender, RoutedEventArgs e)
        {

            Paper paper = new Paper();
            paper.MainWindow = this;
            PopupWindow window = new PopupWindow(paper, this);
            window.ShowDialog();
        }

        private void PaperCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PaperCb.SelectedIndex != -1)
            {

            CurrentPaper = ListOfPapers[PaperCb.SelectedIndex];
            MainBorder.Child = CurrentPaper;
            Properties.Settings.Default.PaperCbSelectedIndex = PaperCb.SelectedIndex;
            Properties.Settings.Default.Save();
            }
        }

        

        private void UpdateBtn(object sender, RoutedEventArgs e)
        {
            Size size = new Size(Convert.ToDouble((WidthPaper.Text)), Convert.ToDouble(HeightPaper.Text));

            CurrentPaper.Size = Helpers.RatioAlligner(MainBorder, size);
            CurrentPaper.ElementName = ElementNamePaper.Text;
        }
    }
}
