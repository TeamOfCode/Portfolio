using System.Collections.Generic;
using PropertyWebManager.Models.PropertyModels;

namespace PropertyWebManager.IRepo
{
    public interface IRepoAdmin
    {
        List<UserProfile> GetUsers();
        UserProfile GetById(long id);
        void DeleteUser(long id);
    }
}