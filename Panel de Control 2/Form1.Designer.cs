namespace Panel_de_Control_2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Titulo = new System.Windows.Forms.Label();
            this.LabelFecha = new System.Windows.Forms.Label();
            this.LabelHora = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aleatorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirAFavoritosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarTítuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarDimensionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsDeHoyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carpetaDeLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirBotónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alarmasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelInternet = new System.Windows.Forms.FlowLayoutPanel();
            this.labelInternet = new System.Windows.Forms.Label();
            this.labelProgramas = new System.Windows.Forms.Label();
            this.labelCarpetas = new System.Windows.Forms.Label();
            this.panelProgramas = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCarpetas = new System.Windows.Forms.FlowLayoutPanel();
            this.temporalpruebasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaNotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.Location = new System.Drawing.Point(366, 34);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(216, 31);
            this.Titulo.TabIndex = 0;
            this.Titulo.Text = "Panel de Control";
            this.Titulo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Titulo_MouseDoubleClick);
            // 
            // LabelFecha
            // 
            this.LabelFecha.AutoSize = true;
            this.LabelFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFecha.Location = new System.Drawing.Point(432, 65);
            this.LabelFecha.Name = "LabelFecha";
            this.LabelFecha.Size = new System.Drawing.Size(49, 18);
            this.LabelFecha.TabIndex = 1;
            this.LabelFecha.Text = "Fecha";
            // 
            // LabelHora
            // 
            this.LabelHora.AutoSize = true;
            this.LabelHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelHora.Location = new System.Drawing.Point(432, 83);
            this.LabelHora.Name = "LabelHora";
            this.LabelHora.Size = new System.Drawing.Size(41, 18);
            this.LabelHora.TabIndex = 2;
            this.LabelHora.Text = "Hora";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem,
            this.informaciónToolStripMenuItem,
            this.otrosToolStripMenuItem,
            this.alarmasToolStripMenuItem,
            this.notasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(937, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.cambiarTítuloToolStripMenuItem,
            this.guardarDimensionesToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.aleatorioToolStripMenuItem,
            this.añadirAFavoritosToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // aleatorioToolStripMenuItem
            // 
            this.aleatorioToolStripMenuItem.Name = "aleatorioToolStripMenuItem";
            this.aleatorioToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.aleatorioToolStripMenuItem.Text = "Aleatorio";
            this.aleatorioToolStripMenuItem.Click += new System.EventHandler(this.aleatorioToolStripMenuItem_Click);
            // 
            // añadirAFavoritosToolStripMenuItem
            // 
            this.añadirAFavoritosToolStripMenuItem.Name = "añadirAFavoritosToolStripMenuItem";
            this.añadirAFavoritosToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.añadirAFavoritosToolStripMenuItem.Text = "Añadir a favoritos";
            this.añadirAFavoritosToolStripMenuItem.Click += new System.EventHandler(this.añadirAFavoritosToolStripMenuItem_Click);
            // 
            // cambiarTítuloToolStripMenuItem
            // 
            this.cambiarTítuloToolStripMenuItem.Name = "cambiarTítuloToolStripMenuItem";
            this.cambiarTítuloToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cambiarTítuloToolStripMenuItem.Text = "Cambiar título";
            this.cambiarTítuloToolStripMenuItem.Click += new System.EventHandler(this.cambiarTítuloToolStripMenuItem_Click);
            // 
            // guardarDimensionesToolStripMenuItem
            // 
            this.guardarDimensionesToolStripMenuItem.Name = "guardarDimensionesToolStripMenuItem";
            this.guardarDimensionesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.guardarDimensionesToolStripMenuItem.Text = "Guardar dimensiones";
            this.guardarDimensionesToolStripMenuItem.Click += new System.EventHandler(this.guardarDimensionesToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // informaciónToolStripMenuItem
            // 
            this.informaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versiónToolStripMenuItem,
            this.logsToolStripMenuItem});
            this.informaciónToolStripMenuItem.Name = "informaciónToolStripMenuItem";
            this.informaciónToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.informaciónToolStripMenuItem.Text = "Información";
            // 
            // versiónToolStripMenuItem
            // 
            this.versiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versToolStripMenuItem});
            this.versiónToolStripMenuItem.Name = "versiónToolStripMenuItem";
            this.versiónToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.versiónToolStripMenuItem.Text = "Versión";
            // 
            // versToolStripMenuItem
            // 
            this.versToolStripMenuItem.Name = "versToolStripMenuItem";
            this.versToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.versToolStripMenuItem.Text = "vers";
            
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logsDeHoyToolStripMenuItem,
            this.carpetaDeLogsToolStripMenuItem});
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logsToolStripMenuItem.Text = "Logs";
            // 
            // logsDeHoyToolStripMenuItem
            // 
            this.logsDeHoyToolStripMenuItem.Name = "logsDeHoyToolStripMenuItem";
            this.logsDeHoyToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.logsDeHoyToolStripMenuItem.Text = "Logs de hoy";
            this.logsDeHoyToolStripMenuItem.Click += new System.EventHandler(this.logsDeHoyToolStripMenuItem_Click);
            // 
            // carpetaDeLogsToolStripMenuItem
            // 
            this.carpetaDeLogsToolStripMenuItem.Name = "carpetaDeLogsToolStripMenuItem";
            this.carpetaDeLogsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.carpetaDeLogsToolStripMenuItem.Text = "Carpeta de logs";
            this.carpetaDeLogsToolStripMenuItem.Click += new System.EventHandler(this.carpetaDeLogsToolStripMenuItem_Click);
            // 
            // otrosToolStripMenuItem
            // 
            this.otrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirBotónToolStripMenuItem,
            this.temporalpruebasToolStripMenuItem});
            this.otrosToolStripMenuItem.Name = "otrosToolStripMenuItem";
            this.otrosToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.otrosToolStripMenuItem.Text = "Otros";
            // 
            // añadirBotónToolStripMenuItem
            // 
            this.añadirBotónToolStripMenuItem.Name = "añadirBotónToolStripMenuItem";
            this.añadirBotónToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.añadirBotónToolStripMenuItem.Text = "Añadir Botón";
            this.añadirBotónToolStripMenuItem.Click += new System.EventHandler(this.añadirBotónToolStripMenuItem_Click);
            // 
            // alarmasToolStripMenuItem
            // 
            this.alarmasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaToolStripMenuItem});
            this.alarmasToolStripMenuItem.Name = "alarmasToolStripMenuItem";
            this.alarmasToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.alarmasToolStripMenuItem.Text = "Alarmas";
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.nuevaToolStripMenuItem.Text = "Nueva";
            this.nuevaToolStripMenuItem.Click += new System.EventHandler(this.nuevaToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelInternet
            // 
            this.panelInternet.Location = new System.Drawing.Point(13, 140);
            this.panelInternet.Name = "panelInternet";
            this.panelInternet.Size = new System.Drawing.Size(272, 399);
            this.panelInternet.TabIndex = 7;
            // 
            // labelInternet
            // 
            this.labelInternet.AutoSize = true;
            this.labelInternet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInternet.Location = new System.Drawing.Point(97, 113);
            this.labelInternet.Name = "labelInternet";
            this.labelInternet.Size = new System.Drawing.Size(80, 24);
            this.labelInternet.TabIndex = 8;
            this.labelInternet.Text = "Internet";
            this.labelInternet.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelInternet_MouseDoubleClick);
            // 
            // labelProgramas
            // 
            this.labelProgramas.AutoSize = true;
            this.labelProgramas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgramas.Location = new System.Drawing.Point(416, 113);
            this.labelProgramas.Name = "labelProgramas";
            this.labelProgramas.Size = new System.Drawing.Size(110, 24);
            this.labelProgramas.TabIndex = 8;
            this.labelProgramas.Text = "Programas";
            this.labelProgramas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelProgramas_MouseDoubleClick);
            // 
            // labelCarpetas
            // 
            this.labelCarpetas.AutoSize = true;
            this.labelCarpetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCarpetas.Location = new System.Drawing.Point(742, 113);
            this.labelCarpetas.Name = "labelCarpetas";
            this.labelCarpetas.Size = new System.Drawing.Size(92, 24);
            this.labelCarpetas.TabIndex = 8;
            this.labelCarpetas.Text = "Carpetas";
            this.labelCarpetas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.labelCarpetas_MouseDoubleClick);
            // 
            // panelProgramas
            // 
            this.panelProgramas.Location = new System.Drawing.Point(349, 140);
            this.panelProgramas.Name = "panelProgramas";
            this.panelProgramas.Size = new System.Drawing.Size(258, 399);
            this.panelProgramas.TabIndex = 9;
            // 
            // panelCarpetas
            // 
            this.panelCarpetas.Location = new System.Drawing.Point(673, 140);
            this.panelCarpetas.Name = "panelCarpetas";
            this.panelCarpetas.Size = new System.Drawing.Size(228, 399);
            this.panelCarpetas.TabIndex = 10;
            // 
            // temporalpruebasToolStripMenuItem
            // 
            this.temporalpruebasToolStripMenuItem.Name = "temporalpruebasToolStripMenuItem";
            this.temporalpruebasToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.temporalpruebasToolStripMenuItem.Text = "temporal-pruebas";
            this.temporalpruebasToolStripMenuItem.Click += new System.EventHandler(this.temporalpruebasToolStripMenuItem_Click);
            // 
            // notasToolStripMenuItem
            // 
            this.notasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaNotaToolStripMenuItem});
            this.notasToolStripMenuItem.Name = "notasToolStripMenuItem";
            this.notasToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.notasToolStripMenuItem.Text = "Notas";
            // 
            // nuevaNotaToolStripMenuItem
            // 
            this.nuevaNotaToolStripMenuItem.Name = "nuevaNotaToolStripMenuItem";
            this.nuevaNotaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevaNotaToolStripMenuItem.Text = "Nueva nota";
            this.nuevaNotaToolStripMenuItem.Click += new System.EventHandler(this.nuevaNotaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 564);
            this.Controls.Add(this.panelCarpetas);
            this.Controls.Add(this.panelProgramas);
            this.Controls.Add(this.labelProgramas);
            this.Controls.Add(this.labelCarpetas);
            this.Controls.Add(this.labelInternet);
            this.Controls.Add(this.panelInternet);
            this.Controls.Add(this.LabelHora);
            this.Controls.Add(this.LabelFecha);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Control 2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Label LabelFecha;
        private System.Windows.Forms.Label LabelHora;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem informaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel panelInternet;
        private System.Windows.Forms.Label labelInternet;
        private System.Windows.Forms.Label labelProgramas;
        private System.Windows.Forms.Label labelCarpetas;
        private System.Windows.Forms.FlowLayoutPanel panelProgramas;
        private System.Windows.Forms.FlowLayoutPanel panelCarpetas;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aleatorioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarTítuloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsDeHoyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carpetaDeLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirBotónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirAFavoritosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarDimensionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alarmasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temporalpruebasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaNotaToolStripMenuItem;
    }
}

