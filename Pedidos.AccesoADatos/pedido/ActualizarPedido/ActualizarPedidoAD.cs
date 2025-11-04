using Pedidos.Abstracciones.AccesoADatos.Pedido.ActualizarPedido;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Pedido.ActualizarPedido
{
	public class ActualizarPedidoAD: IActualizarPedidoAD
	{
		private ContextoPedido _contexto;
		public ActualizarPedidoAD()
		{
			_contexto = new ContextoPedido();
		}

		public int Actualizar(PedidoDto elPedido)
		{
			PedidoAD elPedidoEnBaseDeDatos = _contexto.Pedido.Where(Pedido => Pedido.Id == elPedido.Id).FirstOrDefault();
            // Actualiza campos editables
            elPedidoEnBaseDeDatos.Id = elPedido.Id;
            elPedidoEnBaseDeDatos.ClienteId = elPedido.ClienteId;
            elPedidoEnBaseDeDatos.UsuarioId = elPedido.UsuarioId;
            elPedidoEnBaseDeDatos.Fecha = elPedido.Fecha;
            elPedidoEnBaseDeDatos.Subtotal = elPedido.Subtotal;
            elPedidoEnBaseDeDatos.Impuestos = elPedido.Impuestos;
            elPedidoEnBaseDeDatos.Total = elPedido.Total;
			elPedidoEnBaseDeDatos.Estado = elPedido.Estado;
            EntityState estado = _contexto.Entry(elPedidoEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
			int cantidadDeDatosAgregados = _contexto.SaveChanges();
			return cantidadDeDatosAgregados;
		}
	}
}