using System.Data.Entity;

namespace Pedidos.AccesoADatos.Modelos
{
    public class ContextoRol : DbContext
    {
        public ContextoRol() : base("name=Contexto")
        {
            
        }
        
        public DbSet<RolAD> Roles { get; set; }
    }
}