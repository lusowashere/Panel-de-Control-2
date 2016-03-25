using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Windows;

namespace Panel_de_Control_2
{
    class FuncionesAux
    {
        /// <summary>
        /// Cuenta la cantidad de veces que un caracter aparece en una cadena
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="caracter"></param>
        /// <returns></returns>
        public static int contar(String cadena, char caracter)
        {
            int aux = 0;
            

            foreach (char letra in cadena)
            {
                if (letra == caracter) { aux++; }
            }

            
            return aux;
        }
    }
     
    /// <summary>
    /// agrupa funciones relativas a la fecha y la hora
    /// </summary>
    public class fechaYhora //
    {

        public static string fechaDeHoy() //devuelve un string con el día de la semana en castellano, el día del mes y el año
        {
            String fechaFinal, diaDeLaSemana, mes;
            DayOfWeek diaDeLaSemanaInt;
            int mesInt;
            

            diaDeLaSemanaInt = DateTime.Today.DayOfWeek;

            switch (diaDeLaSemanaInt)
            {
                case DayOfWeek.Monday:
                    diaDeLaSemana = "Lunes";
                    break;
                case DayOfWeek.Tuesday:
                    diaDeLaSemana="Martes";
                    break;
                case DayOfWeek.Wednesday:
                    diaDeLaSemana="Miércoles";
                    break;
                case DayOfWeek.Thursday:
                    diaDeLaSemana="Jueves";
                    break;
                case DayOfWeek.Friday:
                    diaDeLaSemana="Viernes";
                    break;
                case DayOfWeek.Saturday:
                    diaDeLaSemana = "Sábado";
                    break;
                case DayOfWeek.Sunday:
                    diaDeLaSemana = "Domindo";
                    break;

                default:
                    return "Fallo al obtener el día de la semana";
                    
            }

            mesInt=DateTime.Today.Month;

            switch (mesInt)
	        {
                case 1:
                    mes="Enero";
                    break;
                case 2:
                    mes="Febrero";
                    break;
                case 3:
                    mes="Marzo";
                    break;
                case 4:
                    mes="Abril";
                    break;
                case 5:
                    mes="Mayo";
                    break;
                case 6:
                    mes="Junio";
                    break;
                case 7:
                    mes="Julio";
                    break;
                case 8:
                    mes="Agosto";
                    break;
                case 9:
                    mes="Septiembre";
                    break;
                case 10:
                    mes="Octubre";
                    break;
                case 11:
                    mes="Noviembre";
                    break;
                case 12:
                    mes="Diciembre";
                    break;
		        default:
                    return "No se ha podido encontrar el nombre del mes2";
 
	        }

            fechaFinal = diaDeLaSemana + ", " + DateTime.Today.Day + " de " + mes + " de " + DateTime.Today.Year;
            return fechaFinal;


        }//fin de la función FechaDeHoy

        public static string horaEscrita()//devuelve la hora actual en formato hh:mm:ss
        {
            String hh, mm, ss;

            hh = ponerCeros(DateTime.Now.Hour.ToString());
            mm = ponerCeros(DateTime.Now.Minute.ToString());
            ss = ponerCeros(DateTime.Now.Second.ToString());

            return hh + ":" + mm + ":" + ss;                     

        }//fin de la función horaEscrita

        /// <summary>
        /// al igual que en el primer controlPanel, si un número tiene una sola cifra, le añade un cero antes
        /// </summary>
        /// <param name="numero">cadena de texto de número a analizar</param>
        /// <returns></returns>
        public static string ponerCeros(String numero) 
        {
            if(numero.Length==2){
                return numero;
            }
            else if (numero.Length == 1)
            {
                return "0" + numero;
            }
            else { return "Err"; }//el número tiene más de dos cifras
        }//fin de la función ponerCeros

        public static string ristraFechaActual()//devuelve una cadena de forma yyyymmdd
        {
            string ristra;
            ristra = DateTime.Today.Year.ToString();
            ristra = ristra + ponerCeros( DateTime.Today.Month.ToString());
            ristra = ristra + ponerCeros(DateTime.Today.Day.ToString());

            return ristra;
        }//fin de la función ristraFechaActual

        public static string fechaCortaDeHoy()
        {
            string fecha;
            fecha = DateTime.Today.Day.ToString();
            fecha = fecha + "/" + DateTime.Today.Month.ToString();
            fecha = fecha + "/" + DateTime.Today.Year.ToString();

            return fecha;
        }


        public static string ristraActual()//devuelve una cadena de forma yyyymmddhhmmss del momento actual
        {
            string yyyy, MM, dd, hh, mm, ss;
            yyyy = DateTime.Today.Year.ToString();
            MM = ponerCeros(DateTime.Today.Month.ToString());
            dd = ponerCeros(DateTime.Today.Day.ToString());
            hh = ponerCeros(DateTime.Now.Hour.ToString());
            mm = ponerCeros(DateTime.Now.Minute.ToString());
            ss = ponerCeros(DateTime.Now.Second.ToString());

            return yyyy + MM + dd + hh + mm + ss;
            
        }//fin de la función ristraActual

        public static string horaEscritaDesdeRistra(string ristra)//devuelve la hora de la ristra en formato hh:mm:ss
        {
            String hh, mm, ss;

            hh = ristra.Substring(8,2);
            mm = ristra.Substring(10,2);
            ss = ristra.Substring(12,2);

            return hh + ":" + mm + ":" + ss;

        }//fin de la función horaEscritaDesdeRistra

