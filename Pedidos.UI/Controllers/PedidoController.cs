using Pedidos.Abstracciones.LogicaDeNegocio.Producto.ListarProductos;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.LogicaDeNegocio.Producto.ListarProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Producto.UI.Controllers
{
    public class PedidoController : Controller
    {
        private IListarClientesLN _listarProducto;
        public PedidoController()
        {
            _listarProducto = new ListarProductosLN();

        }
        public ActionResult ListarPedido()
        {
            List<ProductoDto> laListaDeProducto = _listarProducto.Obtener();
            int i = 0;
            return View(laListaDeProducto);
        }

        public ActionResult DetallesPedido()
        {
            return View();
        }

        public ActionResult CrearPedido()
        {
            return View();
        }

        public ActionResult EditarPedido()
        {
            return View();
        }
    }
}