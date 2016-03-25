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
    /// utilidades para añadir botones a un menú contextual
    /// </summary>
    public class AddBotones//
    {
        Form formulario;
        ComboBox selectTipo;
        TextBox nombre, ruta;
        Button botonOk, botonCancelar;
        Label labelInternet, LabelProgramas, LabelCarpetas;
        ContextMenuStrip contextInternet, contextProgramas, contextCarpetas; //estos permitirán almacenar los botones para leerlos y guardarlos

        List<claseAuxBotonContext> botonesInternet, botonesProgramas, botonesCarpetas;

        public AddBotones(Label Internet,Label programas,Label carpetas) {

            labelInternet = Internet;
            LabelProgramas = programas;
            LabelCarpetas = carpetas;

            contextInternet = new ContextMenuStrip();
            contextProgramas = new ContextMenuStrip();
            contextCarpetas = new ContextMenuStrip();

            labelInternet.ContextMenuStrip = contextInternet;
            LabelProgramas.ContextMenuStrip = contextProgramas;
            LabelCarpetas.ContextMenuStrip = contextCarpetas;

            botonesInternet=new List<claseAuxBotonContext>();
            botonesCarpetas=new List<claseAuxBotonContext>();
            botonesProgramas=new List<claseAuxBotonContext>();
            
            
            
            formulario = new Form();//creamos el formulario

            formulario.Text="Añadir botón";

            

            //creamos la label indicadora
            Label labelComboBox = new Label();
            labelComboBox.Text = "Tipo de botón:";
            formulario.Controls.Add(labelComboBox);
            labelComboBox.TextAlign = ContentAlignment.BottomLeft;

            //creamos el selector de tipo de botón
            selectTipo = new ComboBox();
            selectTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            selectTipo.Items.Clear();
            selectTipo.Items.Add("Internet");
            selectTipo.Items.Add("Programas");
            selectTipo.Items.Add("Carpetas");
            formulario.Controls.Add(selectTipo);

            //creamos la segunda label indicadora
            Label labelNombre=new Label();
            labelNombre.Text="Texto del botón";
            formulario.Controls.Add(labelNombre);
            labelNombre.TextAlign = ContentAlignment.BottomLeft;

            //creamos la textBox para introducir el nombre
            nombre = new TextBox();
            formulario.Controls.Add(nombre);

            //creamos la tercera etiqueta
            Label labelRuta = new Label();
            labelRuta.Text = "Ruta/Dirección";
            formulario.Controls.Add(labelRuta);
            labelRuta.TextAlign = ContentAlignment.BottomLeft;

            //creamos la textBox para introducir la ruta
            ruta = new TextBox();
            formulario.Controls.Add(ruta);

            //creamos el botonOk
            botonOk = new Button();
            botonOk.Text = "Aceptar";
            botonOk.Click += new EventHandler(botonOk_Click);
            formulario.Controls.Add(botonOk);


            //creamos el botonCancelar
            botonCancelar = new Button();
            botonCancelar.Text = "Cancelar";
            botonCancelar.Click += new EventHandler(botonCancelar_Click);
            formulario.Controls.Add(botonCancelar);
            

            //ajustamos alturas y posiciones
            labelComboBox.Top = 10;
            selectTipo.Top = 40;
            labelNombre.Top = 70;
            nombre.Top = 100;
            labelRuta.Top = 130;
            ruta.Top = 160;
            botonOk.Top = 210;
            botonCancelar.Top = 210;
            botonCancelar.Left = botonOk.Left + botonOk.Width + 10;

            labelComboBox.Left = 10;
            selectTipo.Left = 10;
            labelNombre.Left = 10;
            nombre.Left = 10;
            labelRuta.Left = 10;
            ruta.Left = 10;
            botonOk.Left = 10;

            nombre.Width = 100;
            ruta.Width = 500;
            formulario.Width = 550;

            

        }

        void botonCancelar_Click(object sender, EventArgs e) //cierra el formulario borrando antes todos los campos
        {
            nombre.Text = "";
            ruta.Text = "";
            formulario.Close();
        }

        void botonOk_Click(object sender, EventArgs e)//cierra el formulario
        {
            formulario.Close();
        }

        public void addBotonConFormulario()
        {
            formulario.ShowDialog();

            ContextMenuStrip menu;

            if (nombre.Text != "" && ruta.Text != "")
            {
                claseAuxBotonContext a=new claseAuxBotonContext(nombre.Text,ruta.Text);
                
                if (selectTipo.SelectedItem.ToString() == "Internet")
                {
                    menu = contextInternet;
                    botonesInternet.Add(a);
                }
                else if (selectTipo.SelectedItem.ToString() == "Programas")
                {
                    menu = contextProgramas;
                    botonesProgramas.Add(a);
                }
                else
                {
                    menu = contextCarpetas;
                    botonesCarpetas.Add(a);
                }

                BotonContextual botonCont = new BotonContextual(nombre.Text, ruta.Text, menu);
                logs.addToLog("Creado botón de " + selectTipo.SelectedItem.ToString() + " con nombre \"" + nombre.Text + "\" con enlace a " + ruta.Text);

                nombre.Text = "";
                ruta.Text = "";

                guardarBotones();

                MessageBox.Show("Boton creado. Aparecerá al hacer click derecho sobre el texto \""+selectTipo.SelectedItem.ToString()+"\"");

                

            }
        }//fin de la función addBotonConFormulario

        public void guardarBotones()//guarda los botones de la lista en archivos
        {
            string directorio="Guardar";//directorio en el que se guardarán los archivos
            string rutaArchivoInternet = @"Guardar/botonesInternet.lus";
            string rutaArchivoProgramas = @"Guardar/botonesProgramas.lus";
            string rutaArchivoCarpetas = @"Guardar/botonesCarpetas.lus";


            if (!Directory.Exists(directorio))//crear el directorio
            {
                Directory.CreateDirectory(directorio);
            }

            //guardar botones de internet
            string rutaArchivoActual;
            rutaArchivoActual = rutaArchivoInternet;

            if (!File.Exists(rutaArchivoActual))
            {
                FileStream fs = File.Create(rutaArchivoActual);
                fs.Close();
            }

            StreamWriter sw = new StreamWriter(rutaArchivoActual);
            sw.Write("");

            foreach (claseAuxBotonContext bot in botonesInternet)
            {
                sw.WriteLine(bot.nombre);
                sw.WriteLine(bot.ruta);
            }

            sw.Close();

            //guardar botones de programas
            rutaArchivoActual = rutaArchivoProgramas;

            if (!File.Exists(rutaArchivoActual))
            {
                FileStream fs = File.Create(rutaArchivoActual);
                fs.Close();
            }

            StreamWriter sw2 = new StreamWriter(rutaArchivoActual);
            sw2.Write("");

            foreach (claseAuxBotonContext bot in botonesProgramas)
            {
                sw2.WriteLine(bot.nombre);
                sw2.WriteLine(bot.ruta);
            }

            sw2.Close();

            //guardar botones de carpetas
            rutaArchivoActual = rutaArchivoCarpetas;

            if (!File.Exists(rutaArchivoActual))
            {
                FileStream fs = File.Create(rutaArchivoActual);
                fs.Close();
            }

            StreamWriter sw3 = new StreamWriter(rutaArchivoActual);
            sw3.Write("");

            foreach (claseAuxBotonContext bot in botonesCarpetas)
            {
                sw3.WriteLine(bot.nombre);
                sw3.WriteLine(bot.ruta);
            }

            sw3.Close();

        }


        public void leerBotones()//lee los botones de los archivos, los crea y los añade a la lista
        {
            string directorio = "Guardar";//directorio en el que se guardarán los archivos
            string rutaArchivoInternet = @"Guardar/botonesInternet.lus";
            string rutaArchivoProgramas = @"Guardar/botonesProgramas.lus";
            string rutaArchivoCarpetas = @"Guardar/botonesCarpetas.lus";

            if (Directory.Exists(directorio))//si ni siquiera existe el directorio no se hace nada
            {
                string rutaActual;
                

                //leemos los botones de internet
                rutaActual = rutaArchivoInternet;
                if (File.Exists(rutaActual))
                {
                    StreamReader sr = new StreamReader(rutaActual);
                    while (!sr.EndOfStream)
                    {
                        string nombreLeido, rutaLeida;
                        nombreLeido = sr.ReadLine();
                        rutaLeida = sr.ReadLine();
                        claseAuxBotonContext aux = new claseAuxBotonContext(nombreLeido, rutaLeida);
                        botonesInternet.Add(aux);
                        BotonContextual bot = new BotonContextual(nombreLeido, rutaLeida,contextInternet);
                    }
                    sr.Close();
                }
                else { logs.addToLog("No se encontró la ruta de los botones de programas"); }

                //leemos los botones de programas
                rutaActual = rutaArchivoProgramas;
                if (File.Exists(rutaActual))
                {
                    StreamReader sr2 = new StreamReader(rutaActual);
                    while (!sr2.EndOfStream)
                    {
                        string nombreLeido, rutaLeida;
                        nombreLeido = sr2.ReadLine();
                        rutaLeida = sr2.ReadLine();
                        claseAuxBotonContext aux = new claseAuxBotonContext(nombreLeido, rutaLeida);
                        botonesProgramas.Add(aux);
                        BotonContextual bot = new BotonContextual(nombreLeido, rutaLeida, contextProgramas);
                    }
                    sr2.Close();
                }
                else { logs.addToLog("No se encontró la ruta de los botones de programas"); }


                //leemos los botones de carpetas
                rutaActual = rutaArchivoCarpetas;
                if (File.Exists(rutaActual))
                {
                    StreamReader sr3 = new StreamReader(rutaActual);
                    while (!sr3.EndOfStream)
                    {
                        string nombreLeido, rutaLeida;
                        nombreLeido = sr3.ReadLine();
                        rutaLeida = sr3.ReadLine();
                        claseAuxBotonContext aux = new claseAuxBotonContext(nombreLeido, rutaLeida);
                        botonesCarpetas.Add(aux);
                        BotonContextual bot = new BotonContextual(nombreLeido, rutaLeida, contextCarpetas);
                    }
                    sr3.Close();
                }
                else { logs.addToLog("No se encontró la ruta de los botones de programas"); }

                logs.addToLog("Leidos los botones");

            }
            else { logs.addToLog("No se encontró el directorio para leer los botones"); }

        }//fin de la función leerBotones

        public void tipoDeBoton(int numeroDel1al3)//preselecciona un tipo de botón
        {
            selectTipo.SelectedIndex=numeroDel1al3-1;
            nombre.Select();
        }

    }//fin de la clase addBotones

    public class claseAuxBotonContext
    {//para hacer las listas
        public string nombre, ruta;
        public claseAuxBotonContext(String nombreDelBoton, String rutaDelBoton)
        {
            nombre = nombreDelBoton;
            ruta = rutaDelBoton;
        }
    }

    public class BotonContextual
    {
        String rutaBoton;
        ToolStripMenuItem boton;

        public BotonContextual(String nombre, String ruta, ContextMenuStrip contenedor)
        {
            rutaBoton = ruta;
            boton = new ToolStripMenuItem(nombre);

            boton.Click += new EventHandler(boton_Click);
            contenedor.Items.Add(boton);
        }

        public BotonContextual(String nombre, String ruta, ToolStripMenuItem contenedor)
        {
            rutaBoton = ruta;
            boton = new ToolStripMenuItem(nombre);

            boton.Click += new EventHandler(boton_Click);
            contenedor.DropDownItems.Add(boton);
            //contenedor.Items.Add(boton);
        }

        void boton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(rutaBoton);
            logs.addToLog("Pulsado botón contextual \"" + boton.Text + "\" con enlace a " + rutaBoton);
        }//fin de la declaración

    }//boton que al pulsarlo ejecuta una determinada ruta
}
