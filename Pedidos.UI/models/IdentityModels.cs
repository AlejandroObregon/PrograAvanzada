using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Inventario.UI.Models  // o el namespace correcto de tu proyecto
{
    public class ApplicationUser : IdentityUser
    {
        // Agrega propiedades personalizadas si necesitas
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Constructor para usar tu esquema personalizado
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // Método estático para crear instancias
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // OPCIONAL: Si quieres que las tablas tengan nombres diferentes
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cambiar nombres de tablas (opcional)
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UsuarioRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UsuarioClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UsuarioLogins");
        }
    }
}