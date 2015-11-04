using PropertyManager.Models.PropertyModels;
using PagedList;

namespace PropertyManager.Models
{
    public class NoticesViewModel
    {
        public IPagedList<Property> Properties { get; set; }
        public ViewModelFilterNotice Filter { get; set; }
    }
}