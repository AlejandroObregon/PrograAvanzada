using Inventario.Abstracciones.AccesoADatos.Inventario.ListarInventario;
using Inventario.Abstracciones.LogicaDeNegocio.Inventario.ListarInventario;
using Inventario.Abstracciones.ModelosParaUI;
using Inventario.AccesoADatos.Inventario.ListarInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario.LogicaDeNegocio.Inventario.ListarInventario
{
	public class ListarProductosLN: IListarProductoLN
	{
		private IListarProductosAD _listarInventarioAD;
		public ListarProductosLN() {
			_listarInventarioAD = new ListarInventarioAD();
		}

		public List<InventarioDto> Obtener()
		{
			/*List<InventarioDto> laListaDeInventario = new List<InventarioDto>();
			laListaDeInventario.Add(ObtenerObjeto());*/
			List<InventarioDto> laListaDeInventario = _listarInventarioAD.Obtener();

			return laListaDeInventario;
		}

		private InventarioDto ObtenerObjeto()
		{
			return new InventarioDto { 
			Anio = 2025,
			Cantidad = 5,
			CodigoDelRepuesto = "0001",
			Estado = true,
			FechaDeModificacion = DateTime.Now,
			FechaDeRegistro = DateTime.Now,
			MarcaDelRepuesto = "KYB",
			Modelo = "Corolla",
			NombreDelRepuesto = "Compensador",
			Vehiculo = "Toyota"
			};
		}
	}
}
