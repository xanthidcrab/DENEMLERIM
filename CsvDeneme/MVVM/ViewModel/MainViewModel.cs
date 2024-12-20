using CsvDeneme.MVVM.Core;
using CsvDeneme.MVVM.Model;
using CsvHelper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CsvDeneme.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<CsvModel> CSV { get; }
        public MainWindow MainWindow { get; }
        public ICommand OpfCommand { get; }

        public MainViewModel(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            OpfCommand = new RelayCommand(OpenDia);
            CSV = new ObservableCollection<CsvModel>();

        }

        private void OpenDia(object obj)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            ofd.ShowDialog();

            ReadCsv(ofd.FileName);
        }

        private void ReadCsv(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<CsvModel>();
            }

        }
    }
       

}
    

