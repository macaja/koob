namespace Koob.AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("koob.calificaciones")]
    public partial class calificaciones
    {
        [Key]
        public int cal_codigo { get; set; }

        public int cal_valor { get; set; }

        public int usu_codigo { get; set; }

        public virtual usuarios usuarios { get; set; }
    }
}
