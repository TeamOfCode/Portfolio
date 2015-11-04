using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PropertyManager.Models.PropertyModels;

namespace PropertyManager.Models.ViewModel
{
    public class NoticeViewModel
    {
        public IPagedList<Property> Properties { get; set; }
        public ViewModelFilterNotice Filter { get; set; }
    }
}