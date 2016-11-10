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
    public class InteresesRepository : RepositorioGenerico<interesados>
    {
        public List<dominio.Libro> listaDeIntereses(string usuEmail)
        {
            IQueryable<libros> Intereses;
            AutoMapper.Mapper.CreateMap<libros, dominio.Libro>();
            using (var context = new KoobEntities())
            {

                Intereses = from u in context.libros
                            join v in context.interesados on u.lib_codigo equals v.lib_codigo
                            where v.usu_email_interesado == usuEmail
                            select u;
                return new List<dominio.Libro>(Intereses.AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Libro>)).ToList();
            }

            // return new List<dominio.Libro>(Deseos.AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Libro>)).ToList();
        }

        private List<dominio.Intereses> losQueSeInteresaron(String email)
        {
            IQueryable<interesados> interesados;
            AutoMapper.Mapper.CreateMap<interesados, dominio.Intereses>();
            using (var context = new KoobEntities())
            {

                interesados = context.interesados.Where(x => x.usu_email_dueño == email);
                return new List<dominio.Intereses>(interesados.AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Intereses>)).ToList();
            }
        }
        public List<dominio.Intereses> quienSeIntereso(string email)
        {
            List<dominio.Intereses> losQueSe = losQueSeInteresaron(email);
            LibrosRepository librosRepository = new LibrosRepository();
            foreach (var interesado in losQueSe)
            {
                interesado.libro = librosRepository.obtenerLibPorID(interesado.lib_codigo);
            }

            return losQueSe;
        }

        private List<dominio.Intereses> losQueMeInteresaron(String email)
        {
            IQueryable<interesados> interesados;
            AutoMapper.Mapper.CreateMap<interesados, dominio.Intereses>();
            using (var context = new KoobEntities())
            {

                interesados = context.interesados.Where(x => x.usu_email_interesado == email);
                return new List<dominio.Intereses>(interesados.AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Intereses>)).ToList();
            }
        }

        public List<dominio.Intereses> meInteresan(string email)
        {
            List<dominio.Intereses> losQueMe = losQueMeInteresaron(email);
            LibrosRepository librosRepository = new LibrosRepository();
            foreach (var interesado in losQueMe)
            {
                interesado.libro = librosRepository.obtenerLibPorID(interesado.lib_codigo);
            }

            return losQueMe;
        }


        private interesados verificar(string email, int libCodigo)
        {

            using (var context = new KoobEntities())
            {
                var lib = context.interesados.Where(x => x.usu_email_interesado == email && x.lib_codigo == libCodigo).FirstOrDefault();
                return lib;
            }

        }

        public void eliminarInteresesPorLibReportado(int codigo)
        {
            try
            {
                using (var context = new KoobEntities())
                {
                    var lib = context.interesados.Where(x => x.lib_codigo == codigo).ToList();
                    foreach (var interes in lib)
                    {
                        quitarInteresPorID(interes.int_codigo);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        public Boolean agregarInteres(dominio.Intereses interes)
        {
            var estaEnBD = verificar(interes.usu_email_interesado, interes.lib_codigo);

            if (estaEnBD == null)
            {
                AutoMapper.Mapper.CreateMap<dominio.Intereses, interesados>();
                var inter = AutoMapper.Mapper.Map<interesados>(interes);
                Insert(inter);
                Save();
                return true;
            }
            else
            {

                quitarInteres(estaEnBD);
                return false;
            }
        }

        public int verificarDocumentReady(string email, int libCodigo)
        {

            using (var context = new KoobEntities())
            {
                var lib = context.interesados.Where(x => x.usu_email_interesado == email && x.lib_codigo == libCodigo).FirstOrDefault();
                if (lib != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

        }

        private void quitarInteresPorID(int interesId)
        {

            Delete(interesId);
            Save();

        }
        private void quitarInteres(interesados interes)
        {

            Delete(interes);
            Save();

        }

    }
}

