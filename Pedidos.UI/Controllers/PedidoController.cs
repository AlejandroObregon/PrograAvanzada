using Pedidos.Abstracciones.LogicaDeNegocio.Pedido.ActualizarPedido;
using Pedidos.Abstracciones.LogicaDeNegocio.Pedido.CrearPedido;
using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.ListarClientes;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.ListarProductos;
using Pedidos.Abstracciones.LogicaDeNegocio.Pedido.ObtenerPedidoPorId;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.LogicaDeNegocio.Pedido.ActualizarPedido;
using Pedidos.LogicaDeNegocio.Pedido.CrearPedido;
using Pedidos.LogicaDeNegocio.Cliente.ListarCliente;
using Pedidos.LogicaDeNegocio.Pedido.ObtenerPedidoPorId;
using Pedidos.LogicaDeNegocio.Producto.ListarProducto;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public PedidoController()
        {
            _listarPedido = new ListarClientesLN();
            _crearPedido = new CrearPedidoLN();
            _obtenerPedidoPorId = new ObtenerPedidoPorIdLN();
            _actualizarPedido = new ActualizarPedidoLN();
            _listarProducto = new ListarProductosLN();
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

        public ActionResult EditarPedido()
        {
            return View();
        }
    }
}