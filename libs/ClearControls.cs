using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARC115ProyectoBiblioteca.libs
{
    class ClearControls
    {
        private void Clean(Control.ControlCollection controlCollection)
        {
            foreach (Control control in controlCollection)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = string.Empty;
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
            }
        }

        #region//Metodos para limpiar controles dentro de otros controles...
        /// <summary>
        /// Limpia un Formulario
        /// </summary>
        /// <param name="form">Recibe un formulario</param>
        public void Clean(Form form)
        {
            Clean(form.Controls);
        }
        /// <summary>
        /// Limpia un Panel
        /// </summary>
        /// <param name="panel">Recibe un control de tipo Panel</param>
        public void Clean(Panel panel)
        {
            Clean(panel.Controls);
        }
        /// <summary>
        /// Limpia un GroupBox
        /// </summary>
        /// <param name="groupBox">Recibe un control de tipo GroupBox</param>
        public void Clean(GroupBox groupBox)
        {
            Clean(groupBox.Controls);
        }
        #endregion
    }
}
