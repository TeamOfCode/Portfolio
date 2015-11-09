using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using PropertyManager.Models;
using PropertyManager.Models.PropertyModels;
using System.Web.Mvc;

namespace PropertyManager.Repo
{
    public class FotoRepo
    {
        private readonly PropertyManagerContext db = new PropertyManagerContext();
      
        
        
        public IQueryable<PropertyPhoto> GetAllFotosForUserProperty(int propertyId, string userId)
        {
            
            if (userId == GetUserByPropertyId(propertyId))
            {
                return db.PropertyPhotos.Where(p => p.PropertyId == propertyId);
            }

            return null;
        }






        public string GetUserByPropertyId(int propertyId)
        {
            var properrtyUserId = db.Properties.Where(x => x.PropertyId == propertyId).Select(x => x.UserId);
            return properrtyUserId.ToString();
        }

       




        public PropertyPhoto GetFotoById(int id)
        {
            return db.PropertyPhotos.Find(id);
        }



        public PropertyPhoto GetFirstFotoByPropertyId(int id)
        {
            return db.PropertyPhotos.FirstOrDefault(x => x.PropertyId == id);
        }





        public bool DeleteFoto(int id)
        {
            PropertyPhoto foto = GetFotoById(id);
            db.PropertyPhotos.Remove(foto);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public int UploadImageInDataBase(HttpPostedFileBase file, PropertyPhoto fotoModel)
        {
            //    fotoModel.FotoData = ConvertToBytes(file);
            Image sourceimage = Image.FromStream(file.InputStream);
            fotoModel.FotoData = ConvertImageToBytes(sourceimage);

            var min = ScaleImage(sourceimage, 300, 300);
            fotoModel.FotoMiniatureData = ConvertImageToBytes(min);

            var foto = new PropertyPhoto
            {
                FotoSize = file.ContentLength,
                Description = fotoModel.Description,
                FileName = fotoModel.FileName,
                FotoData = fotoModel.FotoData,
                FotoMiniatureData = fotoModel.FotoMiniatureData
            };
            db.PropertyPhotos.Add(foto);
            int i = db.SaveChanges();
            return i == 1 ? 1 : 0;
        }

        public static byte[] ConvertImageToBytes(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        static public Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }

        //public List<FotoModelView> DisplayFotoModelViews(IQueryable<FotoModel> fotoModel)
        //{
        //    List<FotoModelView> viewFotos = new List<FotoModelView>();
        //    foreach (var item in fotoModel)
        //    {
        //        viewFotos.Add(

        //            new FotoModelView
        //            {
        //                FotoId = item.FotoId,
        //                FotoSize = item.FotoSize,
        //                Description = item.Description,
        //                FileName = item.FileName,
        //                FotoData = "data:image/png;base64," + Convert.ToBase64String(item.FotoData),
        //                FotoMiniatureData = "data:image/png;base64," + Convert.ToBase64String(item.FotoMiniatureData)
        //            }
        //        );
        //    }


        //    return viewFotos;
        //}






    }
}