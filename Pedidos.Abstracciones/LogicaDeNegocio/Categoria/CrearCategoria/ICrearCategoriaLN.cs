using Pedidos.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.LogicaDeNegocio.Categoria.CrearCategoria
{
	public interface ICrearCategoriaLN
	{
		Task<int> Guardar(CategoriaDto elCategoria);
	}
}
