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
    public class GameDAO :  AbstractDAO<Game>, IGameDAO
    {
        private IGameEntityManager em = new NHibernateGameEntityManager();

        public IList<Game> GetByFilter(GameFilterViewModel filter)
        {
            return em.GetByFilter(filter.Team, filter.Season, filter.Competition);
        }
        public IList<Game> GetLast(long id, int count)
        {
            return em.GetLast(id, count);
        }
    }
}