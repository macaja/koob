namespace Koob.AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("koob.comentarios")]
    public partial class comentarios
    {
        [Key]
        public int com_codigo { get; set; }

        [Required]
        [StringLength(2000)]
        public string com_comentario { get; set; }

        public int usu_codigo { get; set; }

        public virtual usuarios usuarios { get; set; }
    }
}
