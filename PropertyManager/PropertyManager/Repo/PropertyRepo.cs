using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.Provider;
using PropertyManager.Models;
using PropertyManager.Models.PropertyModels;

namespace PropertyManager.Repo
{
    public class PropertyRepo
    {
        private readonly PropertyManagerContext db = new PropertyManagerContext();

     
        
        
        
        
        public IQueryable<Property> GetAllPropertyForUser(string userId)
        {

        
            var properties = db.Properties;

            return properties;
        }

        public IQueryable<Property> GetAllProperty()
        {


            var properties = db.Properties.Include(p => p.ApplicationUser).Include(p => p.PropertyType).Include(p => p.TransactionType);

            return properties;
        }


        public string GetUserByPropertyId(int propertyId)
        {
            var properrtyUserId = db.Properties.Where(x => x.PropertyId == propertyId).Select(x => x.UserId);
            return properrtyUserId.ToString();
        }


        public Property GetPropertyById(int id)
        {
            return db.Properties.Find(id);
        }

      
        
        public bool DeleteFoto(int id)
        {
            Property property = GetPropertyById(id);
            db.Properties.Remove(property);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }








    }
}