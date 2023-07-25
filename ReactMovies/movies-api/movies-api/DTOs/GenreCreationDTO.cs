using movies_api.Validations;
using System.ComponentModel.DataAnnotations;

namespace movies_api.DTOs
{
    public class GenreCreationDTO
    {
        [FirstLetterUppercase]  //validateAtributtes
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(50)]
        public string Name { get; set; }

    }
}
