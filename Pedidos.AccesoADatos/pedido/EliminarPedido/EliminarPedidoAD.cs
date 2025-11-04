using Pedidos.Abstracciones.AccesoADatos.Pedido.EliminarPedido;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Pedido.EliminarPedido
{
	public class EliminarPedidoAD: IEliminarPedidoAD
	{
		private ContextoPedido _contexto;
		public EliminarPedidoAD()
		{
			_contexto = new ContextoPedido();
		}

		public int Eliminar(int id)
		{
			PedidoAD elPedidoEnBaseDeDatos = _contexto.Pedido.Where(Pedido => Pedido.Id == id).FirstOrDefault();
			_contexto.Pedido.Remove(elPedidoEnBaseDeDatos);
			EntityState estado = _contexto.Entry(elPedidoEnBaseDeDatos).State = System.Data.Entity.EntityState.Deleted;
			int cantidadDeDatosAgregados = _contexto.SaveChanges();
			return cantidadDeDatosAgregados;
		}
	}
}
