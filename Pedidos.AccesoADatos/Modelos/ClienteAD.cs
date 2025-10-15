using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pedidos.AccesoADatos.Modelos
{
	[Table("Cliente")]
	public class ClienteAD
	{
		[Column("Id")]
		public int Id { get; set; }
		[Column("Nombre")]
		public string Nombre { get; set; }
		[Column("Cedula")]
		public string Cedula { get; set; }
		[Column("Correo")]
		public string Correo { get; set; }
		[Column("Telefono")]
		public string Telefono { get; set; }
		[Column("Direccion")]
		public string Direccion { get; set; }
	}
}