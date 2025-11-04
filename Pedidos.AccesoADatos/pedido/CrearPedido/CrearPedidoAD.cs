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

		public CrearPedidoAD()
		{
			_contexto = new ContextoPedido();
		}

		public async Task<int> Guardar(PedidoDto elPedido)
		{
			PedidoAD elPedidoAGuardar = ConvertirObjetoParaAD(elPedido);
			
			_contexto.Pedido.Add(elPedidoAGuardar);
			
			EntityState estado = _contexto.Entry(elPedidoAGuardar).State = System.Data.Entity.EntityState.Added;
			int cantidadDeDatosAgregados = await _contexto.SaveChangesAsync();
			return cantidadDeDatosAgregados;
		}
		
		
private PedidoAD ConvertirObjetoParaAD(PedidoDto Pedido)
		{
			return new PedidoAD {
                Id = Pedido.Id,
                ClienteId = Pedido.ClienteId,
                UsuarioId = Pedido.UsuarioId,
                Fecha = Pedido.Fecha,
                Subtotal = Pedido.Subtotal,
                Impuestos = Pedido.Impuestos,
                Total = Pedido.Total,
                Estado = Pedido.Estado,
            };
		}
	}
}
