using Pedidos.Abstracciones.AccesoADatos.Categoria.CrearCategoria;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Categoria.CrearCategoria
{
	public class CrearCategoriaAD : ICrearCategoriaAD
	{
		private ContextoCategoria _contexto;

		public CrearCategoriaAD()
		{
			_contexto = new ContextoCategoria();
		}

		public async Task<int> Guardar(CategoriaDto elCategoria)
		{
			CategoriaAD elCategoriaAGuardar = ConvertirObjetoParaAD(elCategoria);
			
			_contexto.Categorias.Add(elCategoriaAGuardar);
			
			EntityState estado = _contexto.Entry(elCategoriaAGuardar).State = System.Data.Entity.EntityState.Added;
			int cantidadDeDatosAgregados = await _contexto.SaveChangesAsync();
			return cantidadDeDatosAgregados;
		}
		
		
private CategoriaAD ConvertirObjetoParaAD(CategoriaDto Categoria)
		{
			return new CategoriaAD {
				Id = Categoria.Id,
                Nombre = Categoria.Nombre,
                Activo = Categoria.Activo,
            };
		}
	}
}
