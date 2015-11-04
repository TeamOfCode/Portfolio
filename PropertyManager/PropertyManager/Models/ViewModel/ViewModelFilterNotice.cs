using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager.Models.ViewModel
{
    public class ViewModelFilterNotice
    {
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public decimal? AreaMin { get; set; }
        public decimal? AreaMax { get; set; }
        public string NoticeType { get; set; }
        public string City { get; set; }
    }
}