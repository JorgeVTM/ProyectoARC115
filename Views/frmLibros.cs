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
    public partial class frmLibros : Form
    {
        //Variable global
        int id;

        public frmLibros()
        {
            InitializeComponent();
            recargarTabla();
        }

        public void recargarTabla()
        {
            tablaLibros.DataSource = new LibroController().findLibrosTable();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Libro libro = new Libro();
            try
            {
                libro.ISBN= txtISBN.Text;
                libro.titulo = txtTitulo.Text;
                libro.fechapublicacion = dataFecha.Value;
                libro.autor = txtAutor.Text;
                libro.editorial = txtEditorial.Text;
                libro.categoria = txtCategoria.Text;

                if (id.Equals(null) || id.Equals(0))
                {
                    new LibroController().addLibro(libro);
                    MessageBox.Show("Libro agregado exitosamente");
                    recargarTabla();
                    new ClearControls().Clean(panel2);
                }
                else
                {
                    libro.id = this.id;
                    new LibroController().upadateLibro(libro);
                    MessageBox.Show("Libro guardado exitosamente");
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

        private void tablaLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow tabla = tablaLibros.Rows[e.RowIndex];
                txtISBN.Text = tabla.Cells["isbn"].Value.ToString();
                txtTitulo.Text = tabla.Cells["titulo"].Value.ToString();
                dataFecha.Value = DateTime.Parse(tabla.Cells["fechapublicacion"].Value.ToString());
                txtAutor.Text = tabla.Cells["autor"].Value.ToString();
                txtEditorial.Text = tabla.Cells["editorial"].Value.ToString();
                txtCategoria.Text = tabla.Cells["categoria"].Value.ToString();
                id = int.Parse(tabla.Cells["id"].Value.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if(int.TryParse(txtBuscar.Text, out this.id))
                {
                    Libro libro = new LibroController().findLibro(this.id);
                    txtISBN.Text = libro.ISBN;
                    txtTitulo.Text = libro.titulo;
                    dataFecha.Value = libro.fechapublicacion;
                    txtAutor.Text = libro.autor;
                    txtEditorial.Text = libro.editorial;
                    txtCategoria.Text = libro.categoria;
                }
                else
                {
                    MessageBox.Show("No ingreses letras a este campo, solo numeros ");
                }
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
                    Libro libro = new LibroController().findLibro(this.id);
                    new LibroController().deleteLibro(libro);
                    MessageBox.Show("Libro eliminado exitosamente");
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
