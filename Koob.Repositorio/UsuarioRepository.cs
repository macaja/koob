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
        public dominio.Usuario ObtenerPorID(object id)
        {
            var usuario = GetByID(id);

            AutoMapper.Mapper.CreateMap<usuarios, dominio.Usuario>();
            return AutoMapper.Mapper.Map<dominio.Usuario>(usuario);
        }
        public bool logueo(String email, string password)
        {
            bool isValid=false;
            using (var context  = new KoobEntities())
            {

                var user = context.usuarios.FirstOrDefault(u => u.usu_email == email);
                if (user != null)
                {
                    if (user.usu_password == password) //Verificar password del usuario
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
            
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
