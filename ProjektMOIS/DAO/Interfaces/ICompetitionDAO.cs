using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMOIS.DAO
{
    public interface ICompetitionDAO : IAbstractDAO<Competition>
    {
        IList<Competition> GetByTeam(long id);
        IList<Competition> GetByPlayer(long id);
    }
}
