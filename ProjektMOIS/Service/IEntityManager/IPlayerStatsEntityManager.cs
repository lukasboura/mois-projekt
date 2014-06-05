using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMOIS.Service
{
    interface IPlayerStatsEntityManager
    {
        IList<PlayerStats> GetLastStats(long id, int count);
        IList<PlayerStats> GetByFilter(long player, long season, long? competition);
    }
}
