using Pedidos.Abstracciones.AccesoADatos.Producto.ListarProductos;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.ListarProductos;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Producto.ListarProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.LogicaDeNegocio.Producto.ListarProducto
{
	public class ListarClientesLN: IListarClientesLN
	{
		private IListarClientesAD _listarProductoAD;
		public ListarClientesLN() {
			_listarProductoAD = new ListarProductoAD();
		}

		public List<ProductoDto> Obtener()
		{
			/*List<ProductoDto> laListaDeProducto = new List<ProductoDto>();
			laListaDeProducto.Add(ObtenerObjeto());*/
			List<ProductoDto> laListaDeProducto = _listarProductoAD.Obtener();

			return laListaDeProducto;
		}

		public ProductoDto ObtenerObjeto()
		{
			return new ProductoDto { 
			Id = 1,
			Nombre = "Producto1",
            CategoriaId = 1,
            Precio = 200.0f,
            ImpuestoPorc = 11,
            Stock = 1,
            Activo = true,
            ImagenUrl = "Corolla"

			};


    }
	}
}
