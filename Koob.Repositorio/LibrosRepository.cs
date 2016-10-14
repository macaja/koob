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
        public void InsertarLibro(dominio.Libro libro)
        {
            AutoMapper.Mapper.CreateMap<dominio.Libro, libros>();
            var lib = AutoMapper.Mapper.Map<libros>(libro);
            Insert(lib);
            Save();
        }
        public void eliminarLibroID(int id)
        {
            ReporteRepository reportesRepository = new ReporteRepository();
            reportesRepository.eliminarReporteID(id);
            Delete(id);
            Save();
        }
    }
}
