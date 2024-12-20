using Serilog;
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
namespace WpfSerilogExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Loglama örnekleri
            Log.Information("MainWindow initialized");
            Log.Debug("This is a debug message");
            Log.Warning("MAKİNANIN ANASINI SİKTİN KANKA");
            Log.Error("MAKİNANIN ANASINI SİKTİN KANKA");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Hata örneği
                throw new System.Exception("Sample exception");
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "makina patladı");
                MessageBox.Show("An error occurred. Check logs for details.");
            }
        }
    }
}