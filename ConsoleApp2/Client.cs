using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
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

            //Console.WriteLine("sheiyvanet");
            //var message = Console.ReadLine();

            //var data = Encoding.UTF8.GetBytes(message);
            //tcpsocket.Connect(tcpEndPoint);
            //tcpsocket.Send(data);

            //var buffer = new byte[256];
            //var size = 0;
            //var answer = new StringBuilder();

            //do
            //{
            //    size = tcpsocket.Receive(buffer);
            //    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            //}
            //while (tcpsocket.Available > 0);

            //Console.WriteLine(answer);

            //tcpsocket.Shutdown(SocketShutdown.Both);
            //tcpsocket.Close();

            //Console.ReadLine();
            #endregion

            #region UDP
            const string ip = "127.0.0.1";
            const int port = 8082;

            var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var udpsocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            udpsocket.Bind(udpEndPoint);

            while (true)
            {
                var buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();

                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);

                do
                {
                    size = udpsocket.ReceiveFrom(buffer, ref senderEndPoint);
                    data.Append(Encoding.UTF8.GetString(buffer));
                }
                while (udpsocket.Available > 0);

                udpsocket.SendTo(Encoding.UTF8.GetBytes("werili migebulia"), senderEndPoint);

                Console.WriteLine(data);
            }
            #endregion
        }
    }
}
