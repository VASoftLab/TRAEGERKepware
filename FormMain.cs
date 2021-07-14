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

using NLog;

using TRAEGERKepware.Model;

// https://docs.traeger.de/en/software/sdk/opc-ua/net/client.development.guide

namespace TRAEGERKepware
{
    public partial class FormMain : Form
    {
        private OpcClient client; // OPC Client
        private List<OPCServerItem> _OPCServers; // OPC Servers List

        private List<string> _TAG;
        
        private Logger logger;

        private Plant plant;

        public FormMain()
        {
            InitializeComponent();
            InitializeUC();
            
            logger = LogManager.GetCurrentClassLogger();

            _OPCServers = new List<OPCServerItem>();
        }

        private void InitializeUC()
        {
            T3G3.ValveMV_Click += btT3G3ValveMV_Click;
            T3G3.AFlowMV_Click += btT3G3AFlowMV_Click;
            T3G3.DOMV_Click += btT3G3DOMV_Click;

            T4G3.ValveMV_Click += btT4G3ValveMV_Click;
            T4G3.AFlowMV_Click += btT4G3AFlowMV_Click;
            T4G3.DOMV_Click += btT4G3DOMV_Click;

            T5G3.ValveMV_Click += btT5G3ValveMV_Click;
            T5G3.AFlowMV_Click += btT5G3AFlowMV_Click;
            T5G3.DOMV_Click += btT5G3DOMV_Click;
        }

        #region InitializeUC
        private void btT3G3ValveMV_Click(object sender, EventArgs e)
        {
            double value = T3G3.ValveMV;
        }
        private void btT3G3AFlowMV_Click(object sender, EventArgs e)
        {
            double value = T3G3.AFlowMV;
        }
        private void btT3G3DOMV_Click(object sender, EventArgs e)
        {
            double value = T3G3.DOMV;
        }

        private void btT4G3ValveMV_Click(object sender, EventArgs e)
        {
            double value = T4G3.ValveMV;
        }
        private void btT4G3AFlowMV_Click(object sender, EventArgs e)
        {
            double value = T4G3.AFlowMV;
        }
        private void btT4G3DOMV_Click(object sender, EventArgs e)
        {
            double value = T4G3.DOMV;
        }

        private void btT5G3ValveMV_Click(object sender, EventArgs e)
        {
            double value = T5G3.ValveMV;
        }
        private void btT5G3AFlowMV_Click(object sender, EventArgs e)
        {
            double value = T5G3.AFlowMV;
        }
        private void btT5G3DOMV_Click(object sender, EventArgs e)
        {
            double value = T5G3.DOMV;
        }
        #endregion


