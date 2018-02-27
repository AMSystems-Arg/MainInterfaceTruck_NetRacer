namespace ar.com.amsystems.Telemetry.Server
{
    partial class MIT_Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIT_Server));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_versionEST2 = new System.Windows.Forms.Label();
            this.lbl_versionTitleEST2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.interfacesDropDown = new System.Windows.Forms.ComboBox();
            this.networkInterfaceTitleLabel = new System.Windows.Forms.Label();
            this.serverIpTitleLabel = new System.Windows.Forms.Label();
            this.appUrlLabel = new System.Windows.Forms.LinkLabel();
            this.appUrlTitleLabel = new System.Windows.Forms.Label();
            this.apiUrlLabel = new System.Windows.Forms.LinkLabel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.apiEndpointUrlTitleLabel = new System.Windows.Forms.Label();
            this.statusTitleLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.broadcastTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipTitle = "MIT Telemetry Server corriendo...";
            this.trayIcon.ContextMenuStrip = this.contextMenuStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "MIT Telemetry Server corriendo...";
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(107, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::ar.com.amsystems.Telemetry.Server.Properties.Resources.CloseIcon;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.closeToolStripMenuItem.Text = "Cerrar";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // statusUpdateTimer
            // 
            this.statusUpdateTimer.Interval = 3000;
            this.statusUpdateTimer.Tick += new System.EventHandler(this.statusUpdateTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_versionEST2);
            this.groupBox1.Controls.Add(this.lbl_versionTitleEST2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.ipAddressLabel);
            this.groupBox1.Controls.Add(this.interfacesDropDown);
            this.groupBox1.Controls.Add(this.networkInterfaceTitleLabel);
            this.groupBox1.Controls.Add(this.serverIpTitleLabel);
            this.groupBox1.Controls.Add(this.appUrlLabel);
            this.groupBox1.Controls.Add(this.appUrlTitleLabel);
            this.groupBox1.Controls.Add(this.apiUrlLabel);
            this.groupBox1.Controls.Add(this.statusLabel);
            this.groupBox1.Controls.Add(this.apiEndpointUrlTitleLabel);
            this.groupBox1.Controls.Add(this.statusTitleLabel);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 265);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // lbl_versionEST2
            // 
            this.lbl_versionEST2.AutoSize = true;
            this.lbl_versionEST2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_versionEST2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_versionEST2.Location = new System.Drawing.Point(144, 137);
            this.lbl_versionEST2.Name = "lbl_versionEST2";
            this.lbl_versionEST2.Size = new System.Drawing.Size(76, 18);
            this.lbl_versionEST2.TabIndex = 37;
            this.lbl_versionEST2.Text = "Checking...";
            // 
            // lbl_versionTitleEST2
            // 
            this.lbl_versionTitleEST2.AutoSize = true;
            this.lbl_versionTitleEST2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_versionTitleEST2.Location = new System.Drawing.Point(48, 137);
            this.lbl_versionTitleEST2.Name = "lbl_versionTitleEST2";
            this.lbl_versionTitleEST2.Size = new System.Drawing.Size(103, 18);
            this.lbl_versionTitleEST2.TabIndex = 36;
            this.lbl_versionTitleEST2.Text = "Version Motor: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(127, 206);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ipAddressLabel.Location = new System.Drawing.Point(144, 69);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(103, 18);
            this.ipAddressLabel.TabIndex = 34;
            this.ipAddressLabel.Text = "Verificando IP...";
            this.toolTip.SetToolTip(this.ipAddressLabel, "Use this IP address for mobile application (Android)");
            // 
            // interfacesDropDown
            // 
            this.interfacesDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interfacesDropDown.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfacesDropDown.FormattingEnabled = true;
            this.interfacesDropDown.Location = new System.Drawing.Point(147, 24);
            this.interfacesDropDown.Name = "interfacesDropDown";
            this.interfacesDropDown.Size = new System.Drawing.Size(361, 25);
            this.interfacesDropDown.TabIndex = 33;
            this.interfacesDropDown.TabStop = false;
            this.interfacesDropDown.SelectedIndexChanged += new System.EventHandler(this.interfacesDropDown_SelectedIndexChanged);
            // 
            // networkInterfaceTitleLabel
            // 
            this.networkInterfaceTitleLabel.AutoSize = true;
            this.networkInterfaceTitleLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.networkInterfaceTitleLabel.Location = new System.Drawing.Point(23, 27);
            this.networkInterfaceTitleLabel.Name = "networkInterfaceTitleLabel";
            this.networkInterfaceTitleLabel.Size = new System.Drawing.Size(120, 18);
            this.networkInterfaceTitleLabel.TabIndex = 32;
            this.networkInterfaceTitleLabel.Text = "Interfaces de Red:";
            // 
            // serverIpTitleLabel
            // 
            this.serverIpTitleLabel.AutoSize = true;
            this.serverIpTitleLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIpTitleLabel.Location = new System.Drawing.Point(29, 68);
            this.serverIpTitleLabel.Name = "serverIpTitleLabel";
            this.serverIpTitleLabel.Size = new System.Drawing.Size(118, 18);
            this.serverIpTitleLabel.TabIndex = 31;
            this.serverIpTitleLabel.Text = "IP del Server MIT: ";
            this.serverIpTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // appUrlLabel
            // 
            this.appUrlLabel.AutoSize = true;
            this.appUrlLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appUrlLabel.Location = new System.Drawing.Point(390, 172);
            this.appUrlLabel.Name = "appUrlLabel";
            this.appUrlLabel.Size = new System.Drawing.Size(82, 18);
            this.appUrlLabel.TabIndex = 30;
            this.appUrlLabel.TabStop = true;
            this.appUrlLabel.Text = "appUrlLabel";
            // 
            // appUrlTitleLabel
            // 
            this.appUrlTitleLabel.AutoSize = true;
            this.appUrlTitleLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appUrlTitleLabel.Location = new System.Drawing.Point(266, 172);
            this.appUrlTitleLabel.Name = "appUrlTitleLabel";
            this.appUrlTitleLabel.Size = new System.Drawing.Size(107, 18);
            this.appUrlTitleLabel.TabIndex = 29;
            this.appUrlTitleLabel.Text = "HTML5 App URL:";
            // 
            // apiUrlLabel
            // 
            this.apiUrlLabel.AutoSize = true;
            this.apiUrlLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiUrlLabel.Location = new System.Drawing.Point(142, 173);
            this.apiUrlLabel.Name = "apiUrlLabel";
            this.apiUrlLabel.Size = new System.Drawing.Size(78, 18);
            this.apiUrlLabel.TabIndex = 28;
            this.apiUrlLabel.TabStop = true;
            this.apiUrlLabel.Text = "apiUrlLabel";
            this.toolTip.SetToolTip(this.apiUrlLabel, "Use this URL to develop your own applications based on the REST API (click to ope" +
        "n)");
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusLabel.Location = new System.Drawing.Point(144, 103);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(76, 18);
            this.statusLabel.TabIndex = 27;
            this.statusLabel.Text = "Checking...";
            // 
            // apiEndpointUrlTitleLabel
            // 
            this.apiEndpointUrlTitleLabel.AutoSize = true;
            this.apiEndpointUrlTitleLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiEndpointUrlTitleLabel.Location = new System.Drawing.Point(15, 173);
            this.apiEndpointUrlTitleLabel.Name = "apiEndpointUrlTitleLabel";
            this.apiEndpointUrlTitleLabel.Size = new System.Drawing.Size(125, 18);
            this.apiEndpointUrlTitleLabel.TabIndex = 26;
            this.apiEndpointUrlTitleLabel.Text = "Telemetry API URL:";
            // 
            // statusTitleLabel
            // 
            this.statusTitleLabel.AutoSize = true;
            this.statusTitleLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTitleLabel.Location = new System.Drawing.Point(93, 103);
            this.statusTitleLabel.Name = "statusTitleLabel";
            this.statusTitleLabel.Size = new System.Drawing.Size(56, 18);
            this.statusTitleLabel.TabIndex = 25;
            this.statusTitleLabel.Text = "Estado: ";
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 250;
            this.toolTip.AutoPopDelay = 6000;
            this.toolTip.InitialDelay = 250;
            this.toolTip.ReshowDelay = 50;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // broadcastTimer
            // 
            this.broadcastTimer.Interval = 1000;
            this.broadcastTimer.Tick += new System.EventHandler(this.broadcastTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenu,
            this.helpToolStripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(553, 26);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serverToolStripMenu
            // 
            this.serverToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uninstallToolStripMenuItem});
            this.serverToolStripMenu.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverToolStripMenu.Name = "serverToolStripMenu";
            this.serverToolStripMenu.Size = new System.Drawing.Size(60, 22);
            this.serverToolStripMenu.Text = "Server";
            // 
            // uninstallToolStripMenuItem
            // 
            this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            this.uninstallToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.uninstallToolStripMenuItem.Text = "Desinstalar Telemetria MIT";
            this.uninstallToolStripMenuItem.Click += new System.EventHandler(this.uninstallToolStripMenuItem_Click);
            // 
            // helpToolStripMenu
            // 
            this.helpToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenu.Name = "helpToolStripMenu";
            this.helpToolStripMenu.Size = new System.Drawing.Size(53, 22);
            this.helpToolStripMenu.Text = "Ayuda";
            this.helpToolStripMenu.Visible = false;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.helpToolStripMenuItem.Text = "Ayuda (F1)";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aboutToolStripMenuItem.Text = "About (F2)";
            this.aboutToolStripMenuItem.Visible = false;
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MIT_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 301);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MIT_Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainInterfaceTruckServer(Telemetría Server)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MIT_Server_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Timer statusUpdateTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer broadcastTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem uninstallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lbl_versionEST2;
        private System.Windows.Forms.Label lbl_versionTitleEST2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label ipAddressLabel;
        private System.Windows.Forms.ComboBox interfacesDropDown;
        private System.Windows.Forms.Label networkInterfaceTitleLabel;
        private System.Windows.Forms.Label serverIpTitleLabel;
        private System.Windows.Forms.LinkLabel appUrlLabel;
        private System.Windows.Forms.Label appUrlTitleLabel;
        private System.Windows.Forms.LinkLabel apiUrlLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label apiEndpointUrlTitleLabel;
        private System.Windows.Forms.Label statusTitleLabel;
    }
}

