using Pedidos.Abstracciones.AccesoADatos.Pedido.ObtenerPedidoPorId;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Pedido.ObtenerPedidoPorId
{
	public class ObtenerPedidoPorIdAD: IObtenerPedidoPorIdAD
	{
		private ContextoPedido _elContexto;
		public ObtenerPedidoPorIdAD()
		{
			_elContexto = new ContextoPedido();
		}
		public PedidoDto Obtener(int id)
		{
			PedidoDto laListaARetornar = (from Pedido in _elContexto.Pedido
											  where Pedido.Id == id
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

                                                    }).FirstOrDefault();
			return laListaARetornar;
		}
	}
}




