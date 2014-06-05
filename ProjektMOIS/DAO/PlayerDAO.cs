using ProjektMOIS.Model;
using ProjektMOIS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.DAO
{
    public class PlayerDAO :  AbstractDAO<Player>, IPlayerDAO
    {
        private IPlayerEntityManager em = new NHibernatePlayerEntityManager();

        public IList<Player> GetByTeam(long id)
        {
            return em.GetByTeam(id);
        }
        public IList<Player> GetByActive(Boolean value)
        {
            return em.GetByActive(value);
        }
    }
}