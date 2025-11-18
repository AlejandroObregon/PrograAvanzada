using Pedidos.Abstracciones.AccesoADatos.Categoria.CrearCategoria;
using Pedidos.Abstracciones.LogicaDeNegocio.General;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.CrearCategoria;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Categoria.CrearCategoria;
using Pedidos.LogicaDeNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Categoria.CrearCategoria
{
	public class CrearCategoriaLN: ICrearCategoriaLN
	{
		private ICrearCategoriaAD _crearCategoriaAD;
		private IFecha _fecha;

		public CrearCategoriaLN()
		{
			_crearCategoriaAD = new CrearCategoriaAD();
			_fecha = new Fecha();
		}

		public async Task<int> Guardar(CategoriaDto elCategoria)
		{
			int cantidadDeResultados = await _crearCategoriaAD.Guardar(elCategoria);
			return cantidadDeResultados;
		}
		

	}
}
