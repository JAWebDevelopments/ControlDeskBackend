using System.ComponentModel.DataAnnotations;

namespace ControlDesk.Application.DTOs
{
    public class DepartmentDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        [Display(Name = "Nombre del Departamento")]
        public required string DepartmentName { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        [Display(Name = "Descripción del departamento")]
        public required string DepartmentDescription { get; set; }
    }
}
