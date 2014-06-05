using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjektMOIS.Model.Others
{
    public interface IListItems
    {
        IEnumerable<SelectListItem> Teams();

        IEnumerable<SelectListItem> TeamsOnly();

        IEnumerable<SelectListItem> Players();

        IEnumerable<SelectListItem> Positions();

        IEnumerable<SelectListItem> Places();

        IEnumerable<SelectListItem> Countries();

        IEnumerable<SelectListItem> UnsetPeriods(IList<GameStats> stats);

        IEnumerable<SelectListItem> UnsetPlayers(IList<PlayerStats> stats);

        IEnumerable<Country> GetCountries();

        IEnumerable<SelectListItem> Seasons();

        IEnumerable<SelectListItem> Competitions();

        IEnumerable<SelectListItem> CompetitionsOfTeam(long id);

        IEnumerable<SelectListItem> CompetitionsOfPlayer(long id);

        IEnumerable<SelectListItem> CompetitionsOnly();

        IEnumerable<SelectListItem> Roles();
    }
}
