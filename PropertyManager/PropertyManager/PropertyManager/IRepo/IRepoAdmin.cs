using System.Collections.Generic;
using PropertyManager.Models.PropertyModels;

namespace PropertyManager.IRepo
{
    public interface IRepoAdmin
    {
        List<UserProfile> GetUsers();
        UserProfile GetById(long id);
        void DeleteUser(long id);  
    }
}