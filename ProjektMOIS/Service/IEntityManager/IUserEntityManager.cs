using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMOIS.Service
{
    interface IUserEntityManager
    {
        User GetByEmail(string email);
    }
}
