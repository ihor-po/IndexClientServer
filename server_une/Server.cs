using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server_une
{
    class Server
    {
        delegate void DelegateConnect(Socket _socket);
        delegate void DelegateNetwork(Socket _socket);
        private IPEndPoint ep;
        private Socket socket;

        private string index;


        /// <summary>
        /// Create server 
        /// </summary>
        /// <param name="serverIP"></param>
        /// <param name="port"></param>
        public Server(string serverIP, int port)
        {
            ep = new IPEndPoint(IPAddress.Parse(serverIP), port);
        }

        /// <summary>
        /// Server start
        /// </summary>
        public void ServerStart()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            socket.Bind(ep);        //Связать полученный сокет с IP адресом и портом на сервере
            socket.Listen(10);      //перевод сокета в  состояние прослушивания с очередью подключения 10

            Console.WriteLine(DateTime.Now.ToString() + " >>> server was started" );

            DelegateNetwork dn = new DelegateNetwork(ReciveMode);
            dn.BeginInvoke(socket, null, null);
        }

        /// <summary>
        /// Close server connection
        /// </summary>
        public void ServerStop()
        {
            Console.WriteLine(DateTime.Now.ToString() + " >>> server was stoped");
            CloseConnection(socket);
        }

        /// <summary>
        /// Server recive mode
        /// </summary>
        /// <param name="_socket"></param>
        private void ReciveMode(Socket _socket)
        {
            int l;
            while (true)
            {
                try
                {
                    Socket tmpSocket = _socket.Accept();
                    byte[] buffer = new byte[1024];
                    l = tmpSocket.Receive(buffer);

                    index = Encoding.Unicode.GetString(buffer, 0, l); //получение индекса от клиента

                    //Вывод в консоль данные о подключенном клиенте
                    IPEndPoint remoteIpEndPoint = tmpSocket.RemoteEndPoint as IPEndPoint;
                    Console.WriteLine(DateTime.Now.ToString());
                    if (remoteIpEndPoint != null)
                    {
                        Console.WriteLine("Connection from " + remoteIpEndPoint.Address + ":" + remoteIpEndPoint.Port);
                        Console.WriteLine("Resive data >>> " + index);
                    }
                    else
                    {
                        Console.WriteLine(tmpSocket.RemoteEndPoint.ToString() + " >>> " + index);
                    }

                    DelegateConnect dc = new DelegateConnect(SendMode);
                    dc.BeginInvoke(tmpSocket, null, null);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void SendMode(Socket _socket)
        {
            string result = GetStreetsByIndex(index);
            _socket.Send(Encoding.Unicode.GetBytes(result));
            CloseConnection(_socket);
        }

        /// <summary>
        ///  Search streets by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static string GetStreetsByIndex(string _index)
        {
            StringBuilder res = new StringBuilder("", 255);

            try
            {
                using (Address_dbContainer data = new Address_dbContainer())
                {
                    var streets = data.Address.Where(item => item.PostIndex.PostI == _index);

                    if (streets.Count() > 0)
                    {

                        foreach (Address item in streets)
                        {
                            res.AppendFormat(item.LocalAddress + ";");
                        }
                    }
                    else
                    {
                        res.AppendLine("По заданному индексу улицы не найдены!");
                    }
                }
            }
            catch (Exception ex)
            {
                res.AppendLine(ex.Message);
            }

            return res.ToString();
        }

        /// <summary>
        /// Close connection
        /// </summary>
        /// <param name="s"></param>
        private void CloseConnection(Socket s)
        {
            s?.Shutdown(SocketShutdown.Both);
            s?.Close();
        }
    }
}