        public static string fechaCortaDesdeRistra(string ristra)
        {
            string fecha;
            fecha = ristra.Substring(6, 2);
            fecha = fecha + "/" + ristra.Substring(4,2);
            fecha = fecha + "/" + ristra.Substring(0,4);

            return fecha;
        }

        public static string validarHora(String hora)//devuelve los últimos seis dígitos de la ristra si el string introducido tiene forma de hh:mm:ss o de hh:mm. Si no, devuelve""
        {
            if (hora.Length == 8)//debería tener forma de "hh:mm:ss"
            {
                if((hora.Substring(2,1)==":")&&(hora.Substring(5,1)==":"))//los separadores son correctos
                {
                    int hh, mm, ss;
                    string h, m, s;
                    h=hora.Substring(0, 2);
                    m=hora.Substring(3, 2);
                    s=hora.Substring(6, 2);
                    hh = Convert.ToInt32(h);
                    mm = Convert.ToInt32(m);
                    ss = Convert.ToInt32(s);

                    if (hh < 24 && hh >= 0 && mm < 60 && mm >= 0 && ss < 60 && ss >= 0)//el formato está bien
                    {
                        return h + m + s;
                    }
                    

                }
            }
            else if (hora.Length == 5)//debería tener forma de hh:mm
            {
                if (hora.Substring(2, 1) == ":")//los separadores son correctos
                {
                    int hh, mm;
                    string h, m;
                    h = hora.Substring(0, 2);
                    m = hora.Substring(3, 2);
                    
                    hh = Convert.ToInt32(h);
                    mm = Convert.ToInt32(m);
                    

                    if (hh < 24 && hh >= 0 && mm < 60 && mm >= 0 )//el formato está bien
                    {
                        return h + m + "00";//le añade los segundos
                    }

                }
            }


            MessageBox.Show("El formato de fecha es erróneo");
            return "";
        }

        /// <summary>
        /// Añade una cantidad de minutos a la hora representada por la ristra. Devuelve la nueva ristra
        /// </summary>
        /// <param name="minutos">minutos a añadir a la ristra</param>
        /// <param name="ristra">ristra original</param>
        /// <returns></returns>
        public static string addMinutosARistra(string ristra, int minutosAsumar)
        {
            string ristraNueva=ristra;

            //primero averiguamos los dias, minutos y horas que representa cada cosa
            string dd = ristra.Substring(6, 2);
            string hh = ristra.Substring(8, 2);
            string mm = ristra.Substring(10, 2);
            string ss = ristra.Substring(12, 2);

            int dia = Convert.ToInt32(dd);
            int hora = Convert.ToInt32(hh);
            int minutos = Convert.ToInt32(mm);
            //int segundos = Convert.ToInt32(ss);//esto no hace falta porque no se suman ni nada

            int minutosSumados = minutosAsumar + minutos;

            if (minutosSumados >= 60)//hay que añadir horas
            {
                int horasAsumar = minutosSumados / 60;
                hora = hora + horasAsumar;
                minutosSumados = minutosSumados % 60;
                
            }

            if (hora >= 24)//hay que añadir días
            {
                int diasAsumar = hora / 24;
                dia = dia + diasAsumar;
                hora = hora % 24;

            }

            //mas allá no lo hago porque cada mes tiene días distintos. Espero que nadie postponga tanto una alarma
            dd = ponerCeros(Convert.ToString(dia));
            hh = ponerCeros(Convert.ToString(hora));
            mm = ponerCeros(Convert.ToString(minutosSumados));

            ristraNueva = ristra.Substring(0, 6) + dd + hh + mm + ss;
           

            return ristraNueva;
        }

    }//fin de la clase fechayHora

    
            

    public class botonInternet //clase que se utiliza para crear los botones 
    {
        Button boton;
        string rutaInternet, textoBoton, TextoTooltip,log;
        Image imagenBoton;
        Boolean esBotonProgramas,esBotonCarpetas,cerrarDespuesDeApretar;
        ContextMenuStrip menuContextualPb;
        Form formularioInicial;//por si se quiere cerrar después de darle a un botón

        

        public botonInternet(String texto, String ruta, Panel contenedor)//primera declaración. Un botón con una ruta, el texto y el contenedor
        {
            boton = new Button();
            rutaInternet = ruta;
            textoBoton = texto;
            boton.Text = textoBoton;
            
            
            boton.Click += new EventHandler(botonInternet_Click);
            contenedor.Controls.Add(boton);

            boton.Width = Convert.ToInt32(0.99*contenedor.Width);
            boton.Height = contenedor.Height / 10;

            esBotonCarpetas=false; //por defecto son de internet
            esBotonProgramas=false;
            cerrarDespuesDeApretar = false;

            log="";

        }//fin de la primera declaración de botonInternet

        public botonInternet(String texto, String ruta, Panel contenedor, String txtooltip)//segunda declaración. Un botón con una ruta, el texto y el contenedor
        {
            boton = new Button();
            rutaInternet = ruta;
            textoBoton = texto;
            boton.Text = textoBoton;
            ToolTip tltip = new ToolTip();
            tltip.SetToolTip(boton, txtooltip);

            boton.Click += new EventHandler(botonInternet_Click);
            contenedor.Controls.Add(boton);

            boton.Width = Convert.ToInt32(0.99 * contenedor.Width);
            boton.Height = contenedor.Height / 10;

            esBotonCarpetas=false; //por defecto son de internet
            esBotonProgramas=false;
            log="";

        }//fin de la segunda declaración de botonInternet

