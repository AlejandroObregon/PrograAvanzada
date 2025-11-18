using Pedidos.Abstracciones.LogicaDeNegocio.Producto.CrearProducto;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.ListarProductos;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.ObtenerProductoPorId;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.ActualizarProducto;
using Pedidos.Abstracciones.LogicaDeNegocio.Producto.EliminarProducto;
using Pedidos.LogicaDeNegocio.Producto.CrearProducto;
using Pedidos.LogicaDeNegocio.Producto.ListarProducto;
using Pedidos.LogicaDeNegocio.Producto.ObtenerProductoPorId;
using Pedidos.LogicaDeNegocio.Producto.ActualizarProducto;
using Pedidos.LogicaDeNegocio.Producto.EliminarProducto;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Producto.UI.Controllers
{
    public class ProductoController : Controller
    {
        private IListarProductosLN _listarProducto;
        private ICrearProductoLN _crearProducto;
        private IObtenerProductoPorIdLN _obtenerProductoPorId;
        private IActualizarProductoLN _actualizarProducto;
        private IEliminarProductoLN _eliminarProducto;
		public ProductoController()
        {
            _listarProducto = new ListarProductosLN();
			_crearProducto = new CrearProductoLN();
			_obtenerProductoPorId = new ObtenerProductoPorIdLN();
            _actualizarProducto = new ActualizarProductoLN();
            _eliminarProducto = new EliminarProductoLN();
        }


        // GET: Producto
        public ActionResult ListarProducto()
        {
            List<ProductoDto> laListaDeProducto = _listarProducto.Obtener();
            int i = 0;
			return View(laListaDeProducto);
        }

        // GET: Producto/Details/5
        public ActionResult DetallesProducto(int id)
        {
            ProductoDto elProducto = _obtenerProductoPorId.Obtener(id);
			return View(elProducto);
        }

        // GET: Producto/Create
        public ActionResult CrearProducto()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public async Task<ActionResult> CrearProducto(ProductoDto elProductoCreado)
        {
            try
            {
                if (elProductoCreado.archivo != null && elProductoCreado.archivo.ContentLength > 0)
                {
                    // Convertir el archivo a un arreglo de bytes
                    byte[] archivoBytes;
                    using (var memoriaStream = new System.IO.MemoryStream())
                    {
                        elProductoCreado.archivo.InputStream.CopyTo(memoriaStream);
                        archivoBytes = memoriaStream.ToArray();
                    }

                    // Convertir el archivo a base64
                    string base64String = Convert.ToBase64String(archivoBytes);

                    string nombreArchivo = $"{elProductoCreado.Nombre}_{DateTime.Now.Ticks}";
                    GuardarArchivo(elProductoCreado.archivo, nombreArchivo);

                    string extension = Path.GetExtension(elProductoCreado.archivo.FileName);
                    elProductoCreado.ImagenUrl = nombreArchivo + extension;

                    int cantidadDeRegistros = await _crearProducto.Guardar(elProductoCreado);
                }
                else
                {
                    ModelState.AddModelError("archivo", "La imagen es requerida");
                    return View(elProductoCreado);
                }

                return RedirectToAction("ListarProducto");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                return View(elProductoCreado);
            }
        }

        // GET: Producto/Edit/5
        public ActionResult EditarProducto(int id)
        {
			ProductoDto elProducto = _obtenerProductoPorId.Obtener(id);
			return View(elProducto);
		}

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProducto(ProductoDto elProducto)
        {
            try
            {
                if (elProducto.archivo != null && elProducto.archivo.ContentLength > 0)
                {
                    string nombreArchivo = $"{elProducto.Nombre}_{DateTime.Now.Ticks}";
                    GuardarArchivo(elProducto.archivo, nombreArchivo);

                    string extension = Path.GetExtension(elProducto.archivo.FileName);
                    elProducto.ImagenUrl = nombreArchivo + extension;
                }

                int cantidadAfectada = _actualizarProducto.Actualizar(elProducto);
                return RedirectToAction("ListarProducto");
            }
            catch
            {
                return View(elProducto);
            }
        }

        // GET: Producto/Delete/5
        public ActionResult EliminarProducto(int id)
        {
            ProductoDto elProducto = _obtenerProductoPorId.Obtener(id);
            return View(elProducto);
        }

        // POST: Producto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EliminarProducto")] // Mantiene la ruta POST coherente con el formulario de la vista
        public ActionResult EliminarProductoConfirmado(int id)
        {
            try
            {
                // Elimina el registro de Producto indicado
                int cantidadAfectada = _eliminarProducto.Eliminar(id);
                return RedirectToAction("ListarProducto");
            }
            catch
            {
                return View();
            }
        }

        // Devuelve la imagen del repuesto por código o un placeholder si no existe
        public ActionResult ImagenDeProductoPorCodigo(string codigo)
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
