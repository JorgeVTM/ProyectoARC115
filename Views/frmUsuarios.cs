using ARC115ProyectoBiblioteca.entity;
using ARC115ProyectoBiblioteca.entityController;
using ARC115ProyectoBiblioteca.libs;
using Org.BouncyCastle.Asn1.Crmf;
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
    public partial class frmUsuarios : Form
    {
        //Variable global
        int id;
        SerialPort serialPort = null;

        public frmUsuarios(SerialPort serialPort)
        {
            InitializeComponent();
            recargarTabla();
            this.serialPort = serialPort;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            Usuario usuario = new Usuario();
            try
            {
                usuario.nombre = txtNombre.Text;
                usuario.apellido = txtApellido.Text;
                usuario.carnet = txtCarnet.Text;
                usuario.fechanac = dataFecha.Value;
                usuario.correo = txtCorreo.Text;
                usuario.dui = txtDUI.Text;
                usuario.telefono = txtTelefono.Text;
                usuario.rifd = txtRIFD.Text;
                
                if (id.Equals(null) || id.Equals(0))
                {
                    new UsuarioControlle().addUsuario(usuario);
                    MessageBox.Show("Usuario agregado exitosamente");
                    recargarTabla();
                    new ClearControls().Clean(this);
                }
                else
                {
                    usuario.id = this.id;
                    new UsuarioControlle().updateUsuario(usuario);
                    MessageBox.Show("Usuario guardado exitosamente");
                    recargarTabla();
                    this.id = 0;
                    new ClearControls().Clean(this);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void recargarTabla()
        {
            tablaUsuarios.DataSource = new UsuarioControlle().findUsuariosTable();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!id.Equals(null) || !id.Equals(0))
                {
                    Usuario usuario = new UsuarioControlle().findUsuario(this.id);
                    new UsuarioControlle().deleteUsuario(usuario);
                    MessageBox.Show("Usuario eliminado exitosamente");
                    recargarTabla();
                    this.id = 0;
                    new ClearControls().Clean(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tablaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow tabla = tablaUsuarios.Rows[e.RowIndex];
                txtNombre.Text = tabla.Cells["nombre"].Value.ToString();
                txtApellido.Text = tabla.Cells["apellido"].Value.ToString();
                txtCarnet.Text = tabla.Cells["carnet"].Value.ToString();
                dataFecha.Value = DateTime.Parse(tabla.Cells["fecha"].Value.ToString());
                txtCorreo.Text = tabla.Cells["correo"].Value.ToString();
                txtDUI.Text = tabla.Cells["dui"].Value.ToString();
                txtTelefono.Text = tabla.Cells["telefono"].Value.ToString();
                txtRIFD.Text = tabla.Cells["rifd"].Value.ToString();
                id = int.Parse(tabla.Cells["id"].Value.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void btnEscaner_Click(object sender, EventArgs e)
        {
            txtRIFD.Clear();
            try
            {
                if(serialPort != null)
                {
                    txtRIFD.Text = serialPort.ReadExisting();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                serialPort.Close();
            }
        }
    }
}
