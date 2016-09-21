using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koob.Dominio
{
    public class Libro
    {
        public int lib_codigo { get; set; }
        public string lib_isbn { get; set; }
        public string lib_descripcion { get; set; }
        public string lib_ubicacion { get; set; }
        public int usu_codigo { get; set; }
        public int cat_codigo { get; set; }
        public List<Foto> fotos { get; set; }
    }
}
