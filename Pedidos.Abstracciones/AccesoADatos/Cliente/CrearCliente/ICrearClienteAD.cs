using Pedidos.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.AccesoADatos.Cliente.CrearCliente
{
	public interface ICrearClienteAD
	{
		Task<int> Guardar(ClienteDto elCliente);
	}
}
