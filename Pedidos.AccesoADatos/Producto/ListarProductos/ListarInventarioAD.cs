using Pedidos.Abstracciones.AccesoADatos.Producto.ListarProductos;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.ListarProductos;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Producto.ListarProducto
{
	public class ListarProductoAD: IListarProductosAD
	{

		private ContextoProducto _elContexto;
		public ListarProductoAD()
		{
			_elContexto = new ContextoProducto();
		}

		public List<ProductoDto> Obtener()
		{

			List<ProductoAD> laListaEnBaseDeDatos = _elContexto.Productos.ToList();
			List<ProductoDto> laListaARetornar = (from Producto in _elContexto.Productos
													select new ProductoDto
													{
                                                        Id = Producto.Id,
                                                        Nombre = Producto.Nombre,
                                                        CategoriaId = Producto.CategoriaId,
                                                        Precio = Producto.Precio,
                                                        ImpuestoPorc = Producto.ImpuestoPorc,
                                                        Stock = Producto.Stock,
                                                        Activo = Producto.Activo,
                                                        ImagenUrl = Producto.ImagenUrl,
                                                    }).ToList();
			return laListaARetornar;
		}
	}
}
