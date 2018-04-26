using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klientas
{
    public partial class Klientas : Form
    {
        public Klientas()
        {
            InitializeComponent();
        }
        SimpleTcpClient client;


        public void Klientas_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
        }

        public void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                txtStatus.Text += e.MessageString;
            });
        }

        public void btnConnect_Click_1(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            //client.Connect(txtHost.Text, Convert.ToInt32(txtPort.Text));
            client = new SimpleTcpClient().Connect("127.0.0.1", 8910);
        }

        public void btnSend_Click_1(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply(txtMessage.Text, TimeSpan.FromSeconds(1));
        }

       

        

        

        
    }
}
