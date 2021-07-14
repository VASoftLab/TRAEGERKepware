
namespace TRAEGERKepware
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbNodes = new System.Windows.Forms.ListBox();
            this.btBrowse = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.btDisconnect = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tbConnectionString = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbClassId = new System.Windows.Forms.TextBox();
            this.lbClassId = new System.Windows.Forms.Label();
            this.tbProgId = new System.Windows.Forms.TextBox();
            this.lbProgId = new System.Windows.Forms.Label();
            this.lbConnectionString = new System.Windows.Forms.Label();
            this.btRead = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lpPort = new System.Windows.Forms.Label();
            this.btSubscribe = new System.Windows.Forms.Button();
            this.timerGUI = new System.Windows.Forms.Timer(this.components);
            this.T5G3 = new TRAEGERKepware.UCGrid();
            this.T4G3 = new TRAEGERKepware.UCGrid();
            this.T3G3 = new TRAEGERKepware.UCGrid();
            this.SuspendLayout();
            // 
            // lbNodes
            // 
            this.lbNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbNodes.FormattingEnabled = true;
            this.lbNodes.ItemHeight = 16;
            this.lbNodes.Location = new System.Drawing.Point(12, 13);
            this.lbNodes.Name = "lbNodes";
            this.lbNodes.Size = new System.Drawing.Size(369, 180);
            this.lbNodes.TabIndex = 0;
            this.lbNodes.SelectedIndexChanged += new System.EventHandler(this.lbNodes_SelectedIndexChanged);
            // 
            // btBrowse
            // 
            this.btBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btBrowse.Location = new System.Drawing.Point(281, 285);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(100, 26);
            this.btBrowse.TabIndex = 1;
            this.btBrowse.Text = "BROWSE";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // btConnect
            // 
            this.btConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btConnect.Location = new System.Drawing.Point(12, 392);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(169, 26);
            this.btConnect.TabIndex = 2;
            this.btConnect.Text = "CONNECT";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btDisconnect
            // 
            this.btDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDisconnect.Location = new System.Drawing.Point(187, 392);
            this.btDisconnect.Name = "btDisconnect";
            this.btDisconnect.Size = new System.Drawing.Size(194, 26);
            this.btDisconnect.TabIndex = 3;
            this.btDisconnect.Text = "DISCONNECT";
            this.btDisconnect.UseVisualStyleBackColor = true;
            this.btDisconnect.Click += new System.EventHandler(this.btDisconnect_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbStatus.Location = new System.Drawing.Point(0, 588);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(704, 23);
            this.lbStatus.TabIndex = 4;
            this.lbStatus.Text = "OPC Client: UNKNOWN";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbConnectionString
            // 
            this.tbConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbConnectionString.Location = new System.Drawing.Point(12, 345);
            this.tbConnectionString.Multiline = true;
            this.tbConnectionString.Name = "tbConnectionString";
            this.tbConnectionString.ReadOnly = true;
            this.tbConnectionString.Size = new System.Drawing.Size(370, 41);
            this.tbConnectionString.TabIndex = 5;
            this.tbConnectionString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbName.Location = new System.Drawing.Point(12, 201);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(48, 18);
            this.lbName.TabIndex = 6;
            this.lbName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(106, 199);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(275, 22);
            this.tbName.TabIndex = 7;
            // 
            // tbClassId
            // 
            this.tbClassId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbClassId.Location = new System.Drawing.Point(106, 227);
            this.tbClassId.Name = "tbClassId";
            this.tbClassId.ReadOnly = true;
            this.tbClassId.Size = new System.Drawing.Size(275, 22);
            this.tbClassId.TabIndex = 9;
            // 
            // lbClassId
            // 
            this.lbClassId.AutoSize = true;
            this.lbClassId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbClassId.Location = new System.Drawing.Point(9, 229);
            this.lbClassId.Name = "lbClassId";
            this.lbClassId.Size = new System.Drawing.Size(57, 18);
            this.lbClassId.TabIndex = 8;
            this.lbClassId.Text = "ClassId";
            // 
            // tbProgId
            // 
            this.tbProgId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbProgId.Location = new System.Drawing.Point(106, 255);
            this.tbProgId.Name = "tbProgId";
            this.tbProgId.ReadOnly = true;
            this.tbProgId.Size = new System.Drawing.Size(275, 22);
            this.tbProgId.TabIndex = 11;
            // 
            // lbProgId
            // 
            this.lbProgId.AutoSize = true;
            this.lbProgId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbProgId.Location = new System.Drawing.Point(12, 257);
            this.lbProgId.Name = "lbProgId";
            this.lbProgId.Size = new System.Drawing.Size(51, 18);
            this.lbProgId.TabIndex = 10;
            this.lbProgId.Text = "ProgId";
            // 
            // lbConnectionString
            // 
            this.lbConnectionString.AutoSize = true;
            this.lbConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbConnectionString.Location = new System.Drawing.Point(12, 324);
            this.lbConnectionString.Name = "lbConnectionString";
            this.lbConnectionString.Size = new System.Drawing.Size(126, 18);
            this.lbConnectionString.TabIndex = 12;
            this.lbConnectionString.Text = "Connection String";
            // 
            // btRead
            // 
            this.btRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRead.Location = new System.Drawing.Point(387, 392);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(100, 26);
            this.btRead.TabIndex = 15;
            this.btRead.Text = "READ";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // tbPort
            // 
            this.tbPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPort.Location = new System.Drawing.Point(106, 287);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(95, 22);
            this.tbPort.TabIndex = 19;
            this.tbPort.Text = "49320";
            // 
            // lpPort
            // 
            this.lpPort.AutoSize = true;
            this.lpPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lpPort.Location = new System.Drawing.Point(12, 289);
            this.lpPort.Name = "lpPort";
            this.lpPort.Size = new System.Drawing.Size(36, 18);
            this.lpPort.TabIndex = 18;
            this.lpPort.Text = "Port";
            // 
            // btSubscribe
            // 
            this.btSubscribe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSubscribe.Location = new System.Drawing.Point(493, 392);
            this.btSubscribe.Name = "btSubscribe";
            this.btSubscribe.Size = new System.Drawing.Size(199, 26);
            this.btSubscribe.TabIndex = 23;
            this.btSubscribe.Text = "SUBSCRIBE";
            this.btSubscribe.UseVisualStyleBackColor = true;
            this.btSubscribe.Click += new System.EventHandler(this.btSubscribe_Click);
            // 
            // timerGUI
            // 
            this.timerGUI.Interval = 1000;
            this.timerGUI.Tick += new System.EventHandler(this.timerGUI_Tick);
            // 
            // T5G3
            // 
            this.T5G3.AFlowMR = 0D;
            this.T5G3.AFlowMV = 0D;
            this.T5G3.AFlowSP = 0D;
            this.T5G3.DOMR = 0D;
            this.T5G3.DOMV = 0D;
            this.T5G3.DOSP = 0D;
            this.T5G3.Location = new System.Drawing.Point(472, 426);
            this.T5G3.Margin = new System.Windows.Forms.Padding(5);
            this.T5G3.Name = "T5G3";
            this.T5G3.Padding = new System.Windows.Forms.Padding(5);
            this.T5G3.Size = new System.Drawing.Size(220, 155);
            this.T5G3.TabIndex = 22;
            this.T5G3.Title = "GRID 53";
            this.T5G3.ValveMR = 0D;
            this.T5G3.ValveMV = 0D;
            this.T5G3.ValveSP = 0D;
            // 
            // T4G3
            // 
            this.T4G3.AFlowMR = 0D;
            this.T4G3.AFlowMV = 0D;
            this.T4G3.AFlowSP = 0D;
            this.T4G3.DOMR = 0D;
            this.T4G3.DOMV = 0D;
            this.T4G3.DOSP = 0D;
            this.T4G3.Location = new System.Drawing.Point(242, 426);
            this.T4G3.Margin = new System.Windows.Forms.Padding(5);
            this.T4G3.Name = "T4G3";
            this.T4G3.Padding = new System.Windows.Forms.Padding(5);
            this.T4G3.Size = new System.Drawing.Size(220, 155);
            this.T4G3.TabIndex = 21;
            this.T4G3.Title = "GRID 34";
            this.T4G3.ValveMR = 0D;
            this.T4G3.ValveMV = 0D;
            this.T4G3.ValveSP = 0D;
            // 
            // T3G3
            // 
            this.T3G3.AFlowMR = 0D;
            this.T3G3.AFlowMV = 0D;
            this.T3G3.AFlowSP = 0D;
            this.T3G3.DOMR = 0D;
            this.T3G3.DOMV = 0D;
            this.T3G3.DOSP = 0D;
            this.T3G3.Location = new System.Drawing.Point(12, 426);
            this.T3G3.Margin = new System.Windows.Forms.Padding(5);
            this.T3G3.Name = "T3G3";
            this.T3G3.Padding = new System.Windows.Forms.Padding(5);
            this.T3G3.Size = new System.Drawing.Size(220, 155);
            this.T3G3.TabIndex = 20;
            this.T3G3.Title = "GRID 33";
            this.T3G3.ValveMR = 0D;
            this.T3G3.ValveMV = 0D;
            this.T3G3.ValveSP = 0D;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 611);
            this.Controls.Add(this.btSubscribe);
            this.Controls.Add(this.T5G3);
            this.Controls.Add(this.T4G3);
            this.Controls.Add(this.T3G3);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lpPort);
            this.Controls.Add(this.btRead);
            this.Controls.Add(this.lbConnectionString);
            this.Controls.Add(this.tbProgId);
            this.Controls.Add(this.lbProgId);
            this.Controls.Add(this.tbClassId);
            this.Controls.Add(this.lbClassId);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbConnectionString);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btDisconnect);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.lbNodes);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRAEGER Kepware TEST";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbNodes;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btDisconnect;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.TextBox tbConnectionString;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbClassId;
        private System.Windows.Forms.Label lbClassId;
        private System.Windows.Forms.TextBox tbProgId;
        private System.Windows.Forms.Label lbProgId;
        private System.Windows.Forms.Label lbConnectionString;
        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lpPort;
        private UCGrid T3G3;
        private UCGrid T4G3;
        private UCGrid T5G3;
        private System.Windows.Forms.Button btSubscribe;
        private System.Windows.Forms.Timer timerGUI;
    }
}

