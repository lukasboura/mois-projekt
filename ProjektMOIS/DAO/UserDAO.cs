using ProjektMOIS.Model;
using ProjektMOIS.Service;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.DAO
{
    public class UserDAO : AbstractDAO<User>, IUserDAO
    {
        private IUserEntityManager em = new NHibernateUserEntityManager();

        public User GetByEmail(string email)
        {
            return em.GetByEmail(email);
        }
    }
}