using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server_une
{
    class Program
    {
        static IPAddress ip;
        static IPEndPoint ep;


        static void Main(string[] args)
        {
            ip = IPAddress.Parse("192.168.88.217");
            ep = new IPEndPoint(ip, 12088);
            Server();
        }

        static void Server()
        {


            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            socket.Bind(ep);
            socket.Listen(10); //перевод сокета в  состояние прослушивания с очередью подключения 10

            try
            {
                while (true)
                {
                    Socket tmpSocket = socket.Accept();
                    tmpSocket.Send(System.Text.Encoding.ASCII.GetBytes("Connection success...\r\n"));
                    Console.WriteLine(tmpSocket.RemoteEndPoint.ToString());
                    string res = GetStreetsByIndex("50000");
                    tmpSocket.Send(System.Text.Encoding.ASCII.GetBytes(res));
                    tmpSocket.Send(System.Text.Encoding.ASCII.GetBytes("\r\nClose connection\r\n"));
                    socketClose(tmpSocket);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                socketClose(socket);
            }
        }

        private void StartServer()
        {
            if
        }

        #region CLIENT
        static void Client()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint(ip, 80);

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                s.Connect(ep);
                if (s.Connected)
                {
                    String strSend = "GET\r\n\r\n";
                    s.Send(System.Text.Encoding.ASCII.GetBytes(strSend));
                    byte[] buffer = new byte[1024];
                    int l;
                    do
                    {
                        l = s.Receive(buffer);
                        Console.WriteLine(System.Text.Encoding.ASCII.GetString(buffer, 0, l));
                    } while (l > 0);
                }
                else
                {
                    Console.WriteLine("Error connection!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                socketClose(s);
            }
        }
        #endregion

        private static void socketClose(Socket s)
        {
            s?.Shutdown(SocketShutdown.Both);
            s?.Close();
        }

        /// <summary>
        ///  Search streets by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static string GetStreetsByIndex(string index)
        {
            StringBuilder res = new StringBuilder("", 255);

            try
            {
                using (Address_dbContainer data = new Address_dbContainer())
                {
                    var streets = data.Address.Where(item => item.PostIndex.PostI == index);

                    if (streets != null)
                    {

                        foreach (Address item in streets)
                        {
                            res.AppendFormat(item.LocalAddress + ";");
                        }
                    }
                    else
                    {
                        res.Append("По заданному индексу улицы не найдены!");
                    }
                }
            }
            catch (Exception ex)
            {
                res.Append(ex.Message);
            }

            return res.ToString();
        }
    }
}
