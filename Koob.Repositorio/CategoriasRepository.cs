using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koob.Entidades;
using dominio = Koob.Dominio;

namespace Koob.Repositorio
{
    public class CategoriasRepository: RepositorioGenerico<categorias>
    {
        public List<dominio.Categoria> ObtenerCategorias()
        {
            AutoMapper.Mapper.CreateMap<categorias, dominio.Categoria>();
            return new List<dominio.Categoria>(ObtenerTodos().AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Categoria>)).ToList();
        }
    }
}
