using ClassLibrary1;
using System;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TcpServer
{
    class Program
    {
        public static void Main()
        {
            try
            {
                TcpListener server = new TcpListener(9050);
                server.Start();
                TcpClient client = server.AcceptTcpClient();
                NetworkStream strm = client.GetStream();
                IFormatter formatter = new BinaryFormatter();
                Person p = (Person)formatter.Deserialize(strm);
                Console.WriteLine("Меня зовут: " + p.FirstName + " " + p.LastName + " и мне " + p.age);

                strm.Close();
                client.Close();
                server.Stop();
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
