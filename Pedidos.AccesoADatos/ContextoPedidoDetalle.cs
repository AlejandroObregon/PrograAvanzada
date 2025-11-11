using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos
{
    public class ContextoPedidoDetalle : DbContext
    {
        public ContextoPedidoDetalle() : base("name=Contexto")
        {

        }

        public DbSet<PedidoDetalleAD> PedidoDetalle { get; set; }
    }
}
