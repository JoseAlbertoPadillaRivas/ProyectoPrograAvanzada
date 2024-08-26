using proyectoGrupo_1.BaseDatos;
using proyectoGrupo_1.Entidades;
using proyectoGrupo_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace proyectoGrupo_1.Controllers
{

    [Filtro]
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class SeguimientoController : Controller
    {
        SeguimientoModel seg = new SeguimientoModel();

        [FiltroAdmin]
        [HttpGet]
        public ActionResult ConsultarSeguimientos()
        {
            var respuesta = seg.VerSeguimientos();
            return View(respuesta);
        }

        [FiltroAdmin]
        [HttpGet]
        public ActionResult RegistrarSeguimiento()
        {
            return View();
        }

        [FiltroAdmin]
        [HttpPost]
        public ActionResult RegistrarSeguimiento(Seguimiento seguimiento)
        {

            var respuesta = seg.RegistrarSeguimiento(seguimiento);

            if (respuesta)

                return RedirectToAction("ConsultarSeguimientos", "Seguimiento");
            else
            {
                ViewBag.msj = "La informacion del seguimiento ya esta en la base de datos";
                return View();
            }

        }

        [FiltroAdmin]
        [HttpPost]
        public ActionResult CambiarEstadoSeguimiento(Seguimiento seguimiento)
        {
            {
                var respuesta = seg.CambiarEstadoSeguimiento(seguimiento);

                if (respuesta)
                    return RedirectToAction("ConsultarSeguimientos", "Seguimiento");
                else
                {
                    ViewBag.msj = "No se ha podido cambiar el estado del seguimiento";
                    return View();
                }
            }
        }

        [FiltroAdmin]
        [HttpGet]
        public ActionResult ActualizarSeguimiento(int idSeguimiento)
        {
            var respuesta = seg.ConsultarUnSeguimiento(idSeguimiento);
            return View(respuesta);
        }

        [FiltroAdmin]
        [HttpPost]
        public ActionResult ActualizarSeguimiento(Seguimiento seguimiento)
        {
            var respuesta = seg.ActualizarSeguimiento(seguimiento);

            if (respuesta)
                return RedirectToAction("ConsultarSeguimientos", "Seguimiento");
            else
            {
                ViewBag.msj = "No se ha podido actualizar la información";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ConsultarMiSeguimiento()
        {
            var datos = seg.ConsultarMiSeguimiento();
            Seguimiento seguimiento = new Seguimiento();
            seguimiento.DatosSeguimiento = datos;

            return View(seguimiento);
        }

        [FiltroAdmin]
        [HttpPost]
        public ActionResult EliminarSeguimiento(Seguimiento seguimiento)
        {
            var respuesta = seg.EliminarSeguimiento(seguimiento);

            if (respuesta)
                return RedirectToAction("ConsultarSeguimientos", "Seguimiento");
            else
            {
                ViewBag.msj = "No se ha eliminado el seguimiento";
                return View();
            }

        }
    }
}