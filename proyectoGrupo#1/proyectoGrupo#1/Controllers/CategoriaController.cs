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
    [FiltroAdmin]
    public class CategoriaController : Controller
    {
        CategoriaModel catM = new CategoriaModel();

        [HttpGet]
        public ActionResult RegistrarCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCategoria(Categoria cat)
        {

            var respuesta = catM.RegistrarCategoria(cat);

            if (respuesta)
                return RedirectToAction("ConsultarCategorias", "Categoria");
            else
            {
                ViewBag.msj = "La informacion de la categoria ya esta en la base de datos";
                return View();
            }

        }

        [HttpGet]
        public ActionResult ConsultarCategorias()
        {
            var respuesta = catM.ConsultarCategorias();
            return View(respuesta);
        }

       
        [HttpPost]
        public ActionResult EliminarCategoria(Categoria cat)
        {
            var respuesta = catM.EliminarCategoria(cat);

            if (respuesta)
                return RedirectToAction("ConsultarCategorias", "Categoria");
            else
            {
                ViewBag.msj = "No se ha eliminado la categoria";
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditarCategoria(int idCategoria)
        {
            var respuesta = catM.ConsultarCategoria(idCategoria);
            return View(respuesta);
        }

        [HttpPost]
        public ActionResult EditarCategoria(Categoria cat)
        {
            var respuesta = catM.EditarCategoria(cat);

            if (respuesta)
                return RedirectToAction("ConsultarCategorias", "Categoria");
            else
            {
                ViewBag.msj = "No se ha podido actualizar la información de la categoria";
                return View();
            }
        }
    }
}