using Pedidos.Abstracciones.AccesoADatos.Producto.ActualizarProducto;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Producto.ActualizarProducto
{
	public class ActualizarProductoAD: IActualizarProductoAD
	{
		private ContextoProducto _contexto;
		public ActualizarProductoAD()
		{
			_contexto = new ContextoProducto();
		}

		public int Actualizar(ProductoDto elProducto)
		{
			ProductoAD elProductoEnBaseDeDatos = _contexto.Productos.Where(producto => producto.Id == elProducto.Id).FirstOrDefault();
            // Actualiza campos editables
            elProductoEnBaseDeDatos.Id = elProducto.Id;
            elProductoEnBaseDeDatos.Nombre = elProducto.Nombre;
            elProductoEnBaseDeDatos.CategoriaId = elProducto.CategoriaId;
            elProductoEnBaseDeDatos.Precio = elProducto.Precio;
            elProductoEnBaseDeDatos.ImpuestoPorc = elProducto.ImpuestoPorc;
            elProductoEnBaseDeDatos.Stock = elProducto.Stock;
            elProductoEnBaseDeDatos.ImagenUrl = elProducto.ImagenUrl;
            elProductoEnBaseDeDatos.Activo = elProducto.Activo;
			EntityState estado = _contexto.Entry(elProductoEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
			int cantidadDeDatosAgregados = _contexto.SaveChanges();
			return cantidadDeDatosAgregados;
		}
	}
}