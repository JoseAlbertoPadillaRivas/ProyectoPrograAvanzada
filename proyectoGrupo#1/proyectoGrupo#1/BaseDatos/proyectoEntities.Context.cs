﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyectoGrupo_1.BaseDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class proyectoEntities : DbContext
    {
        public proyectoEntities()
            : base("name=proyectoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tCarrito> tCarrito { get; set; }
        public virtual DbSet<tCategoria> tCategoria { get; set; }
        public virtual DbSet<tProducto> tProducto { get; set; }
        public virtual DbSet<tRol> tRol { get; set; }
        public virtual DbSet<tUsuario> tUsuario { get; set; }
        public virtual DbSet<tMaestro> tMaestro { get; set; }
        public virtual DbSet<tDetalle> tDetalle { get; set; }
    
        public virtual int ActualizarUsuario(string cedula, string nombre, string correo, Nullable<int> idRol, Nullable<int> id)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("idRol", idRol) :
                new ObjectParameter("idRol", typeof(int));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarUsuario", cedulaParameter, nombreParameter, correoParameter, idRolParameter, idParameter);
        }
    
        public virtual int CambiarEstadoUsuario(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CambiarEstadoUsuario", idParameter);
        }
    
        public virtual ObjectResult<ConsultarCarrrito_Result> ConsultarCarrrito(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarCarrrito_Result>("ConsultarCarrrito", idParameter);
        }
    
        public virtual int EditarCategoria(Nullable<int> idCategoria, string nombre)
        {
            var idCategoriaParameter = idCategoria.HasValue ?
                new ObjectParameter("idCategoria", idCategoria) :
                new ObjectParameter("idCategoria", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditarCategoria", idCategoriaParameter, nombreParameter);
        }
    
        public virtual int EditarProducto(Nullable<int> idProducto, string descripcion, Nullable<int> precio, Nullable<int> cantidad, Nullable<int> categoria, string imagen)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(int));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            var categoriaParameter = categoria.HasValue ?
                new ObjectParameter("Categoria", categoria) :
                new ObjectParameter("Categoria", typeof(int));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditarProducto", idProductoParameter, descripcionParameter, precioParameter, cantidadParameter, categoriaParameter, imagenParameter);
        }
    
        public virtual int EliminarCategoria(Nullable<int> idCategoria)
        {
            var idCategoriaParameter = idCategoria.HasValue ?
                new ObjectParameter("idCategoria", idCategoria) :
                new ObjectParameter("idCategoria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarCategoria", idCategoriaParameter);
        }
    
        public virtual int EliminarProducto(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarProducto", idProductoParameter);
        }
    
        public virtual ObjectResult<IniciarSesion_Result> IniciarSesion(string correo, string contrasenna)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var contrasennaParameter = contrasenna != null ?
                new ObjectParameter("Contrasenna", contrasenna) :
                new ObjectParameter("Contrasenna", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<IniciarSesion_Result>("IniciarSesion", correoParameter, contrasennaParameter);
        }
    
        public virtual int NuevaCategoria(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("NuevaCategoria", nombreParameter);
        }
    
        public virtual ObjectResult<string> PagarCarrito(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("PagarCarrito", idParameter);
        }
    
        public virtual int RegistrarCarrito(Nullable<int> id, Nullable<int> idProducto, Nullable<int> cantidades)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(int));
    
            var cantidadesParameter = cantidades.HasValue ?
                new ObjectParameter("Cantidades", cantidades) :
                new ObjectParameter("Cantidades", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegistrarCarrito", idParameter, idProductoParameter, cantidadesParameter);
        }
    
        public virtual int RegistrarProducto(string descripcion, Nullable<int> precio, Nullable<int> cantidad, Nullable<int> categoria, string imagen)
        {
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            var categoriaParameter = categoria.HasValue ?
                new ObjectParameter("Categoria", categoria) :
                new ObjectParameter("Categoria", typeof(int));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegistrarProducto", descripcionParameter, precioParameter, cantidadParameter, categoriaParameter, imagenParameter);
        }
    
        public virtual int RegistrarUsuario(string cedula, string nombre, string correo, string contrasenna)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var contrasennaParameter = contrasenna != null ?
                new ObjectParameter("Contrasenna", contrasenna) :
                new ObjectParameter("Contrasenna", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegistrarUsuario", cedulaParameter, nombreParameter, correoParameter, contrasennaParameter);
        }
    
        public virtual ObjectResult<ValidarUsuarioIdentificacion_Result> ValidarUsuarioIdentificacion(string cedula)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ValidarUsuarioIdentificacion_Result>("ValidarUsuarioIdentificacion", cedulaParameter);
        }
    
        public virtual int EliminarProductoCarrito(Nullable<int> id, Nullable<int> idProducto)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarProductoCarrito", idParameter, idProductoParameter);
        }
    }
}
