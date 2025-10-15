using Pedidos.Abstracciones.AccesoADatos.Producto.CrearProducto;
using Pedidos.Abstracciones.LogicaDeNegocio.General;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.CrearProducto;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Producto.CrearProducto;
using Pedidos.LogicaDeNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Producto.CrearProducto
{
	public class CrearProductoLN: ICrearProductoLN
	{
		private ICrearProductoAD _crearProductoAD;
		private IFecha _fecha;

		public CrearProductoLN()
		{
			_crearProductoAD = new CrearProductoAD();
			_fecha = new Fecha();
		}

		public async Task<int> Guardar(ProductoDto elProducto)
		{
			elProducto.Activo = EstadosDeProducto.activo;
			int cantidadDeResultados = await _crearProductoAD.Guardar(elProducto);
			return cantidadDeResultados;
		}
		

	}
}
