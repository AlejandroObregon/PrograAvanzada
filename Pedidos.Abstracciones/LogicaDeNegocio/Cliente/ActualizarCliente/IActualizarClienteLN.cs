using Pedidos.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.LogicaDeNegocio.Cliente.ActualizarCliente
{
    public interface IActualizarClienteLN
    {
        int Actualizar(ClienteDto elCliente);
    }
}

