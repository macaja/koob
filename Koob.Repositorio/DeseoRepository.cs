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
    public class DeseoRepository:RepositorioGenerico<deseos>
    {
        public List<dominio.Libro> listaDeDeseos(String usuEmail)
        {
            IQueryable<libros> Deseos;
            AutoMapper.Mapper.CreateMap<libros, dominio.Libro>();
            using (var context = new KoobEntities())
            {

                Deseos = from u in context.libros
                         join v in context.deseos on u.lib_codigo equals v.lib_codigo
                         where v.usu_email == usuEmail
                         select u;
            }

           return new List<dominio.Libro>(Deseos.AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Libro>)).ToList();
        }
        private Boolean verificar(string email, int libCodigo)
        {
            bool esta =false;
            using (var context = new KoobEntities())
            {
                var lib = context.deseos.Where(x => x.usu_email == email && x.lib_codigo == libCodigo).FirstOrDefault();
                if (lib!=null)
                {
                    esta = true;
                }
            }
            return esta;
        }
        public Boolean agregarDeseo(dominio.Deseo deseo)
        {
            if (verificar(deseo.usu_email, deseo.lib_codigo)==false)
            {
                AutoMapper.Mapper.CreateMap<dominio.Deseo, deseos>();
                var dese = AutoMapper.Mapper.Map<deseos>(deseo);
                Insert(dese);
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
