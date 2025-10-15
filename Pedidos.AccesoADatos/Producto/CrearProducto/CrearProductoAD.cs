using Pedidos.Abstracciones.AccesoADatos.Producto.CrearProducto;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Producto.CrearProducto
{
	public class CrearProductoAD : ICrearProductoAD
	{
		private ContextoProducto _contexto;

		public CrearProductoAD()
		{
			_contexto = new ContextoProducto();
		}

		public async Task<int> Guardar(ProductoDto elProducto)
		{
			ProductoAD elProductoAGuardar = ConvertirObjetoParaAD(elProducto);
			
			_contexto.Productos.Add(elProductoAGuardar);
			
			EntityState estado = _contexto.Entry(elProductoAGuardar).State = System.Data.Entity.EntityState.Added;
			int cantidadDeDatosAgregados = await _contexto.SaveChangesAsync();
			return cantidadDeDatosAgregados;
		}
		
		
private ProductoAD ConvertirObjetoParaAD(ProductoDto Producto)
		{
			return new ProductoAD {
				Id = Producto.Id,
                Nombre = Producto.Nombre,
                CategoriaId = Producto.CategoriaId,
                Precio = Producto.Precio,
                ImpuestoPorc = Producto.ImpuestoPorc,
                Stock = Producto.Stock,
                ImagenUrl = Producto.ImagenUrl,
                Activo = Producto.Activo
			};
		}
	}
}
