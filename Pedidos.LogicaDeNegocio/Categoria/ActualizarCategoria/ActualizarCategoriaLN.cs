using Pedidos.Abstracciones.AccesoADatos.Categoria.ActualizarCategoria;
using Pedidos.Abstracciones.LogicaDeNegocio.General;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.ActualizarCategoria;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Categoria.ActualizarCategoria;
using Pedidos.LogicaDeNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Categoria.ActualizarCategoria
{
    public class ActualizarCategoriaLN : IActualizarCategoriaLN
    {
        private IActualizarCategoriaAD _actualizarCategoriaAD;
        private IFecha _fecha;

        public ActualizarCategoriaLN()
        {
            _actualizarCategoriaAD = new ActualizarCategoriaAD();
            _fecha = new Fecha();
        }

        public int Actualizar(CategoriaDto elCategoria)
        {
            int cantidadDeResultados = _actualizarCategoriaAD.Actualizar(elCategoria);
            return cantidadDeResultados;
        }
    }
}

