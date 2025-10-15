using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.AccesoADatos.Producto.EliminarProducto
{
	public interface IEliminarProductoAD
	{
		int Eliminar(int id);
	}
}
