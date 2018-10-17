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
//        private IPAddress ip;
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

            DelegateNetwork dn = new DelegateNetwork(ReciveMode);
            dn.BeginInvoke(socket, null, null);
        }

        private void ReciveMode(Socket _socket)
        {
            
            int l;
            while (true)
            {
                Socket tmpSocket = socket.Accept();
                byte[] buffer = new byte[1024];
                l = tmpSocket.Receive(buffer);

                index = Encoding.ASCII.GetString(buffer, 0, l); //получение индекса от клиента


                
            }
            do
            {
                l = s.Receive(buffer);
                Console.WriteLine(System.Text.Encoding.ASCII.GetString(buffer, 0, l));
            } while (l > 0);
        }
    }
}
