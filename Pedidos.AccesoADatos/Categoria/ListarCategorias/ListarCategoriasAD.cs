using Pedidos.Abstracciones.AccesoADatos.Categoria.ListarCategorias;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.ListarCategorias;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Categoria.ListarCategorias
{
	public class ListarCategoriaAD: IListarCategoriasAD
	{

		private ContextoCategoria _elContexto;
		public ListarCategoriaAD()
		{
			_elContexto = new ContextoCategoria();
		}

		public List<CategoriaDto> Obtener()
		{

			List<CategoriaAD> laListaEnBaseDeDatos = _elContexto.Categorias.ToList();
			List<CategoriaDto> laListaARetornar = (from Categoria in _elContexto.Categorias
													select new CategoriaDto
													{
                                                        Id = Categoria.Id,
                                                        Nombre = Categoria.Nombre,
                                                        Activo = Categoria.Activo,
                                                    }).ToList();
			return laListaARetornar;
		}
	}
}
