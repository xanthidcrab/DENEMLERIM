using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
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
using PlcTag;

namespace CIPDENEME
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TcpListener _server;
        private Thread _serverThread;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartServer_Click(object sender, RoutedEventArgs e)
        {
            _serverThread = new Thread(StartServer);
            _serverThread.IsBackground = true;
            _serverThread.Start();
            VariableListBox.Items.Add("Server başlatıldı.");
        }

        private void StartServer()
        {
            try
            {
                _server = new TcpListener(IPAddress.Parse("192.168.5.100"), 5000);
                Console.WriteLine(_server.LocalEndpoint);
                _server.Start();
                while (true)
                {
                    var client = _server.AcceptTcpClient();
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
            }
            catch (SocketException ex)
            {
                Dispatcher.Invoke(() => VariableListBox.Items.Add($"Socket hatası: {ex.Message}"));
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() => VariableListBox.Items.Add($"Beklenmeyen bir hata oluştu: {ex.Message}"));
            }
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                string response = "";
                if (request.StartsWith("GET"))
                {
                    response = "HTTP/1.1 200 OK\r\nContent-Type: text/html\r\n\r\n<html><body><h1>YARRRAK!!!!</h1></body></html>";
                }
                else
                {
                    response = $"Serverdan yanıt: {request}";
                }

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);

                Dispatcher.Invoke(() => VariableListBox.Items.Add($"İstemci: {request}"));
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() => VariableListBox.Items.Add($"İstemci hatası: {ex.Message}"));
            }
            finally
            {
                client.Close();
            }
        }

        private void StopServer_Click(object sender, RoutedEventArgs e)
        {
            _server?.Stop();
            _serverThread?.Abort();
            VariableListBox.Items.Add("Server durduruldu.");
        }
    }


}
