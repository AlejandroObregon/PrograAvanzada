using Pedidos.Abstracciones.AccesoADatos.Categoria.ListarCategorias;
using Pedidos.Abstracciones.AccesoADatos.Categoria.ObtenerCategoriaPorId;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.ObtenerCategoriaPorId;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Categoria.ListarCategorias;
using Pedidos.AccesoADatos.Categoria.ObtenerCategoriaPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Categoria.ObtenerCategoriaPorId
{
	public class ObtenerCategoriaPorIdLN: IObtenerCategoriaPorIdLN
	{
		private IObtenerCategoriaPorIdAD _obtenerCategoriaPorId;
		public ObtenerCategoriaPorIdLN()
		{
			_obtenerCategoriaPorId = new ObtenerCategoriaPorIdAD();
		}

		public CategoriaDto Obtener(int id)
		{
			CategoriaDto elCategoria = _obtenerCategoriaPorId.Obtener(id);
			return elCategoria;
		}
	}
}
