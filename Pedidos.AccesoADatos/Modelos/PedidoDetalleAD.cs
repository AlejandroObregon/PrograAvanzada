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
    [Table("PedidoDetalle")]
    public class PedidoDetalleAD
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("PedidoId")]
        public int PedidoId { get; set; }
        [Column("ProductoId")]
        public int ProductoId { get; set; }
        [Column("Cantidad")]
        public int Cantidad { get; set; }
        [Column("PrecioUnit")]
        public decimal PrecioUnit { get; set; }
        [Column("Descuento")]
        public decimal Descuento { get; set; }
        [Column("ImpuestoPorc")]
        public decimal ImpuestoPorc { get; set; }
        [Column("TotalLinea")]
        public decimal TotalLinea { get; set; }
    }
}
