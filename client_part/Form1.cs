using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client_part
{
    public partial class client_main : Form
    {
        public client_main()
        {
            InitializeComponent();
            this.Load += Client_main_Load;
        }

        private void Client_main_Load(object sender, EventArgs e)
        {
            cm_btn_send.Click += Cm_btn_send_Click;
        }
        
        /// <summary>
        /// Button send click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cm_btn_send_Click(object sender, EventArgs e)
        {
            if (cm_tb_ip.Text == "" || cm_tb_port.Text == "")
            {
                MessageBox.Show( "Введите данные сервера", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cm_tb_index.Text.Length != 5)
            {
                MessageBox.Show( "Индекс введен не верно", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StringBuilder sb;

            try
            {
                IPAddress ips = IPAddress.Parse(cm_tb_ip.Text);
                IPEndPoint eps = new IPEndPoint(ips, Convert.ToInt32(cm_tb_port.Text));

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                socket.Connect(eps);
                if (socket.Connected)
                {
                    sb = new StringBuilder();
                    sb.AppendLine($"{DateTime.Now.ToString()} server <<<");

                    socket.Send(Encoding.Unicode.GetBytes(cm_tb_index.Text));
                    byte[] buffer = new byte[1024];
                    int l;
                    do
                    {
                        l = socket.Receive(buffer);
                        sb.Append(Encoding.Unicode.GetString(buffer, 0, l));
                    } while (l > 0);
                }
                else
                {
                    sb = new StringBuilder("Ошибка подключения!");
                }
                sb.AppendLine();
                cm_tb_result.Text += "\r\n" + sb.ToString();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
