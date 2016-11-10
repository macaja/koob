using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koob.Dominio
{
    public class Intereses
    {
        public int int_codigo { get; set; }
        public string usu_email_interesado { get; set; }
        public int lib_codigo { get; set; }
        public string usu_email_dueño { get; set; }
        public Libro libro { get; set; }
    }
}
