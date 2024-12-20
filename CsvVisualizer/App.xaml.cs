using CsvVisualizer.CLASSES;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CsvVisualizer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DXFfields DXFfields { get; set; }
        public static string DXFfiles = AppDomain.CurrentDomain.BaseDirectory + "DXF\\";
        public App()
        {
            DXFfields = new DXFfields();
        }
    }
}
