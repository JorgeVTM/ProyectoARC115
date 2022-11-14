using ARC115ProyectoBiblioteca.entityController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARC115ProyectoBiblioteca
{
    public partial class Base : Form
    {
        //Inicializar formulario
        /*
        frmLibros frmlibros;
        frmInicio frminicio;
        frmUsuarios frmusuarios;
        frmPrestamos frmprestamos;
        frmDevoluciones frmdevoluciones;
        */

        public Base()
        {
            InitializeComponent();
            /*
            formlibros = new frmLibros();
            frmHome = new frmHome();
            
            abrirFormulario(frmHome);
            */
            /*
            frmprestamos = new frmPrestamos();
            frmdevoluciones = new frmDevoluciones();
            frminicio = new frmInicio();
            frmusuarios = new frmUsuarios();
            frmlibros = new frmLibros();
            */
            abrirFormulario(new frmInicio());
        }

        //Termina la ejecución de la aplicación
        private void btnSalir_Click(object sender, EventArgs e)
        {
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
            abrirFormulario(new frmUsuarios());
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
    }
}
