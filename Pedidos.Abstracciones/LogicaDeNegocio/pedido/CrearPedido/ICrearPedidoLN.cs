using Pedidos.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.LogicaDeNegocio.Pedido.CrearPedido
{
	public interface ICrearPedidoLN
	{
		Task<int> Guardar(PedidoDto elPedido);
	}
}
