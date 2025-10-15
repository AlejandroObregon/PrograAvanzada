using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos
{
	public class ContextoCliente : DbContext
	{
		public ContextoCliente() : base("name=Contexto")
		{

		}

		public DbSet<ClienteAD> Clientes { get; set; }
	}
}
