﻿using System;
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
        public string usu_email { get; set; }
        public int cat_codigo { get; set; }
        public string lib_autores { get; set; }
        public string lib_imagen { get; set; }
        public string lib_sinopsis { get; set; }
        public string lib_titulo { get; set; }
        public string lib_catNombre { get; set; }
    }
}
