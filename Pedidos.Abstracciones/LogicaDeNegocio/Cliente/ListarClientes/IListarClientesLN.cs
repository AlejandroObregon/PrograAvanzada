using Pedidos.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.LogicaDeNegocio.Cliente.ListarClientes
{
	public interface IListarClientesLN
	{
		List<ClienteDto> Obtener();
	}
}
