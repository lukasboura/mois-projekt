using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMOIS.DAO
{
    public interface IPlayerDAO : IAbstractDAO<Player>
    {
        IList<Player> GetByTeam(long id);
        IList<Player> GetByActive(Boolean value);
    }
}
