using System.Linq;
using PropertyManager.Models.PropertyModels;

namespace PropertyManager.IRepo
{
    public interface IRepoViewModelPropertyPropertyPhoto
    {
        IQueryable<Property> GetAll();

    }
}