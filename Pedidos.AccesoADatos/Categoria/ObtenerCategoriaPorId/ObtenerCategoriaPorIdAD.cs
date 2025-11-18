using Pedidos.Abstracciones.AccesoADatos.Categoria.ObtenerCategoriaPorId;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.AccesoADatos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.AccesoADatos.Categoria.ObtenerCategoriaPorId
{
	public class ObtenerCategoriaPorIdAD: IObtenerCategoriaPorIdAD
	{
		private ContextoCategoria _elContexto;
		public ObtenerCategoriaPorIdAD()
		{
			_elContexto = new ContextoCategoria();
		}
		public CategoriaDto Obtener(int id)
		{
			CategoriaDto laListaARetornar = (from Categoria in _elContexto.Categorias
											  where Categoria.Id == id
													select new CategoriaDto
													{
                                                        Id = Categoria.Id,
                                                        Nombre = Categoria.Nombre,
                                                        Activo = Categoria.Activo,
                                                    }).FirstOrDefault();
			return laListaARetornar;
		}
	}
}




