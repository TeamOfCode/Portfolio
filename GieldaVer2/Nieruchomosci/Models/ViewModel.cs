using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nieruchomosci.Models
{
    public class ViewModel
    {
    /*   public IEnumerable<Nieruchomosc> Nieruchomosc { get; set; }
        public IEnumerable<NieruchomoscPhoto> NieruchomoscPhoto { get; set; }*/
      /*  public PagedList.IPagedList<Nieruchomosc> Nieruchomosc { get; set; }
        public PagedList.IPagedList<NieruchomoscPhoto> NieruchomoscPhoto { get; set; }*/

        [Display(Name = "ID")]
        public int NieruchomoscID { get; set; }
        [Display(Name = "Rodzaj transakcji")]
        public int TypTransakcjiID { get; set; }
        [Display(Name = "Rodzaj nieruchomości")]
        public int RodzajNieruchomosciID { get; set; }
        public string Adres { get; set; }
        public string Miasto { get; set; }
      
        public Nullable<decimal> Powierzchnia { get; set; }

       /* [Display(Name = "Rodzaj transakcji")]
        public int TypTransakcji { get; set; }
        [Display(Name = "Rodzaj nieruchomości")]
        public int RodzajNieruchomosci { get; set; }*/



        [Required(ErrorMessage = "Pole jest wymagane")]

        [DisplayFormat(DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        public Nullable<decimal> Cena { get; set; }
        [Display(Name = "Data dodania")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public System.DateTime Data_dodania { get; set; }

        public virtual TypTransakcji TypTransakcji { get; set; }
        public virtual RodzajNieruchomosci RodzajNieruchomosci { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<NieruchomoscPhoto> NieruchomoscPhotos { get; set; }


       
       public int? ImageID { get; set; }


        public byte[] ImageData { get; set; }
        [Required(ErrorMessage = "Please select file")]
        public HttpPostedFileBase File { get; set; }
        public byte[] ImageData1 { get; set; }
        public virtual Nieruchomosc Nieruchomosc { get; set; }









    }
}