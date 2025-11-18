using Pedidos.Abstracciones.AccesoADatos.Categoria.ObtenerCategoriasActivas;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Categoria.ObtenerCategoriasActivas
{
    public class ObtenerCategoriasActivasAD : IObtenerCategoriasActivasAD
    {
        private ContextoCategoria _elContexto;

        public ObtenerCategoriasActivasAD()
        {
            _elContexto = new ContextoCategoria();
        }

        public List<CategoriaDto> Obtener()
        {
            List<CategoriaDto> laListaARetornar = (from categoria in _elContexto.Categorias
                                                   where categoria.Activo == true
                                                   select new CategoriaDto
                                                   {
                                                       Id = categoria.Id,
                                                       Nombre = categoria.Nombre,
                                                       Activo = categoria.Activo,
                                                   }).ToList(); // Cambiado a ToList()

            return laListaARetornar;
        }
    }
}




