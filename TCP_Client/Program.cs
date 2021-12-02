using System;
using System.Net.Sockets;
using System.Text;

namespace TCP_Client
{
    class Program
    {
        const int port = 9001;
        const string address = "127.0.0.1";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.Write("Введите имя: ");
            string userName = Console.ReadLine();
            TcpClient client = null;
            try
            {
                client = new TcpClient(address, port);
                NetworkStream stream = client.GetStream();

                while (true)
                {
                    // отправляем сообщение на сервер
                    Console.Write(userName + ": ");
                    string message = Console.ReadLine();
                    message = String.Format($"{userName}: {message}");
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    // получаем ответ от сервера
                    data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    message = builder.ToString();
                    Console.WriteLine($"Сервер: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
