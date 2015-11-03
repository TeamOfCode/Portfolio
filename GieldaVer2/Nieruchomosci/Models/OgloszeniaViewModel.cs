using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace Nieruchomosci.Models
{
    public class OgloszeniaViewModel
    {
        public IPagedList<Nieruchomosc> Nieruchomosci { get; set; }
        public ViewModelFiltrowanieOgloszenie Filtrowanie { get; set; }
    }
    } 
    
