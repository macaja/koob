namespace Koob.AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("koob.libros")]
    public partial class libros
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public libros()
        {
            fotos = new HashSet<fotos>();
            interesados = new HashSet<interesados>();
        }

        [Key]
        [Column(Order = 0)]
        public int lib_codigo { get; set; }

        [Required]
        [StringLength(45)]
        public string lib_isbn { get; set; }

        [Required]
        [StringLength(500)]
        public string lib_descripcion { get; set; }

        [Required]
        [StringLength(50)]
        public string lib_ubicacion { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int usu_codigo { get; set; }

        public int cat_codigo { get; set; }

        public virtual categorias categorias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fotos> fotos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<interesados> interesados { get; set; }

        public virtual usuarios usuarios { get; set; }
    }
}