        private void FormMain_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("tag-list.csv"))
            {
                string[] data = System.IO.File.ReadAllLines("tag-list.csv");
                _TAG = new List<string>(data);
            }
            else
            {
                MessageBox.Show("The tag-list.csv not found!", "Error", icon: MessageBoxIcon.Warning, buttons: MessageBoxButtons.OK);
            }            
        }

        #region Get OPC Server Data
        private void btBrowse_Click(object sender, EventArgs e)
        {
            // Clear all previoud items
            lbNodes.Items.Clear();
            _OPCServers.Clear();

            // Get list of the installed OPC Servers on the localhostg
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
            // Select the first server item
            if (lbNodes.Items.Count > 0)
                lbNodes.SelectedIndex = 0;
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

                    string port = tbPort.Text;
                    string progId = selected.ProgId;
                    string classId = selected.ClassId.ToString().ToUpper();
                    tbConnectionString.Text = $"opc.com://localhost:{port}/{progId}/{classId}";
                }
            }
        }
        #endregion

        #region OPC Server Functions
        private void OPCConnect(string connectionString)
        {
            try
            {
                if (client == null)
                {
                    client = new OpcClient(connectionString);
                    client.StateChanged += Client_StateChanged;
                    client.Connect();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "TRAEGERKepware Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                logger.Error(E.Message);

                if (client != null)
                {
                    client.Dispose();
                    client = null;
                }
                
                lbStatus.Text = "OPC Client: UKNOWN";
            }
        }
        
        private void Client_StateChanged(object sender, OpcClientStateChangedEventArgs e)
        {
            lbStatus.Text = $"OPC Client: {e.NewState}";
        }

        private void OPCDisconnect()
        {
            if (client == null)
                return;

            try
            {
                client.Disconnect();
                client.Dispose();
                client = null;
            }
            catch (Exception E)
            {
                logger.Error(E.Message);
            }
            
        }
        #endregion

        #region Connect / Dosconnect OnClick
        private void btConnect_Click(object sender, EventArgs e)
        {
            string connectionString = tbConnectionString.Text;

            if (!String.IsNullOrEmpty(connectionString))
            {
                logger.Info(connectionString);
                OPCConnect(connectionString);
            }
            else
                MessageBox.Show("Connection string is empty", "Warning", icon: MessageBoxIcon.Warning, buttons: MessageBoxButtons.OK);
        }

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            OPCDisconnect();

            if (timerGUI.Enabled)
                timerGUI.Stop();
        }
        #endregion

        private void btRead_Click(object sender, EventArgs e)
        {
            if (client == null)
                return;

            //List<OpcReadNode> commandList = new List<OpcReadNode>();
            //foreach (string tag in _TAG)
            //{
            //    commandList.Add(new OpcReadNode($"ns=2;{tag}"));
            //}

            //OpcReadNode[] commands = commandList.ToArray();

            //IEnumerable<OpcValue> nodevalues = _Client.ReadNodes(commands);
            //IEnumerator<OpcValue> node = nodevalues.GetEnumerator();

            //while (node.MoveNext())
            //{
            //    node.Current.Value.ToString();
            //}

            //plant.T3G3.ValveReadings = Convert.ToDouble(client.ReadNode("ns=2;s=Simulation Examples.Functions.Sine1").Value);

#if DEBUG
            plant.T3G3.ValveReadings = Convert.ToDouble(client.ReadNode("ns=2;s=Simulation Examples.Functions.Sine1").Value);
            plant.T4G3.ValveReadings = Convert.ToDouble(client.ReadNode("ns=2;s=Simulation Examples.Functions.Sine2").Value);
            plant.T5G3.ValveReadings = Convert.ToDouble(client.ReadNode("ns=2;s=Simulation Examples.Functions.Sine3").Value);
#else
            plant.T3G3.ValveReadings = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank3.Grid3.Airflow.MeterReadings").Value);
            plant.T3G3.ValveSetpoint = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank3.Grid3.Airflow.SetPoint").Value);
            plant.T3G3.AirflowReadings = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank3.Grid3.Airflow.MeterReadings").Value);
            plant.T3G3.AirflowSetpoint = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank3.Grid3.Airflow.SetPoint").Value);
            plant.T3G3.DOReadings = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank3.Grid3.DO.MeterReadings").Value);
            plant.T3G3.DOSetpoint = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank3.Grid3.DO.SetPoint").Value);

            plant.T4G3.ValveReadings = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank4.Grid3.Airflow.MeterReadings").Value);
            plant.T4G3.ValveSetpoint = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank4.Grid3.Airflow.SetPoint").Value);
            plant.T4G3.AirflowReadings = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank4.Grid3.Airflow.MeterReadings").Value);
            plant.T4G3.AirflowSetpoint = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank4.Grid3.Airflow.SetPoint").Value);
            plant.T4G3.DOReadings = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank4.Grid3.DO.MeterReadings").Value);
            plant.T4G3.DOSetpoint = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank4.Grid3.DO.SetPoint").Value);

            plant.T5G3.ValveReadings = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank5.Grid3.Airflow.MeterReadings").Value);
            plant.T5G3.ValveSetpoint = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank5.Grid3.Airflow.SetPoint").Value);
            plant.T5G3.AirflowReadings = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank5.Grid3.Airflow.MeterReadings").Value);
            plant.T5G3.AirflowSetpoint = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank5.Grid3.Airflow.SetPoint").Value);
            plant.T5G3.DOReadings = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank5.Grid3.DO.MeterReadings").Value);
            plant.T5G3.DOSetpoint = Convert.ToDouble(client.ReadNode("ns=2;s=PlantDO.PLCB.Tank5.Grid3.DO.SetPoint").Value);
#endif
            RefreshData();
        }

        private void RefreshData()
        {
            T3G3.BeginInvoke(new Action(() =>
            {
                T3G3.ValveMR = plant.T3G3.ValveReadings;
                T3G3.ValveSP = plant.T3G3.ValveSetpoint;
                T3G3.AFlowMR = plant.T3G3.AirflowReadings;
                T3G3.AFlowSP = plant.T3G3.AirflowSetpoint;
                T3G3.DOMR = plant.T3G3.DOReadings;
                T3G3.DOSP = plant.T3G3.DOSetpoint;
            }));

            T4G3.BeginInvoke(new Action(() =>
            {
                T4G3.ValveMR = plant.T4G3.ValveReadings;
                T4G3.ValveSP = plant.T4G3.ValveSetpoint;
                T4G3.AFlowMR = plant.T4G3.AirflowReadings;
                T4G3.AFlowSP = plant.T4G3.AirflowSetpoint;
                T4G3.DOMR = plant.T4G3.DOReadings;
                T4G3.DOSP = plant.T4G3.DOSetpoint;
            }));

            T5G3.BeginInvoke(new Action(() =>
            {
                T5G3.ValveMR = plant.T5G3.ValveReadings;
                T5G3.ValveSP = plant.T5G3.ValveSetpoint;
                T5G3.AFlowMR = plant.T5G3.AirflowReadings;
                T5G3.AFlowSP = plant.T5G3.AirflowSetpoint;
                T5G3.DOMR = plant.T5G3.DOReadings;
                T5G3.DOSP = plant.T5G3.DOSetpoint;
            }));
        }

        private void btSubscribe_Click(object sender, EventArgs e)
        {
            if (client == null)
                return;

            if (client.State == OpcClientState.Connected)
            {
                #region Subscription
                OpcSubscription subscription = client.SubscribeNodes();
#if DEBUG
                string[] nodeIds = {
                        "ns=2;s=Simulation Examples.Functions.Sine1",
                        "ns=2;s=Simulation Examples.Functions.Sine2",
                        "ns=2;s=Simulation Examples.Functions.Sine3"
                    };
#else
                string[] nodeIds = {
                        "ns=2;s=PlantDO.PLCB.Tank3.Grid3.Airflow.MeterReadings",
                        "ns=2;s=PlantDO.PLCB.Tank3.Grid3.Airflow.SetPoint",
                        "ns=2;s=PlantDO.PLCB.Tank3.Grid3.Airflow.MeterReadings",
                        "ns=2;s=PlantDO.PLCB.Tank3.Grid3.Airflow.SetPoint",
                        "ns=2;s=PlantDO.PLCB.Tank3.Grid3.DO.MeterReadings",
                        "ns=2;s=PlantDO.PLCB.Tank3.Grid3.DO.SetPoint",
                        "ns=2;s=PlantDO.PLCB.Tank4.Grid3.Airflow.MeterReadings",
                        "ns=2;s=PlantDO.PLCB.Tank4.Grid3.Airflow.SetPoint",
                        "ns=2;s=PlantDO.PLCB.Tank4.Grid3.Airflow.MeterReadings",
                        "ns=2;s=PlantDO.PLCB.Tank4.Grid3.Airflow.SetPoint",
                        "ns=2;s=PlantDO.PLCB.Tank4.Grid3.DO.MeterReadings",
                        "ns=2;s=PlantDO.PLCB.Tank4.Grid3.DO.SetPoint",
                        "ns=2;s=PlantDO.PLCB.Tank5.Grid3.Airflow.MeterReadings",
                        "ns=2;s=PlantDO.PLCB.Tank5.Grid3.Airflow.SetPoint",
                        "ns=2;s=PlantDO.PLCB.Tank5.Grid3.Airflow.MeterReadings",
                        "ns=2;s=PlantDO.PLCB.Tank5.Grid3.Airflow.SetPoint",
                        "ns=2;s=PlantDO.PLCB.Tank5.Grid3.DO.MeterReadings",
                        "ns=2;s=PlantDO.PLCB.Tank5.Grid3.DO.SetPoint",
                    };
#endif
                for (int index = 0; index < nodeIds.Length; index++)
                {
                    // Create an OpcMonitoredItem for the NodeId.
                    var item = new OpcMonitoredItem(nodeIds[index], OpcAttribute.Value);
                    item.DataChangeReceived += HandleDataChanged;

                    // You can set your own values on the "Tag" property
                    // that allows you to identify the source later.
                    item.Tag = index;

                    // Set a custom sampling interval on the monitored item.
                    item.SamplingInterval = 1000;

                    // Add the item to the subscription.
                    subscription.AddMonitoredItem(item);
                }

                // After adding the items (or configuring the subscription), apply the changes.
                subscription.ApplyChanges();

                if (!timerGUI.Enabled)
                    timerGUI.Start();
                #endregion
            }
            else
                MessageBox.Show("Check the OPC connection", "Warning", icon: MessageBoxIcon.Warning, buttons: MessageBoxButtons.OK);
        }

        private void HandleDataChanged(object sender, OpcDataChangeReceivedEventArgs e)
        {
            // The tag property contains the previously set value.
            try
            {
                OpcMonitoredItem item = (OpcMonitoredItem)sender;
                string value = e.Item.Value.ToString();

                // logger.Info(item.NodeId.Value.ToString());
                // TODO: Update GUI on DataChanged
#if DEBUG
                if (item.NodeId.Value.ToString() == "Simulation Examples.Functions.Sine1")
                    plant.T3G3.ValveReadings = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "Simulation Examples.Functions.Sine2")
                    plant.T4G3.ValveReadings = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "Simulation Examples.Functions.Sine3")
                    plant.T5G3.ValveReadings = Convert.ToDouble(value);
