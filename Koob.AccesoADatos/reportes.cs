namespace Koob.AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("koob.reportes")]
    public partial class reportes
    {
        [Key]
        public int rep_codigo { get; set; }

        public int usu_codigo { get; set; }

        public int adm_codigo { get; set; }

        public virtual administradores administradores { get; set; }

        public virtual usuarios usuarios { get; set; }
    }
}
