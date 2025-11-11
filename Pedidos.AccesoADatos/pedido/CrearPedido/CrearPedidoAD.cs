using Pedidos.Abstracciones.AccesoADatos.Pedido.CrearPedido;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Pedido.CrearPedido
{
	public class CrearPedidoAD : ICrearPedidoAD
	{
		private ContextoPedido _contexto;
		private ContextoPedidoDetalle _contextod;

		public CrearPedidoAD()
		{
			_contexto = new ContextoPedido();
            _contextod = new ContextoPedidoDetalle();
        }

		public async Task<int> Guardar(PedidoDto elPedido)
		{
			PedidoAD elPedidoAGuardar = ConvertirObjetoParaAD(elPedido);
            _contexto.Pedido.Add(elPedidoAGuardar);
            EntityState estado = _contexto.Entry(elPedidoAGuardar).State = System.Data.Entity.EntityState.Added;
			int cantidadDeDatosAgregados = await _contexto.SaveChangesAsync();

            elPedido.PedidoId = elPedidoAGuardar.Id;
            PedidoDetalleAD elPedidoDetalleAGuardar = ConvertirObjetoParaAD2(elPedido);
            _contextod.PedidoDetalle.Add(elPedidoDetalleAGuardar);
            EntityState estadod = _contextod.Entry(elPedidoDetalleAGuardar).State = System.Data.Entity.EntityState.Added;
            int cantidadDeDatosAgregadosd = await _contextod.SaveChangesAsync();

            return cantidadDeDatosAgregados;
		}
		
		
		private PedidoAD ConvertirObjetoParaAD(PedidoDto Pedido)
		{
            DateTime localDate = DateTime.Now;

            return new PedidoAD {
                Id = Pedido.Id,
                ClienteId = Pedido.ClienteId,
                UsuarioId = 1,
                Fecha = localDate,
                Subtotal = Pedido.Subtotal,
                Impuestos = Pedido.Impuestos,
                Total = Pedido.Total,
                Estado = "Pendiente",
            };
		}

        private PedidoDetalleAD ConvertirObjetoParaAD2(PedidoDto Pedido)
        {
            DateTime localDate = DateTime.Now;

            return new PedidoDetalleAD
            {
        
                PedidoId = Pedido.PedidoId,
                ProductoId = Pedido.ProductoId,
                Cantidad = Pedido.Cantidad,
                PrecioUnit = Pedido.Precio,
                Descuento = Pedido.Descuento,
                ImpuestoPorc = Pedido.ImpuestosPorc,
                TotalLinea = Pedido.Total
            };
        }
    }
}

