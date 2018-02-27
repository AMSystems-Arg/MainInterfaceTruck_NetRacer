namespace ar.com.amsystems.Telemetry.Server
{
    partial class Interfaz_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interfaz_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_archivo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_imprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_salir = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_config = new System.Windows.Forms.ToolStripMenuItem();
            this.serverMITEstadoSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ayuda = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_manual = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_contacto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_licencia = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.group_main = new System.Windows.Forms.GroupBox();
            this.lbl_capacita = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.lb_dni = new System.Windows.Forms.Label();
            this.lb_Apellido = new System.Windows.Forms.Label();
            this.lb_nombre = new System.Windows.Forms.Label();
            this.combo_capa = new System.Windows.Forms.ComboBox();
            this.img_carnet = new System.Windows.Forms.PictureBox();
            this.txt_dni = new System.Windows.Forms.TextBox();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.btn_carnet = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupReporte = new System.Windows.Forms.GroupBox();
            this.txt_capa = new System.Windows.Forms.TextBox();
            this.txt_docDni = new System.Windows.Forms.TextBox();
            this.foto_reporte = new System.Windows.Forms.PictureBox();
            this.txt_conductor = new System.Windows.Forms.TextBox();
            this.lbl_kmRecorrido = new System.Windows.Forms.Label();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.txt_EstacionarDif = new System.Windows.Forms.TextBox();
            this.txt_estacionarFacil = new System.Windows.Forms.TextBox();
            this.txt_multaVelocidad = new System.Windows.Forms.TextBox();
            this.txt_limitcamino = new System.Windows.Forms.TextBox();
            this.txt_choqueAutos = new System.Windows.Forms.TextBox();
            this.txt_choques = new System.Windows.Forms.TextBox();
            this.txt_fueracamino = new System.Windows.Forms.TextBox();
            this.txt_salidasFallidas = new System.Windows.Forms.TextBox();
            this.txt_infracciones = new System.Windows.Forms.TextBox();
            this.txt_ltrsConsumidos = new System.Windows.Forms.TextBox();
            this.img_camionesManejados = new System.Windows.Forms.PictureBox();
            this.img_reporte = new System.Windows.Forms.PictureBox();
            this.layoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.timerActualizarReporte = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.group_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_carnet)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foto_reporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_camionesManejados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_reporte)).BeginInit();
            this.layoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_archivo,
            this.menu_config,
            this.menu_ayuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(862, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_archivo
            // 
            this.menu_archivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_imprimir,
            this.toolStripSeparator3,
            this.menu_salir});
            this.menu_archivo.Name = "menu_archivo";
            this.menu_archivo.Size = new System.Drawing.Size(60, 20);
            this.menu_archivo.Text = "&Archivo";
            // 
            // menu_imprimir
            // 
            this.menu_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("menu_imprimir.Image")));
            this.menu_imprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_imprimir.Name = "menu_imprimir";
            this.menu_imprimir.Size = new System.Drawing.Size(164, 22);
            this.menu_imprimir.Text = "Im&primir Reporte";
            this.menu_imprimir.Click += new System.EventHandler(this.menu_imprimir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            // 
            // menu_salir
            // 
            this.menu_salir.Image = global::ar.com.amsystems.Telemetry.Server.Properties.Resources.FailureStatusIcon;
            this.menu_salir.Name = "menu_salir";
            this.menu_salir.Size = new System.Drawing.Size(164, 22);
            this.menu_salir.Text = "&Salir";
            this.menu_salir.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // menu_config
            // 
            this.menu_config.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverMITEstadoSetup});
            this.menu_config.Name = "menu_config";
            this.menu_config.Size = new System.Drawing.Size(95, 20);
            this.menu_config.Text = "&Configuración";
            // 
            // serverMITEstadoSetup
            // 
            this.serverMITEstadoSetup.Image = ((System.Drawing.Image)(resources.GetObject("serverMITEstadoSetup.Image")));
            this.serverMITEstadoSetup.Name = "serverMITEstadoSetup";
            this.serverMITEstadoSetup.Size = new System.Drawing.Size(212, 22);
            this.serverMITEstadoSetup.Text = "Server MIT (Estado, Setup)";
            this.serverMITEstadoSetup.Click += new System.EventHandler(this.serverMITEstadoSetup_Click);
            // 
            // menu_ayuda
            // 
            this.menu_ayuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_manual,
            this.toolStripSeparator1,
            this.menu_contacto,
            this.toolStripSeparator2,
            this.menu_licencia});
            this.menu_ayuda.Name = "menu_ayuda";
            this.menu_ayuda.Size = new System.Drawing.Size(53, 20);
            this.menu_ayuda.Text = "A&yuda";
            // 
            // menu_manual
            // 
            this.menu_manual.Name = "menu_manual";
            this.menu_manual.Size = new System.Drawing.Size(123, 22);
            this.menu_manual.Text = "Manual";
            this.menu_manual.Click += new System.EventHandler(this.menu_manual_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // menu_contacto
            // 
            this.menu_contacto.Name = "menu_contacto";
            this.menu_contacto.Size = new System.Drawing.Size(123, 22);
            this.menu_contacto.Text = "Contacto";
            this.menu_contacto.Click += new System.EventHandler(this.menu_contacto_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(120, 6);
            // 
            // menu_licencia
            // 
            this.menu_licencia.Image = global::ar.com.amsystems.Telemetry.Server.Properties.Resources.StatusIcon;
            this.menu_licencia.Name = "menu_licencia";
            this.menu_licencia.Size = new System.Drawing.Size(123, 22);
            this.menu_licencia.Text = "Licencia";
            this.menu_licencia.Click += new System.EventHandler(this.menu_licencia_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 957);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(862, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(146, 17);
            this.toolStripStatusLabel1.Text = "By AMSystems for NetRacer";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(859, 923);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.group_main);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(851, 892);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos del Conductor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // group_main
            // 
            this.group_main.BackColor = System.Drawing.SystemColors.Menu;
            this.group_main.Controls.Add(this.lbl_capacita);
            this.group_main.Controls.Add(this.btn_guardar);
            this.group_main.Controls.Add(this.lb_dni);
            this.group_main.Controls.Add(this.lb_Apellido);
            this.group_main.Controls.Add(this.lb_nombre);
            this.group_main.Controls.Add(this.combo_capa);
            this.group_main.Controls.Add(this.img_carnet);
            this.group_main.Controls.Add(this.txt_dni);
            this.group_main.Controls.Add(this.txt_apellido);
            this.group_main.Controls.Add(this.txt_nombre);
            this.group_main.Controls.Add(this.btn_carnet);
            this.group_main.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_main.ForeColor = System.Drawing.Color.MidnightBlue;
            this.group_main.Location = new System.Drawing.Point(143, 52);
            this.group_main.Name = "group_main";
            this.group_main.Size = new System.Drawing.Size(515, 498);
            this.group_main.TabIndex = 3;
            this.group_main.TabStop = false;
            this.group_main.Text = "Ficha Conductor";
            this.group_main.Enter += new System.EventHandler(this.group_Main_Enter);
            // 
            // lbl_capacita
            // 
            this.lbl_capacita.AutoSize = true;
            this.lbl_capacita.Location = new System.Drawing.Point(33, 362);
            this.lbl_capacita.Name = "lbl_capacita";
            this.lbl_capacita.Size = new System.Drawing.Size(139, 18);
            this.lbl_capacita.TabIndex = 12;
            this.lbl_capacita.Text = "Tipo de Capacitación:";
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(403, 446);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(84, 35);
            this.btn_guardar.TabIndex = 5;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // lb_dni
            // 
            this.lb_dni.AutoSize = true;
            this.lb_dni.Location = new System.Drawing.Point(32, 304);
            this.lb_dni.Name = "lb_dni";
            this.lb_dni.Size = new System.Drawing.Size(38, 18);
            this.lb_dni.TabIndex = 11;
            this.lb_dni.Text = "DNI: ";
            // 
            // lb_Apellido
            // 
            this.lb_Apellido.AutoSize = true;
            this.lb_Apellido.Location = new System.Drawing.Point(32, 249);
            this.lb_Apellido.Name = "lb_Apellido";
            this.lb_Apellido.Size = new System.Drawing.Size(68, 18);
            this.lb_Apellido.TabIndex = 10;
            this.lb_Apellido.Text = "Apellido: ";
            // 
            // lb_nombre
            // 
            this.lb_nombre.AutoSize = true;
            this.lb_nombre.Location = new System.Drawing.Point(33, 195);
            this.lb_nombre.Name = "lb_nombre";
            this.lb_nombre.Size = new System.Drawing.Size(66, 18);
            this.lb_nombre.TabIndex = 9;
            this.lb_nombre.Text = "Nombre: ";
            // 
            // combo_capa
            // 
            this.combo_capa.DisplayMember = "valor";
            this.combo_capa.FormattingEnabled = true;
            this.combo_capa.Items.AddRange(new object[] {
            "CBO",
            "OTRO"});
            this.combo_capa.Location = new System.Drawing.Point(35, 383);
            this.combo_capa.MaxLength = 4;
            this.combo_capa.Name = "combo_capa";
            this.combo_capa.Size = new System.Drawing.Size(170, 26);
            this.combo_capa.Sorted = true;
            this.combo_capa.TabIndex = 4;
            this.combo_capa.Text = "Tipo de Capacitación";
            this.combo_capa.ValueMember = "indice";
            // 
            // img_carnet
            // 
            this.img_carnet.Image = ((System.Drawing.Image)(resources.GetObject("img_carnet.Image")));
            this.img_carnet.Location = new System.Drawing.Point(36, 29);
            this.img_carnet.Name = "img_carnet";
            this.img_carnet.Size = new System.Drawing.Size(150, 150);
            this.img_carnet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_carnet.TabIndex = 7;
            this.img_carnet.TabStop = false;
            // 
            // txt_dni
            // 
            this.txt_dni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_dni.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dni.Location = new System.Drawing.Point(35, 325);
            this.txt_dni.MaxLength = 12;
            this.txt_dni.Name = "txt_dni";
            this.txt_dni.Size = new System.Drawing.Size(170, 27);
            this.txt_dni.TabIndex = 3;
            this.txt_dni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_apellido
            // 
            this.txt_apellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_apellido.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_apellido.Location = new System.Drawing.Point(35, 270);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(243, 27);
            this.txt_apellido.TabIndex = 2;
            this.txt_apellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_nombre
            // 
            this.txt_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_nombre.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre.Location = new System.Drawing.Point(35, 216);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(243, 27);
            this.txt_nombre.TabIndex = 1;
            this.txt_nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_carnet
            // 
            this.btn_carnet.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_carnet.Location = new System.Drawing.Point(193, 152);
            this.btn_carnet.Name = "btn_carnet";
            this.btn_carnet.Size = new System.Drawing.Size(86, 28);
            this.btn_carnet.TabIndex = 0;
            this.btn_carnet.Text = "Cargar Foto...";
            this.btn_carnet.UseVisualStyleBackColor = true;
            this.btn_carnet.Click += new System.EventHandler(this.btn_carnet_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.groupReporte);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(851, 892);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reporte";
            // 
            // groupReporte
            // 
            this.groupReporte.BackColor = System.Drawing.Color.White;
            this.groupReporte.Controls.Add(this.txt_capa);
            this.groupReporte.Controls.Add(this.txt_docDni);
            this.groupReporte.Controls.Add(this.foto_reporte);
            this.groupReporte.Controls.Add(this.txt_conductor);
            this.groupReporte.Controls.Add(this.lbl_kmRecorrido);
            this.groupReporte.Controls.Add(this.btn_imprimir);
            this.groupReporte.Controls.Add(this.txt_EstacionarDif);
            this.groupReporte.Controls.Add(this.txt_estacionarFacil);
            this.groupReporte.Controls.Add(this.txt_multaVelocidad);
            this.groupReporte.Controls.Add(this.txt_limitcamino);
            this.groupReporte.Controls.Add(this.txt_choqueAutos);
            this.groupReporte.Controls.Add(this.txt_choques);
            this.groupReporte.Controls.Add(this.txt_fueracamino);
            this.groupReporte.Controls.Add(this.txt_salidasFallidas);
            this.groupReporte.Controls.Add(this.txt_infracciones);
            this.groupReporte.Controls.Add(this.txt_ltrsConsumidos);
            this.groupReporte.Controls.Add(this.img_camionesManejados);
            this.groupReporte.Controls.Add(this.img_reporte);
            this.groupReporte.ForeColor = System.Drawing.Color.Transparent;
            this.groupReporte.Location = new System.Drawing.Point(-4, 3);
            this.groupReporte.Name = "groupReporte";
            this.groupReporte.Size = new System.Drawing.Size(858, 886);
            this.groupReporte.TabIndex = 23;
            this.groupReporte.TabStop = false;
            this.groupReporte.UseCompatibleTextRendering = true;
            // 
            // txt_capa
            // 
            this.txt_capa.BackColor = System.Drawing.Color.White;
            this.txt_capa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_capa.Enabled = false;
            this.txt_capa.Location = new System.Drawing.Point(474, 154);
            this.txt_capa.Name = "txt_capa";
            this.txt_capa.ReadOnly = true;
            this.txt_capa.Size = new System.Drawing.Size(149, 19);
            this.txt_capa.TabIndex = 83;
            this.txt_capa.Text = "Capacitación";
            // 
            // txt_docDni
            // 
            this.txt_docDni.BackColor = System.Drawing.Color.White;
            this.txt_docDni.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_docDni.Enabled = false;
            this.txt_docDni.Location = new System.Drawing.Point(459, 125);
            this.txt_docDni.Name = "txt_docDni";
            this.txt_docDni.ReadOnly = true;
            this.txt_docDni.Size = new System.Drawing.Size(164, 19);
            this.txt_docDni.TabIndex = 84;
            this.txt_docDni.Text = "DNI";
            // 
            // foto_reporte
            // 
            this.foto_reporte.Image = ((System.Drawing.Image)(resources.GetObject("foto_reporte.Image")));
            this.foto_reporte.Location = new System.Drawing.Point(254, 97);
            this.foto_reporte.Name = "foto_reporte";
            this.foto_reporte.Size = new System.Drawing.Size(110, 110);
            this.foto_reporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.foto_reporte.TabIndex = 70;
            this.foto_reporte.TabStop = false;
            // 
            // txt_conductor
            // 
            this.txt_conductor.BackColor = System.Drawing.Color.White;
            this.txt_conductor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_conductor.Enabled = false;
            this.txt_conductor.Location = new System.Drawing.Point(459, 98);
            this.txt_conductor.Name = "txt_conductor";
            this.txt_conductor.ReadOnly = true;
            this.txt_conductor.Size = new System.Drawing.Size(164, 19);
            this.txt_conductor.TabIndex = 85;
            this.txt_conductor.Text = "Conductor";
            // 
            // lbl_kmRecorrido
            // 
            this.lbl_kmRecorrido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbl_kmRecorrido.Enabled = false;
            this.lbl_kmRecorrido.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbl_kmRecorrido.Location = new System.Drawing.Point(405, 229);
            this.lbl_kmRecorrido.Name = "lbl_kmRecorrido";
            this.lbl_kmRecorrido.Size = new System.Drawing.Size(217, 18);
            this.lbl_kmRecorrido.TabIndex = 26;
            this.lbl_kmRecorrido.Text = "KMs Recorridos";
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("btn_imprimir.Image")));
            this.btn_imprimir.Location = new System.Drawing.Point(715, 734);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(102, 106);
            this.btn_imprimir.TabIndex = 69;
            this.btn_imprimir.UseVisualStyleBackColor = true;
            this.btn_imprimir.Click += new System.EventHandler(this.btn_imprimir_Click);
            // 
            // txt_EstacionarDif
            // 
            this.txt_EstacionarDif.BackColor = System.Drawing.Color.White;
            this.txt_EstacionarDif.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_EstacionarDif.Enabled = false;
            this.txt_EstacionarDif.Location = new System.Drawing.Point(492, 788);
            this.txt_EstacionarDif.Name = "txt_EstacionarDif";
            this.txt_EstacionarDif.ReadOnly = true;
            this.txt_EstacionarDif.Size = new System.Drawing.Size(131, 19);
            this.txt_EstacionarDif.TabIndex = 82;
            this.txt_EstacionarDif.Text = "Estacionar Dif";
            // 
            // txt_estacionarFacil
            // 
            this.txt_estacionarFacil.BackColor = System.Drawing.Color.White;
            this.txt_estacionarFacil.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_estacionarFacil.Enabled = false;
            this.txt_estacionarFacil.Location = new System.Drawing.Point(492, 768);
            this.txt_estacionarFacil.Name = "txt_estacionarFacil";
            this.txt_estacionarFacil.ReadOnly = true;
            this.txt_estacionarFacil.Size = new System.Drawing.Size(131, 19);
            this.txt_estacionarFacil.TabIndex = 81;
            this.txt_estacionarFacil.Text = "Estacionar Facil";
            // 
            // txt_multaVelocidad
            // 
            this.txt_multaVelocidad.BackColor = System.Drawing.Color.White;
            this.txt_multaVelocidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_multaVelocidad.Enabled = false;
            this.txt_multaVelocidad.Location = new System.Drawing.Point(502, 704);
            this.txt_multaVelocidad.Name = "txt_multaVelocidad";
            this.txt_multaVelocidad.ReadOnly = true;
            this.txt_multaVelocidad.Size = new System.Drawing.Size(114, 19);
            this.txt_multaVelocidad.TabIndex = 80;
            this.txt_multaVelocidad.Text = "Multa de Velocidad";
            // 
            // txt_limitcamino
            // 
            this.txt_limitcamino.BackColor = System.Drawing.Color.White;
            this.txt_limitcamino.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_limitcamino.Enabled = false;
            this.txt_limitcamino.Location = new System.Drawing.Point(502, 684);
            this.txt_limitcamino.Name = "txt_limitcamino";
            this.txt_limitcamino.ReadOnly = true;
            this.txt_limitcamino.Size = new System.Drawing.Size(114, 19);
            this.txt_limitcamino.TabIndex = 79;
            this.txt_limitcamino.Text = "Limite Camino";
            // 
            // txt_choqueAutos
            // 
            this.txt_choqueAutos.BackColor = System.Drawing.Color.White;
            this.txt_choqueAutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_choqueAutos.Enabled = false;
            this.txt_choqueAutos.Location = new System.Drawing.Point(501, 665);
            this.txt_choqueAutos.Name = "txt_choqueAutos";
            this.txt_choqueAutos.ReadOnly = true;
            this.txt_choqueAutos.Size = new System.Drawing.Size(114, 19);
            this.txt_choqueAutos.TabIndex = 78;
            this.txt_choqueAutos.Text = "Choques de Autos";
            // 
            // txt_choques
            // 
            this.txt_choques.BackColor = System.Drawing.Color.White;
            this.txt_choques.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_choques.Enabled = false;
            this.txt_choques.Location = new System.Drawing.Point(502, 594);
            this.txt_choques.Name = "txt_choques";
            this.txt_choques.ReadOnly = true;
            this.txt_choques.Size = new System.Drawing.Size(114, 19);
            this.txt_choques.TabIndex = 77;
            this.txt_choques.Text = "Choques";
            // 
            // txt_fueracamino
            // 
            this.txt_fueracamino.BackColor = System.Drawing.Color.White;
            this.txt_fueracamino.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_fueracamino.Enabled = false;
            this.txt_fueracamino.Location = new System.Drawing.Point(503, 523);
            this.txt_fueracamino.Name = "txt_fueracamino";
            this.txt_fueracamino.ReadOnly = true;
            this.txt_fueracamino.Size = new System.Drawing.Size(114, 19);
            this.txt_fueracamino.TabIndex = 76;
            this.txt_fueracamino.Text = "Fuera de Camino";
            // 
            // txt_salidasFallidas
            // 
            this.txt_salidasFallidas.BackColor = System.Drawing.Color.White;
            this.txt_salidasFallidas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_salidasFallidas.Enabled = false;
            this.txt_salidasFallidas.Location = new System.Drawing.Point(503, 503);
            this.txt_salidasFallidas.Name = "txt_salidasFallidas";
            this.txt_salidasFallidas.ReadOnly = true;
            this.txt_salidasFallidas.Size = new System.Drawing.Size(114, 19);
            this.txt_salidasFallidas.TabIndex = 75;
            this.txt_salidasFallidas.Text = "Salidas Fallidas";
            // 
            // txt_infracciones
            // 
            this.txt_infracciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_infracciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_infracciones.Enabled = false;
            this.txt_infracciones.Location = new System.Drawing.Point(417, 291);
            this.txt_infracciones.Name = "txt_infracciones";
            this.txt_infracciones.ReadOnly = true;
            this.txt_infracciones.Size = new System.Drawing.Size(206, 19);
            this.txt_infracciones.TabIndex = 74;
            this.txt_infracciones.Text = "Infracciones";
            // 
            // txt_ltrsConsumidos
            // 
            this.txt_ltrsConsumidos.BackColor = System.Drawing.Color.White;
            this.txt_ltrsConsumidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ltrsConsumidos.Enabled = false;
            this.txt_ltrsConsumidos.Location = new System.Drawing.Point(432, 259);
            this.txt_ltrsConsumidos.Name = "txt_ltrsConsumidos";
            this.txt_ltrsConsumidos.ReadOnly = true;
            this.txt_ltrsConsumidos.Size = new System.Drawing.Size(191, 19);
            this.txt_ltrsConsumidos.TabIndex = 73;
            this.txt_ltrsConsumidos.Text = "Consumo Gasoil";
            // 
            // img_camionesManejados
            // 
            this.img_camionesManejados.Location = new System.Drawing.Point(240, 352);
            this.img_camionesManejados.Name = "img_camionesManejados";
            this.img_camionesManejados.Size = new System.Drawing.Size(377, 112);
            this.img_camionesManejados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img_camionesManejados.TabIndex = 71;
            this.img_camionesManejados.TabStop = false;
            // 
            // img_reporte
            // 
            this.img_reporte.BackColor = System.Drawing.Color.Transparent;
            this.img_reporte.Image = ((System.Drawing.Image)(resources.GetObject("img_reporte.Image")));
            this.img_reporte.Location = new System.Drawing.Point(10, 11);
            this.img_reporte.Name = "img_reporte";
            this.img_reporte.Size = new System.Drawing.Size(839, 865);
            this.img_reporte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img_reporte.TabIndex = 49;
            this.img_reporte.TabStop = false;
            this.img_reporte.Click += new System.EventHandler(this.img_reporte_Click);
            // 
            // layoutPanel
            // 
            this.layoutPanel.Controls.Add(this.tabControl1);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.layoutPanel.Location = new System.Drawing.Point(0, 24);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Size = new System.Drawing.Size(862, 933);
            this.layoutPanel.TabIndex = 3;
            // 
            // timerActualizarReporte
            // 
            this.timerActualizarReporte.Enabled = true;
            this.timerActualizarReporte.Interval = 3000;
            this.timerActualizarReporte.Tick += new System.EventHandler(this.timerActualizarReporte_Tick);
            // 
            // Interfaz_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(862, 979);
            this.Controls.Add(this.layoutPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Interfaz_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MIT Reporte (Vial Simulación)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.group_main.ResumeLayout(false);
            this.group_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_carnet)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupReporte.ResumeLayout(false);
            this.groupReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foto_reporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_camionesManejados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_reporte)).EndInit();
            this.layoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_archivo;
        private System.Windows.Forms.ToolStripMenuItem menu_imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menu_salir;
        private System.Windows.Forms.ToolStripMenuItem menu_config;
        private System.Windows.Forms.ToolStripMenuItem menu_ayuda;
        private System.Windows.Forms.ToolStripMenuItem menu_manual;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menu_contacto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menu_licencia;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox group_main;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Label lb_dni;
        private System.Windows.Forms.Label lb_Apellido;
        private System.Windows.Forms.Label lb_nombre;
        private System.Windows.Forms.ComboBox combo_capa;
        private System.Windows.Forms.PictureBox img_carnet;
        private System.Windows.Forms.TextBox txt_dni;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Button btn_carnet;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel layoutPanel;
        private System.Windows.Forms.ToolStripMenuItem serverMITEstadoSetup;
        private System.Windows.Forms.Label lbl_capacita;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timerActualizarReporte;
        private System.Windows.Forms.GroupBox groupReporte;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.TextBox txt_conductor;
        private System.Windows.Forms.TextBox txt_docDni;
        private System.Windows.Forms.TextBox txt_capa;
        public System.Windows.Forms.TextBox txt_EstacionarDif;
        public System.Windows.Forms.TextBox txt_estacionarFacil;
        public System.Windows.Forms.TextBox txt_multaVelocidad;
        public System.Windows.Forms.TextBox txt_limitcamino;
        public System.Windows.Forms.TextBox txt_choqueAutos;
        public System.Windows.Forms.TextBox txt_choques;
        public System.Windows.Forms.TextBox txt_fueracamino;
        public System.Windows.Forms.TextBox txt_salidasFallidas;
        public System.Windows.Forms.TextBox txt_infracciones;
        public System.Windows.Forms.TextBox txt_ltrsConsumidos;
        public System.Windows.Forms.PictureBox img_camionesManejados;
        private System.Windows.Forms.PictureBox foto_reporte;
        private System.Windows.Forms.PictureBox img_reporte;
        private System.Windows.Forms.Label lbl_kmRecorrido;
    }
}