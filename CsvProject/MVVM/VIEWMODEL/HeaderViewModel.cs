using CsvProject.CLASSES.ABSTRACT;
using CsvProject.CLASSES.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CsvProject.MVVM.VIEWMODEL
{
    public class HeaderViewModel : BaseViewModel
    {
        public ICommand AnasayfaClick { get; }
        public ICommand SettingsClick { get; }
        public ICommand CsvClick { get; }
        public ICommand ProfilesClick { get; }
        public ICommand ExitClick { get; }
        public MainViewModel MainViewModel{ get; set; }
        public HeaderViewModel()
        {
            AnasayfaClick = new RelayCommand(AnasayfaClickMethod);
            SettingsClick = new RelayCommand(SettingsClickMethod);
            CsvClick = new RelayCommand(CsvClickMethod);
            ProfilesClick = new RelayCommand(ProfilesClickMethod);
            ExitClick = new RelayCommand(ExitClickMethod);
            
        }

        private void ProfilesClickMethod(object obj)
        {
           
        }

        private void CsvClickMethod(object obj)
        {
            throw new NotImplementedException();
        }

        private void SettingsClickMethod(object obj)
        {
            throw new NotImplementedException();
        }

        private void AnasayfaClickMethod(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExitClickMethod(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
