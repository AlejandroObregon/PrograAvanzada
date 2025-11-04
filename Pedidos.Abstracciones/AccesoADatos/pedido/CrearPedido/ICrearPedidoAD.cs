using Pedidos.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.AccesoADatos.Pedido.CrearPedido
{
	public interface ICrearPedidoAD
	{
		Task<int> Guardar(PedidoDto elPedido);
	}
}