        public botonInternet(String texto, String ruta, Panel contenedor,Color colorDelBoton)//tecera declaración. Un botón con una ruta, el texto, el contenedor y el color del fondo
        {
            boton = new Button();
            rutaInternet = ruta;
            textoBoton = texto;
            boton.Text = textoBoton;
            boton.BackColor = colorDelBoton;

            boton.Click += new EventHandler(botonInternet_Click);
            contenedor.Controls.Add(boton);

            boton.Width = Convert.ToInt32(0.99 * contenedor.Width);
            boton.Height = contenedor.Height / 10;

            esBotonCarpetas=false; //por defecto son de internet
            esBotonProgramas=false; 
            log="";

        }//fin de la tercera declaración de botonInternet

        /// <summary>
        /// lo que ocurre cuando le das al botón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void botonInternet_Click(object sender, EventArgs e)
        {
            if (esBotonProgramas)
            {
                if(File.Exists(rutaInternet)){
                    System.Diagnostics.Process.Start(rutaInternet);//es el mismo que el de abajo, pero no se si hay que hacerlo distinto o añadir algo
                }else{MessageBox.Show("La ruta del programa es incorrecta: \n \""+rutaInternet+"\"");}
            }
            else if (esBotonCarpetas)
            {
                if(Directory.Exists(rutaInternet)){
                    System.Diagnostics.Process.Start(rutaInternet);
                }else{MessageBox.Show("La carpeta no existe");
                }
            }
            else //es boton internet
            {
                System.Diagnostics.Process.Start(rutaInternet);
            }

            //añadir log, si hay
            if (log != "")
            {
                logs.addToLog(log);
            }

            if (cerrarDespuesDeApretar)
            {
                formularioInicial.Close();
            }
            
        }//fin de la función que se ejecuta al hacer click sobre el botón

        public void alineacion(ContentAlignment alineacion) //para cambiar la alineación del texto
        {
            boton.TextAlign = alineacion;
        }

        /// <summary>
        /// para cambiar el color post-declaración
        /// </summary>
        /// <param name="colorDeFondo">Color del botón</param>
        public void color(Color colorDeFondo) { boton.BackColor = colorDeFondo; }

        /// <summary>
        /// añade el tooltip al botón
        /// </summary>
        /// <param name="texto">texto que aparecerá en el tooltip</param>
        public void addTooltip(String texto)
        {
            ToolTip tltp = new ToolTip();
            tltp.SetToolTip(boton, texto);
        }

        /// <summary>
        /// para decir que es de programas
        /// </summary>
        public void esProgramas()
        {
            esBotonProgramas = true;
            esBotonCarpetas = false;
        }

        public void esCarpetas()//para decir que es carpetas
        {
            esBotonCarpetas = true;
            esBotonProgramas = false;
        }

        public void esInternet()//por si acaso
        {
            esBotonProgramas = false;
            esBotonCarpetas = false;
        }

        public void addImagen(Image imagen)
        {
            boton.BackgroundImage = imagen;
            boton.BackgroundImageLayout = ImageLayout.Zoom;
        }

        /// <summary>
        /// permite pulsar el botón desde el código
        /// </summary>
        public void pulsarBoton()//
        {
            MouseEventArgs mEA = new MouseEventArgs(MouseButtons.Left, 1, 10, 10, 0);
            botonInternet_Click(this, mEA);
        }

        /// <summary>
        /// añade un botón al hacer click derecho que permite buscar en pirateBay
        /// </summary>
        /// <param name="textoMenu">texto que aparece en el botón</param>
        public void AddMenuContextualPiratebay(String textoMenu)
        {
            menuContextualPb=new ContextMenuStrip();
            ToolStripMenuItem toolstrip = new ToolStripMenuItem();
            toolstrip.Text = textoMenu;
            menuContextualPb.Items.Add(toolstrip);
            boton.ContextMenuStrip = menuContextualPb;

            toolstrip.Click += new EventHandler(toolstripPB_Click);

        }

        /// <summary>
        /// lo que hace el botón contextual de piratebay cuando le das
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void toolstripPB_Click(object sender, EventArgs e)
        {
            formularioEntradaTexto formularioPb = new formularioEntradaTexto("Buscar en pirateBay", "¿Qué quieres buscar en pirateBay?");
            formularioPb.mostrarFormulario();
            if (formularioPb.getText() != "")
            {
                System.Diagnostics.Process.Start("https://pirateproxy.la/search/" + formularioPb.getText() + "/0/99/0");
                logs.addToLog("Buscado en piratebay \"" + formularioPb.getText() + "\"");
            }
        }

        public void addMenuContextualNotepadPP(String textoMenu)
        {//añade un botón con el click derecho que abre notepad ++
            menuContextualPb = new ContextMenuStrip();
            ToolStripMenuItem toolstrip = new ToolStripMenuItem();
            toolstrip.Text = textoMenu;
            menuContextualPb.Items.Add(toolstrip);
            boton.ContextMenuStrip = menuContextualPb;

            toolstrip.Click += new EventHandler(toolstripNotepad_Click);
        }

        void toolstripNotepad_Click(object sender, EventArgs e)
        {
            string ruta=@"C:\luso\Archivos de programa\Notepad++\notepad++.exe";
            if(File.Exists(ruta)){
                System.Diagnostics.Process.Start(ruta);
                logs.addToLog("Abierto notepad ++");
            }else{
                MessageBox.Show("No se ha encontrado notepad++");
                logs.addToLog("No se ha podido abrir notepad++");
            }
        }

