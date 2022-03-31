using PapeleriaBellasArtes.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PapeleriaBellasArtes.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productosBL = new ProductosBL();
            var listadeProductos = productosBL.ObtenerProductos();
            ViewBag.adminWebSiteUrl = ConfigurationManager.AppSettings["adminWebSiteUrl"];
            return View(listadeProductos);
        }
    }
}