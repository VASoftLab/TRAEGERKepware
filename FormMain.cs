using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Opc.UaFx;
using Opc.UaFx.Client;
using Opc.UaFx.Client.Classic;

namespace TRAEGERKepware
{
    public partial class FormMain : Form
    {
        OpcClient _Client;
        List<OPCServerItem> _OPCServers;
        public FormMain()
        {
            InitializeComponent();            
            _OPCServers = new List<OPCServerItem>();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ;
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            lbNodes.Items.Clear();
            _OPCServers.Clear();

            using (var discoveryClient = new OpcClassicDiscoveryClient("localhost"))
            {
                var servers = discoveryClient.DiscoverServers();

                foreach (var server in servers)
                {
                    lbNodes.Items.Add(server.Name);
                    _OPCServers.Add(new OPCServerItem()
                    {
                        Name = server.Name,
                        ClassId = server.ClassId,
                        ProgId = server.ProgId
                    });
                }
            }

            if (lbNodes.Items.Count > 0)
                lbNodes.SelectedIndex = 0;

        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = tbConnectionString.Text;

                if (_Client == null)
                    _Client = new OpcClient(connectionString);

                _Client.Connect();

                lbStatus.Text = $"OPC Client: {_Client.State}";
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "TRAEGERKepware Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);

                _Client.Dispose();
                _Client = null;
                
                lbStatus.Text = "OPC Client: UKNOWN";
            }
            finally
            {
                
            }
            
        }

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            if (_Client == null)
                return;
            
            _Client.Disconnect();

            lbStatus.Text = $"OPC Client: {_Client.State}";
            
            _Client.Dispose();
            _Client = null;
        }

        private void lbNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Name = lbNodes.SelectedItem.ToString();
            tbName.Text = Name;

            if (_OPCServers.Count > 0)
            {
                OPCServerItem selected = _OPCServers.Where(s => s.Name == Name).FirstOrDefault();
                if (selected != null)
                {
                    tbClassId.Text = selected.ClassId.ToString();
                    tbProgId.Text = selected.ProgId;
                    
                    string port = "49320"; // Default Kepware Port
                    string progId = selected.ProgId;
                    string classId = selected.ClassId.ToString().ToUpper(); 
                    tbConnectionString.Text = $"opc.com://localhost:{port}/{progId}/{classId}";
                }
            }
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            if (_Client == null)
                return;

            OpcReadNode[] commands = new OpcReadNode[] {
                new OpcReadNode("ns=2;s=Simulation Examples.Functions.Sine1"),
                new OpcReadNode("ns=2;s=Simulation Examples.Functions.Sine2"),
                new OpcReadNode("ns=2;s=Simulation Examples.Functions.Sine3")
            };

            // IEnumerable<OpcValue> job = _Client.ReadNodes(commands);
            List<OpcValue> job = _Client.ReadNodes(commands).ToList();
            tbValue1.Text = job[0].Value.ToString();
            tbValue2.Text = job[1].Value.ToString();
            tbValue3.Text = job[2].Value.ToString();
        }
    }
}
