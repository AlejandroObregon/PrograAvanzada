using Pedidos.Abstracciones.AccesoADatos.Cliente.ListarClientes;
using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.ListarClientes;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Cliente.ListarCliente
{
	public class ListarClienteAD: IListarClientesAD
	{

		private ContextoCliente _elContexto;
		public ListarClienteAD()
		{
			_elContexto = new ContextoCliente();
		}

		public List<ClienteDto> Obtener()
		{

			List<ClienteAD> laListaEnBaseDeDatos = _elContexto.Clientes.ToList();
			List<ClienteDto> laListaARetornar = (from Cliente in _elContexto.Clientes
													select new ClienteDto
													{
                                                        Id = Cliente.Id,
                                                        Nombre = Cliente.Nombre,
                                                        Cedula = Cliente.Cedula,
                                                        Correo = Cliente.Correo,
                                                        Telefono = Cliente.Telefono,
                                                        Direccion = Cliente.Direccion
                                                    }).ToList();
			return laListaARetornar;
		}
	}
}
