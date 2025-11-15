using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pedidos.AccesoADatos;
using Pedidos.AccesoADatos.Modelos;

namespace Producto.UI
{
    public static class IdentitySeed
    {
        public static async Task SeedAsync()
        {
            using (var context = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));
                
                var userManager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));

                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }
                
                if (!await roleManager.RoleExistsAsync("Ventas"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Ventas"));
                }
                
                if (!await roleManager.RoleExistsAsync("Operaciones"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Operaciones"));
                }

                //Esto es para crear un usuario super admin default
                const string email = "camicarmo1110@gmail.com";
                const string password = "passwd123";
                
                var admin = await userManager.FindByEmailAsync(email);

                if (admin == null)
                {
                    admin = new ApplicationUser
                    {
                        UserName = email, 
                        Email = email,
                        Activo = true
                    };
                    
                    var result = await userManager.CreateAsync(admin, password);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(admin.Id, "Admin");
                    }
                }

                context.SaveChanges();
            }
        }
    }
}