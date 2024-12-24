using CsvProject.MVVM.VIEWMODEL.MainFrameViewModels;
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

namespace CsvProject.MVVM.VIEW.MainFrame
{
    /// <summary>
    /// SettingsPage.xaml etkileşim mantığı
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage(SettingsPageViewModel settingsPageViewModel)
        {
            InitializeComponent();
            SettingsPageViewModel = settingsPageViewModel;
        }

        public SettingsPageViewModel SettingsPageViewModel { get; }
    }
}
