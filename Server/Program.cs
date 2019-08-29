using NetMQ;
using NetMQ.Sockets;
using System;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var server = new ResponseSocket())
            {
                server.Bind("tcp://*:5555");
                while (true)
                {
                    var data = server.ReceiveFrameBytes();
                    Console.WriteLine($"Received {data.Length} bytes");
                    server.SendFrame(new byte[1]);
                }
            }
        }
    }
}
