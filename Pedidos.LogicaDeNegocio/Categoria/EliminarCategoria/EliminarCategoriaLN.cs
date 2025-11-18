using Pedidos.Abstracciones.AccesoADatos.Categoria.EliminarCategoria;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.EliminarCategoria;
using Pedidos.AccesoADatos.Categoria.EliminarCategoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Categoria.EliminarCategoria
{
    public class EliminarCategoriaLN : IEliminarCategoriaLN
    {
        private IEliminarCategoriaAD _eliminarCategoriaAD;

        public EliminarCategoriaLN()
        {
            _eliminarCategoriaAD = new EliminarCategoriaAD();
        }

        public int Eliminar(int id)
        {
            int cantidadDeResultados = _eliminarCategoriaAD.Eliminar(id);
            return cantidadDeResultados;
        }
    }
}

