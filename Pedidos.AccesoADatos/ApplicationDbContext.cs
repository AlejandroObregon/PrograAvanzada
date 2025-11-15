using Microsoft.AspNet.Identity.EntityFramework;
using Pedidos.AccesoADatos.Modelos;

namespace Pedidos.AccesoADatos
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("name=Contexto")
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}