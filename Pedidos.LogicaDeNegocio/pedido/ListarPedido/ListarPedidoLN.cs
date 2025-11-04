using Pedidos.Abstracciones.AccesoADatos.Pedido.ListarPedidos;
using Pedidos.Abstracciones.LogicaDeNegocio.Pedido.ListarPedidos;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Pedido.ListarPedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Pedido.ListarPedido
{
    public class ListarPedidoLN : IListarPedidoLN
    {
        private IListarPedidoAD _listarPedidoAD;
        public ListarPedidoLN()
        {
            _listarPedidoAD = new ListarPedidoAD();
        }

        public List<PedidoDto> Obtener()
        {
            /*List<PedidoDto> laListaDePedido = new List<PedidoDto>();
			laListaDePedido.Add(ObtenerObjeto());*/
            List<PedidoDto> laListaDePedido = _listarPedidoAD.Obtener();

            return laListaDePedido;
        }

        public PedidoDto ObtenerObjeto()
        {
            return new PedidoDto
            {
                Id = 1,
                UsuarioId = 1,
                ClienteId = 1,
                Fecha = new DateTime(1990, 10, 23),
                Subtotal = 100,
                Impuestos = 100,
                Total = 100,
                Estado = "Pendiente"
            };


        }
    }
}