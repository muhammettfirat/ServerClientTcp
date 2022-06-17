using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int portno = 38000;
        public Thread kanal;
        private int kx = 1;
        public MainWindow()
        {
           
       
        InitializeComponent();
        }
       delegate void clientdg(string datax);
        public int i=1;
        TcpListener tcplisten;
        public void Client_Listen()
        {
            tcplisten = new TcpListener(portno);
            try
            {
                while (true)
                {
                    tcplisten.Start();
                    Socket socket1=tcplisten.AcceptSocket();
                    Byte[] okunan = new Byte[1024];
                    int boyut = socket1.Receive(okunan, okunan.Length, 0);
                    string dataokunan = System.Text.Encoding.Default.GetString(okunan);
                    string gidenveri = "Client :Mesaj Alınmıştır";
                    Byte[] gidenbyte=System.Text.Encoding.Default.GetBytes(gidenveri.ToCharArray());
                    socket1.Send(gidenbyte, gidenbyte.Length, 0);
                    i++;
                    
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Veri Aktarım Hatası");

            }

        }
        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TcpClient tcpcln = new TcpClient("192.168.1.188", 28015);
                NetworkStream netws = tcpcln.GetStream();
                NetworkStream netws1 = tcpcln.GetStream();
                if (netws.CanWrite || netws1.CanWrite)
                {
                    Byte[] giden = Encoding.Default.GetBytes("Client>>" + btnLamba.Content);
                    Byte[] giden1 = Encoding.Default.GetBytes("Client>>" + btnLamba.Content);
                    netws.Write(giden, 0, giden.Length);
                    netws1.Write(giden1, 0, giden1.Length);

                }
                else
                {
                    tcpcln.Close();
                    return;
                }
                if (netws.CanRead || netws1.CanRead)
                {
                    byte[] oku1 = new byte[tcpcln.ReceiveBufferSize];
                    byte[] oku2 = new byte[tcpcln.ReceiveBufferSize];
                    netws.Read(oku1, 0, (int)tcpcln.ReceiveBufferSize);
                    netws1.Read(oku2, 0, (int)tcpcln.ReceiveBufferSize);
                    string gelentext = Encoding.Default.GetString(oku1);
                    string gelenstate = Encoding.Default.GetString(oku2);
                    tcpcln.Close();
                    btnText.Content = gelentext;
                    btnLamba.Content = gelenstate;

                }
                else
                {
                    tcpcln.Close();
                    return;
                }
                kx++;

            }
            catch (Exception)
            {

                MessageBox.Show("Veri gönderme Hatası");
            }
        }

        private void btnLamba_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TcpClient tcpcln = new TcpClient("192.168.1.188", 28015);
                NetworkStream netws = tcpcln.GetStream();
                NetworkStream netws1 = tcpcln.GetStream();
                if (netws.CanWrite || netws1.CanWrite)
                {
                    Byte[] giden = Encoding.Default.GetBytes("Client>>" + btnLamba.Content);
                    Byte[] giden1 = Encoding.Default.GetBytes("Client>>" + btnLamba.Content);
                    netws.Write(giden, 0, giden.Length);
                    netws1.Write(giden1, 0, giden1.Length);

                }
                else
                {
                    tcpcln.Close();
                    return;
                }
                if (netws.CanRead || netws1.CanRead)
                {
                    byte[] oku1 = new byte[tcpcln.ReceiveBufferSize];
                    byte[] oku2 = new byte[tcpcln.ReceiveBufferSize];
                    netws.Read(oku1, 0, (int)tcpcln.ReceiveBufferSize);
                    netws1.Read(oku2, 0, (int)tcpcln.ReceiveBufferSize);
                    string gelentext = Encoding.Default.GetString(oku1);
                    string gelenstate = Encoding.Default.GetString(oku2);
                    tcpcln.Close();
                    btnText.Content = gelentext;
                    btnLamba.Content = gelenstate;

                }
                else
                {
                    tcpcln.Close();
                    return;
                }
                kx++;

            }
            catch (Exception)
            {

                MessageBox.Show("Veri gönderme Hatası");
            }
        }
    }
}
