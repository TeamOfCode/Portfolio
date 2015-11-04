using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropertyManager.Models.PropertyModels;
using PropertyManager.Models.ViewModel;

namespace PropertyManager.Repo
{
    public class NoticeRepo
    {
        public class NoticesRepo //: INoticesRepo
        {
            //private readonly PropertiesEntities _db = new PropertiesEntities();

            //public IQueryable<Property> GetAll()
            //{
            //    var property = _db.Properties
            //        .Include(x => x.TransactionType)
            //        .Include(x => x.PropertyType)
            //        .Include(x => x.UserProfile);

            //    return property;
            //}

            //public Property GetById(long id)
            //{
            //    throw new System.NotImplementedException();
            //}

            //public IQueryable<Property> GetByPrice(double priceMin = 0, double priceMax = 999999999999)
            //{
            //    throw new System.NotImplementedException();
            //}

            //public IQueryable<Property> GetByArea(double areaMin, double areaMax)
            //{
            //    throw new NotImplementedException();
            //}

            //public IQueryable<Property> GetByCity(string city)
            //{
            //    throw new NotImplementedException();
            //}

            //public IQueryable<Property> GetByType(string type)
            //{
            //    throw new NotImplementedException();
            //}

            //public IQueryable<Property> FindNotices(ViewModelFilterNotice filterPattern)
            //{
            //    IQueryable<Property> properties = GetAll();

            //    if (filterPattern.City != null)
            //        properties = properties.Where(x => x.City == filterPattern.City);

            //    if (filterPattern.PriceMin != null || filterPattern.PriceMax != null)
            //        properties = properties.Where(x =>
            //            x.Price >= filterPattern.PriceMin &&
            //            x.Price <= filterPattern.PriceMax);

            //    if (filterPattern.AreaMin != null && filterPattern.AreaMax != null)
            //        properties = properties.Where(x =>
            //            x.Area >= filterPattern.AreaMin &&
            //            x.Area <= filterPattern.AreaMax);

            //    return properties;
            //}

            //public List<Property> SortNotices(string sortType, List<Property> noticeList)
            //{
            //    throw new NotImplementedException();
            //}

            //public List<string> GetTypes()
            //{
            //    var propertyTypes = from types in _db.PropertiesTypes
            //        orderby types.TypePropertyType
            //        select types.TypePropertyType;

            //    return propertyTypes.ToList();
            //}

        }
    }
}