namespace Koob.AccesoADatos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Datos : DbContext
    {
        public Datos()
            : base("name=Datos")
        {
        }

        public virtual DbSet<administradores> administradores { get; set; }
        public virtual DbSet<calificaciones> calificaciones { get; set; }
        public virtual DbSet<categorias> categorias { get; set; }
        public virtual DbSet<comentarios> comentarios { get; set; }
        public virtual DbSet<deseos> deseos { get; set; }
        public virtual DbSet<fotos> fotos { get; set; }
        public virtual DbSet<interesados> interesados { get; set; }
        public virtual DbSet<libros> libros { get; set; }
        public virtual DbSet<reportes> reportes { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<administradores>()
                .Property(e => e.adm_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<administradores>()
                .Property(e => e.adm_password)
                .IsUnicode(false);

            modelBuilder.Entity<administradores>()
                .HasMany(e => e.reportes)
                .WithRequired(e => e.administradores)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<categorias>()
                .Property(e => e.cat_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<categorias>()
                .HasMany(e => e.libros)
                .WithRequired(e => e.categorias)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<comentarios>()
                .Property(e => e.com_comentario)
                .IsUnicode(false);

            modelBuilder.Entity<libros>()
                .Property(e => e.lib_isbn)
                .IsUnicode(false);

            modelBuilder.Entity<libros>()
                .Property(e => e.lib_descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<libros>()
                .Property(e => e.lib_ubicacion)
                .IsUnicode(false);

            modelBuilder.Entity<libros>()
                .HasMany(e => e.fotos)
                .WithRequired(e => e.libros)
                .HasForeignKey(e => new { e.lib_codigo, e.usu_codigo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<libros>()
                .HasMany(e => e.interesados)
                .WithRequired(e => e.libros)
                .HasForeignKey(e => new { e.lib_codigo, e.usu_codigo_dueño })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.usu_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.usu_username)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.usu_password)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.usu_correo)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .Property(e => e.usu_telefono)
                .IsUnicode(false);

            modelBuilder.Entity<usuarios>()
                .HasMany(e => e.calificaciones)
                .WithRequired(e => e.usuarios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuarios>()
                .HasMany(e => e.comentarios)
                .WithRequired(e => e.usuarios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuarios>()
                .HasMany(e => e.deseos)
                .WithRequired(e => e.usuarios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuarios>()
                .HasMany(e => e.interesados)
                .WithRequired(e => e.usuarios)
                .HasForeignKey(e => e.usu_codigo_interesado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuarios>()
                .HasMany(e => e.libros)
                .WithRequired(e => e.usuarios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuarios>()
                .HasMany(e => e.reportes)
                .WithRequired(e => e.usuarios)
                .WillCascadeOnDelete(false);
        }
    }
}
