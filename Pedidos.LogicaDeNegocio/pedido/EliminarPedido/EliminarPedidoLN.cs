using Pedidos.Abstracciones.AccesoADatos.Pedido.EliminarPedido;
using Pedidos.Abstracciones.LogicaDeNegocio.Pedido.EliminarPedido;
using Pedidos.AccesoADatos.Pedido.EliminarPedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Pedido.EliminarPedido
{
    public class EliminarPedidoLN : IEliminarPedidoLN
    {
        private IEliminarPedidoAD _eliminarPedidoAD;

        public EliminarPedidoLN()
        {
            _eliminarPedidoAD = new EliminarPedidoAD();
        }

        public int Eliminar(int id)
        {
            int cantidadDeResultados = _eliminarPedidoAD.Eliminar(id);
            return cantidadDeResultados;
        }
    }
}

