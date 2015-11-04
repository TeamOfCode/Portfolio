using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyManager.Models.PropertyModels;
using PropertyManager.Models.ViewModel;

namespace PropertyManager.IRepo
{
    interface INoticeRepo
    {
        IQueryable<Property> GetAll();
        Property GetById(long id);
        IQueryable<Property> GetByPrice(double priceMin, double priceMax);
        IQueryable<Property> GetByArea(double areaMin, double areaMax);
        IQueryable<Property> GetByCity(string city);
        IQueryable<Property> GetByType(string type);
        IQueryable<ViewModelPropertyPropertyPhoto> FindNotices(ViewModelFilterNotice filterPattern);
        List<Property> SortNotices(string sortType, List<Property> noticeList);
        List<string> GetTypes();
    }
}
