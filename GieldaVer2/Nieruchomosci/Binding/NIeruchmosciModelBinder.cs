using System.Web.Mvc;
using Nieruchomosci.Models;

namespace Nieruchomosci.Binding
{
    public class NIeruchmosciModelBinder : IModelBinder
    {
        private const string sessionKey = "ViewModelFiltrowanieOgloszenie";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ViewModelFiltrowanieOgloszenie ogl = (ViewModelFiltrowanieOgloszenie)controllerContext.HttpContext.Session[sessionKey];

            ViewModelFiltrowanieOgloszenie ogl2 = (ViewModelFiltrowanieOgloszenie) bindingContext.Model;


            return ogl;
        }
    }
}