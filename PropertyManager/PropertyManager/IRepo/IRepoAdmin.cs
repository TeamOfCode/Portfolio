using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyManager.Models;

namespace PropertyManager.IRepo
{
    interface IRepoAdmin
    {
        List<ApplicationUser> GetUsers();
        ApplicationUser GetById(long id);
        void DeleteUser(long id);

       
    }
}
