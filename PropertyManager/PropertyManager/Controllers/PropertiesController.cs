using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PropertyManager.Models;
using PropertyManager.Models.PropertyModels;

namespace PropertyManager.Controllers
{
    public class PropertiesController : Controller
    {
        private PropertyManagerContext db = new PropertyManagerContext();

        // GET: Properties
        public ActionResult Index()
        {
            var properties = db.Properties.Include(p => p.ApplicationUser).Include(p => p.PropertyType).Include(p => p.TransactionType);

         

            return View(properties.ToList());

           
        }

        // GET: Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "PropertyTypeId", "TypePropertyType");
            ViewBag.TransactionTypeId = new SelectList(db.TransactionTypes, "TransactionTypeId", "Type");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PropertyId,TransactionTypeId,PropertyTypeId,UserId,PropertyCategory,BuildingType,Address,City,Area,LotArea,Floor,Standard,RoomsAmount,BuildYear,Price,ImprovedLand,Description,Advertiser,PhoneNumber,AddDate")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Properties.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", property.UserId);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "PropertyTypeId", "TypePropertyType", property.PropertyTypeId);
            ViewBag.TransactionTypeId = new SelectList(db.TransactionTypes, "TransactionTypeId", "Type", property.TransactionTypeId);
            return View(property);
        }

        // GET: Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", property.UserId);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "PropertyTypeId", "TypePropertyType", property.PropertyTypeId);
            ViewBag.TransactionTypeId = new SelectList(db.TransactionTypes, "TransactionTypeId", "Type", property.TransactionTypeId);
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PropertyId,TransactionTypeId,PropertyTypeId,UserId,PropertyCategory,BuildingType,Address,City,Area,LotArea,Floor,Standard,RoomsAmount,BuildYear,Price,ImprovedLand,Description,Advertiser,PhoneNumber,AddDate")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", property.UserId);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "PropertyTypeId", "TypePropertyType", property.PropertyTypeId);
            ViewBag.TransactionTypeId = new SelectList(db.TransactionTypes, "TransactionTypeId", "Type", property.TransactionTypeId);
            return View(property);
        }

        // GET: Properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.Properties.Find(id);
            db.Properties.Remove(property);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
