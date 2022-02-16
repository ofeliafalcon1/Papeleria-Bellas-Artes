using PapeleriaBellasArtes.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PapeleriaBellasArtes.WebAdmin.Controllers
{
    public class ProductosController : Controller
    {
        ProductosBL _productosBl;

        public ProductosController()
        {
            _productosBl = new ProductosBL();
        }

        // GET: Productos
        public ActionResult Index()
        {
            var listadeProductos = _productosBl.ObtenerProductos();

            return View(listadeProductos);
        }

        public ActionResult Crear()
        {
            var nuevoProducto = new Producto(); 

            return View(nuevoProducto); 
        }

        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            _productosBl.GuardarProducto(producto);
            return RedirectToAction("Index");
        } 

        public ActionResult Editar(int id)
        {
           var producto = _productosBl.ObtenerProducto(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Producto producto)
        {

            _productosBl.GuardarProducto(producto);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var producto = _productosBl.ObtenerProducto(id);

            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _productosBl.ObtenerProducto(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _productosBl.EliminarProducto(producto.Id);


            return RedirectToAction("Index");
        }
    }
}