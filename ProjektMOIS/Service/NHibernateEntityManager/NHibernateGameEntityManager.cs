using NHibernate;
using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Service
{
    public class NHibernateGameEntityManager : IGameEntityManager
    {
        public IList<Game> GetByFilter(long team, long season, long? competition)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                if (competition == null)
                {
                    var matches = session.QueryOver<Game>()
                                        .Where(e => e.Team.Id == team)
                                        .Where(e => e.Season.Id == season)
                                        .List();
                    return matches as IList<Game>;

                }
                else
                {
                    var matches = session.QueryOver<Game>()
                                        .Where(e => e.Team.Id == team)
                                        .Where(e => e.Season.Id == season)
                                        .Where(e => e.Competition.Id == competition)
                                        .List();
                    return matches as IList<Game>;
                }
            }
        }


        public IList<Game> GetLast(long id, int count)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var matches = session.QueryOver<Game>()
                                    .Where(t => t.Team.Id == id)
                                    .Take(count)
                                    .List();
                return matches as IList<Game>;

            }
        }
    }
}