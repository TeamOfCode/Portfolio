using System.Collections.Generic;
using System.Linq;
using Nieruchomosci.Models;

namespace Nieruchomosci.IRepo
{
    public interface IOgloszeniaRepo
    {
        IQueryable<Nieruchomosc> GetAll();
        Nieruchomosc GetById(long id);
        IQueryable<Nieruchomosc> GetByCena(double cenaod, double cenado);
        IQueryable<Nieruchomosc> GetByPowierzchnia(double powierzchniaod, double powierzchniado);
        IQueryable<Nieruchomosc> GetByMiasto(string miasto);
        IQueryable<Nieruchomosc> GetByRodzaj(string rodzaj);
        IQueryable<Nieruchomosc> WyszukajOgloszenia(ViewModelFiltrowanieOgloszenie ogloszenie);
        List<Nieruchomosc> SortujOgloszenia(string rodzajsortowania, List<Nieruchomosc> listaOgloszen);
        List<string> GetRodzaje();
    }
}