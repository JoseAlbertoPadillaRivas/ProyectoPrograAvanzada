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
    [Filtro]
    public class ProductoController : Controller
    {
        ProductoModel prodM = new ProductoModel();
        CategoriaModel catM = new CategoriaModel();
        CarritoModel carritoM = new CarritoModel();

        [FiltroAdmin]
        [HttpGet]
        public ActionResult RegistrarProducto()
        {
            return View();
        }
        [FiltroAdmin]
        [HttpPost]
        public ActionResult RegistrarProducto(Producto prod)
        {

            var respuesta = prodM.RegistrarProducto(prod);
            //var categoria = catM.ConsultarCategorias();

            //List<SelectListItem> lstCategoria = new List<SelectListItem>();
            //foreach (var item in categoria)
            //{
            //    lstCategoria.Add(new SelectListItem { Value = item.idCategoria.ToString(), Text = item.Descripcion });
            //}

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

        [FiltroAdmin]
        [HttpGet]
        public ActionResult EditarProducto(int id)
        {
            var respuesta = prodM.ConsultarProducto(id);
            var categoria = catM.ConsultarCategorias();

            List<SelectListItem> lstCategoria = new List<SelectListItem>();
            foreach (var item in categoria)
            {
                lstCategoria.Add(new SelectListItem { Value = item.idCategoria.ToString(), Text = item.Nombre });
            }

            ViewBag.Roles = lstCategoria;
            return View(respuesta);
        }

        [FiltroAdmin]
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

        [FiltroAdmin]
        [HttpPost]
        public ActionResult EliminarProducto(Producto prod)
        {
            var respuesta = prodM.EliminarProducto(prod);

            if (respuesta)
                return RedirectToAction("VerProductos", "Producto");
            else
            {
                ViewBag.msj = "No se ha eliminado el producto";
                return View();
            }

        }

        [Filtro]
        [HttpPost]
        public ActionResult RegistrarCarrito(int idProducto, int Cantidad)
        {
            carritoM.RegistrarCarrito(idProducto, Cantidad);
            CargarVariablesCarrito();
            return Json("", JsonRequestBehavior.AllowGet);
        }

        private void CargarVariablesCarrito()
        {
            var carritoActual = carritoM.ConsultarCarrito();
            Session["Cantidad"] = carritoActual.Sum(c => c.Cantidades);
            Session["SubTotal"] = carritoActual.Sum(c => c.SubTotal);
            Session["Total"] = carritoActual.Sum(c => c.Total);
        }
    }
}