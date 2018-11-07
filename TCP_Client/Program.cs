using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCP_Client
{
    class Program
    {
        
        private static Socket _clientSocket =  new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        public static void Main(string[] args)
        {
            Console.Title = "Time Client";
            LoopConnect();
            Console.ReadLine();
        }

        private static void LoopConnect()
        {
            int attempts = 0;
            //while (!_clientSocket.Connected)
            {
                try
                {
                    _clientSocket.Connect(IPAddress.Loopback, 1024);
                    attempts++;
                    System.Threading.Thread.Sleep(500);
                }
                catch (SocketException exception)
                {
                    Console.Clear();
                    Console.WriteLine(exception);
                    Console.WriteLine("Connection attempts: "+attempts);
                }   
            }
            Console.Clear();
            Console.WriteLine("Connected!");
        }
    }
}