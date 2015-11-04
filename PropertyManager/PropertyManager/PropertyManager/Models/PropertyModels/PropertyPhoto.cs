using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Razor.Parser.SyntaxTree;

namespace PropertyManager.Models.PropertyModels
{
    public class PropertyPhoto
    {
        public int PropertyId { get; set; }
        public int ImageId { get; set; }
        public int ImageSize { get; set; }

        [Display(Name = "Nazwa pliku")]
        public string FileName { get; set; }

        [Required(ErrorMessage = "Proszę wybrać plik.")]
        public HttpPostedFileBase File { get; set; }

        public byte[] ImageData1 { get; set; }
        public byte[] ImageData2 { get; set; }
        public virtual Property Property { get; set; }
    }
}