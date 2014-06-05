using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.Service
{
    public interface IPlayerEntityManager
    {
        IList<Player> GetByTeam(long id);
        IList<Player> GetByActive(Boolean value);
    }
}