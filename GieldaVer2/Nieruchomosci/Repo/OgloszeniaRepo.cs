using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nieruchomosci.Models;
using System.Web.Security;
using PagedList;

using Nieruchomosci.IRepo;
using Nieruchomosci.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nieruchomosci.Models;
using System.Web.Security;
using WebMatrix.WebData;
using Nieruchomosci.Filters;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using PagedList;

namespace Nieruchomosci.Repo
{
    public class OgloszeniaRepo:IOgloszeniaRepo
    {
      // private EntitiesNieruchomosci db = new EntitiesNieruchomosci();


        private EntitiesNieruchomosci db = new EntitiesNieruchomosci();
        
        //private EntitiesNieruchomosci db;

        //public OgloszeniaRepo()
        //{
        //    db=new EntitiesNieruchomosci();
        //}


       public IQueryable<Nieruchomosc> GetAll()
       {
           var nieruchomosc = db.Nieruchomosc.Include(n => n.TypTransakcji).Include(n => n.RodzajNieruchomosci).Include(n => n.UserProfile);
           return nieruchomosc;
        }

        public Nieruchomosc GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Nieruchomosc> GetByCena(double cenaod = 0, double cenado = 999999999999)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Nieruchomosc> GetByPowierzchnia(double powierzchniaod, double powierzchniado)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Nieruchomosc> GetByMiasto(string miasto)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Nieruchomosc> GetByRodzaj(string rodzaj)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Nieruchomosc> WyszukajOgloszenia(ViewModelFiltrowanieOgloszenie ogloszenie)
        {
            IQueryable<Nieruchomosc> nieruchomoscsi = GetAll();
            if (ogloszenie.Miasto != null)
                nieruchomoscsi = nieruchomoscsi.Where(x => x.Miasto == ogloszenie.Miasto);
            if (ogloszenie.Cenaod != null || ogloszenie.Cenado != null)
                nieruchomoscsi = nieruchomoscsi.Where(x => x.Cena >= ogloszenie.Cenaod && x.Cena<=ogloszenie.Cenado);
            if (ogloszenie.Powierzchniad != null && ogloszenie.Powierzhcniado != null)
                nieruchomoscsi = nieruchomoscsi.Where(x => x.Powierzchnia >=ogloszenie.Powierzchniad && x.Powierzchnia<=ogloszenie.Powierzhcniado);

            return nieruchomoscsi;

        }


        public List<Nieruchomosc> SortujOgloszenia(string rodzajsortowania, List<Nieruchomosc> listaOgloszen)
        {
            throw new NotImplementedException();
        }

        public List<string> GetRodzaje()
        {
            var rodzaj = from rodzaje in db.RodzajNieruchomosci
                               orderby rodzaje.RodzajNieruchomosciRodzaj
                               select rodzaje.RodzajNieruchomosciRodzaj;

            return rodzaj.ToList();
        }
    }

    //    public List<Nieruchomosc> SortujOgloszenia(string rodzajsortowania, List<Nieruchomosc> listaOgloszen)
    //    {
    //           switch (rodzajsortowania)
    //        {
    //            case "name_desc":
    //                students = students.OrderByDescending(s => s.Miasto);
    //                break;
    //            case "Date":
    //                students = students.OrderBy(s => s.Data_dodania);
    //                break;
    //            case "date_desc":
    //                students = students.OrderByDescending(s => s.Data_dodania);
    //                break;
    //            case "transakcja_desc":
    //                students = students.OrderByDescending(s => s.TypTransakcji.Typ);
    //                break;
    //            case "Transakcja":
    //                students = students.OrderBy(s => s.TypTransakcji.Typ);
    //                break;
    //            case "rodzaj_desc":
    //                students = students.OrderByDescending(s => s.RodzajNieruchomosci.RodzajNieruchomosciRodzaj);
    //                break;
    //            case "Rodzaj":
    //                students = students.OrderBy(s => s.RodzajNieruchomosci.RodzajNieruchomosciRodzaj);
    //                break;
    //            case "powierzchnia_desc":
    //                students = students.OrderByDescending(s => s.Powierzchnia);
    //                break;
    //            case "Powierzchnia":
    //                students = students.OrderBy(s => s.Powierzchnia);
    //                break;
    //            case "cena_desc":
    //                students = students.OrderByDescending(s => s.Cena);
    //                break;
    //            case "Cena":
    //                students = students.OrderBy(s => s.Cena);
    //                break;
    //            default:  // Name ascending 
    //                students = students.OrderByDescending(s => s.Data_dodania);
    //                break;
    //    }
    //        return listaOgloszen;
    //}
}