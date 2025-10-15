using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.CrearCliente;
using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.ListarClientes;
using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.ObtenerClientePorId;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.ActualizarCliente;
using Pedidos.Abstracciones.LogicaDeNegocio.Cliente.EliminarCliente;
using Pedidos.LogicaDeNegocio.Cliente.CrearCliente;
using Pedidos.LogicaDeNegocio.Cliente.ListarCliente;
using Pedidos.LogicaDeNegocio.Cliente.ObtenerClientePorId;
using Pedidos.LogicaDeNegocio.Cliente.ActualizarCliente;
using Pedidos.LogicaDeNegocio.Cliente.EliminarCliente;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Cliente.UI.Controllers
{
    public class ClienteController : Controller
    {
        private IListarClientesLN _listarCliente;
        private ICrearClienteLN _crearCliente;
        private IObtenerClientePorIdLN _obtenerClientePorId;
        private IActualizarClienteLN _actualizarCliente;
        private IEliminarClienteLN _eliminarCliente;
        public ClienteController()
        {
            _listarCliente = new ListarClientesLN();
            _crearCliente = new CrearClienteLN();
            _obtenerClientePorId = new ObtenerClientePorIdLN();
            _actualizarCliente = new ActualizarClienteLN();
            _eliminarCliente = new EliminarClienteLN();
        }


        // GET: Cliente
        public ActionResult ListarCliente()
        {
            List<ClienteDto> laListaDeCliente = _listarCliente.Obtener();
            int i = 0;
            return View(laListaDeCliente);
        }

        // GET: Cliente/Details/5
        public ActionResult DetallesCliente(int id)
        {
            ClienteDto elCliente = _obtenerClientePorId.Obtener(id);
            return View(elCliente);
        }

        // GET: Cliente/Create
        public ActionResult CrearCliente()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<ActionResult> CrearCliente(ClienteDto elClienteCreado)
        {
            try
            {
                int cantidadDeRegistros = await _crearCliente.Guardar(elClienteCreado);
                return RedirectToAction("ListarCliente");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult EditarCliente(int id)
        {
            ClienteDto elCliente = _obtenerClientePorId.Obtener(id);
            return View(elCliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCliente(ClienteDto elCliente)
        {
            try
            {
                int cantidadAfectada = _actualizarCliente.Actualizar(elCliente);
                return RedirectToAction("ListarCliente");
            }
            catch
            {
                return View(elCliente);
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult EliminarCliente(int id)
        {
            ClienteDto elCliente = _obtenerClientePorId.Obtener(id);
            return View(elCliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EliminarCliente")] // Mantiene la ruta POST coherente con el formulario de la vista
        public ActionResult EliminarClienteConfirmado(int id)
        {
            try
            {
                // Elimina el registro de Cliente indicado
                int cantidadAfectada = _eliminarCliente.Eliminar(id);
                return RedirectToAction("ListarCliente");
            }
            catch
            {
                return View();
            }
        }

        // Devuelve la imagen del repuesto por código o un placeholder si no existe
        public ActionResult ImagenDeClientePorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return PlaceholderImage();
            }

            string carpeta = Server.MapPath("~/Content/Uploads");
            string[] extensiones = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp", ".svg" };
            foreach (var ext in extensiones)
            {
                string ruta = Path.Combine(carpeta, codigo + ext);
                if (System.IO.File.Exists(ruta))
                {
                    string contentType = ObtenerContentType(ext);
                    return File(ruta, contentType);
                }
            }
            return PlaceholderImage();
        }

        private ActionResult PlaceholderImage()
        {
            string placeholder = Server.MapPath("~/Content/Images/placeholder.svg");
            if (System.IO.File.Exists(placeholder))
            {
                return File(placeholder, "image/svg+xml");
            }
            return new HttpNotFoundResult();
        }

        private string ObtenerContentType(string ext)
        {
            switch (ext.ToLowerInvariant())
            {
                case ".jpg":
                case ".jpeg": return "image/jpeg";
                case ".png": return "image/png";
                case ".gif": return "image/gif";
                case ".webp": return "image/webp";
                case ".svg": return "image/svg+xml";
                default: return "application/octet-stream";
            }
        }

        private void GuardarArchivo(HttpPostedFileBase archivo, string nombreBase)
        {
            if (archivo == null || archivo.ContentLength <= 0 || string.IsNullOrWhiteSpace(nombreBase))
                return;

            string carpeta = Server.MapPath("~/Content/Uploads");
            if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

            string extension = Path.GetExtension(archivo.FileName);
            if (string.IsNullOrEmpty(extension)) extension = ".png";
            string rutaDestino = Path.Combine(carpeta, nombreBase + extension.ToLowerInvariant());

            // Borra imágenes previas del mismo código para mantener una sola
            foreach (var existente in Directory.GetFiles(carpeta, nombreBase + ".*"))
            {
                try { System.IO.File.Delete(existente); } catch { }
            }

            archivo.SaveAs(rutaDestino);
        }
    }
}
