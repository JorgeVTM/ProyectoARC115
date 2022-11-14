using ARC115ProyectoBiblioteca.entity;
using ARC115ProyectoBiblioteca.entityController;
using ARC115ProyectoBiblioteca.libs;
using System;
using System.Windows.Forms;

namespace ARC115ProyectoBiblioteca
{
    public partial class frmPrestamos : Form
    {
        //Variable global
        int id;

        public frmPrestamos()
        {
            InitializeComponent();
            recargarTabla();
            recargarcbx();
        }

        public void recargarTabla()
        {
            tablaPrestamos.DataSource = new LibrosPrestamosController().findPrestamosTable();
        }

        public void recargarcbx()
        {
            foreach (Libro libro in new LibroController().findLibros())
            {
                cbLibros.Items.Add(libro);
            }
            foreach (Usuario usuario in new UsuarioControlle().findUsuarios())
            {
                cbUsuario.Items.Add(usuario);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            LibrosPrestamos prestamos = new LibrosPrestamos();
            try
            {
                if(DateTime.Compare(dateFechadev.Value, dateFechapres.Value) > 0)
                {
                    prestamos.pklibro = (Libro)cbLibros.SelectedItem;
                    prestamos.pkusuario = (Usuario)cbUsuario.SelectedItem;
                    prestamos.fechaPrestamo = dateFechapres.Value;
                    prestamos.fechaDevolucion = dateFechadev.Value;
                    prestamos.estado = 1;
                    new LibrosPrestamosController().addPrestamo(prestamos);
                    MessageBox.Show("Prestamo generado exitosamente");
                    recargarTabla();
                    new ClearControls().Clean(panel2);
                }
                else
                {
                    MessageBox.Show("La fecha de devolución no puede ser menor a la fecha de prestamo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tablaPrestamos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int pklibro, pkusuario;
            try
            {
                DataGridViewRow tabla = tablaPrestamos.Rows[e.RowIndex];
                //cbLibros.SelectedItem =

                pklibro = int.Parse(tabla.Cells["pklibro"].Value.ToString());
                Libro libro = new LibroController().findLibro(pklibro);
                
                pkusuario = int.Parse(tabla.Cells["pklibro"].Value.ToString());
                Usuario usuario = new UsuarioControlle().findUsuario(pkusuario);

                this.id = int.Parse(tabla.Cells["id"].Value.ToString());
                dateFechapres.Value = DateTime.Parse(tabla.Cells["fechaprestamo"].Value.ToString());
                dateFechadev.Value = DateTime.Parse(tabla.Cells["fechadevolucion"].Value.ToString());
                txtLibro.Text = libro.ToString();
                txtUsuario.Text = usuario.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!id.Equals(null) || !id.Equals(0))
                {
                    LibrosPrestamos prestamo = new LibrosPrestamosController().findPrestamo(this.id);
                    new LibrosPrestamosController().deletePrestamo(prestamo);
                    MessageBox.Show("prestamo eliminado exitosamente");
                    recargarTabla();
                    this.id = 0;
                    new ClearControls().Clean(panel2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
