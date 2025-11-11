using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.ListarClientes;
using Pedidos.Abstracciones.LogicaDeNegocio.Pedido.ActualizarPedido;
using Pedidos.Abstracciones.LogicaDeNegocio.Pedido.CrearPedido;
using Pedidos.Abstracciones.LogicaDeNegocio.Pedido.ObtenerPedidoPorId;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.ListarProductos;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.ObtenerProductoPorId;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.LogicaDeNegocio.Cliente.ListarCliente;
using Pedidos.LogicaDeNegocio.Pedido.ActualizarPedido;
using Pedidos.LogicaDeNegocio.Pedido.CrearPedido;
using Pedidos.LogicaDeNegocio.Pedido.ObtenerPedidoPorId;
using Pedidos.LogicaDeNegocio.Producto.ListarProducto;
using Pedidos.LogicaDeNegocio.Producto.ObtenerProductoPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Pedido.UI.Controllers
{
    public class PedidoController : Controller
    {
        private IListarClientesLN _listarPedido;
        private ICrearPedidoLN _crearPedido;
        private IObtenerPedidoPorIdLN _obtenerPedidoPorId;
        private IActualizarPedidoLN _actualizarPedido;
        private IListarProductosLN _listarProducto;
        private IObtenerProductoPorIdLN _obtenerProductoPorId;

        public PedidoController()
        {
            _listarPedido = new ListarClientesLN();
            _crearPedido = new CrearPedidoLN();
            _obtenerPedidoPorId = new ObtenerPedidoPorIdLN();
            _actualizarPedido = new ActualizarPedidoLN();
            _listarProducto = new ListarProductosLN();
            _obtenerProductoPorId = new ObtenerProductoPorIdLN();

        }
        public ActionResult ListarPedido()
        {
            List<ClienteDto> laListaDePedidos = _listarPedido.Obtener();
            int i = 0;
            return View(laListaDePedidos);
        }

        public ActionResult DetallesPedido()
        {
            return View();
        }

        public ActionResult CrearPedido(int Id)
        {
            List<ProductoDto> laListaDeProducto = _listarProducto.Obtener();
            int i = 0;

            DateTime now = DateTime.Now;
            PedidoDto elPedido = new PedidoDto
            {
                ClienteId = Id,
                Productos = laListaDeProducto
            }
            ;

           
            return View(elPedido);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> CrearPedido(PedidoDto elPedidoCreado)
        {
            try
            {
                int guardado = await _crearPedido.Guardar(elPedidoCreado);
                return RedirectToAction("ListarPedido");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditarPedido()
        {
            return View();
        }

        public JsonResult DetallesProducto(int id)
        {
            ProductoDto elProducto = _obtenerProductoPorId.Obtener(id);
            return Json(elProducto, JsonRequestBehavior.AllowGet);
        }
    }
}