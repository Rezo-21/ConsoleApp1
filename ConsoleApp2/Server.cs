using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class program
    {
        static void Main(string[] args)
        {
            #region TCP
            //const string ip = "127.0.0.1";
            //const int port = 8080;

            //var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            //var tcpsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //tcpsocket.Bind(tcpEndPoint);
            //tcpsocket.Listen(5);

            //while (true)
            //{
            //    var listener = tcpsocket.Accept();
            //    var buffer = new byte[256];
            //    var size = 0;
            //    var data = new StringBuilder();

            //    do
            //    {
            //        size = listener.Receive(buffer);
            //        data.Append(Encoding.UTF8.GetString(buffer, 0, size));
            //    }
            //    while (listener.Available > 0);

            //    Console.WriteLine(data);

            //    listener.Send(Encoding.UTF8.GetBytes(""));

            //    listener.Shutdown(SocketShutdown.Both);
            //    listener.Close();
            #endregion

            #region UDP
            const string ip = "127.0.0.1";
            const int port = 8081;

            var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            udpSocket.Bind(udpEndPoint);

            while (true)
            {
                Console.WriteLine("sheiyvanet werili");
                var message = Console.ReadLine();

                var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
                udpSocket.SendTo(Encoding.UTF8.GetBytes(message), serverEndPoint); ;

                while (true)
                {
                    var buffer = new byte[256];
                    var size = 0;
                    var data = new StringBuilder();

                    EndPoint senderEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);

                    do
                    {
                        size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);
                        data.Append(Encoding.UTF8.GetString(buffer));
                    }
                    while (udpSocket.Available > 0);

                    Console.WriteLine(data);
                    Console.ReadLine();
                }
            }
            #endregion
        }
    }
}