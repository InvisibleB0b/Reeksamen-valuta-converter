using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpClientConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(IPAddress.Loopback.ToString(), 9000);

            IPAddress ip = IPAddress.Loopback;

            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 9000);

            while (true)
            {
                string message = Console.ReadLine();

                Byte[] sendBytes = Encoding.ASCII.GetBytes(message);

                udpClient.Send(sendBytes, sendBytes.Length);

                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);

                string recivedData = Encoding.ASCII.GetString(receiveBytes);

                Console.WriteLine(recivedData);

            }


        }
    }
}
