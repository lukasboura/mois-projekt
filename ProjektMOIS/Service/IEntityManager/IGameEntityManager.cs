using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMOIS.Service
{
    interface IGameEntityManager
    {
        IList<Game> GetByFilter(long team, long season, long? competition);
        IList<Game> GetLast(long id, int count);
    }
}
