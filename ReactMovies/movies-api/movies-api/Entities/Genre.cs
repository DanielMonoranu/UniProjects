using movies_api.Validations;
using System.ComponentModel.DataAnnotations;

namespace movies_api.Entities
{
    public class Genre  
    {
        public int Id { get; set; }
        [FirstLetterUppercase]  //validateAtributtes
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
