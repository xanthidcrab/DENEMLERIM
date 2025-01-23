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
                StackPanel stackPanel = new StackPanel() 
                {
                    Orientation = Orientation.Horizontal
                };
                StackPanel stackPanel2 = new StackPanel()
                {
                    Orientation = Orientation.Horizontal
                };
                StackPanel stackPanel3 = new StackPanel()
                {
                    Orientation = Orientation.Horizontal
                };
                StackPanel MainStackPanel = new StackPanel()
                {
                    
                };
                Label label = new Label()
                {
                    Content = "ID:",
                    FontSize = 20,
                    FontWeight = FontWeights.Bold
                };
                stackPanel.Children.Add(label);
                TextBlock textBlock = new TextBlock()
                {
                    Text = $" {item.ID}"
                    ,
                    FontSize = 20,
                    VerticalAlignment = VerticalAlignment.Center
                };
                stackPanel.Children.Add(textBlock);
                Label label1 = new Label() 
                {
                    Content = "Element Type:",
                    FontSize = 20,
                    FontWeight = FontWeights.Bold
                };
                stackPanel2.Children.Add(label1);

                Label label2 = new Label()
                {
                    Content = "Element Name:",
                    FontSize = 20,
                    FontWeight = FontWeights.Bold
                };
                TextBlock textBlockElementName = new TextBlock()
                {
                    Text = $" {item.ElementName}"
                    ,
                    FontSize = 20,
                    VerticalAlignment = VerticalAlignment.Center
                };
                stackPanel3.Children.Add(label2);
                stackPanel3.Children.Add(textBlockElementName);
                
                switch (item.Type)
                {
                    case 0:
                        TextBlock textBlockType = new TextBlock()
                        {
                            Text = $" Image",
                            FontSize = 20,
                            VerticalAlignment = VerticalAlignment.Center
                        };
                        stackPanel2.Children.Add(textBlockType);
                        break;
                    default:
                        break;
                }
                MainStackPanel.Children.Add(stackPanel);
                MainStackPanel.Children.Add(stackPanel2);
                MainStackPanel.Children.Add(stackPanel3);
                ElementContainer.Items.Add(MainStackPanel);
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

        }
    }
}
