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

namespace SettingsDeneme
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ThemeComboBox.SelectedItem = Properties.Settings.Default.Theme == "Dark"
               ? ThemeComboBox.Items[1]
               : ThemeComboBox.Items[0];
            DarkModeCheckBox.IsChecked = Properties.Settings.Default.IsDarkMode;

        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Ayarları kaydet
            Properties.Settings.Default.Theme = ((ComboBoxItem)ThemeComboBox.SelectedItem).Content.ToString();
            Properties.Settings.Default.IsDarkMode = DarkModeCheckBox.IsChecked == true;

            // Ayarları diske yaz
            Properties.Settings.Default.Save();

            MessageBox.Show("Settings saved!");
        }
    }
}
