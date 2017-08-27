using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace ConsoleApplicationWCFServer
{
    
        [ServiceContract]
        public interface IMyService
        {
            // Далее идут 2 метода, которые будем запрашивать у службы
            // Просто опишем их, реализовывать будем в классе
            // Сложение
            [OperationContract]
            double GetSum(double i, double j);
            // Умножение
            [OperationContract]
            double GetMult(double i, double j);
        }
        // Реализация методов, которые описаны в интерфейсе
        public class MyService : IMyService
        {
            public double GetSum(double i, double j)
            {
                return i + j;
            }

            public double GetMult(double i, double j)
            {
                return i * j;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Инициализируем службу, указываем адрес, по которому она будет доступна
                ServiceHost host = new ServiceHost(typeof(MyService), new Uri("http://localhost:58000/MyService"));
                // Добавляем конечную точку службы с заданным интерфейсом, привязкой (создаём новую) и адресом конечной точки
                host.AddServiceEndpoint(typeof(IMyService), new BasicHttpBinding(), "");
                // Запускаем службу
                host.Open();
                Console.WriteLine("Сервер запущен");
                Console.ReadLine();
                // Закрываем службу
                host.Close();
            }
        }
    }

