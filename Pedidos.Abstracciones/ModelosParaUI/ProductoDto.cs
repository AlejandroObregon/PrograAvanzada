using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pedidos.Abstracciones.ModelosParaUI
{
	public class ProductoDto
	{
		public int Id { get; set; }
		[Required]
		public string Nombre { get; set; }
		public int CategoriaId { get; set; }
		public float Precio { get; set; }
		public float ImpuestoPorc { get; set; }
		public int Stock { get; set; }
		public bool Activo { get; set; }
		public string ImagenUrl { get; set; }
	}
}




