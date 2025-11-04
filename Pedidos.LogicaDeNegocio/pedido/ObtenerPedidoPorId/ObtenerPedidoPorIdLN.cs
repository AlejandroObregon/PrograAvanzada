using Pedidos.Abstracciones.AccesoADatos.Pedido.ListarPedidos;
using Pedidos.Abstracciones.AccesoADatos.Pedido.ObtenerPedidoPorId;
using Pedidos.Abstracciones.LogicaDeNegocio.Pedido.ObtenerPedidoPorId;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Pedido.ListarPedido;
using Pedidos.AccesoADatos.Pedido.ObtenerPedidoPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Pedido.ObtenerPedidoPorId
{
	public class ObtenerPedidoPorIdLN: IObtenerPedidoPorIdLN
	{
		private IObtenerPedidoPorIdAD _obtenerPedidoPorId;
		public ObtenerPedidoPorIdLN()
		{
			_obtenerPedidoPorId = new ObtenerPedidoPorIdAD();
		}

		public PedidoDto Obtener(int id)
		{
			PedidoDto elPedido = _obtenerPedidoPorId.Obtener(id);
			return elPedido;
		}
	}
}
