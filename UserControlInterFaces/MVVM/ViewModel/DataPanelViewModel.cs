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
        public DataPanelViewModel()
        {
            Person = new PersonModel();
            AddToList = new RelayCommand(AddList, CanAddList);
            Persons = new ObservableCollection<PersonModel>();
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
