using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koob.Entidades;
using dominio = Koob.Dominio;
using System.Data.Entity;

namespace Koob.Repositorio
{
    public class LibrosRepository: RepositorioGenerico<libros>
    {
        public List<dominio.Libro> ObtenerLibros()
        {

            AutoMapper.Mapper.CreateMap<libros, dominio.Libro>();
            return new List<dominio.Libro>(ObtenerTodos().AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Libro>)).ToList();
        }
        public dominio.Libro ObtenerPorID(int id)
        {
            var libro = GetByID(id);

            AutoMapper.Mapper.CreateMap<libros, dominio.Libro>();
            return AutoMapper.Mapper.Map<dominio.Libro>(libro);
        }
        public dominio.Libro obtenerLibPorID(int id)
        {
            using (var context = new KoobEntities())
            {
                var lib = context.libros.Where(x => x.lib_codigo==id).FirstOrDefault();
                AutoMapper.Mapper.CreateMap<libros, dominio.Libro>();
                var libro = AutoMapper.Mapper.Map<dominio.Libro>(lib);
                return libro;
            }
        }


        private libros obtenerPorIDParaBorrar(int id)
        {
            using (var context = new KoobEntities())
            {
                var lib = context.libros.Where(x => x.lib_codigo == id).FirstOrDefault(); 
                return lib;
            }
        }

        public void InsertarLibro(dominio.Libro libro)
        {
            AutoMapper.Mapper.CreateMap<dominio.Libro, libros>();
            var lib = AutoMapper.Mapper.Map<libros>(libro);
            Insert(lib);
            Save();
        }

        public void eliminarLibroID(int id)
        {
            libros libro = obtenerPorIDParaBorrar(id);
            Delete(libro);
            Save();
        }
        public List<dominio.Libro> obtenerLibroPorTitulo(String titulo)
        {
            IQueryable<libros> libros;
            AutoMapper.Mapper.CreateMap<libros, dominio.Libro>();
            using (var context = new KoobEntities())
            {

                libros = context.libros.Where(x => x.lib_titulo == titulo);
                return new List<dominio.Libro>(libros.AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Libro>)).ToList();
            }
        }
        public List<dominio.Libro> obtenerLibroPorAutor(string autor)
        {
            IQueryable<libros> libros;
            AutoMapper.Mapper.CreateMap<libros, dominio.Libro>();
            using (var context = new KoobEntities())
            {

                libros = context.libros.Where(x => x.lib_autores == autor);
                return new List<dominio.Libro>(libros.AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Libro>)).ToList();
            }            
        }
        public List<dominio.Libro> obtenerLibroPorCategoria(string categoria)
        {
            IQueryable<libros> libros;
            AutoMapper.Mapper.CreateMap<libros, dominio.Libro>();
            using (var context = new KoobEntities())
            {

                libros = from u in context.libros
                         join v in context.categorias on u.cat_codigo equals v.cat_codigo
                         where v.cat_nombre == categoria
                         select u;
                return new List<dominio.Libro>(libros.AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Libro>)).ToList();
            }
        }
        public List<dominio.Libro> obtenerLibroPorUsuario(string usuario)
        {
            IQueryable<libros> libros;
            AutoMapper.Mapper.CreateMap<libros, dominio.Libro>();
            using (var context = new KoobEntities())
            {

                libros = from u in context.libros
                         where u.usu_email == usuario
                         select u;
                return new List<dominio.Libro>(libros.AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Libro>)).ToList();
            }
        }
    }
}
