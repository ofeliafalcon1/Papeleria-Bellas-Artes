using PapeleriaBellasArtes.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PapeleriaBellasArtes.WebAdmin.Controllers
{
    public class ClientesController : Controller
    {
        ClienteBL _clienteBl;

        public ClientesController()
        {
            _clienteBl = new ClienteBL();

        }

        // GET: Clientes
        public ActionResult Index()
        {
            var listadeClientes = _clienteBl.ObtenerClientes();

            return View(listadeClientes);

        }

        public ActionResult Crear()
        {
            var nuevoCliente = new Cliente();

            return View(nuevoCliente);
        }

        [HttpPost]
        public ActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid) //ModelState revisa y compara los atributos de la clase cliente
            {
                if (cliente.Nombre != cliente.Nombre.Trim())//Trim es una funcion que detecta si hay espacios innecesarios en el texto
                {
                    ModelState.AddModelError("Nombre", "El Nombre no debe contener espacios al inicio ni al final");
                    return View(cliente);
                }
                _clienteBl.GuardarCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Editar(int id)
        {
            var cliente = _clienteBl.ObtenerCliente(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid) //ModelState revisa y compara los atributos de la clase cliente
            {
                if (cliente.Nombre != cliente.Nombre.Trim())//Trim es una funcion que detecta si hay espacios innecesarios en el texto
                {
                    ModelState.AddModelError("Nombre", "El Nombre no debe contener espacios al inicio ni al final");
                    return View(cliente);
                }
                _clienteBl.GuardarCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Detalle(int id)
        {
            var cliente = _clienteBl.ObtenerCliente(id);

            return View(cliente);
        }

        public ActionResult Eliminar(int id)
        {
            var cliente = _clienteBl.ObtenerCliente(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Eliminar(Cliente cliente)
        {
            _clienteBl.EliminarCliente(cliente.Id);

            return RedirectToAction("Index");
        }
    }

}