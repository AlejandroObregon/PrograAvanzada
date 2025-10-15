using Pedidos.Abstracciones.AccesoADatos.Cliente.ObtenerClientePorId;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Cliente.ObtenerClientePorId
{
	public class ObtenerClientePorIdAD: IObtenerClientePorIdAD
	{
		private ContextoCliente _elContexto;
		public ObtenerClientePorIdAD()
		{
			_elContexto = new ContextoCliente();
		}
		public ClienteDto Obtener(int id)
		{
			ClienteDto laListaARetornar = (from Cliente in _elContexto.Clientes
											  where Cliente.Id == id
													select new ClienteDto
													{
                                                        Id = Cliente.Id,
                                                        Nombre = Cliente.Nombre,
                                                        Cedula = Cliente.Cedula,
                                                        Correo = Cliente.Correo,
                                                        Telefono = Cliente.Telefono,
                                                        Direccion = Cliente.Direccion
                                                    }).FirstOrDefault();
			return laListaARetornar;
		}
	}
}




