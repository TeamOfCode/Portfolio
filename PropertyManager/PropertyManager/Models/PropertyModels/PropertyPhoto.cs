using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManager.Models.PropertyModels
{
    public class PropertyPhoto
    {
        [Key]
        public int FotoId { get; set; }
        public int PropertyId { get; set; }
        public int FotoSize { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Nazwa")]
        public string FileName { get; set; }
        public byte[] FotoData { get; set; }

        public byte[] FotoMiniatureData { get; set; }
        public virtual Property Property { get; set; }

    }
}