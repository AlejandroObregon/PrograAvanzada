using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Pedidos.AccesoADatos.Modelos;
using Producto.UI.Models;

namespace Inventario.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager =>
            HttpContext.GetOwinContext().GetUserManager<UserManager<ApplicationUser>>();
        
        private SignInManager<ApplicationUser, string> SignInManager =>
        HttpContext.GetOwinContext().GetUserManager<SignInManager<ApplicationUser, string>>();
        
        private IAuthenticationManager AuthenticationManager =>
        HttpContext.GetOwinContext().Authentication;

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                false,
                shouldLockout: false);

            if (result == SignInStatus.Success)
            {
                return RedirectToLocal(returnUrl);
            }
            
            ModelState.AddModelError("", "Login failed.");
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}