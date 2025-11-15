using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.AccesoADatos.Modelos
{
    [Table("Rol")]
    public class RolAD
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Activo")]
        public bool Activo { get; set; }
    }
}