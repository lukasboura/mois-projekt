using ProjektMOIS.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Service
{
    public class NHibernateEntityManager<T> : IEntityManager<T> where T : AbstractEntity
    {

        public T GetById(long id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var entity = session.Get<T>(id);

                return entity as T;
            }
        }

        public IList<T> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var list = session.QueryOver<T>().List();

                return list;
            }
        }

        public void Create(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Save(entity);
                session.Flush();
            }
        }

        public void Update(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }
    }
}