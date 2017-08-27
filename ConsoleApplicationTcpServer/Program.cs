using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplicationTcpServer
{
    class MyMath {

        public static double calc(char op,int x, int y) {
            switch (op)
            {
                case '+': return x + y;
                case '-': return x - y;
                case '*': return x * y;
                case '/': return x / y;
                default: return 0;                    
            }
            
        }
    }
    class Program { 
    const int PORT = 5006; // порт для прослушивания подключений
    static TcpListener listener;
        
    static void Main(string[] args)
    {
        try
        {
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), PORT);
            listener.Start();
            Console.WriteLine("Ожидание подключений...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                    string message;
                    StreamReader reader= new StreamReader(stream);;
                    StreamWriter writer= new StreamWriter(stream);;
                    do
                    {
                       
                        // считываем строку из потока
                        message = reader.ReadLine();
                        Console.WriteLine("Получено: " + message);
                        string [] value=message.Split('#');
                        // отправляем ответ
                        int x = int.Parse(value[0]);
                        char op = value[1][0];
                        int y = int.Parse(value[2]);

                        string res=MyMath.calc(op,x,y).ToString();
                        string code = "0";
                        string answer = code + "#" + res;
                        Console.WriteLine("Отправлено: " + answer);
                        writer.WriteLine(answer);
                        writer.Flush();
                    } while (message != "exit");
                writer.Close();
                reader.Close();
                stream.Close();
                client.Close();
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
