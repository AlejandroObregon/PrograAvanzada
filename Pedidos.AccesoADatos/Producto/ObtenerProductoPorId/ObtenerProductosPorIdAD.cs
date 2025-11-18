using Pedidos.Abstracciones.AccesoADatos.Producto.ObtenerProductoPorId;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Producto.ObtenerProductoPorId
{
	public class ObtenerProductoPorIdAD: IObtenerProductoPorIdAD
	{
		private ContextoProducto _elContexto;
		public ObtenerProductoPorIdAD()
		{
			_elContexto = new ContextoProducto();
		}
		public ProductoDto Obtener(int id)
		{
			ProductoDto laListaARetornar = (from Producto in _elContexto.Productos
											  where Producto.Id == id
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
													}).FirstOrDefault();
			return laListaARetornar;
		}
	}
}




