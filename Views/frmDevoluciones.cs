using ARC115ProyectoBiblioteca.entity;
using ARC115ProyectoBiblioteca.entityController;
using ARC115ProyectoBiblioteca.libs;
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
    public partial class frmDevoluciones : Form
    {
        public frmDevoluciones()
        {
            InitializeComponent();
            recargarTabla();
            recargarcbx();
        }

        public void recargarTabla()
        {
            tablaDevoluciones.DataSource = new DevolucionesController().findDevolucionesTable();
        }

        public void recargarcbx()
        {
            foreach (LibrosPrestamos prestamos in new LibrosPrestamosController().findPrestamos())
            {
                cbPrestamos.Items.Add(prestamos);
            }
        }

        private void cbPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Obtenemos el item objeto seleccionado
            ComboBox combo = (ComboBox)sender;
            LibrosPrestamos prestamos = (LibrosPrestamos)combo.SelectedItem;

            txtFechapres.Text = String.Format("{0:yyyy-MM-dd}", prestamos.fechaPrestamo);
            txtFechadev.Text = String.Format("{0:yyyy-MM-dd}", prestamos.fechaDevolucion);
            txtUsuario.Text = prestamos.pkusuario.ToString();
            txtLibro.Text = prestamos.pklibro.ToString();

            if(DateTime.Compare(prestamos.fechaDevolucion, DateTime.Now) > 0)
            {
                txtEstado.Text = "Prestamo al día";
            }
            else
            {
                txtEstado.Text = "Prestamo atrazado";
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                Devoluciones devoluciones = new Devoluciones();
                LibrosPrestamos prestamos = (LibrosPrestamos)cbPrestamos.SelectedItem;
                devoluciones.estado = 1;

                devoluciones.estado = 1;
                devoluciones.pklibro = prestamos.pklibro;
                devoluciones.pkusuario = prestamos.pkusuario;
                devoluciones.fechaEntrega = prestamos.fechaDevolucion;
                devoluciones.fechaPrestamo = prestamos.fechaPrestamo;

                new LibrosPrestamosController().deletePrestamo(prestamos);
                new DevolucionesController().addDevolucion(devoluciones);
                
                cbPrestamos.Items.Remove(prestamos);

                MessageBox.Show("Devolución generado exitosamente");
                recargarTabla();
                new ClearControls().Clean(panel2);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
