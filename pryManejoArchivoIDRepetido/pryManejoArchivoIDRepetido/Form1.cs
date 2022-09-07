using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace pryManejoArchivoIDRepetido
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool puedograbar = true;
            //el código ya existe?
            StreamReader objLeerArchivo = new StreamReader("./bdProducto.txt");

            //que sea distinto al final, entra y repite el còdigo
            while (!objLeerArchivo.EndOfStream)
            {
                string[] vecLeido = objLeerArchivo.ReadLine().Split(Convert.ToChar(","));

                if (vecLeido[0] == txtCodigo.Text)
                {
                    MessageBox.Show("Còdigo repetido, vuelva a ingresar");
                    txtCodigo.Focus();
                    txtCodigo.SelectAll();
                    puedograbar = false;
                    //bandera donde diga que el codigo esta repetido
                }             
            }
            objLeerArchivo.Close();


            //preguntar
            if (puedograbar == true)
            {

                //abrir archivo, indicar que sea para editar
                StreamWriter objEscribir = new StreamWriter("./bdProducto.txt", true);

                //objEscribir.Write(txtCodigo.Text);
                //objEscribir.Write(txtNombre.Text);

                //concatenar y agrego una coma
                objEscribir.WriteLine(txtCodigo.Text + "," + txtNombre.Text);

                objEscribir.Close();
                MessageBox.Show("Registrado");

                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtCodigo.Focus();

                llamarAListar();

            }

          
       
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("./bdProducto.txt"))
            {
                //MessageBox.Show("Existe!");
            }
            else
            {
                File.Create("./bdProducto.txt");
                //MessageBox.Show("no lo encontramos maestro,,,");
            }

            //File.Exists("./bdProducto.txt");
            //
            llamarAListar();
        }


        private void llamarAListar()
        {
            listBox1.Items.Clear();

            //abro el archivo, lo leo y muestro
            StreamReader objLeerArchivo = new StreamReader("./bdProducto.txt");

            //que sea distinto al final, entra y repite el còdigo
            while (!objLeerArchivo.EndOfStream)
            {
                //string textoLeido = objLeerArchivo.ReadLine();

                //substring sirve para leer de una cadena de caracteres
                //desde una posicion inicial hasta la cantidad que indique
                //listBox1.Items.Add(textoLeido.Substring(0,2));

                //creame un vector en base a lo que lees
                //split es separar, separame por el caracter "," (còdigo ascii)
                string[] vecLeido = objLeerArchivo.ReadLine().Split(Convert.ToChar(","));
                listBox1.Items.Add(vecLeido[0].ToString());

            }

            //cierro el archivo
            objLeerArchivo.Close();
        }

    }
}
