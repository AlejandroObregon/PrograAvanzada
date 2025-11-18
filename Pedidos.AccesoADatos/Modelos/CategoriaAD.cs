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
	[Table("Categoria")]
	public class CategoriaAD
	{
		[Column("Id")]
		public int Id { get; set; }
		[Column("Nombre")]
		public string Nombre { get; set; }
        [Column("Activo")]
        public bool Activo { get; set; }
    }
}