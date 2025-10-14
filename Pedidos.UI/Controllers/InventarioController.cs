using Inventario.Abstracciones.LogicaDeNegocio.Inventario.CrearInventario;
using Inventario.Abstracciones.LogicaDeNegocio.Inventario.ListarInventario;
using Inventario.Abstracciones.LogicaDeNegocio.Inventario.ObtenerInventarioPorId;
using Inventario.Abstracciones.ModelosParaUI;
using Inventario.LogicaDeNegocio.Inventario.CrearInventario;
using Inventario.LogicaDeNegocio.Inventario.ListarInventario;
using Inventario.LogicaDeNegocio.Inventario.ObtenerInventarioPorId;
using Inventario.Abstracciones.LogicaDeNegocio.Inventario.ActualizarInventario;
using Inventario.Abstracciones.LogicaDeNegocio.Inventario.EliminarInventario;
using Inventario.LogicaDeNegocio.Inventario.ActualizarInventario;
using Inventario.LogicaDeNegocio.Inventario.EliminarInventario;
//using Inventario.LogicaDeNegocio.Inventario.ObtenerInventarioPorId;
// PISTA: Implementar EditarInventarioPorIdLN

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Inventario.UI.Controllers
{
    public class InventarioController : Controller
    {
        private IListarProductoLN _listarInventario;
        private ICrearProductoLN _crearInventario;
        private IObtenerProductoPorIdLN _obtenerInventarioPorId;
        private IActualizarInventarioLN _actualizarInventario;
        private IEliminarProductoLN _eliminarInventario;
		public InventarioController()
        {
            _listarInventario = new ListarProductosLN();
			_crearInventario = new CrearProductoLN();
			_obtenerInventarioPorId = new ObtenerProductoPorIdLN();
            // Implementar Actualizar y Eliminar en la capa de negocio
            _actualizarInventario = new ActualizarProductoLN();
            _eliminarInventario = new EliminarProductoLN();
        }


        // GET: Inventario
        public ActionResult ListarInventario()
        {
            List<InventarioDto> laListaDeInventario = _listarInventario.Obtener();
            int i = 0;
			return View(laListaDeInventario);
        }

        // GET: Inventario/Details/5
        public ActionResult DetallesInventario(int id)
        {
            InventarioDto elInventario = _obtenerInventarioPorId.Obtener(id);
			return View(elInventario);
        }

        // GET: Inventario/Create
        public ActionResult CrearInventario()
        {
            return View();
        }

        // POST: Inventario/Create
        [HttpPost]
        public async Task<ActionResult> CrearInventario(InventarioDto elInventarioCreado)
        {
            try
            {
				if (elInventarioCreado.archivo != null && elInventarioCreado.archivo.ContentLength > 0)
				{
                    // Convertir el archivo a un arreglo de bytes
                    int a = 1;
					byte[] archivoBytes;
					using (var memoriaStream = new System.IO.MemoryStream())
					{
						elInventarioCreado.archivo.InputStream.CopyTo(memoriaStream);
						archivoBytes = memoriaStream.ToArray();
					}

					// Convertir el archivo a base64
					string base64String = Convert.ToBase64String(archivoBytes);
                    // Guardar archivo físicamente por código de repuesto
                    GuardarArchivo(elInventarioCreado.archivo, elInventarioCreado.CodigoDelRepuesto);
                    int cantidadDeRegistros = await _crearInventario.Guardar(elInventarioCreado);

				}

				return RedirectToAction("ListarInventario");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventario/Edit/5
        public ActionResult EditarInventario(int id)
        {
			InventarioDto elInventario = _obtenerInventarioPorId.Obtener(id);
			return View(elInventario);
		}

        // POST: Inventario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarInventario(InventarioDto elInventario)
        {
            try
            {
                // Si adjuntaron nueva imagen, la guardamos
                if (elInventario.archivo != null && elInventario.archivo.ContentLength > 0)
                {
                    GuardarArchivo(elInventario.archivo, elInventario.CodigoDelRepuesto);
                }
                // Actualiza el inventario con los datos enviados desde el formulario
                int cantidadAfectada = _actualizarInventario.Actualizar(elInventario);
                return RedirectToAction("ListarInventario");
            }
            catch
            {
                // En caso de error, regresa a la vista con el modelo recibido
                return View(elInventario);
            }
        }

        // GET: Inventario/Delete/5
        public ActionResult EliminarInventario(int id)
        {
            InventarioDto elInventario = _obtenerInventarioPorId.Obtener(id);
            return View(elInventario);
        }

        // POST: Inventario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EliminarInventario")] // Mantiene la ruta POST coherente con el formulario de la vista
        public ActionResult EliminarInventarioConfirmado(int id)
        {
            try
            {
                // Elimina el registro de inventario indicado
                int cantidadAfectada = _eliminarInventario.Eliminar(id);
                return RedirectToAction("ListarInventario");
            }
            catch
            {
                return View();
            }
        }

        // Devuelve la imagen del repuesto por código o un placeholder si no existe
        public ActionResult ImagenDeInventarioPorCodigo(string codigo)
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
