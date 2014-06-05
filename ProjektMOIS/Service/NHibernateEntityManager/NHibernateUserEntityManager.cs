using ProjektMOIS.Model;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Service
{
    public class NHibernateUserEntityManager : IUserEntityManager
    {
        public User GetByEmail(string email)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var user = session.QueryOver<User>()
                    .Where(u => u.Email == email)
                    .SingleOrDefault<User>();
                return user as User;
            }
        }
    }
}