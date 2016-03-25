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
    /// gestiona un conjunto de notas 
    /// </summary>
    public class ListaDeNotas
    {
        ToolStripMenuItem contenedor;
        List<Nota> lista;

        public ListaDeNotas(ToolStripMenuItem conten)
        {
            lista = new List<Nota>();
            contenedor = conten;
        }

        /// <summary>
        /// ejecuta el formulario para añadir una nota a la lista
        /// </summary>
        public void addNotaFormulario()
        {
                        
            FormularioNotas form = new FormularioNotas("Nueva nota");
            logs.addToLog("abierto formulario para crear notas");
            form.mostrarDialogo();
            if (form.formularioOk())
            {

                string ruta;//le añado una ruta con forma de ristra para evitar duplicidades
                ruta = fechaYhora.ristraActual() + ".lus";
                Nota nuevaNota = new Nota(form.getTitulo(), form.getTexto(), ruta, contenedor);
                lista.Add(nuevaNota);
                logs.addToLog("se crea una nueva nota con el título " + form.getTitulo());
            }
        }

        /// <summary>
        /// lee todos los archivos de notas guardados y los añade a la lista
        /// </summary>
        public void leerNotas()
        {
            string rutaCarpeta = @"Guardar\notas";

            if (Directory.Exists(rutaCarpeta))
            {
                string[] archivos = Directory.GetFiles(rutaCarpeta, "*.lus");
                foreach (string arch in archivos)
                {
                    string rutaFinal = arch.Substring(arch.LastIndexOf(@"\") + 1);
                    Nota nuevaNota = new Nota(rutaFinal, contenedor);
                    lista.Add(nuevaNota);
                }


            }else{logs.addToLog("No se ha encontrado la carpeta de las alarmas");}

            
        }

    }//fin de la clase listaDeNotas

    /// <summary>
    /// información de una nota
    /// </summary>
    public class Nota
    {
        string titulo, texto,ruta;
        ToolStripMenuItem boton, leer, quitar, contenedor;

        /// <summary>
        /// constructor de nota nueva
        /// </summary>
        /// <param name="tituloNota">titulo que tendrá la nota</param>
        /// <param name="textoNota">texto que tendrá la nota</param>
        /// <param name="rutaNota">ruta en la que se almacena la nota</param>
        /// <param name="conten">toolstrip al que se asocian las notas</param>
        public Nota(string tituloNota, string textoNota, string rutaNota, ToolStripMenuItem conten)
        {
            titulo = tituloNota;
            texto = textoNota;
            ruta = rutaNota;
            contenedor = conten;

            crearBoton();
            guardarNota();
        }

        /// <summary>
        /// constructor que crea una alarma directamente a partir de la ruta
        /// </summary>
        /// <param name="rutaNota">ruta donde se almacena esta nota</param>
        /// /// <param name="conten">toolstrip al que se asocian las notas</param>
        public Nota(string rutaNota,ToolStripMenuItem conten)
        {
            ruta = rutaNota;

            string rutaCompleta = @"Guardar\notas\" + ruta;

            if (Directory.Exists("Guardar") && Directory.Exists(@"Guardar\notas") && File.Exists(rutaCompleta))
            {
                StreamReader sr = new StreamReader(rutaCompleta);
                titulo = sr.ReadLine();
                texto = sr.ReadToEnd();
                sr.Close();
            }
            else
            {
                titulo = "error";
                texto = "error";
            }

            contenedor = conten;
            crearBoton();

        }//final del segundo constructor

        /// <summary>
        /// metodo al que llaman los dos constructores para crear un botón
        /// </summary>
        public void crearBoton()
        {
            boton = new ToolStripMenuItem(titulo);
            contenedor.DropDownItems.Add(boton);

            leer = new ToolStripMenuItem("Leer/cambiar");
            quitar = new ToolStripMenuItem("Quitar");

            boton.DropDownItems.Add(leer);
            boton.DropDownItems.Add(quitar);

            leer.Click += new EventHandler(leer_Click);
            quitar.Click += new EventHandler(quitar_Click);

        }

        /// <summary>
        /// quita el botón y elimina el archivo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void quitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea eliminar la nota " + titulo + "?", "Eliminar nota " + titulo, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string rutaCompleta = @"Guardar\notas\" + ruta;
                if (File.Exists(rutaCompleta))
                {
                    File.Delete(rutaCompleta);
                }

                contenedor.DropDownItems.Remove(boton);

                logs.addToLog("Se elimina la nota " + titulo);
                //¡¡sigue en la lista hasta que se cierre el programa!!
            }
            else
            {
                logs.addToLog("Se decide no eliminar la nota " + titulo);
            }
        }

        void leer_Click(object sender, EventArgs e)
        {
            logs.addToLog("leida nota " + titulo);
            FormularioNotas formulario = new FormularioNotas(this);
            

            formulario.mostrarFormulario();

            /*if (formulario.formularioOk())
            {
                
                cambiarContenidoNota(formulario.getTitulo(), formulario.getTexto());
                guardarNota();
            }
            */
        }

        /// <summary>
        /// devuelve el título de la nota
        /// </summary>
        public string getTitulo(){return titulo;}

        /// <summary>
        /// devuelve el texto de la nota
        /// </summary>
        /// <returns></returns>
        public string getTexto() { return texto; }

        /// <summary>
        /// devuelve la ruta donde se almacena la nota
        /// </summary>
        /// <returns></returns>
        public string getRuta() { return ruta; }

        /// <summary>
        /// Cambia el título de la nota
        /// </summary>
        /// <param name="nuevoTitulo">nuevo titulo que se le va a dar a la nota</param>
        public void setTitulo(string nuevoTitulo) { titulo = nuevoTitulo; }

        /// <summary>
        /// Cambia el texto de la nota
        /// </summary>
        /// <param name="nuevoTexto">nuevo texto que contendrá la nota</param>
        public void setTexto(string nuevoTexto) { texto = nuevoTexto; }

        /// <summary>
        /// cambia la ruta donde se almacena la nota ¡¡Manipular con cuidado!!
        /// </summary>
        /// <param name="nuevaRuta"></param>
        public void setRuta(string nuevaRuta) { ruta = nuevaRuta; }

        /// <summary>
        /// guarda la nota en la ruta establecida
        /// </summary>
        public void guardarNota()
        {
            //se guardará todo en archivos en la carpeta guardar\notas

            string rutaCompleta = @"Guardar\notas\" + ruta;

            if (!Directory.Exists("Guardar"))
            {
                Directory.CreateDirectory("Guardar");
            }

            if(!Directory.Exists(@"Guardar\notas\"))
            {
                Directory.CreateDirectory(@"Guardar\notas\");
            }

            if(!File.Exists(rutaCompleta)){
                FileStream fs=File.Create(rutaCompleta);
                fs.Close();
            }

            StreamWriter sw=new StreamWriter(rutaCompleta);
            sw.Write("");
            sw.WriteLine(titulo);
            sw.WriteLine(texto);
            sw.Close();
        }//fin de la función guardarNota

        /// <summary>
        /// cambia el título y el texto de la nota y la guarda
        /// </summary>
        /// <param name="nuevoTitulo">nuevo título de la nota</param>
        /// <param name="nuevoTexto">nuevo texto de la nota</param>
        public void cambiarContenidoNota(string nuevoTitulo, string nuevoTexto)
        {
            titulo = nuevoTitulo;
            texto = nuevoTexto;
            boton.Text = titulo;
            guardarNota();
        }


    }//fin de la clase nota

    
    /// <summary>
    /// formulario para crear o modificar notas
    /// </summary>
    public class FormularioNotas
    {
        Form formulario;
        Label labelTitulo;
        TextBox textBoxTitulo, textBoxTexto;
        Button botonOk, botonCancelar;
        Boolean cambiado, creacion;
        Nota notaOrigen;
        string tituloNota, textoNota;
        

        /// <summary>
        /// crea un formulario nuevo
        /// </summary>
        /// <param name="titulo">título del formulario, para saber si es una nota nueva o es un cambio</param>
        public FormularioNotas(Nota notaQueCreaFormulario)
        {
            //crear el formulario
            formulario = new Form();
            notaOrigen = notaQueCreaFormulario;
            formulario.Text = notaOrigen.getTitulo();
            formulario.Height = 530;
            formulario.Width = 400;
            formulario.MinimumSize = formulario.Size;
            formulario.Width = 600;
            formulario.Height = 555;
            
            //crear la etiqueta de titulo
            labelTitulo = new Label();
            labelTitulo.Text = "Título:";
            formulario.Controls.Add(labelTitulo);
            labelTitulo.AutoSize = true;
            labelTitulo.Top = 5;
            

            //crear el textbox de titulo
            textBoxTitulo = new TextBox();
            formulario.Controls.Add(textBoxTitulo);
            textBoxTitulo.Top = labelTitulo.Bottom + 5;
            textBoxTitulo.Text = notaOrigen.getTitulo();
            

            //crear el textbox del contenido
            textBoxTexto = new TextBox();
            formulario.Controls.Add(textBoxTexto);
            textBoxTexto.Top = textBoxTitulo.Bottom + 10;
            textBoxTexto.Multiline = true;
            textBoxTexto.ScrollBars = ScrollBars.Both;
            textBoxTexto.Text = notaOrigen.getTexto();
           

            //crear el boton de aceptar
            botonOk = new Button();
            botonOk.Text = "Aceptar";
            formulario.Controls.Add(botonOk);
            botonOk.Click += new EventHandler(botonOk_Click);

            //crear el boton de cancelar
            botonCancelar = new Button();
            botonCancelar.Text = "Cancelar";
            formulario.Controls.Add(botonCancelar);
            botonCancelar.Click += new EventHandler(botonCancelar_Click);

            colocarControles();
            
            cambiado = false;

            creacion = false;//este constructor es para modificar una nota ya creada


            formulario.ResizeEnd += new EventHandler(formulario_ResizeEnd);

        }//fin del constructor que coge una nota como argumento

        public FormularioNotas(String tituloDelFormulario)
        {
            //crear el formulario
            formulario = new Form();
            
            formulario.Text = tituloDelFormulario;
            formulario.Height = 530;
            formulario.Width = 400;
            formulario.MinimumSize = formulario.Size;
            formulario.Width = 600;
            formulario.Height = 555;

            //crear la etiqueta de titulo
            labelTitulo = new Label();
            labelTitulo.Text = "Título:";
            formulario.Controls.Add(labelTitulo);
            labelTitulo.AutoSize = true;
            labelTitulo.Top = 5;


            //crear el textbox de titulo
            textBoxTitulo = new TextBox();
            formulario.Controls.Add(textBoxTitulo);
            textBoxTitulo.Top = labelTitulo.Bottom + 5;
            


            //crear el textbox del contenido
            textBoxTexto = new TextBox();
            formulario.Controls.Add(textBoxTexto);
            textBoxTexto.Top = textBoxTitulo.Bottom + 10;
            textBoxTexto.Multiline = true;
            textBoxTexto.ScrollBars = ScrollBars.Both;
            


            //crear el boton de aceptar
            botonOk = new Button();
            botonOk.Text = "Aceptar";
            formulario.Controls.Add(botonOk);
            botonOk.Click += new EventHandler(botonOk_Click);

            //crear el boton de cancelar
            botonCancelar = new Button();
            botonCancelar.Text = "Cancelar";
            formulario.Controls.Add(botonCancelar);
            botonCancelar.Click += new EventHandler(botonCancelar_Click);

            colocarControles();

            cambiado = false;

            creacion = true;//este constructor es para crear una nueva nota


            formulario.ResizeEnd += new EventHandler(formulario_ResizeEnd);

        }

        void botonCancelar_Click(object sender, EventArgs e)
        {
            formulario.Close();
        }

        void formulario_ResizeEnd(object sender, EventArgs e)
        {
            colocarControles();
            //labelTitulo.Text = formulario.Height + " - " + formulario.Width;

        }

        /// <summary>
        /// ajusta las posiciones de los controles
        /// </summary>
        public void colocarControles()
        {
            int margen, largoCheckBoxes;
            margen = Convert.ToInt32(0.02 * formulario.Width);
            largoCheckBoxes=Convert.ToInt32(0.94*formulario.Width);
            
            labelTitulo.Left = margen;
            textBoxTitulo.Left = margen;
            textBoxTexto.Left = margen;
            botonOk.Left = margen;

            textBoxTitulo.Width = largoCheckBoxes;
            textBoxTexto.Width = largoCheckBoxes;

            textBoxTexto.Height = Convert.ToInt32(0.75*formulario.Height);
            botonOk.Top = textBoxTexto.Bottom + 10;

            botonCancelar.Top = botonOk.Top;
            botonCancelar.Left = margen + botonOk.Width + 20;
        }

        void botonOk_Click(object sender, EventArgs e) //si no es creación modifica la nota, si no símplemente asigna parámetros
        {
            cambiado = true;
            
            tituloNota = textBoxTitulo.Text;
            textoNota=textBoxTexto.Text;

            if (!creacion)
            {
                notaOrigen.cambiarContenidoNota(textBoxTitulo.Text, textBoxTexto.Text);
                logs.addToLog("Cambiada nota " + notaOrigen.getTitulo());                
            }
            formulario.Close();

        }

        /// <summary>
        /// muestra el formulario pero permite hacer cosas mientras está abierto
        /// </summary>
        public void mostrarFormulario()
        {
            cambiado = false;
            formulario.Show();//no se pone showDialog para que permita dejar abierta la nota y tocar el control panel
            
        }

        /// <summary>
        /// muestra el formulario pero no permite hacer otras cosas hasta que se cierra
        /// </summary>
        public void mostrarDialogo()
        {
            cambiado = false;
            formulario.ShowDialog();//para la creación inicial de la nota
        }

        /// <summary>
        /// devuelve true si se ha dado al botón aceptar en el formulario
        /// </summary>
        /// <returns></returns>
        public Boolean formularioOk() { return cambiado; }

        /// <summary>
        /// devuelve el título introducido
        /// </summary>
        /// <returns></returns>
        public string getTitulo() { return tituloNota; }

        /// <summary>
        /// introduce el título en el textbox titulo
        /// </summary>
        /// <param name="titulo">título de la nota</param>
        public void setTitulo(string titulo) { textBoxTitulo.Text = titulo; }

        /// <summary>
        /// devuelve el texto de la nota
        /// </summary>
        public string getTexto() { return textoNota; }

        /// <summary>
        /// introduce el texto en el cuadro
        /// </summary>
        /// <param name="texto">texto de la nota</param>
        public void setTexto(string texto) { textBoxTexto.Text = texto; }

    }//fin de la clase formularioNotas

}
