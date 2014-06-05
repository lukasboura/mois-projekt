using ProjektMOIS.DAO;
using ProjektMOIS.Model;
using ProjektMOIS.Model.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektMOIS.Controllers
{
    public class AjaxController : Controller
    {

        private ICompetitionDAO compdao = new CompetitionDAO();
        private IListItems items = new MyListItems();

        public JsonResult Competitions(int teamdId)
        {
            var competitions = items.CompetitionsOfTeam(teamdId).ToArray();

            return new JsonResult() { Data = competitions, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}