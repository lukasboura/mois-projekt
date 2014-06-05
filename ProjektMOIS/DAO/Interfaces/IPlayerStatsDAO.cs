using ProjektMOIS.Model;
using ProjektMOIS.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMOIS.DAO
{
    public interface IPlayerStatsDAO : IAbstractDAO<PlayerStats>
    {
        IList<PlayerStats> GetLastStats(long id, int count);

        IList<PlayerStats> GetByFilter(PlayerStatsFilterViewModel filter);

        IList<ProjektMOIS.DAO.PlayerStatsDAO.HistoryData> GroupTest(long id);
    }
}
