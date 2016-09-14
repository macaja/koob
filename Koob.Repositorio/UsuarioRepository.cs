using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koob.Entidades;
using dominio = Koob.Dominio;
using AutoMapper;
namespace Koob.Repositorio
{
    public class UsuarioRepository: RepositorioGenerico<usuarios>
    {
        public List<dominio.Usuario> ObtenerUsuarios()
        {
            AutoMapper.Mapper.CreateMap<usuarios, dominio.Usuario>();
            return new List<dominio.Usuario>(ObtenerTodos().AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Usuario>)).ToList();
        }
        public dominio.Usuario ObtenerPorID(int id)
        {
            var usuario = GetByID(id);

            AutoMapper.Mapper.CreateMap<usuarios, dominio.Usuario>();
            return AutoMapper.Mapper.Map<dominio.Usuario>(usuario);
        }
        public void InsertarUsuario(dominio.Usuario usuario)
        {
            AutoMapper.Mapper.CreateMap<dominio.Usuario, usuarios>();
            var usu = AutoMapper.Mapper.Map<usuarios>(usuario);
            Insert(usu);
            Save();
        }
        public void EliminarUsuario(int id)
        {

        }
    }
}
