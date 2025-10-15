using Pedidos.Abstracciones.AccesoADatos.Producto.EliminarProducto;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.EliminarProducto;
using Pedidos.AccesoADatos.Producto.EliminarProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Producto.EliminarProducto
{
    public class EliminarClienteLN : IEliminarClienteLN
    {
        private IEliminarClienteAD _eliminarProductoAD;

        public EliminarClienteLN()
        {
            _eliminarProductoAD = new EliminarProductoAD();
        }

        public int Eliminar(int id)
        {
            int cantidadDeResultados = _eliminarProductoAD.Eliminar(id);
            return cantidadDeResultados;
        }
    }
}

