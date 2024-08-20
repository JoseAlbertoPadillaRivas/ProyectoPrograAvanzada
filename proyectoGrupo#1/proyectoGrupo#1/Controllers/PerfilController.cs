﻿using proyectoGrupo_1.Entidades;
using proyectoGrupo_1.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KN_Web.Controllers
{
    [Filtro]
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class PerfilController : Controller
    {
        UsuarioModel usuarioM = new UsuarioModel();

        [HttpGet]
        public ActionResult Perfil()
        {
            var respuesta = usuarioM.ConsultarUsuario(int.Parse(Session["idUsuario"].ToString()));
            return View(respuesta);
        }

        [HttpPost]
        public ActionResult ActualizarPerfil(Usuario user)
        {
            var respuesta = usuarioM.ActualizarUsuario(user);

            if (respuesta)
                return RedirectToAction("Perfil", "Perfil");
            else
            {
                ViewBag.msj = "No se ha podido actualizar su información de perfil";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarContrasenna()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ActualizarContrasenna(Usuario user)
        {
            if (user.Contrasenna != user.ConfirmarContrasenna)
            {
                ViewBag.msj = "Las contraseñas ingresadas no coinciden";
                return View();
            }

            int id = int.Parse(Session["idUsuario"].ToString());
            var respuesta = usuarioM.CambiarContrasennaUsuario(id, user.Contrasenna, false, DateTime.Now);

            if (respuesta)
                return RedirectToAction("CerrarSesion", "Login");
            else
            {
                ViewBag.msj = "No se ha podido actualizar su contraseña";
                return View();
            }
        }
    }
}
