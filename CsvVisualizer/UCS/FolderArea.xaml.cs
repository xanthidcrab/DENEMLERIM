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
        private SortedList<int, Node> nodes;

        public SortedList<int, Node> Nodes
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

            Nodes = new SortedList<int, Node>();
            InitFile();
        }

        public void InitFile()
        {
            // Create a new instance of FileSystemWatcher
            FileSystemWatcher watcher = new FileSystemWatcher();

            // Set the path to the directory you want to monitor
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "DXF\\";
            watcher.Path = directoryPath;
            string[] fileNames = Directory.GetFiles(directoryPath);

            // Replace the existing code block with the following code
            foreach (var item in fileNames)
            {
                FileInfo fileInfo = new FileInfo(item);
                nodes.Add(Nodes.Count, new Node(nodes.Count, fileInfo.Name, item));
                TextBlock textBlock = new TextBlock()
                {
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                    Text = fileInfo.Name,
                };
                textBlock.MouseDown += (sender, e) =>
                {

                    var text = sender as TextBlock;
                    Mv.myModelGroup.Children.Clear(); // ModelVisual3D içeriğini temizle
                    var a = App.DXFfields.path.Data as PathGeometry;
                    App.DXFfields.LoadFiles(App.DXFfiles + text.Text, (Canvas)Mv.harunbaba.Children[3]);

                    var c = App.DXFfields.ExtrudePathWithThickness(a, 222, 222);
                    Mv.myModelGroup.Children.Add(c); // Yeni modeli ekle
                    
                };
                MainStackPanel.Children.Add(textBlock);
            }
            // Subscribe to the events you want to handle
            watcher.Created += OnFileCreated;
            watcher.Deleted += OnFileDeleted;
            watcher.Changed += OnFileChanged;
            watcher.Renamed += OnFileRenamed;

            // Enable the watcher to start monitoring
            watcher.EnableRaisingEvents = true;
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
