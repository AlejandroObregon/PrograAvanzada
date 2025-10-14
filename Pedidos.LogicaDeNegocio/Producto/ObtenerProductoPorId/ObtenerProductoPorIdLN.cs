using Pedidos.Abstracciones.AccesoADatos.Producto.ListarProductos;
using Pedidos.Abstracciones.AccesoADatos.Producto.ObtenerProductoPorId;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.ObtenerProductoPorId;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Producto.ListarProducto;
using Pedidos.AccesoADatos.Producto.ObtenerProductoPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Producto.ObtenerProductoPorId
{
	public class ObtenerProductoPorIdLN: IObtenerProductoPorIdLN
	{
		private IObtenerProductoPorIdAD _obtenerProductoPorId;
		public ObtenerProductoPorIdLN()
		{
			_obtenerProductoPorId = new ObtenerProductoPorIdAD();
		}

		public ProductoDto Obtener(int id)
		{
			ProductoDto elProducto = _obtenerProductoPorId.Obtener(id);
			return elProducto;
		}
	}
}
