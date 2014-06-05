using ProjektMOIS.Model;
using ProjektMOIS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.DAO
{
    public abstract class AbstractDAO<T> : IAbstractDAO<T> where T : AbstractEntity
    {
        private IEntityManager<T> em = new NHibernateEntityManager<T>();

        public T GetById(long id)
        {
            return em.GetById(id);
        }

        public IList<T> GetAll()
        {
            return em.GetAll();
        }

        public void Create(T entity)
        {
            em.Create(entity);
        }

        public void Update(T entity)
        {
            em.Update(entity);
        }

        public void Delete(T entity)
        {
            em.Delete(entity);
        }

    }
}