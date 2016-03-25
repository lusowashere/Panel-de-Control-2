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
    /// <summary>
    /// lista de alarmas y funciones para ellas
    /// </summary>
    public class ListaAlarmas
    {
        Form formularioCreacionAlarmas;
        List<Alarma> listaDeAlarmas; 
        ToolStripMenuItem contenedor;
        DateTimePicker selectorFecha;
        TextBox textBoxHora, textBoxTitulo, textBoxDescripcion;
        Boolean formularioRellenado;
        string ristra;

        /// <summary>
        /// lista de alarmas
        /// </summary>
        /// <param name="cont">toolstripmenuitem al que se le añadirán los botones</param>
        public ListaAlarmas(ToolStripMenuItem cont)
        {
            contenedor = cont;
            listaDeAlarmas = new List<Alarma>();

            //crear el formulario
            formularioCreacionAlarmas = new Form();
            formularioCreacionAlarmas.Text = "Crear nueva alarma";

            //creamos las labels
            Label labelFecha=new Label();
            labelFecha.Text = "Fecha para la alarma";
            labelFecha.Width = 300;
                       
            Label labelHora = new Label();
            labelHora.Text = "Hora (hh:mm:ss ó hh:mm)";
            labelHora.Width = 300;
                        
            Label labelTitulo = new Label();
            labelTitulo.Text = "Título de la alarma(opcional)";
            labelTitulo.Width = 300;
                        
            Label labelDescripcion = new Label();
            labelDescripcion.Text = "Descripción de la alarma";
            labelDescripcion.Width = 300;
            
            //creamos los controles
            int ancho = 200;
            selectorFecha = new DateTimePicker();
            textBoxHora = new TextBox();
            textBoxHora.Width = ancho;
            textBoxTitulo = new TextBox();
            textBoxTitulo.Width = ancho;
            textBoxDescripcion = new TextBox();
            textBoxDescripcion.Width = ancho;
            Button botonOk = new Button();
            botonOk.Text = "Activar alarma";
            Button botonCancelar=new Button();
            botonCancelar.Text = "Cancelar";
            botonCancelar.Click += new EventHandler(botonCancelar_Click);
            botonOk.Click += new EventHandler(botonOk_Click);

            //añadimos los controles

            formularioCreacionAlarmas.Controls.Add(labelFecha);
            formularioCreacionAlarmas.Controls.Add(selectorFecha);
            formularioCreacionAlarmas.Controls.Add(labelHora);
            formularioCreacionAlarmas.Controls.Add(textBoxHora);
            formularioCreacionAlarmas.Controls.Add(labelTitulo);
            formularioCreacionAlarmas.Controls.Add(textBoxTitulo);
            formularioCreacionAlarmas.Controls.Add(labelDescripcion);
            formularioCreacionAlarmas.Controls.Add(textBoxDescripcion);
            formularioCreacionAlarmas.Controls.Add(botonOk);
            formularioCreacionAlarmas.Controls.Add(botonCancelar);
            
            //posicionar los controles
            int alto1, alto2, alto0;
            alto1 = 50;
            alto2 = 25;
            alto0 = 10;

            labelFecha.Top = alto0;
            selectorFecha.Top = alto0+alto2;
            labelHora.Top = alto0 + alto1 * 1;
            textBoxHora.Top = alto0 + alto1 * 1 + alto2;
            labelTitulo.Top = alto0 + alto1 * 2;
            textBoxTitulo.Top = alto0 + alto1 * 2 + alto2;
            labelDescripcion.Top = alto0 + alto1 * 3;
            textBoxDescripcion.Top = alto0 + alto1 * 3 + alto2;
            botonOk.Top = alto0 + alto1 * 4+alto0;
            botonCancelar.Top = alto0 + alto1 * 4+alto0;

            int izquierda = 10;
            labelFecha.Left = izquierda;
            selectorFecha.Left = izquierda;
            labelHora.Left = izquierda;
            textBoxHora.Left = izquierda;
            labelTitulo.Left = izquierda;
            textBoxTitulo.Left = izquierda;
            labelDescripcion.Left = izquierda;
            textBoxDescripcion.Left = izquierda;
            botonOk.Left = izquierda;

            botonCancelar.Left = izquierda + botonCancelar.Width + izquierda;


            labelFecha.TextAlign = ContentAlignment.BottomLeft;
            labelHora.TextAlign = ContentAlignment.BottomLeft;
            labelTitulo.TextAlign = ContentAlignment.BottomLeft;
            labelDescripcion.TextAlign = ContentAlignment.BottomLeft;

            formularioCreacionAlarmas.StartPosition = FormStartPosition.CenterScreen;
        }

        void botonOk_Click(object sender, EventArgs e)//se comprueba que todo esté correcto y se cierra el formulario
        {
            DateTime fecha = selectorFecha.Value;
            string yyyy, mm, dd;
            yyyy = Convert.ToString(fecha.Year);
            mm = fechaYhora.ponerCeros(Convert.ToString(fecha.Month));
            dd=fechaYhora.ponerCeros(Convert.ToString(fecha.Day));

            string ristraHora = fechaYhora.validarHora(textBoxHora.Text);
            if (ristraHora != "") //la hora está bien escrita
            {
                ristra = yyyy + mm + dd + ristraHora;//ristra que se utilizará en la alarma
                if (Convert.ToInt64(ristra) > Convert.ToInt64(fechaYhora.ristraActual()))//la alarma no es anterior al momento actual
                {
                    //la alarma es correcta
                    formularioRellenado = true;
                    formularioCreacionAlarmas.Close();
                }
                else
                {
                    MessageBox.Show("La alarma no puede ser anterior al momento actual");
                }
                                
            }

            
        }//fin de la función botonOk_Click

        void botonCancelar_Click(object sender, EventArgs e)
        {
            formularioCreacionAlarmas.Close();
        }

        public void mostrarFormulario()//crea una alarma a partir del formulario
        {
            formularioRellenado = false;//esto evita que intente crear una alarma si se cancela el formulario
            formularioCreacionAlarmas.ShowDialog();
            
            if (formularioRellenado)
            {
                //creas una alarma
                addAlarma(textBoxDescripcion.Text, textBoxTitulo.Text, ristra);
                logs.addToLog("Creada alarma " + textBoxTitulo.Text + " " + fechaYhora.horaEscritaDesdeRistra(ristra) + " " + fechaYhora.fechaCortaDesdeRistra(ristra) + " con descripcion " + textBoxDescripcion.Text);
            
                textBoxDescripcion.Text = "";
                textBoxTitulo.Text = "";
                textBoxHora.Text = "";
            }

        }

        public void addAlarma(string texto, string titulo, string ristraAl)//añadir una alarma
        {
            Alarma alarmanueva = new Alarma(texto, titulo, ristraAl, contenedor, this);
            listaDeAlarmas.Add(alarmanueva);
            guardarAlarmas();
        }

        public void quitarAlarma(string ristra) //quita la alarma
        {
            int i,j;
            j = 0;
            i = 0;
            foreach (Alarma alrm in listaDeAlarmas)
            {
                if (alrm.getRistra() == ristra)
                {
                    j = i;
                }
                i = i + 1;
            }

            listaDeAlarmas.RemoveAt(j);
            guardarAlarmas();
        }

        public void comprobarAlarmas()//comprueba que la ristra actual no coincida con ninguna de las alarmas
        {
            foreach (Alarma alrm in listaDeAlarmas)
            {
                alrm.comprobar();
            }

            Boolean algoParaBorrar = true;
            while (algoParaBorrar)//da varias vueltas hasta asegurarse de que lo ha borrado todo
            {
                int i, elementoAborrar;
                
                algoParaBorrar = false;

                i = 0;
                elementoAborrar = 0;

                foreach (Alarma alarm in listaDeAlarmas)
                {
                    if (alarm.getEliminada())
                    {
                        algoParaBorrar = true;
                        elementoAborrar = i;
                    }
                    i += 1;
                }

                if (algoParaBorrar)
                {
                    listaDeAlarmas.RemoveAt(elementoAborrar);
                    guardarAlarmas();
                }
                                
            }
        }//fin de la función comprobarAlarmas

        /// <summary>
        /// comprueba si alguna de las alarmas de la lista está caducada
        /// </summary>
        public void comprobarCaducados() //
        {
            
            foreach (Alarma alrm in listaDeAlarmas)
            {
                alrm.comprobarCaducadas();
            }

            Boolean algoParaBorrar = true;
            while (algoParaBorrar)//da varias vueltas hasta asegurarse de que lo ha borrado todo
            {
                int i, elementoAborrar;

                algoParaBorrar = false;

                i = 0;
                elementoAborrar = 0;

                foreach (Alarma alarm in listaDeAlarmas)
                {
                    if (alarm.getEliminada())
                    {
                        algoParaBorrar = true;
                        elementoAborrar = i;
                    }
                    i += 1;
                }

                if (algoParaBorrar)
                {
                    listaDeAlarmas.RemoveAt(elementoAborrar);
                    guardarAlarmas();
                }

            }
        }//fin de la función comprobarCaducados

        /// <summary>
        /// comprueba si hay que cambiar alguna, y si es así, muestra el formulario
        /// </summary>
        /// <param name="tituloAnterior">titulo que tenía la alarma antes</param>
        /// <param name="textoAnterior">texto que tenía la alarma antes</param>
        /// <param name="ristraAnterior">ristra que tenía la alarma antes</param>
        public void comprobarCambiar(string tituloAnterior,string textoAnterior,string ristraAnterior)//
        {
            Boolean algoParaCambiar = true;
            while (algoParaCambiar)//da varias vueltas hasta asegurarse de que lo ha cambiado todo
            {
                int i, elementoAcambiar;

                algoParaCambiar = false;

                i = 0;
                elementoAcambiar = 0;

                foreach (Alarma alarm in listaDeAlarmas)
                {
                    if (alarm.getCambiada())
                    {
                        algoParaCambiar = true;
                        elementoAcambiar = i;
                    }
                    i += 1;
                }

                if (algoParaCambiar)
                {
                    textBoxTitulo.Text = tituloAnterior;
                    textBoxDescripcion.Text = textoAnterior;
                    textBoxHora.Text = fechaYhora.horaEscritaDesdeRistra(ristraAnterior); 

                    formularioRellenado = false;//esto evita que intente crear una alarma si se cancela el formulario
                    formularioCreacionAlarmas.ShowDialog();

                    if (formularioRellenado)
                    {
                        //cambias la alarma
                        listaDeAlarmas[elementoAcambiar].cambiarAlarma(textBoxDescripcion.Text, textBoxTitulo.Text, ristra);
                        textBoxDescripcion.Text = "";
                        textBoxTitulo.Text = "";
                        textBoxHora.Text = "";
                        guardarAlarmas();
                    }

                    listaDeAlarmas[elementoAcambiar].setCambiada(false);
                    
                }

            }
        }//fin de la función comprobarCambiar

        public void guardarAlarmas()//guarda la lista de alarmas en un archivo de texto
        {
             
            string ruta = @"Guardar\alarmas.lus";

            if (!Directory.Exists("Guardar")) { Directory.CreateDirectory("Guardar"); }

            if (!File.Exists(ruta))
            {
                FileStream fs = File.Create(ruta);
                fs.Close();
            }

            StreamWriter sw = new StreamWriter(ruta);
            sw.Write("");

            foreach (Alarma alrm in listaDeAlarmas)
            {
                sw.WriteLine(alrm.getTexto());
                sw.WriteLine(alrm.getTitulo());
                sw.WriteLine(alrm.getRistra());
            }
            sw.Close();

            logs.addToLog("guardadas alarmas");

            

        }  //fin de la función guardarAlarmas

        ///<summary>
        ///lee las alarmas
        ///</summary>
        public void cargarAlarmas()
        {
            string ruta = @"Guardar\alarmas.lus";
            if (Directory.Exists("Guardar") && File.Exists(ruta))
            {
                StreamReader sr = new StreamReader(ruta);
                while (!sr.EndOfStream)
                {
                    Alarma alrm = new Alarma(sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), contenedor, this);
                    listaDeAlarmas.Add(alrm);
                    
                }

                sr.Close();

                comprobarCaducados();
                                
            }
        }

    }//fin de la clase listaAlarmas

    /// <summary>
    /// información necesaria para crear una alarma
    /// </summary>
    public class Alarma//información necesaria para crear una alarma
    {
        string ristraHora, texto, titulo;
        ToolStripMenuItem boton, cambiar, quitar, contenedor;
        ListaAlarmas lista;
        Boolean eliminada, paraCambiar; //si está en positivo se elimina la alarma

        /// <summary>
        /// crea una alarma
        /// </summary>
        /// <param name="textoAlarma">texto de la alarma</param>
        /// <param name="tituloAlarma">titulo de la alarma</param>
        /// <param name="ristra">formato "yyyymmddhhmmss" para definir el momento en el que sonará</param>
        /// <param name="conten">toolstripmenuitem al que se le añadirá el botón de la alarma</param>
        /// <param name="listaOrigen">lista a la que se añadirá la alarma</param>
        public Alarma(string textoAlarma, string tituloAlarma, string ristra, ToolStripMenuItem conten, ListaAlarmas listaOrigen)//crear una nueva alarma
        {
            texto = textoAlarma;
            titulo = tituloAlarma;
            ristraHora = ristra;
            boton = new ToolStripMenuItem(tituloAlarma + " " + fechaYhora.horaEscritaDesdeRistra(ristra) + " " + fechaYhora.fechaCortaDesdeRistra(ristra));
            lista = listaOrigen;
            contenedor = conten;
            contenedor.DropDownItems.Add(boton);
            
            quitar = new ToolStripMenuItem("quitar");
            cambiar = new ToolStripMenuItem("cambiar");
            boton.DropDownItems.Add(quitar);
            boton.DropDownItems.Add(cambiar);
            quitar.Click += new EventHandler(quitar_Click);
            cambiar.Click += new EventHandler(cambiar_Click);

            eliminada = false;

            
        }

        void cambiar_Click(object sender, EventArgs e)
        {
            paraCambiar = true;
            lista.comprobarCambiar(titulo,texto,ristraHora);
        }

        void quitar_Click(object sender, EventArgs e)
        {
            quitarAlarma();
        }

        /// <summary>
        /// quita el boton de la alarma
        /// </summary>
        public void quitarAlarma()
        {
           // lista.quitarAlarma(ristraHora);
            contenedor.DropDownItems.Remove(boton);
            eliminada = true;
            //lista.comprobarCaducados();
        }

        /// <summary>
        /// si la ristra coincide con la ristra de la fecha actual, suena la alarma
        /// </summary>
        public void comprobar()
        {
            string ristraActual = fechaYhora.ristraActual();
            if (ristraActual == ristraHora)//suena la alarma
            {
                if( File.Exists(@"C:\Windows\Media\Alarm04.wav")){
                    System.Media.SoundPlayer player=new System.Media.SoundPlayer(@"C:\Windows\Media\Alarm04.wav");
                    player.Play();
                    //logs.addToLog("ha sonado el ruido");
                }else{
                    logs.addToLog("no se ha encontrado el sonido para la alarma");
                }
                
                logs.addToLog("suena la alarma " + titulo + " " + fechaYhora.horaEscritaDesdeRistra(ristraHora) + " " + fechaYhora.fechaCortaDesdeRistra(ristraHora));

                
                CuadroAlarma cuadro = new CuadroAlarma(this);
                cuadro.mostrarFormulario();

                if (cuadro.getAlarmaDescartada())
                {//se elimina la alarma
                    quitarAlarma();
                    eliminada = true;
                }
                System.Threading.Thread.Sleep(1000);//esto evita que suene dos veces en el mismo segundo
                            
            }
            /*else if (Convert.ToUInt64(ristraActual) > Convert.ToUInt64(ristraHora))//se ha pasado la hora de la alarma
            {
                MessageBox.Show("Se elimina la alarma " + titulo + "- " + fechaYhora.fechaCortaDesdeRistra(ristraHora) + " " + fechaYhora.horaEscritaDesdeRistra(ristraHora));
                contenedor.DropDownItems.Remove(boton);
                eliminada = true;
                //quitarAlarma();
            }*/

        }//fin de la función comprobar

        /// <summary>
        /// comprueba si la fecha de la alarma es anterior a la fecha actual
        /// </summary>        
        public void comprobarCaducadas()
        {
            string ristraActual = fechaYhora.ristraActual();
            if (Convert.ToUInt64(ristraActual) > Convert.ToUInt64(ristraHora))//se ha pasado la hora de la alarma
            {
                MessageBox.Show("Alarma Caducada " + titulo + "- " + fechaYhora.fechaCortaDesdeRistra(ristraHora) + " " + fechaYhora.horaEscritaDesdeRistra(ristraHora) + " descripcion:" +texto,titulo);
                quitarAlarma();
                eliminada = true;
                //quitarAlarma();
            }
        }

        /// <summary>
        /// devuelve el título de la alarma
        /// </summary>
        /// <returns></returns>
        public string getTitulo() { return titulo; }
        
        /// <summary>
        /// devuelve la ristra de la alarma
        /// </summary>
        /// <returns></returns>
        public string getRistra() { return ristraHora; }
        
        /// <summary>
        /// devuelve el texto de la alarma
        /// </summary>
        /// <returns></returns>
        public string getTexto() { return texto; }

        public Boolean getEliminada() { return eliminada; }
        public Boolean getCambiada() { return paraCambiar; }
        public void setCambiada(Boolean nuevoEstado) { paraCambiar = nuevoEstado; }

        /// <summary>
        /// cambia una alarma
        /// </summary>
        /// <param name="textoAlarma">nuevo texto</param>
        /// <param name="tituloAlarma">nuevo titulo</param>
        /// <param name="ristra">nueva ristra</param>
        public void cambiarAlarma(string textoAlarma, string tituloAlarma, string ristra)//
        {
            logs.addToLog("Cambiada la alarma " + titulo + " a " + tituloAlarma + "- " + fechaYhora.fechaCortaDesdeRistra(ristra) + " " + fechaYhora.horaEscritaDesdeRistra(ristra) + " descripcion:" + textoAlarma);
            texto = textoAlarma;
            titulo = tituloAlarma;
            ristraHora=ristra;
            boton.Text = tituloAlarma + " " + fechaYhora.horaEscritaDesdeRistra(ristra) + " " + fechaYhora.fechaCortaDesdeRistra(ristra);
            paraCambiar = false;

            lista.guardarAlarmas();
        }
    }//fin de la clase alarma

    /// <summary>
    /// Formulario que se muestra en el momento que suena una alarma
    /// </summary>
    public class CuadroAlarma
    {
        Form formulario;//lo que se muestra
        
        /// <summary>
        /// alarma que provoca la aparición del cuadro, para modificarla si hiciera falta.
        /// </summary>
        Alarma alarmaQueLlama;
        Button botonOk, botonAplazar;
        Boolean alarmaDescartada;//si no se ha aplazado la alarma, es true
        NumericUpDown minutos;//permite elegir los minutos a aplazar

        public CuadroAlarma(Alarma alarmaProvocadora) //constructor
        {
            alarmaQueLlama = alarmaProvocadora;//para poder trabajar con ella
            formulario = new Form(); //creamos el formulario que aparecerá

            formulario.Height = 150;
            formulario.Width = 500;
            formulario.MaximumSize = formulario.Size;
            formulario.MinimumSize = formulario.Size;

            formulario.Text = alarmaQueLlama.getTitulo();//le ponemos el título de la alarma
            formulario.StartPosition = FormStartPosition.CenterScreen;

            Label labelMensaje = new Label(); //la etiqueta que mostrará el mensaje
            labelMensaje.AutoSize = true;
            labelMensaje.Text = fechaYhora.fechaCortaDesdeRistra(alarmaQueLlama.getRistra()) + " " + fechaYhora.horaEscritaDesdeRistra(alarmaQueLlama.getRistra()) + " - " + alarmaQueLlama.getTexto();
            
            formulario.Controls.Add(labelMensaje);
            labelMensaje.Top = 30;
            labelMensaje.Left = 20;

            botonOk = new Button();//botón que descartará la alarma
            botonOk.Text = "Aceptar";
            botonOk.Click += new EventHandler(botonOk_Click);
            formulario.Controls.Add(botonOk);
            alarmaDescartada = false;
            botonOk.Top = 70;
            botonOk.Left = 20;

            botonAplazar = new Button();
            botonAplazar.Text = "Aplazar";
            formulario.Controls.Add(botonAplazar);
            botonAplazar.Top = botonOk.Top;
            botonAplazar.Left = formulario.Width - 30-botonAplazar.Width;
            botonAplazar.Click += new EventHandler(botonAplazar_Click);

            Label LabelAplazarAlarma = new Label();
            LabelAplazarAlarma.Text = "Aplazar alarma";
            formulario.Controls.Add(LabelAplazarAlarma);
            LabelAplazarAlarma.Top = botonOk.Top + 5;
            LabelAplazarAlarma.Left = botonOk.Left + botonOk.Width + 110;
            LabelAplazarAlarma.AutoSize = true;
            

            minutos = new NumericUpDown();
            minutos.Value = 5;
            formulario.Controls.Add(minutos);
            minutos.Minimum = 1;
            minutos.Top = botonOk.Top;
            minutos.Left = LabelAplazarAlarma.Left + LabelAplazarAlarma.Width + 4;
            minutos.Width = 40;

            Label labelMinutos = new Label();
            labelMinutos.Text = "minutos";
            formulario.Controls.Add(labelMinutos);
            labelMinutos.Top = LabelAplazarAlarma.Top;
            labelMinutos.Left = minutos.Left + minutos.Width + 4;


        }//fin del constructor CuadroAlarma

        /// <summary>
        /// boton que aplaza la alarma los minutos indicados en el numericupdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void botonAplazar_Click(object sender, EventArgs e)
        {
            int minutosAplazado = Convert.ToInt32(minutos.Value);
            alarmaDescartada = false;

            string ristraNueva;

            ristraNueva = fechaYhora.addMinutosARistra(alarmaQueLlama.getRistra(), minutosAplazado);

            alarmaQueLlama.cambiarAlarma(alarmaQueLlama.getTexto(), alarmaQueLlama.getTitulo(), ristraNueva);

            formulario.Close();
            logs.addToLog("Se aplaza la alarma " + alarmaQueLlama.getTitulo() + " " + minutosAplazado + "minutos");
            
        }

        /// <summary>
        /// lo que ocurre cuando se presiona el botón de "aceptar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void botonOk_Click(object sender, EventArgs e)
        {
            alarmaDescartada = true;
            formulario.Close();
        }

        /// <summary>
        /// devuelve true si se ha dado a aceptar al mostrar la alarma
        /// </summary>
        /// <returns></returns>
        public Boolean getAlarmaDescartada() { return alarmaDescartada; }

        /// <summary>
        /// muestra el cuadro de la alarma
        /// </summary>
        public void mostrarFormulario()
        {
            formulario.ShowDialog();
        }

    }//fin de la clase CuadroAlarma
}
