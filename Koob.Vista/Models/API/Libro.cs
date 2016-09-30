using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koob.Vista.Models.API
{
    public class Libro
    {
        public List<Caracteristicas> items { get; set; }
        public int totalItems { get; set; }
    }
}