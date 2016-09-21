using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Koob.Vista.Models
{
    public class Libro
    {
        public int lib_codigo { get; set; }
        [Required]
        [Key]
        [Display(Name = "Codigo ISBN")]
        public string lib_isbn { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Debe contener una breve {0} de al menos {2} palabras.", MinimumLength = 15)]
        [Display(Name = "Descripcion")]
        public string lib_descripcion { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [Display(Name = "Ubicacion")]
        public string lib_ubicacion { get; set; }
        public int usu_codigo { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public int cat_codigo { get; set; }
        public List<Foto> fotos { get; set; }
    }
}