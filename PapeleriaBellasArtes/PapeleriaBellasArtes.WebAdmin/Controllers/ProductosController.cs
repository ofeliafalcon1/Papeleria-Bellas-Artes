using PapeleriaBellasArtes.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PapeleriaBellasArtes.WebAdmin.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        ProductosBL _productosBl;
        CategoriasBL _categoriasBL;

        public ProductosController()
        {
            _productosBl = new ProductosBL();
            _categoriasBL = new CategoriasBL();
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
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoProducto); 
        }

        [HttpPost]
        public ActionResult Crear(Producto producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }

                if(imagen != null)
                {
                    producto.UrlImagen = GuardarImagen(imagen);
                }
                _productosBl.GuardarProducto(producto);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();//Enviamos a la Lista de Categorias
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");
            return View(producto);
        }

        public ActionResult Editar(int id)
        {
           var producto = _productosBl.ObtenerProducto(id);
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);
            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Producto producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }

                if (imagen != null)
                {
                    producto.UrlImagen = GuardarImagen(imagen);
                }
                _productosBl.GuardarProducto(producto);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategorias();//Enviamos a la Lista de Categorias
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");
            return View(producto);
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

        private string GuardarImagen(HttpPostedFileBase imagen)//Funcion guardar imagen
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }
    }
}