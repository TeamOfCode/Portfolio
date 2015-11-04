using System.Collections.Generic;

namespace PropertyWebManager.Models.PropertyModels
{
    public class WebPagesRoles
    {
        public WebPagesRoles()
        {
            this.UserProfiles = new HashSet<UserProfile>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}