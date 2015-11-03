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


namespace Nieruchomosci.Controllers
{
    public class HomeController : Controller

    {
        private EntitiesNieruchomosci db = new EntitiesNieruchomosci();
       [InitializeSimpleMembership]


        public ViewResult Index(string sortOrder, string currentFilter, string searchString, decimal? cenaod, decimal? cenado, decimal? powierzchniaod, decimal? powierzchniado, string rodzaj, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.TransakcjaSortParm = sortOrder == "Transakcja" ? "transakcja_desc" : "Transakcja";
            ViewBag.RodzajNieruchomosciSortParm = sortOrder == "Rodzaj" ? "rodzaj_desc" : "Rodzaj";
            ViewBag.PowierzchniaSortParm = sortOrder == "Powierzchnia" ? "powierzchnia_desc" : "Powierzchnia";
            ViewBag.CenaSortParm = sortOrder == "Cena" ? "cena_desc" : "Cena";
            decimal cena;
            
           
           
         /*   if (cenado!= null)
            {
                cenado.Replace(".", ",");
                try
                {
                    cena = decimal.Parse(cenado);
                }
               catch
                { cena = 0; }

            }
            else 
            {
                cena = 0;
            }
            //var cena = cenado;  rozwiazanie na problem przeicnka i kropki*/


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CenaOd = cenaod;
            ViewBag.CenaDo = cenado;
            ViewBag.PowierzchniaOd = powierzchniaod;
            ViewBag.PowierzchniaDo = powierzchniado;
            ViewBag.Rodzaj = rodzaj;




            //var students = from s in mymodel.Nieruchomosc.Include(n => n.TypTransakcji).Include(n => n.RodzajNieruchomosci).Include(n => n.UserProfile)
            //select s;

            /*var students = from s in db.Nieruchomosc.Include(n => n.TypTransakcji).Include(n => n.RodzajNieruchomosci).Include(n => n.UserProfile)
                            select s;/*

             /*  var students = from o in db.Nieruchomosc.Include(n => n.TypTransakcji).Include(n => n.RodzajNieruchomosci).Include(n => n.UserProfile)
                              join c in db.NieruchomoscPhoto on o.NieruchomoscID equals c.NieruchomoscID
                              select new Nieruchomosc  { Miasto=o.Miasto,Cena=o.Cena,Data_dodania=o.Data_dodania,Powierzchnia=o.Powierzchnia,TypTransakcji =o.TypTransakcji,RodzajNieruchomosci=o.RodzajNieruchomosci};
           
                     */
            // var students = mymodel;
            //var students
            /*  mymodel= from o in db.Nieruchomosc.Include(n => n.TypTransakcji).Include(n => n.RodzajNieruchomosci).Include(n => n.UserProfile)
                         join c in db.NieruchomoscPhoto on o.NieruchomoscID equals c.NieruchomoscID
                         select o; 
           
     

         var students =mymodel;*/
            ViewModel mymodel = new ViewModel();

            var students = from o in db.Nieruchomosc.Include(n => n.TypTransakcji).Include(n => n.RodzajNieruchomosci).Include(n => n.UserProfile)//.Include("NieruchomoscPhotos")
                           join c in db.NieruchomoscPhoto/*.Where(c=>c.NieruchomoscID==o.NieruchomoscID).DefaultIfEmpty()*/  on o.NieruchomoscID equals c.NieruchomoscID into mm
                           from left in mm.DefaultIfEmpty()
                           orderby o.Data_dodania
                           group left by new { o.NieruchomoscID, o.Cena, o.RodzajNieruchomosci, o.Typ_nieruchomosci, o.Data_dodania, o.Miasto, o.Powierzchnia, o.TypTransakcji } into g

                           /*select new ViewModel  {RodzajNieruchomosciID=o.RodzajNieruchomosciID,
                               TypTransakcjiID=o.TypTransakcjiID,NieruchomoscID=o.NieruchomoscID, Miasto=o.Miasto,Cena=o.Cena,
                               Data_dodania=o.Data_dodania,Powierzchnia=o.Powierzchnia,TypTransakcji=o.TypTransakcji,
                                                  RodzajNieruchomosci = o.RodzajNieruchomosci,
                                                 ImageID = (int?)left.ImageID
                                                  //ImageData1=left.ImageData1
                                                  //ImageData=c.ImageData,*/


                           select new ViewModel
                           {
                               ImageID = g.Max(c => c.ImageID),
                               NieruchomoscID = g.Key.NieruchomoscID,
                               Miasto = g.Key.Miasto,
                               Cena = g.Key.Cena,
                               Data_dodania = g.Key.Data_dodania,
                               Powierzchnia = g.Key.Powierzchnia,

                               TypTransakcji = g.Key.TypTransakcji,
                               RodzajNieruchomosci = g.Key.RodzajNieruchomosci,
                               //ImageID = (int?)left.ImageID
                               //ImageData1=left.ImageData1
                               //ImageData=c.ImageData





                           };




            var rodzajenieruchomosci = new List<string>();
            var rodzajeQuery = from rodzaje in db.RodzajNieruchomosci
                               orderby rodzaje.RodzajNieruchomosciRodzaj
                               select rodzaje.RodzajNieruchomosciRodzaj;
            rodzajenieruchomosci.AddRange(rodzajeQuery.Distinct());
            ViewBag.RodzajeNieruchomosci = new SelectList(rodzajenieruchomosci);




            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Miasto.Contains(searchString)
                                       || s.Miasto.Contains(searchString));



