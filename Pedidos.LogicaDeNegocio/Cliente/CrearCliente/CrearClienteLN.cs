using Pedidos.Abstracciones.AccesoADatos.Cliente.CrearCliente;
using Pedidos.Abstracciones.LogicaDeNegocio.General;
using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.CrearCliente;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Cliente.CrearCliente;
using Pedidos.LogicaDeNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Cliente.CrearCliente
{
	public class CrearClienteLN: ICrearClienteLN
	{
		private ICrearClienteAD _crearClienteAD;
		private IFecha _fecha;

		public CrearClienteLN()
		{
			_crearClienteAD = new CrearClienteAD();
			_fecha = new Fecha();
		}

		public async Task<int> Guardar(ClienteDto elCliente)
		{
			int cantidadDeResultados = await _crearClienteAD.Guardar(elCliente);
			return cantidadDeResultados;
		}
		

	}
}
