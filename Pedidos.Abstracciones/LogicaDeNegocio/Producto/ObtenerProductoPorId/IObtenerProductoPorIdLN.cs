using Pedidos.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.LogicaDeNegocio.Producto.ObtenerProductoPorId
{
	public interface IObtenerProductoPorIdLN
	{
		ProductoDto Obtener(int id);
	}
}
