namespace Koob.AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("koob.deseos")]
    public partial class deseos
    {
        [Key]
        public int des_codigo { get; set; }

        public int usu_codigo { get; set; }

        public int lib_codigo { get; set; }

        public virtual usuarios usuarios { get; set; }
    }
}
