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
	[Table("Producto")]
	public class ProductoAD
	{
		[Column("Id")]
		public int Id { get; set; }
		[Column("Nombre")]
		public string Nombre { get; set; }
		[Column("CategoriaId")]
		public int CategoriaId { get; set; }
		[Column("Precio")]
		public float Precio { get; set; }
		[Column("ImpuestoPorc")]
		public float ImpuestoPorc { get; set; }
		[Column("Stock")]
		public int Stock { get; set; }
		[Column("ImagenUrl")]
		public string ImagenUrl { get; set; } 
		[Column("Activo")]
		public bool Activo { get; set; }
	}
}