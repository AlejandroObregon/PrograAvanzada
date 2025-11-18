using Pedidos.Abstracciones.AccesoADatos.Categoria.ActualizarCategoria;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Categoria.ActualizarCategoria
{
	public class ActualizarCategoriaAD: IActualizarCategoriaAD
	{
		private ContextoCategoria _contexto;
		public ActualizarCategoriaAD()
		{
			_contexto = new ContextoCategoria();
		}

		public int Actualizar(CategoriaDto elCategoria)
		{
			CategoriaAD elCategoriaEnBaseDeDatos = _contexto.Categorias.Where(Categoria => Categoria.Id == elCategoria.Id).FirstOrDefault();
            // Actualiza campos editables
            elCategoriaEnBaseDeDatos.Id = elCategoria.Id;
            elCategoriaEnBaseDeDatos.Nombre = elCategoria.Nombre;
            elCategoriaEnBaseDeDatos.Activo = elCategoria.Activo;
            EntityState estado = _contexto.Entry(elCategoriaEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
			int cantidadDeDatosAgregados = _contexto.SaveChanges();
			return cantidadDeDatosAgregados;
		}
	}
}