using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koob.Vista.Models.API
{
    public class Informacion
    {
        public String title { get; set; }
        public String subtitle { get; set; }
        public String description { get; set; }
        public List<String> authors { get; set; }
        public Imagen imageLinks { get; set; }
    }
}