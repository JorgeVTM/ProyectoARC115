using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARC115ProyectoBiblioteca.entity
{
    public class Libro
    {
        public int id { get; set; }
        public string ISDBN { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public string editorial { get; set; }
        public string categoria { get; set; }
        public DateTime fechapublicacion { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0} Titulo: {1}", id, titulo);
        }
    }
}
