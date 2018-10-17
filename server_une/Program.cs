using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using server_une;

namespace server_une
{
    class Program
    {
        static void Main(string[] args)
        {
            Server ser = new Server("192.168.88.217", 12088);

            ser.ServerStart();
            Console.ReadLine();
            ser.ServerStop();
            
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
                //socketClose(s);
            }
        }
        #endregion

    }
}
