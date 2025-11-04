using Pedidos.Abstracciones.AccesoADatos.Pedido.CrearPedido;
using Pedidos.Abstracciones.LogicaDeNegocio.General;
using Pedidos.Abstracciones.LogicaDeNegocio.Pedido.CrearPedido;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Pedido.CrearPedido;
using Pedidos.LogicaDeNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Pedido.CrearPedido
{
	public class CrearPedidoLN: ICrearPedidoLN
	{
		private ICrearPedidoAD _crearPedidoAD;
		private IFecha _fecha;

		public CrearPedidoLN()
		{
			_crearPedidoAD = new CrearPedidoAD();
			_fecha = new Fecha();
		}

		public async Task<int> Guardar(PedidoDto elPedido)
		{
			int cantidadDeResultados = await _crearPedidoAD.Guardar(elPedido);
			return cantidadDeResultados;
		}
		

	}
}
