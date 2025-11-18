using Pedidos.Abstracciones.AccesoADatos.Categoria.EliminarCategoria;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Categoria.EliminarCategoria
{
	public class EliminarCategoriaAD: IEliminarCategoriaAD
	{
		private ContextoCategoria _contexto;
		public EliminarCategoriaAD()
		{
			_contexto = new ContextoCategoria();
		}

		public int Eliminar(int id)
		{
			CategoriaAD elCategoriaEnBaseDeDatos = _contexto.Categorias.Where(Categoria => Categoria.Id == id).FirstOrDefault();
			_contexto.Categorias.Remove(elCategoriaEnBaseDeDatos);
			EntityState estado = _contexto.Entry(elCategoriaEnBaseDeDatos).State = System.Data.Entity.EntityState.Deleted;
			int cantidadDeDatosAgregados = _contexto.SaveChanges();
			return cantidadDeDatosAgregados;
		}
	}
}
