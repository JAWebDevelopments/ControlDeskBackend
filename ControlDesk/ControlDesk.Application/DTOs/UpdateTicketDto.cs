using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDesk.Application.DTOs
{
    public class UpdateTicketDto
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        [Display(Name = "Titulo Ticket")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        [Display(Name = "Descripción")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        [Display(Name = "Estado")]
        public required int State { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        [Display(Name = "Id Usuario de creación")]
        public required int UserIdCreated { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        [Display(Name = "Id Usuario de asignación")]
        public required int UserIdAssigned { get; set; }

        public required int UserIdUpdate { get; set; }
    }
}
