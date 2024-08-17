using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyectoGrupo_1.BaseDatos;
using proyectoGrupo_1.Entidades;
using proyectoGrupo_1.Models;

namespace proyectoGrupo_1.Controllers
{
    public class LoginController : Controller
    {
        UsuarioModel usuarioM = new UsuarioModel();
        GeneralModel generalM = new GeneralModel();


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

        //Recupera la contraseña del usuario
        [HttpGet]
        public ActionResult RecuperarAcceso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarAcceso(Usuario user)
        {
            var respuesta = usuarioM.ConsultarUsuarioCedula(user.Cedula);

            if (respuesta != null)
            {
                var contrasennaTemporal = generalM.CreatePassword();
                var fechaVencimientoTemporal = DateTime.Now.AddMinutes(20);
                var actualizacion = usuarioM.CambiarContrasennaUsuario(respuesta.id, contrasennaTemporal, true, fechaVencimientoTemporal);

                if (actualizacion)
                {
                    string ruta = AppDomain.CurrentDomain.BaseDirectory + "Password.html";
                    string contenido = System.IO.File.ReadAllText(ruta);
                    contenido = contenido.Replace("@@Nombre", respuesta.Nombre);
                    contenido = contenido.Replace("@@Contrasenna", contrasennaTemporal);
                    contenido = contenido.Replace("@@Vencimiento", fechaVencimientoTemporal.ToString("dd/MM/yyyy hh:mm:ss tt"));
                    generalM.EnviarCorreo(respuesta.Correo, "Recuperar Acceso Sistema", contenido);
                }

                return RedirectToAction("IniciarSesion", "Login");
            }
            else
            {
                ViewBag.msj = "No fue posible obtener su información";
                return View();
            }
        }
    }
}