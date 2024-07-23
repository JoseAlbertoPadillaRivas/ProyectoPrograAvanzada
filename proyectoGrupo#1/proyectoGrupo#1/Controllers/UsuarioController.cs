using proyectoGrupo_1.Entidades;
using proyectoGrupo_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoGrupo_1.Controllers
{
    [FiltroAdmin]
    [Filtro]
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class UsuarioController : Controller
    {

            UsuarioModel usuarioM = new UsuarioModel();
            RolModel rolM = new RolModel();

            [HttpGet]
            public ActionResult ConsultarUsuarios()
            {
                var respuesta = usuarioM.ConsultarUsuarios();
                return View(respuesta);
            }

            [HttpPost]
            public ActionResult CambiarEstadoUsuario(Usuario user)
            {
                var respuesta = usuarioM.CambiarEstadoUsuario(user);

                if (respuesta)
                    return RedirectToAction("ConsultarUsuarios", "Usuario");
                else
                {
                    ViewBag.msj = "No se ha podido inactivar la información del usuario";
                    return View();
                }
            }

            [HttpGet]
            public ActionResult ActualizarUsuario(int id)
            {
                var respuesta = usuarioM.ConsultarUsuario(id);
                var roles = rolM.ConsultarRoles();

                List<SelectListItem> lstRoles = new List<SelectListItem>();
                foreach (var item in roles)
                {
                    lstRoles.Add(new SelectListItem { Value = item.idRol.ToString(), Text = item.Nombre });
                }

                ViewBag.Roles = lstRoles;
                return View(respuesta);
            }

            [HttpPost]
            public ActionResult ActualizarUsuario(Usuario user)
            {
                var respuesta = usuarioM.ActualizarUsuario(user);

                if (respuesta)
                    return RedirectToAction("ConsultarUsuarios", "Usuario");
                else
                {
                    ViewBag.msj = "No se ha podido actualizar la información del usuario";
                    return View();
                }
            }

        }
    }
