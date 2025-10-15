using Pedidos.Abstracciones.AccesoADatos.Producto.ActualizarProducto;
using Pedidos.Abstracciones.LogicaDeNegocio.General;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.ActualizarProducto;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Producto.ActualizarProducto;
using Pedidos.LogicaDeNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Producto.ActualizarProducto
{
    public class ActualizarClienteLN : IActualizarClienteLN
    {
        private IActualizarClienteAD _actualizarProductoAD;
        private IFecha _fecha;

        public ActualizarClienteLN()
        {
            _actualizarProductoAD = new ActualizarProductoAD();
            _fecha = new Fecha();
        }

        public int Actualizar(ProductoDto elProducto)
        {
            int cantidadDeResultados = _actualizarProductoAD.Actualizar(elProducto);
            return cantidadDeResultados;
        }
    }
}

