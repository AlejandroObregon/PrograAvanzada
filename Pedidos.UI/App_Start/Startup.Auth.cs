using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Pedidos.AccesoADatos;
using Pedidos.AccesoADatos.Modelos;

namespace Producto.UI
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<UserManager<ApplicationUser>>(CreateUserManager);
            app.CreatePerOwinContext<SignInManager<ApplicationUser, string>>(CreateSignInManager);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/User/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator
                        .OnValidateIdentity<UserManager<ApplicationUser>, ApplicationUser>(
                            validateInterval: TimeSpan.FromMinutes(30),
                            regenerateIdentity: (manager, user) =>
                                user.GenerateUserIdentityAsync(manager))
                }
            });
            
            //*SOLO USAR SI USAN LOGIN EXTERNO EJ: GOOGLE*//
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            
        }

        private static UserManager<ApplicationUser> CreateUserManager(
            IdentityFactoryOptions<UserManager<ApplicationUser>> options, IOwinContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>());
            var manager = new UserManager<ApplicationUser>(userStore);

            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 5,
                RequireDigit = true,
                RequireLowercase = true
            };
            
            return manager;
        }

        private static SignInManager<ApplicationUser, string> CreateSignInManager(
            IdentityFactoryOptions<SignInManager<ApplicationUser, string>> options, IOwinContext context)
        {
            return new SignInManager<ApplicationUser, string>(
                context.Get<UserManager<ApplicationUser>>(), context.Authentication);
        }
    }
}