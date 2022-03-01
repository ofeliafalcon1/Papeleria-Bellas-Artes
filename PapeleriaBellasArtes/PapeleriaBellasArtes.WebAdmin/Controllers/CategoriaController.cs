using PapeleriaBellasArtes.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PapeleriaBellasArtes.WebAdmin.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaBL _categoriasBL;

        public CategoriaController ()
        {
            _categoriasBL = new CategoriaBL();
        }

        // GET: Categoria
        public ActionResult Index()
        {
            var listadeCategoria = _categoriasBL.ObtenerCategorias();

            return View(listadeCategoria);

        }

        public ActionResult Crear()
        {
            var nuevoCategoria = new Categoria();

            return View(nuevoCategoria);
        }

        [HttpPost]
        public ActionResult Crear(Categoria categoria)
        {
            if (ModelState.IsValid) //ModelState revisa y compara los atributos de la clase categoria
            {
                if(categoria.Descripcion != categoria.Descripcion.Trim())//Trim es una funcion que detecta si hay espacios innecesarios en el texto
                {
                    ModelState.AddModelError("Descripcion", "La descripción no debe contener espacios al inicio ni al final");
                    return View(categoria);
                }
                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Editar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid) //ModelState revisa y compara los atributos de la clase categoria
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())//Trim es una funcion que detecta si hay espacios innecesarios en el texto
                {
                    ModelState.AddModelError("Descripcion", "La descripción no debe contener espacios al inicio ni al final");
                    return View(categoria);
                }
                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Detalle(int id)
        {
            var producto = _categoriasBL.ObtenerCategoria(id);

            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var categoria = _categoriasBL.ObtenerCategoria(id);

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Eliminar(Categoria categoria)
        {
            _categoriasBL.EliminarCategoria(categoria.Id);

            return RedirectToAction("Index");
        }
    }
}