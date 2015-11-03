using Nieruchomosci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nieruchomosci.IRepo
{
    public interface IRepoAdmin
    {
        List<UserProfile> GetUsers();
        UserProfile GetById(long id);
        void DeleteUser(long id);
        

    }
}