using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMOIS.DAO
{
    public interface IGameDAO : IAbstractDAO<Game>
    {
        IList<Game> GetByFilter(GameFilterViewModel filter);
        IList<Game> GetLast(long id, int count);
    }
}
