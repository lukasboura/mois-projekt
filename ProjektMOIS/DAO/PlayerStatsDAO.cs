using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using ProjektMOIS.Model;
using ProjektMOIS.Model.ViewModels;
using ProjektMOIS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.DAO
{
    public class PlayerStatsDAO :  AbstractDAO<PlayerStats>, IPlayerStatsDAO
    {
        private IPlayerStatsEntityManager em = new NHibernatePlayerStatsEntityManager();

        public IList<PlayerStats> GetLastStats(long id, int count)
        {
            return em.GetLastStats(id, count);
        }

        public IList<PlayerStats> GetByFilter(PlayerStatsFilterViewModel filter)
        {
            return em.GetByFilter(filter.Player, filter.Season, filter.Competition);
        }

        public IList<HistoryData> GroupTest(long id)
        {
            HistoryData dto = null;
            Game gameALias = null;
            PlayerStats psALias = null;

            using (ISession session = NHibernateHelper.OpenSession())
            {
                var stats = session.QueryOver<PlayerStats>(() => psALias)
                                    .JoinAlias(() => psALias.Game, () => gameALias)
                                    .Where(e => e.Player.Id == id)
                                    .SelectList(list => list
                                        .SelectGroup(() => gameALias.Season).WithAlias(() => dto.Season)
                                        .SelectSum(() => psALias.Goals).WithAlias(() => dto.Goals)
                                        .SelectSum(() => psALias.Minutes).WithAlias(() => dto.Minutes)
                                        .SelectSum(() => psALias.Assists).WithAlias(() => dto.Assists)
                                        .SelectSum(() => psALias.Red).WithAlias(() => dto.Red)
                                        .SelectSum(() => psALias.Yellow).WithAlias(() => dto.Yellow)
                                        .SelectSum(() => psALias.Corners).WithAlias(() => dto.Corners)
                                        .SelectSum(() => psALias.Shots).WithAlias(() => dto.Shots)
                                        .SelectSum(() => psALias.ShotsWide).WithAlias(() => dto.ShotsWide)
                                        .SelectSum(() => psALias.Offsides).WithAlias(() => dto.Offsides)
                                     )
                                    .TransformUsing(Transformers.AliasToBean<HistoryData>())
                                    .List<HistoryData>();
                return stats as IList<HistoryData>;

            }
        }

        public class HistoryData
        {
            public virtual Season Season { get; set; }
            public virtual int Minutes { get; set; }
            public virtual int Goals { get; set; }
            public virtual int Assists { get; set; }
            public virtual int Red { get; set; }
            public virtual int Yellow { get; set; }
            public virtual int Corners { get; set; }
            public virtual int Shots { get; set; }
            public virtual int ShotsWide { get; set; }
            public virtual int Offsides { get; set; }
        }
    }
}