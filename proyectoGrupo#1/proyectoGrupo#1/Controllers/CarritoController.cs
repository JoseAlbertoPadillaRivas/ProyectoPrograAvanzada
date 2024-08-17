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
            var datos = carritoM.ValidarCantidadesProdcutos();

            //Es porque no hay existencias inclumpliendose
            if (datos.Count() <= 0)
            {
                carritoM.PagarCarrito();
                return RedirectToAction("ConsultarCarrito", "Carrito");
            }
            else
            {
                var productosEnCarrito = carritoM.ConsultarCarrito();

                //Se setea el objeto general que tiene el id del producto necesario del modal y la lista actual del carrito
                Carrito carrito = new Carrito();
                carrito.DatosCarrito = productosEnCarrito;

                var mensaje = "";
                var contador = 0;
                foreach (var item in datos)
                {
                    if (contador != datos.Count() - 2)
                        mensaje += item.Descripcion + ", ";
                    else
                        mensaje += item.Descripcion + " y ";

                    contador += 1;
                }

                ViewBag.msj = "No se puede realizar el pago, los productos " + mensaje + "superan la cantidad en el inventario disponible";
                return View("ConsultarCarrito", carrito);
            }
        }

        [HttpPost]
        public ActionResult EliminarProductoCarrito(Carrito ent)
        {
            carritoM.EliminarProductoCarrito(ent.idProducto);
            return RedirectToAction("ConsultarCarrito", "Carrito");
        }
    }
}