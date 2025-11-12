using System.ComponentModel.DataAnnotations;

namespace ControlDesk.Application.DTOs
{
    public class CreateTicketDto
    {

        public CreateTicketDto(string title, string description, int userIdCreated, int userIdAssigned, int userIdUpdate)
        {
            Title = title;
            Description = description;
            UserIdCreated = userIdCreated;
            UserIdAssigned = userIdAssigned;
            UserIdUpdate = userIdUpdate;
        }

        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        [Display(Name = "Titulo Ticket")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        [Display(Name = "Descripción")]
        public  string Description { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        [Display(Name = "Id Usuario de creación")]
        public int UserIdCreated { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio y no puede estar vacío")]
        [Display(Name = "Id Usuario de asignación")]
        public int UserIdAssigned { get; set; }

        public int UserIdUpdate { get; set; }
    }
}
