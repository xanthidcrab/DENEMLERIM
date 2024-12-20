using DiProgram.MVVM.Model;
using DiProgram.MVVM.View;
using DiProgram.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DiProgram
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            // Main vm
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();

            //p1
            services.AddSingleton<Page1>();
            services.AddSingleton<Page1ViewModel>();
            //p1
            services.AddSingleton<Page2>();
            services.AddSingleton<Page2ViewModel>();
            //p1
            services.AddSingleton<Page3>();
            services.AddSingleton<Page3ViewModel>();
            //p1
            services.AddSingleton<Page4>();
            services.AddSingleton<Page4ViewModel>();
            //p5
            services.AddSingleton<Page5>();
            services.AddSingleton<Page5ViewModel>();

            //uc1
            services.AddSingleton<UserControl1>();
            services.AddSingleton<UserControlModel1>();

            //uc1
            services.AddSingleton<UserControl1>();
            services.AddSingleton<UserControlModel1>();

            //uc2
            services.AddSingleton<UserControl2>();
            services.AddSingleton<UserControlModel2>();

            //uc3
            services.AddSingleton<UserControl3>();
            services.AddSingleton<UserControlModel4>();

            //uc5
            services.AddSingleton<UserControl5>();
            services.AddSingleton<UserControlModel5>();

            ServiceProvider = services.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
