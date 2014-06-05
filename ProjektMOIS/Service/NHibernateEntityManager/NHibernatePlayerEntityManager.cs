using NHibernate;
using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Service
{
    public class NHibernatePlayerEntityManager : IPlayerEntityManager
    {

        public IList<Player> GetByTeam(long id)
        {
            using (ISession session = NHibernateHelper.OpenSession()) 
            {
                var players = session.QueryOver<Player>()
                                    .Where(e => e.Team.Id == id)
                                    .Where(e => e.Active == true)
                                    .List();
                return players as IList<Player>;
            }
        }


        public IList<Player> GetByActive(bool value)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var players = session.QueryOver<Player>()
                                    .Where(e => e.Active == value)
                                    .List();
                return players as IList<Player>;
            }
        }
    }
}