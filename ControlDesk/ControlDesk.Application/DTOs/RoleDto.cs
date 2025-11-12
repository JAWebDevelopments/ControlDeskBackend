using System.ComponentModel.DataAnnotations;

namespace ControlDesk.Application.DTOs
{
    public class RoleDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        [Display(Name = "Nombre del rol")]
        public required string RoleName { get; set; }
    }
}
