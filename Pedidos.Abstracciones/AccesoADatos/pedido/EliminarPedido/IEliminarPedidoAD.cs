using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.AccesoADatos.Pedido.EliminarPedido
{
	public interface IEliminarPedidoAD
	{
		int Eliminar(int id);
	}
}
