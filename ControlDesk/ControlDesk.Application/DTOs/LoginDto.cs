using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDesk.Application.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        public required string Password { get; set; }
    }
}
