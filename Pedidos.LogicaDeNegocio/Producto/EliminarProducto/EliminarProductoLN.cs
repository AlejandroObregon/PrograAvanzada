using Inventario.Abstracciones.AccesoADatos.Inventario.EliminarInventario;
using Inventario.Abstracciones.LogicaDeNegocio.Inventario.EliminarInventario;
using Inventario.AccesoADatos.Inventario.EliminarInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.LogicaDeNegocio.Inventario.EliminarInventario
{
    public class EliminarProductoLN : IEliminarProductoLN
    {
        private IEliminarProductoAD _eliminarInventarioAD;

        public EliminarProductoLN()
        {
            _eliminarInventarioAD = new EliminarProductoAD();
        }

        public int Eliminar(int id)
        {
            int cantidadDeResultados = _eliminarInventarioAD.Eliminar(id);
            return cantidadDeResultados;
        }
    }
}

