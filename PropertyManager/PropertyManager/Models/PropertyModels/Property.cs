using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManager.Models.PropertyModels
{
    public class Property
    {
           public Property()
        {
            this.PropertyPhotos = new HashSet<PropertyPhoto>();
        }

        [Display(Name = "ID")]
        public int PropertyId { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Rodzaj transakcji")]
        public int TransactionTypeId { get; set; }

        [Display(Name = "Rodzaj nieruchomości")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public int PropertyTypeId { get; set; }

        [Display(Name = "Użytkownik")]
        public int UserId { get; set; }

        [Display(Name = "Typ nieruchomości")]
        [StringLength(50, ErrorMessage = "Maksymalna długość pola {0} wynosi {1} znaków")]
        public string PropertyCategory { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Typ budynku")]
        [StringLength(50, ErrorMessage = "Maksymalna długość pola {0} wynosi {1} znaków")]
        public string BuildingType { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Adres")]
        [StringLength(100, ErrorMessage = "Maksymalna długość pola {0} wynosi {1} znaków")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "City")]
        [StringLength(100, ErrorMessage = "Maksymalna długość pola {0} wynosi {1} znaków")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Powierzchnia")]
        public Nullable<decimal> Area { get; set; }

        [Display(Name = "Powierzchnia działki")]
        public Nullable<decimal> LotArea { get; set; }

        [Display(Name = "Piętro")]
        public Nullable<int> Floor { get; set; }

        public string Standard { get; set; }

        [Display(Name = "Liczba pokoi")]
        public Nullable<int> RoomsAmount { get; set; }

        [Display(Name = "Rok budowy")]
        public Nullable<int> BuildYear { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Cena")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Uzbrojenie")]
        [StringLength(50, ErrorMessage = "Maksymalna długość pola {0} wynosi {1} znaków")]
        public string ImprovedLand { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Ogłoszeniodawca")]
        [StringLength(100, ErrorMessage = "Maksymalna długość pola {0} wynosi {1} znaków")]
        public string Advertiser { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Telefon kontaktowy")]
        [DataType(DataType.Text)]
        [StringLength(9, ErrorMessage = "Maksymalna długość pola {0} wynosi {1} znaków")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Data dodania")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public System.DateTime AddDate { get; set; }

        public virtual TransactionType TransactionType { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        //public virtual UserProfile UserProfile { get; set; }
        public virtual ApplicationUser UserProfile { get; set; }
        public virtual ICollection<PropertyPhoto> PropertyPhotos { get; set; }
    }


    }
