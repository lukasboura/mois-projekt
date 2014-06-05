using ProjektMOIS.Model;
using ProjektMOIS.Service;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektMOIS.DAO
{
    public class SeasonDAO : AbstractDAO<Season>, ISeasonDAO
    {
    }
}