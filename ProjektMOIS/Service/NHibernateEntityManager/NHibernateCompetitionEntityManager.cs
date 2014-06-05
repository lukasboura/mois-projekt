using NHibernate;
using NHibernate.Transform;
using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Service
{
    public class NHibernateCompetitionEntityManager : ICompetitionEntityManager
    {
        public IList<Competition> GetByTeam(long id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var comps = session.QueryOver<Competition>()
                                    .Where(e => e.Team.Id == id)
                                    .List();
                return comps as IList<Competition>;
            }
        }


        public IList<Competition> GetByPlayer(long id)
        {
            Competition dto = null;
            Competition comp = null;
            Game game = null;
            PlayerStats ps = null;

            using (ISession session = NHibernateHelper.OpenSession())
            {
                var comps = session.QueryOver<PlayerStats>(() => ps)
                                    .JoinAlias(() => ps.Game, () => game)
                                    .JoinAlias(() => game.Competition, () => comp)
                                    .Where(e => e.Player.Id == id)
                                    .SelectList(l => l
                                        .Select(() => comp.Id).WithAlias(() => dto.Id)
                                        .Select(() => comp.Name).WithAlias(() => dto.Name)
                                        .Select(() => comp.Team).WithAlias(() => dto.Team)
                                      )
                                    .TransformUsing(Transformers.AliasToBean<Competition>())
                                    .List<Competition>();
                return comps as IList<Competition>;
            }
        }
    }
}