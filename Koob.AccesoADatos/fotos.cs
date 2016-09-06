namespace Koob.AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("koob.fotos")]
    public partial class fotos
    {
        [Key]
        public int fot_codigo { get; set; }

        [Required]
        public byte[] fot_foto1 { get; set; }

        public byte[] fot_foto2 { get; set; }

        public byte[] fot_foto3 { get; set; }

        public byte[] fot_foto4 { get; set; }

        public byte[] fot_foto5 { get; set; }

        public int lib_codigo { get; set; }

        public int usu_codigo { get; set; }

        public virtual libros libros { get; set; }
    }
}
