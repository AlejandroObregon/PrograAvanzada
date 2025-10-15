using Pedidos.Abstracciones.AccesoADatos.Cliente.ActualizarCliente;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Cliente.ActualizarCliente
{
	public class ActualizarClienteAD: IActualizarClienteAD
	{
		private ContextoCliente _contexto;
		public ActualizarClienteAD()
		{
			_contexto = new ContextoCliente();
		}

		public int Actualizar(ClienteDto elCliente)
		{
			ClienteAD elClienteEnBaseDeDatos = _contexto.Clientes.Where(Cliente => Cliente.Id == elCliente.Id).FirstOrDefault();
            // Actualiza campos editables
            elClienteEnBaseDeDatos.Id = elCliente.Id;
            elClienteEnBaseDeDatos.Nombre = elCliente.Nombre;
            elClienteEnBaseDeDatos.Cedula = elCliente.Cedula;
            elClienteEnBaseDeDatos.Correo = elCliente.Correo;
            elClienteEnBaseDeDatos.Telefono = elCliente.Telefono;
            elClienteEnBaseDeDatos.Direccion = elCliente.Direccion;
			EntityState estado = _contexto.Entry(elClienteEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
			int cantidadDeDatosAgregados = _contexto.SaveChanges();
			return cantidadDeDatosAgregados;
		}
	}
}