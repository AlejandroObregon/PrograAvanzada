using Pedidos.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Abstracciones.AccesoADatos.Producto.CrearProducto
{
	public interface ICrearProductoAD
	{
		Task<int> Guardar(ProductoDto elProducto);
	}
}
