﻿using proyectoGrupo_1.BaseDatos;
using proyectoGrupo_1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoGrupo_1.Models
{
    public class SeguimientoModel
    {
        public bool RegistrarSeguimiento(Seguimiento seguimiento)
        {
            try { 
            var rowsAffected = 0;

            using (var context = new proyectoEntities1())
            {
                rowsAffected = context.RegistrarSeguimiento(seguimiento.idUsuario, seguimiento.nombreProducto, seguimiento.fechaIngreso, seguimiento.fechaSalida);
            }

            return (rowsAffected > 0 ? true : false);
            }
            catch { return false; }
        }
        public tSeguimiento ConsultarUnSeguimiento(int idSeguimiento)
        {
            using (var context = new proyectoEntities1())
            {
                return (from x in context.tSeguimiento
                        where x.idSeguimiento == idSeguimiento
                        select x).FirstOrDefault();
            }
        }

        public List<ConsultarMiSeguimiento_Result> ConsultarMiSeguimiento()
        {
            using (var context = new proyectoEntities1())
            {
                int id = int.Parse(HttpContext.Current.Session["idUsuario"].ToString());
                return context.ConsultarMiSeguimiento(id).ToList();
            }
        }

        public bool CambiarEstadoSeguimiento(Seguimiento seguimiento)
        {
            try
            {
                var rowsAffected = 0;

            using (var context = new proyectoEntities1())
            {
                rowsAffected = context.CambiarEstadoSeguimiento(seguimiento.idSeguimiento);
            }

            return (rowsAffected > 0 ? true : false);
            }
            catch { return false; }
        }

        public bool ActualizarSeguimiento(Seguimiento seguimiento) {
            try
            {
                var rowsAffected = 0;

            using (var context = new proyectoEntities1())
            {
                rowsAffected = context.ActualizarSeguimiento(seguimiento.nombreProducto, seguimiento.fechaIngreso, seguimiento.fechaSalida, seguimiento.idSeguimiento);
            }

            return (rowsAffected > 0 ? true : false);
            }
            catch { return false; }
        }

        public List<tSeguimiento> VerSeguimientos()
        {
            using (var context = new proyectoEntities1())
            {

                return (from x in context.tSeguimiento
                        select x).ToList();
            }
        }
        public bool EliminarSeguimiento(Seguimiento seguimiento)
        {
            try
            {
                var rowsAffected = 0;

            using (var context = new proyectoEntities1())
            {
                rowsAffected = context.EliminarSeguimiento(seguimiento.idSeguimiento);
            }

            return (rowsAffected > 0 ? true : false);
            }
            catch { return false; }
        }
    }
}