                /*  students = students.Where(s => s.Miasto.Contains(searchString)
                                        || s.Miasto.Contains(searchString));*/


            }


            if (!String.IsNullOrEmpty(rodzaj))
            {
                students = students.Where(s => s.RodzajNieruchomosci.RodzajNieruchomosciRodzaj.Contains(rodzaj));

            }

            //var cena = cenaod == null ? cenaod = 0 : cenaod;
            if (cenaod != null && cenado != null)
            {
                students = students.Where(s => s.Cena >= (cenaod) && s.Cena <= (cenado));

            }
            if (cenaod == null && cenado != null)
            {
                students = students.Where(s => s.Cena >= 0 && s.Cena <= (cenado));

            }

            if (cenaod != null && cenado == null)
            {
                students = students.Where(s => s.Cena >= (cenaod) && s.Cena <= 999999999999);

            }

            if (powierzchniaod != null && powierzchniado != null)
            {
                students = students.Where(s => s.Powierzchnia >= (powierzchniaod) && s.Powierzchnia <= (powierzchniado));

            }
            if (powierzchniaod == null && powierzchniado != null)
            {
                students = students.Where(s => s.Powierzchnia >= 0 && s.Powierzchnia <= (powierzchniado));

            }

            if (powierzchniaod != null && powierzchniado == null)
            {
                students = students.Where(s => s.Powierzchnia >= (powierzchniaod) && s.Powierzchnia <= 999999999999);

            }



            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Miasto);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.Data_dodania);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.Data_dodania);
                    break;
                case "transakcja_desc":
                    students = students.OrderByDescending(s => s.TypTransakcji.Typ);
                    break;
                case "Transakcja":
                    students = students.OrderBy(s => s.TypTransakcji.Typ);
                    break;
                case "rodzaj_desc":
                    students = students.OrderByDescending(s => s.RodzajNieruchomosci.RodzajNieruchomosciRodzaj);
                    break;
                case "Rodzaj":
                    students = students.OrderBy(s => s.RodzajNieruchomosci.RodzajNieruchomosciRodzaj);
                    break;
                case "powierzchnia_desc":
                    students = students.OrderByDescending(s => s.Powierzchnia);
                    break;
                case "Powierzchnia":
                    students = students.OrderBy(s => s.Powierzchnia);
                    break;
                case "cena_desc":
                    students = students.OrderByDescending(s => s.Cena);
                    break;
                case "Cena":
                    students = students.OrderBy(s => s.Cena);
                    break;
                default:  // Name ascending 
                    students = students.OrderByDescending(s => s.Data_dodania);
                    break;
            }



            /*var Model = new ViewModel
            {
                
                Nieruchomosc = students.ToList() //This line throws the error.
              
            };*/
            // mymodel.Nieruchomosc = students.ToList();
            // mymodel.NieruchomoscPhoto = from m in db.NieruchomoscPhoto
            // select m;





            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));

        }
        
        
      /* public ActionResult Index()
        {
            ViewBag.Message = " ";

            return View();
        } */
        public ActionResult Details(int id = 0)
        {
            Nieruchomosc nieruchomosc = db.Nieruchomosc.Find(id);
            if (nieruchomosc == null)
            {
                return HttpNotFound();
            }
            return View(nieruchomosc);
        }
        public ActionResult About()
        {
            ViewBag.Message = " ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = " ";

            return View();
        }
    }
}
