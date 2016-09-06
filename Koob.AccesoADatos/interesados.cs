namespace Koob.AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("koob.interesados")]
    public partial class interesados
    {
        [Key]
        public int int_codigo { get; set; }

        public int usu_codigo_interesado { get; set; }

        public int lib_codigo { get; set; }

        public int usu_codigo_dueño { get; set; }

        public virtual libros libros { get; set; }

        public virtual usuarios usuarios { get; set; }
    }
}
