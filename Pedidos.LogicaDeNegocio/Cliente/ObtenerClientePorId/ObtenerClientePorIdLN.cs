using Pedidos.Abstracciones.AccesoADatos.Cliente.ListarClientes;
using Pedidos.Abstracciones.AccesoADatos.Cliente.ObtenerClientePorId;
using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.ObtenerClientePorId;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Cliente.ListarCliente;
using Pedidos.AccesoADatos.Cliente.ObtenerClientePorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Cliente.ObtenerClientePorId
{
	public class ObtenerClientePorIdLN: IObtenerClientePorIdLN
	{
		private IObtenerClientePorIdAD _obtenerClientePorId;
		public ObtenerClientePorIdLN()
		{
			_obtenerClientePorId = new ObtenerClientePorIdAD();
		}

		public ClienteDto Obtener(int id)
		{
			ClienteDto elCliente = _obtenerClientePorId.Obtener(id);
			return elCliente;
		}
	}
}
