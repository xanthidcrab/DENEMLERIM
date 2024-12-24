using CsvProject.MVVM.VIEW.MainFrame;
using CsvProject.MVVM.VIEWMODEL;
using CsvProject.MVVM.VIEWMODEL.MainFrameViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows;

namespace CsvProject
{
    /// <summary>
    /// App.xaml etkileşim mantığı
    /// </summary>
    public partial class App : Application
    {
        public static string CSVFilePath = AppDomain.CurrentDomain.BaseDirectory + "CSV\\";
        public static string XMLFilePath = AppDomain.CurrentDomain.BaseDirectory + "XML\\";
        public static string DXFFilePath = AppDomain.CurrentDomain.BaseDirectory + "DXF\\";

        private IServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HeaderViewModel>();

            services.AddSingleton<CSVPage>();
            services.AddSingleton<CSVPageViewModel>();

            services.AddSingleton<SettingsPage>();
            services.AddSingleton<SettingsPageViewModel>();

            services.AddSingleton<ProfilesPage>();
            services.AddSingleton<ProfilePageViewModel>();

            services.AddSingleton<MainPage>();
            services.AddSingleton<MainPageViewModel>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
