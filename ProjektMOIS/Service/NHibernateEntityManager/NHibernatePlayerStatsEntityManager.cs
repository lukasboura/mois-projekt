using NHibernate;
using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Service
{
    public class NHibernatePlayerStatsEntityManager : IPlayerStatsEntityManager
    {
        public IList<PlayerStats> GetLastStats(long id, int count)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var stats = session.QueryOver<PlayerStats>()
                                    .Where(e => e.Player.Id == id)
                                    .Take(count)
                                    .List();
                return stats as IList<PlayerStats>;
            }
        }


        public IList<PlayerStats> GetByFilter(long player, long season, long? competition)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                if (competition == null)
                {
                    var matches = session.QueryOver<PlayerStats>()
                                        .Where(e => e.Player.Id == player)
                                        .JoinQueryOver<Game>(ps=>ps.Game)
                                        .Where(g => g.Season.Id == season)
                                        .List();
                    return matches as IList<PlayerStats>;

                }
                else
                {
                    var matches = session.QueryOver<PlayerStats>()
                                        .Where(e => e.Player.Id == player)
                                        .JoinQueryOver<Game>(ps => ps.Game)
                                        .Where(g => g.Season.Id == season)
                                        .Where(g => g.Competition.Id == competition)
                                        .List();
                    return matches as IList<PlayerStats>;
                }
            }
        }
    }
}