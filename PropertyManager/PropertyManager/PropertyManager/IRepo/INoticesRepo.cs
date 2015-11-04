﻿using System.Collections.Generic;
using System.Linq;
using PropertyManager.Models;
using PropertyManager.Models.PropertyModels;

namespace PropertyManager.IRepo
{
    public interface INoticesRepo
    {
        IQueryable<Property> GetAll();
        Property GetById(long id);
        IQueryable<Property> GetByPrice(double priceMin, double priceMax);
        IQueryable<Property> GetByArea(double areaMin, double areaMax);
        IQueryable<Property> GetByCity(string city);
        IQueryable<Property> GetByType(string type);
        IQueryable<Property> FindNotices(ViewModelFilterNotice filterPattern);
        List<Property> SortNotices(string sortType, List<Property> noticeList);
        List<string> GetTypes();
    }
}