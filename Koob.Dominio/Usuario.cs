using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koob.Dominio
{
    public class Usuario
    {
        public int usu_codigo { get; set; }
        public string usu_nombre { get; set; }
        public string usu_username { get; set; }
        public string usu_password { get; set; }
        public string usu_correo { get; set; }
        public string usu_telefono { get; set; }
        public List<Libro> libros { get; set; }
    }
}
