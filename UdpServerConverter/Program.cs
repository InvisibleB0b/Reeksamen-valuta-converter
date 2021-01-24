using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ConvertingValuta;

namespace UdpServerConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpServer = new UdpClient(9000);

            IPAddress ip = IPAddress.Loopback;

            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 9000);

            try
            {

                Console.WriteLine("Server is ready");

                while (true)
                {
                    Byte[] receiveBytes = udpServer.Receive(ref RemoteIpEndPoint);

                    string recivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine(recivedData);

                    string metode = recivedData.Split(" ")[0];

                    double vaerdi = Convert.ToDouble(recivedData.Split(" ")[1]);

                    string message = "";

                    switch (metode.ToLower())
                    {
                        case "tildanske":

                            double tilDKK = ValutaConverter.TilDanske(vaerdi);

                            message = tilDKK.ToString() + " DKK";

                            break;
                        case "tilsvenske":

                            double tilSWE = ValutaConverter.TilSvenske(vaerdi);

                            message = tilSWE.ToString() + " SWE";
                            break;
                    }

                    Byte[] sendBytes = Encoding.ASCII.GetBytes(message);

                    udpServer.Send(sendBytes, sendBytes.Length, RemoteIpEndPoint);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
