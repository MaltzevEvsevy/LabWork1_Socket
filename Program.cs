// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;

try
{
    for (int i = 1; i < 255; i++)
    {
        IPAddress ip = IPAddress.Parse($"127.0.0.{i.ToString()}");
        IPEndPoint ipEP = new IPEndPoint(ip, 8000);
        Socket TXer = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        //Console.WriteLine("Сокет соединяется с {0} ", TXer.RemoteEndPoint.ToString());
        Thread Potock = new Thread(() => Communication(TXer, ipEP));
        Potock.Start();
    }
    Console.Write("Введите адресс: ");
    string try_ip = Console.ReadLine();
    SendMessageFromSocket(try_ip, 8000);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    Console.ReadLine();
}

static void SendMessageFromSocket(string ip, int port)
{
    // Буфер для входящих данных
    byte[] bytes = new byte[1024];

    // Соединяемся с удаленным устройством

    // Устанавливаем удаленную точку для сокета
    //IPHostEntry ipHost = Dns.GetHostEntry("localhost");
    // было но почему-то перстало работать, надо в лок. интерфесайх разобраться 
    //IPAddress ipAddr = ipHost.AddressList[0];

    //IPAddress ipAddr = new IPAddress(new byte[] { 127, 0, 0, 1 });

    

    IPAddress ipAddr = IPAddress.Parse(ip);
    IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

    Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

    // Соединяем сокет с удаленной точкой
    sender.Connect(ipEndPoint);

    Console.Write("Введите сообщение: ");
    string message = Console.ReadLine();

    Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
    byte[] msg = Encoding.UTF8.GetBytes(message);

    // Отправляем данные через сокет
    int bytesSent = sender.Send(msg);

    // Получаем ответ от сервера
    int bytesRec = sender.Receive(bytes);

    Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));

    // Используем рекурсию для неоднократного вызова SendMessageFromSocket()
    if (message.IndexOf("<TheEnd>") == -1)
        SendMessageFromSocket(ip, port);

    // Освобождаем сокет
    sender.Shutdown(SocketShutdown.Both);
    sender.Close();
}
static void Communication(Socket sender, IPEndPoint ipEndPoint)
{
    try
    {
        // Соединяем сокет с удаленной точкой
        sender.Connect(ipEndPoint);

        if (sender.Connected == false)
        {
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
        else
        {
            Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
    catch(SocketException)
    {

    }
}