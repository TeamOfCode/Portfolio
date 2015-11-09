using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PropertyManager.IRepo;
using PropertyManager.Models;
using PropertyManager.Models.PropertyModels;

namespace PropertyManager.Repo
{
    public class RepoViewModelPropertyPropertyPhoto : IRepoViewModelPropertyPropertyPhoto
    {
        private readonly PropertyManagerContext _db = new PropertyManagerContext();

        public IQueryable<Property> GetAll()
        {
            //var property = _db.Properties.Include(x=>x.PropertyType)

            var property = _db.Properties;
            
            //db.Properties.Include(x => x.PropertyType)
            //    .Include(x => x.PropertyType)
            //    .Include(x => x.UserProfile);

            return property;
        }

    }
}