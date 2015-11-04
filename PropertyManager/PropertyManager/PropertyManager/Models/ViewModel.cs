using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using PropertyManager.Models.PropertyModels;

namespace PropertyManager.Models
{
    public class ViewModel
    {
        [Display(Name = "ID")]
        public int PropertyId { get; set; }

        [Display(Name = "Rodzaj transakcji")]
        public int TransactionTypeId { get; set; }

        [Display(Name = "Rodzaj nieruchomości")]
        public int PropertyTypeId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public decimal? Area { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        public decimal? Cena { get; set; }

        public DateTime AddDate { get; set; }

        public virtual TransactionType TransactiontYpe { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<PropertyPhoto> PropertyPhotos { get; set; }

        public int? ImageId { get; set; }
        public byte[] ImageData1 { get; set; }
        public byte[] ImageData2 { get; set; }

        [Required(ErrorMessage = "Please select file")]
        public HttpPostedFileBase File { get; set; }
        public virtual Property Property { get; set; }
    }
}