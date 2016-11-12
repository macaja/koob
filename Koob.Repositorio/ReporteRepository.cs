﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koob.Entidades;
using dominio = Koob.Dominio;

namespace Koob.Repositorio
{
    public class ReporteRepository : RepositorioGenerico<reportes>
    {
        public List<dominio.Reporte> ObtenerReportes()
        {

            AutoMapper.Mapper.CreateMap<reportes, dominio.Reporte>();
            return new List<dominio.Reporte>(ObtenerTodos().AsEnumerable().Select(AutoMapper.Mapper.Map<dominio.Reporte>)).ToList();
        }

        private reportes verificar(string email, int libCodigo)
        {

            using (var context = new KoobEntities())
            {
                var lib = context.reportes.Where(x => x.usu_email == email && x.lib_codigo == libCodigo).FirstOrDefault();
                return lib;
            }

        }
        public Boolean agregarReporte(dominio.Reporte reporte)
        {
            var estaEnBD = verificar(reporte.usu_email, reporte.lib_codigo);

            if (estaEnBD == null)
            {
                AutoMapper.Mapper.CreateMap<dominio.Reporte, reportes>();
                var report = AutoMapper.Mapper.Map<reportes>(reporte);
                Insert(report);
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }


        private dominio.Reporte repeatReportes(int libCodigo)
        {
            using (var context = new KoobEntities())
            {
                var lib = context.reportes.Where(x => x.lib_codigo == libCodigo).FirstOrDefault();
                AutoMapper.Mapper.CreateMap<reportes, dominio.Reporte>();
                var report = AutoMapper.Mapper.Map<dominio.Reporte>(lib);
                return report;
            }

        }

        public void eliminarReporteID(int lib_codigo)
        {
            var reporte = repeatReportes(lib_codigo);
            Delete(reporte.rep_codigo);
                Save();

           
        }
    }
}