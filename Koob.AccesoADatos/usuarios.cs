namespace Koob.AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("koob.usuarios")]
    public partial class usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuarios()
        {
            calificaciones = new HashSet<calificaciones>();
            comentarios = new HashSet<comentarios>();
            deseos = new HashSet<deseos>();
            interesados = new HashSet<interesados>();
            libros = new HashSet<libros>();
            reportes = new HashSet<reportes>();
        }

        [Key]
        public int usu_codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string usu_nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string usu_username { get; set; }

        [Required]
        [StringLength(50)]
        public string usu_password { get; set; }

        [Required]
        [StringLength(100)]
        public string usu_correo { get; set; }

        [Required]
        [StringLength(20)]
        public string usu_telefono { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<calificaciones> calificaciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<comentarios> comentarios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deseos> deseos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<interesados> interesados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<libros> libros { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reportes> reportes { get; set; }
    }
}
