using NetMQ;
using NetMQ.Sockets;
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new RequestSocket())
            {
                client.Connect("tcp://localhost:5555");
                int i = 1;
                while (i <= 100000000)
                {
                    var data = new byte[i];
                    client.SendFrame(data);
                    Console.WriteLine($"Send {i} bytes");
                    i *= 10;
                    client.ReceiveFrameBytes();
                }
            }
        }
    }
}
