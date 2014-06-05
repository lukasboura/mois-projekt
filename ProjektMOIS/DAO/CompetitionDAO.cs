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
    public class CompetitionDAO :  AbstractDAO<Competition>, ICompetitionDAO
    {
        private ICompetitionEntityManager em = new NHibernateCompetitionEntityManager();

        public IList<Competition> GetByTeam(long id)
        {
            return em.GetByTeam(id);
        }
        public IList<Competition> GetByPlayer(long id)
        {
            return em.GetByPlayer(id);
        }
    }
}