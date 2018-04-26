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

namespace SifruotasTekstoApsikeitimas
{
    public partial class Serveris : Form
    {
        public Serveris()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;

        public void Serveris_Load(object sender, EventArgs e)
        {
            
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;
        }

        public void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                txtStatus.Text += e.MessageString;
                e.ReplyLine(string.Format("You said: {0}", e.MessageString));
            });
            
        }

        public void btnStart_Click_1(object sender, EventArgs e)
        {
            txtStatus.Text += "Server starting...";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(txtHost.Text);
            server.Start(ip, Convert.ToInt32(8910));
        }

        

        public void btnStop_Click_1(object sender, EventArgs e)
        {
            if (server.IsStarted)
                server.Stop();
        }

        
    }
}
