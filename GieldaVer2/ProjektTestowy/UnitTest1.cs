using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nieruchomosci.Controllers;
using Nieruchomosci.Models;
using Nieruchomosci.Repo;
using PagedList;

namespace ProjektTestowy
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*AdminController admin = new AdminController();
            var lista = admin.OgloszeniaLista() as ViewResult;
            var model = lista.Model as IPagedList<Nieruchomosci.Models.Nieruchomosc>;
*/
                  EntitiesNieruchomosci db = new EntitiesNieruchomosci();
                  var nieruchomosc = db.Nieruchomosc.Include(n => n.TypTransakcji).Include(n => n.RodzajNieruchomosci).Include(n => n.UserProfile);
            OgloszeniaRepo repo = new OgloszeniaRepo();
            //var lista = repo.GetAll();
            //int a = 5;


        }
    }
}
