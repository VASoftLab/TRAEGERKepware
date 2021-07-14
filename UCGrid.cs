using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRAEGERKepware
{
    public partial class UCGrid : UserControl
    {
        public event EventHandler ValveMV_Click;
        public event EventHandler AFlowMV_Click;
        public event EventHandler DOMV_Click;

        public String Title
        {
            get
            {
                return gbGrid.Text;
            }
            set
            {
                gbGrid.Text = value;
            }
        }

        private double _ValveMR;
        private double _ValveSP;
        private double _ValveMV;
        private double _AFlowMR;
        private double _AFlowSP;
        private double _AFlowMV;
        private double _DOMR;
        private double _DOSP;
        private double _DOMV;

        public Double ValveMR { get { return _ValveMR; } set { _ValveMR = value; tbValveMR.Text = value.ToString("0.0"); } }
        public Double ValveSP { get { return _ValveSP; } set { _ValveSP = value; tbValveSP.Text = value.ToString("0.0"); } }
        public Double ValveMV { get { return _ValveMV; } set { _ValveMV = value; tbValveMV.Text = value.ToString("0.0"); } }

        public Double AFlowMR { get { return _AFlowMR; } set { _AFlowMR = value; tbAFlowMR.Text = value.ToString("0.00"); } }
        public Double AFlowSP { get { return _AFlowSP; } set { _AFlowSP = value; tbAFlowSP.Text = value.ToString("0.00"); } }
        public Double AFlowMV { get { return _AFlowMV; } set { _AFlowMV = value; tbAFlowMV.Text = value.ToString("0.00"); } }

        public Double DOMR { get { return _DOMR; } set { _DOMR = value; tbDOMR.Text = value.ToString("0.00"); } }
        public Double DOSP { get { return _DOSP; } set { _DOSP = value; tbDOSP.Text = value.ToString("0.00"); } }
        public Double DOMV { get { return _DOMV; } set { _DOMV = value; tbDOMV.Text = value.ToString("0.00"); } }

        public UCGrid()
        {
            InitializeComponent();
            Initialization();
        }

        private void Initialization()
        {
            Title = "GRID";
            
            ValveMR = 0;
            ValveSP = 0;
            ValveMV = 0;

            AFlowMR = 0;
            AFlowSP = 0;
            AFlowMV = 0;

            DOMR = 0;
            DOSP = 0;
            DOMV = 0;
        }

        private void btValveMV_Click(object sender, EventArgs e)
        {
            Double.TryParse(tbValveMV.Text, out double value);
            ValveMV = value;
            this.ValveMV_Click?.Invoke(this, e);
        }

        private void btAFlowSP_Click(object sender, EventArgs e)
        {
            Double.TryParse(tbAFlowMV.Text, out double value);
            AFlowMV = value;
            this.AFlowMV_Click?.Invoke(this, e);
        }

        private void btDOSP_Click(object sender, EventArgs e)
        {
            Double.TryParse(tbDOMV.Text, out double value);
            DOMV = value;
            this.DOMV_Click?.Invoke(this, e);
        }
    }
}
