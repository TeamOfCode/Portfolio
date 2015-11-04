using PropertyWebManager.Models.PropertyModels;
using PagedList;

namespace PropertyWebManager.Models
{
    public class NoticesViewModel
    {
        public IPagedList<Property> Properties { get; set; }
        public ViewModelFilterNotice Filter { get; set; }
    }
}