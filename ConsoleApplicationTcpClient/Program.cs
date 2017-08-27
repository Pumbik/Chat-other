using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTcpClient
{
    class Program
    {
        const int PORT = 5006;
        const string ADDRESS = "127.0.0.1";
        static void Main(string[] args)
        {
            TcpClient client = null;
            try
            {

                client = new TcpClient(ADDRESS, PORT);
                NetworkStream stream = client.GetStream();
                StreamWriter writer = new StreamWriter(stream); 
                StreamReader reader = new StreamReader(stream);
                string message;
                do
                {
                    Console.Write("Введите data: ");
                    Console.Write("x: ");
                    int x = int.Parse(Console.ReadLine());
                    Console.Write("op: ");
                    char op= Console.ReadLine()[0];
                    Console.Write("y: ");
                    int y = int.Parse(Console.ReadLine());
                    message = string.Format($"{x}#{op}#{y}");
                    // отправляем сообщение                  
                    writer.WriteLine(message);
                    writer.Flush();
                    // BinaryReader reader = new BinaryReader(new BufferedStream(stream));

                    string answer = reader.ReadLine();
                    string[] value = answer.Split('#');
                    if (value.Length!=2) throw new Exception("Error number arg");
                    string code = value[0];
                    string res = value[1];
                    if (code != "0") throw new Exception("Error from server");
                    Console.WriteLine("Получен ответ: " + message+"="+res);
                } while (message != "exit");
                reader.Close();
                writer.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (client != null)
                    client.Close();
            }
        }
    }
}
