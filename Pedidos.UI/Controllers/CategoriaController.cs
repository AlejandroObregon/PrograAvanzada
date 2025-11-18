using Pedidos.Abstracciones.LogicaDeNegocio.Categoria;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.ActualizarCategoria;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.CrearCategoria;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.EliminarCategoria;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.ListarCategorias;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.ObtenerCategoriaPorId;
using Pedidos.Abstracciones.LogicaDeNegocio.Categoria.ObtenerCategoriasActivas;
using Pedidos.Abstracciones.ModelosParaUI;
using Pedidos.LogicaDeNegocio.Categoria.ActualizarCategoria;
using Pedidos.LogicaDeNegocio.Categoria.CrearCategoria;
using Pedidos.LogicaDeNegocio.Categoria.EliminarCategoria;
using Pedidos.LogicaDeNegocio.Categoria.ListarCategoria;
using Pedidos.LogicaDeNegocio.Categoria.ObtenerCategoriaPorId;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Producto.UI.Controllers
{
    public class CategoriaController : Controller
    {
        private IListarCategoriasLN _listarCategorias;
        private ICrearCategoriaLN _crearCategoria;
        private IObtenerCategoriaPorIdLN _obtenerCategoriaPorId;
        private IObtenerCategoriasActivasLN _obtenerCategoriasActivas;
        private IActualizarCategoriaLN _actualizarCategoria;
        private IEliminarCategoriaLN _eliminarCategoria;

        public CategoriaController()
        {
            _listarCategorias = new ListarCategoriasLN();
            _crearCategoria = new CrearCategoriaLN();
            _obtenerCategoriaPorId = new ObtenerCategoriaPorIdLN();
            _actualizarCategoria = new ActualizarCategoriaLN();
            _eliminarCategoria = new EliminarCategoriaLN();
        }

        // GET: Categoria
        public ActionResult ListarCategoria()
        {
            try
            {
                List<CategoriaDto> laListaDeCategorias = _listarCategorias.Obtener();
                return View(laListaDeCategorias);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar las categorías: " + ex.Message;
                return View(new List<CategoriaDto>());
            }
        }

        // GET: Categoria/Details/5
        public ActionResult DetallesCategoria(int id)
        {
            try
            {
                CategoriaDto laCategoria = _obtenerCategoriaPorId.Obtener(id);
                if (laCategoria == null)
                {
                    ViewBag.Error = "Categoría no encontrada";
                    return RedirectToAction("ListarCategoria");
                }
                return View(laCategoria);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar la categoría: " + ex.Message;
                return RedirectToAction("ListarCategoria");
            }
        }

        // GET: Categoria/Create
        public ActionResult CrearCategoria()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearCategoria(CategoriaDto laCategoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int cantidadDeRegistros = await _crearCategoria.Guardar(laCategoria);
                    if (cantidadDeRegistros > 0)
                    {
                        TempData["Success"] = "Categoría creada exitosamente";
                        return RedirectToAction("ListarCategoria");
                    }
                    else
                    {
                        ViewBag.Error = "No se pudo crear la categoría";
                    }
                }
                return View(laCategoria);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al crear la categoría: " + ex.Message;
                return View(laCategoria);
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult EditarCategoria(int id)
        {
            try
            {
                CategoriaDto laCategoria = _obtenerCategoriaPorId.Obtener(id);
                if (laCategoria == null)
                {
                    ViewBag.Error = "Categoría no encontrada";
                    return RedirectToAction("ListarCategoria");
                }
                return View(laCategoria);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar la categoría: " + ex.Message;
                return RedirectToAction("ListarCategoria");
            }
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCategoria(CategoriaDto laCategoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int cantidadAfectada = _actualizarCategoria.Actualizar(laCategoria);
                    if (cantidadAfectada > 0)
                    {
                        TempData["Success"] = "Categoría actualizada exitosamente";
                        return RedirectToAction("ListarCategoria");
                    }
                    else
                    {
                        ViewBag.Error = "No se pudo actualizar la categoría";
                    }
                }
                return View(laCategoria);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al actualizar la categoría: " + ex.Message;
                return View(laCategoria);
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult EliminarCategoria(int id)
        {
            try
            {
                CategoriaDto laCategoria = _obtenerCategoriaPorId.Obtener(id);
                if (laCategoria == null)
                {
                    ViewBag.Error = "Categoría no encontrada";
                    return RedirectToAction("ListarCategoria");
                }
                return View(laCategoria);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al cargar la categoría: " + ex.Message;
                return RedirectToAction("ListarCategoria");
            }
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EliminarCategoria")]
        public ActionResult EliminarCategoriaConfirmado(int id)
        {
            try
            {
                int cantidadAfectada = _eliminarCategoria.Eliminar(id);
                if (cantidadAfectada > 0)
                {
                    TempData["Success"] = "Categoría eliminada exitosamente";
                }
                else
                {
                    TempData["Error"] = "No se pudo eliminar la categoría";
                }
                return RedirectToAction("ListarCategoria");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al eliminar la categoría: " + ex.Message;
                return RedirectToAction("ListarCategoria");
            }
        }

        [HttpGet]
        public JsonResult ObtenerCategoriasActivas()
        {
            try
            {
                var categoriasActivas = _obtenerCategoriasActivas.Obtener();
                return Json(categoriasActivas, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}