using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TcpConvertClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Awaiting connection!!");

            Console.ReadKey();

            TcpClient client = new TcpClient(IPAddress.Loopback.ToString(), 7000);

            Stream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            while (true)
            {
                string message = sr.ReadLine();

                Console.WriteLine(message);

                string request = Console.ReadLine();

                sw.WriteLine(request);
            }
        }
    }
}
