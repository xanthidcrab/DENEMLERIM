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

namespace Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FileSystemWatcher watcher { get; set; }
        public static string folderToWatch = "..\\..\\PROFILES\\";

        public MainWindow()
        {
            InitializeComponent();
            FileSystemWatcher watcher = new FileSystemWatcher
            {
                Path = folderToWatch,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*.*", // Tüm dosya türlerini takip et
                EnableRaisingEvents = true // İzleme işlemini başlat
            };
            watcher.Created += OnFileCreated;
            watcher.Renamed += OnFileRenamed;
            Init();
        }

        public void Init()
        {

            // FileSystemWatcher oluştur
           
            // Olaylara abone ol
           

            Console.WriteLine($"Klasör takip ediliyor: {folderToWatch}");
            Console.WriteLine("Çıkmak için herhangi bir tuşa basın...");

             // Programın çalışmaya devam etmesini sağlar
        }

        public void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            Labellerce.Content = " isimli dosya klasöre taşındı";
        }

        private static void OnFileRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Dosya yeniden adlandırıldı:");
            Console.WriteLine($"Eski Adı: {e.OldFullPath}");
            Console.WriteLine($"Yeni Adı: {e.FullPath}");
        }
    }
}
