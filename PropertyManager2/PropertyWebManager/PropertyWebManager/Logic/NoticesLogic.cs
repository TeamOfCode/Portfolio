using System.Collections.Generic;
using System.Linq;
using PropertyWebManager.IRepo;
using PropertyWebManager.Models;
using PropertyWebManager.Models.PropertyModels;
using PropertyWebManager.Repo;

namespace PropertyWebManager.Logic
{
    public class NoticesLogic
    {
        private INoticesRepo _repo;

        public NoticesLogic()
        {
          //  _repo = new NoticesRepo();
        }

        public List<ViewModel> FindNotices(ViewModelFilterNotice filterPattern)
        {
            IQueryable<Property> properties = _repo.GetAll();

            return new List<ViewModel>();
        }
    }
}