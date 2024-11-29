using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserControlInterFaces.Core;
using UserControlInterFaces.MVVM.Model;

namespace UserControlInterFaces.MVVM.ViewModel
{
    public class DataPanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnpropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private PersonModel _Person;

        public PersonModel Person
        {
            get { return _Person; }
            set { _Person = value;
                OnpropertyChange(nameof(Person));
            }
        }
        private PersonModel _SelectedItem;

        public PersonModel SelectedItem
        {
            get { return _Person; }
            set
            {
                _SelectedItem = value;
                OnpropertyChange(nameof(SelectedItem));
            }
        }
        private ObservableCollection<PersonModel> _Persons;

        public ObservableCollection<PersonModel>Persons
        {
            get { return _Persons; }
            set
            {
                _Persons = value;
                OnpropertyChange(nameof(Person));
            }
        }
        public ICommand AddToList { get; }
        public ICommand Save { get; }
        public ICommand OpenXmls { get; }
        public DataPanelViewModel()
        {
            Person = new PersonModel();
            AddToList = new RelayCommand(AddList, CanAddList);
            Persons = new ObservableCollection<PersonModel>();
            Save = new RelayCommand(SaveXml, CanSaveXml);
            OpenXmls = new RelayCommand(OpenXml, CanOpenXml);
        }
        private void OpenXml(object obj)
        {
            throw new NotImplementedException();
        }
        private bool CanOpenXml(object arg)
        {
            return true;
        }

        private bool CanSaveXml(object arg)
        {
            return true;
                
        }

        private void SaveXml(object obj)
        {
            Person.XmlPrint();
        }

        private void AddList(object p)
        {
            Persons.Add(Person);
            Person = new PersonModel();
        }

        private bool CanAddList(object p)
        {
            if (Person.Name != null )
                return true;
            else
                return false;
        }
    }
}
