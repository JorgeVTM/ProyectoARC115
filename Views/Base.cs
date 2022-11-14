using ARC115ProyectoBiblioteca.entityController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARC115ProyectoBiblioteca
{
    public partial class Base : Form
    {

        SerialPort serialPort = null;

        public Base()
        {
            InitializeComponent();
            Array myPort = SerialPort.GetPortNames();
            foreach(Object port in myPort)
            {
                cbPort.Items.Add(port);
            }
            abrirFormulario(new frmInicio());
        }

        //Termina la ejecución de la aplicación
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(serialPort != null)
            {
                serialPort.Close();
            }
            Application.Exit();
        }


        //Cierra la conexión con la base de datos
        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Ejecución de comandos al presionar cada botón del panel lateral

        //Acciones que se ejecutan por defecto al abrir el formulario
        public void abrirFormulario(object frmHijo)
        {
            if (this.pnlContenedor.Controls.Count > 0)
            {
                this.pnlContenedor.Controls.RemoveAt(0);
            }

            Form subformulario = frmHijo as Form;

            subformulario.TopLevel = false;
            subformulario.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(subformulario);
            this.pnlContenedor.Tag = subformulario;
            subformulario.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmInicio());

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmUsuarios(serialPort));
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmLibros());
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmPrestamos());
        }

        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            abrirFormulario(new frmDevoluciones());
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.PortName = cbPort.SelectedItem.ToString();

            try
            {
                serialPort.Open();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
