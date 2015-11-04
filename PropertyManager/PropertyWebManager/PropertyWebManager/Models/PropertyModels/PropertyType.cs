using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyWebManager.Models.PropertyModels
{
    public class PropertyType
    {
        public PropertyType()
        {
            this.Properties = new HashSet<Property>();
        }

        public int PropertyTypeId { get; set; }

        [Display(Name = "Rodzaj nieruchomości")]
        public string TypePropertyType { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}