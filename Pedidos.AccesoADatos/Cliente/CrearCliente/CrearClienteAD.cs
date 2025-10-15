using Pedidos.Abstracciones.AccesoADatos.Cliente.CrearCliente;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Cliente.CrearCliente
{
	public class CrearClienteAD : ICrearClienteAD
	{
		private ContextoCliente _contexto;

		public CrearClienteAD()
		{
			_contexto = new ContextoCliente();
		}

		public async Task<int> Guardar(ClienteDto elCliente)
		{
			ClienteAD elClienteAGuardar = ConvertirObjetoParaAD(elCliente);
			
			_contexto.Clientes.Add(elClienteAGuardar);
			
			EntityState estado = _contexto.Entry(elClienteAGuardar).State = System.Data.Entity.EntityState.Added;
			int cantidadDeDatosAgregados = await _contexto.SaveChangesAsync();
			return cantidadDeDatosAgregados;
		}
		
		
private ClienteAD ConvertirObjetoParaAD(ClienteDto Cliente)
		{
			return new ClienteAD {
				Id = Cliente.Id,
                Nombre = Cliente.Nombre,
                Cedula = Cliente.Cedula,
                Correo = Cliente.Correo,
                Telefono = Cliente.Telefono,
                Direccion = Cliente.Direccion
			};
		}
	}
}
