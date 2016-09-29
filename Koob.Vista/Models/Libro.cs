using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Koob.Vista.Models
{
    public class Libro
    {
        [Required]
        [Display(Name = "Codigo ISBN")]
        public string lib_isbn { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Debe contener una breve {0} de al menos {2} palabras.", MinimumLength = 15)]
        [Display(Name = "Descripcion")]
        public string lib_descripcion { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Debe introducir su {0}, Contiene como minimo {2} digitos.", MinimumLength = 10)]
        [Display(Name = "Ubicacion")]
        public string lib_ubicacion { get; set; }
        public string usu_email { get; set; }
        [Display(Name = "Categoria")]
        public int cat_codigo { get; set; }
        public string lib_catNombre { get; set; }
        
    }
}