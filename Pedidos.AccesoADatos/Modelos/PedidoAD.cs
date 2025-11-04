using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pedidos.AccesoADatos.Modelos
{
    [Table("Pedido")]
    public class PedidoAD
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("ClienteId")]
        public int ClienteId { get; set; }
        [Column("UsuarioId")]
        public int UsuarioId { get; set; }
        [Column("Fecha")]
        public DateTime Fecha { get; set; }
        [Column("Subtotal")]
        public decimal Subtotal { get; set; }
        [Column("Impuestos")]
        public decimal Impuestos { get; set; }
        [Column("Total")]
        public decimal Total { get; set; }
        [Column("Estado")]
        public string Estado { get; set; }
    }
}
