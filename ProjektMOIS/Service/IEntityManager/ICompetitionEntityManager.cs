using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMOIS.Service
{
    interface ICompetitionEntityManager
    {
        IList<Competition> GetByTeam(long id);
        IList<Competition> GetByPlayer(long id);
    }
}
