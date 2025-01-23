using Barcode.Classes;
using Barcode.INTERFACES;
using Barcode.Windows;
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
    /// Interaction logic for PaperPopUp.xaml
    /// </summary>
    public partial class PaperPopUp : UserControl
    {
        public PopupWindow Window { get; set; }
        public Paper Paper { get; set; }

        public PaperPopUp(PopupWindow window, Paper paper)
        {
            InitializeComponent();
            Window = window;
            Paper = paper;
            IDtb.Text = Window.MainWindow.ListOfPapers.Count.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Size RealSize = new Size(Convert.ToDouble(WidthPaper.Text), Convert.ToDouble(HeightPaper.Text));
            Paper.RealSize = RealSize;
            Helpers.PaperWidthAligner(Paper, Window.MainWindow.MainBorder);
            Paper.ElementName = ElementNamePaper.Text;
            Paper.ID = Window.MainWindow.ListOfPapers.Count;
            Paper.VerticalAlignment = VerticalAlignment.Center;
            Paper.HorizontalAlignment = HorizontalAlignment.Center;
            Window.MainWindow.CurrentPaper = Paper;
            Window.MainWindow.MainBorder.Child = Window.MainWindow.CurrentPaper;
            Window.MainWindow.ListOfPapers.Add(Paper);
            Window.Visibility = Visibility.Collapsed;
        }
    }
}
