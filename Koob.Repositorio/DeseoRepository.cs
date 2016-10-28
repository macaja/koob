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
        public List<dominio.Libro> listaDeDeseos(string usuEmail)
        {
            IQueryable<libros> Deseos;
            AutoMapper.Mapper.CreateMap<libros, dominio.Libro>();
            using (var context = new KoobEntities())
            {

                Deseos = from u in context.libros
                         join v in context.deseos on u.lib_codigo equals v.lib_codigo
                         where v.usu_email == usuEmail
                         select u;
                return new List<dominio.Libro>(Deseos.AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Libro>)).ToList();
            }

          // return new List<dominio.Libro>(Deseos.AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Libro>)).ToList();
        }
        private deseos verificar(string email, int libCodigo)
        {
            
            using (var context = new KoobEntities())
            {
                var lib = context.deseos.Where(x => x.usu_email == email && x.lib_codigo == libCodigo).FirstOrDefault();
                return lib;
            }
            
        }

        public void eliminarDeseosPorLibReportado(int codigo)
        {
            try
            {
                using (var context = new KoobEntities())
                {
                    var lib = context.deseos.Where(x => x.lib_codigo == codigo).ToList();
                    foreach (var deseo in lib)
                    {
                        quitarDeseoPorID(deseo.des_codigo);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        public Boolean agregarDeseo(dominio.Deseo deseo)
        {
            var estaEnBD = verificar(deseo.usu_email, deseo.lib_codigo);

            if (estaEnBD==null)
            {
                AutoMapper.Mapper.CreateMap<dominio.Deseo, deseos>();
                var dese = AutoMapper.Mapper.Map<deseos>(deseo);
                Insert(dese);
                Save();
                return true;
            }
            else
            {

                quitarDeseo(estaEnBD);
                return false;
            }
        }
        private void quitarDeseoPorID(int deseo)
        {

            Delete(deseo);
            Save();

        }
        private void quitarDeseo(deseos deseo)
        {

            Delete(deseo);
            Save();

        }

        private List<dominio.Deseo> queryLibrosMasDeseados()
        {
            //IQueryable<deseos> libsPopulares;
            AutoMapper.Mapper.CreateMap<deseos, dominio.Deseo>();

            using (var context = new KoobEntities())
            {
                var deseos = context.deseos
                   .GroupBy(p => p.lib_codigo)
                   .Select(g => new dominio.Deseo { lib_codigo = g.Key, count = g.Count() }).OrderByDescending(t=> t.count).ToList();
                return deseos;   
            }
        }
        public List<dominio.Libro> librosPopulares()
        {
            LibrosRepository libroRepository = new LibrosRepository();
            List<dominio.Deseo> librosMasDeseados = queryLibrosMasDeseados();
            List<dominio.Libro> librosPopulares = new List<Dominio.Libro>();
            foreach (var libro in librosMasDeseados)
            {
                librosPopulares.Add(libroRepository.obtenerLibPorID(libro.lib_codigo));
            }
            return librosPopulares;

        }


    }
}
