using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using Koob.Entidades;

namespace Koob.Repositorio  
{
    public class RepositorioGenerico<TEntidad> where TEntidad: class
    {
        protected KoobEntities koobContext=new KoobEntities();
        protected DbSet<TEntidad> dbSet;

        public RepositorioGenerico()
        {
            this.dbSet = koobContext.Set<TEntidad>();
        }

        public virtual IEnumerable<TEntidad> get( 
            Expression<Func<TEntidad, bool>> filter = null,
            Func<IQueryable<TEntidad>, IOrderedQueryable<TEntidad>> orderBy = null,
            string incluirPropiedades = "")
        { 
        IQueryable<TEntidad> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var incluirPropiedad in incluirPropiedades.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(incluirPropiedad);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntidad GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntidad entidad)
        {
            dbSet.Add(entidad);
        }

        public virtual void Delete(object id)
        {
            TEntidad entidadAEliminar = dbSet.Find(id);
            Delete(entidadAEliminar);
        }

        public virtual void Delete(TEntidad entidadAEliminar)
        {
            if (koobContext.Entry(entidadAEliminar).State == EntityState.Detached)
            {
                dbSet.Attach(entidadAEliminar);
            }
            dbSet.Remove(entidadAEliminar);
        }

        public virtual void Update(TEntidad entidadAModificar)
        {
            dbSet.Attach(entidadAModificar);
            koobContext.Entry(entidadAModificar).State = EntityState.Modified;
        }
    }
    
}
