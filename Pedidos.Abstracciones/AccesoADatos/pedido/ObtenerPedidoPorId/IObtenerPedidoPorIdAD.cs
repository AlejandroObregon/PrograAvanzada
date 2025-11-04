using Pedidos.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.AccesoADatos.Pedido.ObtenerPedidoPorId
{
	public interface IObtenerPedidoPorIdAD
	{
        PedidoDto Obtener(int id);
	}
}