#else
                if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank3.Grid3.Airflow.MeterReadings")
                    plant.T3G3.ValveReadings = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank3.Grid3.Airflow.SetPoint")
                    plant.T3G3.ValveSetpoint = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank3.Grid3.Airflow.MeterReadings")
                    plant.T3G3.AirflowReadings = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank3.Grid3.Airflow.SetPoint")
                    plant.T3G3.AirflowSetpoint = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank3.Grid3.DO.MeterReadings")
                    plant.T3G3.DOReadings = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank3.Grid3.DO.SetPoint")
                    plant.T3G3.DOSetpoint = Convert.ToDouble(value);

                if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank4.Grid3.Airflow.MeterReadings")
                    plant.T4G3.ValveReadings = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank4.Grid3.Airflow.SetPoint")
                    plant.T4G3.ValveSetpoint = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank4.Grid3.Airflow.MeterReadings")
                    plant.T4G3.AirflowReadings = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank4.Grid3.Airflow.SetPoint")
                    plant.T4G3.AirflowSetpoint = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank4.Grid3.DO.MeterReadings")
                    plant.T4G3.DOReadings = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank4.Grid3.DO.SetPoint")
                    plant.T4G3.DOSetpoint = Convert.ToDouble(value);

                if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank5.Grid3.Airflow.MeterReadings")
                    plant.T5G3.ValveReadings = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank5.Grid3.Airflow.SetPoint")
                    plant.T5G3.ValveSetpoint = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank5.Grid3.Airflow.MeterReadings")
                    plant.T5G3.AirflowReadings = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank5.Grid3.Airflow.SetPoint")
                    plant.T5G3.AirflowSetpoint = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank5.Grid3.DO.MeterReadings")
                    plant.T5G3.DOReadings = Convert.ToDouble(value);
                else if (item.NodeId.Value.ToString() == "PlantDO.PLCB.Tank5.Grid3.DO.SetPoint")
                    plant.T5G3.DOSetpoint = Convert.ToDouble(value);
#endif
            }
            catch (Exception E)
            {
                logger.Debug(E.Message);
            }            
        }

        private void timerGUI_Tick(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}