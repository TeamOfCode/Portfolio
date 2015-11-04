using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyWebManager.Models.PropertyModels
{
    public class UserProfile
    {
        public UserProfile()
        {
            this.Properties = new HashSet<Property>();
            this.WebPagesRoles = new HashSet<WebPagesRoles>();
        }

        public int UserId { get; set; }
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<WebPagesRoles> WebPagesRoles { get; set; }

    }
}