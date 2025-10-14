using Inventario.Abstracciones.AccesoADatos.Inventario.ListarInventario;
using Inventario.Abstracciones.AccesoADatos.Inventario.ObtenerInventarioPorId;
using Inventario.Abstracciones.LogicaDeNegocio.Inventario.ObtenerInventarioPorId;
using Inventario.Abstracciones.ModelosParaUI;
using Inventario.AccesoADatos.Inventario.ListarInventario;
using Inventario.AccesoADatos.Inventario.ObtenerInventarioPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.LogicaDeNegocio.Inventario.ObtenerInventarioPorId
{
	public class ObtenerProductoPorIdLN: IObtenerProductoPorIdLN
	{
		private IObtenerProductoPorIdAD _obtenerInventarioPorId;
		public ObtenerProductoPorIdLN()
		{
			_obtenerInventarioPorId = new ObtenerInventarioPorIdAD();
		}

		public InventarioDto Obtener(int id)
		{
			InventarioDto elInventario = _obtenerInventarioPorId.Obtener(id);
			return elInventario;
		}
	}
}
