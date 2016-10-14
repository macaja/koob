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
    public class AdministradorRepository: RepositorioGenerico<administradores>
    {
        public bool logueo(String nombre, string password)
        {
            bool isValid = false;
            using (var context = new KoobEntities())
            {

                var admin = context.administradores.FirstOrDefault(u => u.adm_nombre == nombre);
                if (admin != null)
                {
                    if (admin.adm_password == password) //Verificar password del usuario
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;

        }
    }
}
