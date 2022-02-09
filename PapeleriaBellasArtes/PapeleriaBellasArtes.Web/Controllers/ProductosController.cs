using PapeleriaBellasArtes.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PapeleriaBellasArtes.Web.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {

            //Agregamos produtos//
            var productosBL = new ProductosBL();
            var listadeProductos = productosBL.ObtenerProductos();   //Obtenemos productos

         return View(listadeProductos);       //retornamos la lista de productos//
        }
    }
}