using ProjektMOIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMOIS.DAO
{
    public interface IUserDAO : IAbstractDAO<User>
    {
        User GetByEmail(string email);
    }
}
