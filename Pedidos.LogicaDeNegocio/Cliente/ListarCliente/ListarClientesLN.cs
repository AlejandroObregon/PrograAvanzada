using Pedidos.Abstracciones.AccesoADatos.Cliente.ListarClientes;
using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.ListarClientes;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Cliente.ListarCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Cliente.ListarCliente
{
	public class ListarClientesLN: IListarClientesLN
	{
		private IListarClientesAD _listarClienteAD;
		public ListarClientesLN() {
			_listarClienteAD = new ListarClienteAD();
		}

		public List<ClienteDto> Obtener()
		{
			/*List<ClienteDto> laListaDeCliente = new List<ClienteDto>();
			laListaDeCliente.Add(ObtenerObjeto());*/
			List<ClienteDto> laListaDeCliente = _listarClienteAD.Obtener();

			return laListaDeCliente;
		}

		public ClienteDto ObtenerObjeto()
		{
			return new ClienteDto { 
			Id = 1,
			Nombre = "Cliente1",
            Cedula = "1-2345-6789",
            Correo = "Usuario@gmail.com",
            Telefono = "4321-9876",
            Direccion = "Monte Verde"
			};


    }
	}
}
