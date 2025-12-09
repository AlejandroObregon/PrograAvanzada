using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pedidos.Abstracciones.ModelosParaUI
{
	public class ClienteDto
	{
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre solo puede contener letras y espacios.")]
        public string Nombre { get; set; }
		
        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "La cédula debe tener exactamente 9 dígitos.")]
        public string Cedula { get; set; } = string.Empty;
        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El correo es obligatorio.")]
        public string Correo { get; set; }
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El telefono es obligatorio.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El número telefonico debe tener exactamente 8 dígitos.")]
        public string Telefono { get; set; }
		public string Direccion { get; set; }
    }
}