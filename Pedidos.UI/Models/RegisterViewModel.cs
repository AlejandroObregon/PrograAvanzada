using System.ComponentModel.DataAnnotations;

namespace Producto.UI.Models
{
    public class RegisterViewModel
    {
        [Required,  EmailAddress]
        public string Email { get; set; }
        
        [Required, StringLength(100, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string NameUser { get; set; }
        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}