using CsvVisualizer.CLASSES;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CsvVisualizer.UCS
{
    /// <summary>
    /// Interaction logic for FolderArea.xaml
    /// </summary>
    public partial class FolderArea : UserControl
    {
        private SortedList<int, DXFMODEL> nodes;

        public SortedList<int, DXFMODEL> Nodes
        {
            get => nodes;
            set
            {
                nodes = value;
            }
        }

        MainWindow Mv;

        public FolderArea()
        {
            InitializeComponent();

            Mv = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            Nodes = new SortedList<int, DXFMODEL>();
            InitFile();
        }

        public void InitFile()
        {
            string[] FileNames = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "DXF");
            foreach (var item in FileNames)
            {
                if (item.EndsWith(".dxf"))
                {
                    DXFMODEL dxf = new DXFMODEL();
                    dxf.StockCode = item.Trim().Replace(AppDomain.CurrentDomain.BaseDirectory + "DXF\\", "").Replace(".dxf", "");
                    dxf.ID = Nodes.Count;
                    dxf.CreateSelf(Nodes);
                    Nodes.Add(dxf.ID, dxf);
                }
               
            }
        }

        // Event handler for file created event
        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            // Handle the file created event
            string filePath = e.FullPath;
            Console.WriteLine("File created: " + filePath);
        }

        // Event handler for file deleted event
        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            // Handle the file deleted event
            string filePath = e.FullPath;
            Console.WriteLine("File deleted: " + filePath);
        }

        // Event handler for file changed event
        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            // Handle the file changed event
            string filePath = e.FullPath;
            Console.WriteLine("File changed: " + filePath);
        }

        // Event handler for file renamed event
        private void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            // Handle the file renamed event
            string oldFilePath = e.OldFullPath;
            string newFilePath = e.FullPath;
            Console.WriteLine("File renamed from " + oldFilePath + " to " + newFilePath);
        }
    }
    public class Node
    {
        public Node(int ıD, string name, string ımgPath)
        {
            ID = ıD;
            Name = name;
            ImgPath = ımgPath;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string ImgPath { get; set; }
       
    }
}
