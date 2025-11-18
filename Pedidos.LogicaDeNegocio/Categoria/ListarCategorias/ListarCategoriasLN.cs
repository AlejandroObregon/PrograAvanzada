using Pedidos.Abstracciones.AccesoADatos.Categoria.ListarCategorias;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.ListarCategorias;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Categoria.ListarCategorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Categoria.ListarCategoria
{
	public class ListarCategoriasLN: IListarCategoriasLN
	{
		private IListarCategoriasAD _listarCategoriaAD;
		public ListarCategoriasLN() {
			_listarCategoriaAD = new ListarCategoriaAD();
		}

		public List<CategoriaDto> Obtener()
		{
			/*List<CategoriaDto> laListaDeCategoria = new List<CategoriaDto>();
			laListaDeCategoria.Add(ObtenerObjeto());*/
			List<CategoriaDto> laListaDeCategoria = _listarCategoriaAD.Obtener();

			return laListaDeCategoria;
		}

		public CategoriaDto ObtenerObjeto()
		{
			return new CategoriaDto { 
			Id = 1,
			Nombre = "Categoria1",
			};


    }
	}
}
