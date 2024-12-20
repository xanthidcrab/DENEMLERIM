using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfSerilogExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // Serilog yapılandırması
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // Minimum log seviyesi
                    // Logları konsola yaz
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) // Günlük log dosyası
                .CreateLogger();

            // Serilog'un başlatıldığını kontrol edin
            Log.Information("Application is starting up");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // Serilog'u kapat
            Log.CloseAndFlush();
            base.OnExit(e);
        }
    }
}

