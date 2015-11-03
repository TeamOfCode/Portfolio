using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamOfCodeX.Models
{
    public class ContactModel
    {

        [Required, Display(Name = "Your name")]
        public string FromName { get; set; }

        [Required, Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }  
    }
}