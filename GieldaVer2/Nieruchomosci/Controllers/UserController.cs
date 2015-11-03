﻿using System;
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
    public class UserController : Controller
    {
        private EntitiesNieruchomosci db = new EntitiesNieruchomosci();

        [Authorize]
        [InitializeSimpleMembership]
       /* public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            var memberId = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";





            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

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
        /*    ViewModel mymodel = new ViewModel();

            var students = from o in db.Nieruchomosc.Include(n => n.TypTransakcji).Include(n => n.RodzajNieruchomosci).Include(n => n.UserProfile).Where(c => c.UserId == memberId)//.Include("NieruchomoscPhotos")
                           join c in db.NieruchomoscPhoto/*.Where(c=>c.NieruchomoscID==o.NieruchomoscID).DefaultIfEmpty()*/  //on o.NieruchomoscID equals c.NieruchomoscID into mm
                       //    from left in mm.DefaultIfEmpty()
                       //    orderby o.NieruchomoscID
                       //    group left by new { o.NieruchomoscID, o.Cena, o.RodzajNieruchomosci, o.Typ_nieruchomosci, o.Data_dodania, o.Miasto, o.Powierzchnia, o.TypTransakcji } into g
                           
                           /*select new ViewModel  {RodzajNieruchomosciID=o.RodzajNieruchomosciID,
                               TypTransakcjiID=o.TypTransakcjiID,NieruchomoscID=o.NieruchomoscID, Miasto=o.Miasto,Cena=o.Cena,
                               Data_dodania=o.Data_dodania,Powierzchnia=o.Powierzchnia,TypTransakcji=o.TypTransakcji,
                                                  RodzajNieruchomosci = o.RodzajNieruchomosci,
                                                 ImageID = (int?)left.ImageID
                                                  //ImageData1=left.ImageData1
                                                  //ImageData=c.ImageData,*/


                         /*  select new ViewModel
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






            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Miasto.Contains(searchString)
                                       || s.Miasto.Contains(searchString)); */

                /*  students = students.Where(s => s.Miasto.Contains(searchString)
                                        || s.Miasto.Contains(searchString));*/

        /*
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
                default:  // Name ascending 
                    students = students.OrderBy(s => s.Miasto);
                    break;
            } */

            /*var Model = new ViewModel
            {
                
                Nieruchomosc = students.ToList() //This line throws the error.
              
            };*/
            // mymodel.Nieruchomosc = students.ToList();
            // mymodel.NieruchomoscPhoto = from m in db.NieruchomoscPhoto
            // select m;

/*



            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));

        } */


        /*------------------------------------------------------------------------------------------------------*/
        [Authorize]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, decimal? cenaod, decimal? cenado, decimal? powierzchniaod, decimal? powierzchniado, string rodzaj, int? page)
        {
            var memberId = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.TransakcjaSortParm = sortOrder == "Transakcja" ? "transakcja_desc" : "Transakcja";
            ViewBag.RodzajNieruchomosciSortParm = sortOrder == "Rodzaj" ? "rodzaj_desc" : "Rodzaj";
            ViewBag.PowierzchniaSortParm = sortOrder == "Powierzchnia" ? "powierzchnia_desc" : "Powierzchnia";
            ViewBag.CenaSortParm = sortOrder == "Cena" ? "cena_desc" : "Cena";





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

            var students = from o in db.Nieruchomosc.Include(n => n.TypTransakcji).Include(n => n.RodzajNieruchomosci).Include(n => n.UserProfile).Where(c => c.UserId == memberId)//.Include("NieruchomoscPhotos")
                           join c in db.NieruchomoscPhoto/*.Where(c=>c.NieruchomoscID==o.NieruchomoscID).DefaultIfEmpty()*/  on o.NieruchomoscID equals c.NieruchomoscID into mm
                           from left in mm.DefaultIfEmpty()
                           orderby o.NieruchomoscID
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

        /*-------------------------------------------------------------------------------------------------------*/











        [InitializeSimpleMembership] // bez tego nie pobierzemy ID uzytkownika
        // [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Zalogowany()
        {

            if (WebSecurity.IsAuthenticated)
            {
                return RedirectToAction("Index","User");

            }
            else
            {
                return RedirectToAction("Login", "Account");

            }

        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.TypTransakcjiID = new SelectList(db.TypTransakcji, "TypTransakcjiID", "Typ");
            ViewBag.RodzajNieruchomosciID = new SelectList(db.RodzajNieruchomosci, "RodzajNieruchomosciID", "RodzajNieruchomosciRodzaj");
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Nieruchomosci/Create
        [InitializeSimpleMembership] // bez tego nie pobierzemy ID uzytkownika
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Nieruchomosc nieruchomosc)
        {



            //try
            // {

            if (ModelState.IsValid)
            {
                DateTime saveTime = DateTime.Now;
                var memberId = WebSecurity.GetUserId(User.Identity.Name); //metoda odpowiedzialna za pobieranie ID zalogowanego uzytkownika

                db.Nieruchomosc.Add(nieruchomosc);
                db.Nieruchomosc.Add(nieruchomosc).Data_dodania = saveTime;
                db.Nieruchomosc.Add(nieruchomosc).UserId = memberId;




                db.SaveChanges();

                int id = (from u in db.Nieruchomosc
                          where u.UserId == memberId
                          select u.NieruchomoscID).Max();
                TempData["id"] = id;

                /*   int id = (from u in db.Nieruchomosc
                             where u.UserId == memberId //&& u.Data_dodania == saveTime 
                             select u.NieruchomoscID).FirstOrDefault(); */

                //return RedirectToAction("Index");
                //return RedirectToAction("Gallery");
                return RedirectToAction("Edit", new { Id = id });
            }
            // }
            // catch (Exception /* dex */)
            //{
            //Log the error (uncomment dex variable name and add a line here to write a log.
            //  ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            //}


            //ModelState.AddModelError("nieruchomosc.Cena", "lala");
            ViewBag.TypTransakcjiID = new SelectList(db.TypTransakcji, "TypTransakcjiID", "Typ", nieruchomosc.TypTransakcjiID);
            ViewBag.RodzajNieruchomosciID = new SelectList(db.RodzajNieruchomosci, "RodzajNieruchomosciID", "RodzajNieruchomosciRodzaj", nieruchomosc.RodzajNieruchomosciID);
            //ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", nieruchomosc.UserId);
            return View(nieruchomosc);
        }

        //
        // GET: /Nieruchomosci/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            TempData["id"] = id;
            Nieruchomosc nieruchomosc = db.Nieruchomosc.Find(id);
            if (nieruchomosc.UserId != WebSecurity.GetUserId(User.Identity.Name)) { nieruchomosc = null; }
            if (nieruchomosc == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypTransakcjiID = new SelectList(db.TypTransakcji, "TypTransakcjiID", "Typ", nieruchomosc.TypTransakcjiID);
            ViewBag.RodzajNieruchomosciID = new SelectList(db.RodzajNieruchomosci, "RodzajNieruchomosciID", "RodzajNieruchomosciRodzaj", nieruchomosc.RodzajNieruchomosciID);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", nieruchomosc.UserId);
            return View(nieruchomosc);
            //return RedirectToAction("Details", new { ID=id});
        }

        //
        // POST: /Nieruchomosci/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Nieruchomosc nieruchomosc)
        {
            //var x = nieruchomosc.Cena;
            if (ModelState.IsValid)
            {
                db.Entry(nieruchomosc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypTransakcjiID = new SelectList(db.TypTransakcji, "TypTransakcjiID", "Typ", nieruchomosc.TypTransakcjiID);
            ViewBag.RodzajNieruchomosciID = new SelectList(db.RodzajNieruchomosci, "RodzajNieruchomosciID", "RodzajNieruchomosciRodzaj", nieruchomosc.RodzajNieruchomosciID);
            ViewBag.UserId = new SelectList(db.UserProfile, "UserId", "UserName", nieruchomosc.UserId);
            return View(nieruchomosc);
           //return RedirectToAction("Details", new {id=nieruchomosc.NieruchomoscID });
        }

        //
        // GET: /Nieruchomosci/Delete/5
       [HttpGet]
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Nieruchomosc nieruchomosc = db.Nieruchomosc.Find(id);
            if (nieruchomosc == null)
            {
                return HttpNotFound();
            }
            return View(nieruchomosc);
        }

        //
        // POST: /Nieruchomosci/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nieruchomosc nieruchomosc = db.Nieruchomosc.Find(id);
            if (nieruchomosc.UserId == WebSecurity.GetUserId(User.Identity.Name))
            {
                db.Nieruchomosc.Remove(nieruchomosc);
                db.SaveChanges();
                return RedirectToAction("Ogloszenia");
            }
            else return RedirectToAction("Index","Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            TempData["id"] = id;
            Nieruchomosc nieruchomosc = db.Nieruchomosc.Find(id);
            if (nieruchomosc == null)
            {
                return HttpNotFound();
            }

            return View(nieruchomosc);
        }



        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        [Authorize]
        public ActionResult GetImage(int? id)
        {
            if (id == null)
            {
                return base.File("~/Images/Brak_miniatura.png", "image/png");
            }
            else
            {
                NieruchomoscPhoto nieruchomoscphoto = db.NieruchomoscPhoto.Find(id);
                byte[] image = nieruchomoscphoto.ImageData1;
                return File(image, "image/jpg");
            }

        }
[Authorize]
        public ActionResult GetImage1(int id)
        {
            NieruchomoscPhoto nieruchomoscphoto = db.NieruchomoscPhoto.Find(id);
            byte[] image = nieruchomoscphoto.ImageData;
            return File(image, "image/jpg");
        }
     [Authorize]
        public ActionResult Upload()
        {
            return View();
        }

        [Authorize]
        public ActionResult Upload1()
        {
            return View();
        }
[Authorize]
        [HttpPost]
        public ActionResult Upload(NieruchomoscPhoto IG)
        {
            // Apply Validation Here


            if (IG.File.ContentLength > (2 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                return View();
            }
            if (!(IG.File.ContentType == "image/jpeg" || IG.File.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                return View();
            }
            //IG.NieruchomoscID=1;

            int id2 = (int)TempData["id"];

            IG.NieruchomoscID = id2;
            IG.FileName = IG.File.FileName;
            IG.ImageSize = IG.File.ContentLength;

            byte[] data = new byte[IG.File.ContentLength];
            IG.File.InputStream.Read(data, 0, IG.File.ContentLength);

            IG.ImageData = data;
            //  using (EntitiesNieruchomosci dc = new EntitiesNieruchomosci())
            //{
            //   dc.NieruchomoscPhoto.Add(IG);
            // dc.SaveChanges();
            //}
            // return RedirectToAction("Gallery");
            //moje wyociny
            //Read image back from file and create thumbnail from it
            //var imageFile = Path.Combine(Server.MapPath("~/Content/Uploads/Originals"), filename);
            // using (var srcImage = Image.FromFile(imageFile))





            using (var newImage = new Bitmap(100, 100))
            using (var graphics = Graphics.FromImage(newImage))
            using (var stream = new MemoryStream())
            using (MemoryStream ms = new MemoryStream(data))
            {
                Image imageFile = Image.FromStream(ms);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(imageFile, new Rectangle(0, 0, 100, 100));
                newImage.Save(stream, ImageFormat.Jpeg);
                var thumbNew = File(stream.ToArray(), "image/jpeg");
                IG.ImageData1 = thumbNew.FileContents;
                //artwork.ArtworkThumbnail = thumbNew.FileContents;

            }



            using (EntitiesNieruchomosci dc = new EntitiesNieruchomosci())
            {
                dc.NieruchomoscPhoto.Add(IG);
                dc.SaveChanges();
            }




            //TempData["id2"] = id2;
            return RedirectToAction("Edit", new { Id = id2 });


        }

//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        [Authorize]
        [HttpPost]
        public ActionResult Upload1(NieruchomoscPhoto IG)
        {
            // Apply Validation Here


            if (IG.File.ContentLength > (2 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                return View();
            }
            if (!(IG.File.ContentType == "image/jpeg" || IG.File.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                return View();
            }
            //IG.NieruchomoscID=1;

            int id2 = (int)TempData["id"];

            IG.NieruchomoscID = id2;
            IG.FileName = IG.File.FileName;
            IG.ImageSize = IG.File.ContentLength;

            byte[] data = new byte[IG.File.ContentLength];
            IG.File.InputStream.Read(data, 0, IG.File.ContentLength);

            IG.ImageData = data;
            //  using (EntitiesNieruchomosci dc = new EntitiesNieruchomosci())
            //{
            //   dc.NieruchomoscPhoto.Add(IG);
            // dc.SaveChanges();
            //}
            // return RedirectToAction("Gallery");
            //moje wyociny
            //Read image back from file and create thumbnail from it
            //var imageFile = Path.Combine(Server.MapPath("~/Content/Uploads/Originals"), filename);
            // using (var srcImage = Image.FromFile(imageFile))





            using (var newImage = new Bitmap(100, 100))
            using (var graphics = Graphics.FromImage(newImage))
            using (var stream = new MemoryStream())
            using (MemoryStream ms = new MemoryStream(data))
            {
                Image imageFile = Image.FromStream(ms);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(imageFile, new Rectangle(0, 0, 100, 100));
                newImage.Save(stream, ImageFormat.Jpeg);
                var thumbNew = File(stream.ToArray(), "image/jpeg");
                IG.ImageData1 = thumbNew.FileContents;
                //artwork.ArtworkThumbnail = thumbNew.FileContents;

            }



            using (EntitiesNieruchomosci dc = new EntitiesNieruchomosci())
            {
                dc.NieruchomoscPhoto.Add(IG);
                dc.SaveChanges();
            }




            //TempData["id2"] = id2;
            return RedirectToAction("Edit", new { Id = id2 });


        }

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        [Authorize]
        public ActionResult DeletePhoto(int id = 0)
        {
            NieruchomoscPhoto nieruchomoscphoto = db.NieruchomoscPhoto.Find(id);
            if (nieruchomoscphoto == null)
            {
                return HttpNotFound();
            }
            //return View(nieruchomoscphoto);
            db.NieruchomoscPhoto.Remove(nieruchomoscphoto);
            db.SaveChanges();
            return RedirectToAction("Edit", new { Id = nieruchomoscphoto.NieruchomoscID });
        }

        //
        // POST: /Galeria/Delete/5
/*
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedPhoto(int id)
        {
            NieruchomoscPhoto nieruchomoscphoto = db.NieruchomoscPhoto.Find(id);
            db.NieruchomoscPhoto.Remove(nieruchomoscphoto);
            db.SaveChanges();
            return RedirectToAction("Edit", new { Id = nieruchomoscphoto.NieruchomoscID });
        }*/
    }
}
