using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using System.ServiceModel;
namespace ConsoleApplicationWCFClient
{
  

    
        // Тоже сюда закинул интерфейс, можно выделить в отдельную библиотеку
        [ServiceContract]
        public interface IMyService
        {
            // Сложение
            [OperationContract]
            double GetSum(double i, double j);
            // Умножение
            [OperationContract]
            double GetMult(double i, double j);
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Задаём адрес нашей службы
                Uri tcpUri = new Uri("http://localhost:58000/MyService");
                // Создаём сетевой адрес, с которым клиент будет взаимодействовать
                EndpointAddress address = new EndpointAddress(tcpUri);
                BasicHttpBinding binding = new BasicHttpBinding();
                // Данный класс используется клиентами для отправки сообщений
                ChannelFactory<IMyService> factory = new ChannelFactory<IMyService>(binding, address);
                // Открываем канал для общения клиента с со службой
                IMyService service = factory.CreateChannel();
                Console.WriteLine(service.GetSum(3, 5));
                Console.WriteLine(service.GetSum(5, 12));
                Console.WriteLine(service.GetMult(3, 5));
                Console.WriteLine(service.GetMult(-3, 15));
                Console.ReadLine();
            }
        }
    }

