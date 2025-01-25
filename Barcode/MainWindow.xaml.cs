using Barcode.Classes;
using Barcode.INTERFACES;
using Barcode.UCS;
using Barcode.UCS.Controls;
using Barcode.Windows;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
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
using System.Xml.Linq;

namespace Barcode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CRUD _Crud;
        public CRUD Crud
        {
            get => _Crud;
            set => _Crud = value;
        }
        public Paper CurrentPaper 
        { 
            get 
            {
             return currentPaper;
            }
            set {
                currentPaper = value;
                LoadTable();
                MainElementList = currentPaper.ElementList;
                UpdatePaper();
                CurrentPaper.MouseMove += CurrentPaper_MouseMove;
                    }
        }
        private Point _mousePosition;
        public Point MousePosition 
        {
            get
            {
                return _mousePosition;
            }
            set
            {
                if (ChosenElement != null && Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    var chosenPos = (IPositions)ChosenElement;
                    var chosenSize = (ISizes)ChosenElement;
                    Point point = new Point(value.X - chosenSize.Size.Width / 2, value.Y - chosenSize.Size.Height / 2);
                    if (point.X + chosenSize.Size.Width <= currentPaper.Size.Width && point.X - chosenSize.Size.Width / 2 >= 0)
                    {
                    chosenPos.Position = point;

                    }
                    //Helpers.UpdateRealPos(chosenPos);
                }
            }
        }
        private void CurrentPaper_MouseMove(object sender, MouseEventArgs e)
        {
            MousePosition = e.GetPosition(currentPaper);
        }

        private void UpdatePaper()
        {
            MainBorder.Child = null;
            MainBorder.Child = currentPaper;
        }

        private void LoadTable()
        {
            IDtb.Text = currentPaper.ID.ToString();
            ElementNamePaper.Text = currentPaper.ElementName;
            
            WidthPaper.Text = currentPaper.RealSize.Width.ToString();
            HeightPaper.Text = currentPaper.RealSize.Width.ToString();

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
        private IData _ChosenElement;
        public IData ChosenElement
        {
            get { return _ChosenElement; }
            set 
            { 
                _ChosenElement = value;
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            ChosenGridi.Child = null;

            switch (ChosenElement.Type)
            {
                case 0:
                    ChosenGridi.Child = new ImagePreferance(ChosenElement);
                    PrefTable.Text = "Image Preferance";
                    break;
                default:
                    break;

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
                MainStackPanel.Tag = item;
                ElementContainer.Items.Add(MainStackPanel);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            _mousePosition = new Point();
            Crud = new CRUD();
            Crud.MainWindow = this;
            ListOfPapers =new ObservableCollection<Paper>();
            MainElementList = new ObservableCollection<IData>();
            ListOfPapers.CollectionChanged += ListOfPapers_CollectionChanged;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                Crud.XmlDataset.Clear();
                Crud.XmlDataset.ReadXml(filePath);
                Paper ppr = Crud.XmlToPaper();
                CurrentPaper = ppr;
            }
            
        }

        private void AddBarcodeButton(object sender, RoutedEventArgs e)
        {

        }

        private void PrintButton(object sender, RoutedEventArgs e)
        {

        }

        private void SavePaper(object sender, RoutedEventArgs e)
        {
            
            DataRow paper = currentPaper.ConvertDataRow();
            Crud.PaperTable.Rows.Add(paper);
            foreach (IData item in currentPaper.ElementList)
            {
                switch (item.Type)
                {
                    case 0:
                        UCS.Image image = item as UCS.Image;
                        DataRow dataRow = image.ConvertDataRow();
                        Crud.ImageTable.Rows.Add(dataRow);  

                        break;
                    default:
                        break;
                }
            }
                        Crud.SaveXml(CurrentPaper.ElementName);
        }

        private void AddPaper(object sender, RoutedEventArgs e)
        {

            Paper paper = new Paper(Crud);
            paper.MainWindow = this;
            PopupWindow window = new PopupWindow(paper, this);
            window.ShowDialog();
        }

        private void PaperCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PaperCb.SelectedIndex != -1)
            {

            Crud.XmlDataset.Clear();
            Crud.XmlDataset.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "PAPERS\\"+ PaperCb.SelectedItem); 
            CurrentPaper = Crud.XmlToPaper();
            Properties.Settings.Default.PaperCbSelectedIndex = PaperCb.SelectedIndex;
            Properties.Settings.Default.Save();
            }
        }

        private void UpdateBtn(object sender, RoutedEventArgs e)
        {

        }

        private void CurrentElementSelectionchanged(object sender, SelectionChangedEventArgs e)
        {
            if (ElementContainer.SelectedIndex != -1)
                ChosenElement = MainElementList[ElementContainer.SelectedIndex];
            else
                ChosenElement = MainElementList[ElementContainer.SelectedIndex+1];

        }
        
    }
}
