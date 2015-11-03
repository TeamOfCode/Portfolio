using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Nieruchomosci.IRepo;
using Nieruchomosci.Models;
using Nieruchomosci.Repo;
using PagedList;

namespace Nieruchomosci.Controllers
{
    public class AdminController : Controller
    {
        private readonly EntitiesNieruchomosci db1 = new EntitiesNieruchomosci();
        private readonly IOgloszeniaRepo repo;

        public AdminController()
        {
            repo = new OgloszeniaRepo();
        }

        //
        // GET: /Admin1/

        [Authorize(Roles = "Admin")]
        public ActionResult Users()
        {
            return View(db1.UserProfile.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin1/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id = 0)
        {
            var userprofile = db1.UserProfile.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // GET: /Admin1/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id = 0)
        {
            var userprofile = db1.UserProfile.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /Admin1/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var userprofile = db1.UserProfile.Find(id);
            db1.UserProfile.Remove(userprofile);
            db1.SaveChanges();
            return RedirectToAction("Users");
        }

        protected override void Dispose(bool disposing)
        {
            db1.Dispose();
            base.Dispose(disposing);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //nowe role
        [Authorize(Roles = "Admin")]
        public ActionResult RoleCreate()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleCreate(string RoleName)
        {
            Roles.CreateRole(Request.Form["RoleName"]);
            // ViewBag.ResultMessage = "Role created successfully !";

            return RedirectToAction("RoleIndex", "Account");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult RoleIndex()
        {
            var roles = Roles.GetAllRoles();
            return View(roles);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult RoleDelete(string RoleName)
        {
            Roles.DeleteRole(RoleName);
            // ViewBag.ResultMessage = "Role deleted succesfully !";


            return RedirectToAction("RoleIndex", "Account");
        }


        /// <summary>
        ///     Create a new role to the user
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult RoleAddToUser()
        {
            var list = new SelectList(Roles.GetAllRoles());
            ViewBag.Roles = list;

            return View();
        }

        /// <summary>
        ///     Add role to the user
        /// </summary>
        /// <param name="RoleName"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string RoleName, string UserName)
        {
            if (Roles.IsUserInRole(UserName, RoleName))
            {
                ViewBag.ResultMessage = "Użytkownik ma już przypisana taką rolę !";
            }
            else
            {
                Roles.AddUserToRole(UserName, RoleName);
                ViewBag.ResultMessage = "Użytkownik dodany do roli poprawnie !";
            }

            var list = new SelectList(Roles.GetAllRoles());
            ViewBag.Roles = list;
            return View();
        }

        /// <summary>
        ///     Get all the roles for a particular user
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ViewBag.RolesForThisUser = Roles.GetRolesForUser(UserName);
                var list = new SelectList(Roles.GetAllRoles());
                ViewBag.Roles = list;
            }
            return View("RoleAddToUser");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            if (Roles.IsUserInRole(UserName, RoleName))
            {
                Roles.RemoveUserFromRole(UserName, RoleName);
                ViewBag.ResultMessage = "Rola usunięta z tego użytkownika poprawnie!";
            }
            else
            {
                ViewBag.ResultMessage = " Ten użytkownik nie należy do tej roli";
            }
            ViewBag.RolesForThisUser = Roles.GetRolesForUser(UserName);
            var list = new SelectList(Roles.GetAllRoles());
            ViewBag.Roles = list;


            return View("RoleAddToUser");
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        [Authorize(Roles = "Admin")]
        //public ViewResult Ogloszenia(string sortOrder, string miasto, string searchString, decimal? cenaod, decimal? cenado, decimal? powierzchniaod, decimal? powierzchniado, string rodzaj, int? page)
        public ActionResult OgloszeniaFormularz()
        {
            var listaOgloszen = repo.GetAll();


            return PartialView();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------
        /*[Authorize(Roles = "Admin")]
        [HttpPost, ActionName("OgloszeniaLista")]
      
        [ValidateAntiForgeryToken]
        public ActionResult OgloszeniaListaPost(ViewModelFiltrowanieOgloszenie ogloszenie, int page = 1)
        {
            var pageSize = 10;
            var listaNieruchomosci = repo.WyszukajOgloszenia(ogloszenie);
            return PartialView(listaNieruchomosci.ToPagedList(page, pageSize));
        }*/

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult OgloszeniaLista(ViewModelFiltrowanieOgloszenie ogloszenie, int page = 1)
        {
            IQueryable<Nieruchomosc> listaNieruchomosci = ogloszenie == null
                ? repo.GetAll().OrderBy(x => x.Miasto)
                : repo.WyszukajOgloszenia(ogloszenie).OrderBy(x => x.Miasto);

            var pageSize = 10;

            return PartialView(new OgloszeniaViewModel()
            {
                Nieruchomosci = listaNieruchomosci.ToList().ToPagedList(page, pageSize),
                Filtrowanie = ogloszenie
            });
        }

        //public ActionResult OgloszeniaLista(ViewModelFiltrowanieOgloszenie nieruchomosci, int page = 1)
        //public ActionResult OgloszeniaLista(Nieruchomosc nieruchomoscsi,int page = 1)
        //{
        //    var pageSize = 10;
        //    var lista = nieruchomoscsi;
        //    /*return PartialView(nieruchomosci.ToPagedList(page, pageSize));*/
        //    return PartialView(new OgloszeniaViewModel()
        //    {
        //        Nieruchomosci = null,
        //        pageNumber = page,
        //        pageSize = pageSize
        //    });
        //}
        
        [Authorize(Roles = "Admin")]
        public ActionResult WszystkieOgloszenia()
        {
            var pageNumber = 1;
            var pageSize = 10;
            var nieruchomoscs = repo.GetAll().OrderBy(x => x.Miasto).ToList();
            /*return PartialView("OgloszeniaLista",nieruchomoscs.ToPagedList(pageNumber, pageSize));*/
            return PartialView("OgloszeniaLista", new OgloszeniaViewModel()
            {
                Nieruchomosci = nieruchomoscs.ToPagedList(pageNumber, pageSize),
                Filtrowanie = null});
        }

        public ActionResult Ogloszenia()
        {
             /*var listaNieruchomosci = repo.GetAll();
            return View(new PagedList<Nieruchomosc>(listaNieruchomosci.ToList(),1,10));*/
            return View();
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteO(int id = 0)
        {
            var nieruchomosc = db1.Nieruchomosc.Find(id);
            if (nieruchomosc == null)
            {
                return HttpNotFound();
            }
            return View(nieruchomosc);
        }

        //
        // POST: /Nieruchomosci/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("DeleteO")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedO(int id)
        {
            var nieruchomosc = db1.Nieruchomosc.Find(id);
            db1.Nieruchomosc.Remove(nieruchomosc);
            db1.SaveChanges();
            return RedirectToAction("Ogloszenia");
        }


        [Authorize(Roles = "Admin")]
        public ActionResult EditO(int id = 0)
        {
            var nieruchomosc = db1.Nieruchomosc.Find(id);
            if (nieruchomosc == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypTransakcjiID = new SelectList(db1.TypTransakcji, "TypTransakcjiID", "Typ",
                nieruchomosc.TypTransakcjiID);
            ViewBag.RodzajNieruchomosciID = new SelectList(db1.RodzajNieruchomosci, "RodzajNieruchomosciID",
                "RodzajNieruchomosciRodzaj", nieruchomosc.RodzajNieruchomosciID);
            ViewBag.UserId = new SelectList(db1.UserProfile, "UserId", "UserName", nieruchomosc.UserId);
            return View(nieruchomosc);
        }

        //
        // POST: /Nieruchomosci/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditO(Nieruchomosc nieruchomosc)
        {
            if (ModelState.IsValid)
            {
                db1.Entry(nieruchomosc).State = EntityState.Modified;
                db1.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypTransakcjiID = new SelectList(db1.TypTransakcji, "TypTransakcjiID", "Typ",
                nieruchomosc.TypTransakcjiID);
            ViewBag.RodzajNieruchomosciID = new SelectList(db1.RodzajNieruchomosci, "RodzajNieruchomosciID",
                "RodzajNieruchomosciRodzaj", nieruchomosc.RodzajNieruchomosciID);
            ViewBag.UserId = new SelectList(db1.UserProfile, "UserId", "UserName", nieruchomosc.UserId);
            return View(nieruchomosc);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsO(int id = 0)
        {
            var nieruchomosc = db1.Nieruchomosc.Find(id);
            if (nieruchomosc == null)
            {
                return HttpNotFound();
            }
            return View(nieruchomosc);
        }
    }
}