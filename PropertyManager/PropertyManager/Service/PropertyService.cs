using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PropertyManager.Models.PropertyModels;
using PropertyManager.Repo;

namespace PropertyManager.Service
{
    public class PropertyService
    {
        private PropertyRepo _propertyRepo;
        private FotoRepo _fotoRepo;


        public PropertyService()
        {
            _propertyRepo=new PropertyRepo();
            _fotoRepo=new FotoRepo();

        }



        public List<ViewModelPropertyPropertyPhoto> GetAllPropertiesWithFirstPhotoProperty()
        {
            var property = _propertyRepo.GetAllProperty().ToList();
            var propertyPhoto = property.Select(x => _fotoRepo.GetFirstFotoByPropertyId(x.PropertyId)).ToList();
            var propertyWithPhoto = new List<ViewModelPropertyPropertyPhoto>();
            for (int i = 0; i < property.Count(); i++)
            {
                propertyWithPhoto.Add(new ViewModelPropertyPropertyPhoto()
                {
                    Property = property[i],
                    
                    PropertyPhoto = propertyPhoto[i]


                });

            }



            return propertyWithPhoto;
        }


        // ImageConverter converter = new ImageConverter();
    //return (byte[])converter.ConvertTo(img, typeof(byte[]));


        //public FileContentResult getImg(int id)
        //{

        //    ImageConverter converter = new ImageConverter();
        //    var img = ("~/Images/Brak_miniatura.png");
        //    byte[] byteArray = _fotoRepo.GetFirstFotoByPropertyId(id).FotoData;
        //    return byteArray != null
        //        ? new FileContentResult(byteArray, "image/jpeg")
        //        : new FileContentResult((byte[])converter.ConvertTo(img, typeof(byte[]));
                    
                    
                    

        //}



    }
}