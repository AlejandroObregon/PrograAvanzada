using Pedidos.Abstracciones.AccesoADatos.Categoria.ListarCategorias;
using Pedidos.Abstracciones.AccesoADatos.Categoria.ObtenerCategoriasActivas;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.ObtenerCategoriasActivas;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Categoria.ListarCategorias;
using Pedidos.AccesoADatos.Categoria.ObtenerCategoriasActivas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Categoria.ObtenerCategoriasActivas
{
	public class ObtenerCategoriasActivasLN: IObtenerCategoriasActivasLN
	{
		private IObtenerCategoriasActivasAD _obtenerCategoriasActivas;
		public ObtenerCategoriasActivasLN()
		{
			_obtenerCategoriasActivas = new ObtenerCategoriasActivasAD();
		}

		public List<CategoriaDto> Obtener()
		{
            List<CategoriaDto> laListaDeCategoria = _obtenerCategoriasActivas.Obtener();
			return laListaDeCategoria;
		}
	}
}
