using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos
{
	public class Contexto : DbContext
	{
		public Contexto() : base("name=Contexto")
		{

		}

		public DbSet<ProductoAD> Productos { get; set; }
	}
}
