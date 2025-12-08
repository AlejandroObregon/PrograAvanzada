using Inventario.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pedidos.Abstracciones.ModelosParaUI;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pedidos.UI.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = await userManager.FindAsync(model.Email, model.Password);

            if (user != null)
            {
                // Guardar en sesión
                Session["UsuarioId"] = user.Id;
                Session["UsuarioEmail"] = user.Email;
                Session["UsuarioNombre"] = user.NombreCompleto;
                Session["UsuarioRol"] = userManager.GetRoles(user.Id).FirstOrDefault();

                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            return View(model);
        }

        // GET: Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

                // Crear roles si no existen
                if (!await roleManager.RoleExistsAsync("Administrador"))
                    await roleManager.CreateAsync(new IdentityRole("Administrador"));
                if (!await roleManager.RoleExistsAsync("Ventas"))
                    await roleManager.CreateAsync(new IdentityRole("Ventas"));

                // Crear usuario
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    NombreCompleto = model.NombreCompleto
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Asignar rol
                    await userManager.AddToRoleAsync(user.Id, model.Rol);

                    // Iniciar sesión automáticamente
                    Session["UsuarioId"] = user.Id;
                    Session["UsuarioEmail"] = user.Email;
                    Session["UsuarioNombre"] = user.NombreCompleto;
                    Session["UsuarioRol"] = model.Rol;

                    TempData["Success"] = "¡Registro exitoso! Bienvenido " + model.NombreCompleto;
                    return RedirectToAction("Index", "Home");
                }

                AddErrors(result);
            }

            return View(model);
        }


        // Get: Account/Logout (para formulario)
        [HttpGet]
        public ActionResult Logout()
        {
            // Limpiar sesión
            Session.Clear();
            Session.Abandon();

            // Redirigir inmediatamente
            return RedirectToAction("Login");
        }

        #region Helpers
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}