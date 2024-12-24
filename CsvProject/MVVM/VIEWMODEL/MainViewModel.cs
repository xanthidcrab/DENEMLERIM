using CsvProject.CLASSES.ABSTRACT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvProject.MVVM.VIEWMODEL
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(HeaderViewModel headerViewModel)
        {
            HeaderViewModel = headerViewModel;
            HeaderViewModel.MainViewModel = this;
           
        }

        private object _currentPage;
        public object CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public HeaderViewModel HeaderViewModel { get; }
    }
}
