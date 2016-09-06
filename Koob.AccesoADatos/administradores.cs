namespace Koob.AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("koob.administradores")]
    public partial class administradores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public administradores()
        {
            reportes = new HashSet<reportes>();
        }

        [Key]
        public int adm_codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string adm_nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string adm_password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reportes> reportes { get; set; }
    }
}
