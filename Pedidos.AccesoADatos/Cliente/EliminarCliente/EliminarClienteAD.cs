using Pedidos.Abstracciones.AccesoADatos.Cliente.EliminarCliente;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Cliente.EliminarCliente
{
	public class EliminarClienteAD: IEliminarClienteAD
	{
		private ContextoCliente _contexto;
		public EliminarClienteAD()
		{
			_contexto = new ContextoCliente();
		}

		public int Eliminar(int id)
		{
			ClienteAD elClienteEnBaseDeDatos = _contexto.Clientes.Where(Cliente => Cliente.Id == id).FirstOrDefault();
			_contexto.Clientes.Remove(elClienteEnBaseDeDatos);
			EntityState estado = _contexto.Entry(elClienteEnBaseDeDatos).State = System.Data.Entity.EntityState.Deleted;
			int cantidadDeDatosAgregados = _contexto.SaveChanges();
			return cantidadDeDatosAgregados;
		}
	}
}
