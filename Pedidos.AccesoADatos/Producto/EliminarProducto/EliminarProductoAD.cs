using Pedidos.Abstracciones.AccesoADatos.Producto.EliminarProducto;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Producto.EliminarProducto
{
	public class EliminarProductoAD: IEliminarProductoAD
	{
		private ContextoProducto _contexto;
		public EliminarProductoAD()
		{
			_contexto = new ContextoProducto();
		}

		public int Eliminar(int id)
		{
			ProductoAD elProductoEnBaseDeDatos = _contexto.Productos.Where(Producto => Producto.Id == id).FirstOrDefault();
			_contexto.Productos.Remove(elProductoEnBaseDeDatos);
			EntityState estado = _contexto.Entry(elProductoEnBaseDeDatos).State = System.Data.Entity.EntityState.Deleted;
			int cantidadDeDatosAgregados = _contexto.SaveChanges();
			return cantidadDeDatosAgregados;
		}
	}
}
