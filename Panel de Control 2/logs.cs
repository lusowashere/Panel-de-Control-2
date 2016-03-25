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
    class logs//clase utilizada para todas las funciones de guardar registros y leerlos
    {
        Form formulario;
        TextBox txtBox, textBoxEscribirEnLogs;
        Button botonOk;

        public logs()
        {
            formulario = new Form();
            formulario.Height = 600;
            formulario.Width = 850;
            formulario.Text = "Logs";
            formulario.MaximumSize = formulario.Size;
            formulario.MinimumSize = formulario.Size;
            //formulario.Icon = Panel_de_Control_2.Properties.Resources.icono;
            txtBox = new TextBox();
            txtBox.Multiline = true;
            txtBox.WordWrap = false;
            //txtBox.MaximumSize.Height = 500;
            txtBox.ScrollBars = ScrollBars.Both;
            txtBox.Height = 500;
            txtBox.Width = 800;
            formulario.Controls.Add(txtBox);
            txtBox.Top = 10;
            txtBox.Left = 10;
            
            botonOk = new Button();
            botonOk.Text = "Aceptar";
            formulario.Controls.Add(botonOk);
            botonOk.Top = 515;
            botonOk.Left = 10;
            botonOk.Click += new EventHandler(botonOk_Click);

            Button botonCarpetaLogs = new Button();
            botonCarpetaLogs.Text = "Carpeta de Logs";
            botonCarpetaLogs.AutoSize = true;
            formulario.Controls.Add(botonCarpetaLogs);
            botonCarpetaLogs.Top = 515;
            botonCarpetaLogs.Left = botonOk.Left + botonOk.Width + 10;
            botonCarpetaLogs.Click += new EventHandler(botonCarpetaLogs_Click);

            //boton que añade lo escrito a los logs
            Button botonEscribirEnLogs = new Button();
            botonEscribirEnLogs.Text = "Añadir";
            
            botonEscribirEnLogs.Top = botonOk.Top;
            botonEscribirEnLogs.Left = formulario.Width - 10 - botonEscribirEnLogs.Width-10;
            botonEscribirEnLogs.Click += new EventHandler(botonEscribirEnLogs_Click);

            //txtbox para añadir lo que quieras a los logs            
            textBoxEscribirEnLogs = new TextBox();
            formulario.Controls.Add(textBoxEscribirEnLogs);
            textBoxEscribirEnLogs.Top = botonOk.Top+2;
            textBoxEscribirEnLogs.Left = botonOk.Left + botonOk.Width + 10 + botonCarpetaLogs.Width + 10;
            textBoxEscribirEnLogs.Width = formulario.Width - textBoxEscribirEnLogs.Left - botonEscribirEnLogs.Width - 25;
            formulario.Controls.Add(botonEscribirEnLogs);//lo pongo después para optimizar el índice de tabulación





            formulario.FormClosed += new FormClosedEventHandler(formulario_FormClosed);
        }

        void botonEscribirEnLogs_Click(object sender, EventArgs e)//añade lo escrito a los logs ¡¡sin fecha!!
        {
            string ruta = @"C:\luso\Dropbox\mio\Programas\material\panelControl\logs";
            if (Directory.Exists(ruta))//se guarda en el directorio de material, junto con los otros logs
            {
                ruta = ruta + @"\" + fechaYhora.ristraFechaActual() + ".lus";
                if (!File.Exists(ruta))//hay que crear el archivo
                {
                    FileStream archivo = File.Create(ruta);
                    archivo.Close();
                }
            }
            else//se utiliza una ruta interna
            {
                ruta = "logs";
                if (!Directory.Exists(ruta))
                {//hay que crearlo
                    Directory.CreateDirectory(ruta);
                }
                ruta = ruta + @"\" + fechaYhora.ristraFechaActual() + ".lus";

                if (!File.Exists(ruta))
                {//hay que crearlo
                    FileStream archivo = File.Create(ruta);
                    archivo.Close();
                }
            }
            //primero se lee lo que hay
            string textoActual;
            StreamReader sr = new StreamReader(ruta);
            textoActual = sr.ReadToEnd();
            sr.Close();

            //se añade el texto actual
            string texto;
            texto = "//" + textBoxEscribirEnLogs.Text;

            string nuevoTexto = texto + "\r\n" + textoActual;

            //se guarda el nuevo texto
            StreamWriter sw = new StreamWriter(ruta);
            sw.Write(nuevoTexto);
            sw.Close();

            leerLogs();//actualiza los logs de la pantalla
            textBoxEscribirEnLogs.Text = "";
            botonOk.Select();
        }

        void formulario_FormClosed(object sender, FormClosedEventArgs e)
        {
            logs.addToLog("Se cierra la ventana de logs");
        }

        void botonCarpetaLogs_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(rutaDeLosLogs());
        }

        void botonOk_Click(object sender, EventArgs e)
        {
            formulario.Close();
            //logs.addToLog("Cerrada ventana de logs");
        }

        public void showFormulario()
        {
            logs.addToLog("Abierta ventana de logs");
            leerLogs();
            botonOk.Select();
            formulario.ShowDialog();
            
        }

        public void leerLogs()//lee los logs y los copia al txtbox
        {
            string ruta=@"C:\luso\Dropbox\mio\Programas\material\panelControl\logs";
            if(Directory.Exists(ruta))//se guarda en el directorio de material, junto con los otros logs
            {
                ruta=ruta+@"\"+fechaYhora.ristraFechaActual()+".lus";
                if(!File.Exists(ruta))//hay que crear el archivo
                {
                    FileStream archivo= File.Create(ruta);
                    archivo.Close();
                }
            }else//se utiliza una ruta interna
            {
                ruta="logs";
                if(!Directory.Exists(ruta)){//hay que crearlo
                    Directory.CreateDirectory(ruta);
                }
                ruta=ruta+@"\"+fechaYhora.ristraFechaActual()+".lus";

                if(!File.Exists(ruta)){//hay que crearlo
                    FileStream archivo= File.Create(ruta);
                    archivo.Close();
                }
            }

            string texto;
            StreamReader sr=new StreamReader(ruta);
             texto=sr.ReadToEnd();
             txtBox.Text = texto;
            sr.Close();
        }
        
        /// <summary>
        /// Añade una línea de texto con la hora y la fecha a los logs
        /// </summary>
        /// <param name="texto">texto a añadir</param>
        public static void addToLog(String texto)//añadir a los logs
        {
            string ruta=@"C:\luso\Dropbox\mio\Programas\material\panelControl\logs";
            if(Directory.Exists(ruta))//se guarda en el directorio de material, junto con los otros logs
            {
                ruta=ruta+@"\"+fechaYhora.ristraFechaActual()+".lus";
                if(!File.Exists(ruta))//hay que crear el archivo
                {
                    FileStream archivo= File.Create(ruta);
                    archivo.Close();
                }
            }else//se utiliza una ruta interna
            {
                ruta="logs";
                if(!Directory.Exists(ruta)){//hay que crearlo
                    Directory.CreateDirectory(ruta);
                }
                ruta=ruta+@"\"+fechaYhora.ristraFechaActual()+".lus";

                if(!File.Exists(ruta)){//hay que crearlo
                    FileStream archivo= File.Create(ruta);
                    archivo.Close();
                }
            }
            //primero se lee lo que hay
            string textoActual;
            StreamReader sr=new StreamReader(ruta);
            textoActual=sr.ReadToEnd();
            sr.Close();

            //se añade el texto actual
            texto=fechaYhora.fechaCortaDeHoy()+" "+fechaYhora.horaEscrita()+" - "+texto;

            string nuevoTexto=texto+"\r\n"+textoActual;

            //se guarda el nuevo texto
            StreamWriter sw=new StreamWriter(ruta);
            sw.Write(nuevoTexto);
            sw.Close();
        }//fin de la funcion addToLog


        public static string rutaDeLosLogs()//devuelve la carpeta donde están los logs
        {
            string ruta = @"C:\luso\Dropbox\mio\Programas\material\panelControl\logs";
            if (!Directory.Exists(ruta))//se guarda en el directorio de material, junto con los otros logs
            {
                ruta = "logs";
                if (!Directory.Exists(ruta))
                {//hay que crearlo
                    Directory.CreateDirectory(ruta);
                }
                
            }

            return ruta;
        }//fin de la función rutaDeLosLogs

    }//fin de la clase logs
    
}
