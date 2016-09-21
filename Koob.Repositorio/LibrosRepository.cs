using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koob.Entidades;
using dominio = Koob.Dominio;

namespace Koob.Repositorio
{
    public class LibrosRepository: RepositorioGenerico<libros>
    {
        public List<dominio.Libro> ObtenerUsuarios()
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
        public void InsertarUsuario(dominio.Libro libro)
        {
            AutoMapper.Mapper.CreateMap<dominio.Libro, libros>();
            var lib = AutoMapper.Mapper.Map<libros>(libro);
            Insert(lib);
            Save();
        }
    }
}
