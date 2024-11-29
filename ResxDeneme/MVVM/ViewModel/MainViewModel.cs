using ResxDeneme.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResxDeneme.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _selectedLanguage;
        private ResourceManager _resourceManager;

        public MainViewModel()
        {
            _resourceManager = new ResourceManager(typeof(Resources));
            SelectedLanguage = "en"; // Varsayılan dil
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Label1 => _resourceManager.GetString("Label1", CultureInfo.CurrentCulture);
        public string Label2 => _resourceManager.GetString("Label2", CultureInfo.CurrentCulture);
        public string Label3 => _resourceManager.GetString("Label3", CultureInfo.CurrentCulture);
        public string Label4 => _resourceManager.GetString("Label4", CultureInfo.CurrentCulture);
        public string Label5 => _resourceManager.GetString("Label5", CultureInfo.CurrentCulture);
        public string Label6 => _resourceManager.GetString("Label6", CultureInfo.CurrentCulture);
        public string Label7 => _resourceManager.GetString("Label7", CultureInfo.CurrentCulture);
        public string Label8 => _resourceManager.GetString("Label8", CultureInfo.CurrentCulture);
        public string Label9 => _resourceManager.GetString("Label9", CultureInfo.CurrentCulture);
        public string Label10 => _resourceManager.GetString("Label10", CultureInfo.CurrentCulture);

        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                SetCulture(_selectedLanguage);
                OnPropertyChanged("");
            }
        }

        private void SetCulture(string language)
        {
            switch (SelectedLanguage.Replace("System.Windows.Controls.ComboBoxItem: ", "")
)
            {
                case "English":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
                    break;
                case "Italiano":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("it");
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("it");
                    break;
                case "Türkçe":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("tr");
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("tr");
                    break;
                default:
                    break;
            }
            
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
