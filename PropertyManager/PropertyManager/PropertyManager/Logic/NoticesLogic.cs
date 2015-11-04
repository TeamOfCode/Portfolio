using System.Collections.Generic;
using System.Linq;
using PropertyManager.IRepo;
using PropertyManager.Models;
using PropertyManager.Models.PropertyModels;
using PropertyManager.Repo;

namespace PropertyManager.Logic
{
    public class NoticesLogic
    {
        private INoticesRepo _repo;

        public NoticesLogic()
        {
            _repo = new NoticesRepo();
        }

        public List<ViewModel> FindNotices(ViewModelFilterNotice filterPattern)
        {
            IQueryable<Property> properties = _repo.GetAll();
            
            return new List<ViewModel>();
        } 
    }
}