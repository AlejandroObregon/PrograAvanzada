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
        [Required]
        public int CategoriaId { get; set; }
		[Required]
		public float Precio { get; set; }
		[Required]
		public float ImpuestoPorc { get; set; }
		[Required]
		public int Stock { get; set; }
		[Required]
		public bool Activo { get; set; }
		public string ImagenUrl { get; set; }
        public HttpPostedFileBase archivo { get; set; }
    }
}