        public void addMenuContextualWikipedia(String textoMenu)
        {
            ContextMenuStrip menuContextualWiki=new ContextMenuStrip();
            ToolStripMenuItem toolstripWiki = new ToolStripMenuItem();
            toolstripWiki.Text = textoMenu;
            menuContextualWiki.Items.Add(toolstripWiki);
            boton.ContextMenuStrip = menuContextualWiki;

            toolstripWiki.Click += new EventHandler(toolstripWiki_Click);
        }

        void toolstripWiki_Click(object sender, EventArgs e)
        {
            formularioEntradaTexto entradaTexto = new formularioEntradaTexto("Buscar en wikipedia", "Texto a buscar en wikipedia:");
            entradaTexto.mostrarFormulario();
            if (entradaTexto.getText() != "")
            {
                System.Diagnostics.Process.Start("https://es.wikipedia.org/wiki/" + entradaTexto.getText());
            }

        }

        /// <summary>
        /// cambia el log que registra el botón al ser pulsado
        /// </summary>
        /// <param name="texto">log que registra el botón</param>
        public void logDelBoton(String texto)
        {
            log = texto;
        }

        /// <summary>
        /// Si es true después de abrir el enlace cerrará el panel de control
        /// </summary>
        /// <param name="siNo">True o false según se quiera cerrar o no</param>
        /// <param name="formPadre">formulario a cerrar</param>
        public void cerrarDespuesDePresionar(Boolean siNo, Form formPadre)
        {
            formularioInicial = formPadre;
            cerrarDespuesDeApretar = siNo;
        }

    }//fin de la clase botonInternet









    public class botonTodo//Clase creada específicamente para el primer botón de la columna izquierda
    {
        Button boton;

        public botonTodo(String texto, Panel contenedor)
        {
            boton = new Button();
            boton.Text = texto;
            boton.Click+=new EventHandler(boton_Click);
            contenedor.Controls.Add(boton);
            boton.Width = contenedor.Width;
            boton.Height = contenedor.Height / 10;
        }

        void boton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.gmail.com");
            System.Diagnostics.Process.Start("https://web.whatsapp.com/");
            System.Diagnostics.Process.Start("www.facebook.com");
            
        }

        public void addTooltip(String texto)
        {//añade el tooltip al botón
            ToolTip tltp = new ToolTip();
            tltp.SetToolTip(boton, texto);
        }

        public void pulsarBoton()//permite pulsar el botón desde el código
        {
            MouseEventArgs mEA = new MouseEventArgs(MouseButtons.Left, 1, 10, 10, 0);
            boton_Click(this, mEA);
        }

