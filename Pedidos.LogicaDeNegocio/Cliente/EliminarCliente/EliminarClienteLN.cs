using Pedidos.Abstracciones.AccesoADatos.Cliente.EliminarCliente;
using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.EliminarCliente;
using Pedidos.AccesoADatos.Cliente.EliminarCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Cliente.EliminarCliente
{
    public class EliminarClienteLN : IEliminarClienteLN
    {
        private IEliminarClienteAD _eliminarClienteAD;

        public EliminarClienteLN()
        {
            _eliminarClienteAD = new EliminarClienteAD();
        }

        public int Eliminar(int id)
        {
            int cantidadDeResultados = _eliminarClienteAD.Eliminar(id);
            return cantidadDeResultados;
        }
    }
}

