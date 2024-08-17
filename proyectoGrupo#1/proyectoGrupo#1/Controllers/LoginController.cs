using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyectoGrupo_1.Entidades;
using proyectoGrupo_1.Models;

namespace proyectoGrupo_1.Controllers
{
    public class LoginController : Controller
    {
        UsuarioModel usuarioM = new UsuarioModel();


        [HttpGet]
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Usuario user)
        {
            var respuesta = usuarioM.IniciarSesion(user);

            if (respuesta != null)
            {

                Session["NombreUsuario"] = respuesta.Nombre;
                Session["idUsuario"] = respuesta.id;
                Session["RolUsuario"] = respuesta.IdRol.ToString();
                return RedirectToAction("Home", "Login");
            }
            else
            {
                ViewBag.msj = "Su información no es correcta";
                return View();
            }
        }



        [Filtro]
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("IniciarSesion", "Login");
        }



        [HttpGet]
        public ActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(Usuario user)
        {
            var respuesta = usuarioM.RegistrarUsuario(user);

            if (respuesta)
                return RedirectToAction("IniciarSesion", "Login");
            else
            {
                ViewBag.msj = "Su información ya existe en nuestro sistema";
                return View();
            }
        }



        [Filtro]
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

    }
}