        public void color(Color colorDeFondo) { boton.BackColor = colorDeFondo; }//para cambiar el color post-declaración
        
    }//fin de la clase botonTodo


    public class textBoxGoogle //crea una textbox que introduce lo escrito en google
    {
        TextBox txtBox;
        List<string> cosasBuscadas;//hace un histórico de búsquedas al que se puede acceder pulsando hacia arriba
        int indice;//punto en el que te encuentras

        public textBoxGoogle(Panel contenedor)
        {
            txtBox=new TextBox();
            contenedor.Controls.Add(txtBox);
            txtBox.Width = Convert.ToInt32(contenedor.Width * 0.99);
            txtBox.KeyDown+=new KeyEventHandler(txtBox_KeyDown);
            cosasBuscadas = new List<string>();
            indice = 0;

            ToolTip tltp = new ToolTip();
            tltp.SetToolTip(txtBox, "Buscar en google");
        }

        public void buscarEnGoogle()//busca en google lo que hay en la textbox
        {
            String texto = txtBox.Text;
            System.Diagnostics.Process.Start("http://www.google.com/search?hl=en&q=" + texto + "&aq=f&oq=");
            logs.addToLog("Buscado en google \"" + texto + "\"");
        }

        public Boolean selected() { return txtBox.Focused; }
        public void select() { txtBox.Focus(); }

        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarEnGoogle();
                cosasBuscadas.Add(txtBox.Text);//se añade lo buscado al histórico
                indice = cosasBuscadas.Count;
                txtBox.Text = "";
                
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtBox.Text = busquedaAnterior();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtBox.Text = busquedaPosterior();
            }
        }

        private string busquedaAnterior()
        {
            if (indice == 0)//no quedan anteriores
            {
                return cosasBuscadas[indice];
            }
            else
            {
                int aux = indice;
                indice = indice - 1;
                return cosasBuscadas[indice];
            }
        }

        private string busquedaPosterior()
        {
            if (indice == cosasBuscadas.Count() - 1)
            {
                return "";
            }
            else
            {
                indice = indice + 1;
                return cosasBuscadas[indice];
            }
        }
            
    }//fin de la clase textBoxGoogle

    public class ListaDesplegableCarpeta //crea un desplegable con todos los directorios de una carpeta
    {
        ComboBox listaDesplegable;
        string nombre,carpetaPrincipal;
        Panel panelContenedor;

        public ListaDesplegableCarpeta(String ruta2,Panel contenedor,String nombre)//tiene que leer todos los directorios dentro de la carpeta y para cada directorio añadirlo a la lista
        {
            string ruta,rutaGuardar;
            ruta = ruta2;
            rutaGuardar = @"Guardar/carpetasComboBox.lus";
            bool hayCarpeta=false;

            if (!Directory.Exists(ruta)){//no existe la carpeta. Se plantea la posibilidad de crear otra carpeta
                
                //se comprueba si en el archivo de comboboxes hay alguna referencia a éste
                if (Directory.Exists("Guardar") && File.Exists(rutaGuardar))
                {

                    StreamReader sr = new StreamReader(rutaGuardar);
                    while (!sr.EndOfStream && !hayCarpeta)
                    {
                        if (sr.ReadLine() == ruta) //hay una referencia a este
                        {
                            ruta = sr.ReadLine();//se cambia la ruta por la línea siguiente
                            hayCarpeta = true;
                        }
                    }
                    sr.Close();

                }

                if (!hayCarpeta)
                {
                    if (MessageBox.Show("No se ha encontrado la carpeta " + ruta + " para crear el comboBox ¿desea asociarlo a otra carpeta?", "Fallo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        FolderBrowserDialog seleccionarCarpeta = new FolderBrowserDialog();
                        seleccionarCarpeta.ShowDialog();
                        if (seleccionarCarpeta.SelectedPath != "")
                        {
                            ruta = seleccionarCarpeta.SelectedPath;
                            hayCarpeta = true;

                            //se guarda registro de que se sustituye esta carpeta por otra
                            if (!Directory.Exists("Guardar"))
                            {
                                Directory.CreateDirectory("Guardar");
                            }
                            if (!File.Exists(rutaGuardar))
                            {
                                FileStream fs = File.Create(rutaGuardar);
                                fs.Close();
                            }

                            StreamWriter sw = new StreamWriter(rutaGuardar);
                            sw.WriteLine(ruta2);
                            sw.WriteLine(ruta);
                            sw.Close();

                        }
                    }
                }
            }else{hayCarpeta=true;}

            if(hayCarpeta)
            {
                listaDesplegable = new ComboBox();
                string[] carpetas = Directory.GetDirectories(ruta);

                this.nombre = nombre;
                carpetaPrincipal = ruta;
                panelContenedor = contenedor;
                listaDesplegable.Items.Add(nombre);

                foreach (String subcarpeta in carpetas)
                {
                    string nombreCarpeta = subcarpeta.Substring(subcarpeta.LastIndexOf(@"\") + 1);

                    listaDesplegable.Items.Add(nombreCarpeta);
                }

                listaDesplegable.DropDownStyle = ComboBoxStyle.DropDownList;
                listaDesplegable.SelectedIndex = 0;

                listaDesplegable.MouseHover += new EventHandler(listaDesplegable_MouseHover);
                listaDesplegable.SelectedValueChanged += new EventHandler(listaDesplegable_SelectedValueChanged);

                contenedor.Controls.Add(listaDesplegable);
            }
            

        }//fin del constructor listaDesplegableCarpeta

        void listaDesplegable_SelectedValueChanged(object sender, EventArgs e)
        {
            String carpetaSeleccionada=listaDesplegable.SelectedItem.ToString();
            if (carpetaSeleccionada == nombre)
            {//abrir carpeta principal
                carpetaSeleccionada = carpetaPrincipal;
            }
            else
            {
                carpetaSeleccionada = carpetaPrincipal + @"\" + carpetaSeleccionada;
            }
            //MessageBox.Show(carpetaSeleccionada);
            System.Diagnostics.Process.Start(carpetaSeleccionada);
            panelContenedor.Focus();
            
        }

        void listaDesplegable_MouseHover(object sender, EventArgs e)
        {
            listaDesplegable.DroppedDown=true;
        }//fin de la declaración de ListaDesplegableCarpeta

    }//fin de la clase ListaDesplegableCarpeta

    public class LectorTeclasPulsadas //crea una lista de teclas y botones, de manera que lee la tecla introducida y pulsa el botón determinado
    {
        List<Keys> teclas;
        List<botonInternet> botones;
        botonTodo botonDeTodo;
        Keys teclaTodo;

        public LectorTeclasPulsadas()
        {//inicializar
            teclas = new List<Keys>();
            botones = new List<botonInternet>();
        }

        public void addBoton(botonInternet boton,Keys tecla)//añade un botón a la lista de teclas de acceso rápido
        {
            botones.Add(boton);
            teclas.Add(tecla);
        }

        public void addBotonTodo(botonTodo boton, Keys tecla)//función especial para el botón de todo
        {
            botonDeTodo = boton;
            teclaTodo = tecla;
        }

        public Boolean comprobarTecla(Keys teclaPulsada)//si es una de las teclas de los botones, lo pulsa, devuelve true si lo ha encontrado
        {
            int i = 0;//indice que recorre la lista de botones

            Boolean buscando=true;//para cuando ya se ha encontrado

            foreach (Keys tecla in teclas) //comprueba la lista entera de botones
            {
                if (buscando && tecla == teclaPulsada)
                {
                    botones[i].pulsarBoton();
                }
                else { i += 1; }                
            }

            if (buscando && teclaPulsada == teclaTodo)
            {//a ver si es la de todo
                buscando = false;
                botonDeTodo.pulsarBoton();
            }


            if (buscando) { return false; } //no se ha encontrado nada
            else { return true; }


	    }//fin de la clase comprobarTecla
        
        

    }//fin de la clase LectorTeclasPulsadas

    public class ListaColores //utilidades para cambiar de colores
    {
        List<Color> lista, listaColoresNuevos;
        int indiceActual;
        ToolStripMenuItem contenedor;
        Form1 formularioOrigen;
        

        public ListaColores(ToolStripMenuItem cont)//declaración básica
        {
            lista = new List<Color>();
            listaColoresNuevos=new List<Color>();//esta permite diferenciar los guardados de los por defecto.

             //introducimos los primeros colores en la lista
            lista.Add(Color.Beige);
            lista.Add(Color.LemonChiffon);
            lista.Add(Color.Azure);
            lista.Add(Color.Thistle);
            lista.Add(Color.LavenderBlush);
            lista.Add(Color.NavajoWhite);
            lista.Add(Color.Honeydew);

            indiceActual = 0;

            contenedor = cont;

            leerColoresNuevos();
        }

        public Color siguienteColor()
        {
            if (indiceActual == lista.Count - 1)
            {//se ha llegado al final de la lista
                indiceActual = 0;
            }
            else { indiceActual += 1; }

            return lista[indiceActual];
        }

        public void guardarColor(Color colorNuevo)//permite guardar el color en un archivo
        {
            if (!Directory.Exists("Guardar"))
            {//crear directorio
                Directory.CreateDirectory("Guardar");
            }

            string ruta=@"Guardar\color.lus";

            if (!File.Exists(ruta))
            {
                FileStream fs = File.Create(ruta);
                fs.Close();
            }

            StreamWriter sw=new StreamWriter(ruta);
            sw.Write(colorNuevo.ToArgb());
            sw.Close();

            //MessageBox.Show("Guardado color " + colorNuevo.ToArgb());

        }

        public Color leerColor()//lee el color del archivo
        {
            Color colorDevuelto;
            string ruta=@"Guardar\color.lus";
            if (Directory.Exists("Guardar"))
            {
                if (File.Exists(ruta))
                {
                    StreamReader sr = new StreamReader(ruta);
                    colorDevuelto = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
                    sr.Close();

                    //MessageBox.Show("Leido color " + colorDevuelto.ToArgb());
                    lista.Add(colorDevuelto);//se añade a la lista

                }
                else
                {
                    MessageBox.Show("no se ha leido el archivo");
                    colorDevuelto = Color.Green;
                }
            }
            else
            {
                MessageBox.Show("No se ha encontrado el directorio de color guardado");
                colorDevuelto = Color.LightGray;
            }


            return colorDevuelto; 
        }//fin de lafunción leerColor

        public Color colorAleatorio()//crea un color aleatorio
        {
            int rojo, verde, azul;

        Random rnd = new Random();

        
        rojo = rnd.Next(255);
        verde = rnd.Next(255);
        azul = rnd.Next(255);


        Color colorNuevo = Color.FromArgb(rojo, verde, azul);

        //añadir color a la lista
        lista.Add(colorNuevo);

        

        return colorNuevo;
        }

        public Color seleccionarColor(Color colorAnterior)
        {
            ColorDialog seleccionaColor = new ColorDialog();
            seleccionaColor.AnyColor = true;
            seleccionaColor.Color=colorAnterior;
            if (seleccionaColor.ShowDialog() == DialogResult.OK)
            {
                Color colorNuevo = seleccionaColor.Color;
                lista.Add(colorNuevo);
                return colorNuevo;
            }
            else
            {//no se ha seleccionado color
                return colorAnterior;
            }
        }

        public void toolstripAdd()
        {
            foreach (Color cl in lista)
            {
                botonColor bot = new botonColor(cl,contenedor,formularioOrigen);
                

            }
        }

        public void addColorLista(Color colorNuevo)//lo añade al toolstrip y a la lista y lo guarda en un archivo para recuperarlo
        {
            botonColor bot = new botonColor(colorNuevo, contenedor, formularioOrigen);
            lista.Add(colorNuevo);//lo guarda en la lista principal
            listaColoresNuevos.Add(colorNuevo);//lo guarda en la lista nueva
            guardarColoresNuevos();
        }//fin de la función addColorLista

        public void guardarColoresNuevos()//guarda en un archivo los colores nuevos
        {
            string ruta=@"Guardar\coloresNuevos.lus";

            if (!Directory.Exists("Guardar"))//se crea el directorio
            {
                Directory.CreateDirectory("Guardar");
            }

            if (!File.Exists(ruta))//se crea el archivo
            {
                FileStream fs = File.Create(ruta);
                fs.Close();
            }

            StreamWriter sw = new StreamWriter(ruta);
            sw.Write("");//borra lo anterior

            foreach (Color cl in listaColoresNuevos)
            {
                sw.WriteLine(cl.ToArgb());
            }
            sw.Close();

        }//fin de la función guardarColoresNuevos

        public void leerColoresNuevos()//lee el archivo de colores nuevos y los añade a las dos listas
        {
            string ruta = @"Guardar\coloresNuevos.lus";
            if (Directory.Exists("Guardar") && File.Exists(ruta))
            {
                StreamReader sr = new StreamReader(ruta);
                while (!sr.EndOfStream)
                {
                    Color cl = Color.FromArgb(Convert.ToInt32( sr.ReadLine()));
                    lista.Add(cl);
                    listaColoresNuevos.Add(cl);
                }

                sr.Close();
            }

        }//fin de la función leerColoresNuevos

        public void addFormularioOrigen(Form1 origen)//añade el formulario de origen al objeto
        {
            formularioOrigen = origen;
        }

    }//fin de la clase listaColores

    public class botonColor //clase auxiliar para cambiar de color
    {
        Color colorBoton;
        ToolStripMenuItem bot, contenedor;
        Form1 formularioOrigen;

        public botonColor(Color color, ToolStripMenuItem cont,Form1 formulario)
        {
            contenedor = cont;
            colorBoton = color;
            bot = new ToolStripMenuItem(color.ToString());
            bot.BackColor = color;

            cont.DropDownItems.Add(bot);

            bot.Click += new EventHandler(bot_Click);
            formularioOrigen = formulario;
        }

        void bot_Click(object sender, EventArgs e)
        {
            formularioOrigen.cambiarColor(colorBoton);
            logs.addToLog("Cambiado color a "+colorBoton.ToString());
        }

    }
    public class formularioEntradaTexto
    {//para introducir un texto
        Form formulario;
        Button botonOk, botonCancel;
        TextBox txtbox;
        string texto;

        public formularioEntradaTexto(String titulo, String indicacion)
        {
            formulario = new Form();
            formulario.Text = titulo;
            Label etiqueta = new Label();
            etiqueta.AutoSize = true;
            etiqueta.Text = indicacion;
            txtbox = new TextBox();
            botonOk=new Button();
            botonOk.Text = "Ok";
            botonCancel = new Button();
            botonCancel.Text = "Cancelar";

            formulario.Controls.Add(etiqueta);
            formulario.Controls.Add(txtbox);
            formulario.Controls.Add(botonOk);
            formulario.Controls.Add(botonCancel);

            formulario.Width = 500;
            etiqueta.Top = 20;
            txtbox.Top = 50;
            txtbox.Width = Convert.ToInt32(formulario.Width * 0.9);
            botonOk.Top = 80;
            botonCancel.Top = botonOk.Top;

            etiqueta.Left = 10;
            txtbox.Left = 10;
            botonOk.Left = 10;

            botonCancel.Left = botonOk.Left + botonOk.Width + 10;

            formulario.Height = 150;

            botonOk.Click += new EventHandler(botonOk_Click);
            botonCancel.Click += new EventHandler(botonCancel_Click);
            txtbox.KeyDown += new KeyEventHandler(txtbox_KeyDown);

            texto = "";
                        
        }

        void txtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                texto = txtbox.Text;
                formulario.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                formulario.Close();
            }
        }

        void botonCancel_Click(object sender, EventArgs e)
        {
            formulario.Close();
        }

        void botonOk_Click(object sender, EventArgs e)
        {
            texto=txtbox.Text;
            formulario.Close();
        }

        public void mostrarFormulario(){

            formulario.ShowDialog();
        }


        public string getText(){return texto;}

        public void guardarTitulo(String tituloNuevo)
        {//para guardar el título en un archivo
            if (!Directory.Exists("Guardar"))
            {//crear directorio
                Directory.CreateDirectory("Guardar");
            }

            string ruta = @"Guardar\titulo.lus";

            if (!File.Exists(ruta))
            {
                FileStream fs = File.Create(ruta);
                fs.Close();
            }

            StreamWriter sw = new StreamWriter(ruta);
            sw.Write(texto);
            sw.Close();

            logs.addToLog("Guardado título \"" + texto + "\"");

        }

        public static string leerTitulo()//para leer el título de un archivo
        {
            string titulo;
            string ruta = @"Guardar\titulo.lus";
            if (Directory.Exists("Guardar") && File.Exists(ruta))
            {
                StreamReader sr = new StreamReader(ruta);
                titulo = sr.ReadToEnd();
                sr.Close();
            }
            else
            {//no existe el archivo
                titulo = "Panel de Control";
            }

            return titulo; 
        }

    }//fin de la clase formularioEntradaTexto

    public class sizeFormulario//funciones para guardar y leer tamaños de formulario
    {
        public static void guardarSize(int largo, int ancho,int posX,int posY)
        {
            string ruta = @"guardar\size.lus";

            if (!Directory.Exists("Guardar")) { Directory.CreateDirectory("Guardar"); }

            if (!File.Exists(ruta))
            {
                FileStream fs = File.Create(ruta);
                fs.Close();
            }

            StreamWriter sw = new StreamWriter(ruta);
            sw.Write("");

            sw.WriteLine(largo);
            sw.WriteLine(ancho);
            sw.WriteLine(posX);
            sw.WriteLine(posY);
            sw.Close();

            logs.addToLog("Guardados posición y dimensiones del formulario");

        }//fin de la función guardarSize

        public static int leerAncho(int anchoInicial)//devuelve el ancho leido del archivo. Si no lee nada devuelve el ancho por defecto
        {
            int anchoDevuelto=anchoInicial;
            string ruta = @"guardar\size.lus";

            if(Directory.Exists("Guardar") && File.Exists(ruta)){
                StreamReader sr=new StreamReader(ruta);
                string aux = sr.ReadLine();//la primera línea no se lee que es el largo
                anchoDevuelto=Convert.ToInt32(sr.ReadLine());
                sr.Close();
            }
            return anchoDevuelto;

        }//fin de la función leerAncho

        public static int leerLargo(int largoInicial)//devuelve el largo leido del archivo. Si no lee nada devuelve el largo por defecto
        {
            int anchoDevuelto = largoInicial;
            string ruta = @"guardar\size.lus";

            if (Directory.Exists("Guardar") && File.Exists(ruta))
            {
                StreamReader sr = new StreamReader(ruta);
                //string aux = sr.ReadLine();//la primera línea no se lee que es el largo
                anchoDevuelto = Convert.ToInt32(sr.ReadLine());
                sr.Close();
            }
            return anchoDevuelto;

        }//fin de la función leerX

        public static int leerX(int xInicial)//devuelve el largo leido del archivo. Si no lee nada devuelve el largo por defecto
        {
            int anchoDevuelto = xInicial;
            string ruta = @"guardar\size.lus";

            if (Directory.Exists("Guardar") && File.Exists(ruta))
            {
                StreamReader sr = new StreamReader(ruta);
                string aux = sr.ReadLine();//la primera línea no se lee que es el largo
                aux = sr.ReadLine();//sgunda linea
                anchoDevuelto = Convert.ToInt32(sr.ReadLine());
                sr.Close();
            }
            return anchoDevuelto;

        }//fin de la función leerX

        public static int leerY(int YInicial)//devuelve el largo leido del archivo. Si no lee nada devuelve el largo por defecto
        {
            int anchoDevuelto = YInicial;
            string ruta = @"guardar\size.lus";

            if (Directory.Exists("Guardar") && File.Exists(ruta))
            {
                StreamReader sr = new StreamReader(ruta);
                string aux = sr.ReadLine();//la primera línea no se lee que es el largo
                aux = sr.ReadLine();//segunda
                aux = sr.ReadLine();//tercera
                anchoDevuelto = Convert.ToInt32(sr.ReadLine());
                sr.Close();
            }
            return anchoDevuelto;

        }//fin de la función leerY
    }//fin de la clase sizeFormulario

    /// <summary>
    /// diferentes utilidades para mostrar la versión del programa
    /// </summary>
    public class Version
    {
        string numeroVersion, historico;
        ToolStripMenuItem boton;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="botonVersion">botón que mostrará el número de versión y que al hacer click mandará al histórico</param>
        public Version(ToolStripMenuItem botonVersion)
        {
            numeroVersion = "";
            historico = "";
            boton = botonVersion;
            boton.ToolTipText = "Ver histórico de versiones";

            boton.Text=numeroVersion;

            boton.Click += new EventHandler(boton_Click);
        }

        void boton_Click(object sender, EventArgs e)//muestra el histórico de versiones
        {
            FormularioVersion frm = new FormularioVersion(historico);
        }

        public string getNumeroVersion() { return numeroVersion; }
        /// <summary>
        /// Cambia el número de versión, incluido el texto del botón
        /// </summary>
        /// <param name="nuevaVersion">versión nueva</param>
        public void setNumeroVersion(string nuevaVersion) 
        { 
            numeroVersion = nuevaVersion;
            boton.Text = nuevaVersion;
        }

        /// <summary>
        /// añade una nueva línea. Si la versión es mayor que la actual, la cambia
        /// </summary>
        /// <param name="nuevaVersion">Número de versión</param>
        /// <param name="fecha">fecha de la versión</param>
        /// <param name="texto">descripción de la versión</param>
        public void addVersion(String nuevaVersion, String fecha, String texto)//
        {
            historico=historico+ "\r\n";

            if (FuncionesAux.contar(nuevaVersion, '.') == 1)
            {
                historico = historico + nuevaVersion + "\t \t (" + fecha + ")   \t" + texto;
            }
            else if (FuncionesAux.contar(nuevaVersion, '.') == 2)
            {
                historico = historico + "\t" + nuevaVersion + "\t (" + fecha + ")   \t" + texto;
            }
                        
            if (String.Compare(nuevaVersion,numeroVersion)>0)//la versión es más moderna
            {
                setNumeroVersion(nuevaVersion);
            }

            
        }

        /// <summary>
        /// devuelve un string con todo el histórico
        /// </summary>
        /// <returns></returns>
        public string getHistorico()
        {
            return historico;
        }



    }//fin de la clase version

    /// <summary>
    /// muestra y crea un formulario para ver el histórico de versiones
    /// </summary>
    public class FormularioVersion
    {
        Form formulario;
        Button botonOk;

        /// <summary>
        /// muestra un formulario con el histórico
        /// </summary>
        /// <param name="hist">texto que se mostrará</param>
        public FormularioVersion(String hist)
        {
            formulario = new Form();
            formulario.Height = 600;
            formulario.Width = 850;
            formulario.Text = "Histórico";
            formulario.MaximumSize = formulario.Size;
            formulario.MinimumSize = formulario.Size;
            //formulario.Icon = Panel_de_Control_2.Properties.Resources.icono;
            TextBox txtBox = new TextBox();
            txtBox.Multiline = true;
            txtBox.WordWrap = false;
            //txtBox.MaximumSize.Height = 500;
            txtBox.ScrollBars = ScrollBars.Both;
            txtBox.Height = 500;
            txtBox.Width = 800;
            formulario.Controls.Add(txtBox);
            txtBox.Top = 10;
            txtBox.Left = 10;
            txtBox.ReadOnly = true;
            txtBox.Text = hist;

            botonOk = new Button();
            botonOk.Text = "Aceptar";
            formulario.Controls.Add(botonOk);
            botonOk.Top = 515;
            botonOk.Left = 10;

            botonOk.Click += new EventHandler(botonOk_Click);
            botonOk.Select();
            formulario.ShowDialog();
            
        }

        void botonOk_Click(object sender, EventArgs e)
        {
            formulario.Close();
        }//fin del constructor FormularioVersion

    }//fin de la clase formularioVersion

}
