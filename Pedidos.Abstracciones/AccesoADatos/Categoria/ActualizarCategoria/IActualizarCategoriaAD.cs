using Pedidos.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.AccesoADatos.Categoria.ActualizarCategoria
{
	public interface IActualizarCategoriaAD
	{
		int Actualizar(CategoriaDto elCategoria);
	}
}
