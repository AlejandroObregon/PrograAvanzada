using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.AccesoADatos.Modelos
{
    [Table("Usuario")]
    public class UsuarioAD
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nombre")]
        public string NombreUsuario { get; set; }
        [Column("ContraseñaHash")]
        public string ContraseñaHash { get; set; }
        [Column("IdRol")]
        public int IdRol { get; set; }
        [Column("Activo")]
        public bool Activo { get; set; }
    }
}