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

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int kx = 1;
        TcpClient tcpcln;
        public MainWindow()
        {
            InitializeComponent();
            lbl.Background = Brushes.Red;
            SWT_Listen();
        }
        public const int portno = 28015;
        public Thread kanal;
        delegate void STD(string datax);
        public int i = 1;
        Socket socket1;
        public void SWT_Listen()
        {
            TcpListener tcpListener = new TcpListener(portno);
            try
            {
                while (true)
                {
                    tcpListener.Start();
                    socket1 = tcpListener.AcceptSocket();
                    Byte[] okunan = new Byte[1024];
                    int boyut = socket1.Receive(okunan, okunan.Length, 0);
                    string dataokunan = System.Text.Encoding.Default.GetString(okunan);
                    string gidenveri = "Server Mesajınız Alınmıştır";
                    Byte[] gidenByte = System.Text.Encoding.Default.GetBytes(gidenveri.ToCharArray());
                    socket1.Send(gidenByte, gidenByte.Length, 0);
                    i++;
                  

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Tcp Dinleme Hatası");
            }
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          string state;
            if (lbl.Background == Brushes.Green)
            {
                lbl.Background = Brushes.Red;
                lbl.Content = "Kapalı";
                state = "Kapalı";
            }
            else if (lbl.Background == Brushes.Red)
            {
                lbl.Background = Brushes.Green;
                lbl.Content = "Açık";
                state = "Açık";
            }
            kanal = new Thread(SWT_Listen);
            kanal.Priority = ThreadPriority.Normal;
            kanal.IsBackground = true;
            kanal.Start();
            lblListen.Content = "Dinlemede";
            try
            {
                tcpcln = new TcpClient("192.168.1.188", 38000);
                NetworkStream netws = tcpcln.GetStream();
                NetworkStream netws1 = tcpcln.GetStream();
                if (netws.CanWrite || netws1.CanWrite)
                {
                    Byte[] gidenText = Encoding.Default.GetBytes("Server>>" + txtalan.Text);
                    Byte[] gidenState = Encoding.Default.GetBytes("Server>>" + lbl.Content);


                }
                else
                {
                    tcpcln.Close();
                    return;
                }
                kx++;
                if (netws.CanRead || netws1.CanRead)
                {
                    Byte[] gelenText = Encoding.Default.GetBytes("Server>>" + txtalan.Text);
                    Byte[] gelenState = Encoding.Default.GetBytes($"Server>> {lbl.Content}");
                    Byte[] oku1 = new byte[tcpcln.ReceiveBufferSize];
                    Byte[] oku2 = new byte[tcpcln.ReceiveBufferSize];
                    string gelentext = Encoding.Default.GetString(oku1);
                    string gelenstate = Encoding.Default.GetString(oku2);
                    tcpcln.Close();
                    lbl.Content = gelentext;
                    lbl.Content = gelenstate;


                    netws.Read(gelenText);
                    netws1.Read(gelenState);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Veri gönderim hatası");
            }

        }
       
        private void btntext_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            txtalan.Text = rnd.Next(100).ToString();
            kanal = new Thread(SWT_Listen);
            kanal.Priority = ThreadPriority.Normal;
            kanal.IsBackground = true;
            kanal.Start();
            lblListen.Content = "Dinlemede";
            try
            {
                tcpcln = new TcpClient("192.168.1.188", 38000);
                NetworkStream netws = tcpcln.GetStream();
                NetworkStream netws1 = tcpcln.GetStream();
                if (netws.CanWrite || netws1.CanWrite)
                {
                    Byte[] gidenText = Encoding.Default.GetBytes("Server>>" + txtalan.Text);
                    Byte[] gidenState = Encoding.Default.GetBytes("Server>>" + lbl.Content);


                }
                else
                {
                    tcpcln.Close();
                    return;
                }
                kx++;
                if (netws.CanRead || netws1.CanRead)
                {
                    Byte[] gelenText = Encoding.Default.GetBytes("Server>>" + txtalan.Text);
                    Byte[] gelenState = Encoding.Default.GetBytes($"Server>> {lbl.Content}");
                    Byte[] oku1 = new byte[tcpcln.ReceiveBufferSize];
                    Byte[] oku2 = new byte[tcpcln.ReceiveBufferSize];
                    string gelentext = Encoding.Default.GetString(oku1);
                    string gelenstate = Encoding.Default.GetString(oku2);
                    tcpcln.Close();
                    lbl.Content = gelentext;
                    lbl.Content = gelenstate;


                    netws.Read(gelenText);
                    netws1.Read(gelenState);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Veri gönderim hatası");
            }
        }
     
    }
}
