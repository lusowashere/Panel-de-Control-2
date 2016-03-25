using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Panel_de_Control_2
{
    public partial class Form1 : Form
    {
        LectorTeclasPulsadas teclasQuePulsanBoton;//teclas que al pulsarse activan un botón
        ListaColores listaDeColores;
        textBoxGoogle buscarEnGoogle;
        AddBotones botonesContextuales;
        Version version;
        ListaAlarmas listaDeAlarmas;
        ListaDeNotas listaDeNotas;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e) //el botón cerrar del archivo de siempre
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)//contador
        {
            LabelFecha.Text = fechaYhora.fechaDeHoy();//poner la fecha de hoy
            LabelHora.Text = fechaYhora.horaEscrita();

            if (LabelHora.Text.Substring(3, 5) == "00:00") //cosas que pasan a en punto
            { 
                logs.addToLog("Comprobación horaria, el programa sigue abierto");
                listaDeAlarmas.comprobarCaducados();
                System.Threading.Thread.Sleep(1000);
            }

            posicionarYajustarControles();

            listaDeAlarmas.comprobarAlarmas();

            
        }

        private void Form1_Load(object sender, EventArgs e)//lo que se hace cuando se inicia el programa
        {
            versToolStripMenuItem.Text = "2.6.2";

            version = new Version(versToolStripMenuItem);
                        
            version.addVersion("2.0", "5/1/16", "Se empieza la versión en C#");
            version.addVersion("2.1", "6/1/16", "Se crean los botones");
            version.addVersion("2.2", "7/1/16", "Se cambia el color y se guarda y se lee");
            version.addVersion("2.3", "8/1/16", "Se añade el textboxGoogle");
            version.addVersion("2.4", "9/1/16", "Se crean las listas desplegables y la opción de cambiar el título.");
            version.addVersion("2.5", "11/1/16", "Se crean los logs");
            version.addVersion("2.5.2", "12/1/16", "Se finalizan los logs");
            version.addVersion("2.6", "18/1/16", "Se agrega la opción de añadir botones, pulidos los colores y se puede guardar el tamaño");
            version.addVersion("2.6.2", "22/1/16", "Se añaden un par de logs");
            version.addVersion("2.6.3", "30/1/16", "Se añade el enlace al recopilatorio de acordes y la  opción de añadir texto a los logs");
            version.addVersion("2.7", "31/1/16", "Se crean las alarmas");
            version.addVersion("2.7.2", "2/2/16", "Se añade sonido a las alarmas y se mejoran los logs de estas");
            version.addVersion("2.7.3", "13/2/16", "Se añade la posibilidad de aplazar las alarmas");
            version.addVersion("2.8", "13/2/16", "Se añaden las notas");
            version.addVersion("2.8.1", "9/3/16", "Las notas piden confirmación para eliminar. Otros ajustes");
            version.addVersion("2.8.2", "19/3/16", "Los comboBox comprueban si existe la carpeta. Arreglado que no se guarden las notas");
            version.addVersion("2.8.3", "25/3/16", "Las notas se pueden dejar abiertas y se guardan. Mejorado el histórico de versiones. Se cierra después de ejecutar visual studio");

            //esto se hace al arrancar para que quede más bonito
            LabelFecha.Text = fechaYhora.fechaDeHoy();//poner la fecha de hoy
            LabelHora.Text = fechaYhora.horaEscrita();

            //this.Icon = Panel_de_Control_2.Properties.Resources.icono;
            
            //leer el tamaño por si fuera distinto
            this.Height = sizeFormulario.leerLargo(this.Height);
            this.Width = sizeFormulario.leerAncho(this.Width);
            this.SetDesktopLocation(sizeFormulario.leerX(this.DesktopLocation.X),sizeFormulario.leerY(this.DesktopLocation.Y));


            //centrar las labels
            posicionarYajustarControles();

            logs.addToLog("Abierto panel de control 2 \r\n");

            //declarar lista de colores
            listaDeColores = new ListaColores(colorToolStripMenuItem);
            listaDeColores.addFormularioOrigen(this);

            //leer el color
            cambiarColor(listaDeColores.leerColor());

            //declarar la lista de teclas que pulsan botón
            teclasQuePulsanBoton = new LectorTeclasPulsadas();

            botonTodo botonDeTodo = new botonTodo("TODO", panelInternet);
            botonDeTodo.addTooltip("(T)Gmail, Whatsapp y Facebook");
            teclasQuePulsanBoton.addBotonTodo(botonDeTodo, Keys.T);
            botonDeTodo.color(Color.LightYellow);
            
            //declaración de los botones de internet

            botonInternet gmail = new botonInternet("", "www.gmail.com", panelInternet,Color.White);
            gmail.addImagen(Panel_de_Control_2.Properties.Resources.iconoGmail);
            teclasQuePulsanBoton.addBoton(gmail, Keys.G);
            gmail.addTooltip("(g)");
            gmail.logDelBoton("abierto Gmail");
                      
            
            botonInternet whatsapp = new botonInternet("", "https://web.whatsapp.com/", panelInternet,"(w) lleva a la página de whatsapp web");
            whatsapp.addImagen(Panel_de_Control_2.Properties.Resources.iconoWhatsapp);
            whatsapp.color(Color.LightGray);
            teclasQuePulsanBoton.addBoton(whatsapp, Keys.W);
            whatsapp.logDelBoton("Abierto whatsapp");

            botonInternet facebook = new botonInternet("", "www.facebook.com", panelInternet, Color.White);
            facebook.addImagen(Panel_de_Control_2.Properties.Resources.iconoFacebook);
            teclasQuePulsanBoton.addBoton(facebook, Keys.F);
            facebook.addTooltip("(f)");
            facebook.logDelBoton("Abierto facebook");

            buscarEnGoogle = new textBoxGoogle(panelInternet);

            botonInternet pirateBay = new botonInternet("", "https://pirateproxy.sx/", panelInternet, "(p) Lleva a la página principal de pirateBay  \nClick derecho para buscar en piratebay");
            pirateBay.addImagen(Panel_de_Control_2.Properties.Resources.iconoPiratebay);
            teclasQuePulsanBoton.addBoton(pirateBay, Keys.P);
            pirateBay.color(Color.White);
            pirateBay.AddMenuContextualPiratebay("Buscar en pirateBay");
            pirateBay.logDelBoton("Abierto piratebay");

            botonInternet youTube = new botonInternet("", "https://www.youtube.com/playlist?list=FL8FPnv2i7TQA8A9cI5F1pOQ", panelInternet, "(y) Lleva a la lista de favoritos de Luso");
            youTube.addImagen(Panel_de_Control_2.Properties.Resources.imagenYoutube);
            teclasQuePulsanBoton.addBoton(facebook, Keys.Y);
            youTube.color(Color.LightGray);
            youTube.logDelBoton("Abierto youtube");

            botonInternet drive = new botonInternet("", "https://drive.google.com/drive/#starred", panelInternet, Color.White);
            drive.addTooltip("(d) Lleva a la carpeta de favoritos de Drive");
            drive.addImagen(Panel_de_Control_2.Properties.Resources.imagenDrive);
            teclasQuePulsanBoton.addBoton(drive, Keys.D);
            drive.logDelBoton("Abierto drive");

            botonInternet imdb = new botonInternet("", "www.imdb.com", panelInternet);
            imdb.addImagen(Panel_de_Control_2.Properties.Resources.imagenImdb);
            imdb.color(Color.LightGray);
            imdb.logDelBoton("Abierto IMDB");


            botonInternet wikipedia = new botonInternet("", "https://es.wikipedia.org/wiki/Wikipedia:Portada", panelInternet, "Wikipedia \nClick derecho para buscar en wikipedia");
            wikipedia.addImagen(Panel_de_Control_2.Properties.Resources.imagenWikipedia);
            wikipedia.color(Color.White);
            wikipedia.addMenuContextualWikipedia("Buscar en wikipedia");
            wikipedia.logDelBoton("Abierto wikipedia");

            


            //programas
            botonInternet word=new botonInternet("",@"C:\Program Files\Microsoft Office\root\Office16\WINWORD.exe",panelProgramas,Color.White);
            word.addImagen(Panel_de_Control_2.Properties.Resources.imagenWord);
            word.logDelBoton("Abierto word");
            word.addTooltip("Microsoft Word");
            word.esProgramas();

            botonInternet excel = new botonInternet("", @"C:\Program Files\Microsoft Office\root\Office16\EXCEL.exe", panelProgramas,Color.White);
            excel.addImagen(Panel_de_Control_2.Properties.Resources.imagenExcel);
            excel.addTooltip("(x) Microsoft Excel");
            teclasQuePulsanBoton.addBoton(excel, Keys.X);
            excel.logDelBoton("Abierto excel");
            excel.esProgramas();

            botonInternet notepad = new botonInternet("", @"c:\Windows\System32\notepad.exe", panelProgramas,Color.White);
            notepad.addImagen(Panel_de_Control_2.Properties.Resources.imagenNotepad);
            notepad.addTooltip("(n) Bloc de notas \n click derecho para notepad++");
            teclasQuePulsanBoton.addBoton(notepad, Keys.N);
            notepad.addMenuContextualNotepadPP("Notepad ++");
            notepad.logDelBoton("Abierto notepad");
            notepad.esProgramas();

            botonInternet programaDropbox = new botonInternet("", @"C:\Program Files (x86)\Dropbox\Client\Dropbox.exe", panelProgramas,"Ejecuta el programa dropbox");
            programaDropbox.addImagen(Panel_de_Control_2.Properties.Resources.imagenDropbox);
            programaDropbox.color(Color.White);
            programaDropbox.logDelBoton("Iniciado dropbox");
            programaDropbox.addTooltip("Ejecuta dropbox");
            programaDropbox.esProgramas();

            botonInternet minecraft = new botonInternet("", @"C:\Program Files (x86)\Minecraft\MinecraftLauncher.exe", panelProgramas,Color.White);
            minecraft.addImagen(Panel_de_Control_2.Properties.Resources.imagenMinecraft);
            minecraft.logDelBoton("Abierto minecraft");
            minecraft.addTooltip("minecraft");
            minecraft.esProgramas();

            botonInternet visualStudio = new botonInternet("", @"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\devenv.exe", panelProgramas, Color.White);
            visualStudio.addImagen(Panel_de_Control_2.Properties.Resources.imagenVisualStudio);
            visualStudio.logDelBoton("Abierto visual Studio");
            visualStudio.addTooltip("Visual studio");
            minecraft.esProgramas();
            visualStudio.cerrarDespuesDePresionar(true, this);//habitualmente abro visualStudio para cambiar el panel de control, así que he añadido esto para que lo cierre

            //carpetas

            botonInternet luso = new botonInternet("Luso       ", @"C:\luso", panelCarpetas);
            luso.esCarpetas();
            luso.alineacion(ContentAlignment.MiddleRight);
            luso.addImagen(Panel_de_Control_2.Properties.Resources.imagenCarpeta);
            luso.color(Color.LightGray);
            luso.logDelBoton("Abierta carpeta luso");
            luso.esCarpetas();
            

            ListaDesplegableCarpeta carpetaDescargas = new ListaDesplegableCarpeta(@"C:\luso\descargas",panelCarpetas, "descargas");
            ListaDesplegableCarpeta carpetaDropbox = new ListaDesplegableCarpeta(@"C:\luso\dropbox", panelCarpetas, "dropbox");

            
            //leer el título
            Titulo.Text = formularioEntradaTexto.leerTitulo();

            listaDeColores.toolstripAdd();

            posicionarYajustarControles();

            botonesContextuales = new AddBotones(labelInternet, labelProgramas, labelCarpetas);
            botonesContextuales.leerBotones();
            añadirBotónToolStripMenuItem.ToolTipText = "Añadir un botón al menú contextual que aparecerá al hacer click derecho sobre los letreros de \"carpetas\", \"programas\" o \"internet\"";


            //botón de enlace a acordes
            //BotonContextual botonAcordes = new BotonContextual("Recopilatorio", @"C:\luso\Dropbox\partituras\RecopilatorioIV.docx", otrosToolStripMenuItem);


            //alarmas
            listaDeAlarmas = new ListaAlarmas(alarmasToolStripMenuItem);
            listaDeAlarmas.cargarAlarmas();


            //notas
            listaDeNotas = new ListaDeNotas(notasToolStripMenuItem);
            listaDeNotas.leerNotas();

            temporalpruebasToolStripMenuItem.Visible = false;//este es un botón que utilizo para hacer pruebas

        }//fin de la función Form1_Load

        public void posicionarYajustarControles() //ajusta el tamaño cada segundo
        {
            //centrar las labels
            Titulo.Left = Convert.ToInt32((this.Width / 2) - (Titulo.Width / 2));
            LabelFecha.Left = Convert.ToInt32((this.Width / 2) - (LabelFecha.Width / 2));
            LabelHora.Left = Convert.ToInt32((this.Width / 2) - (LabelHora.Width / 2));
            
            //hacer los paneles del ancho adecuado
            int anchoPaneles,borde;
            double porcentaje=28;//cuanto del ancho mide cada panel
           
            
            anchoPaneles = Convert.ToInt32( (porcentaje*this.Width)/100);
            borde =Convert.ToInt32( (this.Width - anchoPaneles * 3) / 4);
            panelInternet.Width = anchoPaneles;
            panelCarpetas.Width = anchoPaneles;
            panelProgramas.Width = anchoPaneles;

            //posicionar los paneles horizontalmente
            panelProgramas.Left = Convert.ToInt32((this.Width / 2) - (panelProgramas.Width / 2));//centrado
            panelInternet.Left = borde;
            panelCarpetas.Left = this.Width - panelCarpetas.Width - borde;

            //posicionar los rótulos
            labelInternet.Left=panelInternet.Left+(panelInternet.Width/2)-(labelInternet.Width/2);
            labelProgramas.Left = panelProgramas.Left + (panelProgramas.Width / 2) - (labelProgramas.Width / 2);
            labelCarpetas.Left = panelCarpetas.Left + (panelCarpetas.Width / 2) - (labelCarpetas.Width / 2);
        
            //ahora vamos a ajustar la altura de los paneles
            int parteSuperiorPaneles = panelInternet.Top;//para mantener constante la distancia de la punta
            int alturaPaneles;

            alturaPaneles = Convert.ToInt32(0.95*( this.Height - parteSuperiorPaneles - borde));
            panelInternet.Height = alturaPaneles;
            panelProgramas.Height = alturaPaneles;
            panelCarpetas.Height = alturaPaneles;

            //quiero ajustar la altura de los botones
            int numeroBotonesInternet = panelInternet.Controls.Count;
            int numeroBotonesProgramas = panelProgramas.Controls.Count;
            int numeroBotonesCarpetas = panelCarpetas.Controls.Count;
            int alturaBotones, numeroBotones;

            numeroBotones = Math.Max(numeroBotonesInternet, Math.Max(numeroBotonesCarpetas,numeroBotonesProgramas));

            if (numeroBotones == 0) { numeroBotones = 1; }//para evitar la primera división entre 0

            alturaBotones = Convert.ToInt32(0.9*alturaPaneles / numeroBotones);

            foreach (Control ctrl in panelInternet.Controls)//ajusta el ancho de los botones de internet
            {
                ctrl.Width = Convert.ToInt32(anchoPaneles*0.99);
                ctrl.Height = alturaBotones;
            }

            foreach(Control ctrlC in panelCarpetas.Controls)//ajusta el ancho de los botones de la carpeta
            {
                ctrlC.Width=Convert.ToInt32(anchoPaneles*0.99);
                ctrlC.Height = alturaBotones;
            }

            foreach (Control ctrlP in panelProgramas.Controls)//ajusta el ancho de los botones de los programas
            {
                ctrlP.Width = Convert.ToInt32(anchoPaneles * 0.99);
                ctrlP.Height = alturaBotones;
            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys teclaPulsada = e.KeyCode;

            if (!buscarEnGoogle.selected())
            {//si estamos escribiendo en la  textbox no se busca

                Boolean pulsado = teclasQuePulsanBoton.comprobarTecla(teclaPulsada);

                if (!pulsado)
                {//se comprueban otras teclas
                    switch (teclaPulsada)
                    {
                        case Keys.Escape:
                            this.Close();
                            break;

                        case Keys.C:
                            cambiarColor(listaDeColores.siguienteColor());
                            break;
                        case Keys.B:
                            buscarEnGoogle.select();
                            break;
                        case Keys.S: //para probar cosas
                            listaDeColores.guardarColor(Color.Black);
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (teclaPulsada == Keys.Escape)
            {
                Titulo.Focus();
            }
        }

        public void cambiarColor(Color colorNuevo)//pinta las partes necesarias del color solicitado
        {
            logs.addToLog("Cambiado color a " + colorNuevo.ToString());
            this.BackColor = colorNuevo;
            panelCarpetas.BackColor = colorNuevo;
            panelInternet.BackColor = colorNuevo;
            panelProgramas.BackColor = colorNuevo;
            listaDeColores.guardarColor(colorNuevo);
        }

        private void aleatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logs.addToLog("Elegido color aleatorio");
            cambiarColor(listaDeColores.colorAleatorio());
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cambiarColor(listaDeColores.seleccionarColor(this.BackColor));
        }

        private void cambiarTítuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formularioEntradaTexto cambiarTitulo = new formularioEntradaTexto("Cambiar título", "Nuevo título");
            logs.addToLog("Abierta ventana de cambiar título");
            cambiarTitulo.mostrarFormulario();

            if (cambiarTitulo.getText() != "")
            {
                Titulo.Text = cambiarTitulo.getText();

                cambiarTitulo.guardarTitulo(Titulo.Text);
                logs.addToLog("Cambiado título a "+Titulo.Text);
            }
        }

        private void logsDeHoyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logs lg=new logs();
            lg.showFormulario();
        }

        private void carpetaDeLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(logs.rutaDeLosLogs());
        }

        private void añadirBotónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botonesContextuales.addBotonConFormulario();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            logs.addToLog("Se cierra el panel de control 2");
        }

        private void añadirAFavoritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaDeColores.addColorLista(this.BackColor);
            
        }

        private void Titulo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MouseEventArgs mEA = new MouseEventArgs(MouseButtons.Left, 1, 10, 10, 0);
            cambiarTítuloToolStripMenuItem_Click(this, mEA);
        }

        private void labelInternet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            botonesContextuales.tipoDeBoton(1);
            botonesContextuales.addBotonConFormulario();
        }

        private void labelProgramas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            botonesContextuales.tipoDeBoton(2);
            botonesContextuales.addBotonConFormulario();
        }

        private void labelCarpetas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            botonesContextuales.tipoDeBoton(3);
            botonesContextuales.addBotonConFormulario();
        }

        private void guardarDimensionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sizeFormulario.guardarSize(this.Height, this.Width,this.DesktopLocation.X,this.DesktopLocation.Y);
            logs.addToLog("dimensiones guardadas");
        }

        

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaDeAlarmas.mostrarFormulario();
        }

        /// <summary>
        /// Botón que utilizo para hacer pruebas. Normalmente está deshabilitado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void temporalpruebasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaDesplegableCarpeta comboBoxPrueba = new ListaDesplegableCarpeta(@"C:\luso\patatas",panelCarpetas,"prueba");
        }

        private void nuevaNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listaDeNotas.addNotaFormulario();
        }



    }//fin de la clase form1

    
}


