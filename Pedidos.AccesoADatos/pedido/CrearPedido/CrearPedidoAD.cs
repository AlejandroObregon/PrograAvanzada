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
        private ContextoProducto _contextop;

        public CrearPedidoAD()
		{
			_contexto = new ContextoPedido();
            _contextod = new ContextoPedidoDetalle();
            _contextop = new ContextoProducto();
        }

		public async Task<int> Guardar(PedidoDto elPedido)
		{
            // Guarda el Pedido
			PedidoAD elPedidoAGuardar = ConvertirObjetoParaAD(elPedido);
            _contexto.Pedido.Add(elPedidoAGuardar);
            EntityState estado = _contexto.Entry(elPedidoAGuardar).State = System.Data.Entity.EntityState.Added;
			int cantidadDeDatosAgregados = await _contexto.SaveChangesAsync();

            // Guarde el Detalle del Pedido con el ID
            elPedido.PedidoId = elPedidoAGuardar.Id;
            PedidoDetalleAD elPedidoDetalleAGuardar = ConvertirObjetoParaAD2(elPedido);
            _contextod.PedidoDetalle.Add(elPedidoDetalleAGuardar);
            EntityState estadod = _contextod.Entry(elPedidoDetalleAGuardar).State = System.Data.Entity.EntityState.Added;
            int cantidadDeDatosAgregadosd = await _contextod.SaveChangesAsync();

            // Actualiza los stocks del producto en BD
            ProductoAD elProductoEnBaseDeDatos = _contextop.Productos.Where(producto => producto.Id == elPedidoDetalleAGuardar.ProductoId).FirstOrDefault();
            // Actualiza Stock
            var stockActualizado = elProductoEnBaseDeDatos.Stock - elPedidoDetalleAGuardar.Cantidad;
            elProductoEnBaseDeDatos.Stock = stockActualizado;

            EntityState estadop = _contextop.Entry(elProductoEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAgregadosp = _contextop.SaveChanges();
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

