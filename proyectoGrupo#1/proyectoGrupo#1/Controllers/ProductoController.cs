using proyectoGrupo_1.BaseDatos;
using proyectoGrupo_1.Entidades;
using proyectoGrupo_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoGrupo_1.Controllers
{
    public class ProductoController : Controller
    {
        ProductoModel prodM = new ProductoModel();
        CategoriaModel catM = new CategoriaModel();

        [HttpGet]
        public ActionResult RegistrarProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarProducto(Producto prod)
        {

            var respuesta = prodM.RegistrarProducto(prod);

            if (respuesta)
                return RedirectToAction("VerProductos", "Producto");
            else
            {
                ViewBag.msj = "La informacion del producto ya esta en la base de datos";
                return View();
            }

        }

        [HttpGet]
        public ActionResult VerProductos()
        {
            var respuesta = prodM.VerProductos();
            return View(respuesta);
        }

        [HttpGet]
        public ActionResult VerCelulares()
        {
            var respuesta = prodM.VerCelulares();
            return View(respuesta);
        }

        [HttpGet]
        public ActionResult VerAccesorios()
        {
            var respuesta = prodM.VerAccesorios();
            return View(respuesta);
        }

        [HttpGet]
        public ActionResult VerComputadoras()
        {
            var respuesta = prodM.VerComputadoras();
            return View(respuesta);
        }

        [HttpGet]
        public ActionResult EditarProducto(int id)
        {
            var respuesta = prodM.ConsultarProducto(id);
            var categoria = catM.ConsultarCat();

            List<SelectListItem> lstCategoria = new List<SelectListItem>();
            foreach (var item in categoria)
            {
                lstCategoria.Add(new SelectListItem { Value = item.idCategoria.ToString(), Text = item.Nombre });
            }

            ViewBag.Roles = lstCategoria;
            return View(respuesta);
        }

        [HttpPost]
        public ActionResult EditarProducto(Producto prod)
        {
            var respuesta = prodM.EditarProducto(prod);

            if (respuesta)
                return RedirectToAction("VerProductos", "Producto");
            else
            {
                ViewBag.msj = "No se ha podido actualizar su información de perfil";
                return View();
            }
        }



    }
    }