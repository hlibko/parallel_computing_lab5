using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TCP_Server
{
    class Program
    {
        const int port = 9001;
        static TcpListener listener;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
                Console.WriteLine("Ожидание подключений...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client);

                    // создаем новый поток для обслуживания нового клиента
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
    }
}
