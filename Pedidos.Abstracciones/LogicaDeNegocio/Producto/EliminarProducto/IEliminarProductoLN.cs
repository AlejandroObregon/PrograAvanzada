using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.LogicaDeNegocio.Producto.EliminarInventario
{
    public interface IEliminarProductoLN
    {
        int Eliminar(int id);
    }
}

