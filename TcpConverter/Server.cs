using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ConvertingValuta;

namespace TcpConverter
{
    class Server
    {
        public static void Start()
        {
            try
            {
                TcpListener server;

                int port = 7000;


                server = new TcpListener(IPAddress.Loopback, port);

                server.Start();

                Console.WriteLine("Waiting for a connection........");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    Task.Run(() =>
                    {
                        TcpClient tempSocket = client;
                        DoClient(tempSocket);
                    });

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DoClient(TcpClient socket)
        {
            Stream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            sw.WriteLine("You are connected!!");


            while (true)
            {
                string message = sr.ReadLine();

                string metode = message.Split(" ")[0];

                double vaerdi = Convert.ToDouble(message.Split(" ")[1]);

                switch (metode.ToLower())
                {
                    case "tildanske":

                        double tilDKK = ValutaConverter.TilDanske(vaerdi);

                        sw.WriteLine($"{tilDKK} DKK");

                        break;
                    case "tilsvenske":

                        double tilSWE = ValutaConverter.TilSvenske(vaerdi);

                        sw.WriteLine($"{tilSWE} SWE");
                        break;
                }
            }


        }

    }
}
