using ClassLibrary1;
using System;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClientTcp
{
    class Program
    {
        public static void Main()
        {
            try
            {
                string serverIp = "127.0.0.1";
                Int32 port = 9050;
                Person p = new Person("Иван", "Иванов", 20);
                TcpClient client = new TcpClient(serverIp, port);
                IFormatter formatter = new BinaryFormatter(); // Модуль форматирования, который будет сериализовать класс

                NetworkStream strm = client.GetStream(); // поток
                formatter.Serialize(strm, p); // процесс сериализации

                strm.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            Console.WriteLine("\nНажмите enter для продолжения...");
            Console.Read();
        }
    }
}
