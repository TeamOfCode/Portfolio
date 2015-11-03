using System.Collections.Generic;
using System.Linq;
using Nieruchomosci.IRepo;
using Nieruchomosci.Models;
using Nieruchomosci.Repo;

namespace Nieruchomosci.Logic
{
    public class OgloszeniaLogic
    {
        private IOgloszeniaRepo repo;

        public OgloszeniaLogic()
        {
            repo = new OgloszeniaRepo();
        }

        public List<ViewModel> WyszukajOgloszenia(ViewModelFiltrowanieOgloszenie ogloszenie)
        {
            IQueryable<Nieruchomosc> nieruchomoscsi = repo.GetAll();
            

            return new List<ViewModel>();
        } 

  
    }
}