using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Koob.Vista.Models
{
    public class Foto
    {

        [Required]
        [Display(Name = "Foto1")]
        public byte[] fot_foto1 { get; set; }
        [Display(Name = "Foto2")]
        public byte[] fot_foto2 { get; set; }
        [Display(Name = "Foto3")]
        public byte[] fot_foto3 { get; set; }
        [Display(Name = "Foto4")]
        public byte[] fot_foto4 { get; set; }
        [Display(Name = "Foto5")]
        public byte[] fot_foto5 { get; set; }
    }
}