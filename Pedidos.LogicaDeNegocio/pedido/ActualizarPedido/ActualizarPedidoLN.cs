using Pedidos.Abstracciones.AccesoADatos.Pedido.ActualizarPedido;
using Pedidos.Abstracciones.LogicaDeNegocio.General;
using Pedidos.Abstracciones.LogicaDeNegocio.Pedido.ActualizarPedido;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Pedido.ActualizarPedido;
using Pedidos.LogicaDeNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Pedido.ActualizarPedido
{
    public class ActualizarPedidoLN : IActualizarPedidoLN
    {
        private IActualizarPedidoAD _actualizarPedidoAD;
        private IFecha _fecha;

        public ActualizarPedidoLN()
        {
            _actualizarPedidoAD = new ActualizarPedidoAD();
            _fecha = new Fecha();
        }

        public int Actualizar(PedidoDto elPedido)
        {
            int cantidadDeResultados = _actualizarPedidoAD.Actualizar(elPedido);
            return cantidadDeResultados;
        }
    }
}

