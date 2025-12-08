using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pedidos.Abstracciones.ModelosParaUI
{
    public class PedidoDto
    {
        public int Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }


        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public int ImpuestosPorc { get; set; }
        public IEnumerable<ProductoDto> Productos { get; set; }

    }
}