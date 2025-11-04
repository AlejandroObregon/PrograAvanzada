using Pedidos.Abstracciones.AccesoADatos.Pedido.ListarPedidos;
using Pedidos.Abstracciones.LogicaDeNegocio.Pedido.ListarPedidos;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Pedido.ListarPedido
{
	public class ListarPedidoAD: IListarPedidoAD
	{

		private ContextoPedido _elContexto;
		public ListarPedidoAD()
		{
			_elContexto = new ContextoPedido();
		}

		public List<PedidoDto> Obtener()
		{

			List<PedidoAD> laListaEnBaseDeDatos = _elContexto.Pedido.ToList();
			List<PedidoDto> laListaARetornar = (from Pedido in _elContexto.Pedido
													select new PedidoDto
                                                    {
                                                        Id = Pedido.Id,
                                                        ClienteId = Pedido.ClienteId,
                                                        UsuarioId = Pedido.UsuarioId,
                                                        Fecha = Pedido.Fecha,
                                                        Subtotal = Pedido.Subtotal,
                                                        Impuestos = Pedido.Impuestos,
                                                        Total = Pedido.Total,
                                                        Estado = Pedido.Estado,

                                                    }).ToList();
			return laListaARetornar;
		}
	}
}
