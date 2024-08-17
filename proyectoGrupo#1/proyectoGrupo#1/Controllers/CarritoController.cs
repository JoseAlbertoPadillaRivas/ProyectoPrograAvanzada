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
    public class CarritoController : Controller
    {

        CarritoModel carritoM = new CarritoModel();

        [HttpGet]
        public ActionResult ConsultarCarrito()
        {
            var datos = carritoM.ConsultarCarrito();

            Carrito carrito = new Carrito();
            carrito.DatosCarrito = datos;

            Session["Cantidad"] = datos.Sum(c => c.Cantidades);
            Session["SubTotal"] = datos.Sum(c => c.SubTotal);
            Session["Total"] = datos.Sum(c => c.Total);

            return View(carrito);
        }

        [HttpPost]
        public ActionResult PagarCarrito()
        {
            carritoM.PagarCarrito();
            return RedirectToAction("ConsultarCarrito", "Carrito");
        }

        [HttpPost]
        public ActionResult EliminarProductoCarrito(Carrito ent)
        {
            carritoM.EliminarProductoCarrito(ent.idProducto);
            return RedirectToAction("ConsultarCarrito", "Carrito");
        }
    }
}