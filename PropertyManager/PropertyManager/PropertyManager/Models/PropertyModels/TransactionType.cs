using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PropertyManager.Models.PropertyModels
{
    public class TransactionType
    {
        public TransactionType()
        {
            this.Properties = new HashSet<Property>();
        }

        public int TransactionTypeId { get; set; }

        [Display(Name = "Typ transakcji")]
        public string Type { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}