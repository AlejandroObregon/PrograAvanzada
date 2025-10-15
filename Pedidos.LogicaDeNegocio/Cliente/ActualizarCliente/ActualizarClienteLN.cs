using Pedidos.Abstracciones.AccesoADatos.Cliente.ActualizarCliente;
using Pedidos.Abstracciones.LogicaDeNegocio.General;
using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.ActualizarCliente;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Cliente.ActualizarCliente;
using Pedidos.LogicaDeNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Cliente.ActualizarCliente
{
    public class ActualizarClienteLN : IActualizarClienteLN
    {
        private IActualizarClienteAD _actualizarClienteAD;
        private IFecha _fecha;

        public ActualizarClienteLN()
        {
            _actualizarClienteAD = new ActualizarClienteAD();
            _fecha = new Fecha();
        }

        public int Actualizar(ClienteDto elCliente)
        {
            int cantidadDeResultados = _actualizarClienteAD.Actualizar(elCliente);
            return cantidadDeResultados;
        }
    }
}

